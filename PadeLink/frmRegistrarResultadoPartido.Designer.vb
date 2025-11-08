<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistrarResultadoPartido
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTorneo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboZona = New System.Windows.Forms.ComboBox()
        Me.dgvPartidos = New System.Windows.Forms.DataGridView()
        Me.grpCarga = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudP2 = New System.Windows.Forms.NumericUpDown()
        Me.nudP1 = New System.Windows.Forms.NumericUpDown()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cmbGanador = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPareja2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPareja1 = New System.Windows.Forms.Label()
        CType(Me.dgvPartidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCarga.SuspendLayout()
        CType(Me.nudP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudP1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(414, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 21)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Torneo"
        '
        'cboTorneo
        '
        Me.cboTorneo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTorneo.FormattingEnabled = True
        Me.cboTorneo.Location = New System.Drawing.Point(540, 51)
        Me.cboTorneo.Name = "cboTorneo"
        Me.cboTorneo.Size = New System.Drawing.Size(240, 24)
        Me.cboTorneo.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(414, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 21)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Zona"
        '
        'cboZona
        '
        Me.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZona.FormattingEnabled = True
        Me.cboZona.Location = New System.Drawing.Point(540, 104)
        Me.cboZona.Name = "cboZona"
        Me.cboZona.Size = New System.Drawing.Size(240, 24)
        Me.cboZona.TabIndex = 37
        '
        'dgvPartidos
        '
        Me.dgvPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidos.Location = New System.Drawing.Point(349, 166)
        Me.dgvPartidos.Name = "dgvPartidos"
        Me.dgvPartidos.RowHeadersWidth = 51
        Me.dgvPartidos.RowTemplate.Height = 24
        Me.dgvPartidos.Size = New System.Drawing.Size(506, 232)
        Me.dgvPartidos.TabIndex = 38
        '
        'grpCarga
        '
        Me.grpCarga.Controls.Add(Me.Label5)
        Me.grpCarga.Controls.Add(Me.nudP2)
        Me.grpCarga.Controls.Add(Me.nudP1)
        Me.grpCarga.Controls.Add(Me.btnCancelar)
        Me.grpCarga.Controls.Add(Me.btnGuardar)
        Me.grpCarga.Controls.Add(Me.cmbGanador)
        Me.grpCarga.Controls.Add(Me.Label2)
        Me.grpCarga.Controls.Add(Me.lblPareja2)
        Me.grpCarga.Controls.Add(Me.Label4)
        Me.grpCarga.Controls.Add(Me.lblPareja1)
        Me.grpCarga.Location = New System.Drawing.Point(164, 404)
        Me.grpCarga.Name = "grpCarga"
        Me.grpCarga.Size = New System.Drawing.Size(792, 307)
        Me.grpCarga.TabIndex = 39
        Me.grpCarga.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(175, 21)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Games a favor/contra"
        '
        'nudP2
        '
        Me.nudP2.Location = New System.Drawing.Point(527, 67)
        Me.nudP2.Name = "nudP2"
        Me.nudP2.Size = New System.Drawing.Size(120, 22)
        Me.nudP2.TabIndex = 48
        '
        'nudP1
        '
        Me.nudP1.Location = New System.Drawing.Point(254, 67)
        Me.nudP1.Name = "nudP1"
        Me.nudP1.Size = New System.Drawing.Size(120, 22)
        Me.nudP1.TabIndex = 47
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Azure
        Me.btnCancelar.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(527, 223)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(156, 30)
        Me.btnCancelar.TabIndex = 46
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Azure
        Me.btnGuardar.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(218, 223)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(156, 30)
        Me.btnGuardar.TabIndex = 45
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'cmbGanador
        '
        Me.cmbGanador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGanador.FormattingEnabled = True
        Me.cmbGanador.Location = New System.Drawing.Point(376, 138)
        Me.cmbGanador.Name = "cmbGanador"
        Me.cmbGanador.Size = New System.Drawing.Size(139, 24)
        Me.cmbGanador.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(259, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 21)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Ganador"
        '
        'lblPareja2
        '
        Me.lblPareja2.AutoSize = True
        Me.lblPareja2.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPareja2.Location = New System.Drawing.Point(580, 18)
        Me.lblPareja2.Name = "lblPareja2"
        Me.lblPareja2.Size = New System.Drawing.Size(67, 21)
        Me.lblPareja2.TabIndex = 39
        Me.lblPareja2.Text = "pareja2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(403, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 21)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "vs"
        '
        'lblPareja1
        '
        Me.lblPareja1.AutoSize = True
        Me.lblPareja1.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPareja1.Location = New System.Drawing.Point(250, 18)
        Me.lblPareja1.Name = "lblPareja1"
        Me.lblPareja1.Size = New System.Drawing.Size(64, 21)
        Me.lblPareja1.TabIndex = 37
        Me.lblPareja1.Text = "pareja1"
        '
        'frmRegistrarResultadoPartido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 744)
        Me.Controls.Add(Me.grpCarga)
        Me.Controls.Add(Me.dgvPartidos)
        Me.Controls.Add(Me.cboZona)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTorneo)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmRegistrarResultadoPartido"
        Me.Text = "frmRegistrarResultadoPartido"
        CType(Me.dgvPartidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCarga.ResumeLayout(False)
        Me.grpCarga.PerformLayout()
        CType(Me.nudP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudP1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents cboTorneo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboZona As ComboBox
    Friend WithEvents dgvPartidos As DataGridView
    Friend WithEvents grpCarga As GroupBox
    Friend WithEvents lblPareja2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblPareja1 As Label
    Friend WithEvents cmbGanador As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents nudP2 As NumericUpDown
    Friend WithEvents nudP1 As NumericUpDown
End Class
