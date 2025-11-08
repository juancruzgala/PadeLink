<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShell
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHost = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbDrop = New System.Windows.Forms.ToolStripButton()
        Me.tsbTorneos = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbLogout = New System.Windows.Forms.ToolStripButton()
        Me.tsbReportes = New System.Windows.Forms.ToolStripButton()
        Me.tsbBusqueda = New System.Windows.Forms.ToolStripButton()
        Me.tsbBackup = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHost
        '
        Me.pnlHost.AutoScroll = True
        Me.pnlHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHost.Location = New System.Drawing.Point(0, 0)
        Me.pnlHost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlHost.Name = "pnlHost"
        Me.pnlHost.Size = New System.Drawing.Size(1322, 756)
        Me.pnlHost.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDrop, Me.tsbTorneos, Me.tsbEditar, Me.tsbNuevo, Me.tsbLogout, Me.tsbReportes, Me.tsbBusqueda, Me.tsbBackup})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip2.Size = New System.Drawing.Size(1322, 48)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbDrop
        '
        Me.tsbDrop.Image = Global.PadeLink.My.Resources.Resources.drop
        Me.tsbDrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDrop.Name = "tsbDrop"
        Me.tsbDrop.Size = New System.Drawing.Size(81, 43)
        Me.tsbDrop.Text = "Drop"
        '
        'tsbTorneos
        '
        Me.tsbTorneos.Image = Global.PadeLink.My.Resources.Resources.listatorneos
        Me.tsbTorneos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTorneos.Name = "tsbTorneos"
        Me.tsbTorneos.Size = New System.Drawing.Size(102, 43)
        Me.tsbTorneos.Text = "Torneos"
        '
        'tsbEditar
        '
        Me.tsbEditar.Image = Global.PadeLink.My.Resources.Resources.Editartorneo
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(85, 44)
        Me.tsbEditar.Text = "Editar"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.PadeLink.My.Resources.Resources.nuevotorneo
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(92, 44)
        Me.tsbNuevo.Text = "Nuevo"
        '
        'tsbLogout
        '
        Me.tsbLogout.Image = Global.PadeLink.My.Resources.Resources._1828407
        Me.tsbLogout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLogout.Name = "tsbLogout"
        Me.tsbLogout.Size = New System.Drawing.Size(144, 43)
        Me.tsbLogout.Text = "Cerrar Sesion"
        '
        'tsbReportes
        '
        Me.tsbReportes.Image = Global.PadeLink.My.Resources.Resources.listatorneos
        Me.tsbReportes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReportes.Name = "tsbReportes"
        Me.tsbReportes.Size = New System.Drawing.Size(110, 43)
        Me.tsbReportes.Text = "Reportes"
        '
        'tsbBusqueda
        '
        Me.tsbBusqueda.Image = Global.PadeLink.My.Resources.Resources._2965314
        Me.tsbBusqueda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBusqueda.Name = "tsbBusqueda"
        Me.tsbBusqueda.Size = New System.Drawing.Size(118, 43)
        Me.tsbBusqueda.Text = "Busqueda"
        '
        'tsbBackup
        '
        Me.tsbBackup.Image = Global.PadeLink.My.Resources.Resources._10365581
        Me.tsbBackup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBackup.Name = "tsbBackup"
        Me.tsbBackup.Size = New System.Drawing.Size(160, 43)
        Me.tsbBackup.Text = "Mantenimiento"
        '
        'FrmShell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1322, 756)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.pnlHost)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FrmShell"
        Me.Text = "Gestor de Torneos PadeLink"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHost As Panel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsbDrop As ToolStripButton
    Friend WithEvents tsbTorneos As ToolStripButton
    Friend WithEvents tsbEditar As ToolStripButton
    Friend WithEvents tsbNuevo As ToolStripButton
    Friend WithEvents tsbLogout As ToolStripButton
    Friend WithEvents tsbReportes As ToolStripButton
    Friend WithEvents tsbBusqueda As ToolStripButton
    Friend WithEvents tsbBackup As ToolStripButton
End Class
