Namespace Smart
    Public Class SqlTable : Inherits SqlDatabaseObject
        Dim CachedColumns As ColumnNameDataTypePair()

#Region "Must Inherit Implementation"
        Public Overrides ReadOnly Property ObjectType() As String
            Get
                Return CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.Table)
            End Get
        End Property
        Private SystemObjectType As String = CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.SystemTable)
        Public Overrides Function GetDeleteSQL() As String
            Return "DROP TABLE " & FullName
        End Function
        Private _Columns As SortedDictionary(Of String, SqlColumn)
        Public ReadOnly Property Columns() As SortedDictionary(Of String, SqlColumn)
            Get
                Return _Columns
            End Get
        End Property
#End Region

#Region "Constructor"
        Public Sub New(ada As SmartDataAdapter, databaseName As String, id As Integer)
            MyBase.New(ada, databaseName, id)
            RefreshColumnCache()
        End Sub

        Public Sub New(ada As SmartDataAdapter, databaseName As String, tableName As String)
            MyBase.New(ada, databaseName, tableName)
            RefreshColumnCache()
        End Sub
#End Region

#Region "Schema & Columns"
        Public Sub RefreshColumnCache()
            Dim cols As SqlColumn() = SqlColumn.CreateFromTableSchema(Me)
            _Columns = New SortedDictionary(Of String, SqlColumn)
            For Each c As SqlColumn In cols
                _Columns.Add(c.Name, c)
            Next
        End Sub

        Public Overridable Function GetTableSchema() As DataTable
            Dim dt As DataTable
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT TOP 1 * FROM " + FullName + " WHERE 1 = 2", CommandType.Text)
            dt = Adapter.GetTableSchemaFromSelectCommand()

            'Add additional columns for supplementary
            dt.Columns.Add("Description", GetType(String))
            dt.Columns.Add("DefaultValue", GetType(String))
            dt.Columns.Add("ColumnId", GetType(Integer))
            dt.Columns.Add("ComputedExpression", GetType(String))

            Dim dictDesc = BatchTable.ExportToDictionary(GetAllColumnsDescription(), "ColumnName", "Description")
            Dim dictDef = BatchTable.ExportToDictionary(GetAllColumnDefaultValues(), "ColumnName", "DefaultValue")

            For n As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(n)("Description") = If(dictDesc.ContainsKey(dt.Rows(n)("ColumnName").ToString()), dictDesc(dt.Rows(n)("ColumnName").ToString()), "")
                dt.Rows(n)("DefaultValue") = If(dictDef.ContainsKey(dt.Rows(n)("ColumnName").ToString()), dictDef(dt.Rows(n)("ColumnName").ToString()), "")

                Dim extr As DataRow = GetColumnId(dt.Rows(n)("ColumnName").ToString())
                If extr IsNot Nothing Then
                    dt.Rows(n)("ColumnId") = CInt(extr("column_id"))
                    dt.Rows(n)("ComputedExpression") = extr("definition").ToString()
                End If
            Next

            Return dt
        End Function

        Public Overridable Function GetPrimaryKeys() As String()
            Return (From c In Columns Where c.Value.IsKey = True Select c.Value.Name).ToArray()
        End Function

        Public Function GetColumns(type As ColumnType) As SqlColumn()
            Select Case type
                Case ColumnType.AllColumns, ColumnType.Asterisk
                    Return (From c In Columns Order By c.Value.Ordinal Select c.Value).ToArray()
                Case ColumnType.PrimaryKeys
                    Return (From c In Columns Where c.Value.IsKey = True Order By c.Value.Ordinal Select c.Value).ToArray()
                Case ColumnType.NonPrimaryKeys
                    Return (From c In Columns Where c.Value.IsKey = False Order By c.Value.Ordinal Select c.Value).ToArray()
            End Select
            Return Nothing
        End Function

        Public Function GetColumnNames(type As ColumnType) As String()
            Select Case type
                Case ColumnType.AllColumns, ColumnType.Asterisk
                    Return (From c In Columns Order By c.Value.Ordinal Select c.Value.Name).ToArray()
                Case ColumnType.PrimaryKeys
                    Return (From c In Columns Order By c.Value.Ordinal Where c.Value.IsKey = True Select c.Value.Name).ToArray()
                Case ColumnType.NonPrimaryKeys
                    Return (From c In Columns Order By c.Value.Ordinal Where c.Value.IsKey = False Select c.Value.Name).ToArray()
                Case ColumnType.WritableAndKeys
                    Return (From c In Columns Order By c.Value.Ordinal Where c.Value.IsKey = True Or c.Value.[ReadOnly] = False Select c.Value.Name).ToArray()
            End Select
            Return Nothing
        End Function

        Public Function ConcatColumnNames(columnNames As String(), tableAlias As String) As String
            If Not tableAlias = "" Then tableAlias = tableAlias & "."

            Dim sb As New System.Text.StringBuilder()
            For n As Integer = 0 To columnNames.Length - 1
                If n = 0 Then
                    sb.Append(tableAlias & CHK.Database.SmartCommandBuilder.GetFormattedColumnName(columnNames(n)))
                Else
                    sb.Append("," & tableAlias & CHK.Database.SmartCommandBuilder.GetFormattedColumnName(columnNames(n)))
                End If
            Next
            Return sb.ToString()
        End Function

        Public Function GetAutoIncrementColumn() As String
            Return (From c In Columns Where c.Value.IsAutoIncrement = True Select c.Value.Name).FirstOrDefault()
        End Function
#End Region

#Region "Data"
        Public Function GetData(sql As String, startRow As Integer, length As Nullable(Of Integer), ByRef totalRecordCount As Integer) As DataTable
            Dim srcTable As DataTable
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(sql, CommandType.Text)
            srcTable = Adapter.GetDataTable() 'Structure + Data
            totalRecordCount = srcTable.Rows.Count  'Total Number of Record

            'The following procedure will make Data slow, we have to determine some shortcut
            If startRow = 0 Then 'Start from first row
                If length.HasValue = False Then 'Unlimited Record
                    Return srcTable
                Else 'Limited Record
                    If srcTable.Rows.Count <= length.Value Then Return srcTable
                End If
            End If

            Dim refinedTable As New DataTable
            Dim n As Integer
            Dim startIndex As Integer, endIndex As Integer
            Dim pk As String() = GetPrimaryKeys()
            refinedTable = srcTable.Clone() 'Structure + Empty

            'Determine Row Index Range
            startIndex = startRow
            If length.HasValue Then 'Record Limit
                endIndex = Math.Min(startIndex + length.Value - 1, srcTable.Rows.Count - 1)
            Else 'All
                endIndex = srcTable.Rows.Count - 1
            End If

            'Copy Content
            For n = startIndex To endIndex
                BatchTable.Copy(srcTable.Rows(n), refinedTable, pk)
            Next

            refinedTable.AcceptChanges()
            Return refinedTable
        End Function

        Public Function GetFastData(sqlData As String, sqlCount As String, ByRef totalRecordCount As Integer) As DataTable
            Dim src As DataTable
            Adapter.ChangeDatabase(Database)

            'Get Count
            Adapter.SetSelectCommand(sqlCount, CommandType.Text)
            Dim k As Object = Adapter.ExecuteScalar(CommandName.Select)
            If k Is Nothing Then Throw New ApplicationException("The count sql does not return an integer, please correct")
            totalRecordCount = StringConverter.ToInteger(k.ToString(), -1)

            'Get Structure and Data
            Adapter.SetSelectCommand(sqlData, CommandType.Text)
            src = Adapter.GetDataTable() 'Structure + Data
            Return src
        End Function

        Public Sub UpdateData(changesTable As DataTable)
            FlushTableInAdapter(True)
            Adapter.Update(changesTable, PrepareParameterMode.BuildSQL)
        End Sub

        ''' <summary>
        ''' Clear all data in the table
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Truncate()
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("TRUNCATE TABLE " & FullName, CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub
#End Region

#Region "Column Operation"
        Public Sub RenameColumn(oldColumnName As String, newColumnName As String)
            Dim sql As String = "EXECUTE sp_rename N'" & FullName & "." & oldColumnName & "', '" & newColumnName & "', 'COLUMN'"
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(sql, CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub

        Public Sub ChangeColumnDataType(columnName As String, newDataType As String)
            Dim sql As String = "ALTER TABLE " & FullName & " ALTER COLUMN [" & columnName & "] " & newDataType
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(sql, CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub

        Public Sub AddColumn(columnName As String, dataType As String, allowNull As Boolean, initValue As String)
            Adapter.ChangeDatabase(Database)

            If initValue Is Nothing Then 'Direct Add Column
                Adapter.SetSelectCommand("ALTER TABLE " & FullName & " ADD [" & columnName & "] " & dataType & If(allowNull, "", " NOT NULL"), CommandType.Text)
                Adapter.ExecuteNonQuery(CommandName.Select)
            Else
                'Add NULL column
                Adapter.SetSelectCommand("ALTER TABLE " & FullName & " ADD [" & columnName & "] " & dataType, CommandType.Text)
                Adapter.ExecuteNonQuery(CommandName.Select)

                'Set initial value
                Adapter.SetSelectCommand("UPDATE " & FullName & " SET [" & columnName & "] = '" & initValue & "'", CommandType.Text)
                Adapter.ExecuteNonQuery(CommandName.Select)

                'Set back the NOT NULL column
                If allowNull = False Then
                    Adapter.SetSelectCommand("ALTER TABLE " & FullName & " ALTER COLUMN [" & columnName & "] " & dataType & " NOT NULL", CommandType.Text)
                    Adapter.ExecuteNonQuery(CommandName.Select)
                End If
            End If
        End Sub

        Public Sub DropColumn(columnName As String)
            Dim sql As String = "ALTER TABLE " & FullName & " DROP COLUMN [" & columnName & "]"
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(sql, CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub
#End Region

#Region "Script and Query"
        Public Overrides Function GetDefinition(isCreate As Boolean) As String
            'Throw New ApplicationException("The table definition cannot be obtained by this function")
            Return MyBase.GetDefinition(isCreate)
        End Function

        ''' <summary>
        ''' In the adapter, the command builder is used to generate SQL, since the adapter is shared,
        ''' while the comand builder is adjusted whenever the adapter has get table,
        ''' the table is required to flush at the adapter so that the command builder can generate the SQL for this table correctly.
        ''' </summary>
        Private Sub FlushTableInAdapter()
            FlushTableInAdapter(False)
        End Sub

        Private Sub FlushTableInAdapter(isInsertOrUpdate As Boolean)
            Adapter.ChangeDatabase(Database)

            Dim builder As New SqlQueryBuilder(Me)
            If isInsertOrUpdate Then
                Adapter.SetSelectCommand(builder.GetSelectSQL("", ColumnType.WritableAndKeys, "1=2"), CommandType.Text)
                Adapter.GetDataTable()
            Else 'Select
                Adapter.SetSelectCommand(builder.GetSelectSQL("", ColumnType.Asterisk, "1=2"), CommandType.Text)
                Adapter.GetDataTable() 'Do not need to get the data, but the command builder is flushed
            End If
        End Sub
#End Region

#Region "Column, Keys, Foreign Keys additional properties"
        Public Function GetColumnDescription(columnName As String) As String
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT value FROM fn_listextendedproperty(N'MS_Description', N'SCHEMA', N'" & Schema & "', N'TABLE', N'" & Name & "', N'COLUMN', N'" & columnName & "')", CommandType.Text)
            Return Adapter.ExecuteScalarString(CommandName.Select)
        End Function

        Public Function GetAllColumnsDescription() As DataTable
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(My.Resources.SystemQueryResource.GetAllColumnDesc, System.Data.CommandType.Text)
            Adapter.SetSelectCommandParameter("ObjectID", Me.ObjectID)
            Return Adapter.GetDataTable()
        End Function

        Public Function GetColumnDefaultValue(columnName As String) As String
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT COLUMN_DEFAULT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA=@TABLE_SCHEMA AND TABLE_NAME=@TABLE_NAME AND COLUMN_NAME=@COLUMN_NAME", CommandType.Text)
            Adapter.SetSelectCommandParameter("TABLE_SCHEMA", Schema)
            Adapter.SetSelectCommandParameter("TABLE_NAME", Name)
            Adapter.SetSelectCommandParameter("COLUMN_NAME", columnName)
            Return Adapter.ExecuteScalarString(CommandName.Select)
        End Function

        Public Function GetAllColumnDefaultValues() As DataTable
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT COLUMN_NAME AS ColumnName, COLUMN_DEFAULT AS DefaultValue FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA=@TABLE_SCHEMA AND TABLE_NAME=@TABLE_NAME AND COLUMN_DEFAULT IS NOT NULL", CommandType.Text)
            Adapter.SetSelectCommandParameter("TABLE_SCHEMA", Schema)
            Adapter.SetSelectCommandParameter("TABLE_NAME", Name)
            Return Adapter.GetDataTable()
        End Function

        Public Function GetColumnId(columnName As String) As DataRow
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT column_id, definition FROM sys.computed_columns WHERE object_id = @object_id AND name = @name", CommandType.Text)
            Adapter.SetSelectCommandParameter("object_id", ObjectID)
            Adapter.SetSelectCommandParameter("name", columnName)
            Dim dt As DataTable = Adapter.GetDataTable()
            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt.Rows(0)
            End If
        End Function

        Public Function GetConstraints() As SqlConstraint()
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT s.constid,ct.name,OBJECT_DEFINITION(constid) AS 'CheckClause' FROM sys.sysconstraints AS s INNER JOIN sys.sysobjects AS ct ON s.constid = ct.id WHERE ct.xtype = 'C' AND s.id=@id", CommandType.Text)
            Adapter.SetSelectCommandParameter("id", ObjectID)
            Dim dt As DataTable = Adapter.GetDataTable()

            Dim list As New List(Of SqlConstraint)
            For n As Integer = 0 To dt.Rows.Count - 1
                Dim c As New SqlConstraint()
                c.Name = dt.Rows(n)("name").ToString()
                c.ConstraintId = CInt(dt.Rows(n)("constid"))
                c.CheckClause = dt.Rows(n)("CheckClause").ToString()
                list.Add(c)
            Next

            Return list.ToArray()
        End Function

        Public Function GetForeignKeys() As SqlForeignKey()
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(My.Resources.SystemQueryResource.GetTableForeignKeys, CommandType.Text)
            Adapter.SetSelectCommandParameter("parent_object_id", ObjectID)
            Dim dt As DataTable = Adapter.GetDataTable()

            Dim list As New List(Of SqlForeignKey)
            For n As Integer = 0 To dt.Rows.Count - 1
                Dim c As New SqlForeignKey()
                c.ConstraintId = CInt(dt.Rows(n)("const_object_id"))
                c.Name = dt.Rows(n)("name").ToString()
                c.ColumnName = dt.Rows(n)("parent_col").ToString()
                c.RefObjectId = CInt(dt.Rows(n)("ref_object_id"))
                c.RefTableSchema = dt.Rows(n)("ref_schema").ToString()
                c.RefTableName = dt.Rows(n)("ref_table").ToString()
                c.RefColumnName = dt.Rows(n)("ref_col").ToString()
                list.Add(c)
            Next

            Return list.ToArray()
        End Function

        Public Function GetIndices() As SqlIndex()
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(My.Resources.SystemQueryResource.GetTableIndices, CommandType.Text)
            Adapter.SetSelectCommandParameter("object_id", ObjectID)
            Adapter.SetSelectCommandParameter("index_type", "IX")
            Dim dt As DataTable = Adapter.GetDataTable()

            Dim list As New List(Of SqlUniqueKey)
            Dim uk As SqlUniqueKey = Nothing
            For n As Integer = 0 To dt.Rows.Count - 1
                Dim indexId As Integer = CInt(dt.Rows(n)("index_id"))

                If uk Is Nothing OrElse uk.IndexId <> indexId Then
                    uk = New SqlUniqueKey()
                    uk.TableObjectId = ObjectID
                    uk.IndexId = indexId
                    uk.Name = dt.Rows(n)("index_name").ToString()
                    list.Add(uk)
                End If

                Dim c As New SqlIndexColumn
                c.ColumnId = CInt(dt.Rows(n)("column_id"))
                c.ColumnName = dt.Rows(n)("column_name").ToString()
                c.Ordinal = CInt(dt.Rows(n)("key_ordinal"))
                c.IsInclude = CBool(dt.Rows(n)("is_included_column"))
                uk.Columns.Add(c)
            Next

            Return list.ToArray()
        End Function

        Public Function GetUniqueKeys() As SqlUniqueKey()
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(My.Resources.SystemQueryResource.GetTableIndices, CommandType.Text)
            Adapter.SetSelectCommandParameter("object_id", ObjectID)
            Adapter.SetSelectCommandParameter("index_type", "UK")
            Dim dt As DataTable = Adapter.GetDataTable()

            Dim list As New List(Of SqlUniqueKey)
            Dim uk As SqlUniqueKey = Nothing
            For n As Integer = 0 To dt.Rows.Count - 1
                Dim indexId As Integer = CInt(dt.Rows(n)("index_id"))

                If uk Is Nothing OrElse uk.IndexId <> indexId Then
                    uk = New SqlUniqueKey()
                    uk.TableObjectId = ObjectID
                    uk.IndexId = indexId
                    uk.Name = dt.Rows(n)("index_name").ToString()
                    list.Add(uk)
                End If

                Dim c As New SqlIndexColumn
                c.ColumnId = CInt(dt.Rows(n)("column_id"))
                c.ColumnName = dt.Rows(n)("column_name").ToString()
                c.Ordinal = CInt(dt.Rows(n)("key_ordinal"))
                uk.Columns.Add(c)
            Next

            Return list.ToArray()
        End Function

        Public Sub SetColumnDescription(columnName As String, desc As String)
            Dim dt As DataTable

            desc = SqlQueryBuilder.EncodeText(desc)

            'Check Extended Property existence
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT value FROM fn_listextendedproperty(N'MS_Description', N'SCHEMA', N'" & Schema & "', N'TABLE', N'" & Name & "', N'COLUMN', N'" & columnName & "')", CommandType.Text)
            dt = Adapter.GetDataTable()

            If dt.Rows.Count > 0 Then 'Exteneded Property Exists
                Adapter.SetSelectCommand("EXEC sp_updateextendedproperty N'MS_Description', N'" & desc & "', N'SCHEMA', N'" & Schema & "', N'TABLE', N'" & Name & "', N'COLUMN', N'" & columnName & "'", CommandType.Text)
            Else 'New Extended Property
                Adapter.SetSelectCommand("EXEC sp_addextendedproperty N'MS_Description', N'" & desc & "', N'SCHEMA', N'" & Schema & "', N'TABLE', N'" & Name & "', N'COLUMN', N'" & columnName & "'", CommandType.Text)
            End If
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub

        Public Function GetIdentityColumnLastValue() As Integer?
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT IDENT_CURRENT('" & FullName & "') )", CommandType.Text)
            Dim k = Adapter.ExecuteScalar(CommandName.Select)
            If TypeOf k Is Integer Then
                Return CInt(k)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetColumnDefinition(columnName As String) As String
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT COLUMN_DEFAULT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA=@TABLE_SCHEMA AND TABLE_NAME=@TABLE_NAME AND COLUMN_NAME=@COLUMN_NAME", CommandType.Text)
            Adapter.SetSelectCommandParameter("TABLE_SCHEMA", Schema)
            Adapter.SetSelectCommandParameter("TABLE_NAME", Name)
            Adapter.SetSelectCommandParameter("COLUMN_NAME", columnName)
            Dim dt As DataTable = Adapter.GetDataTable
            If dt.Rows.Count = 0 Then Throw New Exception("Column name " & columnName & " is not found, definition cannot be retrieved.")
            Dim r = dt.Rows(0)

            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("ALTER TABLE " & FullName & " ADD [" & r("COLUMN_NAME").ToString() & "] " &
                          r("DATA_TYPE").ToString() &
                          If(r("IS_NULLABLE").ToString() = "YES", "", " NOT NULL"))

            Return sb.ToString()
        End Function
#End Region

#Region "Identity"
        Public Function GetCurrentIdentity() As Integer?
            Adapter.SetSelectCommand("SELECT IDENT_CURRENT('" & FullName & "')", CommandType.Text)
            Dim obj = Adapter.ExecuteScalar(CommandName.Select)
            Return CHK.StringConverter.ToIntegerNull(obj.ToString())
        End Function

        Public Sub SetIdentity(seedValue As Integer)
            Adapter.SetSelectCommand("dbcc checkident ('" & FullName & "', RESEED, " & seedValue & ")", CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub
#End Region

#Region "Enum"
        Public Enum ColumnType
            AllColumns
            Asterisk
            PrimaryKeys
            NonPrimaryKeys
            WritableAndKeys
            None
        End Enum

        Public Structure ColumnNameDataTypePair
            Public Name As String
            Public DataType As String
            Public SystemDataType As String
        End Structure
#End Region
    End Class
End Namespace
