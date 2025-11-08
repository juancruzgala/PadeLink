<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class editar_pareja
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtJugador2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cboEstadoPago = New System.Windows.Forms.ComboBox()
        Me.txtJugador1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDni1 = New System.Windows.Forms.TextBox()
        Me.txtDni2 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(461, 133)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(13, 20)
        Me.lblTitulo.TabIndex = 30
        Me.lblTitulo.Text = "."
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtJugador2
        '
        Me.txtJugador2.Location = New System.Drawing.Point(261, 186)
        Me.txtJugador2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtJugador2.Name = "txtJugador2"
        Me.txtJugador2.Size = New System.Drawing.Size(236, 26)
        Me.txtJugador2.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(320, 310)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 24)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Seña/Pago:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(160, 207)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(98, 24)
        Me.lblNombre.TabIndex = 27
        Me.lblNombre.Text = "Nombres:"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancelar.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(555, 413)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(205, 34)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnVolver.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.Location = New System.Drawing.Point(836, 499)
        Me.btnVolver.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(130, 34)
        Me.btnVolver.TabIndex = 25
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Azure
        Me.btnGuardar.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(290, 413)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(207, 34)
        Me.btnGuardar.TabIndex = 24
        Me.btnGuardar.Text = "Guardar Cambios"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'cboEstadoPago
        '
        Me.cboEstadoPago.FormattingEnabled = True
        Me.cboEstadoPago.Items.AddRange(New Object() {"SI", "NO"})
        Me.cboEstadoPago.Location = New System.Drawing.Point(459, 310)
        Me.cboEstadoPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboEstadoPago.Name = "cboEstadoPago"
        Me.cboEstadoPago.Size = New System.Drawing.Size(132, 28)
        Me.cboEstadoPago.TabIndex = 23
        '
        'txtJugador1
        '
        Me.txtJugador1.Location = New System.Drawing.Point(264, 232)
        Me.txtJugador1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtJugador1.Name = "txtJugador1"
        Me.txtJugador1.Size = New System.Drawing.Size(230, 26)
        Me.txtJugador1.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 55)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(976, 85)
        Me.Panel1.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift", 16.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(364, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 39)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Modificar Pareja"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift", 16.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(250, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 39)
        Me.Label1.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(528, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 24)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "DNIs:"
        '
        'txtDni1
        '
        Me.txtDni1.Location = New System.Drawing.Point(592, 183)
        Me.txtDni1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDni1.Name = "txtDni1"
        Me.txtDni1.Size = New System.Drawing.Size(236, 26)
        Me.txtDni1.TabIndex = 32
        '
        'txtDni2
        '
        Me.txtDni2.Location = New System.Drawing.Point(593, 229)
        Me.txtDni2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDni2.Name = "txtDni2"
        Me.txtDni2.Size = New System.Drawing.Size(236, 26)
        Me.txtDni2.TabIndex = 33
        '
        'editar_pareja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 544)
        Me.Controls.Add(Me.txtDni2)
        Me.Controls.Add(Me.txtDni1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.txtJugador2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cboEstadoPago)
        Me.Controls.Add(Me.txtJugador1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "editar_pareja"
        Me.Text = "editar_pareja"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents txtJugador2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnVolver As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents cboEstadoPago As ComboBox
    Friend WithEvents txtJugador1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDni1 As TextBox
    Friend WithEvents txtDni2 As TextBox
End Class
