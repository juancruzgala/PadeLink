Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class editar_torneo

    Private ReadOnly _torneoActual As Torneo
    Private dtCategorias As DataTable

    Public Sub New(t As Torneo)
        InitializeComponent()
        _torneoActual = t
        ConfigurarNumericos()
    End Sub

    Private Sub editar_torneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)
        Try
            CargarCategorias()
            CargarDatos()
        Catch ex As Exception
            MessageBox.Show("Error al inicializar la edición: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '---------------------------
    ' Configuración de controles
    '---------------------------
    Private Sub ConfigurarNumericos()
        With nudPrecio
            .Minimum = 0D
            .Maximum = 100000000D
            .DecimalPlaces = 2
            .ThousandsSeparator = True
            .Increment = 100D
        End With
        With nudMaxParejas
            .Minimum = 0
            .Maximum = 512
            .Increment = 1
        End With
        ' DTP hora
        dtpHoraInicio.Format = DateTimePickerFormat.Time
        dtpHoraInicio.ShowUpDown = True
    End Sub

    Private Sub CargarCategorias()
        Const sql As String = "SELECT id_categoria, nombre_cat FROM dbo.Categoria ORDER BY nombre_cat;"
        Using cn = Conexion.GetConnection(), da As New SqlDataAdapter(sql, cn)
            dtCategorias = New DataTable()
            da.Fill(dtCategorias)
        End Using

        cboCategoria.DataSource = dtCategorias
        cboCategoria.DisplayMember = "nombre_cat"
        cboCategoria.ValueMember = "id_categoria"
        cboCategoria.SelectedIndex = -1
    End Sub

    '---------------------------
    ' Cargar datos del torneo
    '---------------------------
    Private Sub CargarDatos()
        If _torneoActual Is Nothing Then Exit Sub

        txtNombre.Text = _torneoActual.nombre_torneo

        ' hora_inicio es DateTime; lo usamos directo (o solo la hora si lo preferís)
        dtpHoraInicio.Value = If(_torneoActual.hora_inicio = Date.MinValue,
                                 Date.Today.AddHours(9),
                                 _torneoActual.hora_inicio)

        dtpDesde.Value = If(_torneoActual.fecha = Date.MinValue, Date.Today, _torneoActual.fecha)
        dtpHasta.Value = If(_torneoActual.fecha_hasta = Date.MinValue, _torneoActual.fecha, _torneoActual.fecha_hasta)

        ' Números con límites
        Dim mp = Math.Max(CInt(nudMaxParejas.Minimum), Math.Min(CInt(nudMaxParejas.Maximum), _torneoActual.max_parejas))
        nudMaxParejas.Value = mp

        Dim precio = Math.Max(nudPrecio.Minimum, Math.Min(nudPrecio.Maximum, _torneoActual.precio_inscripcion))
        nudPrecio.Value = precio

        ' Categoría por id
        If dtCategorias IsNot Nothing AndAlso dtCategorias.Rows.Count > 0 Then
            cboCategoria.SelectedValue = _torneoActual.id_categoria
        End If
    End Sub

    '---------------------------
    ' Guardar cambios
    '---------------------------
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            ' Validaciones
            If String.IsNullOrWhiteSpace(txtNombre.Text) Then
                MessageBox.Show("Ingresá un nombre para el torneo.")
                txtNombre.Focus() : Exit Sub
            End If
            If dtpHasta.Value.Date < dtpDesde.Value.Date Then
                MessageBox.Show("La fecha 'Hasta' no puede ser menor que 'Desde'.")
                Exit Sub
            End If
            If cboCategoria.SelectedIndex = -1 OrElse cboCategoria.SelectedValue Is Nothing Then
                MessageBox.Show("Seleccioná la categoría.")
                cboCategoria.DroppedDown = True : Exit Sub
            End If

            ' Mapear al modelo snake_case
            _torneoActual.nombre_torneo = txtNombre.Text.Trim()
            _torneoActual.hora_inicio = dtpHoraInicio.Value
            _torneoActual.fecha = dtpDesde.Value.Date
            _torneoActual.fecha_hasta = dtpHasta.Value.Date
            _torneoActual.max_parejas = CInt(nudMaxParejas.Value)
            _torneoActual.precio_inscripcion = nudPrecio.Value
            _torneoActual.id_categoria = CInt(cboCategoria.SelectedValue)

            ' Persistencia
            RepositorioTorneos.Actualizar(_torneoActual)

            MessageBox.Show("Torneo actualizado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            FrmShell.ShowInShell(New lista_torneos() With {.Modo = ModoLista.EditarTorneo})

        Catch exSql As SqlException
            MessageBox.Show("Error SQL al actualizar el torneo: " & exSql.Message, "Error SQL",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el torneo: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        FrmShell.ShowInShell(New lista_torneos() With {.Modo = ModoLista.EditarTorneo})
    End Sub

End Class
