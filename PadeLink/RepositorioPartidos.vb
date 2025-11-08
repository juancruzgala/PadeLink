Imports System.Data
Imports System.Data.SqlClient

Public Module RepositorioPartidosRepo

    Public Function ListarPartidosPorTorneo(torneoId As Integer) As DataTable
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
WHERE z.id_torneo = @T
ORDER BY z.nombre_zona, pt.id_partido;"
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@T", SqlDbType.Int).Value = torneoId
            cn.Open()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Sub RegistrarResultado(idPartido As Integer, ganador As Integer)
        Const sql As String = "EXEC RegistrarResultadoPartido @id, @g"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPartido
            cmd.Parameters.Add("@g", SqlDbType.Int).Value = ganador
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub


End Module
