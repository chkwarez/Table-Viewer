Namespace Smart
    Public Class SqlForeignKey
        Public ConstraintId As Integer
        Public Name As String
        Public ColumnName As String
        Public RefObjectId As Integer
        Public RefTableSchema As String
        Public RefTableName As String
        Public RefColumnName As String

        Public Sub New()

        End Sub
    End Class
End Namespace