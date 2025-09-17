<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaUsuarios
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
        Me.components = New System.ComponentModel.Container()
        Me.PadeLinkDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PadeLinkDataSet = New PadeLink.PadeLinkDataSet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsuariosRolesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usuarios_RolesTableAdapter = New PadeLink.PadeLinkDataSetTableAdapters.Usuarios_RolesTableAdapter()
        Me.UsuariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UsuariosRolesBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.UsuariosTableAdapter = New PadeLink.PadeLinkDataSetTableAdapters.UsuariosTableAdapter()
        Me.UsuariosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnCrearUsuario = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.UsuariosBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.UsuariosBindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdusuarioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreusuarioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContraseñaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PadeLinkDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PadeLinkDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosRolesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosRolesBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosBindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PadeLinkDataSetBindingSource
        '
        Me.PadeLinkDataSetBindingSource.DataSource = Me.PadeLinkDataSet
        Me.PadeLinkDataSetBindingSource.Position = 0
        '
        'PadeLinkDataSet
        '
        Me.PadeLinkDataSet.DataSetName = "PadeLinkDataSet"
        Me.PadeLinkDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(457, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 28)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Lista de Usuarios"
        '
        'UsuariosRolesBindingSource
        '
        Me.UsuariosRolesBindingSource.DataMember = "Usuarios_Roles"
        Me.UsuariosRolesBindingSource.DataSource = Me.PadeLinkDataSet
        '
        'Usuarios_RolesTableAdapter
        '
        Me.Usuarios_RolesTableAdapter.ClearBeforeFill = True
        '
        'UsuariosBindingSource
        '
        Me.UsuariosBindingSource.DataMember = "Usuarios"
        Me.UsuariosBindingSource.DataSource = Me.PadeLinkDataSetBindingSource
        '
        'UsuariosRolesBindingSource1
        '
        Me.UsuariosRolesBindingSource1.DataMember = "Usuarios_Roles"
        Me.UsuariosRolesBindingSource1.DataSource = Me.PadeLinkDataSet
        '
        'UsuariosTableAdapter
        '
        Me.UsuariosTableAdapter.ClearBeforeFill = True
        '
        'UsuariosBindingSource1
        '
        Me.UsuariosBindingSource1.DataMember = "Usuarios"
        Me.UsuariosBindingSource1.DataSource = Me.PadeLinkDataSetBindingSource
        '
        'btnCrearUsuario
        '
        Me.btnCrearUsuario.Location = New System.Drawing.Point(97, 578)
        Me.btnCrearUsuario.Name = "btnCrearUsuario"
        Me.btnCrearUsuario.Size = New System.Drawing.Size(154, 39)
        Me.btnCrearUsuario.TabIndex = 5
        Me.btnCrearUsuario.Text = "Crear Usuario"
        Me.btnCrearUsuario.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(928, 574)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(145, 43)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'UsuariosBindingSource2
        '
        Me.UsuariosBindingSource2.DataMember = "Usuarios"
        Me.UsuariosBindingSource2.DataSource = Me.PadeLinkDataSetBindingSource
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AutoGenerateColumns = False
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdusuarioDataGridViewTextBoxColumn, Me.NombreusuarioDataGridViewTextBoxColumn, Me.ContraseñaDataGridViewTextBoxColumn, Me.EstadoDataGridViewTextBoxColumn})
        Me.dgvUsuarios.DataSource = Me.UsuariosBindingSource3
        Me.dgvUsuarios.Location = New System.Drawing.Point(52, 97)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.RowHeadersWidth = 51
        Me.dgvUsuarios.RowTemplate.Height = 24
        Me.dgvUsuarios.Size = New System.Drawing.Size(1041, 440)
        Me.dgvUsuarios.TabIndex = 7
        '
        'UsuariosBindingSource3
        '
        Me.UsuariosBindingSource3.DataMember = "Usuarios"
        Me.UsuariosBindingSource3.DataSource = Me.PadeLinkDataSetBindingSource
        '
        'IdusuarioDataGridViewTextBoxColumn
        '
        Me.IdusuarioDataGridViewTextBoxColumn.DataPropertyName = "id_usuario"
        Me.IdusuarioDataGridViewTextBoxColumn.HeaderText = "id_usuario"
        Me.IdusuarioDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.IdusuarioDataGridViewTextBoxColumn.Name = "IdusuarioDataGridViewTextBoxColumn"
        Me.IdusuarioDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdusuarioDataGridViewTextBoxColumn.Width = 125
        '
        'NombreusuarioDataGridViewTextBoxColumn
        '
        Me.NombreusuarioDataGridViewTextBoxColumn.DataPropertyName = "nombre_usuario"
        Me.NombreusuarioDataGridViewTextBoxColumn.HeaderText = "nombre_usuario"
        Me.NombreusuarioDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.NombreusuarioDataGridViewTextBoxColumn.Name = "NombreusuarioDataGridViewTextBoxColumn"
        Me.NombreusuarioDataGridViewTextBoxColumn.Width = 125
        '
        'ContraseñaDataGridViewTextBoxColumn
        '
        Me.ContraseñaDataGridViewTextBoxColumn.DataPropertyName = "contraseña"
        Me.ContraseñaDataGridViewTextBoxColumn.HeaderText = "contraseña"
        Me.ContraseñaDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.ContraseñaDataGridViewTextBoxColumn.Name = "ContraseñaDataGridViewTextBoxColumn"
        Me.ContraseñaDataGridViewTextBoxColumn.Width = 125
        '
        'EstadoDataGridViewTextBoxColumn
        '
        Me.EstadoDataGridViewTextBoxColumn.DataPropertyName = "estado"
        Me.EstadoDataGridViewTextBoxColumn.HeaderText = "estado"
        Me.EstadoDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.EstadoDataGridViewTextBoxColumn.Name = "EstadoDataGridViewTextBoxColumn"
        Me.EstadoDataGridViewTextBoxColumn.Width = 125
        '
        'frmListaUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 647)
        Me.Controls.Add(Me.dgvUsuarios)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnCrearUsuario)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmListaUsuarios"
        Me.Text = "frmListaUsuarios"
        CType(Me.PadeLinkDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PadeLinkDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosRolesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosRolesBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosBindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PadeLinkDataSetBindingSource As BindingSource
    Friend WithEvents PadeLinkDataSet As PadeLinkDataSet
    Friend WithEvents Label1 As Label
    Friend WithEvents UsuariosRolesBindingSource As BindingSource
    Friend WithEvents Usuarios_RolesTableAdapter As PadeLinkDataSetTableAdapters.Usuarios_RolesTableAdapter
    Friend WithEvents UsuariosRolesBindingSource1 As BindingSource
    Friend WithEvents UsuariosBindingSource As BindingSource
    Friend WithEvents UsuariosTableAdapter As PadeLinkDataSetTableAdapters.UsuariosTableAdapter
    Friend WithEvents UsuariosBindingSource1 As BindingSource
    Friend WithEvents btnCrearUsuario As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents UsuariosBindingSource2 As BindingSource
    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents IdusuarioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombreusuarioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ContraseñaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EstadoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UsuariosBindingSource3 As BindingSource
End Class
