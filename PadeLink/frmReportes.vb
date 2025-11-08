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
        ' ===== ESTILO BASE =====
        Me.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)
        Me.Text = "Reportes"
        Me.BackColor = Color.FromArgb(240, 243, 247)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.TopLevel = False
        Me.Dock = DockStyle.Fill
        Me.Padding = New Padding(10, 5, 10, 5)

        ' ===== TÍTULO =====
        Dim lblTitulo As New Label With {
        .Text = Me.Text,
        .Font = New Font("Bahnschrift SemiBold", 16, FontStyle.Regular),
        .ForeColor = Color.FromArgb(40, 40, 40),
        .AutoSize = False,
        .TextAlign = ContentAlignment.MiddleLeft,
        .Dock = DockStyle.Top,
        .Height = 50,
        .Padding = New Padding(20, 0, 0, 0)
    }

        ' ===== DATAGRID =====
        dgv = New DataGridView With {
        .Dock = DockStyle.Fill,
        .ReadOnly = True,
        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        .AllowUserToAddRows = False,
        .AllowUserToDeleteRows = False,
        .BackgroundColor = Color.FromArgb(248, 249, 250),
        .BorderStyle = BorderStyle.None
    }

        ' ===== LABEL TOTAL =====
        lblTotal = New Label With {
        .Text = "",
        .Dock = DockStyle.Bottom,
        .Height = 30,
        .TextAlign = ContentAlignment.MiddleRight,
        .Padding = New Padding(0, 0, 20, 0),
        .Font = New Font("Bahnschrift SemiBold", 10.0F)
    }

        ' ===== SELECCIÓN DE ROL =====
        Dim rol As String = If(SessionInfo.CurrentRole, String.Empty)

        Select Case rol
            Case "Administrador"
                ArmarFiltrosAdmin()
                CargarAdmin()

            Case "Canchero"
                Me.Text = "📅 Calendario de torneos"
                lblTitulo.Text = Me.Text
                CargarCanchero()

            Case "Fiscal"
                Me.Text = "⚖️ Avance de torneos activos"
                lblTitulo.Text = Me.Text
                CargarFiscal()

            Case Else
                MessageBox.Show("No hay reportes configurados para tu rol.", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
        End Select

        ' ===== ORDEN FINAL DE CONTROLES (FIX VISUAL) =====
        Me.Controls.Clear()

        ' Agregar en orden vertical correcto
        Me.Controls.Add(dgv)          ' fill ocupa el espacio disponible
        Me.Controls.Add(lblTotal)     ' abajo
        If pnlFiltros IsNot Nothing Then Me.Controls.Add(pnlFiltros) ' arriba (si existe)
        Me.Controls.Add(lblTitulo)    ' arriba del todo

        ' Forzar nuevo layout
        Me.ResumeLayout()
        Me.PerformLayout()
    End Sub



    ' ====================== ADMIN ======================
    Private Sub ArmarFiltrosAdmin()
        pnlFiltros = New FlowLayoutPanel With {
            .Dock = DockStyle.Top,
            .Height = 50,
            .Padding = New Padding(10),
            .BackColor = Color.FromArgb(230, 235, 240)
        }

        Dim lblD As New Label With {.AutoSize = True, .Text = "Desde:", .Margin = New Padding(5, 10, 5, 0)}
        Dim lblH As New Label With {.AutoSize = True, .Text = "Hasta:", .Margin = New Padding(15, 10, 5, 0)}
        dtDesde = New DateTimePicker With {.Name = "dtDesde", .Value = Date.Today.AddMonths(-1)}
        dtHasta = New DateTimePicker With {.Name = "dtHasta", .Value = Date.Today}

        btnFiltrar = New Button With {
            .Text = "Filtrar",
            .AutoSize = True,
            .BackColor = Color.FromArgb(52, 152, 219),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Margin = New Padding(15, 5, 0, 0)
        }
        btnFiltrar.FlatAppearance.BorderSize = 0
        AddHandler btnFiltrar.Click, Sub() CargarAdmin()

        pnlFiltros.Controls.AddRange({lblD, dtDesde, lblH, dtHasta, btnFiltrar})
        Me.Controls.Add(pnlFiltros)
        Me.Controls.SetChildIndex(pnlFiltros, 1) ' lo ubica debajo del título

        Me.Text = "📊 Recaudación (Administrador)"
    End Sub

    Private Sub CargarAdmin()
        Dim dt = RepositorioReportes.Admin_Recaudacion(dtDesde.Value, dtHasta.Value)
        dgv.DataSource = dt
        FormatearColumnaSiExiste("Recaudado", "C2")
        FormatearColumnaSiExiste("Fecha", "d")

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
