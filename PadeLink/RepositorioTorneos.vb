Imports System.Data
Imports System.Data.SqlClient

Public Module RepositorioTorneos

    '=======================
    ' INSERT
    '=======================
    Public Function Insertar(t As Torneo) As Integer
        Const sql As String =
"INSERT INTO dbo.Torneos
 (nombre_torneo, fecha, fecha_hasta, hora_inicio, id_categoria, id_canchero, id_fiscal, max_parejas, precio_inscripcion)
 VALUES
 (@nombre, @fecha, @fechahasta, @hora, @idcat, @idcanchero, @idfiscal, @maxparejas, @precio);
 SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = t.nombre_torneo
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = t.fecha
            cmd.Parameters.Add("@fechahasta", SqlDbType.Date).Value = t.fecha_hasta
            cmd.Parameters.Add("@hora", SqlDbType.Time).Value = t.hora_inicio.TimeOfDay
            cmd.Parameters.Add("@idcat", SqlDbType.Int).Value = t.id_categoria
            cmd.Parameters.Add("@idcanchero", SqlDbType.Int).Value = t.id_canchero
            cmd.Parameters.Add("@idfiscal", SqlDbType.Int).Value = t.id_fiscal
            cmd.Parameters.Add("@maxparejas", SqlDbType.Int).Value = t.max_parejas
            Dim p = cmd.Parameters.Add("@precio", SqlDbType.Decimal)
            p.Precision = 10 : p.Scale = 2 : p.Value = t.precio_inscripcion

            cn.Open()
            Return CInt(cmd.ExecuteScalar())
        End Using
    End Function

    '=======================
    ' LISTAR (OBJETOS)  ✅
    '=======================
    Public Function Listar() As List(Of Torneo)
        Const sql As String =
"SELECT  id_torneo, nombre_torneo, fecha, fecha_hasta, hora_inicio,
         id_categoria, id_canchero, id_fiscal, max_parejas, precio_inscripcion, estado
   FROM dbo.Torneos
   ORDER BY fecha DESC, nombre_torneo;"

        Dim lista As New List(Of Torneo)
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cn.Open()
            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    Dim t As New Torneo With {
                        .id_torneo = rd.GetInt32(0),
                        .nombre_torneo = rd.GetString(1),
                        .fecha = rd.GetDateTime(2),
                        .fecha_hasta = rd.GetDateTime(3),
                        .hora_inicio = Date.Today.Add(rd.GetTimeSpan(4)),
                        .id_categoria = rd.GetInt32(5),
                        .id_canchero = rd.GetInt32(6),
                        .id_fiscal = rd.GetInt32(7),
                        .max_parejas = rd.GetInt32(8),
                        .precio_inscripcion = rd.GetDecimal(9),
                        .estado = rd.GetString(10)   ' ✅ Nuevo campo calculado
                    }
                    lista.Add(t)
                End While
            End Using
        End Using
        Return lista
    End Function

    '=======================
    ' LISTAR (DATATABLE)
    '=======================
    Public Function ListarDataTable() As DataTable
        Const sql As String =
"SELECT  T.id_torneo          AS IdTorneo,
         T.nombre_torneo      AS Nombre,
         T.max_parejas        AS MaxParejas,
         T.precio_inscripcion AS PrecioInscripcion,
         T.fecha              AS Fecha,
         T.fecha_hasta        AS FechaHasta,
         T.hora_inicio        AS HoraInicio,
         C.nombre_cat         AS Categoria,
         UC.nombre_usuario    AS Canchero,
         UF.nombre_usuario    AS Fiscal,
         T.estado             AS Estado
  FROM dbo.Torneos T
  JOIN dbo.Categoria C ON C.id_categoria = T.id_categoria
  JOIN dbo.Usuarios  UC ON UC.id_usuario = T.id_canchero
  JOIN dbo.Usuarios  UF ON UF.id_usuario = T.id_fiscal
  ORDER BY T.fecha DESC, T.nombre_torneo;"

        Using cn = Conexion.GetConnection(), da As New SqlDataAdapter(sql, cn)
            Dim dt As New DataTable()
            da.Fill(dt)
            Return dt
        End Using
    End Function

    '=======================
    ' EXISTS  ✅
    '=======================
    Public Function ExisteAlguno() As Boolean
        Const sql As String = "SELECT TOP 1 1 FROM dbo.Torneos;"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cn.Open()
            Dim o = cmd.ExecuteScalar()
            Return o IsNot Nothing
        End Using
    End Function

    '=======================
    ' GET BY ID
    '=======================
    Public Function ObtenerPorId(id As Integer) As Torneo
        Const sql As String =
"SELECT id_torneo, nombre_torneo, fecha, fecha_hasta, hora_inicio,
        id_categoria, id_canchero, id_fiscal, max_parejas, precio_inscripcion, estado
  FROM dbo.Torneos WHERE id_torneo=@id;"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
            cn.Open()
            Using rd = cmd.ExecuteReader()
                If Not rd.Read() Then Return Nothing
                Return New Torneo With {
                    .id_torneo = rd.GetInt32(0),
                    .nombre_torneo = rd.GetString(1),
                    .fecha = rd.GetDateTime(2),
                    .fecha_hasta = rd.GetDateTime(3),
                    .hora_inicio = Date.Today.Add(rd.GetTimeSpan(4)),
                    .id_categoria = rd.GetInt32(5),
                    .id_canchero = rd.GetInt32(6),
                    .id_fiscal = rd.GetInt32(7),
                    .max_parejas = rd.GetInt32(8),
                    .precio_inscripcion = rd.GetDecimal(9),
                    .estado = rd.GetString(10)   ' ✅ Campo calculado
                }
            End Using
        End Using
    End Function

    '=======================
    ' UPDATE
    '=======================
    Public Sub Actualizar(t As Torneo)
        Const sql As String =
"UPDATE dbo.Torneos
   SET nombre_torneo=@nombre, fecha=@fecha, fecha_hasta=@fechahasta, hora_inicio=@hora,
       id_categoria=@idcat, id_canchero=@idcanchero, id_fiscal=@idfiscal,
       max_parejas=@maxparejas, precio_inscripcion=@precio
 WHERE id_torneo=@id;"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = t.id_torneo
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = t.nombre_torneo
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = t.fecha
            cmd.Parameters.Add("@fechahasta", SqlDbType.Date).Value = t.fecha_hasta
            cmd.Parameters.Add("@hora", SqlDbType.Time).Value = t.hora_inicio.TimeOfDay
            cmd.Parameters.Add("@idcat", SqlDbType.Int).Value = t.id_categoria
            cmd.Parameters.Add("@idcanchero", SqlDbType.Int).Value = t.id_canchero
            cmd.Parameters.Add("@idfiscal", SqlDbType.Int).Value = t.id_fiscal
            cmd.Parameters.Add("@maxparejas", SqlDbType.Int).Value = t.max_parejas
            Dim p = cmd.Parameters.Add("@precio", SqlDbType.Decimal)
            p.Precision = 10 : p.Scale = 2 : p.Value = t.precio_inscripcion

            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

End Module
