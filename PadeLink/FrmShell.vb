Imports System.Windows.Forms
Imports System.Drawing
Imports System.Diagnostics.Eventing.Reader

Public Class FrmShell

    Public Shared Property Current As FrmShell

    Public Shared Sub Logout()
        SessionInfo.CurrentUser = Nothing
        SessionInfo.CurrentRole = Nothing

        Dim login As New Frmlogin()
        login.Show()
        If Current IsNot Nothing AndAlso Not Current.IsDisposed Then
            If Current._child IsNot Nothing AndAlso Not Current._child.IsDisposed Then
                Current._child.Close()
                Current._child.Dispose()
                Current._child = Nothing
                Current.pnlHost.Controls.Clear()
            End If
            Current.Hide()
        End If
    End Sub

    Public Shared Sub ShowInShell(child As Form)
        Dim shell As FrmShell = Nothing


        If Current IsNot Nothing AndAlso Not Current.IsDisposed Then
            shell = Current
        Else

            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmShell Then
                    shell = DirectCast(f, FrmShell)
                    Exit For
                End If
            Next
        End If


        If shell Is Nothing Then
            shell = New FrmShell()
            Current = shell
            shell.Show()
        Else

            If Not shell.Visible Then shell.Show()
            shell.BringToFront()
        End If


        shell.ShowForm(child)
    End Sub


    Private _child As Form
    Public Sub ShowForm(child As Form)
        If _child IsNot Nothing AndAlso Not _child.IsDisposed Then
            _child.Close()
            _child.Dispose()
        End If

        _child = child
        _child.TopLevel = False
        _child.FormBorderStyle = FormBorderStyle.None
        _child.Dock = DockStyle.Fill

        pnlHost.SuspendLayout()
        pnlHost.Controls.Clear()
        pnlHost.Controls.Add(_child)
        _child.Show()
        pnlHost.ResumeLayout()
    End Sub

    Private Function HayTorneos() As Boolean
        Try
            Return RepositorioTorneos.Listar().Count > 0
        Catch
            Return (RepositorioTorneos.Torneos IsNot Nothing AndAlso RepositorioTorneos.Torneos.Count > 0)
        End Try
    End Function

    Private Sub FrmShell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Current = Me

        pnlHost.Dock = DockStyle.Fill

        ToolstripStyling.FixToolStrip(ToolStrip2)

        ToolStrip2.RenderMode = ToolStripRenderMode.Professional
        ToolStrip2.BackColor = Color.FromArgb(235, 239, 243)
        ToolStrip2.ForeColor = Color.Black
        ToolStrip2.Dock = DockStyle.Top
        pnlHost.Dock = DockStyle.Fill

        Try : tsbNuevo.Image = My.Resources.nuevotorneo : Catch : End Try
        Try : tsbEditar.Image = My.Resources.Editartorneo : Catch : End Try
        Try : tsbTorneos.Image = My.Resources.listatorneos : Catch : End Try
        Try : tsbDrop.Image = My.Resources.drop : Catch : End Try
        Try : tsbLogout.Image = My.Resources.cerrarsesion : Catch : End Try


        For Each b As ToolStripButton In New ToolStripButton() {tsbNuevo, tsbEditar, tsbTorneos, tsbDrop, tsbLogout}
            If b Is Nothing Then Continue For
            b.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            b.TextImageRelation = TextImageRelation.ImageBeforeText
            b.ImageScaling = ToolStripItemImageScaling.SizeToFit
            b.ImageTransparentColor = Color.Transparent
        Next


        Dim cont = ToolStrip2.Parent
        If cont IsNot Nothing Then cont.Controls.SetChildIndex(ToolStrip2, 0)
        ToolStrip2.BringToFront()

        AplicarPermisosPorRol()
    End Sub

    Private Sub FrmShell_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Current Is Me Then Current = Nothing
        Application.Exit()
    End Sub

    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        ShowForm(New crear_torneo())
    End Sub

    Private Sub tsbEditar_Click(sender As Object, e As EventArgs) Handles tsbEditar.Click
        If Not HayTorneos() Then
            MessageBox.Show("Aún no se han creado torneos.", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ShowForm(New lista_torneos() With {.Modo = ModoLista.EditarTorneo})
    End Sub

    Private Sub tsbTorneos_Click(sender As Object, e As EventArgs) Handles tsbTorneos.Click
        If Not HayTorneos() Then
            MessageBox.Show("Aún no se han creado torneos.", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Dim modo As ModoLista =
            If(String.Equals(SessionInfo.CurrentRole, "Fiscal", StringComparison.OrdinalIgnoreCase),
               ModoLista.VerInscriptosFiscal,
               ModoLista.GestionJugadores)

        ShowForm(New lista_torneos() With {.Modo = modo})
    End Sub

    Private Sub tsbDrop_Click(sender As Object, e As EventArgs) Handles tsbDrop.Click
        If Not HayTorneos() Then
            MessageBox.Show("Aún no se han creado torneos.", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ShowForm(New lista_torneos() With {.Modo = ModoLista.GenerarDrop})
    End Sub

    Private Sub tsbLogout_Click(sender As Object, e As EventArgs) Handles tsbLogout.Click
        Logout()
    End Sub


    Private Sub AplicarPermisosPorRol()
        Try
            Dim role As String = SessionInfo.CurrentRole
            If String.Equals(role, "Fiscal", StringComparison.OrdinalIgnoreCase) Then
                tsbNuevo.Visible = False
                tsbEditar.Visible = False
                tsbDrop.Visible = True
                tsbTorneos.Visible = True
                tsbLogout.Visible = True
            ElseIf String.Equals(role, "Canchero", StringComparison.OrdinalIgnoreCase) Then

                tsbNuevo.Visible = True
                tsbEditar.Visible = True
                tsbDrop.Visible = True
                tsbTorneos.Visible = True
                tsbLogout.Visible = True
            ElseIf String.Equals(role, "Administrador", StringComparison.OrdinalIgnoreCase) Then
                tsbNuevo.Visible = False
                tsbEditar.Visible = False
                tsbDrop.Visible = False
                tsbTorneos.Visible = True
                tsbLogout.Visible = True
            End If
        Catch

            tsbNuevo.Visible = True
            tsbEditar.Visible = True
            tsbDrop.Visible = True
            tsbTorneos.Visible = True
            tsbLogout.Visible = True
        End Try
    End Sub
End Class