<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class lista_inscriptos
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.dgvInscriptos = New System.Windows.Forms.DataGridView()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvInscriptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(900, 120)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitulo.Font = New System.Drawing.Font("Bahnschrift SemiBold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(0, 55, 0, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(900, 120)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Lista de Inscriptos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'dgvInscriptos
        '
        Me.dgvInscriptos.AllowUserToAddRows = False
        Me.dgvInscriptos.AllowUserToDeleteRows = False
        Me.dgvInscriptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInscriptos.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvInscriptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInscriptos.Location = New System.Drawing.Point(20, 140)
        Me.dgvInscriptos.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvInscriptos.Name = "dgvInscriptos"
        Me.dgvInscriptos.RowHeadersVisible = False
        Me.dgvInscriptos.RowHeadersWidth = 51
        Me.dgvInscriptos.Size = New System.Drawing.Size(860, 240)
        Me.dgvInscriptos.TabIndex = 1
        '
        'btnVolver
        '
        Me.btnVolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVolver.BackColor = System.Drawing.Color.FromArgb(230, 235, 245)
        Me.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolver.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnVolver.ForeColor = System.Drawing.Color.FromArgb(45, 45, 60)
        Me.btnVolver.Location = New System.Drawing.Point(740, 395)
        Me.btnVolver.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(140, 40)
        Me.btnVolver.TabIndex = 2
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'lista_inscriptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(900, 460)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.dgvInscriptos)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "lista_inscriptos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Inscriptos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvInscriptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents dgvInscriptos As DataGridView
    Friend WithEvents btnVolver As Button
End Class
