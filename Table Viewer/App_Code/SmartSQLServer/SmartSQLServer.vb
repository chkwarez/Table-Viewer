Namespace Smart
    Public Class SmartSQLServer
        Private Adapter As SmartDataAdapter

        Public Sub New(ByVal existingAdapter As SmartDataAdapter)
            Adapter = existingAdapter
        End Sub

        Public Sub New(ByVal connectionString As String)
            Connect(connectionString)
        End Sub

        Public Sub Connect(ByVal connectionString As String)
            Adapter = New SmartDataAdapter(connectionString)
        End Sub

        Public Sub Disconnect()
            Adapter.CloseConnection()
        End Sub

        Public Function GetTable(ByVal databaseName As String, ByVal tableName As String) As SQLServerTable
            Return New SQLServerTable(Adapter, databaseName, tableName)
        End Function
    End Class
End Namespace