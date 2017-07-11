Namespace Smart
    Public Class SqlColumn : Implements IComparable(Of SqlColumn)
        Public ColumnId As Integer
        Public Name As String
        Public Ordinal As Integer
        Public DefaultValue As String
        Public IsNullable As Boolean
        Public IsUnique As Boolean
        Public DataType As String
        Public SystemDataType As Type
        Public Description As String
        Public IsKey As Boolean
        Public IsAutoIncrement As Boolean
        Public [ReadOnly] As Boolean
        Public ComputedExpression As String
        Public ColumnSize As Integer?

        Public Sub New(ByVal name As String)
            Me.Name = name
        End Sub

        Public Shared Function CreateFromTableSchema(ByVal table As SqlTable) As SqlColumn()
            Dim dt As DataTable = table.GetTableSchema()
            Dim list As New List(Of SqlColumn)

            For n As Integer = 0 To dt.Rows.Count - 1
                Dim c As New SqlColumn(dt.Rows(n)("ColumnName").ToString())
                c.Ordinal = CInt(dt.Rows(n)("ColumnOrdinal"))
                c.IsNullable = CBool(dt.Rows(n)("AllowDBNull"))
                c.IsUnique = CBool(dt.Rows(n)("IsUnique"))
                c.IsKey = CBool(dt.Rows(n)("IsKey"))
                c.IsAutoIncrement = CBool(dt.Rows(n)("IsAutoIncrement"))
                c.DataType = dt.Rows(n)("DataTypePrint").ToString()
                c.SystemDataType = Type.GetType(dt.Rows(n)("DataType").ToString())
                c.Description = dt.Rows(n)("Description").ToString()
                c.DefaultValue = dt.Rows(n)("DefaultValue").ToString()
                c.ReadOnly = CBool(dt.Rows(n)("IsReadOnly"))
                If TypeOf dt.Rows(n)("ColumnSize") Is Integer Then c.ColumnSize = CInt(dt.Rows(n)("ColumnSize"))
                If TypeOf dt.Rows(n)("ColumnId") Is Integer Then c.ColumnId = CInt(dt.Rows(n)("ColumnId"))
                c.ComputedExpression = dt.Rows(n)("ComputedExpression").ToString()
                list.Add(c)
            Next

            Return (From t In list Order By t.Ordinal Select t).ToArray()
        End Function

        Public Function CompareTo(ByVal other As SqlColumn) As Integer Implements System.IComparable(Of SqlColumn).CompareTo
            Return Me.Ordinal.CompareTo(other.Ordinal)
        End Function
    End Class
End Namespace