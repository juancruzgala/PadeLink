Imports System.Data
Imports System.Data.SqlClient

Public Module RepositorioFixture

    ' ---------- Lecturas básicas ----------
    Public Function ObtenerParejasInscriptas(torneoId As Integer) As DataTable
        Const sql As String =
"SELECT  i.id_pareja,
        p.id_jugador1, j1.nombre AS n1, j1.apellido AS a1,
        p.id_jugador2, j2.nombre AS n2, j2.apellido AS a2
FROM dbo.Inscripcion i
JOIN dbo.Parejas p ON p.id_pareja = i.id_pareja
JOIN dbo.Jugador j1 ON j1.id_jugador = p.id_jugador1
JOIN dbo.Jugador j2 ON j2.id_jugador = p.id_jugador2
WHERE i.id_torneo = @T
ORDER BY i.id_inscripcion;"
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

    Public Function CrearZona(torneoId As Integer, nombreZona As String) As Integer
        Const sql As String =
"INSERT INTO dbo.Zona (id_torneo, nombre_zona) 
 OUTPUT INSERTED.id_zona
 VALUES (@T, @Z);"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@T", SqlDbType.Int).Value = torneoId
            cmd.Parameters.Add("@Z", SqlDbType.VarChar, 5).Value = nombreZona
            cn.Open()
            Return CInt(cmd.ExecuteScalar())
        End Using
    End Function

    Public Sub InsertarParejaEnZona(idZona As Integer, idPareja As Integer)
        Const sql As String =
"IF NOT EXISTS (SELECT 1 FROM dbo.Zona_Puntaje WHERE id_zona=@Z AND id_pareja=@P)
    INSERT INTO dbo.Zona_Puntaje (id_zona, id_pareja, partidos_jugados, ganados, perdidos, games_favor, games_contra, puntos)
    VALUES (@Z, @P, 0,0,0,0,0,0);"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@Z", SqlDbType.Int).Value = idZona
            cmd.Parameters.Add("@P", SqlDbType.Int).Value = idPareja
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub CrearPartido(idZona As Integer, idPareja1 As Integer, idPareja2 As Integer)
        If idPareja1 = idPareja2 Then Exit Sub
        Const sql As String =
"IF NOT EXISTS (SELECT 1 FROM dbo.Partido WHERE id_zona=@Z AND
               ((id_pareja1=@A AND id_pareja2=@B) OR (id_pareja1=@B AND id_pareja2=@A)))
BEGIN
    INSERT INTO dbo.Partido (id_zona, id_pareja1, id_pareja2, estado)
    VALUES (@Z, @A, @B, 'Pendiente');
END"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@Z", SqlDbType.Int).Value = idZona
            cmd.Parameters.Add("@A", SqlDbType.Int).Value = idPareja1
            cmd.Parameters.Add("@B", SqlDbType.Int).Value = idPareja2
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' Genera todas las combinaciones únicas (round robin) para N parejas de la zona
    Private Sub CrearPartidosRoundRobin(idZona As Integer, ids As List(Of Integer))
        For i = 0 To ids.Count - 2
            For j = i + 1 To ids.Count - 1
                CrearPartido(idZona, ids(i), ids(j))
            Next
        Next
    End Sub

    ' ---------- Generación de fixture por zonas ----------
    ' Reglas:
    ' - grupos base de 3
    ' - resto=1 -> la última zona queda con 4
    ' - resto=2 -> las dos últimas zonas con +1 cada una (si hay sólo una zona, queda 5 y listo)
    Public Sub GenerarFixtureZonas(torneoId As Integer)
        Dim parejas = ObtenerParejasInscriptas(torneoId)
        If parejas.Rows.Count = 0 Then Throw New Exception("No hay parejas inscriptas en este torneo.")

        ' Armar lista de ids en orden de inscripción
        Dim ids = parejas.AsEnumerable().Select(Function(r) CInt(r("id_pareja"))).ToList()

        Dim n = ids.Count
        Dim grupos As Integer = Math.Ceiling(n / 3.0R)
        If grupos <= 0 Then grupos = 1

        ' Tamanios base
        Dim sizes = Enumerable.Repeat(3, grupos).ToList()
        Dim resto = n - (3 * grupos)
        If resto = 1 Then
            sizes(sizes.Count - 1) += 1                        ' última zona de 4
        ElseIf resto = 2 Then
            If sizes.Count >= 2 Then
                sizes(sizes.Count - 1) += 1                    ' última +1
                sizes(sizes.Count - 2) += 1                    ' anteúltima +1
            Else
                sizes(0) += 2                                  ' caso borde: una sola zona, queda 5
            End If
        End If

        ' Limpieza previa opcional (si querés regenerar)
        ' Eliminar zonas/partidos/puntajes anteriores del torneo
        LimpiarFixtureDelTorneo(torneoId)

        Dim idx As Integer = 0
        For g = 0 To sizes.Count - 1
            Dim nombreZona = Chr(Asc("A"c) + g).ToString()     ' A, B, C...
            Dim idZona = CrearZona(torneoId, nombreZona)

            Dim cant = sizes(g)
            Dim grupoIds = ids.Skip(idx).Take(cant).ToList()
            idx += cant

            ' Insertar parejas en la tabla de puntajes
            For Each pid In grupoIds
                InsertarParejaEnZona(idZona, pid)
            Next

            ' Crear todos los partidos de la zona
            CrearPartidosRoundRobin(idZona, grupoIds)
        Next
    End Sub

    Private Sub LimpiarFixtureDelTorneo(torneoId As Integer)
        Const sql As String =
";WITH z AS (
   SELECT id_zona FROM dbo.Zona WHERE id_torneo=@T
)
DELETE p FROM dbo.Partido p WHERE p.id_zona IN (SELECT id_zona FROM Zona as z);
DELETE zp FROM dbo.Zona_Puntaje zp WHERE zp.id_zona IN (SELECT id_zona FROM Zona as z);
DELETE z FROM dbo.Zona z WHERE z.id_torneo=@T;"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@T", SqlDbType.Int).Value = torneoId
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' ---------- Lectura del fixture para UI ----------
    Public Function ObtenerFixtureParaUI(torneoId As Integer) As DataSet
        Dim ds As New DataSet()

        Const qZonas As String = "
SELECT id_zona, nombre_zona
FROM dbo.Zona
WHERE id_torneo=@T
ORDER BY nombre_zona;"

        Const qTablaZona As String = "
SELECT  zp.id_zona, zp.id_pareja,
        CONCAT(j1.nombre,' ',j1.apellido, ' / ', j2.nombre,' ',j2.apellido) AS Pareja,
        zp.partidos_jugados, zp.ganados, zp.perdidos,
        zp.games_favor, zp.games_contra, zp.puntos
FROM dbo.Zona_Puntaje zp
JOIN dbo.Parejas p  ON p.id_pareja = zp.id_pareja
JOIN dbo.Jugador j1 ON j1.id_jugador = p.id_jugador1
JOIN dbo.Jugador j2 ON j2.id_jugador = p.id_jugador2
WHERE zp.id_zona IN (SELECT id_zona FROM dbo.Zona WHERE id_torneo=@T)
ORDER BY zp.id_zona, Pareja;"

        Const qPartidos As String = "
SELECT  pt.id_partido, pt.id_zona,
        pt.id_pareja1, pt.id_pareja2,
        CONCAT(j1.nombre,' ',j1.apellido) AS J1A,
        CONCAT(j1b.nombre,' ',j1b.apellido) AS J1B,
        CONCAT(j2a.nombre,' ',j2a.apellido) AS J2A,
        CONCAT(j2b.nombre,' ',j2b.apellido) AS J2B,
        pt.puntos_pareja1, pt.puntos_pareja2, pt.estado
FROM dbo.Partido pt
JOIN dbo.Parejas p1 ON p1.id_pareja = pt.id_pareja1
JOIN dbo.Parejas p2 ON p2.id_pareja = pt.id_pareja2
JOIN dbo.Jugador j1  ON j1.id_jugador  = p1.id_jugador1
JOIN dbo.Jugador j1b ON j1b.id_jugador = p1.id_jugador2
JOIN dbo.Jugador j2a ON j2a.id_jugador = p2.id_jugador1
JOIN dbo.Jugador j2b ON j2b.id_jugador = p2.id_jugador2
WHERE pt.id_zona IN (SELECT id_zona FROM dbo.Zona WHERE id_torneo=@T)
ORDER BY pt.id_zona, pt.id_partido;"

        Using cn = Conexion.GetConnection()
            cn.Open()

            Using da As New SqlDataAdapter(qZonas, cn)
                da.SelectCommand.Parameters.Add("@T", SqlDbType.Int).Value = torneoId
                da.Fill(ds, "Zonas")
            End Using
            Using da As New SqlDataAdapter(qTablaZona, cn)
                da.SelectCommand.Parameters.Add("@T", SqlDbType.Int).Value = torneoId
                da.Fill(ds, "Tabla")
            End Using
            Using da As New SqlDataAdapter(qPartidos, cn)
                da.SelectCommand.Parameters.Add("@T", SqlDbType.Int).Value = torneoId
                da.Fill(ds, "Partidos")
            End Using
        End Using

        Return ds
    End Function

End Module

