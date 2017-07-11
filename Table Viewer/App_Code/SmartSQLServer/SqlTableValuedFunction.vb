Namespace Smart
    Public Class SqlTableValuedFunction : Inherits SqlDatabaseObject : Implements IExecutable

#Region "Must Inherit Implementation"
        Public Overrides ReadOnly Property ObjectType() As String
            Get
                Return CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.TableValuedFunction)
            End Get
        End Property

        Public Overrides Function GetDeleteSQL() As String
            Return "DROP FUNCTION " & FullName
        End Function

        Public Function GetExecutionScript() As String Implements IExecutable.GetExecutionScript
            Dim code As String = "", paraArray As String()
            Dim n As Integer

            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(FullName, CommandType.StoredProcedure)
            paraArray = Adapter.GetCommandParameters(CommandName.Select)

            'Generate Execution Code
            For n = 0 To paraArray.Length - 1 'Create Parameter
                If paraArray(n) = "" Then Continue For
                code = code & "'" & paraArray(n) & "'"
                If n < paraArray.Length - 1 Then code = code & ","
            Next

            code = "--" & code & vbCrLf
            code &= "SELECT * FROM " & Schema & "." & Name & "()"

            Return code.Trim()
        End Function

        Public Function GetExecutionScript(ByVal para As ParameterCollection) As String Implements IExecutable.GetExecutionScript
            Dim paraArray As String(), comment As String, code As String = "", tmp As String, final As String
            Dim n As Integer
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(FullName, CommandType.StoredProcedure)
            paraArray = Adapter.GetCommandParameters(CommandName.Select)


            'Generate Execution Code
            comment = String.Join(",", paraArray)
            For n = 0 To paraArray.Length - 1 'Create Parameter
                tmp = para.GetValue(paraArray(n), Nothing)

                If tmp = Nothing Then
                    tmp = "NULL"
                Else
                    tmp = "'" & tmp & "'"
                End If

                If n = 0 Then
                    code = tmp
                Else
                    code &= ", " & tmp
                End If
            Next

            final = "--" & comment & vbCrLf
            final &= "SELECT * FROM " & Schema & "." & Name & "(" & code & ")"
            Return final
        End Function

        Public Function GetExecutionVariables() As DataTable Implements IExecutable.GetExecutionVariables
            Adapter.ChangeDatabase(Database)
            Adapter.SetSelectCommand(FullName, CommandType.StoredProcedure)
            Return Adapter.GetCommandParametersTable(CommandName.Select)
        End Function
#End Region

#Region "Constructor"
        Public Sub New(ByVal ada As SmartDataAdapter, ByVal databaseName As String, ByVal id As Integer)
            MyBase.New(ada, databaseName, id)
        End Sub

        Public Sub New(ByVal ada As SmartDataAdapter, ByVal databaseName As String, ByVal funcName As String)
            MyBase.New(ada, databaseName, funcName)
        End Sub
#End Region


    End Class
End Namespace