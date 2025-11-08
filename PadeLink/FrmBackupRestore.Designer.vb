<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBackupRestore
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
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnElegirDestino = New System.Windows.Forms.Button()
        Me.btnHacerBackup = New System.Windows.Forms.Button()
        Me.btnElegirBak = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConfirmacion = New System.Windows.Forms.TextBox()
        Me.chkEstoySeguro = New System.Windows.Forms.CheckBox()
        Me.btnRestaurar = New System.Windows.Forms.Button()
        Me.txtBackupDestino = New System.Windows.Forms.TextBox()
        Me.txtBakOrigen = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(245, 324)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(180, 24)
        Me.lblNombre.TabIndex = 29
        Me.lblNombre.Text = "Origen del Backup:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(550, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 24)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Restaurar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(268, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 24)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Backup Destino:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(574, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 24)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Backup"
        '
        'btnElegirDestino
        '
        Me.btnElegirDestino.BackColor = System.Drawing.Color.Azure
        Me.btnElegirDestino.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnElegirDestino.Location = New System.Drawing.Point(766, 125)
        Me.btnElegirDestino.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnElegirDestino.Name = "btnElegirDestino"
        Me.btnElegirDestino.Size = New System.Drawing.Size(176, 38)
        Me.btnElegirDestino.TabIndex = 44
        Me.btnElegirDestino.Text = "Elegir Destino"
        Me.btnElegirDestino.UseVisualStyleBackColor = False
        '
        'btnHacerBackup
        '
        Me.btnHacerBackup.BackColor = System.Drawing.Color.Azure
        Me.btnHacerBackup.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHacerBackup.Location = New System.Drawing.Point(525, 172)
        Me.btnHacerBackup.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnHacerBackup.Name = "btnHacerBackup"
        Me.btnHacerBackup.Size = New System.Drawing.Size(176, 40)
        Me.btnHacerBackup.TabIndex = 45
        Me.btnHacerBackup.Text = "Hacer Backup"
        Me.btnHacerBackup.UseVisualStyleBackColor = False
        '
        'btnElegirBak
        '
        Me.btnElegirBak.BackColor = System.Drawing.Color.Azure
        Me.btnElegirBak.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnElegirBak.Location = New System.Drawing.Point(766, 317)
        Me.btnElegirBak.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnElegirBak.Name = "btnElegirBak"
        Me.btnElegirBak.Size = New System.Drawing.Size(176, 40)
        Me.btnElegirBak.TabIndex = 46
        Me.btnElegirBak.Text = "Elegir Backup"
        Me.btnElegirBak.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(389, 373)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(446, 24)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Para restaurar escribir ""RESTAURAR PadeLink"":"
        '
        'txtConfirmacion
        '
        Me.txtConfirmacion.Location = New System.Drawing.Point(394, 416)
        Me.txtConfirmacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtConfirmacion.Name = "txtConfirmacion"
        Me.txtConfirmacion.Size = New System.Drawing.Size(416, 26)
        Me.txtConfirmacion.TabIndex = 48
        '
        'chkEstoySeguro
        '
        Me.chkEstoySeguro.AutoSize = True
        Me.chkEstoySeguro.Location = New System.Drawing.Point(525, 465)
        Me.chkEstoySeguro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkEstoySeguro.Name = "chkEstoySeguro"
        Me.chkEstoySeguro.Size = New System.Drawing.Size(128, 24)
        Me.chkEstoySeguro.TabIndex = 49
        Me.chkEstoySeguro.Text = "Estoy seguro"
        Me.chkEstoySeguro.UseVisualStyleBackColor = True
        '
        'btnRestaurar
        '
        Me.btnRestaurar.BackColor = System.Drawing.Color.Azure
        Me.btnRestaurar.Enabled = False
        Me.btnRestaurar.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestaurar.Location = New System.Drawing.Point(500, 512)
        Me.btnRestaurar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRestaurar.Name = "btnRestaurar"
        Me.btnRestaurar.Size = New System.Drawing.Size(176, 40)
        Me.btnRestaurar.TabIndex = 50
        Me.btnRestaurar.Text = "Restaurar"
        Me.btnRestaurar.UseVisualStyleBackColor = False
        '
        'txtBackupDestino
        '
        Me.txtBackupDestino.Location = New System.Drawing.Point(434, 124)
        Me.txtBackupDestino.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBackupDestino.Name = "txtBackupDestino"
        Me.txtBackupDestino.Size = New System.Drawing.Size(304, 26)
        Me.txtBackupDestino.TabIndex = 52
        '
        'txtBakOrigen
        '
        Me.txtBakOrigen.Location = New System.Drawing.Point(434, 323)
        Me.txtBakOrigen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBakOrigen.Name = "txtBakOrigen"
        Me.txtBakOrigen.Size = New System.Drawing.Size(304, 26)
        Me.txtBakOrigen.TabIndex = 53
        '
        'FrmBackupRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 578)
        Me.Controls.Add(Me.txtBakOrigen)
        Me.Controls.Add(Me.txtBackupDestino)
        Me.Controls.Add(Me.btnRestaurar)
        Me.Controls.Add(Me.chkEstoySeguro)
        Me.Controls.Add(Me.txtConfirmacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnElegirBak)
        Me.Controls.Add(Me.btnHacerBackup)
        Me.Controls.Add(Me.btnElegirDestino)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNombre)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmBackupRestore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de PadeLink"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombre As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnElegirDestino As Button
    Friend WithEvents btnHacerBackup As Button
    Friend WithEvents btnElegirBak As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtConfirmacion As TextBox
    Friend WithEvents chkEstoySeguro As CheckBox
    Friend WithEvents btnRestaurar As Button
    Friend WithEvents txtBackupDestino As TextBox
    Friend WithEvents txtBakOrigen As TextBox
End Class
