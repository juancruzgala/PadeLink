Public Class ParejaTorneo
    Public Property IdInscripcion As Integer
    Public Property id_pareja As Integer
    Public Property id_torneo As Integer
    Public Property id_jugador1 As Integer
    Public Property id_jugador2 As Integer
    Public Property Jugador1 As String
    Public Property Jugador2 As String
    Public Property SeniaOPago As String

    ' <<< NUEVO: lo que usa la columna DataPropertyName = "Pareja"
    Public ReadOnly Property Pareja As String
        Get
            Dim j1 = If(Jugador1, "").Trim()
            Dim j2 = If(Jugador2, "").Trim()
            If j1 = "" AndAlso j2 = "" Then Return ""
            Return $"{j1} / {j2}"
        End Get
    End Property
End Class
