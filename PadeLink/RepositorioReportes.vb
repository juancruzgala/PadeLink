Imports System.Data
Imports System.Data.SqlClient

Public Module RepositorioReportes

    Private ReadOnly PRICE_CANDIDATES As String() =
    {"monto", "monto_inscripcion", "precio_inscripcion", "precio", "monto_torneo"}
    Private Const ESTADO_PARTIDO_FINALIZADO As String = "Finalizado"

    Private Function PrecioColumna(cn As SqlConnection) As String
        Using cmd As New SqlCommand("
            SELECT CASE 
                     WHEN EXISTS(SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Torneos') AND name = @p1) 
                          THEN @p1
                     WHEN EXISTS(SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Torneos') AND name = @p2)
                          THEN @p2
                     ELSE @p1
                   END", cn)
            cmd.Parameters.AddWithValue("@p1", PRICE_CANDIDATES)
            cmd.Parameters.AddWithValue("@p2", PRICE_CANDIDATES)
            Return CStr(cmd.ExecuteScalar())
        End Using
    End Function
    Private Function TorneosColumnExists(cn As SqlConnection, col As String) As Boolean
        Using cmd As New SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.Torneos', @c) IS NOT NULL THEN 1 ELSE 0 END", cn)
            cmd.Parameters.AddWithValue("@c", col)
            Return CInt(cmd.ExecuteScalar()) = 1
        End Using
    End Function

    Private Function DetectPrecioColumn(cn As SqlConnection) As String
        For Each c In PRICE_CANDIDATES
            If TorneosColumnExists(cn, c) Then Return c
        Next
        Return "monto"
    End Function

    ' -------------------------- ADMIN: Recaudación por torneo (rango fechas) --------------------------
    Public Function Admin_Recaudacion(desde As Date, hasta As Date) As DataTable
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection()
            cn.Open()
            Dim priceCol As String = DetectPrecioColumn(cn)

            Dim sql As String =
$"
;WITH base AS (
    SELECT 
        t.id_torneo,
        t.nombre_torneo,
        t.fecha,
        CAST(ISNULL(t.{priceCol}, 0) AS DECIMAL(18,2)) AS precio,
        i.estado_validacion
    FROM dbo.Torneos t
    LEFT JOIN dbo.Inscripcion i ON i.id_torneo = t.id_torneo
    WHERE t.fecha BETWEEN @d1 AND @d2
)
SELECT 
    nombre_torneo AS Torneo,
    CONVERT(date, fecha) AS Fecha,
    COUNT(CASE WHEN estado_validacion IS NOT NULL THEN 1 END) AS ParejasInscriptas,

    CAST(
        ISNULL(SUM(
            CASE 
                WHEN estado_validacion = 'Pago Total' THEN precio
                WHEN estado_validacion = 'Seña'       THEN precio * 0.5
                ELSE 0 
            END
        ), 0) AS DECIMAL(18,2)
    ) AS Monto,

    SUM(CASE WHEN estado_validacion = 'Pago Total' THEN 1 ELSE 0 END) AS CantPagoTotal,
    SUM(CASE WHEN estado_validacion = 'Seña'       THEN 1 ELSE 0 END) AS CantSeña,
    SUM(CASE WHEN estado_validacion = 'No pago'    THEN 1 ELSE 0 END) AS CantNoPago
FROM base
GROUP BY nombre_torneo, fecha
ORDER BY Fecha DESC, Torneo ASC;
"


            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = desde.Date
                cmd.Parameters.Add("@d2", SqlDbType.DateTime).Value = hasta.Date.AddDays(1).AddTicks(-1)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function



    ' -------------------------- CANCHERO --------------------------
    Public Function Canchero_Calendario(Optional diasAtras As Integer = 7, Optional diasAdelante As Integer = 60) As DataTable
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand("
            SELECT 
                t.nombre_torneo AS Torneo,
                CONVERT(date, t.fecha) AS Fecha,
                t.id_categoria,
                ISNULL(c.nombre_cat, CONCAT('Cat ', t.id_categoria)) AS Categoria,
                t.estado
            FROM dbo.Torneos t
            LEFT JOIN dbo.Categoria c ON c.id_categoria = t.id_categoria
            WHERE t.fecha BETWEEN DATEADD(day, -@back, CAST(GETDATE() AS date))
                               AND DATEADD(day,  @fwd,  CAST(GETDATE() AS date))
            ORDER BY t.fecha ASC, t.nombre_torneo ASC;", cn)
            cmd.Parameters.Add("@back", SqlDbType.Int).Value = diasAtras
            cmd.Parameters.Add("@fwd", SqlDbType.Int).Value = diasAdelante
            cn.Open()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' -------------------------- FISCAL: Avance de torneos activos --------------------------
    ' -------------------------- FISCAL: Avance de torneos activos --------------------------
    Public Function Fiscal_Avance() As DataTable
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand("
;WITH insc AS (
    SELECT i.id_torneo, COUNT(DISTINCT i.id_pareja) AS parejas
    FROM dbo.Inscripcion i
    GROUP BY i.id_torneo
)
SELECT 
    t.nombre_torneo AS Torneo,
    CONVERT(date, t.fecha) AS Fecha,
    ISNULL(insc.parejas, 0) AS Parejas,
    (ISNULL(insc.parejas,0)*(ISNULL(insc.parejas,0)-1))/2 AS PartidosEsperados
FROM dbo.Torneos t
LEFT JOIN insc ON insc.id_torneo = t.id_torneo
WHERE t.estado IN ('En Curso','EN CURSO','Activo','ACTIVO')
ORDER BY Fecha DESC, Torneo;", cn)
            cn.Open()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function


End Module
