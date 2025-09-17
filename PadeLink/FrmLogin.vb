Public Class Frmlogin
    Private Sub Frmlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim usuario As String = txtUsuario.Text
        Dim contrasena As String = txtContrasena.Text

        'Obtenemos el rol directamente de la BD
        Dim rolEncontrado As String = ObtenerRolUsuario(usuario, contrasena)

        If rolEncontrado IsNot Nothing Then
            Select Case rolEncontrado
                Case "Administrador"
                    Dim f As New frmListaUsuarios
                    f.Show()
                Case "Canchero"
                    Dim f As New frmCanchero
                    f.Show()
                Case "Fiscal"
                    Dim f As New frmFiscal
                    f.Show()
                Case Else
                    MessageBox.Show("Rol desconocido: " & rolEncontrado)
            End Select
            Me.Hide()
        Else
            MessageBox.Show("Usuario/contraseña incorrectos o usuario inactivo")
        End If
    End Sub

    Private Function ObtenerRolUsuario(user As String, pass As String) As String
        Dim rolEncontrado As String = Nothing
        Using cn As SqlClient.SqlConnection = Conexion.GetConnection()
            cn.Open()
            Dim sql As String =
                "SELECT r.nombre_rol 
             FROM Usuarios u
             INNER JOIN Roles r ON u.id_rol = r.id_rol
             WHERE u.nombre_usuario=@u AND u.contraseña=@p AND u.estado='A';"
            Using cmd As New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@u", user)
                cmd.Parameters.AddWithValue("@p", pass)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    rolEncontrado = result.ToString()
                End If
            End Using
        End Using
        Return rolEncontrado
    End Function

End Class
