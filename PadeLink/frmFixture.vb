Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class FrmFixture

    Private torneoId As Integer
    Private dsFixture As DataSet

    Private Sub FrmFixture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Fixture por Zonas"
        CargarTorneosEnCombo()
    End Sub

    Private Sub CargarTorneosEnCombo()
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand("
SELECT id_torneo, nombre_torneo
FROM dbo.Torneos
ORDER BY fecha DESC, nombre_torneo;", cn)
            cn.Open()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        cboTorneo.DisplayMember = "nombre_torneo"
        cboTorneo.ValueMember = "id_torneo"
        cboTorneo.DataSource = dt
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If cboTorneo.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccioná un torneo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        torneoId = CInt(cboTorneo.SelectedValue)

        Try
            ' 1) Generar en BD
            RepositorioFixture.GenerarFixtureZonas(torneoId)
            ' 2) Cargar para UI
            dsFixture = RepositorioFixture.ObtenerFixtureParaUI(torneoId)
            PintarTabs()
            MessageBox.Show("Fixture generado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al generar fixture." & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PintarTabs()
        tabZonas.TabPages.Clear()
        If dsFixture Is Nothing OrElse dsFixture.Tables.Count = 0 Then Exit Sub

        Dim zonas = dsFixture.Tables("Zonas")
        Dim tabla = dsFixture.Tables("Tabla")
        Dim partidos = dsFixture.Tables("Partidos")

        For Each z As DataRow In zonas.Rows
            Dim idZona = CInt(z("id_zona"))
            Dim nombre = z("nombre_zona").ToString()

            Dim tp As New TabPage("Zona " & nombre)

            Dim sc As New SplitContainer()
            sc.Orientation = Orientation.Horizontal
            sc.Dock = DockStyle.Fill
            sc.SplitterDistance = CInt(sc.Height * 0.55)

            ' tabla posiciones
            Dim dgvTabla As New DataGridView With {
                .Dock = DockStyle.Fill,
                .ReadOnly = True,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            }
            Dim vTabla = tabla.Select("id_zona=" & idZona)
            If vTabla.Length > 0 Then
                dgvTabla.DataSource = vTabla.CopyToDataTable()
            Else
                dgvTabla.DataSource = tabla.Clone()
            End If

            ' partidos
            Dim dgvPartidos As New DataGridView With {
                .Dock = DockStyle.Fill,
                .ReadOnly = True,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            }
            Dim vPart = partidos.Select("id_zona=" & idZona)
            If vPart.Length > 0 Then
                dgvPartidos.DataSource = vPart.CopyToDataTable()
            Else
                dgvPartidos.DataSource = partidos.Clone()
            End If

            sc.Panel1.Controls.Add(dgvTabla)
            sc.Panel2.Controls.Add(dgvPartidos)

            tp.Controls.Add(sc)
            tabZonas.TabPages.Add(tp)
        Next
    End Sub

    ' Refresca el fixture para el torneo indicado y repinta las tabs
    Public Sub PerformRefreshFor(torneoIdObj As Object)
        Dim torneoId As Integer
        If torneoIdObj IsNot Nothing AndAlso Integer.TryParse(torneoIdObj.ToString(), torneoId) = False Then
            torneoId = 0
        End If

        ' Si no vino id válido, intenta usar el seleccionado en el combo (si existe)
        If torneoId <= 0 Then
            Try
                If cboTorneo IsNot Nothing AndAlso cboTorneo.SelectedValue IsNot Nothing Then
                    Integer.TryParse(cboTorneo.SelectedValue.ToString(), torneoId)
                End If
            Catch
                torneoId = 0
            End Try
        End If

        If torneoId <= 0 Then Exit Sub

        Try
            ' Ajustá estos nombres si en tu form se llaman distinto
            dsFixture = RepositorioFixture.ObtenerFixtureParaUI(torneoId)
            PintarTabs()
        Catch ex As Exception
            ' Opcional: log/MsgBox
            ' MessageBox.Show("No se pudo refrescar el fixture: " & ex.Message)
        End Try
    End Sub


    ' ---------------------- Exportar a PDF ----------------------
    Private Sub btnExportarPDF_Click(sender As Object, e As EventArgs) Handles btnExportarPDF.Click
        If dsFixture Is Nothing Then
            MessageBox.Show("Primero generá el fixture.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Title = "Exportar Fixture a PDF"
            sfd.Filter = "PDF (*.pdf)|*.pdf"
            sfd.FileName = $"Fixture_{Date.Now:yyyyMMdd_HHmm}.pdf"
            If sfd.ShowDialog(Me) <> DialogResult.OK Then Exit Sub

            Try
                ExportarFixtureAPdf(sfd.FileName, cboTorneo.Text)
                MessageBox.Show("PDF exportado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("No se pudo exportar el PDF." & Environment.NewLine & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub ExportarFixtureAPdf(path As String, titulo As String)
        Dim zonas = dsFixture.Tables("Zonas")
        Dim tabla = dsFixture.Tables("Tabla")
        Dim partidos = dsFixture.Tables("Partidos")

        Dim doc As New Document(PageSize.A4, 36, 36, 36, 36)
        Using fs = New FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim w = PdfWriter.GetInstance(doc, fs)
            doc.Open()

            Dim fTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)
            Dim fSub = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)
            Dim fN = FontFactory.GetFont(FontFactory.HELVETICA, 10)

            doc.Add(New Paragraph("Fixture de Torneo", fTitulo))
            doc.Add(New Paragraph(titulo, fN))
            doc.Add(New Paragraph("Generado: " & Date.Now.ToString("dd/MM/yyyy HH:mm"), fN))
            doc.Add(New Paragraph(" "))


            For Each z As DataRow In zonas.Rows
                Dim idZona = CInt(z("id_zona"))
                Dim nombre = z("nombre_zona").ToString()

                doc.Add(New Paragraph("Zona " & nombre, fSub))
                doc.Add(New Paragraph(" "))


                ' --- Tabla de posiciones ---
                Dim vTabla = tabla.Select("id_zona=" & idZona)
                Dim pdfTable As New PdfPTable(6) : pdfTable.WidthPercentage = 100
                pdfTable.SetWidths({28, 12, 12, 12, 12, 12}) ' Pareja | PJ | G | P | GF | GC
                AddHeader(pdfTable, {"Pareja", "PJ", "G", "P", "GF", "GC"})

                If vTabla.Length > 0 Then
                    For Each r In vTabla
                        pdfTable.AddCell(New Phrase(r("Pareja").ToString(), fN))
                        pdfTable.AddCell(New Phrase(r("partidos_jugados").ToString(), fN))
                        pdfTable.AddCell(New Phrase(r("ganados").ToString(), fN))
                        pdfTable.AddCell(New Phrase(r("perdidos").ToString(), fN))
                        pdfTable.AddCell(New Phrase(r("games_favor").ToString(), fN))
                        pdfTable.AddCell(New Phrase(r("games_contra").ToString(), fN))
                    Next
                End If

                doc.Add(pdfTable)
                doc.Add(New Paragraph(" "))


                ' --- Lista de partidos ---
                Dim vPart = partidos.Select("id_zona=" & idZona)
                Dim pdfPart As New PdfPTable(5) : pdfPart.WidthPercentage = 100
                pdfPart.SetWidths({30, 30, 10, 10, 20}) ' Pareja1 | Pareja2 | P1 | P2 | Estado
                AddHeader(pdfPart, {"Pareja 1", "Pareja 2", "P1", "P2", "Estado"})
                If vPart.Length > 0 Then
                    For Each r In vPart
                        Dim p1 = $"{r("J1A")} / {r("J1B")}"
                        Dim p2 = $"{r("J2A")} / {r("J2B")}"
                        pdfPart.AddCell(New Phrase(p1, fN))
                        pdfPart.AddCell(New Phrase(p2, fN))
                        pdfPart.AddCell(New Phrase(If(r("puntos_pareja1") Is DBNull.Value, "", r("puntos_pareja1").ToString()), fN))
                        pdfPart.AddCell(New Phrase(If(r("puntos_pareja2") Is DBNull.Value, "", r("puntos_pareja2").ToString()), fN))
                        pdfPart.AddCell(New Phrase(r("estado").ToString(), fN))
                    Next
                End If

                doc.Add(pdfPart)
                doc.NewPage()
            Next

            doc.Close()
        End Using
    End Sub

    Private Sub AddHeader(tbl As PdfPTable, headers As IEnumerable(Of String))
        Dim fH = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)
        For Each h In headers
            Dim cell As New PdfPCell(New Phrase(h, fH))
            cell.BackgroundColor = New BaseColor(230, 230, 230)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tbl.AddCell(cell)
        Next
    End Sub
    Private Sub AbrirCargaDesdeFila(rowIndex As Integer)
        Dim r = dgvPartidos.Rows(rowIndex)
        Dim idPartido As Integer = CInt(r.Cells("id_partido").Value)
        Dim p1 As String = r.Cells("Pareja1").Value.ToString()
        Dim p2 As String = r.Cells("Pareja2").Value.ToString()

        Using f As New frmRegistrarResultadoPartido(idPartido, p1, p2)
            If f.ShowDialog(Me) = DialogResult.OK Then
                PerformRefreshFor(cboTorneo.SelectedValue) ' refresca el fixture
            End If
        End Using
    End Sub

    Private Sub btnRegistrarResultado_Click(sender As Object, e As EventArgs) Handles btnRegistrarResultado.Click
        If dgvPartidos.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccioná un partido.", "Info")
            Return
        End If
        AbrirCargaDesdeFila(dgvPartidos.CurrentRow.Index)
    End Sub


    Private Sub dgvPartidos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartidos.CellDoubleClick
        If e.RowIndex < 0 Then Return
        AbrirCargaDesdeFila(e.RowIndex)
    End Sub


    ' ---------------------- Imprimir (render rápido) ----------------------
    Private bmp As Bitmap

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ' Renderiza el Tab actual a una imagen y lo manda a imprimir (simple y efectivo)
        If tabZonas.TabPages.Count = 0 Then
            MessageBox.Show("No hay fixture para imprimir.", "Info")
            Return
        End If
        Dim tp = tabZonas.SelectedTab
        bmp = New Bitmap(tp.Width, tp.Height)
        tp.DrawToBitmap(bmp, New System.Drawing.Rectangle(System.Drawing.Point.Empty, tp.Size))

        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, AddressOf Pd_PrintPage
        Dim dlg As New PrintDialog() With {.Document = pd}
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            pd.Print()
        End If
    End Sub

    Private Sub Pd_PrintPage(sender As Object, e As PrintPageEventArgs)
        If bmp Is Nothing Then Return
        Dim r = e.MarginBounds
        e.Graphics.DrawImage(bmp, r)
        e.HasMorePages = False
    End Sub

End Class
