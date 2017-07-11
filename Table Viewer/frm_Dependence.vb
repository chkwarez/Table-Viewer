Public Class frm_Dependence
    Public ParentMainForm As frm_Main
    Public ObjectID As Integer

    Public Sub LoadDependency()
        Dim obj As Smart.SqlDatabaseObject
        obj = ParentMainForm.DatabaseWindow.Server.Database.GetDatbaseObjectById(ObjectID)
        dgResult.DataSource = obj.GetDependencyTable()
        dgResult.Refresh()

        txtName.Text = obj.Name
        txtDatabase.Text = obj.Database
        txtObjectID.Text = obj.ObjectID.ToString()

        Decorate()
    End Sub

    Public Sub Decorate()
        If dgResult.Columns.Count > 0 Then
            dgResult.Columns(0).Width = 200
        End If
    End Sub

    Private Sub TextBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyUp, txtDatabase.KeyUp, txtObjectID.KeyUp
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub dgResult_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgResult.KeyUp
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
End Class