Imports System.Data
Imports System.Data.SqlClient

Public Module RepositorioParejas

    ' Inserta (o reutiliza) jugadores, crea la pareja e inscribe en el torneo
    Public Sub AgregarBD(t As Torneo, jugador1 As String, jugador2 As String, estado As String)
        If t Is Nothing Then Throw New ArgumentNullException(NameOf(t))

        Const sql As String = "
BEGIN TRY
    BEGIN TRAN;

    DECLARE @idj1 INT = (SELECT TOP(1) id_jugador FROM dbo.Jugador WHERE nombre = @n1);
    IF @idj1 IS NULL
    BEGIN
        INSERT INTO dbo.Jugador (nombre, apellido, id_categoria)
        VALUES (@n1, '', @idCategoria);
        SET @idj1 = CAST(SCOPE_IDENTITY() AS INT);
    END

    DECLARE @idj2 INT = (SELECT TOP(1) id_jugador FROM dbo.Jugador WHERE nombre = @n2);
    IF @idj2 IS NULL
    BEGIN
        INSERT INTO dbo.Jugador (nombre, apellido, id_categoria)
        VALUES (@n2, '', @idCategoria);
        SET @idj2 = CAST(SCOPE_IDENTITY() AS INT);
    END

    DECLARE @idPareja INT = (
        SELECT TOP(1) id_pareja
        FROM dbo.Parejas
        WHERE (id_jugador1=@idj1 AND id_jugador2=@idj2)
           OR (id_jugador1=@idj2 AND id_jugador2=@idj1)
    );
    IF @idPareja IS NULL
    BEGIN
        INSERT INTO dbo.Parejas (id_jugador1, id_jugador2)
        VALUES (@idj1, @idj2);
        SET @idPareja = CAST(SCOPE_IDENTITY() AS INT);
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Inscripcion WHERE id_torneo=@idTorneo AND id_pareja=@idPareja)
    BEGIN
        INSERT INTO dbo.Inscripcion (estado_validacion, id_pareja, id_torneo)
        VALUES (@estado, @idPareja, @idTorneo);
    END

    COMMIT TRAN;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRAN;
    THROW;
END CATCH;
"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@idTorneo", SqlDbType.Int).Value = t.id_torneo
            cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = t.id_categoria
            cmd.Parameters.Add("@n1", SqlDbType.VarChar, 100).Value = jugador1.Trim()
            cmd.Parameters.Add("@n2", SqlDbType.VarChar, 100).Value = jugador2.Trim()

            ' Mapear UI -> valores válidos del CHECK
            Dim estadoNormalizado As String
            Select Case estado.Trim().ToUpperInvariant()
                Case "PENDIENTE" : estadoNormalizado = "Pendiente"
                Case "SEÑA", "SENA", "PAGO TOTAL"
                    estadoNormalizado = "Validado" ' o "Rechazado" según tu criterio
                Case Else
                    estadoNormalizado = "Pendiente"
            End Select

            cmd.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = estadoNormalizado

            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub


    Public Function Listar(t As Torneo) As List(Of ParejaTorneo)
        Dim lista As New List(Of ParejaTorneo)

        Const sql As String = "
SELECT  i.id_inscripcion                           AS IdInscripcion,
        p.id_pareja                                AS IdPareja,
        COALESCE(NULLIF(RTRIM(j1.nombre),''),'')   AS Jugador1,
        COALESCE(NULLIF(RTRIM(j2.nombre),''),'')   AS Jugador2,
        COALESCE(NULLIF(RTRIM(i.estado_validacion),''),'Pendiente') AS SeniaOPago,
        i.id_torneo                                AS IdTorneo
FROM dbo.Inscripcion i
JOIN dbo.Parejas   p  ON p.id_pareja   = i.id_pareja
JOIN dbo.Jugador   j1 ON j1.id_jugador = p.id_jugador1
JOIN dbo.Jugador   j2 ON j2.id_jugador = p.id_jugador2
WHERE i.id_torneo = @idTorneo
ORDER BY j1.nombre, j2.nombre;"

        Using cn = Conexion.GetConnection(), cmd As New SqlClient.SqlCommand(sql, cn)
            cmd.Parameters.Add("@idTorneo", SqlDbType.Int).Value = t.id_torneo
            cn.Open()
            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    lista.Add(New ParejaTorneo With {
                    .IdInscripcion = CInt(rd("IdInscripcion")),
                    .id_pareja = CInt(rd("IdPareja")),
                    .Jugador1 = rd("Jugador1").ToString(),
                    .Jugador2 = rd("Jugador2").ToString(),
                    .SeniaOPago = rd("SeniaOPago").ToString(),
                    .id_torneo = CInt(rd("IdTorneo"))
                })
                End While
            End Using
        End Using

        Return lista
    End Function


    ' Eliminar inscripción (si lo necesitás en la grilla)
    Public Sub Eliminar(t As Torneo, p As ParejaTorneo)
        Const sql As String = "DELETE FROM dbo.Inscripcion WHERE id_inscripcion=@id;"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = p.IdInscripcion
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Module
