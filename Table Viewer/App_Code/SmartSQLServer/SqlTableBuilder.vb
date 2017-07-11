Namespace Smart
    Public Class SqlTableBuilder
        Dim Table As SqlTable

#Region "Constructor"
        Public Sub New()

        End Sub

        Public Sub New(ByVal t As SqlTable)
            Table = t
        End Sub
#End Region

#Region "Script New Table"
        Public Function GetEmptySchemaTable() As DataTable
            Dim dtTable As New DataTable
            dtTable.TableName = "NewTable"
            dtTable.Columns.Add("ColumnName", GetType(String))
            dtTable.Columns.Add("DataType", GetType(String))
            dtTable.Columns.Add("ColumnOrdinal", GetType(Integer)) 'Coloumn Order
            dtTable.Columns.Add("IsUnique", GetType(Boolean))
            dtTable.Columns.Add("IsKey", GetType(Boolean))
            dtTable.Columns.Add("AllowDBNull", GetType(Boolean))
            dtTable.Columns.Add("IsAutoIncrement", GetType(Boolean))
            dtTable.Columns.Add("Description", GetType(String))
            Return dtTable
        End Function

        Public Function GetSchemaTable() As DataTable
            Dim dt As DataTable = GetEmptySchemaTable()
            If Table Is Nothing Then Throw New ApplicationException("The public variable Table is not initialized")
            Dim src As DataTable = Table.GetTableSchema()
            BatchTable.Copy(src, dt, New String() {"ColumnName"})
            Dim mapping As New BatchTable.TableColumnMapping()
            mapping.Add("ColumnName", "ColumnName", True)
            mapping.Add("DataTypePrint", "DataType", False)
            BatchTable.CopyByMapping(src, dt, mapping)
            dt.TableName = Table.Name 'Do not get the schema name, because you usually can't create with non-exist schemas in the other database
            Return dt
        End Function

        Public Function GetCreateSQL(ByVal dtTable As DataTable, Optional ByVal ignoreAutoIncrement As Boolean = False) As String
            Dim n As Integer
            Dim columnName As String, dataType As String, constraints As String
            Dim sql As New System.Text.StringBuilder
            Dim pks As New List(Of String)

            CheckSchemaTable(dtTable)

            sql.AppendLine("CREATE TABLE [" & CommonProperty.UserDefaultSchema & "].[" & dtTable.TableName & "] (")
            dtTable.DefaultView.Sort = "ColumnOrdinal asc"
            For n = 0 To dtTable.Rows.Count - 1
                With dtTable.DefaultView(n)
                    columnName = .Item("ColumnName").ToString()
                    dataType = .Item("DataType").ToString()

                    constraints = ""
                    If TypeOf .Item("IsKey") Is Boolean AndAlso CBool(.Item("IsKey")) = True Then pks.Add(columnName)
                    If ignoreAutoIncrement = False AndAlso TypeOf .Item("IsAutoIncrement") Is Boolean AndAlso CBool(.Item("IsAutoIncrement")) = True Then constraints &= " IDENTITY(1,1)"

                    If TypeOf .Item("AllowDBNull") Is Boolean Then
                        If CBool(.Item("AllowDBNull")) = True Then
                            constraints &= " NULL"
                        Else
                            constraints &= " NOT NULL"
                        End If
                    End If

                    If TypeOf .Item("IsUnique") Is Boolean AndAlso CBool(.Item("IsUnique")) = True Then constraints &= " UNIQUE"

                    sql.AppendLine(columnName & " " & dataType & constraints & ",")
                End With
            Next

            If pks.Count = 0 Then
                sql.AppendLine(")")
            Else
                sql.AppendLine("CONSTRAINT [PK_" & dtTable.TableName & "] PRIMARY KEY CLUSTERED (")
                sql.AppendLine(String.Join(",", pks.ToArray))
                sql.AppendLine(") WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]")
                sql.AppendLine(") ON [PRIMARY]")
            End If

            Return sql.ToString()
        End Function

        Private Shared Function CheckSchemaTable(ByVal dtTable As DataTable) As Boolean
            Dim hasAI As Boolean = False

            For n As Integer = 0 To dtTable.Rows.Count - 1
                With dtTable.DefaultView(n)
                    Dim columnName As String = .Item("ColumnName").ToString()
                    If columnName = "" Then Throw New ApplicationException("Column name cannot be empty")

                    If .Item("DataType").ToString() = "" Then Throw New ApplicationException("The datatype for column " & columnName & " is missing")

                    If TypeOf .Item("IsKey") Is Boolean AndAlso CBool(.Item("IsKey")) = True AndAlso TypeOf .Item("AllowDBNull") Is Boolean AndAlso CBool(.Item("AllowDBNull")) = True Then
                        Throw New ApplicationException("Primary key [" & columnName & "] does not allow DBNull")
                    End If

                    If TypeOf .Item("IsAutoIncrement") Is Boolean AndAlso CBool(.Item("IsAutoIncrement")) = True Then
                        If hasAI = False Then
                            hasAI = True
                        Else
                            Throw New ApplicationException("Only one column in a table can be auto-increment")
                        End If
                    End If
                End With
            Next

            Return True
        End Function
#End Region

#Region "Miscellaneous Function"
        Public Shared Function GetSerializedColumnNames(ByVal col As String(), ByVal tableAlias As String) As String
            Dim isFirst As Boolean = True
            Dim result As String = ""
            Dim n As Integer

            If Not tableAlias = "" Then tableAlias &= "."
            For n = 0 To col.Length - 1
                If isFirst = True Then
                    result = tableAlias & col(n)
                    isFirst = False
                Else
                    result &= "," & tableAlias & col(n)
                End If
            Next

            Return result
        End Function
#End Region

#Region "Structure"
        Public Enum SearchType
            Normal = 2
            PartialMatch = 3
            Star = 5
            DateBetween = 7
        End Enum

        Public Structure SearchColumn
            Dim Name As String
            Dim Types As Integer
            Dim CombinedVariableName As String
        End Structure
#End Region
    End Class
End Namespace