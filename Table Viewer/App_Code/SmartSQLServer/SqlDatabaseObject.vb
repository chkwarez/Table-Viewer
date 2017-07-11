Namespace Smart
    Public MustInherit Class SqlDatabaseObject
        Protected Adapter As SmartDataAdapter
        Public Database As String
        Private _name As String = Nothing
        Public Property Name() As String
            Get
                If _name Is Nothing Then Throw New ApplicationException("The name is not set yet.")
                Return _name
            End Get
            Set(ByVal value As String)
                _name = StringExtension.RSStr(value, ".", True)
                If value.Contains(".") Then 'Contains Schema Information
                    UpdateObjectIDAndSchema(StringExtension.LSStr(value, "."), _name)
                Else
                    UpdateObjectIDAndSchema(_name)
                End If
            End Set
        End Property
        Public MustOverride ReadOnly Property ObjectType() As String
        Private _objectID As Integer
        Public Property ObjectID() As Integer
            Get
                Return _objectID
            End Get
            Set(ByVal value As Integer)
                _objectID = value
                UpdateSchemaAndName(value)
            End Set
        End Property
        Public Schema As String
        Public ReadOnly Property FullName() As String
            Get
                If Schema = CommonProperty.UserDefaultSchema Then
                    If Array.IndexOf(CHK.Database.Constants.ReservedWords, Name.ToUpper()) >= 0 Or Name.Contains("&") Then
                        Return "[" & Name & "]"
                    Else
                        Return Name
                    End If
                Else
                    Dim final As String
                    If Array.IndexOf(CHK.Database.Constants.ReservedWords, Schema.ToUpper()) >= 0 Then
                        final = "[" & Schema & "]."
                    Else
                        final = Schema & "."
                    End If
                    If Array.IndexOf(CHK.Database.Constants.ReservedWords, Name.ToUpper()) >= 0 Or Name.Contains("&") Then
                        final &= "[" & Name & "]"
                    Else
                        final &= Name
                    End If
                    Return final
                End If
            End Get
        End Property
        Protected _CreatedDate As Date
        Public ReadOnly Property CreatedDate() As Date
            Get
                Return _CreatedDate
            End Get
        End Property
        Protected _ModifiedDate As Date
        Public ReadOnly Property ModifiedDate() As Date
            Get
                Return _ModifiedDate
            End Get
        End Property


#Region "Constructor"
        Public Sub New(ByVal ada As SmartDataAdapter, ByVal databaseName As String, ByVal objectName As String)
            Adapter = ada
            If databaseName = "" Or objectName = "" Then Throw New ApplicationException("Database or Object name cannot be empty")
            Database = databaseName
            Name = objectName 'Auto Fill others
        End Sub

        Public Sub New(ByVal ada As SmartDataAdapter, ByVal databaseName As String, ByVal inputObjectID As Integer)
            Adapter = ada
            If databaseName = "" Then Throw New ApplicationException("Database cannot be empty")
            Database = databaseName
            ObjectID = inputObjectID 'Auto Fill others
        End Sub
#End Region

#Region "Operation"
        Public Sub Rename(ByVal newName As String)
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("EXEC sp_rename '" & FullName & "', '" & newName & "'", CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub

        Public Sub Delete()
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(GetDeleteSQL(), CommandType.Text)
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub

        ''' <summary>
        ''' Verify the defintion of this database object, the verification is based on creating a transaction for executing the current definition, the transaction is rollbacked after complete.
        ''' This is throughout test of the correctless of the definition but not merely the syntax.
        ''' </summary>
        ''' <param name="errorMsg">Output error message</param>
        Public Function VerifyDefinition(ByRef errorMsg As String) As Boolean
            Dim b As Boolean
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(GetDefinition(False), CommandType.Text)
            b = Adapter.VerifyCommand(CommandName.Select, errorMsg)
            Return b
        End Function
#End Region

#Region "Existence"
        Public Function Exist() As Boolean
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Name)
            Adapter.SetSelectCommand("SELECT * FROM sys.all_objects WHERE object_id = " + _objectID.ToString(), CommandType.Text)
            dtTable = Adapter.GetDataTable()
            Return CBool(IIf(dtTable.Rows.Count = 0, False, True))
        End Function
#End Region

#Region "Script and Query"
        Public Overridable Function GetDefinition(ByVal isCreate As Boolean) As String
            Adapter.SetSelectCommand("SELECT OBJECT_DEFINITION(object_id) AS content FROM sys.objects WHERE object_id = '" & _objectID & "'", CommandType.Text)
            Dim code As String = Adapter.ExecuteScalar(CommandName.Select).ToString()

            If isCreate = False And String.IsNullOrEmpty(code) = False Then
                code = Replace(code, "CREATE", "ALTER", 1, 1)
            End If

            Return code.Trim()
        End Function

        Public MustOverride Function GetDeleteSQL() As String
#End Region

#Region "Dependency"
        Public Function GetDependencyTable() As DataTable
            Dim dtTable As DataTable
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("EXEC sp_depends @objname = N'" & Schema & "." & Name & "'", CommandType.Text)
            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function

        Public Function IsDependenceExist() As Integer
            Dim dt As DataTable = GetDependencyTable()
            Return dt.Rows.Count
        End Function
#End Region

#Region "Miscellaneous Function"
        Private Sub UpdateSchemaAndName(ByVal objectID As Integer)
            Dim dt As DataTable
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT obj.name, obj.object_id, sch.name AS schema_name, obj.create_date, obj.modify_date FROM sys.all_objects AS obj INNER JOIN sys.schemas AS sch ON obj.schema_id = sch.schema_id WHERE obj.object_id = '" & objectID & "' AND obj.type = '" & ObjectType & "'", CommandType.Text)
            dt = Adapter.GetDataTable()

            If dt.Rows.Count = 0 Then Throw New ApplicationException("The database object with ID " & objectID & " is not found.")

            _name = dt.Rows(0)("name").ToString()
            Schema = dt.Rows(0)("schema_name").ToString()
            If TypeOf dt.Rows(0)("create_date") Is Date Then _CreatedDate = CDate(dt.Rows(0)("create_date"))
            If TypeOf dt.Rows(0)("modify_date") Is Date Then _ModifiedDate = CDate(dt.Rows(0)("modify_date"))
        End Sub

        Private Sub UpdateObjectIDAndSchema(ByVal objectName As String)
            Dim dt As DataTable
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT obj.name, obj.object_id, sch.name AS schema_name, obj.create_date, obj.modify_date FROM sys.all_objects AS obj INNER JOIN sys.schemas AS sch ON obj.schema_id = sch.schema_id WHERE obj.name = '" & objectName & "' AND obj.type = '" & ObjectType & "'", CommandType.Text)
            dt = Adapter.GetDataTable()

            If dt.Rows.Count = 0 Then Throw New ApplicationException("The database object " & objectName & " is not found.")
            If dt.Rows.Count > 1 Then Throw New ApplicationException("More than one database object with the same name (but different schema) is found.")

            _objectID = CInt(dt.Rows(0)("object_id"))
            Schema = dt.Rows(0)("schema_name").ToString()
            If TypeOf dt.Rows(0)("create_date") Is Date Then _CreatedDate = CDate(dt.Rows(0)("create_date"))
            If TypeOf dt.Rows(0)("modify_date") Is Date Then _ModifiedDate = CDate(dt.Rows(0)("modify_date"))
        End Sub

        Private Sub UpdateObjectIDAndSchema(ByVal objectSchema As String, ByVal objectName As String)
            Dim dt As DataTable
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand("SELECT obj.name, obj.object_id, sch.name AS schema_name, obj.create_date, obj.modify_date FROM sys.all_objects AS obj INNER JOIN sys.schemas AS sch ON obj.schema_id = sch.schema_id WHERE sch.name='" & objectSchema & "' AND obj.name='" & objectName & "' AND obj.type='" & ObjectType & "'", CommandType.Text)
            dt = Adapter.GetDataTable()

            If dt.Rows.Count = 0 Then Throw New ApplicationException("The database object " & objectSchema & "." & objectName & " is not found.")

            _objectID = CInt(dt.Rows(0)("object_id"))
            Schema = dt.Rows(0)("schema_name").ToString()
            If TypeOf dt.Rows(0)("create_date") Is Date Then _CreatedDate = CDate(dt.Rows(0)("create_date"))
            If TypeOf dt.Rows(0)("modify_date") Is Date Then _ModifiedDate = CDate(dt.Rows(0)("modify_date"))
        End Sub
#End Region
    End Class
End Namespace