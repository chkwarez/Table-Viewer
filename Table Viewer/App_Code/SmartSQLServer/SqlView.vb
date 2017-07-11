Namespace Smart
    Public Class SqlView : Inherits SqlTable

#Region "Must Inherit Implementation"
        Public Overrides ReadOnly Property ObjectType() As String
            Get
                Return CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.View)
            End Get
        End Property

        Public Overrides Function GetDeleteSQL() As String
            Return "DROP VIEW " & FullName
        End Function
#End Region

#Region "Constructor"
        Public Sub New(ByVal ada As SmartDataAdapter, ByVal databaseName As String, ByVal id As Integer)
            MyBase.New(ada, databaseName, id)
        End Sub

        Public Sub New(ByVal ada As SmartDataAdapter, ByVal databaseName As String, ByVal tableName As String)
            MyBase.New(ada, databaseName, tableName)
        End Sub
#End Region

#Region "Schema and Columns"
        ''' <summary>
        ''' Get the primary key of the view, the primary keys cannot be obtained easily from table schema as it contains multiple columns for all tables even they are not selected
        ''' </summary>
        Public Overrides Function GetPrimaryKeys() As String()
            Dim f As String() = MyBase.GetPrimaryKeys() 'All primary keys from the view even when the key are not selected
            Dim dt As DataTable = Me.GetData("SELECT * FROM " & Me.FullName & " WHERE 1=2", 0, 1, Nothing)

            Dim pks As New List(Of String)
            Dim n As Integer
            For n = 0 To dt.Columns.Count - 1
                If Array.IndexOf(f, dt.Columns(n).ColumnName) >= 0 Then pks.Add(dt.Columns(n).ColumnName) 'The selected primary key
            Next

            Return pks.ToArray()
        End Function

        ''' <summary>
        ''' Get the schema of the view, all base table columns that are not selected are removed.
        ''' </summary>
        Public Overrides Function GetTableSchema() As DataTable
            Dim dt As DataTable = MyBase.GetTableSchema()
            Dim n As Integer

            For n = dt.Rows.Count - 1 To 0 Step -1
                If CBool(dt.Rows(n)("IsHidden")) Then dt.Rows.RemoveAt(n)
            Next

            Return dt
        End Function
#End Region
    End Class
End Namespace