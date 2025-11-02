Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class FrmReportes

    Private dgv As DataGridView
    Private pnlFiltros As FlowLayoutPanel
    Private dtDesde As DateTimePicker
    Private dtHasta As DateTimePicker
    Private btnFiltrar As Button
    Private lblTotal As Label

    Private Sub FrmReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)
        Me.Text = "Reportes"
        Me.WindowState = FormWindowState.Maximized

        dgv = New DataGridView With {
        .Dock = DockStyle.Fill,
        .ReadOnly = True,
        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        .AllowUserToAddRows = False,
        .AllowUserToDeleteRows = False
    }
        Me.Controls.Add(dgv)

        lblTotal = New Label With {
        .Text = "",
        .Dock = DockStyle.Bottom,
        .Height = 26,
        .TextAlign = ContentAlignment.MiddleRight
    }
        Me.Controls.Add(lblTotal)

        ' ---- aquí el fix de la línea problemática ----
        Dim rol As String = If(SessionInfo.CurrentRole, String.Empty)
        Select Case rol
            Case "Administrador"
                ArmarFiltrosAdmin()
                CargarAdmin()

            Case "Canchero"
                Me.Text = "📅 Calendario de torneos"
                CargarCanchero()

            Case "Fiscal"
                Me.Text = "⚖️ Avance de torneos activos"
                CargarFiscal()

            Case Else
                MessageBox.Show("No hay reportes configurados para tu rol.", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
        End Select
    End Sub


    ' ====================== ADMIN ======================
    Private Sub ArmarFiltrosAdmin()
        pnlFiltros = New FlowLayoutPanel With {
            .Dock = DockStyle.Top,
            .Height = 50,
            .Padding = New Padding(10)
        }
        Dim lblD As New Label With {.AutoSize = True, .Text = "Desde:"}
        Dim lblH As New Label With {.AutoSize = True, .Text = "Hasta:"}
        dtDesde = New DateTimePicker With {.Name = "dtDesde", .Value = Date.Today.AddMonths(-1)}
        dtHasta = New DateTimePicker With {.Name = "dtHasta", .Value = Date.Today}
        btnFiltrar = New Button With {.Text = "Filtrar", .AutoSize = True}
        AddHandler btnFiltrar.Click, Sub() CargarAdmin()

        pnlFiltros.Controls.AddRange({lblD, dtDesde, lblH, dtHasta, btnFiltrar})
        Me.Controls.Add(pnlFiltros)
        Me.Text = "📊 Recaudación (Administrador)"
    End Sub

    Private Sub CargarAdmin()
        Dim dt = RepositorioReportes.Admin_Recaudacion(dtDesde.Value, dtHasta.Value)
        dgv.DataSource = dt

        ' formato de columnas si existen
        FormatearColumnaSiExiste("Recaudado", "C2")
        FormatearColumnaSiExiste("Fecha", "d")

        ' totales abajo
        Dim total As Decimal = 0D
        If dt.Columns.Contains("Recaudado") Then
            For Each r As DataRow In dt.Rows
                If Not IsDBNull(r("Recaudado")) Then total += CDec(r("Recaudado"))
            Next
        End If
        lblTotal.Text = $"Total recaudado en rango: {total:C2}"
    End Sub

    ' ====================== CANCHERO ======================
    Private Sub CargarCanchero()
        Dim dt = RepositorioReportes.Canchero_Calendario()
        dgv.DataSource = dt
        FormatearColumnaSiExiste("Fecha", "d")
        lblTotal.Text = $"Torneos en ventana: {dt.Rows.Count}"
    End Sub

    ' ====================== FISCAL ======================
    Private Sub CargarFiscal()
        Dim dt = RepositorioReportes.Fiscal_Avance()
        dgv.DataSource = dt
        FormatearColumnaSiExiste("Fecha", "d")
        FormatearColumnaSiExiste("Porcentaje", "N2")

        ' Resaltar filas con % < 100
        If dt.Columns.Contains("Porcentaje") Then
            For Each gr As DataGridViewRow In dgv.Rows
                Dim p As Decimal = 0
                Decimal.TryParse(Convert.ToString(gr.Cells("Porcentaje").Value), p)
                If p < 100D Then
                    gr.DefaultCellStyle.BackColor = Color.MintCream
                Else
                    gr.DefaultCellStyle.BackColor = Color.Honeydew
                End If
            Next
        End If
        lblTotal.Text = $"Torneos activos: {dt.Rows.Count}"
    End Sub

    ' ====================== helpers ======================
    Private Sub FormatearColumnaSiExiste(nombreCol As String, formato As String)
        If dgv.Columns.Contains(nombreCol) Then
            dgv.Columns(nombreCol).DefaultCellStyle.Format = formato
            dgv.Columns(nombreCol).DefaultCellStyle.Alignment =
                If(formato.StartsWith("C") OrElse formato.StartsWith("N"),
                   DataGridViewContentAlignment.MiddleRight,
                   DataGridViewContentAlignment.MiddleLeft)
        End If
    End Sub

End Class
