Imports System.ComponentModel
Imports System.Drawing

Public Class lista_inscriptos
    Private ReadOnly _torneo As Torneo
    Private _binding As BindingList(Of ParejaTorneo)

    Public Sub New(t As Torneo)
        InitializeComponent()
        _torneo = t
    End Sub

    Private Sub lista_inscriptos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RearmarLayout()
        PrepararTitulo()
        ConfigurarGrid()
        Render()
        AsegurarTextoBotones()
    End Sub


    Private Sub lista_inscriptos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        dgvInscriptos.Refresh()
    End Sub

    Private Sub RearmarLayout()
        Me.SuspendLayout()

        Dim tlp As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .RowCount = 4,
            .ColumnCount = 1,
            .Padding = New Padding(12, 12, 12, 12),
            .Margin = New Padding(0)
        }
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 8))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 42))
        tlp.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 8))

        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Bahnschrift", 16.0F, FontStyle.Bold)
        lblTitulo.Text = If(_torneo Is Nothing, "Inscriptos a ", _torneo.Nombre)
        lblTitulo.Dock = DockStyle.None
        lblTitulo.Height = 50
        lblTitulo.Padding = New Padding(0, 15, 0, 0)
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter

        dgvInscriptos.Dock = DockStyle.Fill
        dgvInscriptos.Margin = New Padding(0, 6, 0, 0)


        Me.Controls.Clear()
        tlp.Controls.Add(New Panel() With {.Dock = DockStyle.Fill}, 0, 0)
        tlp.Controls.Add(lblTitulo, 0, 1)
        tlp.Controls.Add(dgvInscriptos, 0, 2)
        tlp.Controls.Add(New Panel() With {.Dock = DockStyle.Fill}, 0, 3)
        Me.Controls.Add(tlp)

        Me.ResumeLayout()
    End Sub

    Private Sub PrepararTitulo()
        lblTitulo.Text = If(_torneo Is Nothing,
                            "Lista de Inscriptos",
                            $"Lista de Inscriptos · {_torneo.Nombre}")
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
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            .Columns.Clear()
        End With


        Dim cPareja As New DataGridViewTextBoxColumn() With {
            .Name = "Pareja",
            .HeaderText = "Parejas",
            .DataPropertyName = Nothing,
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
            .HeaderText = "Acción",
            .Text = "Editar",
            .UseColumnTextForButtonValue = True,
            .DataPropertyName = Nothing,
            .FillWeight = 7.5F,
            .MinimumWidth = 90
        }
        Dim cBtnEliminar As New DataGridViewButtonColumn() With {
            .Name = "AccionEliminar",
            .HeaderText = "Acción",
            .Text = "Eliminar",
            .UseColumnTextForButtonValue = True,
            .DataPropertyName = Nothing,
            .FillWeight = 7.5F,
            .MinimumWidth = 90
        }

        dgvInscriptos.Columns.AddRange({cPareja, cEstado, cBtnEditar, cBtnEliminar})
    End Sub

    Private Sub Render()
        Dim listaPlain As List(Of ParejaTorneo) = RepositorioParejas.Listar(_torneo)
        _binding = New BindingList(Of ParejaTorneo)(listaPlain)
        dgvInscriptos.DataSource = _binding
    End Sub


    Private Sub dgvInscriptos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvInscriptos.CellFormatting
        If e.RowIndex < 0 Then Return
        If dgvInscriptos.Columns(e.ColumnIndex).Name = "Pareja" Then
            Dim p = TryCast(dgvInscriptos.Rows(e.RowIndex).DataBoundItem, ParejaTorneo)
            If p IsNot Nothing Then
                e.Value = p.Jugador1 & " / " & p.Jugador2
                e.FormattingApplied = True
            End If
        End If
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
        If e.RowIndex <= 0 Then Return
        Dim p = TryCast(dgvInscriptos.Rows(e.RowIndex).DataBoundItem, ParejaTorneo)
        If p Is Nothing Then Return

        Select Case dgvInscriptos.Columns(e.ColumnIndex).Name
            Case "AccionEditar"
                Using f As New editar_pareja(_torneo, p)
                    If f.ShowDialog() = DialogResult.OK Then dgvInscriptos.Refresh()
                End Using

            Case "AccionEliminar"
                If MessageBox.Show($"¿Eliminar a {p.Jugador1} / {p.Jugador2}?",
                                   "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RepositorioParejas.Eliminar(_torneo, p)
                    _binding.Remove(p)
                End If
        End Select
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        ShellHost.ShowInShell(New lista_torneos() With {.Modo = ModoLista.GestionJugadores})
    End Sub
End Class