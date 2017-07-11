Namespace Smart
    Public Interface IExecutable
        Function GetExecutionScript() As String
        Function GetExecutionScript(ByVal para As ParameterCollection) As String
        Function GetExecutionVariables() As DataTable
    End Interface
End Namespace
