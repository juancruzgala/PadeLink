Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class agregar_jugadores
    Private ReadOnly _torneo As Torneo

    Public Sub New(t As Torneo)
        InitializeComponent()
        _torneo = t
    End Sub

    Private Sub agregar_jugadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)

        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Bahnschrift", 16.0F, FontStyle.Bold)
        lblTitulo.Text = If(_torneo Is Nothing, "Agregar jugadores", $"Agregar jugadores - {_torneo.nombre_torneo}")
        lblTitulo.Dock = DockStyle.None
        lblTitulo.Height = 50
        lblTitulo.Padding = New Padding(0, 15, 0, 0)
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter

        CentrarTitulo()

        cboSeniaPago.Items.Clear()
        cboSeniaPago.Items.AddRange(New Object() {"Pendiente", "Seña", "Pago Total"})
        If cboSeniaPago.Items.Count > 0 Then cboSeniaPago.SelectedIndex = 0

        txtJugador1.Select()
    End Sub

    Private Sub agregar_jugadores_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CentrarTitulo()
    End Sub

    Private Sub CentrarTitulo()
        If lblTitulo Is Nothing Then Return
        lblTitulo.Left = (Me.ClientSize.Width - lblTitulo.Width) \ 2
        lblTitulo.Top = 20
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim jugador1 As String = txtJugador1.Text.Trim()
        Dim jugador2 As String = txtJugador2.Text.Trim()
        Dim estado As String = If(cboSeniaPago.SelectedItem Is Nothing, "", cboSeniaPago.SelectedItem.ToString())

        If String.IsNullOrWhiteSpace(jugador1) OrElse String.IsNullOrWhiteSpace(jugador2) Then
            MessageBox.Show("Debés ingresar el nombre de ambos jugadores.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            RepositorioParejas.AgregarBD(_torneo, jugador1, jugador2, estado)
            MessageBox.Show("Pareja agregada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtJugador1.Clear() : txtJugador2.Clear()
            If cboSeniaPago.Items.Count > 0 Then cboSeniaPago.SelectedIndex = 0
            txtJugador1.Focus()
        Catch ex As SqlException
            MessageBox.Show("Error al agregar la pareja: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' =======================
    ' Inserta jugador si no existe
    ' =======================
    Private Function ObtenerOInsertarJugador(nombre As String) As Integer
        Dim id As Integer = 0
        Const sqlBuscar As String = "SELECT id_jugador FROM jugadores WHERE nombre = @nombre;"
        Const sqlInsertar As String = "INSERT INTO jugadores (nombre) OUTPUT INSERTED.id_jugador VALUES (@nombre);"

        Using cn = Conexion.GetConnection(), cmdBuscar As New SqlCommand(sqlBuscar, cn)
            cmdBuscar.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre
            cn.Open()
            Dim obj = cmdBuscar.ExecuteScalar()
            If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                id = Convert.ToInt32(obj)
                Return id
            End If

            ' No existe → insertar
            Using cmdInsertar As New SqlCommand(sqlInsertar, cn)
                cmdInsertar.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre
                id = Convert.ToInt32(cmdInsertar.ExecuteScalar())
            End Using
        End Using

        Return id
    End Function

    Private Sub btnListaInscriptos_Click(sender As Object, e As EventArgs) Handles btnListaInscriptos.Click
        FrmShell.ShowInShell(New lista_inscriptos(_torneo))
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Dim l As New lista_torneos() With {.Modo = ModoLista.GestionJugadores}
        FrmShell.ShowInShell(l)
    End Sub

End Class
