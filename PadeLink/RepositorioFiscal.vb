Imports System.Data
Imports System.Data.SqlClient

Public Module RepositorioFiscal

    ' Torneos para filtrar (podés ajustar el WHERE si querés solo "activos")
    Public Function ObtenerTorneos() As DataTable
        Const sql As String = "
SELECT t.id_torneo, t.nombre_torneo
FROM dbo.Torneos t
ORDER BY t.nombre_torneo;"
        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), da As New SqlDataAdapter(sql, cn)
            da.Fill(dt)
        End Using
        Return dt
    End Function

    ' Buscar jugador por DNI o Nombre (y torneo opcional)
    ' Devuelve: torneo, jugador, dni, cat_jugador, cat_torneo, coincide?, estado_pago, ids
    Public Function BuscarJugador(dni As String, nombre As String, Optional idTorneo As Integer? = Nothing) As DataTable
        Const sql As String =
"SELECT  t.id_torneo,
         t.nombre_torneo,
         j.id_jugador,
         j.nombre        AS jugador,
         j.dni,
         j.id_categoria  AS id_categoria_jugador,
         t.id_categoria  AS id_categoria_torneo,
         CASE WHEN j.id_categoria = t.id_categoria THEN 'OK' ELSE 'Revisar' END AS CoincideCategoria,
         i.estado_validacion AS estado_pago,
         p.id_pareja,
         i.id_inscripcion
FROM dbo.Inscripcion i
JOIN dbo.Parejas p        ON p.id_pareja = i.id_pareja
JOIN dbo.Torneos t         ON t.id_torneo = i.id_torneo
CROSS APPLY (VALUES (p.id_jugador1),(p.id_jugador2)) AS X(id_jugador)
JOIN dbo.Jugador j        ON j.id_jugador = X.id_jugador
WHERE (@dni <> '' AND j.dni = @dni)
   OR (@dni = ''  AND @nombre <> '' AND j.nombre LIKE @nombre + '%')
"

        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@dni", SqlDbType.VarChar, 15).Value = If(dni Is Nothing, "", dni.Trim())
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = If(nombre Is Nothing, "", nombre.Trim())

            ' Si se envía un id_torneo, lo agregamos al WHERE con AND
            If idTorneo.HasValue Then
                cmd.CommandText &= " AND i.id_torneo = @idTorneo"
                cmd.Parameters.Add("@idTorneo", SqlDbType.Int).Value = idTorneo.Value
            End If

            cmd.CommandText &= " ORDER BY t.nombre_torneo, j.nombre;"

            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' Alta de jugador (Fiscal puede crear jugadores nuevos)
    Public Sub InsertarJugador(nombre As String, dni As String, idCategoria As Integer)
        If String.IsNullOrWhiteSpace(nombre) Then Throw New ArgumentException("Nombre requerido.")
        If String.IsNullOrWhiteSpace(dni) Then Throw New ArgumentException("DNI requerido.")

        Dim re As New System.Text.RegularExpressions.Regex("^\d{7,9}$")
        If Not re.IsMatch(dni) Then
            Throw New ArgumentException("DNI inválido (7 a 9 dígitos).")
        End If

        Const sql As String = "
INSERT INTO dbo.Jugador (nombre, apellido, id_categoria, dni)
VALUES (@nombre, '', @idCategoria, @dni);"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre.Trim()
            cmd.Parameters.Add("@dni", SqlDbType.VarChar, 15).Value = dni.Trim()
            cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
    Public Function ObtenerCategorias() As DataTable
        Const sql As String = "
    SELECT id_categoria, nombre_cat
    FROM dbo.Categoria
    ORDER BY id_categoria;"

        Dim dt As New DataTable()
        Using cn = Conexion.GetConnection(), da As New SqlDataAdapter(sql, cn)
            da.Fill(dt)
        End Using
        Return dt
    End Function

End Module
