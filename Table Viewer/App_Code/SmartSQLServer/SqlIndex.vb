Namespace Smart
    Public Class SqlIndex
        Public TableObjectId As Integer
        Public IndexId As Integer
        Public Name As String
        Public Columns As New List(Of SqlIndexColumn)
        Public Overridable ReadOnly Property IsUnique As Boolean
            Get
                Return False
            End Get
        End Property

        Public Sub New()

        End Sub

        Public Function ToColumnString() As String
            Dim sb As New System.Text.StringBuilder()
            For n As Integer = 0 To Columns.Count - 1
                If n = 0 Then
                    sb.Append(Columns(n).ColumnName)
                Else
                    sb.Append(", " & Columns(n).ColumnName)
                End If
            Next
            Return sb.ToString()
        End Function

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Public Structure SqlIndexColumn
        Public ColumnId As Integer
        Public ColumnName As String
        Public Ordinal As Integer
        Public IsInclude As Boolean 'Is Include Column

        Public Overrides Function ToString() As String
            Return Ordinal & ": " & ColumnName
        End Function
    End Structure
End Namespace