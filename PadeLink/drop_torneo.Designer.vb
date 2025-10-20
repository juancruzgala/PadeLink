<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class drop_torneo
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.tcZonas = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.tcZonas.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Bahnschrift", 16.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(208, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(281, 33)
        Me.lblTitulo.TabIndex = 19
        Me.lblTitulo.Text = "Organizacion Partidos"
        '
        'tcZonas
        '
        Me.tcZonas.Controls.Add(Me.TabPage2)
        Me.tcZonas.Controls.Add(Me.TabPage1)
        Me.tcZonas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcZonas.ItemSize = New System.Drawing.Size(90, 28)
        Me.tcZonas.Location = New System.Drawing.Point(0, 0)
        Me.tcZonas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tcZonas.MaximumSize = New System.Drawing.Size(800, 480)
        Me.tcZonas.MinimumSize = New System.Drawing.Size(800, 480)
        Me.tcZonas.Multiline = True
        Me.tcZonas.Name = "tcZonas"
        Me.tcZonas.Padding = New System.Drawing.Point(12, 6)
        Me.tcZonas.SelectedIndex = 0
        Me.tcZonas.Size = New System.Drawing.Size(800, 480)
        Me.tcZonas.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tcZonas.TabIndex = 20
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Location = New System.Drawing.Point(4, 32)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Size = New System.Drawing.Size(792, 444)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 32)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Size = New System.Drawing.Size(792, 444)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnVolver.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.Location = New System.Drawing.Point(703, 499)
        Me.btnVolver.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(116, 27)
        Me.btnVolver.TabIndex = 21
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'drop_torneo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 595)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.tcZonas)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MinimumSize = New System.Drawing.Size(802, 489)
        Me.Name = "drop_torneo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "drop_torneo"
        Me.tcZonas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents tcZonas As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnVolver As Button
End Class
