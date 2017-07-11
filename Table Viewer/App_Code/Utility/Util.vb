Public Class Util
#Region "Clipboard"
    Public Shared Sub SetClipboardText(ByVal text As String)
        If text = "" Then Exit Sub
        Clipboard.Clear()
        Clipboard.SetText(text, TextDataFormat.UnicodeText)
    End Sub

    Public Shared Function GetClipboardText() As String
        Return Clipboard.GetText(TextDataFormat.UnicodeText)
    End Function
#End Region

    Public Shared Function EnumContains(ByVal multipleValue As Integer, ByVal enumValue As Integer, ByVal type As EnumDigitType) As Boolean
        Dim nList As New System.Collections.Generic.List(Of Integer)
        Dim k As Integer, value As Integer

        Select Case type
            Case EnumDigitType.PowerOfTwo
                k = multipleValue
                Do
                    value = CInt(2 ^ (Fix(Math.Log(k) / Math.Log(2))))
                    nList.Add(value)
                    k -= value
                    If k <= 0 Then Exit Do
                Loop
                Return nList.Contains(enumValue)
            Case EnumDigitType.Prime
                Return CType(IIf(multipleValue Mod enumValue = 0, True, False), Boolean)
            Case Else
                Throw New ApplicationException("Enum isn't defined.")
        End Select
    End Function

    Public Enum EnumDigitType
        PowerOfTwo
        Prime
    End Enum
End Class
