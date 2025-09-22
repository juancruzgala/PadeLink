Imports System.Drawing

Public Class editar_torneo

    Private ReadOnly _torneoActual As Torneo

    Public Sub New(t As Torneo)
        InitializeComponent()
        _torneoActual = t
        ConfigurarNumericos()
        CargarDatos()
    End Sub

    Private Sub editar_torneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)
    End Sub

    Private Sub ConfigurarNumericos()

        With nudPrecio
            .Minimum = 0D
            .Maximum = 100000000D
            .DecimalPlaces = 2
            .ThousandsSeparator = True
            .Increment = 100D
        End With

        ' Máximo de parejas
        With nudMaxParejas
            .Minimum = 0
            .Maximum = 512
            .Increment = 1
        End With

    End Sub

    Private Sub CargarDatos()
        If _torneoActual Is Nothing Then Exit Sub

        txtNombre.Text = _torneoActual.Nombre
        dtpHoraInicio.Value = _torneoActual.HoraInicio
        dtpDesde.Value = _torneoActual.FechaDesde
        dtpHasta.Value = _torneoActual.FechaHasta


        nudMaxParejas.Value =
            CDec(Math.Min(Math.Max(CDbl(nudMaxParejas.Minimum),
                                   _torneoActual.MaxParejas),
                          CDbl(nudMaxParejas.Maximum)))

        nudPrecio.Value =
            Math.Min(Math.Max(nudPrecio.Minimum,
                              _torneoActual.PrecioInscripcion),
                     nudPrecio.Maximum)

        cboCategoria.Text = _torneoActual.Categoria
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Validaciones 
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("Ingresá un nombre para el torneo.")
            txtNombre.Focus() : Exit Sub
        End If
        If dtpHasta.Value.Date < dtpDesde.Value.Date Then
            MessageBox.Show("La fecha 'Hasta' no puede ser menor que 'Desde'.")
            Exit Sub
        End If

        _torneoActual.Nombre = txtNombre.Text.Trim()
        _torneoActual.HoraInicio = dtpHoraInicio.Value
        _torneoActual.FechaDesde = dtpDesde.Value.Date
        _torneoActual.FechaHasta = dtpHasta.Value.Date
        _torneoActual.MaxParejas = CInt(nudMaxParejas.Value)
        _torneoActual.Categoria = cboCategoria.Text.Trim()
        _torneoActual.PrecioInscripcion = nudPrecio.Value


        MessageBox.Show("Torneo actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

        FrmShell.ShowInShell(New lista_torneos() With {.Modo = ModoLista.EditarTorneo})
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        FrmShell.ShowInShell(New lista_torneos() With {.Modo = ModoLista.EditarTorneo})
    End Sub

End Class