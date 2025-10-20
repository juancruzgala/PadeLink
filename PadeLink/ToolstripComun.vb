' ToolstripComun.vb
Imports System.Windows.Forms

Public Module ToolstripComun

    ' Conecta los 3 botones a handlers comunes
    Public Sub WireToolstripComun(tsbNuevo As ToolStripButton,
                                  tsbEditar As ToolStripButton,
                                  tsbTorneos As ToolStripButton)
        If tsbNuevo IsNot Nothing Then
            AddHandler tsbNuevo.Click, AddressOf HandleNuevo
        End If
        If tsbEditar IsNot Nothing Then
            AddHandler tsbEditar.Click, AddressOf HandleEditar
        End If
        If tsbTorneos IsNot Nothing Then
            AddHandler tsbTorneos.Click, AddressOf HandleTorneos
        End If
    End Sub

    ' ====== Handlers reutilizables ======

    Public Sub HandleNuevo(sender As Object, e As EventArgs)
        ' Por defecto: abrir la pantalla de crear_torneo
        For Each f As Form In Application.OpenForms
            If TypeOf f Is crear_torneo Then
                f.BringToFront() : f.Focus() : Exit Sub
            End If
        Next
        Dim c As New crear_torneo()
        c.Show()
    End Sub

    Public Sub HandleEditar(sender As Object, e As EventArgs)
        If Not HayTorneos() Then
            MessageBox.Show("Aún no se han creado torneos.", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        AbrirLista(ModoLista.EditarTorneo)
    End Sub

    Public Sub HandleTorneos(sender As Object, e As EventArgs)
        AbrirLista(ModoLista.GestionJugadores)
    End Sub

    ' ====== Helpers ======

    Private Sub AbrirLista(modo As ModoLista)
        For Each f As Form In Application.OpenForms
            If TypeOf f Is lista_torneos Then
                Dim lt = DirectCast(f, lista_torneos)
                lt.Modo = modo
                lt.BringToFront()
                lt.Focus()
                Exit Sub
            End If
        Next
        Dim l As New lista_torneos() With {.Modo = modo}
        l.Show()
    End Sub

    Private Function HayTorneos() As Boolean
        Try
            Return RepositorioTorneos.ExisteAlguno()
        Catch
            Return False
        End Try
    End Function


End Module
