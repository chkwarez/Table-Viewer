Namespace Smart
    Public Class SqlDatabase
        Private Adapter As SmartDataAdapter
        Private _name As String = Nothing
        Public Property Name() As String
            Get
                If _name Is Nothing Then Throw New ApplicationException("The name is not set yet.")
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

#Region "Constructor"
        Public Sub New(ByVal ada As SmartDataAdapter, ByVal database As String)
            Adapter = ada
            Name = database
        End Sub
#End Region

#Region "Existence"
        Public Function Exist(objName As String, objType As CommonProperty.DatabaseObject) As Boolean
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand("SELECT * FROM sys.all_objects WHERE name = '" & objName & "' AND type = '" & CommonProperty.GetObjectTypeCode(objType) & "'", CommandType.Text)
            dtTable = Adapter.GetDataTable()
            Return CBool(IIf(dtTable.Rows.Count = 0, False, True))
        End Function
#End Region

#Region "Operation"
        Public Sub Create(newName As String)
            Adapter.SetSelectCommand("CREATE DATABASE [" & newName & "]", CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
            Adapter.ChangeDatabase(newName)
        End Sub

        Public Sub Rename(newName As String)
            Adapter.ChangeDatabase("master")
            Adapter.SetSelectCommand("ALTER DATABASE [" & Name & "] MODIFY NAME = [" & newName & "]", CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
            Adapter.ChangeDatabase(newName)
        End Sub

        Public Sub Drop()
            Drop(Name)
        End Sub

        Public Sub Drop(databaseName As String)
            Adapter.ChangeDatabase("master")
            Adapter.SetSelectCommand("DROP DATABASE [" & databaseName & "]", CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub

        Public Sub Backup(filePath As String)
            Adapter.ChangeDatabase("master")
            Adapter.SetSelectCommand("BACKUP DATABASE [" & Name & "] TO DISK=N'" & filePath.Replace("'", "''") & "'", CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub

        Public Sub Restore(filePath As String, databaseName As String)
            Adapter.ChangeDatabase("master")
            Adapter.SetSelectCommand("RESTORE DATABASE [" & databaseName & "] FROM DISK=N'" & filePath.Replace("'", "''") & "' WITH FILE=1, NOUNLOAD, REPLACE, STATS=10", CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub
#End Region

#Region "Database Object (Single)"
        Public Function NewQuery() As SqlQuery
            Return New SqlQuery(Adapter, Name)
        End Function

        Public Function GetDatbaseObjectById(ByVal objectID As Integer) As SqlDatabaseObject
            Dim dt As DataTable
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand("SELECT obj.name, obj.object_id, sch.name AS schema_name, obj.type FROM sys.all_objects AS obj INNER JOIN sys.schemas AS sch ON obj.schema_id = sch.schema_id WHERE obj.object_id = '" & objectID & "'", CommandType.Text)
            dt = Adapter.GetDataTable()
            If dt.Rows.Count = 0 Then Throw New ApplicationException("The database object with ID " & objectID & " is not found.")

            Dim id As Integer
            With dt.Rows(0)
                id = CInt(dt.Rows(0)("object_id"))
                Select Case .Item("type").ToString().Trim()
                    Case CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.ScalarValuedFunction)
                        Return New SqlScalarValuedFunction(Adapter, Name, id)
                    Case CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.TableValuedFunction)
                        Return New SqlTableValuedFunction(Adapter, Name, id)
                    Case CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.InlineTableFunction)
                        Return New SqlInlineTableFunction(Adapter, Name, id)
                    Case CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.StoredProcedure)
                        Return New SqlStoredProcedure(Adapter, Name, id)
                    Case CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.Table)
                        Return New SqlTable(Adapter, Name, id)
                    Case CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.View)
                        Return New SqlView(Adapter, Name, id)
                    Case Else
                        Throw New ApplicationException("The obejct type " + .Item("type").ToString() + " is not supported")
                End Select
            End With
        End Function

        Public Function GetTable(ByVal tableName As String) As SqlTable
            Return New SqlTable(Adapter, Name, tableName)
        End Function

        Public Function GetTableList() As List(Of SqlTable)
            Dim src As DataTable = GetTables()
            Dim list As New List(Of Smart.SqlTable)
            For n As Integer = 0 To src.Rows.Count - 1
                Dim s As Smart.SqlTable = GetTable(src.Rows(n)("schema_name").ToString() & "." & src.Rows(n)("name").ToString())
                list.Add(s)
            Next
            Return list
        End Function
#End Region

#Region "Database Objects (List)"
        Public Function GetTables() As DataTable
            Return GetList(CommonProperty.DatabaseObject.Table)
        End Function

        Public Function GetSystemViews() As DataTable
            'Be-careful, obj.type is char(2), which will return redundant empty
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand("SELECT obj.*, sch.name AS schema_name FROM sys.all_objects AS obj INNER JOIN sys.schemas AS sch ON obj.schema_id = sch.schema_id WHERE obj.type = 'V' AND sch.name = 'sys' ORDER BY obj.name", CommandType.Text)
            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function

        Public Function GetViews() As DataTable
            Return GetList(CommonProperty.DatabaseObject.View)
        End Function

        Public Function GetStoredProcedures() As DataTable
            Return GetList(CommonProperty.DatabaseObject.StoredProcedure)
        End Function

        Public Function GetTableValuedFunctions() As DataTable
            Return GetList(CommonProperty.DatabaseObject.TableValuedFunction)
        End Function

        Public Function GetInlineTableFunctions() As DataTable
            Return GetList(CommonProperty.DatabaseObject.InlineTableFunction)
        End Function

        Public Function GetScalarValuedFunctions() As DataTable
            Return GetList(CommonProperty.DatabaseObject.ScalarValuedFunction)
        End Function

        Public Function GetTablesAndViews() As DataTable
            Dim dt1 As DataTable = GetTables()
            Dim dt2 As DataTable = GetViews()
            BatchTable.Copy(dt2, dt1, New String() {"object_id"})
            Return dt1
        End Function

        Private Function GetList(ByVal objType As CommonProperty.DatabaseObject) As DataTable
            'Be-careful, obj.type is char(2), which will return redundant empty
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand("SELECT obj.*, sch.name AS schema_name FROM sys.objects AS obj INNER JOIN sys.schemas AS sch ON obj.schema_id = sch.schema_id WHERE obj.type = '" & CommonProperty.GetObjectTypeCode(objType) & "' ORDER BY obj.schema_id, obj.name", CommandType.Text)
            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function

        Public Function GetInformationSchemas() As DataTable
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand("SELECT obj.*, sch.name AS schema_name FROM sys.all_objects AS obj INNER JOIN sys.schemas AS sch ON obj.schema_id = sch.schema_id WHERE sch.name = 'INFORMATION_SCHEMA' AND obj.type = '" & CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.View) & "' ORDER BY obj.schema_id, obj.name", CommandType.Text)
            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function

        Public Function GetViewList() As List(Of SqlView)
            Dim dt As DataTable = GetViews()
            Dim list As New List(Of Smart.SqlView)
            For n As Integer = 0 To dt.Rows.Count - 1
                list.Add(New Smart.SqlView(Adapter, Name, CInt(dt.Rows(n)("object_id"))))
            Next
            Return list
        End Function

        Public Function GetStoredProcedureList() As List(Of SqlStoredProcedure)
            Dim dt As DataTable = GetStoredProcedures()
            Dim list As New List(Of Smart.SqlStoredProcedure)
            For n As Integer = 0 To dt.Rows.Count - 1
                list.Add(New Smart.SqlStoredProcedure(Adapter, Name, CInt(dt.Rows(n)("object_id"))))
            Next
            Return list
        End Function

        Public Function GetScalarValuedFunctionList() As List(Of SqlScalarValuedFunction)
            Dim dt As DataTable = GetScalarValuedFunctions()
            Dim list As New List(Of Smart.SqlScalarValuedFunction)
            For n As Integer = 0 To dt.Rows.Count - 1
                list.Add(New Smart.SqlScalarValuedFunction(Adapter, Name, CInt(dt.Rows(n)("object_id"))))
            Next
            Return list
        End Function

        Public Function GetTableValuedFunctionList() As List(Of SqlTableValuedFunction)
            Dim dt As DataTable = GetTableValuedFunctions()
            Dim list As New List(Of Smart.SqlTableValuedFunction)
            For n As Integer = 0 To dt.Rows.Count - 1
                list.Add(New Smart.SqlTableValuedFunction(Adapter, Name, CInt(dt.Rows(n)("object_id"))))
            Next
            Return list
        End Function

        Public Function GetInlineTableFunctionList() As List(Of SqlInlineTableFunction)
            Dim dt As DataTable = GetInlineTableFunctions()
            Dim list As New List(Of Smart.SqlInlineTableFunction)
            For n As Integer = 0 To dt.Rows.Count - 1
                list.Add(New Smart.SqlInlineTableFunction(Adapter, Name, CInt(dt.Rows(n)("object_id"))))
            Next
            Return list
        End Function
#End Region

#Region "Database Objects (Search)"
        ''' <summary>
        ''' Search the database object within the database
        ''' </summary>
        ''' <param name="objName">The partial name of the stored procedure, must be supplied with '%' for like match</param>
        ''' <param name="modifyDateS">Start range of the modification date</param>
        ''' <param name="modifyDateE">End range of the modification date</param>
        ''' <param name="code">The partial code of the sotred procedure, do not supply '%'</param>
        Public Function Search(ByVal objName As String, ByVal schema As String, ByVal modifyDateS As Date?, ByVal modifyDateE As Date?, ByVal code As String, ByVal objType As CommonProperty.DatabaseObject, ByVal objType2 As CommonProperty.DatabaseObject) As DataTable
            Dim dtTable As DataTable
            If modifyDateE.HasValue Then modifyDateE = modifyDateE.Value.AddDays(1).AddSeconds(-1)
            If Not objName.StartsWith("%") And Not objName.EndsWith("%") Then objName = "%" & objName & "%"

            Adapter.ChangeDatabase(Name) 'Change Database here is not OK
            Adapter.SetCommand(CommandName.Select, My.Resources.SystemQueryResource.SearchDatabaseObjects, CommandType.Text)
            Adapter.SetSelectCommandParameter("@name", objName)
            Adapter.SetSelectCommandParameter("@schema", schema)
            Adapter.SetSelectCommandParameter("@modify_dateS", ConvertNullableDataTypeToDBNull(modifyDateS))
            Adapter.SetSelectCommandParameter("@modify_dateE", ConvertNullableDataTypeToDBNull(modifyDateE))
            Adapter.SetSelectCommandParameter("@code", code)
            Adapter.SetSelectCommandParameter("@obj_type", CommonProperty.GetObjectTypeCode(objType))
            Adapter.SetSelectCommandParameter("@obj_type2", CommonProperty.GetObjectTypeCode(objType2))
            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function

        ''' <summary>
        ''' Search the database object which involved specified table column within the database
        ''' </summary>
        Public Function SearchByColumn(ByVal table As String, ByVal column As String, ByVal datatype As String) As DataTable
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Name) 'Change Database here is not OK
            Adapter.SetCommand(CommandName.Select, GetSearchColumnCommand(), CommandType.Text)
            Adapter.SetSelectCommandParameter("@column", column)
            Adapter.SetSelectCommandParameter("@datatype", datatype)
            Adapter.SetSelectCommandParameter("@table", table)
            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function

        Public Function SearchTableByPrimaryKey(ByVal columnName As String) As Integer()
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Name) 'Change Database here is not OK
            Adapter.SetCommand(CommandName.Select, My.Resources.SystemQueryResource.SearchTableByPrimaryKey, CommandType.Text)
            Adapter.SetSelectCommandParameter("@ColumnName", columnName)
            Adapter.SetSelectCommandParameter("@IsKey", True)
            dtTable = Adapter.GetDataTable()

            Dim list As New List(Of Integer)
            For n As Integer = 0 To dtTable.Rows.Count - 1
                list.Add(CInt(dtTable.Rows(n)("TableObjectID")))
            Next
            Return list.ToArray()
        End Function
#End Region

#Region "Statistics"
        ''' <summary>
        ''' The size of this database in bytes.
        ''' </summary>
        Public ReadOnly Property Size() As Int64
            Get
                Adapter.ChangeDatabase(Name)
                Adapter.SetSelectCommand("SELECT SUM(CAST(size AS bigint) * 8192) as 'size' from sysfiles", CommandType.Text)
                Dim obj As Object = Adapter.ExecuteScalar(CommandName.Select)
                Return CType(obj, Int64)
            End Get
        End Property

        Public ReadOnly Property CreateDate() As DateTime
            Get
                'Any Database is possible
                Adapter.SetSelectCommand("SELECT create_date FROM sys.databases WHERE name = '" + Name + "'", CommandType.Text)
                Dim obj As Object = Adapter.ExecuteScalar(CommandName.Select)
                Return CType(obj, DateTime)
            End Get
        End Property

        Public ReadOnly Property Collation() As String
            Get
                Adapter.ChangeDatabase(Name)
                Adapter.SetSelectCommand("SELECT DATABASEPROPERTYEX('" & Name & "', 'Collation')", CommandType.Text)
                Dim obj As Object = Adapter.ExecuteScalar(CommandName.Select)
                Return obj.ToString()
            End Get
        End Property

        Public ReadOnly Property RecoveryMode As String
            Get
                Adapter.ChangeDatabase(Name)
                Adapter.SetSelectCommand("SELECT DATABASEPROPERTYEX('" & Name & "', 'RECOVERY')", CommandType.Text)
                Dim obj As Object = Adapter.ExecuteScalarString(CommandName.Select)
                Return obj.ToString()
            End Get
        End Property
#End Region

#Region "Data Files and Log Files"
        Public Function GetDataAndLogFiles() As DataTable
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand(My.Resources.SystemQueryResource.GetDatabasesFiles, CommandType.Text)
            Adapter.SetSelectCommandParameter("name", Name)
            Return Adapter.GetDataTable()
        End Function
#End Region

#Region "Database Roles & Users"
        Public Function GetAllUserRoles() As DataTable
            'Be-careful, obj.type is char(2), which will return redundant empty
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand(My.Resources.SystemQueryResource.GetAllUserRoles, CommandType.Text)
            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function

        Public Function GetRestoreHistory() As DataTable
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand(My.Resources.SystemQueryResource.GetDatabaseRestoreHistory, CommandType.Text)
            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function
#End Region

#Region "Miscellaneous Function"
        Public Shared Function ConvertNullableDataTypeToDBNull(ByVal obj As Object) As Object
            If obj Is Nothing Then
                Return DBNull.Value
            Else
                Return obj
            End If
        End Function

        Public Function GetNewGUID() As String
            Dim guid As String
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand("SELECT NEWID()", CommandType.Text)
            guid = Adapter.ExecuteScalarString(CommandName.Select)
            Return guid
        End Function

        Private Shared Function GetSearchColumnCommand() As String
            Dim sql As String
            sql = "SELECT obj.*, sch.name AS schema_name"
            sql &= vbCrLf & "FROM sys.objects AS obj"
            sql &= vbCrLf & "INNER JOIN sys.schemas AS sch ON obj.schema_id = sch.schema_id"
            sql &= vbCrLf & "WHERE"
            sql &= vbCrLf & "(OBJECT_DEFINITION(obj.object_id) like '%@' + @column + '" & Chr(9) & "' + @datatype + '%'"
            sql &= vbCrLf & "OR OBJECT_DEFINITION(obj.object_id) like '%@' + @column + ' ' + @datatype + '%')"
            sql &= vbCrLf & "AND OBJECT_DEFINITION(obj.object_id) like '%' + @table + '%'"
            sql &= vbCrLf & "ORDER BY obj.name"
            Return sql
        End Function
#End Region
    End Class
End Namespace

