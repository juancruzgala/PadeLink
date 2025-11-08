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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift", 16.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(384, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lista Torneos"
        '
        'flpTorneos
        '
        Me.flpTorneos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.flpTorneos.AutoScroll = True
        Me.flpTorneos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpTorneos.Location = New System.Drawing.Point(173, 110)
        Me.flpTorneos.Margin = New System.Windows.Forms.Padding(20)
        Me.flpTorneos.Name = "flpTorneos"
        Me.flpTorneos.Padding = New System.Windows.Forms.Padding(10)
        Me.flpTorneos.Size = New System.Drawing.Size(632, 414)
        Me.flpTorneos.TabIndex = 14
        Me.flpTorneos.WrapContents = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TableLayoutPanel1.CausesValidation = False
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.flpTorneos, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(978, 544)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'lista_torneos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(978, 544)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "lista_torneos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Torneos"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents flpTorneos As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
