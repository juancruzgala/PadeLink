Imports PadeLink
Imports System.Drawing

' Modo
Public Enum ModoLista
    EditarTorneo
    GestionJugadores
    GenerarDrop
    VerInscriptosFiscal
End Enum

Partial Public Class lista_torneos
    Public Property Modo As ModoLista = ModoLista.GestionJugadores


    Private Sub lista_torneos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AplicarTituloPorModo()
        RenderTorneos()
    End Sub

    Private Sub lista_torneos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        RenderTorneos()
    End Sub


    Private Sub AplicarTituloPorModo()
        Select Case Modo
            Case ModoLista.EditarTorneo
                Me.Text = "Lista de torneos (modo: Editar)"
            Case ModoLista.GenerarDrop
                Me.Text = "Lista de torneos (modo: Drop)"
            Case ModoLista.VerInscriptosFiscal
                Me.Text = "Lista de torneos (modo: Fiscal)"
            Case Else
                Me.Text = "Lista de torneos (modo: Gestionar jugadores)"
        End Select
    End Sub


    Public Sub RenderTorneos()
        flpTorneos.SuspendLayout()
        flpTorneos.Controls.Clear()


        Dim lista As IEnumerable(Of Torneo) = Nothing
        Try
            lista = RepositorioTorneos.Listar()
        Catch
            lista = RepositorioTorneos.Torneos
        End Try
        If lista Is Nothing Then lista = Enumerable.Empty(Of Torneo)()


        If Not lista.Any() Then
            Dim lbl As New Label With {
                .AutoSize = False,
                .Dock = DockStyle.Top,
                .Height = 40,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Font = New Font("Bahnschrift", 11.0F, FontStyle.Italic),
                .Text = "Aún no se han creado torneos."
            }
            flpTorneos.Controls.Add(lbl)
            flpTorneos.ResumeLayout()
            Exit Sub
        End If


        Dim anchoDisponible As Integer = Math.Max(200, flpTorneos.ClientSize.Width - 40)

        For Each t In lista
            Dim btn As New Button() With {
                .Width = anchoDisponible,
                .Height = 80,
                .Margin = New Padding(10, 8, 10, 8),
                .Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular),
                .TextAlign = ContentAlignment.MiddleLeft,
                .Padding = New Padding(12, 8, 12, 8),
                .BackColor = Color.WhiteSmoke,
                .FlatStyle = FlatStyle.Flat
            }
            btn.FlatAppearance.BorderColor = Color.LightGray
            btn.FlatAppearance.BorderSize = 1

            btn.Text =
                t.Nombre & Environment.NewLine &
                t.FechaDesde.ToString("dd/MM/yyyy") & " " & t.HoraInicio.ToString("HH\:mm") & Environment.NewLine &
                "Cat: " & t.Categoria & "   Parejas: " & t.MaxParejas.ToString() & Environment.NewLine &
                "Inscripción: $" & t.PrecioInscripcion.ToString("N0")

            btn.Tag = t
            AddHandler btn.Click, AddressOf BotonTorneo_Click

            flpTorneos.Controls.Add(btn)
        Next

        flpTorneos.ResumeLayout()
    End Sub

    Private Sub BotonTorneo_Click(sender As Object, e As EventArgs)
        Dim t = TryCast(DirectCast(sender, Button).Tag, Torneo)
        If t Is Nothing Then
            MessageBox.Show("No se pudo obtener la información del torneo.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Select Case Me.Modo
            Case ModoLista.EditarTorneo

                FrmShell.ShowInShell(New editar_torneo(t))

            Case ModoLista.GestionJugadores

                FrmShell.ShowInShell(New agregar_jugadores(t))

            Case ModoLista.GenerarDrop

                Dim cant As Integer = RepositorioParejas.Listar(t).Count
                If cant < 3 Then
                    MessageBox.Show("Necesitás al menos 3 parejas inscriptas para generar el drop.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                FrmShell.ShowInShell(New drop_torneo(t))

            Case ModoLista.VerInscriptosFiscal

                FrmShell.ShowInShell(New lista_inscriptos(t))
        End Select
    End Sub

    Private Sub flpTorneos_Paint(sender As Object, e As PaintEventArgs) Handles flpTorneos.Paint
    End Sub

End Class