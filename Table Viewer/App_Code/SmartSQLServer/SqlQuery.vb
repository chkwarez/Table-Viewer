Imports System.Data.SqlClient
Namespace Smart
    Public Class SqlQuery
        Protected Server As SqlServer
        Protected Adapter As SmartDataAdapter
        Private _database As String
        Public Property Database() As String
            Get
                If _database = "" Then
                    Throw New ApplicationException("The database in the query is not set")
                Else
                    Return _database
                End If
            End Get
            Set(ByVal value As String)
                _database = value
            End Set
        End Property
        Public Text As String

#Region "Constructor"
        Public Sub New(ByVal ada As SmartDataAdapter)
            Adapter = ada
            Database = "master"
        End Sub

        Public Sub New(ByVal ada As SmartDataAdapter, ByVal databaseName As String)
            Adapter = ada
            Database = databaseName
        End Sub
#End Region

#Region "Execution"
        Public Function Execute(ByVal desc As ErrorDescription) As SqlQueryResult()
            If desc = ErrorDescription.SingleDetail Then 'Need to use Predinfed stored procedrure to get the Error Descirption
                If Server Is Nothing Then
                    Throw New ApplicationException("If ErrorDescription is SingleDetails, you must initaialized the Server variable.")
                Else
                    Server.InitializeTemporaryStoredProcedure()
                End If
            End If

            Dim queries As String() = SplitQuery(Text) 'Split the Query into SubQuery
            Dim results As New List(Of SqlQueryResult)
            Try
                For m As Integer = 0 To queries.Length - 1
                    If queries(m).Trim() = String.Empty Then Continue For
                    If desc = ErrorDescription.SingleDetail Then
                        results.Add(RunUnitQueryEx(queries(m)))
                    Else
                        results.Add(RunUnitQuery(queries(m)))
                    End If
                Next
            Catch ex As Exception
                Dim r As New SqlQueryResult()
                r.ErrorSeverity = -999
                r.Message = ex.Message
                r.HasError = True
                results.Add(r)
            End Try

            Return results.ToArray()
        End Function

        Private Function RunUnitQuery(ByVal query As String) As SqlQueryResult
            Dim isCorrect As Boolean = False
            Dim errorMessage As String = ""
            Dim result As New SqlQueryResult

            Adapter.ChangeDatabase(Database)
            AddHandler Adapter.MessageReceived, AddressOf Adapter_MessageReceived
            _tempMessage = ""
            Adapter.SetSelectCommand(query, CommandType.Text)
            result.RecordStart()
            result.Data = Adapter.TryGetDataSet(errorMessage)
            result.RecordEnd()
            RemoveHandler Adapter.MessageReceived, AddressOf Adapter_MessageReceived
            If errorMessage = "" Then 'Success run
                result.HasError = False
                result.Message = _tempMessage
            Else 'Error found
                result.HasError = True
                result.Message = errorMessage
            End If

            Return result
        End Function

        Private Function RunUnitQueryEx(ByVal query As String) As SqlQueryResult
            Dim isCorrect As Boolean = False
            Dim result As New SqlQueryResult

            Adapter.ChangeDatabase(Database)
            AddHandler Adapter.MessageReceived, AddressOf Adapter_MessageReceived
            _tempMessage = ""
            Adapter.SetSelectCommand("##TABLEVIEWER_EXECUTESQL2", CommandType.StoredProcedure)
            Adapter.SetSelectCommandParameter("@statement", query)
            result.RecordStart()
            result.Data = Adapter.GetDataSet()
            result.RecordEnd()
            RemoveHandler Adapter.MessageReceived, AddressOf Adapter_MessageReceived

            result.HasError = False
            result.Message = _tempMessage
            'Detect Error Table
            If result.Data IsNot Nothing AndAlso result.Data.Tables.Count > 0 Then 'Contains table
                With result.Data.Tables(result.Data.Tables.Count - 1) 'Last Table may contains Error
                    If .Columns.IndexOf("TABLE_VIEWER") = 0 Then 'Is Column 0 = TABLE_VIEWER
                        If .Rows.Count = 1 Then 'Is One Row
                            If .Rows(0)(0).ToString() = "TABLE_VIEWER_ERROR" Then 'Is First Cell Value = TABLE_VIEWER_ERROR
                                result.HasError = True
                                result.ErrorNumber = CInt(.Rows(0)("ERROR_NUMBER"))
                                result.ErrorMessage = .Rows(0)("ERROR_MESSAGE").ToString()
                                result.ErrorSeverity = CInt(.Rows(0)("ERROR_SEVERITY"))
                                result.ErrorState = CInt(.Rows(0)("ERROR_STATE"))
                                result.ErrorLine = CInt(.Rows(0)("ERROR_LINE"))
                                result.ErrorProcedure = .Rows(0)("ERROR_PROCEDURE").ToString()
                                result.Data.Tables.RemoveAt(result.Data.Tables.Count - 1) 'Remove the Error Table
                            ElseIf .Rows(0)(0).ToString() = "TABLE_VIEWER_SUCCESS" Then 'Is First Cell Value = TABLE_VIEWER_SUCCESS
                                result.AffectedRows = CInt(.Rows(0)("AffectedRows"))
                                result.Data.Tables.RemoveAt(result.Data.Tables.Count - 1) 'Remove the Success Table
                            End If
                        End If
                    End If
                End With
            End If

            If result.HasError = True Then 'Fill Extra Error Message
                Try
                    Adapter.SetSelectCommand(query, CommandType.Text)
                    Adapter.ExecuteNonQuery(CommandName.Select)
                Catch ex As Exception
                    result.Message = ex.Message
                End Try
            End If

            Return result
        End Function

        Public Sub [Stop]()
            Adapter.CancelCommand(CommandName.Select)
        End Sub

        Private _tempMessage As String = ""
        Private Sub Adapter_MessageReceived(ByVal sender As Object, ByVal args As SqlInfoMessageEventArgs)
            If _tempMessage = "" Then
                _tempMessage = args.Message
            Else
                _tempMessage &= vbCrLf & args.Message
            End If
        End Sub
#End Region

#Region "Fast Execution Result Access"
        ''' <summary>
        ''' Get the first table of the first dataset in the first execution result.
        ''' This function can create exception
        ''' </summary>
        Public Function ExecuteAsTable() As DataTable
            Dim r As SqlQueryResult()
            r = Execute(ErrorDescription.Summary)
            If r.Length = 0 Then Throw New ApplicationException("There is no query result")
            If r(0).Data Is Nothing Then Throw New ApplicationException("There is no dataset returned in the first query result")
            If r(0).Data.Tables.Count = 0 Then Throw New ApplicationException("There is not table returned in the first query result")
            Return r(0).Data.Tables(0)
        End Function

        ''' <summary>
        ''' Get scalar variable in the query, the first cell in the first row of the table is returned
        ''' This function can create exception
        ''' </summary>
        Public Function ExecuteAsScalar() As Object
            Dim obj As Object
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(Text, CommandType.Text)
            obj = Adapter.ExecuteScalar(CommandName.Select)
            Return obj
        End Function

        ''' <summary>
        ''' Get scalar string from the query
        ''' This function can create exception
        ''' </summary>
        Public Function ExecuteAsString() As String
            Dim obj As Object = ExecuteAsScalar()
            Return obj.ToString()
        End Function

        ''' <summary>
        ''' Execute the query without returning anything
        ''' This function can create exception
        ''' </summary>
        Public Sub ExecuteNonQuery()
            Call ExecuteAsScalar()
        End Sub

#End Region

#Region "Miscellaneous and Static Function"
        Private Shared Function SplitQuery(ByVal query As String) As String()
            Dim tmpS As String()
            If query.Contains(vbCrLf & "GO" & vbCrLf) Then
                tmpS = query.Split(New String() {vbCrLf & "GO" & vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
            ElseIf query.Contains(vbLf & "GO" & vbLf) Then
                tmpS = query.Split(New String() {vbLf & "GO" & vbLf}, StringSplitOptions.RemoveEmptyEntries)
            Else
                tmpS = New String() {query}
            End If
            Return tmpS
        End Function

        Public Sub SetServer(ByVal s As SqlServer)
            Server = s
        End Sub

        Public Shared Function GetObjectAlterationQuery(ByVal creationQuery As String) As String
            Dim sb As New System.Text.StringBuilder(creationQuery)
            sb = sb.Replace("CREATE PROCEDURE", "ALTER PROCEDURE")
            sb = sb.Replace("CREATE FUNCTION", "ALTER FUNCTION")
            sb = sb.Replace("CREATE VIEW", "ALTER VIEW")
            Return sb.ToString()
        End Function

        Public Shared Function GetObjectCreationQuery(ByVal alterQuery As String) As String
            Dim sb As New System.Text.StringBuilder(alterQuery)
            sb = sb.Replace("ALTER PROCEDURE", "CREATE PROCEDURE")
            sb = sb.Replace("ALTER FUNCTION", "CREATE FUNCTION")
            sb = sb.Replace("ALTER VIEW", "CREATE VIEW")
            Return sb.ToString()
        End Function
#End Region

#Region "Enum"
        Public Enum ErrorDescription
            Summary
            SingleDetail
        End Enum
#End Region
    End Class

    Public Class SqlQueryResult
        Public Data As DataSet
        Public StartTime As DateTime
        Public EndTime As DateTime
        Public ReadOnly Property ExecutionTime() As TimeSpan
            Get
                Return EndTime.Subtract(StartTime)
            End Get
        End Property
        Public Message As String
        Public HasError As Boolean
        Public ErrorNumber As Integer
        Public ErrorMessage As String
        Public ErrorSeverity As Integer
        Public ErrorState As Integer
        Public ErrorLine As Integer
        Public ErrorProcedure As String
        Public AffectedRows As Integer

        Public Sub New()
        End Sub

        ''' <summary>
        ''' Record the start time
        ''' </summary>
        Public Sub RecordStart()
            StartTime = DateTime.Now
        End Sub

        ''' <summary>
        ''' Record the end time
        ''' </summary>
        Public Sub RecordEnd()
            EndTime = DateTime.Now
        End Sub
    End Class
End Namespace