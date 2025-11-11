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

        ' ===== TÍTULO CON FONDO =====
        Dim lblTitulo As New Label With {
        .Text = Me.Text,
        .Font = New Font("Bahnschrift SemiBold", 16, FontStyle.Regular),
        .ForeColor = Color.White,
        .BackColor = Color.FromArgb(52, 73, 94),
        .AutoSize = False,
        .TextAlign = ContentAlignment.BottomCenter,
        .Dock = DockStyle.Top,
        .Height = 100,
        .Padding = New Padding(20, 0, 0, 0)
    }

        lblTitulo.Margin = New Padding(0, 50, 0, 0)


        ' ===== PANEL CONTENEDOR PARA GRID =====
        Dim pnlContenedorGrid As New Panel With {
        .Dock = DockStyle.Fill,
        .Padding = New Padding(10, 35, 10, 10), ' <-- el "25" baja el grid visualmente
        .BackColor = Color.Transparent
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

        ' Estilo visual de encabezados
        With dgv.ColumnHeadersDefaultCellStyle
            .BackColor = Color.FromArgb(230, 235, 240)
            .ForeColor = Color.Black
            .Font = New Font("Bahnschrift SemiBold", 10, FontStyle.Regular)
        End With
        dgv.EnableHeadersVisualStyles = False

        pnlContenedorGrid.Controls.Add(dgv)

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
        ' ===== ORDEN FINAL DE CONTROLES =====
        Me.Controls.Clear()
        Me.Controls.Add(pnlContenedorGrid)
        Me.Controls.Add(lblTotal)
        If pnlFiltros IsNot Nothing Then Me.Controls.Add(pnlFiltros)
        Me.Controls.Add(lblTitulo)

        ' ===== BOTÓN VOLVER (DEBE IR DESPUÉS DE AGREGAR LOS DEMÁS CONTROLES) =====
        Dim btnVolver As New Button With {
            .Text = "Volver",
            .Size = New Size(120, 30),
            .BackColor = Color.FromArgb(52, 73, 94),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Bahnschrift", 10.0F, FontStyle.Bold),
            .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left,
            .Location = New Point(20, Me.ClientSize.Height - 60)
        }

        btnVolver.FlatAppearance.BorderSize = 0

        AddHandler btnVolver.Click,
    Sub()
        FrmShell.ShowInShell(New frmBienvenida())
    End Sub

        Me.Controls.Add(btnVolver)
        btnVolver.BringToFront()

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
        Me.Controls.SetChildIndex(pnlFiltros, 1)

        Me.Text = "📊 Recaudación (Administrador)"
    End Sub


    Private Sub CargarAdmin()
        Dim dt = RepositorioReportes.Admin_Recaudacion(dtDesde.Value, dtHasta.Value)
        dgv.DataSource = dt
        FormatearColumnaSiExiste("Monto", "C2")
        FormatearColumnaSiExiste("Fecha", "d")

        Dim total As Decimal = 0D
        If dt.Columns.Contains("Monto") Then
            For Each r As DataRow In dt.Rows
                If Not IsDBNull(r("Monto")) Then total += CDec(r("Monto"))
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

        ' === Esperar a que las columnas estén creadas antes de modificarlas ===
        dgv.AutoGenerateColumns = True
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.Refresh()

        ' === Formatear columnas ===
        FormatearColumnaSiExiste("Fecha", "d")

        ' === Eliminar columnas que no queremos mostrar ===
        If dgv.Columns.Contains("PartidosJugados") Then
            dgv.Columns.Remove("PartidosJugados")
        End If
        If dgv.Columns.Contains("Porcentaje") Then
            dgv.Columns.Remove("Porcentaje")
        End If

        ' === Reacomodar el ancho de las columnas restantes ===
        For Each col As DataGridViewColumn In dgv.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next

        ' Distribuir pesos manualmente para que se vea equilibrado
        If dgv.Columns.Contains("Torneo") Then dgv.Columns("Torneo").FillWeight = 40
        If dgv.Columns.Contains("Fecha") Then dgv.Columns("Fecha").FillWeight = 25
        If dgv.Columns.Contains("Parejas") Then dgv.Columns("Parejas").FillWeight = 20
        If dgv.Columns.Contains("PartidosEsperados") Then dgv.Columns("PartidosEsperados").FillWeight = 15

        ' === Decoración de filas ===
        For Each gr As DataGridViewRow In dgv.Rows
            gr.DefaultCellStyle.BackColor = Color.MintCream
        Next

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
