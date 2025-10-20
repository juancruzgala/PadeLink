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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHost = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbDrop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbTorneos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLogout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHost
        '
        Me.pnlHost.Location = New System.Drawing.Point(0, 41)
        Me.pnlHost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlHost.Name = "pnlHost"
        Me.pnlHost.Size = New System.Drawing.Size(1314, 560)
        Me.pnlHost.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDrop, Me.ToolStripSeparator4, Me.tsbTorneos, Me.ToolStripSeparator5, Me.tsbEditar, Me.ToolStripSeparator6, Me.tsbNuevo, Me.ToolStripSeparator1, Me.tsbLogout})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip2.Size = New System.Drawing.Size(1047, 38)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbDrop
        '
        Me.tsbDrop.Image = Global.PadeLink.My.Resources.Resources.drop
        Me.tsbDrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDrop.Name = "tsbDrop"
        Me.tsbDrop.Size = New System.Drawing.Size(71, 35)
        Me.tsbDrop.Text = "Drop"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 38)
        '
        'tsbTorneos
        '
        Me.tsbTorneos.Image = Global.PadeLink.My.Resources.Resources.listatorneos
        Me.tsbTorneos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTorneos.Name = "tsbTorneos"
        Me.tsbTorneos.Size = New System.Drawing.Size(89, 35)
        Me.tsbTorneos.Text = "Torneos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 38)
        '
        'tsbEditar
        '
        Me.tsbEditar.Image = Global.PadeLink.My.Resources.Resources.Editartorneo
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(76, 34)
        Me.tsbEditar.Text = "Editar"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 38)
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.PadeLink.My.Resources.Resources.nuevotorneo
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(80, 34)
        Me.tsbNuevo.Text = "Nuevo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'tsbLogout
        '
        Me.tsbLogout.Image = Global.PadeLink.My.Resources.Resources.cerrarsesion
        Me.tsbLogout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLogout.Name = "tsbLogout"
        Me.tsbLogout.Size = New System.Drawing.Size(124, 35)
        Me.tsbLogout.Text = "Cerrar Sesion"
        '
        'FrmShell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 595)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.pnlHost)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FrmShell"
        Me.Text = "FrmShell"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHost As Panel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsbDrop As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbTorneos As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsbEditar As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsbNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbLogout As ToolStripButton
End Class
