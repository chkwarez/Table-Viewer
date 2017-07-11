Namespace Smart
    Public Class SqlStoredProcedure : Inherits SqlDatabaseObject : Implements IExecutable

#Region "Must Inherit Implementation"
        Public Overrides ReadOnly Property ObjectType() As String
            Get
                Return CommonProperty.GetObjectTypeCode(CommonProperty.DatabaseObject.StoredProcedure)
            End Get
        End Property

        Public Overrides Function GetDeleteSQL() As String
            Return "DROP PROCEDURE " & FullName
        End Function

        Public Function GetExecutionScript() As String Implements IExecutable.GetExecutionScript
            Dim code As String = "", paraArray As String()
            Dim n As Integer

            Adapter.SetSelectCommand(FullName, CommandType.StoredProcedure)
            paraArray = Adapter.GetCommandParameters(CommandName.Select)

            'Generate Execution Code
            code = "DECLARE	@return_value int"
            code = code & vbCrLf & "EXEC @return_value = " & FullName
            code = code & vbCrLf

            For n = 0 To paraArray.Length - 1 'Create Parameter
                If paraArray(n) = "" Then Continue For
                code = code & vbCrLf & paraArray(n) & " = NULL"
                If n < paraArray.Length - 1 Then code = code & ","
            Next

            code = code & vbCrLf & vbCrLf & "SELECT 'Return Value' = @return_value"

            Return code.Trim()
        End Function

        Public Function GetExecutionScript(ByVal para As ParameterCollection) As String Implements IExecutable.GetExecutionScript
            Dim code As String = "", paraArray As String(), tmp As String
            Adapter.SetSelectCommand(FullName, CommandType.StoredProcedure)
            paraArray = Adapter.GetCommandParameters(CommandName.Select)

            'Generate Execution Code
            code = "DECLARE	@return_value int"
            code = code & vbCrLf & "EXEC @return_value = " & FullName
            code = code & vbCrLf

            For n As Integer = 0 To paraArray.Length - 1 'Create Parameter
                tmp = para.GetValue(paraArray(n), Nothing)

                If tmp Is Nothing Then
                    tmp = "NULL"
                Else
                    tmp = "N'" & tmp & "'"
                End If

                code &= vbCrLf & paraArray(n) & " = " & tmp
                If n < paraArray.Length - 1 Then code = code & ","
            Next

            code &= vbCrLf & vbCrLf & "SELECT 'Return Value' = @return_value"

            Return code.Trim()
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

        Public Sub New(ByVal ada As SmartDataAdapter, ByVal databaseName As String, ByVal spName As String)
            MyBase.New(ada, databaseName, spName)
        End Sub
#End Region

    End Class
End Namespace