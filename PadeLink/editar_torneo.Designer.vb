<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class editar_torneo
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
        Me.PanelTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.nudPrecio = New System.Windows.Forms.NumericUpDown()
        Me.nudMaxParejas = New System.Windows.Forms.NumericUpDown()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblMaxParejas = New System.Windows.Forms.Label()
        Me.lblHasta = New System.Windows.Forms.Label()
        Me.lblDesde = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.PanelTitulo.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        CType(Me.nudPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxParejas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTitulo
        '
        Me.PanelTitulo.BackColor = System.Drawing.Color.FromArgb(54, 88, 138)
        Me.PanelTitulo.Controls.Add(Me.lblTitulo)
        Me.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTitulo.Location = New System.Drawing.Point(0, 0)
        Me.PanelTitulo.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelTitulo.Name = "PanelTitulo"
        Me.PanelTitulo.Size = New System.Drawing.Size(900, 120)
        Me.PanelTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Bahnschrift SemiBold", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(280, 25)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(400, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "🖋️ Modificar Torneo🖋️"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTitulo.Dock = DockStyle.Bottom
        '
        'pnlContenido
        '
        Me.pnlContenido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContenido.BackColor = System.Drawing.Color.White
        Me.pnlContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlContenido.Controls.Add(Me.cboCategoria)
        Me.pnlContenido.Controls.Add(Me.nudPrecio)
        Me.pnlContenido.Controls.Add(Me.nudMaxParejas)
        Me.pnlContenido.Controls.Add(Me.dtpHasta)
        Me.pnlContenido.Controls.Add(Me.dtpDesde)
        Me.pnlContenido.Controls.Add(Me.dtpHoraInicio)
        Me.pnlContenido.Controls.Add(Me.txtNombre)
        Me.pnlContenido.Controls.Add(Me.lblCategoria)
        Me.pnlContenido.Controls.Add(Me.lblPrecio)
        Me.pnlContenido.Controls.Add(Me.lblMaxParejas)
        Me.pnlContenido.Controls.Add(Me.lblHasta)
        Me.pnlContenido.Controls.Add(Me.lblDesde)
        Me.pnlContenido.Controls.Add(Me.lblHora)
        Me.pnlContenido.Controls.Add(Me.lblNombre)
        Me.pnlContenido.Location = New System.Drawing.Point(80, 150)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Padding = New System.Windows.Forms.Padding(30)
        Me.pnlContenido.Size = New System.Drawing.Size(640, 280)
        Me.pnlContenido.TabIndex = 1
        '
        'cboCategoria
        '
        Me.cboCategoria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboCategoria.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(280, 240)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(200, 28)
        Me.cboCategoria.TabIndex = 7
        '
        'nudPrecio
        '
        Me.nudPrecio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.nudPrecio.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.nudPrecio.Location = New System.Drawing.Point(280, 200)
        Me.nudPrecio.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudPrecio.Name = "nudPrecio"
        Me.nudPrecio.Size = New System.Drawing.Size(120, 28)
        Me.nudPrecio.TabIndex = 6
        '
        'nudMaxParejas
        '
        Me.nudMaxParejas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.nudMaxParejas.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.nudMaxParejas.Location = New System.Drawing.Point(280, 165)
        Me.nudMaxParejas.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
        Me.nudMaxParejas.Name = "nudMaxParejas"
        Me.nudMaxParejas.Size = New System.Drawing.Size(80, 28)
        Me.nudMaxParejas.TabIndex = 5
        '
        'dtpHasta
        '
        Me.dtpHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpHasta.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(280, 130)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(150, 28)
        Me.dtpHasta.TabIndex = 4
        '
        'dtpDesde
        '
        Me.dtpDesde.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpDesde.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(280, 95)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(150, 28)
        Me.dtpDesde.TabIndex = 3
        '
        'dtpHoraInicio
        '
        Me.dtpHoraInicio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpHoraInicio.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraInicio.Location = New System.Drawing.Point(280, 60)
        Me.dtpHoraInicio.Name = "dtpHoraInicio"
        Me.dtpHoraInicio.ShowUpDown = True
        Me.dtpHoraInicio.Size = New System.Drawing.Size(120, 28)
        Me.dtpHoraInicio.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtNombre.BackColor = System.Drawing.Color.Azure
        Me.txtNombre.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.txtNombre.Location = New System.Drawing.Point(280, 25)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(250, 28)
        Me.txtNombre.TabIndex = 1
        '
        'lblCategoria
        '
        Me.lblCategoria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Bahnschrift SemiLight", 10.2!)
        Me.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.lblCategoria.Location = New System.Drawing.Point(160, 242)
        Me.lblCategoria.Text = "Categoría:"
        '
        'lblPrecio
        '
        Me.lblPrecio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Bahnschrift SemiLight", 10.2!)
        Me.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.lblPrecio.Location = New System.Drawing.Point(160, 202)
        Me.lblPrecio.Text = "Inscripción:"
        '
        'lblMaxParejas
        '
        Me.lblMaxParejas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMaxParejas.AutoSize = True
        Me.lblMaxParejas.Font = New System.Drawing.Font("Bahnschrift SemiLight", 10.2!)
        Me.lblMaxParejas.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.lblMaxParejas.Location = New System.Drawing.Point(160, 167)
        Me.lblMaxParejas.Text = "Máx. Parejas:"
        '
        'lblHasta
        '
        Me.lblHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHasta.AutoSize = True
        Me.lblHasta.Font = New System.Drawing.Font("Bahnschrift SemiLight", 10.2!)
        Me.lblHasta.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.lblHasta.Location = New System.Drawing.Point(160, 132)
        Me.lblHasta.Text = "Hasta:"
        '
        'lblDesde
        '
        Me.lblDesde.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDesde.AutoSize = True
        Me.lblDesde.Font = New System.Drawing.Font("Bahnschrift SemiLight", 10.2!)
        Me.lblDesde.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.lblDesde.Location = New System.Drawing.Point(160, 97)
        Me.lblDesde.Text = "Desde:"
        '
        'lblHora
        '
        Me.lblHora.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHora.AutoSize = True
        Me.lblHora.Font = New System.Drawing.Font("Bahnschrift SemiLight", 10.2!)
        Me.lblHora.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.lblHora.Location = New System.Drawing.Point(160, 62)
        Me.lblHora.Text = "Hora de inicio:"
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Bahnschrift SemiLight", 10.2!)
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.lblNombre.Location = New System.Drawing.Point(160, 27)
        Me.lblNombre.Text = "Nombre:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(220, 235, 245)
        Me.btnGuardar.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnGuardar.Location = New System.Drawing.Point(260, 440)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(140, 40)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.BackColor = System.Drawing.Color.LightGray
        Me.btnCancelar.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.Location = New System.Drawing.Point(430, 440)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(140, 40)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'editar_torneo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(800, 520)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.pnlContenido)
        Me.Controls.Add(Me.PanelTitulo)
        Me.Name = "editar_torneo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Torneo"
        Me.PanelTitulo.ResumeLayout(False)
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlContenido.PerformLayout()
        CType(Me.nudPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxParejas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents cboCategoria As ComboBox
    Friend WithEvents nudPrecio As NumericUpDown
    Friend WithEvents nudMaxParejas As NumericUpDown
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents dtpHoraInicio As DateTimePicker
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblCategoria As Label
    Friend WithEvents lblPrecio As Label
    Friend WithEvents lblMaxParejas As Label
    Friend WithEvents lblHasta As Label
    Friend WithEvents lblDesde As Label
    Friend WithEvents lblHora As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
End Class
