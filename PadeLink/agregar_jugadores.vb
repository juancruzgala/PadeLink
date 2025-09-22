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
        lblTitulo.Text = If(_torneo Is Nothing, "Agregar jugadores", _torneo.Nombre)
        lblTitulo.Dock = DockStyle.None
        lblTitulo.Height = 50
        lblTitulo.Padding = New Padding(0, 15, 0, 0)
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter

        CentrarTitulo()

        cboSeniaPago.Items.Clear()
        cboSeniaPago.Items.AddRange(New Object() {"Seña 50%", "Pagado"})
        If cboSeniaPago.Items.Count > 0 Then cboSeniaPago.SelectedIndex = 0

        txtJugador1.Select()
    End Sub

    ' Mantiene el título centrado 
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

        ' Validaciones
        If String.IsNullOrWhiteSpace(jugador1) OrElse String.IsNullOrWhiteSpace(jugador2) Then
            MessageBox.Show("Debés ingresar el nombre de ambos jugadores.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim pareja As New ParejaTorneo With {
            .Jugador1 = jugador1,
            .Jugador2 = jugador2,
            .SeniaOPago = estado,
            .Fecha = Date.Now
        }

        ' Guarda en repositorio 
        RepositorioParejas.Agregar(_torneo, pareja)

        MessageBox.Show("Pareja agregada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

        txtJugador1.Clear()
        txtJugador2.Clear()
        If cboSeniaPago.Items.Count > 0 Then cboSeniaPago.SelectedIndex = 0
        txtJugador1.Focus()
    End Sub

    Private Sub btnListaInscriptos_Click(sender As Object, e As EventArgs) Handles btnListaInscriptos.Click
        ShellHost.ShowInShell(New lista_inscriptos(_torneo))
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Dim l As New lista_torneos() With {.Modo = ModoLista.GestionJugadores}
        ShellHost.ShowInShell(l)
    End Sub
End Class