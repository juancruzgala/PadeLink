Imports System.ComponentModel
Imports System.Drawing

Public Class drop_torneo

    Private ReadOnly _torneo As Torneo
    Private _zonas As List(Of Zona)

    Public Sub New(t As Torneo)
        InitializeComponent()
        _torneo = t
    End Sub

    Private Sub drop_torneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.AutoSize = False
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Height = 36
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        lblTitulo.Font = New Font("Bahnschrift", 14.0F, FontStyle.Bold)
        lblTitulo.Text = "Drop · " & _torneo.Nombre


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
        ' Genera zonas
        _zonas = DropGenerator.GenerarZonas(_torneo)

        '
        tcZonas.SuspendLayout()
        tcZonas.TabPages.Clear()

        For Each z As Zona In _zonas
            Dim tab As New TabPage("Zona " & z.Nombre)

            Dim panel As New TableLayoutPanel With {
                .Dock = DockStyle.Fill,
                .RowCount = 2,
                .ColumnCount = 1
            }
            panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 160)) ' arriba: parejas
            panel.RowStyles.Add(New RowStyle(SizeType.Percent, 100))   ' abajo: partidos

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

            Dim dgvPartidos As New DataGridView With {.Dock = DockStyle.Fill}
            PrepararGridPartidos(dgvPartidos)
            dgvPartidos.DataSource = New BindingList(Of Partido)(z.Partidos)

            panel.Controls.Add(dgvParejas, 0, 0)
            panel.Controls.Add(dgvPartidos, 0, 1)

            tab.Controls.Add(panel)
            tcZonas.TabPages.Add(tab)
        Next

        If tcZonas.TabPages.Count > 0 Then
            tcZonas.SelectedIndex = 0
        End If

        tcZonas.ResumeLayout()
    End Sub

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
            .ReadOnly = False                     ' El canchero completa estos campos
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoGenerateColumns = False
            .Columns.Clear()
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Numero", .HeaderText = "Partido", .DataPropertyName = "Numero", .ReadOnly = True, .FillWeight = 10
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "A", .HeaderText = "Equipo A", .DataPropertyName = "EquipoA", .ReadOnly = True, .FillWeight = 25
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "B", .HeaderText = "Equipo B", .DataPropertyName = "EquipoB", .ReadOnly = True, .FillWeight = 25
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Dia", .HeaderText = "Día", .DataPropertyName = "Dia", .FillWeight = 10
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Hora", .HeaderText = "Hora", .DataPropertyName = "Hora", .FillWeight = 10
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Complejo", .HeaderText = "Complejo", .DataPropertyName = "Complejo", .FillWeight = 10
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Resultado", .HeaderText = "Resultado", .DataPropertyName = "Resultado", .FillWeight = 10
            })
        End With
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Dim l As New lista_torneos() With {.Modo = ModoLista.GenerarDrop}
        ShellHost.ShowInShell(l)
    End Sub

End Class