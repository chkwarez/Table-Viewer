Namespace Smart
    Public Class SqlQueryBuilder
        Dim table As SqlTable
        Dim table2 As SqlTable

#Region "Constructor"
        Public Sub New(t As SqlTable)
            table = t
        End Sub

        Public Sub New(t As SqlTable, t2 As SqlTable)
            table = t
            table2 = t2
        End Sub
#End Region

#Region "Single Table: Script SQL"
        Public Function GetSelectSQL(tableAlias As String, showColumnType As SqlTable.ColumnType, whereClause As String) As String
            Return GetSelectSQL(tableAlias, showColumnType, whereClause, "", Nothing)
        End Function

        Public Function GetSelectSQL(tableAlias As String, showColumnType As SqlTable.ColumnType, whereClause As String, orderClause As String) As String
            Return GetSelectSQL(tableAlias, showColumnType, whereClause, orderClause, Nothing)
        End Function

        Public Function GetSelectSQL(tableAlias As String, showColumnType As SqlTable.ColumnType, whereClause As String, orderClause As String, limit As Nullable(Of Integer)) As String
            Dim tmp As String, sql As String
            If showColumnType = SqlTable.ColumnType.Asterisk Then
                If tableAlias = "" Then
                    tmp = "*"
                Else
                    tmp = tableAlias & ".*"
                End If
            Else
                tmp = GetSerializedColumnNames(table.GetColumnNames(showColumnType), tableAlias)
            End If

            If limit.HasValue Then
                tmp = "TOP " & limit.ToString() & " " & tmp
            End If

            If tableAlias = "" Then
                sql = "SELECT " & tmp & " FROM " & table.FullName
            Else
                sql = "SELECT " & tmp & " FROM " & table.FullName & " AS " & tableAlias
            End If

            If Not whereClause = "" Then sql &= " WHERE " & whereClause
            If Not orderClause = "" Then sql &= " ORDER BY " & orderClause
            Return sql
        End Function

        Public Function GetCountSQL(Optional whereClause As String = "") As String
            Dim sql As String
            sql = "SELECT COUNT(*) FROM " & table.FullName
            If Not whereClause = "" Then sql &= " WHERE " & whereClause
            Return sql
        End Function

        Public Function GetDeleteSQL(Optional whereClause As String = "") As String
            Dim sql As String
            sql = "DELETE FROM " & table.FullName
            If Not whereClause = "" Then sql &= " WHERE " & whereClause
            Return sql
        End Function

        Public Function GetUpdateSQL(showColumnType As SqlTable.ColumnType, Optional whereClause As String = "") As String
            Dim sql As String, tmp As String
            sql = "UPDATE " & table.FullName & " SET" & vbCrLf

            Dim cols As Smart.SqlColumn() = table.GetColumns(showColumnType)
            For n As Integer = 0 To cols.Length - 1
                tmp = cols(n).Name & " = @" & cols(n).Name
                If n < cols.Length - 1 Then tmp &= "," 'Add Comma between each statement
                sql &= tmp & vbCrLf
            Next

            If Not whereClause = "" Then sql &= "WHERE " & whereClause
            Return sql
        End Function

        Public Function GetInsertSQL(showColumnType As SqlTable.ColumnType) As String
            Dim tmp As String = "", tmp2 As String = "", sql As String = ""
            Dim n As Integer

            sql = "INSERT INTO " & table.FullName
            Dim cols As Smart.SqlColumn() = table.GetColumns(showColumnType)
            For n = 0 To cols.Length - 1
                If n = 0 Then
                    tmp = cols(n).Name
                    tmp2 = "@" & cols(n).Name
                Else
                    tmp &= "," & vbCrLf & cols(n).Name
                    tmp2 &= "," & vbCrLf & "@" & cols(n).Name
                End If
            Next
            sql = sql & vbCrLf & "(" & vbCrLf & tmp & vbCrLf & ")" & vbCrLf & "VALUES" & vbCrLf & "(" & vbCrLf & tmp2 & vbCrLf & ")"

            Return sql
        End Function

        Public Function GetTruncateSQL() As String
            Return "TRUNCATE TABLE " & table.FullName
        End Function

        Public Function GetDropSQL(ifExist As Boolean) As String
            If ifExist Then
                Return "IF OBJECT_ID('" & table.FullName & "', 'U') IS NOT NULL DROP TABLE " & table.FullName
            Else
                Return "DROP TABLE " & table.FullName
            End If
        End Function

        Public Function GetSelectGroupBySQL(groupColumnNames As String(), tableAlias As String, whereClause As String) As String
            Dim sql = "SELECT " & table.ConcatColumnNames(groupColumnNames, tableAlias) & ",COUNT(*) AS [Count]" &
                        " FROM " & table.FullName & If(tableAlias = "", "", " AS " & tableAlias)

            If Not whereClause = "" Then sql &= " WHERE " & whereClause

            sql &= " GROUP BY " & table.ConcatColumnNames(groupColumnNames, tableAlias)
            sql &= " ORDER BY " & table.ConcatColumnNames(groupColumnNames, tableAlias)

            Return sql
        End Function

        Public Function GetTableRowCount() As String
            Dim sql = "SELECT rows FROM sys.partitions AS pa WHERE pa.object_id = OBJECT_ID('" & table.FullName & "') AND pa.index_id IN (1,0)"
            Return sql
        End Function
#End Region

#Region "Single Table: Script Stored Procedure"
        Public Function GetSelectStoredProcedure(spName As String, isCreate As Boolean) As String
            Dim sql As New System.Text.StringBuilder

            'Generate Header
            If isCreate = True Then
                sql.AppendLine("CREATE PROCEDURE [" & table.Schema & "].[" & spName & "]")
            Else
                sql.AppendLine("ALTER PROCEDURE [" & table.Schema & "].[" & spName & "]")
            End If

            Dim n As Integer
            Dim cols As SqlColumn() = table.GetColumns(SqlTable.ColumnType.PrimaryKeys)

            For n = 0 To cols.Length - 1
                If n = cols.Length - 1 Then
                    sql.AppendLine("@" & cols(n).Name & Chr(9) & cols(n).DataType)
                Else
                    sql.AppendLine("@" & cols(n).Name & Chr(9) & cols(n).DataType & ",")
                End If
            Next

            sql.AppendLine("AS" & vbCrLf & "BEGIN" & vbCrLf & "SET NOCOUNT ON;" & vbCrLf)

            'Generate Body
            sql.AppendLine("SELECT * FROM " & table.FullName & vbCrLf & "WHERE")
            For n = 0 To cols.Length - 1
                If n = 0 Then
                    sql.AppendLine(cols(n).Name & " = @" & cols(n).Name)
                Else
                    sql.AppendLine("AND " & cols(n).Name & " = @" & cols(n).Name)
                End If
            Next

            sql.AppendLine(vbCrLf & "END")
            Return sql.ToString()
        End Function

        Public Function GetInsertStoredProcedure(spName As String, isCreate As Boolean) As String
            Dim sql As New System.Text.StringBuilder

            'Generate Header
            If isCreate = True Then
                sql.AppendLine("CREATE PROCEDURE [" & table.Schema & "].[" & spName & "]")
            Else
                sql.AppendLine("ALTER PROCEDURE [" & table.Schema & "].[" & spName & "]")
            End If

            Dim n As Integer
            Dim cols As Smart.SqlColumn() = table.GetColumns(SqlTable.ColumnType.AllColumns)

            For n = 0 To cols.Length - 1
                If n = cols.Length - 1 Then
                    sql.AppendLine("@" & cols(n).Name & Chr(9) & cols(n).DataType)
                Else
                    sql.AppendLine("@" & cols(n).Name & Chr(9) & cols(n).DataType & ",")
                End If
            Next

            sql.AppendLine("AS" & vbCrLf & "BEGIN" & vbCrLf & "SET NOCOUNT ON;" & vbCrLf)

            'Generate Body
            sql.AppendLine("INSERT INTO " & table.FullName & vbCrLf & "(")
            For n = 0 To cols.Length - 1
                If n = cols.Length - 1 Then
                    sql.AppendLine(cols(n).Name)
                Else
                    sql.AppendLine(cols(n).Name & ",")
                End If
            Next
            sql.AppendLine(")" & vbCrLf & "VALUES" & vbCrLf & "(")
            For n = 0 To cols.Length - 1
                If n = cols.Length - 1 Then
                    sql.AppendLine("@" & cols(n).Name)
                Else
                    sql.AppendLine("@" & cols(n).Name & ",")
                End If
            Next
            sql.AppendLine(")")

            sql.AppendLine(vbCrLf & "END")
            Return sql.ToString()
        End Function

        Public Function GetUpdateStoredProcedure(spName As String, isCreate As Boolean) As String
            Dim sql As New System.Text.StringBuilder

            'Generate Header
            If isCreate = True Then
                sql.AppendLine("CREATE PROCEDURE [" & table.Schema & "].[" & spName & "]")
            Else
                sql.AppendLine("ALTER PROCEDURE [" & table.Schema & "].[" & spName & "]")
            End If

            Dim n As Integer
            Dim colPK As Smart.SqlColumn() = table.GetColumns(SqlTable.ColumnType.PrimaryKeys)
            Dim colNonPK As Smart.SqlColumn() = table.GetColumns(SqlTable.ColumnType.NonPrimaryKeys)

            For n = 0 To colPK.Length - 1
                If n = colPK.Length - 1 And colNonPK.Length = 0 Then
                    sql.AppendLine("@" & colPK(n).Name & Chr(9) & colPK(n).DataType)
                Else
                    sql.AppendLine("@" & colPK(n).Name & Chr(9) & colPK(n).DataType & ",")
                End If
            Next
            For n = 0 To colNonPK.Length - 1
                If n = colNonPK.Length - 1 Then
                    sql.AppendLine("@" & colNonPK(n).Name & Chr(9) & colNonPK(n).DataType)
                Else
                    sql.AppendLine("@" & colNonPK(n).Name & Chr(9) & colNonPK(n).DataType & ",")
                End If
            Next

            sql.AppendLine("AS" & vbCrLf & "BEGIN" & vbCrLf & "SET NOCOUNT ON;" & vbCrLf)

            'Generate Body
            sql.AppendLine("UPDATE " & table.FullName & vbCrLf & "SET")
            For n = 0 To colNonPK.Length - 1
                If n = colNonPK.Length - 1 Then
                    sql.AppendLine(colNonPK(n).Name & " = @" & colNonPK(n).Name)
                Else
                    sql.AppendLine(colNonPK(n).Name & " = @" & colNonPK(n).Name & ",")
                End If
            Next
            sql.AppendLine("WHERE")
            For n = 0 To colPK.Length - 1
                If n = 0 Then
                    sql.AppendLine(colPK(n).Name & " = @" & colPK(n).Name)
                Else
                    sql.AppendLine("AND " & colPK(n).Name & " = @" & colPK(n).Name)
                End If
            Next

            sql.AppendLine(vbCrLf & "END")
            Return sql.ToString()
        End Function

        Public Function GetDeleteStoredProcedure(spName As String, isCreate As Boolean) As String
            Dim sql As New System.Text.StringBuilder

            'Generate Header
            If isCreate = True Then
                sql.AppendLine("CREATE PROCEDURE [" & table.Schema & "].[" & spName & "]")
            Else
                sql.AppendLine("ALTER PROCEDURE [" & table.Schema & "].[" & spName & "]")
            End If

            Dim n As Integer
            Dim cols As Smart.SqlColumn() = table.GetColumns(SqlTable.ColumnType.PrimaryKeys)

            For n = 0 To cols.Length - 1
                If n = cols.Length - 1 Then
                    sql.AppendLine("@" & cols(n).Name & Chr(9) & cols(n).DataType)
                Else
                    sql.AppendLine("@" & cols(n).Name & Chr(9) & cols(n).DataType & ",")
                End If
            Next

            sql.AppendLine("AS" & vbCrLf & "BEGIN" & vbCrLf & "SET NOCOUNT ON;" & vbCrLf)

            'Generate Body
            sql.AppendLine("DELETE FROM " & table.FullName & vbCrLf & "WHERE")
            For n = 0 To cols.Length - 1
                If n = 0 Then
                    sql.AppendLine(cols(n).Name & " = @" & cols(n).Name)
                Else
                    sql.AppendLine("AND " & cols(n).Name & " = @" & cols(n).Name)
                End If
            Next

            sql.AppendLine(vbCrLf & "END")
            Return sql.ToString()
        End Function

        Public Function GetSearchStoredProcedure(spName As String, isCreate As Boolean, cols As SearchColumn()) As String
            Dim n As Integer, m As Integer
            Dim sql As New System.Text.StringBuilder
            Dim isFirst As Boolean
            Dim tmp As String
            Dim combinedVariables As New List(Of String)

            'Generate Header
            If isCreate = True Then
                sql.AppendLine("CREATE PROCEDURE [" & table.Schema & "].[" & spName & "]")
            Else
                sql.AppendLine("ALTER PROCEDURE [" & table.Schema & "].[" & spName & "]")
            End If

            'Generate Variable Declaration
            isFirst = True
            For n = 0 To cols.Length - 1 'Not Combined Variable
                With cols(n)
                    If Not .CombinedVariableName = "" Then Continue For 'Not Combined Variable
                    If Util.EnumContains(.Types, SearchType.DateBetween, Util.EnumDigitType.Prime) = True Then 'Date Between @S @E
                        tmp = "@" & .Name & "S" & Chr(9) & table.Columns(.Name).DataType
                        tmp &= "," & vbCrLf & "@" & .Name & "E" & Chr(9) & table.Columns(.Name).DataType
                    Else
                        tmp = "@" & .Name & Chr(9) & table.Columns(.Name).DataType
                    End If

                    If isFirst = True Then
                        sql.Append(tmp)
                        isFirst = False
                    Else
                        sql.Append("," & vbCrLf & tmp)
                    End If
                End With
            Next
            For n = 0 To cols.Length - 1 'Combined Variable
                With cols(n)
                    If .CombinedVariableName = "" Then Continue For
                    If combinedVariables.IndexOf(.CombinedVariableName) = -1 Then 'New Combined Variable
                        combinedVariables.Add(.CombinedVariableName)
                        tmp = "@" & .CombinedVariableName & Chr(9) & table.Columns(.Name).DataType

                        If isFirst = True Then
                            sql.Append(tmp)
                            isFirst = False
                        Else
                            sql.Append("," & vbCrLf & tmp)
                        End If
                    End If
                End With
            Next
            sql.AppendLine(vbCrLf & "AS" & vbCrLf & "BEGIN" & vbCrLf & "SET NOCOUNT ON;" & vbCrLf)

            'Generate Body (Not Combined)
            isFirst = True
            sql.AppendLine("SELECT *")
            sql.AppendLine("FROM " & table.FullName & " AS t")
            sql.AppendLine("WHERE")
            For n = 0 To cols.Length - 1
                With cols(n)
                    If Not .CombinedVariableName = "" Then Continue For 'Use Combined Variable later

                    If Util.EnumContains(.Types, SearchType.DateBetween, Util.EnumDigitType.Prime) Then
                        tmp = "((t." & .Name & " >= @" & .Name & "S AND t." & .Name & " <= @" & .Name & "E) OR (t." & .Name & " >= @" & .Name & "S AND @" & .Name & "E IS NULL) OR (t." & .Name & " <= @" & .Name & "E AND @" & .Name & "S IS NULL) OR (@" & .Name & "S IS NULL AND @" & .Name & "E IS NULL))"
                    ElseIf Util.EnumContains(.Types, SearchType.PartialMatch, Util.EnumDigitType.Prime) Then
                        tmp = "(t." & .Name & " LIKE '%' + @" & .Name & " + '%' OR dbo.IsEmpty(@" & .Name & ") = 1)"
                    ElseIf Util.EnumContains(.Types, SearchType.Star, Util.EnumDigitType.Prime) Then
                        tmp = "(t." & .Name & " = @" & .Name & " OR dbo.IsAll(@" & .Name & ") = 1)"
                    Else
                        tmp = "(t." & .Name & " = @" & .Name & " OR dbo.IsEmpty(@" & .Name & ") = 1)"
                    End If

                    If isFirst = True Then
                        sql.AppendLine(tmp)
                        isFirst = False
                    Else
                        sql.AppendLine("AND " & tmp)
                    End If
                End With
            Next

            'Generate Body (Combined Variable)
            Dim isFirst2 As Boolean, tmp2 As String
            For n = 0 To combinedVariables.Count - 1
                tmp = "("
                isFirst2 = True
                For m = 0 To cols.Length - 1
                    With cols(m)
                        If Not .CombinedVariableName = combinedVariables(n) Then Continue For

                        If Util.EnumContains(.Types, SearchType.PartialMatch, Util.EnumDigitType.Prime) Then
                            tmp2 = "t." & .Name & " LIKE '%' + @" & .CombinedVariableName & " + '%'"
                        Else
                            tmp2 = "t." & .Name & " = @" & .CombinedVariableName
                        End If

                        If isFirst2 = True Then
                            tmp &= tmp2
                            isFirst2 = False
                        Else
                            tmp &= " OR " & tmp2
                        End If
                    End With
                Next
                tmp &= " OR dbo.IsEmpty(@" & combinedVariables(n) & ") = 1)"

                If isFirst = True Then
                    sql.AppendLine(tmp)
                    isFirst = False
                Else
                    sql.AppendLine("AND " & tmp)
                End If
            Next

            sql.AppendLine(vbCrLf & "END")
            Return sql.ToString()
        End Function
#End Region

#Region "Multiple Table: Script SQL"
        Public Function GetInnerJoinArgument(alias1 As String, alias2 As String, includeTable1Name As Boolean) As String
            Dim colsCommonPK As String()
            Dim tmp As String = "", sql As String
            colsCommonPK = GetCommonColumnNames(table.GetColumnNames(SqlTable.ColumnType.PrimaryKeys), table2.GetColumnNames(SqlTable.ColumnType.PrimaryKeys))

            For n As Integer = 0 To colsCommonPK.Length - 1
                If n = 0 Then
                    tmp = alias1 & "." & colsCommonPK(n) & " = " & alias2 & "." & colsCommonPK(n)
                Else
                    tmp &= " AND " & alias1 & "." & colsCommonPK(n) & " = " & alias2 & "." & colsCommonPK(n)
                End If
            Next

            If includeTable1Name Then
                sql = "[" & table.FullName & "] AS " & alias1 & " INNER JOIN [" & table2.FullName & "] AS " & alias2 & vbCrLf & "ON " & tmp
            Else
                sql = "INNER JOIN [" & table2.FullName & "] AS " & alias2 & vbCrLf & "ON " & tmp
            End If

            Return sql
        End Function

        Private Shared Function GetCommonColumnNames(col1 As String(), col2 As String()) As String()
            Dim m As Integer
            Dim ResultPK As New List(Of String)

            For m = 0 To col1.GetUpperBound(0)
                If Array.IndexOf(col2, col1(m)) >= 0 Then
                    ResultPK.Add(col1(m))
                End If
            Next

            Return ResultPK.ToArray()
        End Function
#End Region

#Region "Miscellaneous Function and Static Functions"
        Public Shared Function GetSerializedColumnNames(col As String(), tableAlias As String) As String
            Dim isFirst As Boolean = True
            Dim result As String = ""
            Dim n As Integer

            If Not tableAlias = "" Then tableAlias &= "."
            For n = 0 To col.Length - 1
                If isFirst = True Then
                    If CHK.StringExtension.Contains(CHK.Database.Constants.ReservedWords, col(n), False) Then
                        result = tableAlias & "[" & col(n) & "]"
                    Else
                        result = tableAlias & col(n)
                    End If
                    isFirst = False
                Else
                    If CHK.StringExtension.Contains(CHK.Database.Constants.ReservedWords, col(n), False) Then
                        result &= "," & tableAlias & "[" & col(n) & "]"
                    Else
                        result &= "," & tableAlias & col(n)
                    End If
                End If
            Next

            Return result
        End Function

        ''' <summary>
        ''' Encode the text before it is enclosed by single quote (') at the beginning and the end.
        ''' </summary>
        Public Shared Function EncodeText(text As String) As String
            Dim sb As New System.Text.StringBuilder(text)
            sb.Replace("'", "''")
            sb.Replace(System.Environment.NewLine, "' + CHAR(13) + CHAR(10) + '")
            Return sb.ToString()
        End Function

        Public Shared Function EncodeObjectName(name As String) As String
            If CHK.StringExtension.Contains(CHK.Database.Constants.ReservedWords, name, False) Then
                Return "[" & name & "]"
            Else
                Return name
            End If
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