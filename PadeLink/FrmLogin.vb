Imports System.Data.SqlClient

Public Class Frmlogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usuario = txtUsuario.Text.Trim()
        Dim contrasena = txtContrasena.Text

        Dim rol = ObtenerRolUsuario(usuario, contrasena)
        If rol Is Nothing Then
            MessageBox.Show("Usuario/contraseña incorrectos o usuario inactivo")
            Exit Sub
        End If

        SessionInfo.CurrentUser = usuario
        SessionInfo.CurrentRole = rol

        Dim shell As New FrmShell()
        shell.Show()

        Dim startForm As Form
        Select Case rol
            Case "Administrador" : startForm = New frmListaUsuarios()
            Case "Canchero" : startForm = New crear_torneo()
            Case "Fiscal" : startForm = New lista_torneos()
            Case Else
                MessageBox.Show("Rol desconocido: " & rol)
                Exit Sub
        End Select

        shell.ShowForm(startForm)

        Me.Hide()
    End Sub

    Private Function ObtenerRolUsuario(user As String, pass As String) As String
        Dim rolEncontrado As String = Nothing
        Using cn As SqlConnection = Conexion.GetConnection()
            cn.Open()
            Dim sql As String =
                "SELECT TOP(1) r.nombre_rol
                   FROM dbo.Usuarios u
                   JOIN dbo.Usuarios ur ON u.id_usuario = ur.id_usuario
                   JOIN dbo.Roles r          ON ur.id_rol     = r.id_rol
                  WHERE u.nombre_usuario = @u
                    AND u.[contraseña]  = @p
                    AND u.estado        = 'A';"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@u", user)
                cmd.Parameters.AddWithValue("@p", pass)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then rolEncontrado = result.ToString()
            End Using
        End Using
        Return rolEncontrado
    End Function

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Dim msg =
            "📌 Ayuda para iniciar sesión:" & vbCrLf & vbCrLf &
            "1) Escribí tu usuario." & vbCrLf &
            "2) Escribí tu contraseña." & vbCrLf &
            "3) Presioná 'Ingresar'." & vbCrLf & vbCrLf &
            "Si la olvidaste, contactá al administrador."
        MessageBox.Show(msg, "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
