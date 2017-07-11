Imports System.IO

Public Class DatabaseComparisonLogic

    Public Shared Function CompareText(q1 As String, q2 As String) As TextComparisonResult
        Dim compResult As New TextComparisonResult()

        'Simple Comparison
        If q1 = q2 Then
            compResult.IsEqual = True
            compResult.TotalLine1 = CHK.StringExtension.CountLines(q1, StringExtension.LineBreakMode.LF10)
            compResult.TotalLine2 = CHK.StringExtension.CountLines(q2, StringExtension.LineBreakMode.LF10)
            Return compResult
        End If

        'Advance Comparison by simplifying the queries
        Dim simpQuery1 As String = Simplify(q1)
        Dim simpQuery2 As String = Simplify(q2)
        compResult.TotalLine1 = CHK.StringExtension.CountLines(simpQuery1, StringExtension.LineBreakMode.CRLF1310)
        compResult.TotalLine2 = CHK.StringExtension.CountLines(simpQuery2, StringExtension.LineBreakMode.CRLF1310)
        If simpQuery1 = simpQuery2 Then
            compResult.IsEqual = True
            Return compResult
        End If

        'Some Difference Exist, Run Line by Line Comparison
        Dim sr1 = New System.IO.StringReader(simpQuery1)
        Dim sr2 = New System.IO.StringReader(simpQuery2)

        compResult.IsEqual = True

        While sr1.Peek() > 0 And sr2.Peek() > 0
            Dim tmp1 As String = sr1.ReadLine()
            Dim tmp2 As String = sr2.ReadLine()

            If Not tmp1 = tmp2 Then
                compResult.IsEqual = False
                compResult.Difference1 = tmp1
                compResult.Difference2 = tmp2
                Exit While
            End If
        End While

        If sr1.Peek() > 0 Or sr2.Peek() > 0 Then 'One of the result is longer
            compResult.IsEqual = False
        End If

        sr1.Close()
        sr2.Close()

        Return compResult
    End Function

    Public Shared Function Simplify(text As String) As String
        Dim sr As New StringReader(text)
        Dim sb As New System.Text.StringBuilder
        While sr.Peek() > 0
            Dim line As String = sr.ReadLine()
            line = line.Trim()
            If line = "" Then Continue While
            If line.StartsWith(Smart.CommonProperty.CommentPrefix) Then Continue While
            sb.AppendLine(line)
        End While
        Return sb.ToString()
    End Function

End Class

Public Class TextComparisonResult
    Public IsEqual As Boolean
    Public TotalLine1 As Integer
    Public TotalLine2 As Integer
    Public Difference1 As String
    Public Difference2 As String
End Class

