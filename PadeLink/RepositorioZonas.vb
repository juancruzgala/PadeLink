Imports System.Data
Imports System.Data.SqlClient

Public Module RepositorioZonas

    ' ===========================
    ' Listar ZONAS de un TORNEO
    ' ===========================
    Public Function Listar(t As Torneo) As List(Of Zona)
        Dim zonas As New List(Of Zona)
        If t Is Nothing Then Return zonas

        Using cn = Conexion.GetConnection()
            cn.Open()

            ' 1) Traer grupos del torneo
            Dim grupos As New List(Of (Id As Integer, Nombre As String))
            Using cmd As New SqlCommand("
                SELECT id_grupo, nombre_grupo
                  FROM grupos_drop
                 WHERE id_torneo = @id
                 ORDER BY nombre_grupo;", cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = t.id_torneo
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        grupos.Add((rd.GetInt32(0), rd.GetString(1)))
                    End While
                End Using
            End Using
            If grupos.Count = 0 Then Return zonas

            ' 2) Parejas por grupo
            Dim dicParejas As New Dictionary(Of Integer, List(Of ParejaTorneo))
            For Each g In grupos
                dicParejas(g.Id) = New List(Of ParejaTorneo)
            Next
            Using cmd As New SqlCommand("
                SELECT g.id_grupo,
                       pt.id_pareja,
                       pt.id_torneo,
                       pt.id_jugador1,
                       pt.id_jugador2,
                       j1.nombre AS jugador1,
                       j2.nombre AS jugador2
                  FROM parejas_grupo g
                  JOIN parejas_torneo pt ON pt.id_pareja = g.id_pareja
                  JOIN jugadores j1 ON j1.id_jugador = pt.id_jugador1
                  JOIN jugadores j2 ON j2.id_jugador = pt.id_jugador2
                 WHERE pt.id_torneo = @id
                 ORDER BY g.id_grupo, jugador1, jugador2;", cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = t.id_torneo
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        Dim idGrupo = rd.GetInt32(0)
                        Dim p As New ParejaTorneo With {
                            .id_pareja = rd.GetInt32(1),
                            .id_torneo = rd.GetInt32(2),
                            .id_jugador1 = rd.GetInt32(3),
                            .id_jugador2 = rd.GetInt32(4),
                            .Jugador1 = rd.GetString(5),
                            .Jugador2 = rd.GetString(6)
                        }
                        dicParejas(idGrupo).Add(p)
                    End While
                End Using
            End Using

            ' 3) Partidos por grupo
            Dim dicPartidos As New Dictionary(Of Integer, List(Of Partido))
            For Each g In grupos
                dicPartidos(g.Id) = New List(Of Partido)
            Next
            Using cmd As New SqlCommand("
                SELECT p.id_partido, p.id_grupo, p.id_torneo,
                       p.equipo_a, p.equipo_b, p.ronda, p.dia, p.hora, p.complejo, p.resultado
                  FROM partidos p
                 WHERE p.id_torneo = @id
                 ORDER BY p.id_grupo, p.id_partido;", cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = t.id_torneo
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        Dim idGrupo = rd.GetInt32(1)
                        Dim pa As New Partido With {
                            .id_partido = rd.GetInt32(0),
                            .id_grupo = idGrupo,
                            .id_torneo = rd.GetInt32(2),
                            .EquipoA = rd.GetString(3),
                            .EquipoB = rd.GetString(4),
                            .Ronda = rd.GetInt32(5),
                            .Dia = If(rd.IsDBNull(6), CType(Nothing, Date?), rd.GetDateTime(6).Date),
                            .Hora = If(rd.IsDBNull(7), CType(Nothing, TimeSpan?), rd.GetTimeSpan(7)),
                            .Complejo = If(rd.IsDBNull(8), Nothing, rd.GetString(8)),
                            .Resultado = If(rd.IsDBNull(9), Nothing, rd.GetString(9))
                        }
                        dicPartidos(idGrupo).Add(pa)
                    End While
                End Using
            End Using

            ' 4) Armar objetos Zona
            For Each g In grupos
                Dim z As New Zona With {
                    .Nombre = g.Nombre,
                    .Parejas = dicParejas(g.Id),
                    .Partidos = dicPartidos(g.Id)
                }
                ' numeración para la grilla
                Dim i As Integer = 1
                For Each pa In z.Partidos
                    pa.Numero = i : i += 1
                Next
                zonas.Add(z)
            Next
        End Using

        Return zonas
    End Function

    ' ===========================
    ' Actualizar campos de PARTIDO
    ' ===========================
    Public Sub ActualizarPartidoCampos(id_partido As Integer,
                                       dia As Date?,
                                       hora As TimeSpan?,
                                       complejo As String,
                                       resultado As String)
        Const sql As String = "
            UPDATE partidos
               SET dia = @dia,
                   hora = @hora,
                   complejo = @complejo,
                   resultado = @resultado
             WHERE id_partido = @id;"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id_partido
            cmd.Parameters.Add("@dia", SqlDbType.[Date]).Value = If(dia.HasValue, CType(dia.Value, Object), DBNull.Value)
            cmd.Parameters.Add("@hora", SqlDbType.Time).Value = If(hora.HasValue, CType(hora.Value, Object), DBNull.Value)
            cmd.Parameters.Add("@complejo", SqlDbType.VarChar, 100).Value =
                If(String.IsNullOrWhiteSpace(complejo), CType(DBNull.Value, Object), complejo)
            cmd.Parameters.Add("@resultado", SqlDbType.VarChar, 50).Value =
                If(String.IsNullOrWhiteSpace(resultado), CType(DBNull.Value, Object), resultado)
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

End Module
