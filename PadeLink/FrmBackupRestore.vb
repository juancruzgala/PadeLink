Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmBackupRestore

    Private Const NOMBRE_BD As String = "PadeLink"
    Private Const FRASE_CONFIRMACION As String = "RESTAURAR PadeLink"
    Private lblStatus As Label


    Private Sub FrmBackupRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not String.Equals(SessionInfo.CurrentRole, "Administrador", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Acceso restringido a Administradores.", "Permisos",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Close()
        End If

        ' --- Configuración general ---
        Me.Text = "Mantenimiento de PadeLink"
        Me.BackColor = Color.WhiteSmoke
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.AutoScroll = True

        ' --- Crear layout contenedor ---
        Dim layout As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 9,
            .Padding = New Padding(40),
            .AutoScroll = True,       ' 🔹 permite scroll si la pantalla es chica
            .AutoSize = True,         ' 🔹 ajusta altura automáticamente
            .AutoSizeMode = AutoSizeMode.GrowAndShrink
        }


        layout.RowStyles.Clear()
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 8))   ' Backup título
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 5))  ' Backup destino
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 29))   ' Botones backup
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 6))   ' Restaurar título
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 10))  ' Origen backup
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 10))  ' Confirmación
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 10))  ' Checkbox
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 12))  ' Botón restaurar

        ' --- Sección BACKUP ---
        Label3.Text = "💾 Backup"
        Label3.Font = New Font("Bahnschrift SemiBold", 16, FontStyle.Bold)
        Label3.ForeColor = Color.FromArgb(33, 47, 61)
        Label3.TextAlign = ContentAlignment.MiddleCenter
        Label3.Dock = DockStyle.Fill

        Label2.Text = "📂 Backup destino:"
        Label2.Font = New Font("Bahnschrift", 12)
        Label2.AutoSize = True
        Label2.Anchor = AnchorStyles.None

        ' --- TextBox destino ---
        txtBackupDestino.Width = 400
        txtBackupDestino.Anchor = AnchorStyles.None
        txtBackupDestino.Margin = New Padding(10)

        ' --- Botón elegir destino ---
        btnElegirDestino.Text = "Elegir destino"
        btnElegirDestino.BackColor = Color.LightCyan
        btnElegirDestino.ForeColor = Color.Black
        btnElegirDestino.Font = New Font("Bahnschrift", 11, FontStyle.Regular)
        btnElegirDestino.Width = 160
        btnElegirDestino.Height = 40
        btnElegirDestino.FlatStyle = FlatStyle.Flat
        btnElegirDestino.FlatAppearance.BorderSize = 0
        btnElegirDestino.Anchor = AnchorStyles.None
        btnElegirDestino.Margin = New Padding(10)

        ' --- Panel con textbox + botón elegir destino ---
        Dim pnlDestino As New FlowLayoutPanel With {
    .FlowDirection = FlowDirection.LeftToRight,
    .Anchor = AnchorStyles.None,
    .AutoSize = True,
    .WrapContents = False,
    .AutoSizeMode = AutoSizeMode.GrowAndShrink,
    .Dock = DockStyle.None,
    .Margin = New Padding(0),
    .Padding = New Padding(0),
    .BackColor = Color.Transparent
}
        pnlDestino.Controls.AddRange({txtBackupDestino, btnElegirDestino})
        pnlDestino.Anchor = AnchorStyles.None
        pnlDestino.AutoScroll = False
        pnlDestino.Width = 700
        pnlDestino.Height = 55

        ' --- Botón Hacer Backup (debajo del textbox) ---
        btnHacerBackup.Text = "Hacer Backup"
        btnHacerBackup.Font = New Font("Bahnschrift SemiBold", 12)
        btnHacerBackup.BackColor = Color.FromArgb(46, 204, 113)
        btnHacerBackup.ForeColor = Color.White
        btnHacerBackup.Width = 180
        btnHacerBackup.Height = 30
        btnHacerBackup.FlatStyle = FlatStyle.Flat
        btnHacerBackup.FlatAppearance.BorderSize = 0
        btnHacerBackup.Anchor = AnchorStyles.None
        btnHacerBackup.Margin = New Padding(10)

        ' --- Panel general de la sección Backup ---
        Dim pnlBackup As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 2,
            .Anchor = AnchorStyles.None,
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
        pnlBackup.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        pnlBackup.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        pnlBackup.Controls.Add(pnlDestino, 0, 0)
        pnlBackup.Controls.Add(btnHacerBackup, 0, 1)


        ' --- Sección RESTAURAR ---
        Label1.Text = "🔁 Restaurar"
        Label1.Font = New Font("Bahnschrift SemiBold", 16, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(33, 47, 61)
        Label1.TextAlign = ContentAlignment.MiddleCenter
        Label1.Dock = DockStyle.Fill

        lblNombre.Text = "📂 Origen del Backup:"
        lblNombre.Font = New Font("Bahnschrift", 12)
        lblNombre.Anchor = AnchorStyles.None
        txtBakOrigen.Width = 400
        txtBakOrigen.Anchor = AnchorStyles.None
        btnElegirBak.Text = "Elegir Backup"
        btnElegirBak.BackColor = Color.LightCyan
        btnElegirBak.Width = 160
        btnElegirBak.Height = 40
        btnElegirBak.FlatStyle = FlatStyle.Flat
        btnElegirBak.FlatAppearance.BorderSize = 0
        btnElegirBak.Anchor = AnchorStyles.None
        btnElegirBak.AutoSize = True
        btnElegirBak.Font = New Font("Bahnschrift", 11, FontStyle.Regular)

        Dim pnlOrigen As New FlowLayoutPanel With {
            .FlowDirection = FlowDirection.LeftToRight,
            .Anchor = AnchorStyles.None,
            .AutoSize = True,
            .WrapContents = False,
            .AutoSizeMode = AutoSizeMode.GrowAndShrink,
            .Dock = DockStyle.None,
            .Margin = New Padding(0),
            .Padding = New Padding(0)
        }
        pnlOrigen.AutoScroll = False
        pnlOrigen.Anchor = AnchorStyles.None
        pnlOrigen.BackColor = Color.Transparent
        pnlOrigen.Width = 700
        pnlOrigen.Height = 50
        pnlOrigen.Controls.AddRange({txtBakOrigen, btnElegirBak})

        ' --- Confirmación ---
        Label4.Text = "✍️ Para restaurar escribí: RESTAURAR PadeLink"
        Label4.Font = New Font("Bahnschrift", 11)
        Label4.AutoSize = True
        Label4.Anchor = AnchorStyles.None
        txtConfirmacion.Width = 400
        txtConfirmacion.Anchor = AnchorStyles.None
        chkEstoySeguro.Font = New Font("Bahnschrift", 10)
        chkEstoySeguro.Anchor = AnchorStyles.None

        Dim pnlConfirm As New FlowLayoutPanel With {
            .FlowDirection = FlowDirection.TopDown,
            .Anchor = AnchorStyles.None,
            .AutoSize = True,
            .AutoSizeMode = AutoSizeMode.GrowAndShrink,
            .Dock = DockStyle.None,
            .Margin = New Padding(0),
            .Padding = New Padding(0),
            .WrapContents = True
        }
        pnlConfirm.AutoScroll = False
        pnlConfirm.Anchor = AnchorStyles.None
        pnlConfirm.BackColor = Color.Transparent
        pnlConfirm.Width = 700
        pnlConfirm.Height = 100
        pnlConfirm.Controls.AddRange({Label4, txtConfirmacion, chkEstoySeguro})

        ' --- Botón Restaurar ---
        btnRestaurar.Text = "Restaurar"
        btnRestaurar.Font = New Font("Bahnschrift SemiBold", 12)
        btnRestaurar.BackColor = Color.FromArgb(231, 76, 60)
        btnRestaurar.ForeColor = Color.White
        btnRestaurar.Width = 180
        btnRestaurar.Height = 30
        btnRestaurar.FlatStyle = FlatStyle.Flat
        btnRestaurar.FlatAppearance.BorderSize = 0
        btnRestaurar.Anchor = AnchorStyles.None
        btnRestaurar.AutoSize = True

        ' --- Agregar los elementos al layout ---
        layout.Controls.Add(Label3, 0, 0)
        layout.Controls.Add(Label2, 0, 1)
        layout.Controls.Add(pnlBackup, 0, 2)
        layout.Controls.Add(Label1, 0, 3)
        layout.Controls.Add(lblNombre, 0, 4)
        layout.Controls.Add(pnlOrigen, 0, 5)
        layout.Controls.Add(pnlConfirm, 0, 6)
        layout.Controls.Add(btnRestaurar, 0, 7)

        ' --- Limpiar y aplicar ---
        Me.Controls.Clear()
        Me.Controls.Add(layout)
        layout.Dock = DockStyle.Fill
        layout.BringToFront()

        ' ===== BOTÓN VOLVER =====
        Dim btnVolver As New Button With {
            .Text = "Volver",
            .Size = New Size(120, 40),
            .BackColor = Color.FromArgb(52, 73, 94),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Bahnschrift", 10.0F, FontStyle.Bold),
            .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right,
            .Location = New Point(Me.ClientSize.Width - 140, Me.ClientSize.Height - 80)
        }
        btnVolver.FlatAppearance.BorderSize = 0

        ' --- Acción al hacer clic ---
        AddHandler btnVolver.Click,
            Sub()
                ' Si estás usando navegación con el shell principal:
                FrmShell.ShowInShell(New frmBienvenida())

                ' Si quisieras abrirlo de forma independiente:
                'Dim f As New frmBienvenida()
                'f.Show()
                'Me.Close()
            End Sub

        ' --- Agregar el botón al formulario ---
        Me.Controls.Add(btnVolver)
        btnVolver.BringToFront()

        ' ===== LABEL STATUS =====
        lblStatus = New Label With {
            .AutoSize = False,
            .Text = "",
            .Font = New Font("Bahnschrift", 10.0F, FontStyle.Italic),
            .ForeColor = Color.FromArgb(60, 60, 60),
            .BackColor = Color.FromArgb(245, 247, 250),
            .TextAlign = ContentAlignment.MiddleLeft,
            .Dock = DockStyle.Bottom,
            .Height = 35,
            .Padding = New Padding(20, 0, 0, 0)
        }

        ' Agregamos el label al final del formulario, justo encima del botón Volver
        Me.Controls.Add(lblStatus)
        lblStatus.BringToFront()

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
            Dim nombreArchivo = $"{NOMBRE_BD}_{Date.Now:yyyy-MM-dd_HH-mm}.bak"
            Dim destinoServidor = BuildServerBackupPath(nombreArchivo)
            HacerBackupBase(NOMBRE_BD, destinoServidor)
            VerificarBackup(destinoServidor)
            Try
                File.Copy(destinoServidor, txtBackupDestino.Text, overwrite:=True)
            Catch
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
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cn.Open()
            Dim obj = cmd.ExecuteScalar()
            If obj IsNot DBNull.Value AndAlso obj IsNot Nothing Then
                ruta = obj.ToString()
            End If
        End Using
        Return ruta
    End Function

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
            VerificarBackup(txtBakOrigen.Text)
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
        Using cn = Conexion.GetConnection()
            cn.Open()
            Using c0 As New SqlCommand("USE master;", cn)
                c0.ExecuteNonQuery()
            End Using
            Using c1 As New SqlCommand(
                $"ALTER DATABASE [{nombreBd}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", cn)
                c1.CommandTimeout = 0
                c1.ExecuteNonQuery()
            End Using
            Using c2 As New SqlCommand(
                $"RESTORE DATABASE [{nombreBd}] " &
                $"FROM DISK = N'{pathEscapado}' " &
                $"WITH REPLACE, RECOVERY, STATS = 5;", cn)
                c2.CommandTimeout = 0
                c2.ExecuteNonQuery()
            End Using
            Using c3 As New SqlCommand(
                $"ALTER DATABASE [{nombreBd}] SET MULTI_USER;", cn)
                c3.CommandTimeout = 0
                c3.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
