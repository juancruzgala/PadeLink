<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditarUsuario
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
        Me.cboRol = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlContenido.SuspendLayout()
        Me.SuspendLayout()
        '
        '=== FORM ===
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(240, 243, 247)
        Me.ClientSize = New System.Drawing.Size(800, 500)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEditarUsuario"
        Me.Text = "Editar Usuario"
        Me.Dock = DockStyle.Fill
        '
        '=== TÍTULO ===
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitulo.Font = New System.Drawing.Font("Bahnschrift SemiBold", 18.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblTitulo.Height = 100
        Me.lblTitulo.Padding = New Padding(0, 20, 0, 10)
        Me.lblTitulo.Text = "🧑‍💼 Editar Usuario 🧑‍💼"
        '
        '=== PANEL CONTENEDOR ===
        '
        Me.pnlContenido.BackColor = System.Drawing.Color.White
        Me.pnlContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlContenido.Anchor = AnchorStyles.None
        Me.pnlContenido.Padding = New Padding(40)
        Me.pnlContenido.Size = New System.Drawing.Size(600, 320)
        Me.pnlContenido.Location = New System.Drawing.Point(
            (Me.ClientSize.Width - Me.pnlContenido.Width) \ 2,
            (Me.ClientSize.Height - Me.pnlContenido.Height) \ 2)
        Me.pnlContenido.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        '
        '=== LABEL NOMBRE ===
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift", 11.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.Label2.Location = New System.Drawing.Point(40, 40)
        Me.Label2.Text = "Nombre de Usuario:"
        '
        '=== TXT NOMBRE ===
        '
        Me.TxtNombre.Font = New System.Drawing.Font("Bahnschrift", 11.0!)
        Me.TxtNombre.Location = New System.Drawing.Point(260, 38)
        Me.TxtNombre.Size = New System.Drawing.Size(280, 30)
        '
        '=== LABEL CONTRASEÑA ===
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift", 11.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.Label3.Location = New System.Drawing.Point(40, 100)
        Me.Label3.Text = "Contraseña:"
        '
        '=== TXT CONTRASEÑA ===
        '
        Me.txtContrasena.Font = New System.Drawing.Font("Bahnschrift", 11.0!)
        Me.txtContrasena.Location = New System.Drawing.Point(260, 98)
        Me.txtContrasena.Size = New System.Drawing.Size(280, 30)
        '
        '=== LABEL ROL ===
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift", 11.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.Label4.Location = New System.Drawing.Point(40, 160)
        Me.Label4.Text = "Rol:"
        '
        '=== COMBO ROL ===
        '
        Me.cboRol.Font = New System.Drawing.Font("Bahnschrift", 11.0!)
        Me.cboRol.Location = New System.Drawing.Point(260, 158)
        Me.cboRol.Size = New System.Drawing.Size(200, 30)
        '
        '=== BOTÓN GUARDAR ===
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(72, 201, 176)
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.Font = New System.Drawing.Font("Bahnschrift SemiBold", 10.0!)
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Size = New System.Drawing.Size(140, 40)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        '=== BOTÓN CANCELAR ===
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(200, 200, 200)
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.Font = New System.Drawing.Font("Bahnschrift SemiBold", 10.0!)
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Size = New System.Drawing.Size(140, 40)
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        '=== ESTRUCTURA FINAL ===
        '
        Me.pnlContenido.Controls.Add(Me.Label2)
        Me.pnlContenido.Controls.Add(Me.TxtNombre)
        Me.pnlContenido.Controls.Add(Me.Label3)
        Me.pnlContenido.Controls.Add(Me.txtContrasena)
        Me.pnlContenido.Controls.Add(Me.Label4)
        Me.pnlContenido.Controls.Add(Me.cboRol)
        Me.pnlContenido.Controls.Add(Me.btnGuardar)
        Me.pnlContenido.Controls.Add(Me.btnCancelar)

        Me.Controls.Add(Me.pnlContenido)
        Me.Controls.Add(Me.lblTitulo)

        Me.pnlContenido.ResumeLayout(False)
        Me.pnlContenido.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlContenido As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents cboRol As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
End Class
