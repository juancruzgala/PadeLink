Imports System.Data.SqlClient

Public Class Frmlogin

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usuario = txtUsuario.Text.Trim()
        Dim contrasena = txtContrasena.Text

        Dim info = ObtenerUsuario(usuario, contrasena) ' devuelve (id, nombre, rol)
        If info Is Nothing Then
            MessageBox.Show("Usuario/contraseña incorrectos o usuario inactivo",
                            "No se pudo iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' --- SETEAR SESIÓN ---
        SessionInfo.id_usuario = info.Value.id_usuario
        SessionInfo.CurrentUser = info.Value.nombre_usuario
        SessionInfo.CurrentRole = info.Value.rol

        ' --- Abrir Shell y mostrar la vista de bienvenida ---
        Dim shell As FrmShell = If(FrmShell.Current, New FrmShell())
        FrmShell.Current = shell

        If Not shell.Visible Then
            shell.Show()
        End If

        ' Mostrar la pantalla de bienvenida personalizada según el rol
        shell.ShowForm(New frmBienvenida())

        ' Ocultar el login
        Me.Hide()
    End Sub

    ' Devuelve (id_usuario, nombre_usuario, rol) si el login es válido, sino Nothing
    Private Function ObtenerUsuario(user As String, pass As String) As (id_usuario As Integer, nombre_usuario As String, rol As String)?
        Using cn As SqlConnection = Conexion.GetConnection()
            cn.Open()
            Dim sql As String =
"SELECT TOP (1)
        u.id_usuario,
        u.nombre_usuario,
        r.nombre_rol
   FROM dbo.Usuarios u
   JOIN dbo.Roles r ON r.id_rol = u.id_rol
  WHERE u.nombre_usuario = @u
    AND u.[contraseña]   = @p
    AND (u.estado = 'A' OR u.estado = 1);"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@u", user)
                cmd.Parameters.AddWithValue("@p", pass)

                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        Return (rd.GetInt32(0), rd.GetString(1), rd.GetString(2))
                    End If
                End Using
            End Using
        End Using
        Return Nothing
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

    Private Sub Frmlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' opcional: txtUsuario.Focus()
    End Sub

End Class

