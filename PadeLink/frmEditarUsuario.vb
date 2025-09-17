Imports System.Data.SqlClient

Public Class frmEditarUsuario
    Private _idUsuario As Integer

    Public Sub New(idUsuario As Integer, nombre As String, contrasena As String, idRol As Integer)
        InitializeComponent()
        _idUsuario = idUsuario

        ' Cargar roles antes de asignar valor seleccionado
        CargarRoles()

        TxtNombre.Text = nombre
        txtContrasena.Text = contrasena
        cboRol.SelectedValue = idRol
    End Sub
    Private Sub CargarRoles()
        Using cn As New SqlConnection("Server=BESTIAGALARZA;Database=PadeLink;Trusted_Connection=True;")
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
        Using cn As New SqlConnection("Server=BESTIAGALARZA;Database=PadeLink;Trusted_Connection=True;")
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



End Class
