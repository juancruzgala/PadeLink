<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFixture
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
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.tabZonas = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.layoutZonas = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvTabla = New System.Windows.Forms.DataGridView()
        Me.dgvPartidos = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnExportarPDF = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.cboTorneo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlContenido.SuspendLayout()
        Me.tabZonas.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.layoutZonas.SuspendLayout()
        CType(Me.dgvTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPartidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenido
        '
        Me.pnlContenido.BackColor = System.Drawing.Color.White
        Me.pnlContenido.Controls.Add(Me.tabZonas)
        Me.pnlContenido.Controls.Add(Me.btnImprimir)
        Me.pnlContenido.Controls.Add(Me.btnExportarPDF)
        Me.pnlContenido.Controls.Add(Me.btnGenerar)
        Me.pnlContenido.Controls.Add(Me.cboTorneo)
        Me.pnlContenido.Controls.Add(Me.Label3)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenido.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Padding = New System.Windows.Forms.Padding(22, 25, 22, 25)
        Me.pnlContenido.Size = New System.Drawing.Size(1350, 750)
        Me.pnlContenido.TabIndex = 0
        '
        'tabZonas
        '
        Me.tabZonas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabZonas.Controls.Add(Me.TabPage1)
        Me.tabZonas.Controls.Add(Me.TabPage2)
        Me.tabZonas.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.tabZonas.ItemSize = New System.Drawing.Size(80, 25)
        Me.tabZonas.Location = New System.Drawing.Point(45, 162)
        Me.tabZonas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabZonas.Name = "tabZonas"
        Me.tabZonas.SelectedIndex = 0
        Me.tabZonas.Size = New System.Drawing.Size(1260, 438)
        Me.tabZonas.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.layoutZonas)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.TabPage1.Size = New System.Drawing.Size(1252, 405)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Zona A"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'layoutZonas
        '
        Me.layoutZonas.BackColor = System.Drawing.Color.White
        Me.layoutZonas.ColumnCount = 1
        Me.layoutZonas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutZonas.Controls.Add(Me.dgvTabla, 0, 0)
        Me.layoutZonas.Controls.Add(Me.dgvPartidos, 0, 1)
        Me.layoutZonas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutZonas.Location = New System.Drawing.Point(6, 6)
        Me.layoutZonas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.layoutZonas.Name = "layoutZonas"
        Me.layoutZonas.Padding = New System.Windows.Forms.Padding(17, 19, 17, 19)
        Me.layoutZonas.RowCount = 2
        Me.layoutZonas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.layoutZonas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.layoutZonas.Size = New System.Drawing.Size(1240, 393)
        Me.layoutZonas.TabIndex = 0
        '
        'dgvTabla
        '
        Me.dgvTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTabla.BackgroundColor = System.Drawing.Color.White
        Me.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTabla.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.dgvTabla.Location = New System.Drawing.Point(17, 19)
        Me.dgvTabla.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.dgvTabla.Name = "dgvTabla"
        Me.dgvTabla.RowHeadersWidth = 51
        Me.dgvTabla.Size = New System.Drawing.Size(1206, 112)
        Me.dgvTabla.TabIndex = 0
        '
        'dgvPartidos
        '
        Me.dgvPartidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPartidos.BackgroundColor = System.Drawing.Color.White
        Me.dgvPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPartidos.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.dgvPartidos.Location = New System.Drawing.Point(17, 155)
        Me.dgvPartidos.Margin = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.dgvPartidos.Name = "dgvPartidos"
        Me.dgvPartidos.RowHeadersWidth = 51
        Me.dgvPartidos.Size = New System.Drawing.Size(1206, 219)
        Me.dgvPartidos.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1252, 405)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Zona B"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Bahnschrift SemiBold", 9.0!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Location = New System.Drawing.Point(844, 88)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(146, 44)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnExportarPDF
        '
        Me.btnExportarPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnExportarPDF.FlatAppearance.BorderSize = 0
        Me.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportarPDF.Font = New System.Drawing.Font("Bahnschrift SemiBold", 9.0!)
        Me.btnExportarPDF.ForeColor = System.Drawing.Color.White
        Me.btnExportarPDF.Location = New System.Drawing.Point(675, 88)
        Me.btnExportarPDF.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExportarPDF.Name = "btnExportarPDF"
        Me.btnExportarPDF.Size = New System.Drawing.Size(146, 44)
        Me.btnExportarPDF.TabIndex = 3
        Me.btnExportarPDF.Text = "Generar PDF"
        Me.btnExportarPDF.UseVisualStyleBackColor = False
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.btnGenerar.FlatAppearance.BorderSize = 0
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Bahnschrift SemiBold", 9.0!)
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.Location = New System.Drawing.Point(506, 88)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(146, 44)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Generar Drop"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'cboTorneo
        '
        Me.cboTorneo.Font = New System.Drawing.Font("Bahnschrift", 9.5!)
        Me.cboTorneo.Location = New System.Drawing.Point(180, 88)
        Me.cboTorneo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboTorneo.Name = "cboTorneo"
        Me.cboTorneo.Size = New System.Drawing.Size(292, 31)
        Me.cboTorneo.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift SemiBold", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(79, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Torneo:"
        '
        'FrmFixture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 750)
        Me.Controls.Add(Me.pnlContenido)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmFixture"
        Me.Text = "Fixture de Torneo"
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlContenido.PerformLayout()
        Me.tabZonas.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.layoutZonas.ResumeLayout(False)
        CType(Me.dgvTabla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPartidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContenido As Panel
    Friend WithEvents cboTorneo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGenerar As Button
    Friend WithEvents btnExportarPDF As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents tabZonas As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvPartidos As DataGridView
    Friend WithEvents dgvTabla As DataGridView
    Friend WithEvents layoutZonas As TableLayoutPanel
End Class
