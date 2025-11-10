Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient

' Modo
Public Enum ModoLista
    EditarTorneo
    GestionJugadores
    VerInscriptosFiscal
End Enum

Partial Public Class lista_torneos
    Public Property Modo As ModoLista = ModoLista.GestionJugadores

    ' Cache de categorías (id -> nombre)
    Private _categorias As Dictionary(Of Integer, String)

    Private Sub lista_torneos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AplicarTituloPorModo()
        CargarCategorias()
        RenderTorneos()
    End Sub

    Private Sub lista_torneos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        RenderTorneos()
    End Sub

    Private Sub AplicarTituloPorModo()
        Select Case Modo
            Case ModoLista.EditarTorneo
                Me.Text = "Lista de torneos (modo: Editar)"
            Case ModoLista.VerInscriptosFiscal
                Me.Text = "Lista de torneos (modo: Fiscal)"
            Case Else
                Me.Text = "Lista de torneos (modo: Gestionar jugadores)"
        End Select
    End Sub

    Private Sub CargarCategorias()
        If _categorias IsNot Nothing Then Return
        _categorias = New Dictionary(Of Integer, String)

        Const sql As String = "SELECT id_categoria, nombre_cat FROM dbo.Categoria ORDER BY nombre_cat;"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cn.Open()
            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    _categorias(rd.GetInt32(0)) = rd.GetString(1)
                End While
            End Using
        End Using
    End Sub

    Private Function NombreCategoria(idCat As Integer) As String
        If _categorias Is Nothing Then CargarCategorias()
        Dim nombre As String = Nothing
        If _categorias?.TryGetValue(idCat, nombre) Then
            Return nombre
        End If
        Return $"Cat {idCat}"
    End Function

    Public Sub RenderTorneos()
        flpTorneos.SuspendLayout()
        flpTorneos.Controls.Clear()

        Dim lista As List(Of Torneo)
        Try
            lista = RepositorioTorneos.Listar()   ' ← devuelve List(Of Torneo)
        Catch ex As Exception
            MessageBox.Show("No se pudieron cargar los torneos: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lista = New List(Of Torneo)
        End Try

        If lista Is Nothing OrElse lista.Count = 0 Then
            Dim lbl As New Label With {
                .AutoSize = False,
                .Dock = DockStyle.Top,
                .Height = 40,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Font = New Font("Bahnschrift", 11.0F, FontStyle.Italic),
                .Text = "Aún no se han creado torneos."
            }
            flpTorneos.Controls.Add(lbl)
            flpTorneos.ResumeLayout()
            Exit Sub
        End If

        Dim anchoDisponible As Integer = Math.Max(200, flpTorneos.ClientSize.Width - 40)

        For Each t In lista
            Dim nombreCat As String = NombreCategoria(t.id_categoria)

            ' --- CONTENEDOR del botón + estado ---
            Dim panelContenedor As New Panel With {
        .Width = anchoDisponible,
        .Height = 100,
        .BackColor = Color.WhiteSmoke,
        .Margin = New Padding(10, 8, 10, 8)
    }

            ' === BOTÓN PRINCIPAL DEL TORNEO ===
            Dim btn As New Button() With {
        .Width = anchoDisponible - 10,
        .Height = 80,
        .Location = New Point(0, 15),
        .Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular),
        .TextAlign = ContentAlignment.MiddleLeft,
        .Padding = New Padding(12, 8, 12, 8),
        .BackColor = Color.White,
        .FlatStyle = FlatStyle.Flat,
        .Tag = t
    }
            btn.FlatAppearance.BorderColor = Color.LightGray
            btn.FlatAppearance.BorderSize = 1

            btn.Text =
        t.nombre_torneo & Environment.NewLine &
        t.fecha.ToString("dd/MM/yyyy") & " " & t.hora_inicio.ToString("HH:mm") & Environment.NewLine &
        "Categoria: " & nombreCat & "   Parejas: " & t.max_parejas.ToString() & Environment.NewLine &
        "Inscripción: $" & t.precio_inscripcion.ToString("N0")

            AddHandler btn.Click, AddressOf BotonTorneo_Click

            ' === ETIQUETA DE ESTADO ===
            Dim lblEstado As New Label()
            lblEstado.AutoSize = True
            lblEstado.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular)
            lblEstado.Location = New Point(anchoDisponible - 150, -1)

            Select Case t.estado.ToString().Trim().ToLower()
                Case "finalizado"
                    lblEstado.Text = "FINALIZADO"
                    lblEstado.ForeColor = Color.Red
                Case "en curso"
                    lblEstado.Text = "EN CURSO"
                    lblEstado.ForeColor = Color.Green
                Case "programado"
                    lblEstado.Text = "PROGRAMADO"
                    lblEstado.ForeColor = Color.Blue
                Case Else
                    lblEstado.Text = t.estado.ToString()
                    lblEstado.ForeColor = Color.Gray
            End Select

            ' Agregar al contenedor
            panelContenedor.Controls.Add(btn)
            panelContenedor.Controls.Add(lblEstado)
            flpTorneos.Controls.Add(panelContenedor)
        Next


        flpTorneos.ResumeLayout()
    End Sub

    Private Sub BotonTorneo_Click(sender As Object, e As EventArgs)
        Dim t = TryCast(DirectCast(sender, Button).Tag, Torneo)
        If t Is Nothing Then
            MessageBox.Show("No se pudo obtener la información del torneo.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Select Case Me.Modo
            Case ModoLista.EditarTorneo
                FrmShell.ShowInShell(New editar_torneo(t))

            Case ModoLista.GestionJugadores
                FrmShell.ShowInShell(New agregar_jugadores(t))

            Case ModoLista.VerInscriptosFiscal
                FrmShell.ShowInShell(New lista_inscriptos(t))
        End Select
    End Sub

    Private Sub flpTorneos_Paint(sender As Object, e As PaintEventArgs) Handles flpTorneos.Paint
    End Sub
End Class
