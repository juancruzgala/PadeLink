Imports System.Data
Imports System.Data.SqlClient

Public Module RepositorioParejas

    ' ===============================
    ' Alta/inscripción de pareja
    ' ===============================

    Public Sub AgregarBD(t As Torneo, jugador1 As String, jugador2 As String, estado As String,
                         dni1 As String, dni2 As String)

        If t Is Nothing Then Throw New ArgumentNullException(NameOf(t))
        If String.IsNullOrWhiteSpace(jugador1) OrElse String.IsNullOrWhiteSpace(jugador2) Then
            Throw New ArgumentException("Debe indicar el nombre de ambos jugadores.")
        End If
        If String.IsNullOrWhiteSpace(dni1) OrElse String.IsNullOrWhiteSpace(dni2) Then
            Throw New ArgumentException("Los DNI de ambos jugadores son obligatorios.")
        End If
        If dni1.Trim() = dni2.Trim() Then
            Throw New ArgumentException("Los DNI no pueden ser iguales (no se puede inscribir a la misma persona dos veces).")
        End If

        ' Validación simple (7–9 dígitos). La BD además impone CHECK.
        Dim re As New System.Text.RegularExpressions.Regex("^\d{7,9}$")
        If Not re.IsMatch(dni1) OrElse Not re.IsMatch(dni2) Then
            Throw New ArgumentException("Formato de DNI inválido (debe tener 7 a 9 dígitos).")
        End If

        ' Validar estado contra los 3 permitidos por la BD (CHECK)
        Dim estadoNormalizado As String = NormalizarEstadoPago(estado) ' "No pago" | "Seña" | "Pago Total"

        Const sql As String =
"BEGIN TRY
    BEGIN TRAN;

    -- Buscar/crear jugador 1 por DNI
    DECLARE @idj1 INT = (SELECT TOP(1) id_jugador FROM dbo.Jugador WHERE dni = @dni1);
    IF @idj1 IS NULL
    BEGIN
        INSERT INTO dbo.Jugador (nombre, apellido, id_categoria, dni)
        VALUES (@n1, '', @idCategoria, @dni1);
        SET @idj1 = CAST(SCOPE_IDENTITY() AS INT);
    END

    -- Buscar/crear jugador 2 por DNI
    DECLARE @idj2 INT = (SELECT TOP(1) id_jugador FROM dbo.Jugador WHERE dni = @dni2);
    IF @idj2 IS NULL
    BEGIN
        INSERT INTO dbo.Jugador (nombre, apellido, id_categoria, dni)
        VALUES (@n2, '', @idCategoria, @dni2);
        SET @idj2 = CAST(SCOPE_IDENTITY() AS INT);
    END

    -- Bloquear parejas con el mismo jugador
    IF @idj1 = @idj2
    BEGIN
        THROW 51010, 'No se puede crear una pareja con el mismo jugador (DNIs coinciden).', 1;
    END

    -- Buscar/crear la pareja
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

    -- Inscribir en el torneo si no existe
    IF NOT EXISTS (SELECT 1 FROM dbo.Inscripcion WHERE id_torneo=@idTorneo AND id_pareja=@idPareja)
    BEGIN
        INSERT INTO dbo.Inscripcion (estado_validacion, id_pareja, id_torneo)
        VALUES (@estado, @idPareja, @idTorneo);
    END

    COMMIT TRAN;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT>0 ROLLBACK TRAN;
    THROW;
END CATCH;"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@idTorneo", SqlDbType.Int).Value = t.id_torneo
            cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = t.id_categoria
            cmd.Parameters.Add("@n1", SqlDbType.VarChar, 100).Value = jugador1.Trim()
            cmd.Parameters.Add("@n2", SqlDbType.VarChar, 100).Value = jugador2.Trim()
            cmd.Parameters.Add("@dni1", SqlDbType.VarChar, 15).Value = dni1.Trim()
            cmd.Parameters.Add("@dni2", SqlDbType.VarChar, 15).Value = dni2.Trim()
            cmd.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = estadoNormalizado
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function NormalizarEstadoPago(valor As String) As String
        If valor Is Nothing Then Return "No pago"
        Select Case valor.Trim()
            Case "No pago", "Seña", "Pago Total"
                Return valor.Trim()
            Case Else
                Return "No pago"
        End Select
    End Function

    ' ===============================
    ' Listar inscripciones del torneo
    ' ===============================
    Public Function Listar(t As Torneo) As List(Of ParejaTorneo)
        Dim lista As New List(Of ParejaTorneo)

        Const sql As String =
"SELECT  i.id_inscripcion                                        AS IdInscripcion,
        p.id_pareja                                             AS IdPareja,
        COALESCE(NULLIF(RTRIM(j1.nombre),''),'')                AS Jugador1,
        COALESCE(NULLIF(RTRIM(j2.nombre),''),'')                AS Jugador2,
        COALESCE(NULLIF(RTRIM(i.estado_validacion),''),'No pago') AS SeniaOPago,
        i.id_torneo                                             AS IdTorneo
FROM dbo.Inscripcion i
JOIN dbo.Parejas   p  ON p.id_pareja   = i.id_pareja
JOIN dbo.Jugador   j1 ON j1.id_jugador = p.id_jugador1
JOIN dbo.Jugador   j2 ON j2.id_jugador = p.id_jugador2
WHERE i.id_torneo = @idTorneo
ORDER BY j1.nombre, j2.nombre;"

        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
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

    ' ===============================
    ' Eliminar inscripción
    ' ===============================
    Public Sub Eliminar(t As Torneo, p As ParejaTorneo)
        Const sql As String = "DELETE FROM dbo.Inscripcion WHERE id_inscripcion=@id;"
        Using cn = Conexion.GetConnection(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = p.IdInscripcion
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

End Module
