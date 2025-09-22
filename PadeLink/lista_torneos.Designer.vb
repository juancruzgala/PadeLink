<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class lista_torneos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.flpTorneos = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift", 16.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(379, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lista Torneos"
        '
        'flpTorneos
        '
        Me.flpTorneos.AutoScroll = True
        Me.flpTorneos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpTorneos.Location = New System.Drawing.Point(0, 131)
        Me.flpTorneos.Margin = New System.Windows.Forms.Padding(20)
        Me.flpTorneos.Name = "flpTorneos"
        Me.flpTorneos.Padding = New System.Windows.Forms.Padding(10)
        Me.flpTorneos.Size = New System.Drawing.Size(974, 349)
        Me.flpTorneos.TabIndex = 14
        Me.flpTorneos.WrapContents = False
        '
        'lista_torneos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(978, 544)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.flpTorneos)
        Me.Name = "lista_torneos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Torneo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents flpTorneos As FlowLayoutPanel
End Class
