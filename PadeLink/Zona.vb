Public Class Zona
    Public Property Nombre As String                     ' Ejemplo: "A", "B", "C"
    Public Property Parejas As List(Of ParejaTorneo)     ' Lista de parejas asignadas a esa zona
    Public Property Partidos As List(Of Partido)         ' Lista de partidos dentro de esa zona
End Class