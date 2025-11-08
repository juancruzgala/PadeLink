Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmShell

    Public Shared Property Current As FrmShell
    Private _child As Form

    ' ==============================
    ' MÉTODO LOGOUT (CORREGIDO Y SEGURO)
    ' ==============================
    Public Shared Sub Logout()
        Try
            ' --- Limpiar sesión ---
            SessionInfo.CurrentUser = Nothing
            SessionInfo.CurrentRole = Nothing
            SessionInfo.id_usuario = Nothing

            ' --- Cerrar formulario principal si existe ---
            Dim shell As FrmShell = Nothing

            ' Buscar instancia activa (por seguridad)
            If Current IsNot Nothing AndAlso Not Current.IsDisposed Then
                shell = Current
            Else
                shell = Application.OpenForms().OfType(Of FrmShell)().FirstOrDefault()
            End If

            ' Cerrar shell y su contenido
            If shell IsNot Nothing Then
                If shell._child IsNot Nothing AndAlso Not shell._child.IsDisposed Then
                    Try
                        shell._child.Close()
                        shell._child.Dispose()
                    Catch
                    End Try
                    shell._child = Nothing
                End If

                If shell.pnlHost IsNot Nothing AndAlso Not shell.pnlHost.IsDisposed Then
                    Try
                        shell.pnlHost.Controls.Clear()
                    Catch
                    End Try
                End If

                Try
                    shell.Close()
                    shell.Dispose()
                Catch
                End Try
            End If

            ' --- Limpiar referencia estática ---
            Current = Nothing

            ' --- Volver al login ---
            Dim login As New Frmlogin()
            login.Show()

        Catch ex As Exception
            MessageBox.Show("Error al cerrar la sesión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' ==============================
    ' MOSTRAR FORMULARIO EN SHELL
    ' ==============================
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


    ' ==============================
    ' CARGA DE FORMULARIO HIJO
    ' ==============================
    Public Sub ShowForm(child As Form)
        Try
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

        Catch ex As Exception
            MessageBox.Show("Error al cargar el formulario: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function HayTorneos() As Boolean
        Try
            Return RepositorioTorneos.ExisteAlguno()
        Catch
            Return False
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

        Try : tsbNuevo.Image = My.Resources.nuevotorneo : Catch : End Try
        Try : tsbEditar.Image = My.Resources.Editartorneo : Catch : End Try
        Try : tsbTorneos.Image = My.Resources.listatorneos : Catch : End Try
        Try : tsbDrop.Image = My.Resources.drop : Catch : End Try
        Try : tsbLogout.Image = My.Resources._1828407 : Catch : End Try
        Try : tsbBusqueda.Image = My.Resources._2965314 : Catch : End Try
        Try : tsbBackup.Image = My.Resources._10365581 : Catch : End Try
        Try : tsbReportes.Image = My.Resources.listatorneos : Catch : End Try

        For Each b As ToolStripButton In New ToolStripButton() {tsbNuevo, tsbEditar, tsbBackup, tsbTorneos, tsbDrop, tsbLogout, tsbBusqueda, tsbReportes}
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
        ShowForm(New frmBienvenida())
    End Sub


    Private Sub FrmShell_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Current Is Me Then Current = Nothing
        If Application.OpenForms().Count = 0 Then
            Application.ExitThread()
            Application.Exit()
        End If

    End Sub


    ' ==============================
    ' BOTONES TOOLSTRIP
    ' ==============================
    Private Sub tsbBusqueda_Click(sender As Object, e As EventArgs) Handles tsbBusqueda.Click
        ShowForm(New busqueda_fiscal())
    End Sub

    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        ShowForm(New crear_torneo())
    End Sub

    Private Sub tsbEditar_Click(sender As Object, e As EventArgs) Handles tsbEditar.Click
        If Not HayTorneos() Then
            MessageBox.Show("Aún no se han creado torneos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ShowForm(New lista_torneos() With {.Modo = ModoLista.EditarTorneo})
    End Sub

    Private Sub tsbTorneos_Click(sender As Object, e As EventArgs) Handles tsbTorneos.Click
        If Not HayTorneos() Then
            MessageBox.Show("Aún no se han creado torneos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("Aún no se han creado torneos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ShowForm(New lista_torneos() With {.Modo = ModoLista.GenerarDrop})
    End Sub

    Private Sub tsbReportes_Click(sender As Object, e As EventArgs) Handles tsbReportes.Click
        ShowForm(New FrmReportes())
    End Sub

    Private Sub tsbBackup_Click(sender As Object, e As EventArgs) Handles tsbBackup.Click
        ShowForm(New FrmBackupRestore())
    End Sub

    Private Sub tsbLogout_Click(sender As Object, e As EventArgs) Handles tsbLogout.Click
        Logout()
    End Sub

    Private Sub AplicarPermisosPorRol()
        ShowForm(New frmBienvenida())

        Try
            Dim role As String = SessionInfo.CurrentRole

            If String.Equals(role, "Fiscal", StringComparison.OrdinalIgnoreCase) Then
                tsbNuevo.Visible = False
                tsbEditar.Visible = False
                tsbDrop.Visible = True
                tsbTorneos.Visible = True
                tsbLogout.Visible = True
                tsbReportes.Visible = True
                tsbBusqueda.Visible = True
                tsbBackup.Visible = False

            ElseIf String.Equals(role, "Canchero", StringComparison.OrdinalIgnoreCase) Then
                tsbNuevo.Visible = True
                tsbEditar.Visible = True
                tsbDrop.Visible = True
                tsbTorneos.Visible = True
                tsbLogout.Visible = True
                tsbReportes.Visible = True
                tsbBusqueda.Visible = False
                tsbBackup.Visible = False

            ElseIf String.Equals(role, "Administrador", StringComparison.OrdinalIgnoreCase) Then
                tsbNuevo.Visible = False
                tsbEditar.Visible = False
                tsbDrop.Visible = False
                tsbTorneos.Visible = True
                tsbLogout.Visible = True
                tsbReportes.Visible = True
                tsbBusqueda.Visible = False
                tsbBackup.Visible = True
                
            End If

        Catch
            tsbNuevo.Visible = True
            tsbEditar.Visible = True
            tsbDrop.Visible = True
            tsbTorneos.Visible = True
            tsbLogout.Visible = True
            tsbReportes.Visible = True
            tsbBusqueda.Visible = True
            tsbBackup.Visible = True
        End Try
    End Sub

End Class
