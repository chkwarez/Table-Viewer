Public Class TableViewStatus
    Public TableName As String
    Public WhereConditions As New List(Of String)
    Public Ordering As String
    Public InvisibleColumns As New List(Of String)

    Public Sub New(ByVal tableName As String)
        Me.TableName = tableName
    End Sub
End Class
