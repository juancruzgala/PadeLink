<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class busqueda_fiscal
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNuevoNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNuevoDni = New System.Windows.Forms.TextBox()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.btnAgregarJugador = New System.Windows.Forms.Button()
        Me.dgvResultados = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cboTorneo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDni = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(537, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 24)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "AGREGAR"
        '
        'txtNuevoNombre
        '
        Me.txtNuevoNombre.Location = New System.Drawing.Point(288, 2)
        Me.txtNuevoNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNuevoNombre.Name = "txtNuevoNombre"
        Me.txtNuevoNombre.Size = New System.Drawing.Size(131, 26)
        Me.txtNuevoNombre.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(194, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 24)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Nombre:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 24)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "DNI:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(425, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 24)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Categoria:"
        '
        'txtNuevoDni
        '
        Me.txtNuevoDni.Location = New System.Drawing.Point(57, 2)
        Me.txtNuevoDni.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNuevoDni.Name = "txtNuevoDni"
        Me.txtNuevoDni.Size = New System.Drawing.Size(131, 26)
        Me.txtNuevoDni.TabIndex = 41
        '
        'cboCategoria
        '
        Me.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Items.AddRange(New Object() {"SI", "NO"})
        Me.cboCategoria.Location = New System.Drawing.Point(534, 2)
        Me.cboCategoria.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(132, 28)
        Me.cboCategoria.TabIndex = 42
        '
        'btnAgregarJugador
        '
        Me.btnAgregarJugador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAgregarJugador.BackColor = System.Drawing.Color.Azure
        Me.btnAgregarJugador.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarJugador.Location = New System.Drawing.Point(478, 95)
        Me.btnAgregarJugador.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregarJugador.Name = "btnAgregarJugador"
        Me.btnAgregarJugador.Size = New System.Drawing.Size(215, 34)
        Me.btnAgregarJugador.TabIndex = 43
        Me.btnAgregarJugador.Text = "Agregar Jugador"
        Me.btnAgregarJugador.UseVisualStyleBackColor = False
        '
        'dgvResultados
        '
        Me.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultados.Location = New System.Drawing.Point(3, 389)
        Me.dgvResultados.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvResultados.Name = "dgvResultados"
        Me.dgvResultados.ReadOnly = True
        Me.dgvResultados.RowHeadersWidth = 51
        Me.dgvResultados.RowTemplate.Height = 24
        Me.dgvResultados.Size = New System.Drawing.Size(1172, 220)
        Me.dgvResultados.TabIndex = 44
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.77215!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.22785!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvResultados, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.33766!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.66234!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 227.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1178, 613)
        Me.TableLayoutPanel1.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label1.Location = New System.Drawing.Point(530, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 24)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "BUSQUEDA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBuscar.BackColor = System.Drawing.Color.Azure
        Me.btnBuscar.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(531, 128)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(109, 34)
        Me.btnBuscar.TabIndex = 35
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'cboTorneo
        '
        Me.cboTorneo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboTorneo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTorneo.FormattingEnabled = True
        Me.cboTorneo.Items.AddRange(New Object() {"SI", "NO"})
        Me.cboTorneo.Location = New System.Drawing.Point(499, 2)
        Me.cboTorneo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboTorneo.Name = "cboTorneo"
        Me.cboTorneo.Size = New System.Drawing.Size(132, 28)
        Me.cboTorneo.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(416, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 24)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Torneo:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(288, 2)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(122, 26)
        Me.txtNombre.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(194, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Nombre:"
        '
        'txtDni
        '
        Me.txtDni.Location = New System.Drawing.Point(57, 2)
        Me.txtDni.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(131, 26)
        Me.txtDni.TabIndex = 30
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(3, 0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 24)
        Me.lblNombre.TabIndex = 28
        Me.lblNombre.Text = "DNI:"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBuscar, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 67)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1172, 170)
        Me.TableLayoutPanel2.TabIndex = 45
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.FlowLayoutPanel1.Controls.Add(Me.lblNombre)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtDni)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtNombre)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.cboTorneo)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(269, 74)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(634, 32)
        Me.FlowLayoutPanel1.TabIndex = 30
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnAgregarJugador, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 243)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.83721!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.16279!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1172, 139)
        Me.TableLayoutPanel3.TabIndex = 46
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FlowLayoutPanel2.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtNuevoDni)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtNuevoNombre)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel2.Controls.Add(Me.cboCategoria)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(251, 45)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(669, 38)
        Me.FlowLayoutPanel2.TabIndex = 37
        '
        'busqueda_fiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1178, 613)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "busqueda_fiscal"
        Me.Text = "Buscar"
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNuevoNombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNuevoDni As TextBox
    Friend WithEvents cboCategoria As ComboBox
    Friend WithEvents btnAgregarJugador As Button
    Friend WithEvents dgvResultados As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents cboTorneo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDni As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
End Class
