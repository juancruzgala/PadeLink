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
        Me.IdusuarioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreusuarioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContraseñaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuariosBindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlBotones = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.PadeLinkDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PadeLinkDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosRolesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosRolesBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuariosBindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
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
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1319, 132)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Lista de Usuarios"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
        Me.btnCrearUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCrearUsuario.AutoSize = True
        Me.btnCrearUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrearUsuario.Location = New System.Drawing.Point(243, 20)
        Me.btnCrearUsuario.Margin = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.btnCrearUsuario.Name = "btnCrearUsuario"
        Me.btnCrearUsuario.Size = New System.Drawing.Size(173, 49)
        Me.btnCrearUsuario.TabIndex = 5
        Me.btnCrearUsuario.Text = "Crear Usuario"
        Me.btnCrearUsuario.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.AutoSize = True
        Me.btnSalir.BackColor = System.Drawing.Color.MistyRose
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Location = New System.Drawing.Point(40, 20)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(163, 54)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'UsuariosBindingSource2
        '
        Me.UsuariosBindingSource2.DataMember = "Usuarios"
        Me.UsuariosBindingSource2.DataSource = Me.PadeLinkDataSetBindingSource
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AutoGenerateColumns = False
        Me.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdusuarioDataGridViewTextBoxColumn, Me.NombreusuarioDataGridViewTextBoxColumn, Me.ContraseñaDataGridViewTextBoxColumn, Me.EstadoDataGridViewTextBoxColumn})
        Me.dgvUsuarios.DataSource = Me.UsuariosBindingSource3
        Me.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsuarios.Location = New System.Drawing.Point(3, 136)
        Me.dgvUsuarios.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.RowHeadersWidth = 51
        Me.dgvUsuarios.RowTemplate.Height = 24
        Me.dgvUsuarios.Size = New System.Drawing.Size(1319, 608)
        Me.dgvUsuarios.TabIndex = 7
        '
        'IdusuarioDataGridViewTextBoxColumn
        '
        Me.IdusuarioDataGridViewTextBoxColumn.DataPropertyName = "id_usuario"
        Me.IdusuarioDataGridViewTextBoxColumn.HeaderText = "id_usuario"
        Me.IdusuarioDataGridViewTextBoxColumn.MinimumWidth = 8
        Me.IdusuarioDataGridViewTextBoxColumn.Name = "IdusuarioDataGridViewTextBoxColumn"
        Me.IdusuarioDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NombreusuarioDataGridViewTextBoxColumn
        '
        Me.NombreusuarioDataGridViewTextBoxColumn.DataPropertyName = "nombre_usuario"
        Me.NombreusuarioDataGridViewTextBoxColumn.HeaderText = "nombre_usuario"
        Me.NombreusuarioDataGridViewTextBoxColumn.MinimumWidth = 8
        Me.NombreusuarioDataGridViewTextBoxColumn.Name = "NombreusuarioDataGridViewTextBoxColumn"
        '
        'ContraseñaDataGridViewTextBoxColumn
        '
        Me.ContraseñaDataGridViewTextBoxColumn.DataPropertyName = "contraseña"
        Me.ContraseñaDataGridViewTextBoxColumn.HeaderText = "contraseña"
        Me.ContraseñaDataGridViewTextBoxColumn.MinimumWidth = 8
        Me.ContraseñaDataGridViewTextBoxColumn.Name = "ContraseñaDataGridViewTextBoxColumn"
        '
        'EstadoDataGridViewTextBoxColumn
        '
        Me.EstadoDataGridViewTextBoxColumn.DataPropertyName = "estado"
        Me.EstadoDataGridViewTextBoxColumn.HeaderText = "estado"
        Me.EstadoDataGridViewTextBoxColumn.MinimumWidth = 8
        Me.EstadoDataGridViewTextBoxColumn.Name = "EstadoDataGridViewTextBoxColumn"
        '
        'UsuariosBindingSource3
        '
        Me.UsuariosBindingSource3.DataMember = "Usuarios"
        Me.UsuariosBindingSource3.DataSource = Me.PadeLinkDataSetBindingSource
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvUsuarios, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlBotones, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1325, 881)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnSalir)
        Me.pnlBotones.Controls.Add(Me.btnCrearUsuario)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBotones.Location = New System.Drawing.Point(3, 751)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlBotones.Size = New System.Drawing.Size(1319, 127)
        Me.pnlBotones.TabIndex = 4
        Me.pnlBotones.WrapContents = False
        '
        'frmListaUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1325, 881)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmListaUsuarios"
        Me.Text = "Lista de Usuarios"
        CType(Me.PadeLinkDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PadeLinkDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosRolesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosRolesBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuariosBindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents UsuariosBindingSource3 As BindingSource
    Friend WithEvents IdusuarioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombreusuarioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ContraseñaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EstadoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pnlBotones As FlowLayoutPanel
End Class
