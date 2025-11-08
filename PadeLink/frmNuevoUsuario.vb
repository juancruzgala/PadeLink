Imports System.Data.SqlClient

Public Class frmNuevoUsuario

    Public Sub New()
        InitializeComponent()
        CargarRoles()
    End Sub

    Private Sub frmNuevoUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 🔹 Se ajusta automáticamente al tamaño del panel dentro del Shell
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.WindowState = FormWindowState.Normal
        Me.TopLevel = False
        pnlMain.AutoScroll = True
        pnlMain.Dock = DockStyle.Fill
    End Sub

    Private Sub CargarRoles()
        Using cn As SqlConnection = Conexion.GetConnection()
            cn.Open()
            Dim da As New SqlDataAdapter("SELECT id_rol, nombre_rol FROM Roles", cn)
            Dim dt As New DataTable()
            da.Fill(dt)
            cboRol.DataSource = dt
            cboRol.DisplayMember = "nombre_rol"
            cboRol.ValueMember = "id_rol"
        End Using
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If String.IsNullOrWhiteSpace(TxtNombre.Text) OrElse String.IsNullOrWhiteSpace(txtContrasena.Text) Then
            MessageBox.Show("Completá nombre y contraseña")
            Return
        End If

        Using cn As SqlConnection = Conexion.GetConnection()
            cn.Open()
            Dim cmd As New SqlCommand("INSERT INTO Usuarios (nombre_usuario, contraseña, estado, id_rol)
                                       VALUES (@n,@p,'A',@r)", cn)
            cmd.Parameters.AddWithValue("@n", TxtNombre.Text)
            cmd.Parameters.AddWithValue("@p", txtContrasena.Text)
            cmd.Parameters.AddWithValue("@r", CInt(cboRol.SelectedValue))
            cmd.ExecuteNonQuery()
        End Using

        MessageBox.Show("Usuario creado correctamente")
        FrmShell.ShowInShell(New frmListaUsuarios())
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        FrmShell.ShowInShell(New frmListaUsuarios())
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click

        Dim mensaje As String =
        "🎾 **Bienvenido al formulario de creación de usuarios** 🎾" & vbCrLf & vbCrLf &
        "🧑‍💻 En el campo **'Nombre de usuario'**, escriba el nombre del nuevo usuario que desea crear." & vbCrLf &
        "🔒 En el campo **'Contraseña'**, ingrese una clave segura para ese usuario." & vbCrLf &
        "⚙️ En el campo **'Rol'**, seleccione el tipo de usuario que desea asignar." & vbCrLf & vbCrLf &
        "📋 **IMPORTANTE — Funcionalidades según el rol:**" & vbCrLf &
        "👑 **Administrador:** gestiona usuarios, reportes, mantenimiento y visualiza torneos." & vbCrLf &
        "🏟️ **Canchero:** gestiona torneos, jugadores y realiza seguimiento de partidos." & vbCrLf &
        "🧾 **Fiscal:** fiscaliza jugadores, visualiza torneos y anota resultados de partidos." & vbCrLf & vbCrLf &
        "💡 Complete todos los campos y presione **Guardar** para crear el nuevo usuario o Cancelar si entro aqui por error!."

        MessageBox.Show(mensaje, "Ayuda — Crear nuevo usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
