Public Class frm_DatabaseIndex
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

    Public ReadOnly Property Server As Smart.SqlServer
        Get
            Return ParentMainForm.DatabaseWindow.Server
        End Get
    End Property

    Private Sub frm_SP_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If ParentMainForm.DatabaseWindow.Server Is Nothing Then Exit Sub
        LoadDatabaseList()
    End Sub

    Private Sub frm_SP_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub

#Region "Database"
    Public Sub LoadDatabaseList()
        'Show Dynamic Progress
        ddDatabase.Text = "Listing..."
        Application.DoEvents()

        'Get Database List
        Dim dtTable As DataTable = ParentMainForm.DatabaseWindow.Server.GetDatabases(True)

        ddDatabase.Items.Clear()
        For n As Integer = 0 To dtTable.Rows.Count - 1
            ddDatabase.Items.Add(dtTable.Rows(n)("name").ToString())
        Next
        ddDatabase.Text = ParentMainForm.DatabaseWindow.SelectedDatabase
    End Sub
#End Region

    Private Sub btnSetCurrentDatabase_Click(sender As System.Object, e As System.EventArgs) Handles btnSetCurrentDatabase.Click
        LoadDatabaseList()
        ddDatabase.Text = ParentMainForm.DatabaseWindow.SelectedDatabase
    End Sub

    Private Sub btnCheckHealth_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckHealth.Click
        lblStatus.Text = "Checking..."
        btnCheckHealth.Enabled = False
        Application.DoEvents()

        With ParentMainForm.DatabaseWindow.Server
            .ChangeDatabase(ddDatabase.Text)
            Dim newQuery = .Database.NewQuery()
            newQuery.Text = My.Resources.SystemQueryResource.CheckIndicesFragmentation
            Dim dtResult = newQuery.ExecuteAsTable() 'Execute the object creation

            dgHealth.AutoGenerateColumns = False
            dgHealth.DataSource = dtResult
            dgHealth.Refresh()
        End With

        For n As Integer = 0 To dgHealth.Rows.Count - 1
            dgHealth.SetCellValue(n, dgcHealthSelect.Index, True)
        Next

        lblStatus.Text = ""
        btnCheckHealth.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub btnRebuildTableIndices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRebuildTableIndices.Click
        lblStatus.Text = "Rebuilding..."
        btnRebuildTableIndices.Enabled = False
        Application.DoEvents()

        With ParentMainForm.DatabaseWindow.Server
            .ChangeDatabase(ddDatabase.Text)
            Dim query = .Database.NewQuery
            query.Text = My.Resources.SystemQueryResource.RebuildAllIndices
            query.ExecuteNonQuery()
        End With
        MessageBox.Show("All table indices are rebuilt.", "Index", MessageBoxButtons.OK, MessageBoxIcon.Information)

        lblStatus.Text = ""
        btnRebuildTableIndices.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub btnGetRebuildSQL_Click(sender As System.Object, e As System.EventArgs) Handles btnGetRebuildSQL.Click
        Dim sb As New System.Text.StringBuilder()
        For n As Integer = 0 To dgHealth.Rows.Count - 1
            If DirectCast(dgHealth.Rows(n).Cells(dgcHealthSelect.Index).EditedFormattedValue, Boolean) = True Then
                sb.AppendLine(dgHealth.GetCellString(n, dgcSuggestSQL.Index))
            End If
        Next
        txtSuggestSQL.Text = sb.ToString()
        TabControl1.SelectedTab = TabPage2
    End Sub
End Class