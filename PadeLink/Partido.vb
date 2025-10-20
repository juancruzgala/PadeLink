Public Class Partido
    Public Property id_partido As Integer
    Public Property id_torneo As Integer
    Public Property id_grupo As Integer

    Public Property Numero As Integer      ' para mostrar orden en la grilla
    Public Property EquipoA As String
    Public Property EquipoB As String
    Public Property Ronda As Integer

    Public Property Dia As Date?           ' nullable
    Public Property Hora As TimeSpan?      ' nullable
    Public Property Complejo As String
    Public Property Resultado As String
End Class
