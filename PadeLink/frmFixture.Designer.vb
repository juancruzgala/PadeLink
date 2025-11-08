<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFixture
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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cboTorneo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnExportarPDF = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.tabZonas = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvPartidos = New System.Windows.Forms.DataGridView()
        Me.dgvTabla = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnRegistrarResultado = New System.Windows.Forms.Button()
        Me.tabZonas.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvPartidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboTorneo
        '
        Me.cboTorneo.FormattingEnabled = True
        Me.cboTorneo.Location = New System.Drawing.Point(383, 80)
        Me.cboTorneo.Name = "cboTorneo"
        Me.cboTorneo.Size = New System.Drawing.Size(240, 24)
        Me.cboTorneo.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(294, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 21)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Torneo"
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.Azure
        Me.btnGenerar.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(642, 84)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(156, 30)
        Me.btnGenerar.TabIndex = 45
        Me.btnGenerar.Text = "Generar Drop"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'btnExportarPDF
        '
        Me.btnExportarPDF.BackColor = System.Drawing.Color.Azure
        Me.btnExportarPDF.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarPDF.Location = New System.Drawing.Point(373, 143)
        Me.btnExportarPDF.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExportarPDF.Name = "btnExportarPDF"
        Me.btnExportarPDF.Size = New System.Drawing.Size(156, 30)
        Me.btnExportarPDF.TabIndex = 46
        Me.btnExportarPDF.Text = "Generar PDF"
        Me.btnExportarPDF.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.Azure
        Me.btnImprimir.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(590, 143)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(156, 30)
        Me.btnImprimir.TabIndex = 47
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'tabZonas
        '
        Me.tabZonas.Controls.Add(Me.TabPage1)
        Me.tabZonas.Controls.Add(Me.TabPage2)
        Me.tabZonas.Location = New System.Drawing.Point(52, 178)
        Me.tabZonas.Name = "tabZonas"
        Me.tabZonas.SelectedIndex = 0
        Me.tabZonas.Size = New System.Drawing.Size(1027, 458)
        Me.tabZonas.TabIndex = 48
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvPartidos)
        Me.TabPage1.Controls.Add(Me.dgvTabla)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1019, 429)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvPartidos
        '
        Me.dgvPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidos.Location = New System.Drawing.Point(463, 26)
        Me.dgvPartidos.Name = "dgvPartidos"
        Me.dgvPartidos.RowHeadersWidth = 51
        Me.dgvPartidos.RowTemplate.Height = 24
        Me.dgvPartidos.Size = New System.Drawing.Size(373, 358)
        Me.dgvPartidos.TabIndex = 1
        '
        'dgvTabla
        '
        Me.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTabla.Location = New System.Drawing.Point(17, 26)
        Me.dgvTabla.Name = "dgvTabla"
        Me.dgvTabla.RowHeadersWidth = 51
        Me.dgvTabla.RowTemplate.Height = 24
        Me.dgvTabla.Size = New System.Drawing.Size(440, 358)
        Me.dgvTabla.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(822, 409)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnRegistrarResultado
        '
        Me.btnRegistrarResultado.BackColor = System.Drawing.Color.Azure
        Me.btnRegistrarResultado.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistrarResultado.Location = New System.Drawing.Point(677, 696)
        Me.btnRegistrarResultado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRegistrarResultado.Name = "btnRegistrarResultado"
        Me.btnRegistrarResultado.Size = New System.Drawing.Size(152, 29)
        Me.btnRegistrarResultado.TabIndex = 49
        Me.btnRegistrarResultado.Text = "Registrar Resultado"
        Me.btnRegistrarResultado.UseVisualStyleBackColor = False
        '
        'FrmFixture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 776)
        Me.Controls.Add(Me.btnRegistrarResultado)
        Me.Controls.Add(Me.tabZonas)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnExportarPDF)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTorneo)
        Me.Name = "FrmFixture"
        Me.Text = "frmFixture"
        Me.tabZonas.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvPartidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
End Class
