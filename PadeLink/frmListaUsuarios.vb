Imports System.Data.SqlClient

Public Class frmListaUsuarios

    Private Sub frmListaUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvUsuarios.AutoGenerateColumns = True
        CargarUsuarios()

        If dgvUsuarios.Columns.Contains("colBloquear") = False Then
            Dim btnCol As New DataGridViewButtonColumn()
            btnCol.Name = "colBloquear"
            btnCol.HeaderText = "Opción"
            btnCol.Text = "Bloquear"
            btnCol.UseColumnTextForButtonValue = True
            dgvUsuarios.Columns.Add(btnCol)
        End If

        If dgvUsuarios.Columns.Contains("colEditar") = False Then
            Dim btnEdit As New DataGridViewButtonColumn()
            btnEdit.Name = "colEditar"
            btnEdit.HeaderText = ""
            btnEdit.Text = "Editar"
            btnEdit.UseColumnTextForButtonValue = True
            dgvUsuarios.Columns.Add(btnEdit)
        End If

        dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub CargarUsuarios()
        Using cn As SqlConnection = Conexion.GetConnection()
            cn.Open()

            Dim sql As String =
            "SELECT 
                u.id_usuario AS IdUsuario,
                u.nombre_usuario AS NombreUsuario,
                u.contraseña AS Contrasena,
                u.estado AS Estado,
                u.id_rol AS IdRol,        
                r.nombre_rol AS RolNombre 
             FROM Usuarios u
             INNER JOIN Roles r ON u.id_rol = r.id_rol"

            Dim da As New SqlDataAdapter(sql, cn)
            Dim dt As New DataTable()
            da.Fill(dt)

            dgvUsuarios.DataSource = dt
        End Using

        If dgvUsuarios.Columns.Contains("Contrasena") Then
            dgvUsuarios.Columns("Contrasena").Visible = False
        End If
    End Sub

    Private Sub dgvUsuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentClick
        If e.RowIndex >= 0 Then


            Dim id As Integer = CInt(dgvUsuarios.Rows(e.RowIndex).Cells("IdUsuario").Value)

            Select Case dgvUsuarios.Columns(e.ColumnIndex).Name
                Case "colBloquear"
                    BloquearUsuario(id)

                Case "colEditar"
                    Dim nombre As String = dgvUsuarios.Rows(e.RowIndex).Cells("NombreUsuario").Value.ToString()
                    Dim contrasena As String = dgvUsuarios.Rows(e.RowIndex).Cells("Contrasena").Value.ToString()
                    Dim idRol As Integer = CInt(dgvUsuarios.Rows(e.RowIndex).Cells("IdRol").Value)
                    Dim f As New frmEditarUsuario(id, nombre, contrasena, idRol)
                    f.ShowDialog()
                    CargarUsuarios()
            End Select
        End If
    End Sub

    Private Sub BloquearUsuario(idUsuario As Integer)
        Using cn As SqlConnection = Conexion.GetConnection()
            cn.Open()
            Dim cmd As New SqlCommand("
            UPDATE Usuarios 
            SET estado = CASE WHEN estado='A' THEN 'I' ELSE 'A' END 
            WHERE id_usuario=@id", cn)
            cmd.Parameters.AddWithValue("@id", idUsuario)
            cmd.ExecuteNonQuery()
        End Using
        CargarUsuarios()
    End Sub

    Private Sub btnCrearUsuario_Click(sender As Object, e As EventArgs) Handles btnCrearUsuario.Click

        FrmShell.ShowInShell(New frmNuevoUsuario())
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        FrmShell.ShowInShell(New frmBienvenida())
    End Sub
End Class
