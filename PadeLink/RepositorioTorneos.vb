Imports System.Collections.Generic

Public Class RepositorioTorneos
    Public Shared ReadOnly Torneos As New List(Of Torneo)()

    Public Shared Sub AgregarTorneo(t As Torneo)
        If t Is Nothing Then Throw New ArgumentNullException(NameOf(t))
        Torneos.Add(t)
        ' Si más adelante querés refresco automático:
        ' RaiseEvent TorneosCambiaron()
    End Sub

    Public Shared Function Listar() As List(Of Torneo)
        Return Torneos.ToList()
    End Function

    ' Public Shared Event TorneosCambiaron()
End Class