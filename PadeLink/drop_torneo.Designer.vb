<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class drop_torneo
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.tcZonas = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.pnlContenedor.SuspendLayout()
        Me.tcZonas.SuspendLayout()
        Me.SuspendLayout()
        '
        '=== FORM ===
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(240, 243, 247)
        Me.ClientSize = New System.Drawing.Size(1080, 720)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Name = "drop_torneo"
        Me.Text = "drop_torneo"
        '
        '=== TÍTULO ===
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitulo.Font = New System.Drawing.Font("Bahnschrift SemiBold", 20.0!, System.Drawing.FontStyle.Regular)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(45, 45, 45)
        Me.lblTitulo.Text = "🏆 Organización de Partidos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTitulo.Height = 90
        Me.lblTitulo.Padding = New System.Windows.Forms.Padding(0, 25, 0, 15)
        '
        '=== PANEL CONTENEDOR PRINCIPAL ===
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.White
        Me.pnlContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlContenedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContenedor.Location = New System.Drawing.Point(40, 110)
        Me.pnlContenedor.Margin = New System.Windows.Forms.Padding(20)
        Me.pnlContenedor.Padding = New System.Windows.Forms.Padding(16)
        Me.pnlContenedor.Size = New System.Drawing.Size(1000, 550)
        '
        '=== TABCONTROL ===
        '
        Me.tcZonas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcZonas.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.tcZonas.ItemSize = New System.Drawing.Size(100, 30)
        Me.tcZonas.Multiline = True
        Me.tcZonas.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tcZonas.TabPages.AddRange(New System.Windows.Forms.TabPage() {Me.TabPage2, Me.TabPage1})
        '
        '=== TABPAGES ===
        '
        Me.TabPage2.Text = "Zona A"
        Me.TabPage2.UseVisualStyleBackColor = True

        Me.TabPage1.Text = "Zona B"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '=== BOTÓN VOLVER ===
        '
        Me.btnVolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVolver.BackColor = System.Drawing.Color.FromArgb(72, 201, 176)
        Me.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolver.FlatAppearance.BorderSize = 0
        Me.btnVolver.Font = New System.Drawing.Font("Bahnschrift SemiBold", 10.0!)
        Me.btnVolver.ForeColor = System.Drawing.Color.White
        Me.btnVolver.Size = New System.Drawing.Size(120, 40)
        Me.btnVolver.Location = New System.Drawing.Point(920, 670)
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        '=== ENSAMBLE FINAL ===
        '
        Me.pnlContenedor.Controls.Add(Me.tcZonas)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Controls.Add(Me.btnVolver)

        Me.pnlContenedor.ResumeLayout(False)
        Me.tcZonas.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents tcZonas As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnVolver As Button
End Class
