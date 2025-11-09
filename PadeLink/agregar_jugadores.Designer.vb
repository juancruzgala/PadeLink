<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class agregar_jugadores
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJugador1 = New System.Windows.Forms.TextBox()
        Me.cboSeniaPago = New System.Windows.Forms.ComboBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnListaInscriptos = New System.Windows.Forms.Button()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtJugador2 = New System.Windows.Forms.TextBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtDni1 = New System.Windows.Forms.TextBox()
        Me.txtDni2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 82)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(976, 72)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift", 16.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(400, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(240, 39)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Inscribir Pareja"
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
        'txtJugador1
        '
        Me.txtJugador1.Location = New System.Drawing.Point(306, 218)
        Me.txtJugador1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtJugador1.Name = "txtJugador1"
        Me.txtJugador1.Size = New System.Drawing.Size(230, 26)
        Me.txtJugador1.TabIndex = 1
        '
        'cboSeniaPago
        '
        Me.cboSeniaPago.FormattingEnabled = True
        Me.cboSeniaPago.Items.AddRange(New Object() {"SI", "NO"})
        Me.cboSeniaPago.Location = New System.Drawing.Point(490, 318)
        Me.cboSeniaPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboSeniaPago.Name = "cboSeniaPago"
        Me.cboSeniaPago.Size = New System.Drawing.Size(164, 28)
        Me.cboSeniaPago.TabIndex = 2
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.Azure
        Me.btnAgregar.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(452, 408)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(127, 34)
        Me.btnAgregar.TabIndex = 14
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnVolver.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.Location = New System.Drawing.Point(808, 481)
        Me.btnVolver.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(130, 34)
        Me.btnVolver.TabIndex = 15
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'btnListaInscriptos
        '
        Me.btnListaInscriptos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnListaInscriptos.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListaInscriptos.Location = New System.Drawing.Point(418, 481)
        Me.btnListaInscriptos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnListaInscriptos.Name = "btnListaInscriptos"
        Me.btnListaInscriptos.Size = New System.Drawing.Size(205, 34)
        Me.btnListaInscriptos.TabIndex = 16
        Me.btnListaInscriptos.Text = "Lista Inscriptos"
        Me.btnListaInscriptos.UseVisualStyleBackColor = False
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(190, 239)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(98, 24)
        Me.lblNombre.TabIndex = 17
        Me.lblNombre.Text = "Nombres:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(360, 318)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 24)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Seña/Pago:"
        '
        'txtJugador2
        '
        Me.txtJugador2.Location = New System.Drawing.Point(306, 262)
        Me.txtJugador2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtJugador2.Name = "txtJugador2"
        Me.txtJugador2.Size = New System.Drawing.Size(230, 26)
        Me.txtJugador2.TabIndex = 19
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(754, 184)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(13, 20)
        Me.lblTitulo.TabIndex = 20
        Me.lblTitulo.Text = "."
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDni1
        '
        Me.txtDni1.Location = New System.Drawing.Point(619, 218)
        Me.txtDni1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDni1.Name = "txtDni1"
        Me.txtDni1.Size = New System.Drawing.Size(230, 26)
        Me.txtDni1.TabIndex = 21
        '
        'txtDni2
        '
        Me.txtDni2.Location = New System.Drawing.Point(619, 262)
        Me.txtDni2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDni2.Name = "txtDni2"
        Me.txtDni2.Size = New System.Drawing.Size(230, 26)
        Me.txtDni2.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(546, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 24)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "DNIs:"
        '
        'agregar_jugadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1178, 544)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDni2)
        Me.Controls.Add(Me.txtDni1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.txtJugador2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.btnListaInscriptos)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.cboSeniaPago)
        Me.Controls.Add(Me.txtJugador1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "agregar_jugadores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inscribir Parejas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtJugador1 As TextBox
    Friend WithEvents cboSeniaPago As ComboBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnVolver As Button
    Friend WithEvents btnListaInscriptos As Button
    Friend WithEvents lblNombre As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtJugador2 As TextBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents txtDni1 As TextBox
    Friend WithEvents txtDni2 As TextBox
    Friend WithEvents Label5 As Label
End Class
