Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization

Public Class crear_torneo

    Private dtCategorias As DataTable
    Private dtFiscales As DataTable

    ' ===============================
    ' Configuración del DataGridView
    ' ===============================
    Private Sub EnsureGridSetup()
        With dgvDatos
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
            .AutoGenerateColumns = False
        End With

        If dgvDatos.Columns.Count = 0 OrElse
           Not dgvDatos.Columns.Contains("MaximoParejas") OrElse
           Not dgvDatos.Columns.Contains("Categoria") OrElse
           Not dgvDatos.Columns.Contains("PrecioInscripcion") Then

            dgvDatos.Columns.Clear()

            Dim colMax As New DataGridViewTextBoxColumn() With {
                .Name = "MaximoParejas", .HeaderText = "Máximo de Parejas", .Width = 120
            }

            Dim colCat As New DataGridViewComboBoxColumn() With {
                .Name = "Categoria",
                .HeaderText = "Categoría",
                .Width = 160,
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                .FlatStyle = FlatStyle.Flat
            }

            Dim colPrecio As New DataGridViewTextBoxColumn() With {
                .Name = "PrecioInscripcion", .HeaderText = "Precio Inscripción", .Width = 140
            }

            dgvDatos.Columns.AddRange({colMax, colCat, colPrecio})
        End If

        If dtCategorias IsNot Nothing Then
            Dim col As DataGridViewComboBoxColumn = CType(dgvDatos.Columns("Categoria"), DataGridViewComboBoxColumn)
            col.DataSource = dtCategorias
            col.DisplayMember = "nombre_cat"
            col.ValueMember = "id_categoria"
        End If

        If dgvDatos.Rows.Count = 0 Then dgvDatos.Rows.Add()
    End Sub

    ' ===============================
    ' Inicialización
    ' ===============================
    Private Sub crear_torneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarCatalogos()
            EnsureGridSetup()
            txtNombre.Select()
        Catch ex As Exception
            MessageBox.Show("Error al inicializar: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarCatalogos()
        ' Categorías
        Using cn = Conexion.GetConnection(), da As New SqlDataAdapter(
            "SELECT id_categoria, nombre_cat FROM dbo.Categoria ORDER BY nombre_cat;", cn)
            dtCategorias = New DataTable()
            da.Fill(dtCategorias)
        End Using

        ' Fiscales
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

    ' ===============================
    ' Botón Crear
    ' ===============================
    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            EnsureGridSetup()

            If SessionInfo.CurrentUser Is Nothing Then
                MessageBox.Show("No hay sesión activa. Iniciá sesión como canchero.")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtNombre.Text) Then
                MessageBox.Show("Ingresá un nombre para el torneo.")
                txtNombre.Focus()
                Exit Sub
            End If

            If dtpHasta.Value.Date < dtpDesde.Value.Date Then
                MessageBox.Show("La fecha 'Hasta' no puede ser menor que 'Desde'.")
                Exit Sub
            End If

            If dgvDatos.Rows.Count = 0 Then
                MessageBox.Show("Completá los datos de la fila (máximo parejas, categoría, precio).")
                Exit Sub
            End If

            Dim fila As DataGridViewRow = dgvDatos.Rows(0)

            Dim maximoParejas As Integer
            If Not Integer.TryParse(Convert.ToString(fila.Cells("MaximoParejas").Value), maximoParejas) OrElse maximoParejas < 0 Then
                MessageBox.Show("Ingresá un número válido en 'Máximo de Parejas'.")
                Exit Sub
            End If

            If fila.Cells("Categoria").Value Is Nothing Then
                MessageBox.Show("Seleccioná una categoría en la grilla.")
                Exit Sub
            End If
            Dim idCategoria As Integer = CInt(fila.Cells("Categoria").Value)

            Dim precioInscripcion As Decimal
            If Not Decimal.TryParse(Convert.ToString(fila.Cells("PrecioInscripcion").Value),
                NumberStyles.Any, CultureInfo.CurrentCulture, precioInscripcion) OrElse precioInscripcion < 0D Then
                MessageBox.Show("Ingresá un precio válido (≥ 0).")
                Exit Sub
            End If

            If cboFiscal.SelectedIndex = -1 Then
                MessageBox.Show("Seleccioná el Fiscal.")
                Exit Sub
            End If

            ' --- Crear objeto Torneo ---
            Dim nuevo As New Torneo With {
                .nombre_torneo = txtNombre.Text.Trim(),
                .hora_inicio = dtphoraInicio.Value,
                .fecha = dtpDesde.Value.Date,
                .fecha_hasta = dtpHasta.Value.Date,
                .id_categoria = idCategoria,
                .id_canchero = SessionInfo.id_usuario,  ' canchero de la sesión
                .id_fiscal = CInt(cboFiscal.SelectedValue),
                .max_parejas = maximoParejas,
                .precio_inscripcion = precioInscripcion
            }

            Dim idGen = InsertarTorneo(nuevo)

            MessageBox.Show($"Torneo creado correctamente (ID {idGen}).", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarFormulario()

        Catch ex As Exception
            MessageBox.Show("Error al crear el torneo: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===============================
    ' Guardar en BD
    ' ===============================
    Private Function InsertarTorneo(t As Torneo) As Integer
        Const sql As String =
"INSERT INTO dbo.Torneos
 (nombre_torneo, fecha, fecha_hasta, hora_inicio, id_categoria, id_canchero, id_fiscal, max_parejas, monto_inscripcion)
 VALUES
 (@nombre, @fecha, @fechahasta, @hora, @idcat, @idcanchero, @idfiscal, @maxparejas, @monto_inscripcion);
 SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = t.nombre_torneo
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = t.fecha
            cmd.Parameters.Add("@fechahasta", SqlDbType.Date).Value = t.fecha_hasta
            cmd.Parameters.Add("@hora", SqlDbType.Time).Value = t.hora_inicio.TimeOfDay
            cmd.Parameters.Add("@idcat", SqlDbType.Int).Value = t.id_categoria
            cmd.Parameters.Add("@idcanchero", SqlDbType.Int).Value = t.id_canchero
            cmd.Parameters.Add("@idfiscal", SqlDbType.Int).Value = t.id_fiscal
            cmd.Parameters.Add("@maxparejas", SqlDbType.Int).Value = t.max_parejas
            cmd.Parameters.AddWithValue("@monto_inscripcion", SqlDbType.Decimal).Value = t.precio_inscripcion

            cn.Open()
            Return CInt(cmd.ExecuteScalar())
        End Using
    End Function

    ' ===============================
    ' Helpers
    ' ===============================
    Private Sub LimpiarFormulario()
        txtNombre.Clear()
        dtpDesde.Value = Date.Today
        dtpHasta.Value = Date.Today
        dtphoraInicio.Value = Date.Now
        dgvDatos.Rows.Clear()
        EnsureGridSetup()
        cboFiscal.SelectedIndex = -1
        txtNombre.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim l As New lista_torneos() With {.Modo = ModoLista.GestionJugadores}
        FrmShell.ShowInShell(l)
    End Sub

End Class