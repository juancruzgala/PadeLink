Imports System.Data
Imports System.Data.SqlClient

Public Class frmRegistrarResultadoPartido

    ' ===================== Campos =====================
    Private _idPartido As Integer = 0
    Private _idZona As Integer = 0

    ' Preselecciones (opcionales)
    Private ReadOnly _torneoPreseleccionado As Integer? = Nothing
    Private ReadOnly _idPartidoPreseleccionado As Integer? = Nothing

    ' ===================== Constructores =====================
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Abrir con torneo ya elegido (por ejemplo desde lista de torneos)
    Public Sub New(idTorneo As Integer)
        InitializeComponent()
        _torneoPreseleccionado = idTorneo
    End Sub

    ' Abrir directo a un partido (por ejemplo desde el Fixture con doble click)
    Public Sub New(idPartido As Integer, pareja1 As String, pareja2 As String)
        InitializeComponent()
        _idPartidoPreseleccionado = idPartido
        _idPartido = idPartido
        lblEnfrentamiento.Text = $"{pareja1} vs {pareja2}"
        grpCarga.Enabled = True
    End Sub

    ' ===================== Load =====================
    Private Sub frmRegistrarResultadoPartido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Registrar resultado de partido"
        grpCarga.Enabled = False

        CargarTorneos()

        cmbGanador.Items.Clear()
        cmbGanador.Items.AddRange(New Object() {"Pareja 1", "Pareja 2"})

        ' Preseleccionar torneo si vino por constructor
        If _torneoPreseleccionado.HasValue Then
            Try
                cboTorneo.SelectedValue = _torneoPreseleccionado.Value
            Catch
                ' si falla el set por timing, igual al cambiar índice se disparará CargarPartidos
            End Try
        End If

        ' Si vino un partido puntual, dejamos lista la UI
        If _idPartidoPreseleccionado.HasValue Then
            grpCarga.Enabled = True
        End If
    End Sub

    ' ===================== CARGA DE COMBOS / GRILLA =====================
    Private Sub CargarTorneos()
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand("
            SELECT id_torneo, nombre_torneo 
            FROM Torneos
            ORDER BY fecha DESC, nombre_torneo", cn)
            cn.Open()
            dt.Load(cmd.ExecuteReader())
        End Using
        cboTorneo.DisplayMember = "nombre_torneo"
        cboTorneo.ValueMember = "id_torneo"
        cboTorneo.DataSource = dt
        If dt.Rows.Count > 0 Then cboTorneo.SelectedIndex = 0
    End Sub

    Private Sub CargarZonasDelTorneo(torneoId As Integer)
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand("
            SELECT id_zona, nombre_zona
            FROM Zona
            WHERE id_torneo = @t
            ORDER BY nombre_zona", cn)
            cmd.Parameters.Add("@t", SqlDbType.Int).Value = torneoId
            cn.Open()
            dt.Load(cmd.ExecuteReader())
        End Using

        ' Agrego “Todas” arriba
        Dim dtZ As DataTable = dt.Clone()
        Dim row = dtZ.NewRow() : row("id_zona") = 0 : row("nombre_zona") = "Todas"
        dtZ.Rows.Add(row)
        For Each r As DataRow In dt.Rows : dtZ.ImportRow(r) : Next

        cboZona.DisplayMember = "nombre_zona"
        cboZona.ValueMember = "id_zona"
        cboZona.DataSource = dtZ
        cboZona.SelectedIndex = 0
    End Sub

    Private Sub CargarPartidos()
        dgvPartidos.DataSource = Nothing
        _idPartido = 0
        grpCarga.Enabled = False
        lblEnfrentamiento.Text = $"pareja1 vs pareja2"
        cmbGanador.SelectedIndex = -1

        If cboTorneo.SelectedValue Is Nothing Then Return
        Dim torneoId = CInt(cboTorneo.SelectedValue)

        Dim dt As DataTable
        If cboZona.SelectedValue IsNot Nothing AndAlso CInt(cboZona.SelectedValue) > 0 Then
            dt = ListarPartidosPorZona(CInt(cboZona.SelectedValue))
        Else
            dt = RepositorioPartidosRepo.ListarPartidosPorTorneo(torneoId)
        End If

        dgvPartidos.DataSource = dt

        ' Ocultar columnas técnicas y nombrar vistosas
        If dgvPartidos.Columns.Contains("id_partido") Then dgvPartidos.Columns("id_partido").Visible = False
        If dgvPartidos.Columns.Contains("id_pareja1") Then dgvPartidos.Columns("id_pareja1").Visible = False
        If dgvPartidos.Columns.Contains("id_pareja2") Then dgvPartidos.Columns("id_pareja2").Visible = False
        If dgvPartidos.Columns.Contains("nombre_zona") Then dgvPartidos.Columns("nombre_zona").HeaderText = "Zona"
        If dgvPartidos.Columns.Contains("puntos_pareja1") Then dgvPartidos.Columns("puntos_pareja1").HeaderText = "P1"
        If dgvPartidos.Columns.Contains("puntos_pareja2") Then dgvPartidos.Columns("puntos_pareja2").HeaderText = "P2"
    End Sub

    Private Function ListarPartidosPorZona(idZona As Integer) As DataTable
        Const sql As String =
"SELECT  pt.id_partido, z.nombre_zona,
        pt.id_pareja1, pt.id_pareja2,
        CONCAT(j1.nombre,' ',j1.apellido,' / ',j1b.nombre,' ',j1b.apellido) AS Pareja1,
        CONCAT(j2.nombre,' ',j2.apellido,' / ',j2b.nombre,' ',j2b.apellido) AS Pareja2,
        pt.puntos_pareja1, pt.puntos_pareja2, pt.estado
FROM dbo.Partido pt
JOIN dbo.Zona z ON z.id_zona = pt.id_zona
JOIN dbo.Parejas p1 ON p1.id_pareja = pt.id_pareja1
JOIN dbo.Parejas p2 ON p2.id_pareja = pt.id_pareja2
JOIN dbo.Jugador j1  ON j1.id_jugador  = p1.id_jugador1
JOIN dbo.Jugador j1b ON j1b.id_jugador = p1.id_jugador2
JOIN dbo.Jugador j2  ON j2.id_jugador  = p2.id_jugador1
JOIN dbo.Jugador j2b ON j2b.id_jugador = p2.id_jugador2
WHERE pt.id_zona = @Z
ORDER BY pt.id_partido;"

        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@Z", SqlDbType.Int).Value = idZona
            cn.Open()
            dt.Load(cmd.ExecuteReader())
        End Using
        Return dt
    End Function

    ' ===================== EVENTOS UI =====================
    Private Sub cboTorneo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTorneo.SelectedIndexChanged
        If cboTorneo.SelectedValue Is Nothing Then Return
        CargarZonasDelTorneo(CInt(cboTorneo.SelectedValue))
        CargarPartidos()
    End Sub

    Private Sub cboZona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboZona.SelectedIndexChanged
        If cboTorneo.SelectedValue Is Nothing Then Return
        CargarPartidos()
    End Sub

    Private Sub dgvPartidos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPartidos.SelectionChanged
        If dgvPartidos.CurrentRow Is Nothing Then
            grpCarga.Enabled = False
            Return
        End If

        Dim r = dgvPartidos.CurrentRow
        If r Is Nothing Then Return

        _idPartido = CInt(r.Cells("id_partido").Value)
        lblEnfrentamiento.Text = $"{r.Cells("Pareja1").Value} vs {r.Cells("Pareja2").Value}"
        cmbGanador.SelectedIndex = -1
        grpCarga.Enabled = True

        ' (opcional) si querés guardar id_zona cuando la consulta lo incluya
        ' If dgvPartidos.Columns.Contains("id_zona") Then _idZona = CInt(r.Cells("id_zona").Value)
    End Sub

    ' ===================== Guardar =====================
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If _idPartido <= 0 Then
            MessageBox.Show("Seleccioná un partido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cmbGanador.SelectedIndex < 0 Then
            MessageBox.Show("Seleccioná el ganador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ganador: 1=Pareja1, 2=Pareja2
        Dim ganador As Integer = cmbGanador.SelectedIndex + 1

        ' ¿Usás también games (P1/P2) en pantalla?
        Dim usaGames As Boolean = (Me.Controls.Find("nudP1", True).Any AndAlso Me.Controls.Find("nudP2", True).Any)
        Dim p1 As Integer = 0
        Dim p2 As Integer = 0
        If usaGames Then
            Dim n1 = TryCast(Me.Controls.Find("nudP1", True).FirstOrDefault(), NumericUpDown)
            Dim n2 = TryCast(Me.Controls.Find("nudP2", True).FirstOrDefault(), NumericUpDown)
            If n1 IsNot Nothing Then p1 = CInt(n1.Value)
            If n2 IsNot Nothing Then p2 = CInt(n2.Value)
            If p1 = p2 Then
                MessageBox.Show("No se permite empate (P1 = P2).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            ' Si no seleccionó ganador, inferimos de P1/P2
            If cmbGanador.SelectedIndex < 0 Then ganador = If(p1 > p2, 1, 2)
        End If

        Try
            ' 1) Resultado 1/0 (tu SP existente)
            RepositorioPartidosRepo.RegistrarResultado(_idPartido, ganador)

            ' 2) (Opcional) Guardar games en Partido para que se vean en el fixture
            If usaGames Then
                GuardarGamesEnPartido(_idPartido, p1, p2)
            End If

            ' 3) Refrescar grilla propia
            CargarPartidos()

            ' 4) Refrescar Fixture si está abierto
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmFixture Then
                    Try
                        DirectCast(f, FrmFixture).PerformRefreshFor(cboTorneo.SelectedValue)
                    Catch
                    End Try
                    Exit For
                End If
            Next

            MessageBox.Show("Resultado registrado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            grpCarga.Enabled = False
            _idPartido = 0
            cmbGanador.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error al registrar resultado:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        grpCarga.Enabled = False
        _idPartido = 0
        cmbGanador.SelectedIndex = -1
        lblEnfrentamiento.Text = ""
    End Sub

    ' ===================== Helpers SQL opcionales =====================
    Private Sub GuardarGamesEnPartido(idPartido As Integer, p1 As Integer, p2 As Integer)
        Const sql As String = "
UPDATE dbo.Partido
   SET puntos_pareja1 = @p1,
       puntos_pareja2 = @p2
 WHERE id_partido = @id;"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@p1", SqlDbType.Int).Value = p1
            cmd.Parameters.Add("@p2", SqlDbType.Int).Value = p2
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPartido
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub




End Class
