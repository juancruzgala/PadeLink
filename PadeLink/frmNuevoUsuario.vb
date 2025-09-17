Imports System.Data.SqlClient

Public Class frmNuevoUsuario

    Public Sub New()
        InitializeComponent()
        'Cargar roles apenas abra
        CargarRoles()
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
        'Validar campos
        If String.IsNullOrWhiteSpace(TxtNombre.Text) OrElse String.IsNullOrWhiteSpace(txtContrasena.Text) Then
            MessageBox.Show("Completá nombre y contraseña")
            Return
        End If

        Using cn As New SqlConnection("Server=BESTIAGALARZA;Database=PadeLink;Trusted_Connection=True;")
            cn.Open()
            Dim cmd As New SqlCommand("INSERT INTO Usuarios (nombre_usuario, contraseña, estado, id_rol)
                                       VALUES (@n,@p,'A',@r)", cn)
            cmd.Parameters.AddWithValue("@n", TxtNombre.Text)
            cmd.Parameters.AddWithValue("@p", txtContrasena.Text)
            cmd.Parameters.AddWithValue("@r", CInt(cboRol.SelectedValue))
            cmd.ExecuteNonQuery()
        End Using

        MessageBox.Show("Usuario creado correctamente")
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class
