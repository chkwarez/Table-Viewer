Namespace Smart
    Public Class CommonProperty
        Public Enum DatabaseObject
            None
            SystemTable
            Table
            View
            StoredProcedure
            ScalarValuedFunction
            TableValuedFunction
            InlineTableFunction
            Text
        End Enum

        Public Shared Function GetObjectTypeByCode(ByVal code As String) As DatabaseObject
            Select Case code
                Case "FN"
                    Return DatabaseObject.ScalarValuedFunction
                Case "P"
                    Return DatabaseObject.StoredProcedure
                Case "S"
                    Return DatabaseObject.SystemTable
                Case "U"
                    Return DatabaseObject.Table
                Case "TF"
                    Return DatabaseObject.TableValuedFunction
                Case "IF"
                    Return DatabaseObject.InlineTableFunction
                Case "V"
                    Return DatabaseObject.View
                Case Else
                    Return DatabaseObject.None
            End Select
        End Function

        Public Shared Function GetObjectTypeCode(ByVal obj As DatabaseObject) As String
            Select Case obj
                Case DatabaseObject.ScalarValuedFunction
                    Return "FN"
                Case DatabaseObject.StoredProcedure
                    Return "P"
                Case DatabaseObject.SystemTable
                    Return "S"
                Case DatabaseObject.Table
                    Return "U"
                Case DatabaseObject.TableValuedFunction
                    Return "TF"
                Case DatabaseObject.InlineTableFunction
                    Return "IF"
                Case DatabaseObject.View
                    Return "V"
                Case DatabaseObject.None
                    Return ""
                Case Else
                    Throw New ApplicationException("No code is found for this object type")
            End Select
        End Function

        Public Shared Function GetObjectName(ByVal obj As DatabaseObject) As String
            Select Case obj
                Case DatabaseObject.ScalarValuedFunction
                    Return "Scalar Valued Function"
                Case DatabaseObject.StoredProcedure
                    Return "Stored Procedure"
                Case DatabaseObject.SystemTable
                    Return "System Table"
                Case DatabaseObject.Table
                    Return "Table"
                Case DatabaseObject.TableValuedFunction
                    Return "Table Valued Function"
                Case DatabaseObject.InlineTableFunction
                    Return "Inline Table Valued Function"
                Case DatabaseObject.View
                    Return "View"
                Case Else
                    Return ""
            End Select
        End Function

        Public Const UserDefaultSchema As String = "dbo"
        Public Const CommentPrefix As String = "--"

        Public Shared Function IsNumberDataType(ByVal dbDataType As String) As Boolean
            Dim tmp As String = CHK.StringExtension.LSStr(dbDataType, "(", True).ToLower()

            Select Case tmp
                Case "decimal", "numeric", "float", "int", "tinyint", "smallint", "bigint", "float", "double"
                    Return True
                Case Else
                    Return False
            End Select
        End Function
    End Class

    Public Class ParameterCollection
        Dim parameter As Hashtable

        Public Sub New()
            parameter = New Hashtable()
        End Sub

        Public Sub Add(ByVal name As String, ByVal value As String)
            If name Is Nothing Then Throw New ApplicationException("The variable name cannot be null")
            If parameter.Contains(name) Then Throw New ApplicationException("The parameter already exists in the collection.")
            parameter.Add(name, value)
        End Sub

        Public Sub AddOrUpdate(ByVal name As String, ByVal value As String)
            If parameter.Contains(name) Then
                parameter(name) = value
            Else
                parameter.Add(name, value)
            End If
        End Sub

        Public Function GetValue(ByVal name As String) As String
            If parameter.Contains(name) = False Then Throw New ApplicationException("The parameter " & name & " does not exist")
            Return CType(parameter(name), String)
        End Function

        Public Function GetValue(ByVal name As String, ByVal defaultValue As String) As String
            If parameter.Contains(name) Then
                Return GetValue(name)
            Else
                Return defaultValue
            End If
        End Function

        Public Sub Clear()
            parameter.Clear()
        End Sub

        Public Function GetAllParameters() As Hashtable
            Return parameter
        End Function

        ''' <summary>
        ''' Merge the current parameter collections with the other collection
        ''' </summary>
        Public Sub Merge(ByVal nextCollection As ParameterCollection)
            Dim hTable As Hashtable = nextCollection.GetAllParameters()

            For Each dictKey As DictionaryEntry In hTable
                Call AddOrUpdate(dictKey.Key.ToString(), CType(dictKey.Value, String))
            Next
        End Sub
    End Class



End Namespace