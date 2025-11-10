Imports System.Data.SqlClient

Public Class Conexion
    Public Shared Function GetConnection() As SqlConnection
        ' Ajustá la cadena a tu servidor y base
        Dim connectionString As String = "Server=localhost;Database=PadeLink;Trusted_Connection=True;"
        Return New SqlConnection(connectionString)
    End Function
End Class
