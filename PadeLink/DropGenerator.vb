Imports System.Diagnostics
Public Module DropGenerator

    Public Function GenerarZonas(t As Torneo) As List(Of Zona)

        Dim inscriptas As New List(Of ParejaTorneo)(RepositorioParejas.Listar(t))

        ' 🔎 TRACE: cuántas parejas tiene este torneo
        Debug.WriteLine($"[DROP] Torneo='{t?.Nombre}'  Parejas={inscriptas.Count}")

        Dim n As Integer = inscriptas.Count
        If n < 3 Then
            Throw New InvalidOperationException("Se necesitan al menos 3 parejas para generar zonas.")
        End If


        Dim tamGrupo As Integer = If(n > 20, 4, 3)
        Debug.WriteLine($"[DROP] Tamaño de grupo={tamGrupo}")

        ' 2) aleatoriamente
        Dim rnd As New Random()
        For i As Integer = inscriptas.Count - 1 To 1 Step -1
            Dim j As Integer = rnd.Next(i + 1) ' 0..i
            Dim tmp As ParejaTorneo = inscriptas(i)
            inscriptas(i) = inscriptas(j)
            inscriptas(j) = tmp
        Next

        ' 3) Arma zona
        Dim zonas As New List(Of Zona)()
        Dim idx As Integer = 0
        Dim letra As Integer = Asc("A"c)

        While idx < n
            Dim restante As Integer = n - idx
            Dim size As Integer = Math.Min(tamGrupo, restante)

            If restante < tamGrupo AndAlso zonas.Count > 0 Then
                Dim ult As Zona = zonas(zonas.Count - 1)
                For k As Integer = 0 To restante - 1
                    ult.Parejas.Add(inscriptas(idx + k))
                Next
                ult.Partidos = GenerarFixture(ult.Parejas)

                Debug.WriteLine($"[DROP] Zona {ult.Nombre}: {ult.Parejas.Count} parejas (se completó con el resto)")
                Exit While
            End If


            Dim ps As New List(Of ParejaTorneo)()
            For k As Integer = 0 To size - 1
                ps.Add(inscriptas(idx + k))
            Next
            idx += size

            Dim z As New Zona()
            z.Nombre = Chr(letra)
            z.Parejas = ps
            z.Partidos = GenerarFixture(ps)
            zonas.Add(z)

            Debug.WriteLine($"[DROP] Zona {z.Nombre}: {ps.Count} parejas")

            letra += 1
        End While


        Dim totalParejas As Integer = zonas.Sum(Function(zz) zz.Parejas.Count)
        Debug.WriteLine($"[DROP] Zonas generadas={zonas.Count}  ParejasSumadas={totalParejas}")

        Return zonas
    End Function

    Private Function NombrePareja(p As ParejaTorneo) As String
        Return p.Jugador1 & " / " & p.Jugador2
    End Function

    Private Function GenerarFixture(ps As List(Of ParejaTorneo)) As List(Of Partido)
        Dim lista As New List(Of Partido)()

        If ps.Count = 3 Then
            ' Round-robin 3 equipos (3 partidos)
            lista.Add(New Partido With {.Numero = 1, .EquipoA = NombrePareja(ps(0)), .EquipoB = NombrePareja(ps(1)), .Ronda = 1})
            lista.Add(New Partido With {.Numero = 2, .EquipoA = NombrePareja(ps(1)), .EquipoB = NombrePareja(ps(2)), .Ronda = 1})
            lista.Add(New Partido With {.Numero = 3, .EquipoA = NombrePareja(ps(0)), .EquipoB = NombrePareja(ps(2)), .Ronda = 1})

        ElseIf ps.Count = 4 Then
            ' Semis + finales (ganadores y perdedores)
            lista.Add(New Partido With {.Numero = 1, .EquipoA = NombrePareja(ps(0)), .EquipoB = NombrePareja(ps(1)), .Ronda = 1})
            lista.Add(New Partido With {.Numero = 2, .EquipoA = NombrePareja(ps(2)), .EquipoB = NombrePareja(ps(3)), .Ronda = 1})
            lista.Add(New Partido With {.Numero = 3, .EquipoA = "Ganador P1", .EquipoB = "Ganador P2", .Ronda = 2})
            lista.Add(New Partido With {.Numero = 4, .EquipoA = "Perdedor P1", .EquipoB = "Perdedor P2", .Ronda = 2})

        Else
            ' Fallback: todos contra todos
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

End Module