Public Class QueryHistoryLogic : Inherits StackQueueCollection(Of QueryItem)

    Public Sub New(ByVal type As StackQueueCollection.StackQueueType, ByVal maxCount As Integer)
        MyBase.New(type, maxCount)
    End Sub

    Public Shadows Function Add(ByVal value As QueryItem) As Integer
        Dim orgItem As QueryItem = Nothing
        Dim newItem As QueryItem = CType(value, QueryItem)

        If newItem.Text.Trim() = "" Then Return 0 'Skip Insert

        Dim b As Boolean = IsExisted(newItem, orgItem)
        If b = True Then
            orgItem.CreateDate = DateTime.Now 'Renew Date Time
        Else
            MyBase.Add(value)
        End If

        Return 0
    End Function

    Public Function GetQueryItem(ByVal index As Integer) As QueryItem
        Return Item(index)
    End Function

    Private Function IsExisted(ByVal newItem As QueryItem, ByRef orgItem As QueryItem) As Boolean
        Dim n As Integer, tmpItem As QueryItem

        For n = 0 To Me.Count - 1
            tmpItem = GetQueryItem(n)
            If tmpItem.Text = newItem.Text Then
                orgItem = tmpItem
                Return True
            End If
        Next

        Return False
    End Function
End Class

Public Class QueryItem
    Public Database As String
    Public Title As String
    Public Text As String
    Public CreateDate As DateTime

    Public Sub New(ByVal db As String, ByVal queryText As String, ByVal queryTitle As String)
        Database = db
        Title = queryTitle
        Text = queryText
        CreateDate = DateTime.Now
    End Sub
End Class