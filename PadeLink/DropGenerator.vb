Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Public Module DropGenerator

    Public Function GenerarZonas(t As Torneo) As List(Of Zona)
        Dim inscriptas As List(Of ParejaTorneo) = RepositorioParejas.Listar(t)

        If inscriptas.Count < 3 Then
            Throw New InvalidOperationException("Se necesitan al menos 3 parejas para generar zonas.")
        End If

        ' Mezcla aleatoria
        Dim rnd As New Random()
        For i As Integer = inscriptas.Count - 1 To 1 Step -1
            Dim j As Integer = rnd.Next(i + 1)
            Dim tmp = inscriptas(i)
            inscriptas(i) = inscriptas(j)
            inscriptas(j) = tmp
        Next

        Dim tamGrupo As Integer = If(inscriptas.Count > 20, 4, 3)
        Dim zonas As New List(Of Zona)
        Dim idx As Integer = 0
        Dim letra As Integer = Asc("A"c)

        Using cn = Conexion.GetConnection()
            cn.Open()

            ' Eliminar drops anteriores (si se re-genera)
            Using cmdDel As New SqlCommand("DELETE FROM partidos WHERE id_torneo=@id; DELETE FROM parejas_grupo WHERE id_grupo IN (SELECT id_grupo FROM grupos_drop WHERE id_torneo=@id); DELETE FROM grupos_drop WHERE id_torneo=@id;", cn)
                cmdDel.Parameters.Add("@id", SqlDbType.Int).Value = t.id_torneo
                cmdDel.ExecuteNonQuery()
            End Using

            ' Armar zonas
            While idx < inscriptas.Count
                Dim restante As Integer = inscriptas.Count - idx
                Dim size As Integer = Math.Min(tamGrupo, restante)

                Dim ps As New List(Of ParejaTorneo)
                For k As Integer = 0 To size - 1
                    ps.Add(inscriptas(idx + k))
                Next
                idx += size

                Dim nombreZona As String = Chr(letra).ToString()

                ' Insertar zona
                Dim idZona As Integer
                Using cmdZ As New SqlCommand("INSERT INTO grupos_drop (id_torneo, nombre_grupo) OUTPUT INSERTED.id_grupo VALUES (@id, @nombre);", cn)
                    cmdZ.Parameters.Add("@id", SqlDbType.Int).Value = t.id_torneo
                    cmdZ.Parameters.Add("@nombre", SqlDbType.VarChar, 5).Value = nombreZona
                    idZona = Convert.ToInt32(cmdZ.ExecuteScalar())
                End Using

                ' Insertar parejas del grupo
                For Each p In ps
                    Using cmdPG As New SqlCommand("INSERT INTO parejas_grupo (id_grupo, id_pareja) VALUES (@idg, @idp);", cn)
                        cmdPG.Parameters.Add("@idg", SqlDbType.Int).Value = idZona
                        cmdPG.Parameters.Add("@idp", SqlDbType.Int).Value = p.id_pareja
                        cmdPG.ExecuteNonQuery()
                    End Using
                Next

                ' Generar partidos y guardarlos
                Dim partidos = GenerarFixture(ps)
                For Each pa In partidos
                    Using cmdP As New SqlCommand("INSERT INTO partidos (id_torneo, id_grupo, equipo_a, equipo_b, ronda) VALUES (@id, @idg, @a, @b, @r);", cn)
                        cmdP.Parameters.Add("@id", SqlDbType.Int).Value = t.id_torneo
                        cmdP.Parameters.Add("@idg", SqlDbType.Int).Value = idZona
                        cmdP.Parameters.Add("@a", SqlDbType.VarChar, 200).Value = pa.EquipoA
                        cmdP.Parameters.Add("@b", SqlDbType.VarChar, 200).Value = pa.EquipoB
                        cmdP.Parameters.Add("@r", SqlDbType.Int).Value = pa.Ronda
                        cmdP.ExecuteNonQuery()
                    End Using
                Next

                zonas.Add(New Zona With {.Nombre = nombreZona, .Parejas = ps, .Partidos = partidos})
                letra += 1
            End While
        End Using

        Return zonas
    End Function

    Private Function GenerarFixture(ps As List(Of ParejaTorneo)) As List(Of Partido)
        Dim lista As New List(Of Partido)
        If ps.Count = 3 Then
            lista.Add(New Partido With {.Numero = 1, .EquipoA = NombrePareja(ps(0)), .EquipoB = NombrePareja(ps(1)), .Ronda = 1})
            lista.Add(New Partido With {.Numero = 2, .EquipoA = NombrePareja(ps(1)), .EquipoB = NombrePareja(ps(2)), .Ronda = 1})
            lista.Add(New Partido With {.Numero = 3, .EquipoA = NombrePareja(ps(0)), .EquipoB = NombrePareja(ps(2)), .Ronda = 1})
        ElseIf ps.Count = 4 Then
            lista.Add(New Partido With {.Numero = 1, .EquipoA = NombrePareja(ps(0)), .EquipoB = NombrePareja(ps(1)), .Ronda = 1})
            lista.Add(New Partido With {.Numero = 2, .EquipoA = NombrePareja(ps(2)), .EquipoB = NombrePareja(ps(3)), .Ronda = 1})
            lista.Add(New Partido With {.Numero = 3, .EquipoA = "Ganador P1", .EquipoB = "Ganador P2", .Ronda = 2})
            lista.Add(New Partido With {.Numero = 4, .EquipoA = "Perdedor P1", .EquipoB = "Perdedor P2", .Ronda = 2})
        Else
            Dim nro As Integer = 1
            For i As Integer = 0 To ps.Count - 2
                For j As Integer = i + 1 To ps.Count - 1
                    lista.Add(New Partido With {
                        .Numero = nro,
                        .EquipoA = NombrePareja(ps(i)),
                        .EquipoB = NombrePareja(ps(j)),
                        .Ronda = 1})
                    nro += 1
                Next
            Next
        End If
        Return lista
    End Function

    Private Function NombrePareja(p As ParejaTorneo) As String
        Return p.Jugador1 & " / " & p.Jugador2
    End Function

End Module
