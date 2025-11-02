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
        ' Opcional: doble buffer para menos parpadeo en listas grandes
        HabilitarDobleBuffer(dgvInscriptos)
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

    '---------------------------
    ' Layout + Título
    '---------------------------
    Private Sub RearmarLayout()
        Me.SuspendLayout()

        Dim tlp As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .RowCount = 4,
            .ColumnCount = 1,
            .Padding = New Padding(12),
            .Margin = New Padding(0)
        }
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 8))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 42))
        tlp.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 8))

        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Bahnschrift", 16.0F, FontStyle.Bold)
        lblTitulo.Text = "Lista de Inscriptos"
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
        Dim nombre = If(_torneo Is Nothing, "(sin torneo)", _torneo.nombre_torneo)
        lblTitulo.Text = $"Lista de Inscriptos · {nombre}"
    End Sub

    '---------------------------
    ' Grid
    '---------------------------
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
        End With


        Dim cPareja As New DataGridViewTextBoxColumn() With {
            .Name = "Parejas",
            .HeaderText = "Parejas",
            .DataPropertyName = "Pareja",     ' <-- bindea a la propiedad calculada
            .FillWeight = 60,
            .MinimumWidth = 220
        }
            cPareja.DataPropertyName = "Pareja"
            Dim cEstado As New DataGridViewTextBoxColumn() With {
            .Name = "Estado",
            .HeaderText = "Estado de Pago",
            .DataPropertyName = "SeniaOPago", ' <-- bindea directo al estado
            .FillWeight = 25,
            .MinimumWidth = 120
        }
            cEstado.DataPropertyName = "SeniaOPago"
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

    '---------------------------
    ' Eventos de la grilla
    '---------------------------
    Private Sub dgvInscriptos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInscriptos.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim colName = dgvInscriptos.Columns(e.ColumnIndex).Name
        If colName <> "AccionEditar" AndAlso colName <> "AccionEliminar" Then Return

        Dim p = TryCast(dgvInscriptos.Rows(e.RowIndex).DataBoundItem, ParejaTorneo)
        If p Is Nothing Then Return

        Select Case colName
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
        ' Tenías ShellHost; en el resto del proyecto usás FrmShell
        FrmShell.ShowInShell(New lista_torneos() With {.Modo = ModoLista.GestionJugadores})
    End Sub

    Private Sub dgvInscriptos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInscriptos.CellContentClick
        ' No lo usamos, pero lo dejamos por si tenés lógica en el diseñador
    End Sub

    '---------------------------
    ' Utilidad: doble buffer
    '---------------------------
    Private Sub HabilitarDobleBuffer(grid As DataGridView)
        Try
            Dim t As Type = GetType(DataGridView)
            Dim pi = t.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
            If pi IsNot Nothing Then pi.SetValue(grid, True, Nothing)
        Catch
            ' Ignorar si no puede
        End Try
    End Sub

End Class
