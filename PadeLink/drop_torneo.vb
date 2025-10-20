Imports System.ComponentModel
Imports System.Data
Imports System.Globalization
Imports System.Drawing

Public Class drop_torneo

    Private ReadOnly _torneo As Torneo
    Private _zonas As List(Of Zona)

    ' guardo los bindings de cada grilla de partidos para acceso fácil
    Private _bindingsPartidos As New Dictionary(Of DataGridView, BindingList(Of Partido))()

    Public Sub New(t As Torneo)
        InitializeComponent()
        _torneo = t
    End Sub

    Private Sub drop_torneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Título
        lblTitulo.AutoSize = False
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 36
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        lblTitulo.Font = New Font("Bahnschrift", 14.0F, FontStyle.Bold)
        lblTitulo.Text = "Drop · " & _torneo.nombre_torneo

        ' Tabs
        tcZonas.Dock = DockStyle.Fill
        tcZonas.Multiline = True
        tcZonas.SizeMode = TabSizeMode.Fixed
        tcZonas.ItemSize = New Size(100, 24)

        GenerarYMostrar()
    End Sub

    Private Sub drop_torneo_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblTitulo.Height = 36
    End Sub

    Private Sub GenerarYMostrar()
        Try
            ' 1) Intentar leer zonas/partidos ya generados desde BD
            _zonas = RepositorioZonas.Listar(_torneo)

            ' 2) Si no hay nada, generar y persistir (DropGenerator debe guardar en BD)
            If _zonas Is Nothing OrElse _zonas.Count = 0 Then
                _zonas = DropGenerator.GenerarZonas(_torneo)
            End If

            ' 3) Render
            tcZonas.SuspendLayout()
            tcZonas.TabPages.Clear()
            _bindingsPartidos.Clear()

            For Each z As Zona In _zonas
                Dim tab As New TabPage("Zona " & z.Nombre)

                Dim panel As New TableLayoutPanel With {
                    .Dock = DockStyle.Fill,
                    .RowCount = 2,
                    .ColumnCount = 1
                }
                panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 160)) ' arriba: parejas
                panel.RowStyles.Add(New RowStyle(SizeType.Percent, 100))   ' abajo: partidos

                ' ---- Parejas (solo lectura) ----
                Dim dgvParejas As New DataGridView With {.Dock = DockStyle.Fill}
                PrepararGridParejas(dgvParejas)

                Dim listaParejas As New BindingList(Of ParejaFila)()
                Dim idx As Integer = 1
                For Each p As ParejaTorneo In z.Parejas
                    listaParejas.Add(New ParejaFila With {
                        .Numero = idx,
                        .Jugadores = p.Jugador1 & " / " & p.Jugador2
                    })
                    idx += 1
                Next
                dgvParejas.DataSource = listaParejas

                ' ---- Partidos (editable) ----
                Dim dgvPartidos As New DataGridView With {.Dock = DockStyle.Fill}
                PrepararGridPartidos(dgvPartidos)

                Dim bl As New BindingList(Of Partido)(z.Partidos)
                dgvPartidos.DataSource = bl
                _bindingsPartidos(dgvPartidos) = bl

                ' Eventos de edición/errores para persistir a BD
                AddHandler dgvPartidos.CellEndEdit, AddressOf dgvPartidos_CellEndEdit
                AddHandler dgvPartidos.DataError, AddressOf dgvPartidos_DataError

                panel.Controls.Add(dgvParejas, 0, 0)
                panel.Controls.Add(dgvPartidos, 0, 1)
                tab.Controls.Add(panel)
                tcZonas.TabPages.Add(tab)
            Next

            If tcZonas.TabPages.Count > 0 Then
                tcZonas.SelectedIndex = 0
            End If

            tcZonas.ResumeLayout()

        Catch ex As Exception
            MessageBox.Show("Error al generar/mostrar el Drop: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== MODEL auxiliar solo para mostrar parejas en la grilla superior
    Private Class ParejaFila
        Public Property Numero As Integer
        Public Property Jugadores As String
    End Class

    Private Sub PrepararGridParejas(dgv As DataGridView)
        With dgv
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoGenerateColumns = False
            .Columns.Clear()
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Numero", .HeaderText = "Número", .DataPropertyName = "Numero", .FillWeight = 20
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Jugadores", .HeaderText = "Jugadores", .DataPropertyName = "Jugadores", .FillWeight = 80
            })
        End With
    End Sub

    Private Sub PrepararGridPartidos(dgv As DataGridView)
        With dgv
            .ReadOnly = False                                ' editable por canchero
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoGenerateColumns = False
            .Columns.Clear()
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Numero/Equipos: solo lectura
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Numero", .HeaderText = "Partido", .DataPropertyName = "Numero", .ReadOnly = True, .FillWeight = 8
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "A", .HeaderText = "Equipo A", .DataPropertyName = "EquipoA", .ReadOnly = True, .FillWeight = 24
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "B", .HeaderText = "Equipo B", .DataPropertyName = "EquipoB", .ReadOnly = True, .FillWeight = 24
            })

            ' Editables: Día (fecha), Hora (hh:mm), Complejo, Resultado
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Dia", .HeaderText = "Día", .DataPropertyName = "Dia", .FillWeight = 12,
                .DefaultCellStyle = New DataGridViewCellStyle With {.NullValue = Nothing, .Format = "d"}
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Hora", .HeaderText = "Hora", .DataPropertyName = "Hora", .FillWeight = 10,
                .DefaultCellStyle = New DataGridViewCellStyle With {.NullValue = Nothing}
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Complejo", .HeaderText = "Complejo", .DataPropertyName = "Complejo", .FillWeight = 12
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Resultado", .HeaderText = "Resultado", .DataPropertyName = "Resultado", .FillWeight = 10
            })
        End With
    End Sub

    ' ===== Persistencia de la edición de celdas de partidos
    Private Sub dgvPartidos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        Try
            Dim dgv = DirectCast(sender, DataGridView)
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If Not _bindingsPartidos.ContainsKey(dgv) Then Return

            Dim bl = _bindingsPartidos(dgv)
            If e.RowIndex >= bl.Count Then Return

            Dim partido = bl(e.RowIndex)
            If partido Is Nothing Then Return

            ' Parsear valores editables (Dia, Hora, Complejo, Resultado)
            Dim diaNullable As Date? = Nothing
            Dim horaNullable As TimeSpan? = Nothing
            Dim complejo As String = partido.Complejo
            Dim resultado As String = partido.Resultado

            ' Si el DataSource ya mapea, tomamos del partido; si no, intentamos leer la celda editada
            ' Dia:
            Dim diaCell = dgv.Rows(e.RowIndex).Cells("Dia").Value
            If diaCell IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(diaCell.ToString()) Then
                Dim d As Date
                If Date.TryParse(diaCell.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, d) Then
                    diaNullable = d.Date
                End If
            End If

            ' Hora: "HH:mm"
            Dim horaCell = dgv.Rows(e.RowIndex).Cells("Hora").Value
            If horaCell IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(horaCell.ToString()) Then
                ' Intentar 24h
                Dim ts As TimeSpan
                If TimeSpan.TryParse(horaCell.ToString(), ts) Then
                    horaNullable = ts
                Else
                    ' Fallback: intento parsear tipo 10:30 AM
                    Dim dt As DateTime
                    If DateTime.TryParse(horaCell.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, dt) Then
                        horaNullable = dt.TimeOfDay
                    End If
                End If
            End If

            ' Complejo y Resultado: desde celdas (por si el objeto no se actualizó aún)
            Dim complejoCell = dgv.Rows(e.RowIndex).Cells("Complejo").Value
            If complejoCell IsNot Nothing Then complejo = complejoCell.ToString().Trim()

            Dim resultadoCell = dgv.Rows(e.RowIndex).Cells("Resultado").Value
            If resultadoCell IsNot Nothing Then resultado = resultadoCell.ToString().Trim()

            ' Guardar en BD – requiere id_partido en el objeto Partido
            RepositorioZonas.ActualizarPartidoCampos(
                partido.id_partido,
                diaNullable,
                horaNullable,
                complejo,
                resultado
            )

        Catch ex As Exception
            MessageBox.Show("No se pudo actualizar el partido: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Evitar que un error de formato bloquee la grilla
    Private Sub dgvPartidos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        e.ThrowException = False
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Dim l As New lista_torneos() With {.Modo = ModoLista.GenerarDrop}
        FrmShell.ShowInShell(l)
    End Sub

    ' Si tenías manejadores auto-generados:
    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
    End Sub

End Class
