<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevoUsuario
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.cboRol = New System.Windows.Forms.ComboBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlMain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTitulo.Font = New System.Drawing.Font("Bahnschrift", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblTitulo.Location = New System.Drawing.Point(3, 133)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(1194, 60)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "🎾 PADELINK 🎾"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 227)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1194, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Agregar un nuevo usuario"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Font = New System.Drawing.Font("Bookman Old Style", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(458, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 30)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre de usuario:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.Font = New System.Drawing.Font("Bookman Old Style", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(480, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(228, 30)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Contraseña:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.Font = New System.Drawing.Font("Bookman Old Style", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(535, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 30)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Rol:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtNombre
        '
        Me.TxtNombre.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNombre.Location = New System.Drawing.Point(486, 48)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(222, 35)
        Me.TxtNombre.TabIndex = 3
        Me.TxtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtContrasena
        '
        Me.txtContrasena.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtContrasena.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtContrasena.Location = New System.Drawing.Point(485, 47)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtContrasena.Size = New System.Drawing.Size(222, 35)
        Me.txtContrasena.TabIndex = 5
        Me.txtContrasena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboRol
        '
        Me.cboRol.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cboRol.FormattingEnabled = True
        Me.cboRol.Location = New System.Drawing.Point(486, 44)
        Me.cboRol.Name = "cboRol"
        Me.cboRol.Size = New System.Drawing.Size(222, 34)
        Me.cboRol.TabIndex = 7
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGuardar.BackColor = System.Drawing.Color.Azure
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnGuardar.Location = New System.Drawing.Point(437, 31)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(130, 45)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnCancelar.Location = New System.Drawing.Point(634, 31)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(130, 45)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.pnlMain.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1200, 800)
        Me.pnlMain.TabIndex = 0
        '
        'btnAyuda
        '
        Me.btnAyuda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAyuda.BackColor = System.Drawing.Color.CadetBlue
        Me.btnAyuda.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAyuda.Font = New System.Drawing.Font("Bahnschrift SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAyuda.Location = New System.Drawing.Point(1029, 136)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(124, 40)
        Me.btnAyuda.TabIndex = 10
        Me.btnAyuda.Text = "❔ Ayuda"
        Me.btnAyuda.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTitulo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.125!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.125!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.5!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1200, 800)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtNombre)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 270)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1194, 100)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtContrasena)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 376)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1194, 99)
        Me.Panel2.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.cboRol)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 481)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1194, 102)
        Me.Panel3.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnAyuda)
        Me.Panel4.Controls.Add(Me.btnGuardar)
        Me.Panel4.Controls.Add(Me.btnCancelar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 589)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1194, 208)
        Me.Panel4.TabIndex = 5
        '
        'frmNuevoUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(1200, 800)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmNuevoUsuario"
        Me.Text = "Crear Usuario"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents cboRol As ComboBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAyuda As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
End Class
