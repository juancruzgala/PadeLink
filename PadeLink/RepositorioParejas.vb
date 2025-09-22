Public Class RepositorioParejas
    ' Clave por NOMBRE de torneo (case-insensitive)
    Private Shared _map As New Dictionary(Of String, List(Of ParejaTorneo))(StringComparer.OrdinalIgnoreCase)

    Private Shared Function Clave(t As Torneo) As String
        Return If(t?.Nombre, "").Trim()
    End Function

    Public Shared Function Listar(t As Torneo) As List(Of ParejaTorneo)
        Dim k = Clave(t)
        If Not _map.ContainsKey(k) Then _map(k) = New List(Of ParejaTorneo)
        Return _map(k)
    End Function

    Public Shared Sub Agregar(t As Torneo, p As ParejaTorneo)
        Dim k = Clave(t)
        If Not _map.ContainsKey(k) Then _map(k) = New List(Of ParejaTorneo)
        _map(k).Add(p)
    End Sub

    Public Shared Sub Eliminar(t As Torneo, p As ParejaTorneo)
        Dim k = Clave(t)
        If _map.ContainsKey(k) Then _map(k).Remove(p)
    End Sub

    Public Shared Sub Vaciar(t As Torneo)
        Dim k = Clave(t)
        If _map.ContainsKey(k) Then _map(k).Clear()
    End Sub
End Class