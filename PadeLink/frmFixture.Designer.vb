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
        Me.btnRegistrarResultado = New System.Windows.Forms.Button()
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
        '=== PANEL PRINCIPAL ===
        '
        Me.pnlContenido.BackColor = System.Drawing.Color.White
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContenido.Controls.Add(Me.tabZonas)
        Me.pnlContenido.Controls.Add(Me.btnRegistrarResultado)
        Me.pnlContenido.Controls.Add(Me.btnImprimir)
        Me.pnlContenido.Controls.Add(Me.btnExportarPDF)
        Me.pnlContenido.Controls.Add(Me.btnGenerar)
        Me.pnlContenido.Controls.Add(Me.cboTorneo)
        Me.pnlContenido.Controls.Add(Me.Label3)
        Me.pnlContenido.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(1200, 600)
        Me.pnlContenido.TabIndex = 0
        '
        '=== TABCONTROL ===
        '
        Me.tabZonas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
        Or System.Windows.Forms.AnchorStyles.Left) _
        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabZonas.Controls.Add(Me.TabPage1)
        Me.tabZonas.Controls.Add(Me.TabPage2)
        Me.tabZonas.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.tabZonas.ItemSize = New System.Drawing.Size(80, 25)
        ' ⬇️ Bajamos la posición para crear espacio visual arriba
        Me.tabZonas.Location = New System.Drawing.Point(40, 130)
        Me.tabZonas.Name = "tabZonas"
        Me.tabZonas.SelectedIndex = 0
        Me.tabZonas.Size = New System.Drawing.Size(1120, 350)
        Me.tabZonas.TabIndex = 0

        '=== TAB PAGE 1 ===
        '
        Me.TabPage1.Controls.Add(Me.layoutZonas)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Size = New System.Drawing.Size(1112, 347)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Zona A"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '=== LAYOUT ZONAS ===
        '
        Me.layoutZonas.ColumnCount = 1
        Me.layoutZonas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutZonas.Controls.Add(Me.dgvTabla, 0, 0)
        Me.layoutZonas.Controls.Add(Me.dgvPartidos, 0, 1)
        Me.layoutZonas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutZonas.RowCount = 2
        Me.layoutZonas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.layoutZonas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.layoutZonas.Padding = New System.Windows.Forms.Padding(15)
        Me.layoutZonas.BackColor = System.Drawing.Color.White
        Me.layoutZonas.Name = "layoutZonas"
        Me.layoutZonas.Size = New System.Drawing.Size(1102, 337)
        Me.layoutZonas.TabIndex = 0
        '
        '=== DGV TABLA ===
        '
        Me.dgvTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTabla.BackgroundColor = System.Drawing.Color.White
        Me.dgvTabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTabla.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.dgvTabla.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.dgvTabla.Name = "dgvTabla"
        Me.dgvTabla.RowHeadersWidth = 51
        Me.dgvTabla.Size = New System.Drawing.Size(1072, 102)
        Me.dgvTabla.TabIndex = 0
        '
        '=== DGV PARTIDOS ===
        '
        Me.dgvPartidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPartidos.BackgroundColor = System.Drawing.Color.White
        Me.dgvPartidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgvPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPartidos.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.dgvPartidos.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.dgvPartidos.Name = "dgvPartidos"
        Me.dgvPartidos.RowHeadersWidth = 51
        Me.dgvPartidos.Size = New System.Drawing.Size(1072, 210)
        Me.dgvPartidos.TabIndex = 1
        '
        '=== TAB PAGE 2 ===
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1112, 347)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Zona B"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        '=== BOTÓN REGISTRAR ===
        '
        Me.btnRegistrarResultado.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnRegistrarResultado.BackColor = System.Drawing.Color.FromArgb(72, 201, 176)
        Me.btnRegistrarResultado.FlatAppearance.BorderSize = 0
        Me.btnRegistrarResultado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegistrarResultado.Font = New System.Drawing.Font("Bahnschrift SemiBold", 9.0!)
        Me.btnRegistrarResultado.ForeColor = System.Drawing.Color.White
        Me.btnRegistrarResultado.Location = New System.Drawing.Point(500, 530)
        Me.btnRegistrarResultado.Name = "btnRegistrarResultado"
        Me.btnRegistrarResultado.Size = New System.Drawing.Size(200, 40)
        Me.btnRegistrarResultado.TabIndex = 1
        Me.btnRegistrarResultado.Text = "Registrar Resultado"
        Me.btnRegistrarResultado.UseVisualStyleBackColor = False
        '
        '=== BOTONES SUPERIORES ===
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(92, 184, 230)
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Bahnschrift SemiBold", 9.0!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Location = New System.Drawing.Point(750, 70)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(130, 35)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False

        Me.btnExportarPDF.BackColor = System.Drawing.Color.FromArgb(92, 184, 230)
        Me.btnExportarPDF.FlatAppearance.BorderSize = 0
        Me.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportarPDF.Font = New System.Drawing.Font("Bahnschrift SemiBold", 9.0!)
        Me.btnExportarPDF.ForeColor = System.Drawing.Color.White
        Me.btnExportarPDF.Location = New System.Drawing.Point(600, 70)
        Me.btnExportarPDF.Name = "btnExportarPDF"
        Me.btnExportarPDF.Size = New System.Drawing.Size(130, 35)
        Me.btnExportarPDF.TabIndex = 3
        Me.btnExportarPDF.Text = "Generar PDF"
        Me.btnExportarPDF.UseVisualStyleBackColor = False

        Me.btnGenerar.BackColor = System.Drawing.Color.FromArgb(72, 201, 176)
        Me.btnGenerar.FlatAppearance.BorderSize = 0
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Bahnschrift SemiBold", 9.0!)
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.Location = New System.Drawing.Point(450, 70)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(130, 35)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Generar Drop"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        '=== COMBO Y LABEL ===
        '
        Me.cboTorneo.Font = New System.Drawing.Font("Bahnschrift", 9.5!)
        Me.cboTorneo.Location = New System.Drawing.Point(160, 70)
        Me.cboTorneo.Name = "cboTorneo"
        Me.cboTorneo.Size = New System.Drawing.Size(260, 26)
        Me.cboTorneo.TabIndex = 5

        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift SemiBold", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.Label3.Location = New System.Drawing.Point(70, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Torneo:"
        '
        '=== FORM ===
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 600)
        Me.Controls.Add(Me.pnlContenido)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
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
    Friend WithEvents btnRegistrarResultado As Button
    Friend WithEvents layoutZonas As TableLayoutPanel
End Class
