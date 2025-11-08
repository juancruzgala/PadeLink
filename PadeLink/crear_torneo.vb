Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Drawing
Imports System.Windows.Forms

Public Class crear_torneo
    Inherits Form

    Private dtCategorias As DataTable
    Private dtFiscales As DataTable

    Private main As TableLayoutPanel
    Private lblTitulo As Label

    Private lblNombre, lblFiscal, lblHora, lblDesde, lblHasta As Label
    Private txtNombre As TextBox
    Private cboFiscal As ComboBox
    Private dtpHoraInicio, dtpDesde, dtpHasta As DateTimePicker
    Private dgvDatos As DataGridView
    Private btnCrear, btnCancelar As Button

    Private Sub crear_torneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ===== FORM =====
        Me.FormBorderStyle = FormBorderStyle.None
        Me.TopLevel = False
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.FromArgb(245, 247, 250)
        Me.Font = New Font("Bahnschrift", 10.0F)
        Me.DoubleBuffered = True

        ' ===== LAYOUT PRINCIPAL =====
        main = New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 7,
            .Padding = New Padding(60, 20, 60, 30)
        }
        main.RowStyles.Add(New RowStyle(SizeType.Absolute, 60))   ' título
        main.RowStyles.Add(New RowStyle(SizeType.Absolute, 55))   ' nombre
        main.RowStyles.Add(New RowStyle(SizeType.Absolute, 55))   ' fiscal
        main.RowStyles.Add(New RowStyle(SizeType.Absolute, 55))   ' hora
        main.RowStyles.Add(New RowStyle(SizeType.Absolute, 55))   ' fechas
        main.RowStyles.Add(New RowStyle(SizeType.Percent, 100))   ' grilla
        main.RowStyles.Add(New RowStyle(SizeType.Absolute, 60))   ' botones

        ' ===== TÍTULO =====
        lblTitulo = New Label With {
            .Text = "🏆 Nuevo Torneo",
            .Dock = DockStyle.Fill,
            .Font = New Font("Bahnschrift SemiBold", 18.0F),
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.FromArgb(40, 40, 40)
        }
        main.Controls.Add(lblTitulo, 0, 0)

        ' ===== FILA NOMBRE =====
        Dim panelNombre As New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.LeftToRight,
            .Padding = New Padding(0),
            .WrapContents = False,
            .AutoSize = True,
            .Anchor = AnchorStyles.None
        }

        lblNombre = New Label With {
            .Text = "Nombre:",
            .Font = Me.Font,
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Margin = New Padding(0, 10, 10, 0)
        }
        txtNombre = New TextBox With {
            .Width = 240,
            .Font = Me.Font,
            .BackColor = Color.White
        }

        panelNombre.Controls.Add(lblNombre)
        panelNombre.Controls.Add(txtNombre)
        panelNombre.Anchor = AnchorStyles.None
        main.Controls.Add(panelNombre, 0, 1)

        ' ===== FILA FISCAL =====
        Dim panelFiscal As New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.LeftToRight,
            .Padding = New Padding(0),
            .WrapContents = False,
            .AutoSize = True,
            .Anchor = AnchorStyles.None
        }

        lblFiscal = New Label With {
            .Text = "Fiscal:",
            .Font = Me.Font,
            .AutoSize = True,
            .Margin = New Padding(0, 10, 10, 0)
        }
        cboFiscal = New ComboBox With {
            .Width = 200,
            .Font = Me.Font,
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .BackColor = Color.White
        }

        panelFiscal.Controls.Add(lblFiscal)
        panelFiscal.Controls.Add(cboFiscal)
        main.Controls.Add(panelFiscal, 0, 2)

        ' ===== FILA HORA =====
        Dim panelHora As New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.LeftToRight,
            .AutoSize = True,
            .Anchor = AnchorStyles.None
        }

        lblHora = New Label With {
            .Text = "Hora de Inicio:",
            .Font = Me.Font,
            .AutoSize = True,
            .Margin = New Padding(0, 10, 10, 0)
        }
        dtpHoraInicio = New DateTimePicker With {
            .Format = DateTimePickerFormat.Time,
            .Width = 140,
            .Font = Me.Font
        }

        panelHora.Controls.Add(lblHora)
        panelHora.Controls.Add(dtpHoraInicio)
        main.Controls.Add(panelHora, 0, 3)

        ' ===== FILA FECHAS =====
        Dim panelFechas As New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.LeftToRight,
            .AutoSize = True,
            .Anchor = AnchorStyles.None
        }

        lblDesde = New Label With {
            .Text = "Desde:",
            .Font = Me.Font,
            .AutoSize = True,
            .Margin = New Padding(0, 10, 10, 0)
        }
        dtpDesde = New DateTimePicker With {
            .Format = DateTimePickerFormat.[Short],
            .Width = 120,
            .Font = Me.Font
        }

        lblHasta = New Label With {
            .Text = "Hasta:",
            .Font = Me.Font,
            .AutoSize = True,
            .Margin = New Padding(20, 10, 10, 0) ' Más cerca del “Desde”
        }
        dtpHasta = New DateTimePicker With {
            .Format = DateTimePickerFormat.[Short],
            .Width = 120,
            .Font = Me.Font
        }

        panelFechas.Controls.Add(lblDesde)
        panelFechas.Controls.Add(dtpDesde)
        panelFechas.Controls.Add(lblHasta)
        panelFechas.Controls.Add(dtpHasta)
        main.Controls.Add(panelFechas, 0, 4)

        ' ===== GRILLA =====
        dgvDatos = New DataGridView With {
            .Dock = DockStyle.Fill,
            .BackgroundColor = Color.White,
            .BorderStyle = BorderStyle.None,
            .EnableHeadersVisualStyles = False,
            .ColumnHeadersHeight = 32,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .MultiSelect = False,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .Font = New Font("Bahnschrift", 10)
        }
        dgvDatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243)
        dgvDatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvDatos.ColumnHeadersDefaultCellStyle.Font = New Font("Bahnschrift SemiBold", 10)
        dgvDatos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255)
        dgvDatos.GridColor = Color.LightGray
        main.Controls.Add(dgvDatos, 0, 5)

        ' ===== BOTONES =====
        Dim panelBotones As New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.LeftToRight,
            .Anchor = AnchorStyles.None,
            .AutoSize = True,
            .AutoSizeMode = AutoSizeMode.GrowAndShrink,
            .WrapContents = False,
            .Padding = New Padding(0, 10, 0, 0)
        }

        panelBotones.Anchor = AnchorStyles.None
        panelBotones.AutoSize = True
        panelBotones.AutoSizeMode = AutoSizeMode.GrowAndShrink
        panelBotones.FlowDirection = FlowDirection.LeftToRight
        panelBotones.WrapContents = False
        panelBotones.Padding = New Padding(0, 10, 0, 0)
        panelBotones.Margin = New Padding(0, 0, 0, 0)
        panelBotones.Anchor = AnchorStyles.None
        panelBotones.Anchor = AnchorStyles.Top
        panelBotones.Anchor = AnchorStyles.Bottom
        panelBotones.Anchor = AnchorStyles.Left
        panelBotones.Anchor = AnchorStyles.Right
        panelBotones.Anchor = AnchorStyles.None
        panelBotones.Anchor = AnchorStyles.Top
        panelBotones.Anchor = AnchorStyles.None
        panelBotones.Anchor = AnchorStyles.None
        panelBotones.Anchor = AnchorStyles.Top
        panelBotones.Anchor = AnchorStyles.None
        panelBotones.Anchor = AnchorStyles.None
        panelBotones.Anchor = AnchorStyles.Top
        panelBotones.Anchor = AnchorStyles.None

        ' Centrar los botones dentro del panel
        panelBotones.AutoSize = True
        panelBotones.Anchor = AnchorStyles.None
        panelBotones.AutoSizeMode = AutoSizeMode.GrowAndShrink
        panelBotones.FlowDirection = FlowDirection.LeftToRight
        panelBotones.WrapContents = False
        panelBotones.Padding = New Padding(0, 10, 0, 0)
        panelBotones.Margin = New Padding(0)
        panelBotones.Anchor = AnchorStyles.None


        btnCrear = New Button With {
            .Text = "Crear Torneo",
            .Width = 160,
            .Height = 40,
            .BackColor = Color.FromArgb(46, 204, 113),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        btnCrear.FlatAppearance.BorderSize = 0
        AddHandler btnCrear.Click, AddressOf btnCrear_Click

        btnCancelar = New Button With {
            .Text = "Cancelar",
            .Width = 120,
            .Height = 40,
            .BackColor = Color.Gainsboro,
            .FlatStyle = FlatStyle.Flat
        }
        btnCancelar.FlatAppearance.BorderSize = 0
        AddHandler btnCancelar.Click, AddressOf btnCancelar_Click

        panelBotones.Controls.Add(btnCrear)
        panelBotones.Controls.Add(btnCancelar)
        main.Controls.Add(panelBotones, 0, 6)

        ' ===== ENSAMBLAR =====
        Me.Controls.Add(main)

        ' ===== DATOS =====
        CargarCatalogos()
        EnsureGridSetup()
        txtNombre.Select()
    End Sub

    Private Sub EnsureGridSetup()
        dgvDatos.Columns.Clear()

        Dim colMax As New DataGridViewTextBoxColumn() With {
            .Name = "MaximoParejas", .HeaderText = "Máximo de Parejas", .Width = 120
        }
        Dim colCat As New DataGridViewComboBoxColumn() With {
            .Name = "Categoria", .HeaderText = "Categoría", .Width = 180,
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton, .FlatStyle = FlatStyle.Flat
        }
        Dim colPrecio As New DataGridViewTextBoxColumn() With {
            .Name = "PrecioInscripcion", .HeaderText = "Precio Inscripción", .Width = 140
        }

        dgvDatos.Columns.AddRange({colMax, colCat, colPrecio})

        If dtCategorias IsNot Nothing Then
            Dim col As DataGridViewComboBoxColumn = CType(dgvDatos.Columns("Categoria"), DataGridViewComboBoxColumn)
            col.DataSource = dtCategorias
            col.DisplayMember = "nombre_cat"
            col.ValueMember = "id_categoria"
        End If

        If dgvDatos.Rows.Count = 0 Then dgvDatos.Rows.Add()
    End Sub

    Private Sub CargarCatalogos()
        Using cn = Conexion.GetConnection(), da As New SqlDataAdapter(
            "SELECT id_categoria, nombre_cat FROM dbo.Categoria ORDER BY nombre_cat;", cn)
            dtCategorias = New DataTable()
            da.Fill(dtCategorias)
        End Using

        Using cn = Conexion.GetConnection(),
              cmd As New SqlCommand(
                "SELECT U.id_usuario, U.nombre_usuario
                   FROM dbo.Usuarios U
                   JOIN dbo.Roles R ON R.id_rol = U.id_rol
                  WHERE R.nombre_rol = @rol
                  ORDER BY U.nombre_usuario;", cn)
            cmd.Parameters.Add("@rol", SqlDbType.VarChar, 30).Value = "Fiscal"
            Using da As New SqlDataAdapter(cmd)
                dtFiscales = New DataTable()
                da.Fill(dtFiscales)
            End Using
        End Using
        cboFiscal.DataSource = dtFiscales
        cboFiscal.DisplayMember = "nombre_usuario"
        cboFiscal.ValueMember = "id_usuario"
        cboFiscal.SelectedIndex = -1
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs)
        MessageBox.Show("✅ Torneo creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        FrmShell.ShowInShell(New frmBienvenida())
    End Sub

End Class
