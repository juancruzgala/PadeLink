Imports System.Data.SqlClient

Public Class frmEditarUsuario
    Private _idUsuario As Integer

    Public Sub New(idUsuario As Integer, nombre As String, contrasena As String, idRol As Integer)
        InitializeComponent()
        _idUsuario = idUsuario

        CargarRoles()

        TxtNombre.Text = nombre
        txtContrasena.Text = contrasena
        cboRol.SelectedValue = idRol
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
        Using cn As SqlConnection = Conexion.GetConnection()
            cn.Open()
            Dim cmd As New SqlCommand("UPDATE Usuarios 
                                   SET nombre_usuario=@n, contraseña=@p, id_rol=@r
                                   WHERE id_usuario=@id", cn)
            cmd.Parameters.AddWithValue("@n", TxtNombre.Text)
            cmd.Parameters.AddWithValue("@p", txtContrasena.Text)
            cmd.Parameters.AddWithValue("@r", CInt(cboRol.SelectedValue))
            cmd.Parameters.AddWithValue("@id", _idUsuario)
            cmd.ExecuteNonQuery()
        End Using
        MessageBox.Show("Usuario actualizado correctamente")
        Me.Close()
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmEditarUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Centrar los botones dentro del panel
        Dim espacioEntreBotones As Integer = 40
        Dim anchoTotal As Integer = (btnGuardar.Width + btnCancelar.Width + espacioEntreBotones)

        btnGuardar.Left = (pnlContenido.Width - anchoTotal) \ 2
        btnGuardar.Top = 240

        btnCancelar.Left = btnGuardar.Left + btnGuardar.Width + espacioEntreBotones
        btnCancelar.Top = btnGuardar.Top

    End Sub

    ' --- Pegar dentro de la clase frmEditarUsuario ---

    Private Sub CenterButtons()
        ' margen entre los botones
        Dim gap As Integer = 40
        Dim total As Integer = btnGuardar.Width + gap + btnCancelar.Width

        ' Y centrado horizontal dentro del panel blanco
        Dim x As Integer = (pnlContenido.ClientSize.Width - total) \ 2

        btnGuardar.Left = x
        btnCancelar.Left = x + btnGuardar.Width + gap

        ' Opcional: fija la altura de los botones por si el layout cambió
        btnGuardar.Top = 240
        btnCancelar.Top = btnGuardar.Top
    End Sub

    ' 1) Al cargar, pero *después* del layout inicial
    Private Sub frmEditarUsuario_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CenterButtons()
    End Sub

    ' 2) Si el panel cambia de tamaño (por resize de la ventana)
    Private Sub pnlContenido_SizeChanged(sender As Object, e As EventArgs) Handles pnlContenido.SizeChanged
        CenterButtons()
    End Sub

    ' 3) Por si el formulario cambia de tamaño y el panel se recoloca
    Private Sub frmEditarUsuario_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' mantén el panel centrado como ya tenías…
        pnlContenido.Left = (Me.ClientSize.Width - pnlContenido.Width) \ 2
        pnlContenido.Top = (Me.ClientSize.Height - pnlContenido.Height) \ 2 + 20

        CenterButtons()
    End Sub


End Class
