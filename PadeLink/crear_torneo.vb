Imports PadeLink
Imports System.Globalization

Public Class crear_torneo

    Private Sub EnsureGridSetup()
        With dgvDatos
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
            .AutoGenerateColumns = False
        End With

        If dgvDatos.Columns.Count <> 3 OrElse
           Not dgvDatos.Columns.Contains("MaximoParejas") OrElse
           Not dgvDatos.Columns.Contains("Categoria") OrElse
           Not dgvDatos.Columns.Contains("PrecioInscripcion") Then

            dgvDatos.Columns.Clear()

            Dim colMax As New DataGridViewTextBoxColumn() With {
                .Name = "MaximoParejas", .HeaderText = "Máximo de Parejas", .Width = 120
            }
            Dim colCat As New DataGridViewTextBoxColumn() With {
                .Name = "Categoria", .HeaderText = "Categoría", .Width = 160
            }
            Dim colPrecio As New DataGridViewTextBoxColumn() With {
                .Name = "PrecioInscripcion", .HeaderText = "Precio Inscripción", .Width = 140
            }
            dgvDatos.Columns.AddRange({colMax, colCat, colPrecio})
        End If

        If dgvDatos.Rows.Count = 0 Then
            dgvDatos.Rows.Add()
        End If
    End Sub

    Private Sub LimpiarFormulario()
        txtNombre.Clear()
        dtpHoraInicio.Value = Date.Now
        dtpDesde.Value = Date.Today
        dtpHasta.Value = Date.Today
        dgvDatos.Rows.Clear()
        EnsureGridSetup()
        txtNombre.Focus()
    End Sub

    Private Sub crear_torneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureGridSetup()
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            EnsureGridSetup()

            If String.IsNullOrWhiteSpace(txtNombre.Text) Then
                MessageBox.Show("Ingresá un nombre para el torneo.")
                txtNombre.Focus()
                Exit Sub
            End If

            If dtpHasta.Value.Date < dtpDesde.Value.Date Then
                MessageBox.Show("La fecha 'Hasta' no puede ser menor que 'Desde'.")
                Exit Sub
            End If

            Dim fila As DataGridViewRow = dgvDatos.Rows(0)

            Dim maximoParejas As Integer = 0
            Integer.TryParse(Convert.ToString(fila.Cells("MaximoParejas").Value), maximoParejas)

            Dim categoria As String = Convert.ToString(fila.Cells("Categoria").Value).Trim()

            Dim precioInscripcion As Decimal = 0D
            Decimal.TryParse(
                Convert.ToString(fila.Cells("PrecioInscripcion").Value),
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                precioInscripcion
            )

            If maximoParejas <= 0 Then
                MessageBox.Show("Ingresá un número válido en 'Máximo de Parejas'.")
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(categoria) Then
                MessageBox.Show("Ingresá una categoría.")
                Exit Sub
            End If
            If precioInscripcion < 0D Then
                MessageBox.Show("Ingresá un precio válido (>= 0).")
                Exit Sub
            End If


            Dim nuevo As New Torneo With {
                .Nombre = txtNombre.Text.Trim(),
                .HoraInicio = dtpHoraInicio.Value,
                .FechaDesde = dtpDesde.Value.Date,
                .FechaHasta = dtpHasta.Value.Date,
                .MaxParejas = maximoParejas,
                .Categoria = categoria,
                .PrecioInscripcion = precioInscripcion
            }


            RepositorioTorneos.AgregarTorneo(nuevo)


            MessageBox.Show("Torneo creado correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarFormulario()



        Catch ex As Exception
            MessageBox.Show("Error al crear el torneo: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Dim l As New lista_torneos() With {.Modo = ModoLista.GestionJugadores}
        FrmShell.ShowInShell(l)
    End Sub

End Class