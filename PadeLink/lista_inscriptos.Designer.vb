<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lista_inscriptos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.dgvInscriptos = New System.Windows.Forms.DataGridView()
        Me.cPareja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado_pago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Accion = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Accion2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvInscriptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(3, 76)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(10, 8, 10, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(974, 74)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Bahnschrift", 16.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(358, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(282, 39)
        Me.lblTitulo.TabIndex = 19
        Me.lblTitulo.Text = "Lista de Inscriptos"
        '
        'dgvInscriptos
        '
        Me.dgvInscriptos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInscriptos.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvInscriptos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInscriptos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInscriptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInscriptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cPareja, Me.Estado_pago, Me.Accion, Me.Accion2})
        Me.dgvInscriptos.Location = New System.Drawing.Point(12, 156)
        Me.dgvInscriptos.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.dgvInscriptos.Name = "dgvInscriptos"
        Me.dgvInscriptos.RowHeadersWidth = 62
        Me.dgvInscriptos.RowTemplate.Height = 28
        Me.dgvInscriptos.Size = New System.Drawing.Size(965, 224)
        Me.dgvInscriptos.TabIndex = 1
        '
        'cPareja
        '
        Me.cPareja.HeaderText = "Parejas"
        Me.cPareja.MinimumWidth = 8
        Me.cPareja.Name = "cPareja"
        Me.cPareja.Width = 98
        '
        'Estado_pago
        '
        Me.Estado_pago.HeaderText = "Estado de Pago"
        Me.Estado_pago.MinimumWidth = 8
        Me.Estado_pago.Name = "Estado_pago"
        Me.Estado_pago.Width = 113
        '
        'Accion
        '
        Me.Accion.HeaderText = "Accion"
        Me.Accion.MinimumWidth = 8
        Me.Accion.Name = "Accion"
        Me.Accion.Text = "Editar"
        Me.Accion.UseColumnTextForButtonValue = True
        Me.Accion.Width = 63
        '
        'Accion2
        '
        Me.Accion2.HeaderText = "Accion"
        Me.Accion2.MinimumWidth = 8
        Me.Accion2.Name = "Accion2"
        Me.Accion2.Text = "Eliminar"
        Me.Accion2.Width = 63
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnVolver.Font = New System.Drawing.Font("Bahnschrift", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.Location = New System.Drawing.Point(776, 434)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(130, 34)
        Me.btnVolver.TabIndex = 16
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'lista_inscriptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 544)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.dgvInscriptos)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "lista_inscriptos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parejas Inscriptas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvInscriptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents dgvInscriptos As DataGridView
    Friend WithEvents btnVolver As Button
    Friend WithEvents cPareja As DataGridViewTextBoxColumn
    Friend WithEvents Estado_pago As DataGridViewTextBoxColumn
    Friend WithEvents Accion As DataGridViewButtonColumn
    Friend WithEvents Accion2 As DataGridViewButtonColumn
End Class
