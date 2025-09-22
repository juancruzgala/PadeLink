Imports System.Drawing

Public Class editar_pareja

    Private ReadOnly _torneo As Torneo
    Private ReadOnly _pareja As ParejaTorneo

    Public Sub New(t As Torneo, p As ParejaTorneo)
        InitializeComponent()
        _torneo = t
        _pareja = p
    End Sub

    Private Sub editar_pareja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Editar Pareja"
        Me.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)

        lblTitulo.Text = "Editar Pareja"
        lblTitulo.Font = New Font("Bahnschrift", 14.0F, FontStyle.Bold)
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 40

        txtJugador1.Text = _pareja.Jugador1
        txtJugador2.Text = _pareja.Jugador2

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Validaciones 
        If String.IsNullOrWhiteSpace(txtJugador1.Text) OrElse String.IsNullOrWhiteSpace(txtJugador2.Text) Then
            MessageBox.Show("Completá los nombres de ambos jugadores.",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        _pareja.Jugador1 = txtJugador1.Text.Trim()
        _pareja.Jugador2 = txtJugador2.Text.Trim()

        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class