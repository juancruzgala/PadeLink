Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class busqueda_fiscal

    Private Sub busqueda_fiscal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Búsqueda (Fiscal)"
        Me.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)

        cboTorneo.DropDownStyle = ComboBoxStyle.DropDownList
        txtDni.MaxLength = 9
        txtNuevoDni.MaxLength = 9

        CargarTorneos()
        CargarCategorias()
        dgvResultados.AutoGenerateColumns = True
        dgvResultados.AllowUserToAddRows = False
        dgvResultados.ReadOnly = True
        dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvResultados.MultiSelect = False
    End Sub

    Private Sub CargarTorneos()
        Dim dt = RepositorioFiscal.ObtenerTorneos()
        ' Insertar "Todos" al principio
        Dim row As DataRow = dt.NewRow()
        row("id_torneo") = 0
        row("nombre_torneo") = "Todos"
        dt.Rows.InsertAt(row, 0)

        cboTorneo.DataSource = dt
        cboTorneo.DisplayMember = "nombre_torneo"
        cboTorneo.ValueMember = "id_torneo"
        cboTorneo.SelectedIndex = 0
    End Sub
    Private Sub CargarCategorias()
        Dim dt = RepositorioFiscal.ObtenerCategorias()

        cboCategoria.DataSource = dt
        cboCategoria.DisplayMember = "nombre_categoria"
        cboCategoria.ValueMember = "id_categoria"

        cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim dni As String = txtDni.Text.Trim()
        Dim nombre As String = txtNombre.Text.Trim()

        If dni = "" AndAlso nombre = "" Then
            MessageBox.Show("Ingresá DNI o Nombre para buscar.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dni <> "" Then
            Dim re As New System.Text.RegularExpressions.Regex("^\d{7,9}$")
            If Not re.IsMatch(dni) Then
                MessageBox.Show("DNI inválido (7 a 9 dígitos).", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Dim idTorneoSel As Integer = CInt(cboTorneo.SelectedValue)
        Dim filtroTorneo As Integer? = If(idTorneoSel > 0, idTorneoSel, CType(Nothing, Integer?))

        Dim dt = RepositorioFiscal.BuscarJugador(dni, nombre, filtroTorneo)
        dgvResultados.AutoGenerateColumns = True
        dgvResultados.DataSource = dt

        If dt.Rows.Count = 0 Then
            MessageBox.Show("El jugador existe pero no tiene inscripciones que coincidan con el filtro.", "Sin resultados",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Resaltar categoría no coincidente
        For Each row As DataGridViewRow In dgvResultados.Rows
            Dim coincide = row.Cells("CoincideCategoria")?.Value?.ToString()
            If String.Equals(coincide, "Revisar", StringComparison.OrdinalIgnoreCase) Then
                row.DefaultCellStyle.BackColor = Color.MistyRose
                row.DefaultCellStyle.ForeColor = Color.DarkRed
            End If
        Next
    End Sub


    ' Alta rápida de jugador (Fiscal)
    Private Sub btnAgregarJugador_Click(sender As Object, e As EventArgs) Handles btnAgregarJugador.Click
        Dim nombre = txtNuevoNombre.Text.Trim()
        Dim dni = txtNuevoDni.Text.Trim()
        Dim idCat = CInt(cboCategoria.SelectedValue) ' o leer de combo si tenés tabla Categoria

        If String.IsNullOrWhiteSpace(nombre) OrElse String.IsNullOrWhiteSpace(dni) Then
            MessageBox.Show("Nombre y DNI son obligatorios.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim re As New System.Text.RegularExpressions.Regex("^\d{7,9}$")
        If Not re.IsMatch(dni) Then
            MessageBox.Show("DNI inválido (7 a 9 dígitos).", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            RepositorioFiscal.InsertarJugador(nombre, dni, idCat)
            MessageBox.Show("Jugador agregado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNuevoNombre.Clear()
            txtNuevoDni.Clear()
            cboCategoria.SelectedValue = 1
        Catch ex As SqlException When ex.Number = 2627 OrElse ex.Number = 2601
            MessageBox.Show("Ese DNI ya existe para otro jugador.", "DNI duplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Error al agregar jugador." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Aceptar solo números en los DNI
    Private Sub txtDni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDni.KeyPress, txtNuevoDni.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


End Class
