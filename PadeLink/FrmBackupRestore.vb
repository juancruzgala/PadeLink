Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmBackupRestore

    Private Const NOMBRE_BD As String = "PadeLink"   ' <-- ajustá si tu BD se llama distinto
    Private Const FRASE_CONFIRMACION As String = "RESTAURAR PadeLink"

    Private Sub FrmBackupRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Mantenimiento: Backup / Restore"
        lblStatus.Text = ""
        txtBackupDestino.ReadOnly = True
        txtBakOrigen.ReadOnly = True
        btnRestaurar.Enabled = False

        ' Sólo admin puede ver/usar este form
        If Not String.Equals(SessionInfo.CurrentRole, "Administrador", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Acceso restringido a Administradores.", "Permisos",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Close()
        End If
    End Sub

    ' ================== BACKUP ==================
    Private Sub btnElegirDestino_Click(sender As Object, e As EventArgs) Handles btnElegirDestino.Click
        Using sfd As New SaveFileDialog()
            sfd.Title = "Guardar backup"
            sfd.Filter = "Backup SQL Server (*.bak)|*.bak"
            sfd.FileName = $"{NOMBRE_BD}_{Date.Now:yyyy-MM-dd_HH-mm}.bak"
            If sfd.ShowDialog(Me) = DialogResult.OK Then
                txtBackupDestino.Text = sfd.FileName
            End If
        End Using
    End Sub

    Private Sub btnHacerBackup_Click(sender As Object, e As EventArgs) Handles btnHacerBackup.Click
        If String.IsNullOrWhiteSpace(txtBackupDestino.Text) Then
            MessageBox.Show("Elegí un destino para el archivo .bak", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' 🔹 1) Nombre sugerido del archivo
            Dim nombreArchivo = $"{NOMBRE_BD}_{Date.Now:yyyy-MM-dd_HH-mm}.bak"

            ' 🔹 2) Ruta segura dentro del servidor (carpeta con permisos)
            Dim destinoServidor = BuildServerBackupPath(nombreArchivo)

            ' 🔹 3) Ejecutar backup en la carpeta del servidor
            HacerBackupBase(NOMBRE_BD, destinoServidor)

            ' 🔹 4) Verificar backup
            VerificarBackup(destinoServidor)

            ' 🔹 5) Intentar copiar a donde eligió el usuario (si permite)
            Try
                File.Copy(destinoServidor, txtBackupDestino.Text, overwrite:=True)
            Catch
                ' Si no se pudo copiar, al menos quedó en el servidor
            End Try

            lblStatus.Text = $"✅ Backup realizado en: {destinoServidor}"
            MessageBox.Show($"Backup realizado correctamente." & vbCrLf &
                        $"Archivo en servidor: {destinoServidor}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            lblStatus.Text = "❌ Error en backup: " & ex.Message
            MessageBox.Show("No se pudo completar el backup." & Environment.NewLine & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function GetDefaultBackupPath() As String
        Dim ruta As String = ""
        Const sql As String = "
DECLARE @p NVARCHAR(4000);
EXEC master.dbo.xp_instance_regread
    N'HKEY_LOCAL_MACHINE',
    N'SOFTWARE\Microsoft\MSSQLServer\MSSQLServer',
    N'BackupDirectory',
    @p OUTPUT, 'no_output';
SELECT @p;"
        Using cn = Conexion.GetConnection(), cmd As New SqlClient.SqlCommand(sql, cn)
            cn.Open()
            Dim obj = cmd.ExecuteScalar()
            If obj IsNot DBNull.Value AndAlso obj IsNot Nothing Then
                ruta = obj.ToString()
            End If
        End Using
        Return ruta
    End Function

    ' Guarda siempre en la carpeta de backup del servidor (ignora directorios sin permiso)
    Private Function BuildServerBackupPath(nombreArchivo As String) As String
        Dim baseDir = GetDefaultBackupPath()
        If String.IsNullOrWhiteSpace(baseDir) Then baseDir = "C:\Program Files\Microsoft SQL Server\MSSQL\Backup"
        If Not baseDir.EndsWith("\") Then baseDir &= "\"
        Return baseDir & nombreArchivo
    End Function

    ' ================== RESTORE ==================
    Private Sub btnElegirBak_Click(sender As Object, e As EventArgs) Handles btnElegirBak.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Seleccionar backup (.bak)"
            ofd.Filter = "Backup SQL Server (*.bak)|*.bak"
            If ofd.ShowDialog(Me) = DialogResult.OK Then
                txtBakOrigen.Text = ofd.FileName
            End If
        End Using
        EvaluarHabilitarRestore()
    End Sub

    Private Sub txtConfirmacion_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmacion.TextChanged
        EvaluarHabilitarRestore()
    End Sub

    Private Sub chkEstoySeguro_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstoySeguro.CheckedChanged
        EvaluarHabilitarRestore()
    End Sub

    Private Sub EvaluarHabilitarRestore()
        btnRestaurar.Enabled =
            Not String.IsNullOrWhiteSpace(txtBakOrigen.Text) AndAlso
            chkEstoySeguro.Checked AndAlso
            String.Equals(txtConfirmacion.Text.Trim(), FRASE_CONFIRMACION, StringComparison.Ordinal)
    End Sub

    Private Sub btnRestaurar_Click(sender As Object, e As EventArgs) Handles btnRestaurar.Click
        If Not btnRestaurar.Enabled Then Return

        If MessageBox.Show(
            "Vas a restaurar la base completa desde el .bak seleccionado." & Environment.NewLine &
            "Esto detendrá conexiones y reemplazará los datos actuales." & Environment.NewLine &
            "¿Confirmás continuar?",
            "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Return
        End If

        Try
            ' 1) Verificar el .bak
            VerificarBackup(txtBakOrigen.Text)

            ' 2) Restaurar (Single-User, Restore, Multi-User)
            RestaurarDesdeBak(NOMBRE_BD, txtBakOrigen.Text)

            lblStatus.Text = "✅ Restore finalizado correctamente."
            MessageBox.Show("Base restaurada exitosamente." & Environment.NewLine &
                            "Reiniciá la app si ves comportamientos extraños.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            lblStatus.Text = "❌ Error en restore: " & ex.Message
            MessageBox.Show("No se pudo restaurar la base." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================== SQL helpers ==================

    Private Sub HacerBackupBase(nombreBd As String, destinoBak As String)
        Dim pathEscapado = destinoBak.Replace("'", "''")
        Dim sql As String =
$"BACKUP DATABASE [{nombreBd}]
   TO DISK = N'{pathEscapado}'
   WITH INIT, FORMAT, COPY_ONLY, COMPRESSION, STATS = 5;"

        Using cn = Conexion.GetConnection()
            cn.Open()
            Using cmd As New SqlCommand("USE master;", cn) : cmd.ExecuteNonQuery() : End Using
            Using cmd As New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub VerificarBackup(destinoBak As String)
        Dim pathEscapado = destinoBak.Replace("'", "''")
        Dim sql As String = $"RESTORE VERIFYONLY FROM DISK = N'{pathEscapado}';"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub RestaurarDesdeBak(nombreBd As String, bakPath As String)
        Dim pathEscapado = bakPath.Replace("'", "''")

        ' Ejecutar cada paso por separado, SIN transacción
        Using cn = Conexion.GetConnection()
            cn.Open()

            ' Cambiar el contexto a master para no tener la DB objetivo en uso
            Using c0 As New SqlCommand("USE master;", cn)
                c0.ExecuteNonQuery()
            End Using

            ' 1) Forzar SINGLE_USER y cerrar conexiones
            Using c1 As New SqlCommand(
                $"ALTER DATABASE [{nombreBd}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", cn)
                c1.CommandTimeout = 0
                c1.ExecuteNonQuery()
            End Using

            ' 2) Restaurar desde el .bak
            Using c2 As New SqlCommand(
                $"RESTORE DATABASE [{nombreBd}] " &
                $"FROM DISK = N'{pathEscapado}' " &
                $"WITH REPLACE, RECOVERY, STATS = 5;", cn)
                c2.CommandTimeout = 0
                c2.ExecuteNonQuery()
            End Using

            ' 3) Volver a MULTI_USER (hacerlo aunque la restauración ya lo deja accesible)
            Using c3 As New SqlCommand(
                $"ALTER DATABASE [{nombreBd}] SET MULTI_USER;", cn)
                c3.CommandTimeout = 0
                c3.ExecuteNonQuery()
            End Using
        End Using
    End Sub


End Class
