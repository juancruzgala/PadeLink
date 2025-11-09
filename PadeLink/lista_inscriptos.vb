Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class lista_inscriptos
    Private ReadOnly _torneo As Torneo
    Private _binding As BindingList(Of ParejaTorneo)

    Public Sub New(t As Torneo)
        InitializeComponent()
        _torneo = t
        HabilitarDobleBuffer(dgvInscriptos)
    End Sub

    Private Sub lista_inscriptos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepararTitulo()
        ConfigurarGrid()
        Render()
        AsegurarTextoBotones()
    End Sub

    Private Sub PrepararTitulo()
        Panel1.BackColor = Color.FromArgb(54, 88, 138)
        Dim nombre = If(_torneo Is Nothing, "(sin torneo)", _torneo.nombre_torneo)
        lblTitulo.Text = $"📋 Lista de Inscriptos · {nombre}"
    End Sub

    Private Sub ConfigurarGrid()
        With dgvInscriptos
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

            ' Estilo general visual
            .BackgroundColor = Color.FromArgb(245, 247, 250)
            .BorderStyle = BorderStyle.None
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 88, 138)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Bahnschrift SemiBold", 10.5!)
            .DefaultCellStyle.Font = New Font("Bahnschrift", 10.0!)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 250)
            .GridColor = Color.FromArgb(220, 230, 245)
        End With

        ' === Definición de columnas ===
        dgvInscriptos.Columns.Clear()

        Dim cPareja As New DataGridViewTextBoxColumn() With {
            .Name = "Parejas",
            .HeaderText = "Parejas",
            .DataPropertyName = "Pareja",
            .FillWeight = 60,
            .MinimumWidth = 220
        }

        Dim cEstado As New DataGridViewTextBoxColumn() With {
            .Name = "Estado",
            .HeaderText = "Estado de Pago",
            .DataPropertyName = "SeniaOPago",
            .FillWeight = 25,
            .MinimumWidth = 120
        }

        Dim cBtnEditar As New DataGridViewButtonColumn() With {
            .Name = "AccionEditar",
            .HeaderText = "Editar",
            .Text = "Editar",
            .UseColumnTextForButtonValue = True,
            .FillWeight = 7.5F,
            .MinimumWidth = 90
        }

        Dim cBtnEliminar As New DataGridViewButtonColumn() With {
            .Name = "AccionEliminar",
            .HeaderText = "Eliminar",
            .Text = "Eliminar",
            .UseColumnTextForButtonValue = True,
            .FillWeight = 7.5F,
            .MinimumWidth = 90
        }

        dgvInscriptos.Columns.AddRange({cPareja, cEstado, cBtnEditar, cBtnEliminar})
    End Sub

    Private Sub Render()
        Dim datos As List(Of ParejaTorneo)
        If _torneo Is Nothing Then
            datos = New List(Of ParejaTorneo)()
        Else
            datos = RepositorioParejas.Listar(_torneo)
        End If
        _binding = New BindingList(Of ParejaTorneo)(datos)
        dgvInscriptos.DataSource = _binding
    End Sub

    Private Sub AsegurarTextoBotones()
        For Each col As DataGridViewColumn In dgvInscriptos.Columns
            Dim btnCol = TryCast(col, DataGridViewButtonColumn)
            If btnCol Is Nothing Then Continue For
            If btnCol.Name.ToLower().Contains("editar") Then
                btnCol.Text = "Editar"
            ElseIf btnCol.Name.ToLower().Contains("eliminar") Then
                btnCol.Text = "Eliminar"
            End If
            btnCol.UseColumnTextForButtonValue = True
            btnCol.DataPropertyName = Nothing
        Next
    End Sub

    Private Sub dgvInscriptos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInscriptos.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim colName = dgvInscriptos.Columns(e.ColumnIndex).Name
        If colName <> "AccionEditar" AndAlso colName <> "AccionEliminar" Then Return

        Dim p = TryCast(dgvInscriptos.Rows(e.RowIndex).DataBoundItem, ParejaTorneo)
        If p Is Nothing Then Return

        Select Case colName
            Case "AccionEditar"
                FrmShell.ShowInShell(New editar_pareja(_torneo, p))

            Case "AccionEliminar"
                If MessageBox.Show($"¿Eliminar a {p.Jugador1} / {p.Jugador2}?",
                                   "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RepositorioParejas.Eliminar(_torneo, p)
                    _binding.Remove(p)
                End If
        End Select
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        ' Vuelve al formulario de inscripción del mismo torneo
        FrmShell.ShowInShell(New agregar_jugadores(_torneo))
    End Sub

    Private Sub HabilitarDobleBuffer(grid As DataGridView)
        Try
            Dim t As Type = GetType(DataGridView)
            Dim pi = t.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
            If pi IsNot Nothing Then pi.SetValue(grid, True, Nothing)
        Catch
        End Try
    End Sub
End Class
