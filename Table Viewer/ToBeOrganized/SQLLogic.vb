Public Module SQLLogic
    'Public Function GetSearchArgument(ByVal Adapter As SmartDataAdapter, ByVal InputTable As EnquiryTable, ByVal InputS1 As SearchOption, ByVal InputS2 As SearchOption) As String
    '    Return GetSearchArgument(Adapter, InputTable, InputS1, InputS2, "")
    'End Function

    'Public Function GetSearchArgument(ByVal Adapter As SmartDataAdapter, ByVal InputTable As EnquiryTable, ByVal InputS1 As SearchOption, ByVal InputS2 As SearchOption, ByVal TableAlias As String) As String
    '    Dim sql As String = "", Field As String
    '    Dim SchemaTable As DataTable
    '    Dim d1 As DateTime, d2 As DateTime

    '    If TableAlias <> "" Then
    '        TableAlias += "."
    '    End If
    '    SchemaTable = Adapter.GetTableSchema(InputTable.TableName)

    '    If InputS1 IsNot Nothing AndAlso InputS1.Mode <> SearchMode.Empty Then
    '        'Build the Search SQL, handle for General Key 
    '        Field = GetColumnFromFieldSet(SchemaTable, InputS1.FieldSet)
    '        If InputS1.PartialMatch = False Then
    '            'Must be EQUAL 
    '            sql += " and " + TableAlias + "[" + Field + "] = '" + InputS1.Value1 + "'"
    '        Else
    '            'Allow LIKE (Partial Match) 
    '            sql += " and " + TableAlias + "[" + Field + "] like '%" + InputS1.Value1 + "%'"
    '        End If
    '    End If

    '    If InputS2 IsNot Nothing Then
    '        'Build the Search SQL, handle for DateTime 
    '        If InputS2.Value1 = "" Then
    '            InputS2.Value1 = "01/01/1900"
    '        End If
    '        If InputS2.Value2 = "" Then
    '            InputS2.Value2 = "31/12/9999"
    '        End If
    '        If InputS2.Mode <> SearchMode.Empty Then
    '            Field = GetColumnFromFieldSet(SchemaTable, InputS2.FieldSet)
    '            d1 = DateTime.Parse(InputS2.Value1)
    '            d2 = DateTime.Parse(InputS2.Value2)

    '            sql += " and " + TableAlias + "[" + Field + "] between '" + d1.ToString("MM/dd/yyyy") + "' and '" + d2.ToString("MM/dd/yyyy") + "'"
    '        End If
    '    End If

    '    If InputS1 IsNot Nothing AndAlso InputS1.HasKings = True Then
    '        If Array.IndexOf(SearchOption.WildCard, InputS1.CmpyCd) = -1 Then
    '            sql += " and " + TableAlias + "[" + SearchOption.CmpyCdFieldName + "] = '" + InputS1.CmpyCd + "'"
    '        End If
    '        If Array.IndexOf(SearchOption.WildCard, InputS1.DivCd) = -1 Then
    '            sql += " and " + TableAlias + "[" + SearchOption.DivCdFieldName + "] = '" + InputS1.DivCd + "'"
    '        End If
    '        If Array.IndexOf(SearchOption.WildCard, InputS1.GroupCd) = -1 Then
    '            sql += " and " + TableAlias + "[" + SearchOption.GroupCdFieldName + "] = '" + InputS1.GroupCd + "'"
    '        End If
    '        If Array.IndexOf(SearchOption.WildCard, InputS1.DeptCd) = -1 Then
    '            sql += " and " + TableAlias + "[" + SearchOption.DeptCdFieldName + "] = '" + InputS1.DeptCd + "'"
    '        End If
    '    End If

    '    If sql.StartsWith(" and ") Then
    '        sql = sql.Substring(5)
    '    End If

    '    If sql.Trim() = "" Then
    '        'If Search Critera is not exists 
    '        sql = ""
    '    Else
    '        'Search Criter exists, add where 
    '        sql = "Where " + sql
    '    End If
    '    Return sql
    'End Function

    'Public Function GetGroupByArgument(ByVal Adapter As SmartDataAdapter, ByVal ParentTable As EnquiryTable) As String
    '    Return GetGroupByArgument(Adapter, ParentTable, "")
    'End Function

    'Public Function GetGroupByArgument(ByVal Adapter As SmartDataAdapter, ByVal ParentTable As EnquiryTable, ByVal TableAlias As String) As String
    '    Dim tmp As String() = Adapter.GetTablePrimaryKey(ParentTable.TableName)

    '    If TableAlias <> "" Then
    '        TableAlias += "."
    '    End If

    '    If tmp Is Nothing OrElse tmp.Length = 0 Then
    '        Return ""
    '    Else
    '        Return "Group By " + TableAlias + String.Join(", " + TableAlias, tmp)
    '    End If
    'End Function

    Public Function GetStoredProcedureDefinition(ByVal Adapter As SmartDataAdapter, ByVal SPName As String, ByVal isCreateMode As Boolean) As String
        Dim code As String
        Dim obj As Object

        Adapter.SetSelectCommand("SELECT OBJECT_DEFINITION(id) AS content FROM sys.sysobjects where name='" & SPName & "'", CommandType.Text)
        obj = Adapter.ExecuteScalar()
        code = obj.ToString()

        If isCreateMode = False Then
            code = Replace(code, "CREATE", "ALTER", 1, 1)
        End If

        Return code.Trim()
    End Function

    Public Function GetViewDefinition(ByVal Adapter As SmartDataAdapter, ByVal viewName As String, ByVal isCreateMode As Boolean) As String
        Dim code As String
        Dim obj As Object

        Adapter.SetSelectCommand("SELECT OBJECT_DEFINITION(id) AS content FROM sys.sysobjects where name='" & viewName & "'", CommandType.Text)
        obj = Adapter.ExecuteScalar()
        code = obj.ToString()

        If isCreateMode = False Then
            code = Replace(code, "CREATE", "ALTER", 1, 1)
        End If

        Return code.Trim()
    End Function

    Public Function GetStoredProcedureExecutionCommand(ByVal Adapter As SmartDataAdapter, ByVal SPName As String) As String
        Dim code As String = "", parameter As String, paraArray As String()
        Dim n As Integer

        Adapter.SetSelectCommand(SPName, CommandType.StoredProcedure)
        parameter = Adapter.ExportCommandParameters(CommandName.Select)
        paraArray = parameter.Split(",".ToCharArray())

        'Generate Execution Code
        code = "DECLARE	@return_value int"
        code = code & vbCrLf & "EXEC @return_value = [dbo].[" & SPName & "]"
        code = code & vbCrLf

        For n = 0 To paraArray.Length - 1 'Create Parameter
            If paraArray(n) = "" Then Continue For
            code = code & vbCrLf & paraArray(n) & " = NULL"
            If n < paraArray.Length - 1 Then code = code & ","
        Next

        code = code & vbCrLf & vbCrLf & "SELECT 'Return Value' = @return_value"

        Return code.Trim()
    End Function

    Public Function GetFunctionExecutionCommand(ByVal Adapter As SmartDataAdapter, ByVal funcName As String) As String
        Dim code As String = "", parameter As String, paraArray As String()
        Dim n As Integer

        Adapter.SetSelectCommand(funcName, CommandType.StoredProcedure)
        parameter = Adapter.ExportCommandParameters(CommandName.Select)
        paraArray = parameter.Split(",".ToCharArray())

        'Generate Execution Code
        For n = 0 To paraArray.Length - 1 'Create Parameter
            If paraArray(n) = "" Then Continue For
            code = code & "'" & paraArray(n) & "'"
            If n < paraArray.Length - 1 Then code = code & ","
        Next

        code = "--" & code & vbCrLf & "SELECT dbo." & funcName & "()"

        Return code.Trim()
    End Function

    Public Function GetInnerJoinArgument(ByVal Adapter As SmartDataAdapter, ByVal BaseTable As String, ByVal TargetTable As String, ByVal BaseTableAlias As String, ByVal TargetTableAlias As String, ByVal IncludeBaseTableName As Boolean) As String
        Dim PK1 As String(), PK2 As String(), FinalPK As String()
        PK1 = Adapter.GetTablePrimaryKey(BaseTable)
        PK2 = Adapter.GetTablePrimaryKey(TargetTable)
        FinalPK = GetCommonPrimaryKeys(PK1, PK2)

        Dim final As String = "", TargetTableName As String = ""
        Dim n As Integer
        For n = 0 To FinalPK.Length - 1
            final += " and " + BaseTableAlias + "." + FinalPK(n) + " = " + TargetTableAlias + "." + FinalPK(n)
        Next
        If final.StartsWith(" and ") Then
            final = final.Substring(5)
        End If

        TargetTableName = TargetTable

        If IncludeBaseTableName Then
            final = "[" + BaseTable + "] As " + BaseTableAlias + " INNER JOIN [" + TargetTableName + "] As " + TargetTableAlias + " ON " + final
        Else
            final = " INNER JOIN [" + TargetTableName + "] As " + TargetTableAlias + " ON " + final
        End If

        Return final.Trim()
    End Function

    Private Function GetCommonPrimaryKeys(ByVal PK1 As String(), ByVal PK2 As String()) As String()
        Dim m As Integer
        Dim ResultPK As New List(Of String)

        For m = 0 To PK1.GetUpperBound(0)
            If Array.IndexOf(PK2, PK1(m)) >= 0 Then
                ResultPK.Add(PK1(m))
            End If
        Next

        Return ResultPK.ToArray()
    End Function

    Public Function GetTableColumnName(ByVal Adapter As SmartDataAdapter, ByVal TableName As String, ByVal showPrimaryKeyOnly As Boolean) As String()
        Dim sql As String = ""
        Dim n As Integer
        Dim columnList As New System.Collections.Generic.List(Of String)
        Dim dtTable As DataTable

        dtTable = Adapter.GetTableSchema(TableName)

        For n = 0 To dtTable.Rows.Count - 1
            If showPrimaryKeyOnly = False Then
                columnList.Add(dtTable.Rows(n)("ColumnName").ToString())
            Else
                If CBool(dtTable.Rows(n)("IsKey")) = True Then
                    columnList.Add(dtTable.Rows(n)("ColumnName").ToString())
                End If
            End If
        Next

        Return columnList.ToArray()
    End Function

    Public Function PrintTableColumn(ByVal Adapter As SmartDataAdapter, ByVal TableName As String, ByVal TableAlias As String, ByVal showPrimaryKeyOnly As Boolean) As String
        Dim col As String(), isFirst As Boolean = True
        Dim n As Integer, result As String = ""
        col = GetTableColumnName(Adapter, TableName, showPrimaryKeyOnly)

        If Not TableAlias = "" Then TableAlias &= "."
        For n = 0 To col.Length - 1
            If isFirst = True Then
                result = TableAlias & col(n)
                isFirst = False
            Else
                result &= "," & TableAlias & col(n)
            End If
        Next

        Return result
    End Function

    Public Function GetSelectSQL(ByVal Adapter As SmartDataAdapter, ByVal TableName As String, ByVal TableAlias As String, ByVal showPrimaryKeyOnly As Boolean) As String
        Dim tmp As String, sql As String
        tmp = PrintTableColumn(Adapter, TableName, TableAlias, False)

        If TableAlias = "" Then
            sql = "select " & tmp & " from " & TableName
        Else
            sql = "select " & tmp & " from " & TableName & " as " & TableAlias
        End If
        Return sql
    End Function

    Public Function GetTableList(ByVal Adapter As SmartDataAdapter, ByVal databaseName As String) As DataTable
        Dim dtTable As DataTable
        Adapter.SetSelectCommand("select * from " & databaseName & ".INFORMATION_SCHEMA.TABLES order by TABLE_TYPE, TABLE_NAME", CommandType.Text)
        dtTable = Adapter.GetDataTable()
        Return dtTable
    End Function

    Public Function GetDatabaseList(ByVal Adapter As SmartDataAdapter) As DataTable
        Dim dtTable As DataTable
        Adapter.SetSelectCommand("select [name],database_id,state_desc,create_date from master.sys.databases order by [name]", CommandType.Text)
        dtTable = Adapter.GetDataTable()
        Return dtTable
    End Function

    'Public Function GetSelectSQL(ByVal Adapter As SmartDataAdapter, ByVal InputTable As EnquiryTable, ByVal InputS1 As SearchOption, ByVal InputS2 As SearchOption) As String
    '    Dim SearchArgu As String = GetSearchArgument(Adapter, InputTable, InputS1, InputS2, "t")
    '    Dim sql As String
    '    Dim JoinTableSQL As String = GetInnerJoinViewArgument(Adapter, InputTable, "t", "v", True)

    '    sql = "Select DISTINCT TOP " + MAXIMUM_RECORD.ToString() + " * from " + JoinTableSQL + " " + SearchArgu
    '    Return sql
    'End Function

    'Public Function GetCountSQL(ByVal Adapter As SmartDataAdapter, ByVal InputTable As EnquiryTable, ByVal InputS1 As SearchOption, ByVal InputS2 As SearchOption) As String
    '    Dim SearchArgu As String = GetSearchArgument(Adapter, InputTable, InputS1, InputS2, "")
    '    Dim sql As String
    '    sql = "Select count(*) from " + InputTable.TableName + " " + SearchArgu
    '    Return sql
    'End Function

    'Public Function GetCountSQLFromChild(ByVal Adapter As SmartDataAdapter, ByVal ParentTable As EnquiryTable, ByVal ChildTableIndex As Integer, ByVal InputS1 As SearchOption, ByVal InputS2 As SearchOption) As String
    '    Dim GroupByArgu As String = GetGroupByArgument(Adapter, ParentTable, "t")
    '    Dim ChildTable As EnquiryTable = ParentTable.ChildTable(ChildTableIndex)
    '    Dim SearchArgu As String = GetSearchArgument(Adapter, ChildTable, InputS1, InputS2, "t")
    '    Dim sql As String

    '    sql = "Select count(*) from " + ChildTable.TableName + " As t " + SearchArgu + " " + GroupByArgu + "; Select @@rowcount;"
    '    Return sql
    'End Function

End Module
