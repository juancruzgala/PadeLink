<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegistrarResultadoPartido
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
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTorneo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboZona = New System.Windows.Forms.ComboBox()
        Me.dgvPartidos = New System.Windows.Forms.DataGridView()
        Me.grpCarga = New System.Windows.Forms.GroupBox()
        Me.lblEnfrentamiento = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudP2 = New System.Windows.Forms.NumericUpDown()
        Me.nudP1 = New System.Windows.Forms.NumericUpDown()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cmbGanador = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlPrincipal.SuspendLayout()
        CType(Me.dgvPartidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCarga.SuspendLayout()
        CType(Me.nudP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudP1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.BackColor = System.Drawing.Color.White
        Me.pnlPrincipal.Controls.Add(Me.lblTitulo)
        Me.pnlPrincipal.Controls.Add(Me.Label3)
        Me.pnlPrincipal.Controls.Add(Me.cboTorneo)
        Me.pnlPrincipal.Controls.Add(Me.Label1)
        Me.pnlPrincipal.Controls.Add(Me.cboZona)
        Me.pnlPrincipal.Controls.Add(Me.dgvPartidos)
        Me.pnlPrincipal.Controls.Add(Me.grpCarga)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrincipal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Padding = New System.Windows.Forms.Padding(34, 38, 34, 38)
        Me.pnlPrincipal.Size = New System.Drawing.Size(1350, 750)
        Me.pnlPrincipal.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitulo.Font = New System.Drawing.Font("Bahnschrift SemiBold", 18.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(34, 38)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(0, 19, 0, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Padding = New System.Windows.Forms.Padding(0, 19, 0, 25)
        Me.lblTitulo.Size = New System.Drawing.Size(1282, 100)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "🏆 Registrar Resultado de Partido 🏆"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(281, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 24)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Torneo"
        '
        'cboTorneo
        '
        Me.cboTorneo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTorneo.Font = New System.Drawing.Font("Bahnschrift", 9.5!)
        Me.cboTorneo.Location = New System.Drawing.Point(371, 148)
        Me.cboTorneo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboTorneo.Name = "cboTorneo"
        Me.cboTorneo.Size = New System.Drawing.Size(258, 31)
        Me.cboTorneo.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(675, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 24)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Zona"
        '
        'cboZona
        '
        Me.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZona.Font = New System.Drawing.Font("Bahnschrift", 9.5!)
        Me.cboZona.Location = New System.Drawing.Point(742, 148)
        Me.cboZona.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboZona.Name = "cboZona"
        Me.cboZona.Size = New System.Drawing.Size(258, 31)
        Me.cboZona.TabIndex = 37
        '
        'dgvPartidos
        '
        Me.dgvPartidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPartidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPartidos.BackgroundColor = System.Drawing.Color.White
        Me.dgvPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidos.Location = New System.Drawing.Point(169, 225)
        Me.dgvPartidos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvPartidos.Name = "dgvPartidos"
        Me.dgvPartidos.RowHeadersWidth = 51
        Me.dgvPartidos.RowTemplate.Height = 24
        Me.dgvPartidos.Size = New System.Drawing.Size(1012, 250)
        Me.dgvPartidos.TabIndex = 38
        '
        'grpCarga
        '
        Me.grpCarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCarga.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpCarga.Controls.Add(Me.lblEnfrentamiento)
        Me.grpCarga.Controls.Add(Me.Label5)
        Me.grpCarga.Controls.Add(Me.nudP2)
        Me.grpCarga.Controls.Add(Me.nudP1)
        Me.grpCarga.Controls.Add(Me.btnCancelar)
        Me.grpCarga.Controls.Add(Me.btnGuardar)
        Me.grpCarga.Controls.Add(Me.cmbGanador)
        Me.grpCarga.Controls.Add(Me.Label2)
        Me.grpCarga.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.grpCarga.Location = New System.Drawing.Point(202, 500)
        Me.grpCarga.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpCarga.Name = "grpCarga"
        Me.grpCarga.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpCarga.Size = New System.Drawing.Size(945, 225)
        Me.grpCarga.TabIndex = 39
        Me.grpCarga.TabStop = False
        '
        'lblEnfrentamiento
        '
        Me.lblEnfrentamiento.AutoSize = True
        Me.lblEnfrentamiento.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!)
        Me.lblEnfrentamiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblEnfrentamiento.Location = New System.Drawing.Point(280, 30)
        Me.lblEnfrentamiento.Name = "lblEnfrentamiento"
        Me.lblEnfrentamiento.Size = New System.Drawing.Size(204, 27)
        Me.lblEnfrentamiento.TabIndex = 0
        Me.lblEnfrentamiento.Text = "Pareja 1 vs Pareja 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(45, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(207, 24)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Games a favor/contra"
        '
        'nudP2
        '
        Me.nudP2.Location = New System.Drawing.Point(630, 88)
        Me.nudP2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudP2.Name = "nudP2"
        Me.nudP2.Size = New System.Drawing.Size(112, 29)
        Me.nudP2.TabIndex = 1
        '
        'nudP1
        '
        Me.nudP1.Location = New System.Drawing.Point(315, 88)
        Me.nudP1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudP1.Name = "nudP1"
        Me.nudP1.Size = New System.Drawing.Size(112, 29)
        Me.nudP1.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Bahnschrift SemiBold", 9.0!)
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(518, 175)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(169, 44)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Bahnschrift SemiBold", 9.0!)
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(281, 175)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(169, 44)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'cmbGanador
        '
        Me.cmbGanador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGanador.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.cmbGanador.Location = New System.Drawing.Point(495, 135)
        Me.cmbGanador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbGanador.Name = "cmbGanador"
        Me.cmbGanador.Size = New System.Drawing.Size(168, 30)
        Me.cmbGanador.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(382, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Ganador"
        '
        'frmRegistrarResultadoPartido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1350, 750)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmRegistrarResultadoPartido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Resultado de Partido"
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlPrincipal.PerformLayout()
        CType(Me.dgvPartidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCarga.ResumeLayout(False)
        Me.grpCarga.PerformLayout()
        CType(Me.nudP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudP1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPrincipal As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboTorneo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboZona As ComboBox
    Friend WithEvents dgvPartidos As DataGridView
    Friend WithEvents grpCarga As GroupBox
    Friend WithEvents cmbGanador As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents nudP2 As NumericUpDown
    Friend WithEvents nudP1 As NumericUpDown
    Friend WithEvents lblEnfrentamiento As Label
End Class
