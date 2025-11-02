Imports System.Data
Imports System.Data.SqlClient

Public Module RepositorioReportes

    ' ===================== AJUSTES RÁPIDOS (si tu esquema difiere) =====================
    Private Const PRICE_COL_PRIMARY As String = "monto"               ' nombre de columna principal de precio
    Private Const PRICE_COL_FALLBACK As String = "precio_inscripcion" ' alternativa si no existe "monto"
    Private Const ESTADO_PARTIDO_FINALIZADO As String = "Finalizado"
    ' ===================================================================================

    ' Devuelve el nombre de columna de precio que existe en Torneos (monto o precio_inscripcion)
    Private Function PrecioColumna(cn As SqlConnection) As String
        Using cmd As New SqlCommand("
            SELECT CASE 
                     WHEN EXISTS(SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Torneos') AND name = @p1) 
                          THEN @p1
                     WHEN EXISTS(SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Torneos') AND name = @p2)
                          THEN @p2
                     ELSE @p1
                   END", cn)
            cmd.Parameters.AddWithValue("@p1", PRICE_COL_PRIMARY)
            cmd.Parameters.AddWithValue("@p2", PRICE_COL_FALLBACK)
            Return CStr(cmd.ExecuteScalar())
        End Using
    End Function

    ' -------------------------- ADMIN: Recaudación por torneo (rango fechas) --------------------------
    Public Function Admin_Recaudacion(desde As Date, hasta As Date) As DataTable
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection()
            cn.Open()
            Dim priceCol As String = PrecioColumna(cn)

            Dim sql As String =
$"
;WITH base AS (
    SELECT 
        t.id_torneo,
        t.nombre_torneo,
        t.fecha,
        ISNULL(t.{priceCol}, 0) AS precio,
        i.estado_validacion
    FROM dbo.Torneos t
    LEFT JOIN dbo.Inscripcion i ON i.id_torneo = t.id_torneo
    WHERE t.fecha BETWEEN @d1 AND @d2
      AND (t.estado = 'Finalizado' OR t.estado = 'FINALIZADO' OR t.estado = 'Finalizado ') -- por si hay variantes
)
SELECT 
    nombre_torneo      AS Torneo,
    CONVERT(date, fecha) AS Fecha,
    COUNT(CASE WHEN estado_validacion IS NOT NULL THEN 1 END) AS ParejasInscriptas,
    SUM(CASE WHEN estado_validacion = 'Pago Total' THEN precio
             WHEN estado_validacion = 'Seña' THEN precio * 0.5
             ELSE 0 END)                                 AS Recaudado,
    SUM(CASE WHEN estado_validacion = 'Pago Total' THEN 1 ELSE 0 END) AS CantPagoTotal,
    SUM(CASE WHEN estado_validacion = 'Seña'       THEN 1 ELSE 0 END) AS CantSeña,
    SUM(CASE WHEN estado_validacion = 'No pago'    THEN 1 ELSE 0 END) AS CantNoPago
FROM base
GROUP BY nombre_torneo, fecha
ORDER BY Fecha DESC, Torneo ASC;"

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

    ' -------------------------- CANCHERO: “Calendario” (próximos y últimos) --------------------------
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
    ' % = partidos_finalizados / partidos_esperados; partidos_esperados ≈ N*(N-1)/2 con N = parejas inscriptas
    Public Function Fiscal_Avance() As DataTable
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand("
;WITH insc AS (
    SELECT i.id_torneo, COUNT(DISTINCT i.id_pareja) AS parejas
    FROM dbo.Inscripcion i
    GROUP BY i.id_torneo
),
part AS (
    SELECT p.id_torneo,
           COUNT(DISTINCT CASE WHEN p.estado = @fin THEN p.id_partido END) AS jugados
    FROM dbo.Partidos p
    GROUP BY p.id_torneo
)
SELECT 
    t.nombre_torneo AS Torneo,
    CONVERT(date, t.fecha) AS Fecha,
    ISNULL(insc.parejas, 0) AS Parejas,
    (ISNULL(insc.parejas,0)*(ISNULL(insc.parejas,0)-1))/2 AS PartidosEsperados,
    ISNULL(part.jugados, 0)  AS PartidosJugados,
    CAST(CASE 
            WHEN (ISNULL(insc.parejas,0)*(ISNULL(insc.parejas,0)-1))/2 = 0 THEN 0
            ELSE (ISNULL(part.jugados,0) * 100.0) / ((ISNULL(insc.parejas,0)*(ISNULL(insc.parejas,0)-1))/2)
         END AS DECIMAL(5,2)) AS Porcentaje
FROM dbo.Torneos t
LEFT JOIN insc  ON insc.id_torneo = t.id_torneo
LEFT JOIN part  ON part.id_torneo = t.id_torneo
WHERE t.estado IN ('En Curso','EN CURSO','Activo','ACTIVO')
ORDER BY Fecha DESC, Torneo;", cn)
            cmd.Parameters.Add("@fin", SqlDbType.VarChar, 30).Value = ESTADO_PARTIDO_FINALIZADO
            cn.Open()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

End Module
