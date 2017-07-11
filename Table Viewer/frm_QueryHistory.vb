Public Class frm_QueryHistory
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

    Private ReadOnly Property SelectedQuery() As QueryItem
        Get
            If lvwHistory.SelectedItems.Count = 0 Then Return Nothing
            Return ParentMainForm.QueryHistory.GetQueryItem(CType(lvwHistory.SelectedItems(0).Tag, Integer))
        End Get
    End Property


    Public Sub RefreshList()
        Dim n As Integer
        lvwHistory.Items.Clear()
        For n = 0 To ParentMainForm.QueryHistory.Count - 1
            Dim i As New ListViewItem, queryobj As QueryItem
            queryobj = ParentMainForm.QueryHistory.GetQueryItem(n)
            i.Text = queryobj.Title
            i.SubItems.Add(queryobj.Database)
            i.SubItems.Add(queryobj.CreateDate.ToLongTimeString())
            i.Tag = n
            lvwHistory.Items.Add(i)
        Next
    End Sub

    Private Sub ListView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwHistory.Click
        If SelectedQuery Is Nothing Then Exit Sub
        txtQuery.Text = SelectedQuery.Text
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        If SelectedQuery Is Nothing Then Exit Sub
        Dim a As frm_SQL = ParentMainForm.CreateQueryWindow(SelectedQuery.Title)
        a.SetQuery(SelectedQuery.Database, SelectedQuery.Text)
        Me.Close()
    End Sub

    Private Sub frm_QueryHistory_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        RefreshList()
    End Sub

    Private Sub frm_QueryHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwHistory.DoubleClick
        ListView1_Click(Nothing, Nothing)
        btnOpen_Click(Nothing, Nothing)
    End Sub
End Class