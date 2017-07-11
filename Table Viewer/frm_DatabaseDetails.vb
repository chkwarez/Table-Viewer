Public Class frm_DatabaseDetails : Implements IFormRefresh, IFormClose
    Public Database As Smart.SqlDatabase
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

#Region "Form Event"
    Private Sub frm_Database_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub

    Private Sub frm_DatabaseDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
#End Region

#Region "Other Controls Events"

    Private Sub txtDatabaseName_Click(sender As Object, e As EventArgs) Handles txtDatabaseName.Click
        Dim txt = CType(sender, ToolStripTextBox)
        txt.SelectAll()
    End Sub

#End Region

#Region "Program Functions [Core]"
    Private Sub LoadData()
        If Database Is Nothing Then Exit Sub
        txtDatabaseName.Text = Database.Name

        LoadFileStructure()
    End Sub

    Private Sub LoadFileStructure()
        Try
            'Database Files
            Dim dtFiles = Database.GetDataAndLogFiles()
            lvwFiles.Items.Clear()
            For n As Integer = 0 To dtFiles.Rows.Count - 1
                lvwFiles.AddItem(Nothing, dtFiles.Rows(n)("type_desc").ToString(), dtFiles.Rows(n)("FileName").ToString(), dtFiles.Rows(n)("FilePath").ToString())
            Next
            lblRecoveryMode.Text = Database.RecoveryMode
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTableRowCount()
        Try
            Dim qTableRowCount = Database.NewQuery
            qTableRowCount.Text = My.Resources.SystemQueryResource.CountTableRows
            Dim dtTableRowCount = qTableRowCount.ExecuteAsTable()
            lvwTableRowCount.ClearItems()

            For n As Integer = 0 To dtTableRowCount.Rows.Count - 1
                Dim schemaName As String = dtTableRowCount.Rows(n)("schema_name").ToString()
                Dim tableName As String = dtTableRowCount.Rows(n)("table_name").ToString()
                Dim rowCount As Integer = CInt(dtTableRowCount.Rows(n)("rows"))
                If chkHideEmptyTable.Checked And rowCount = 0 Then Continue For

                If Not txtFilterTableName.Text = "" And Not schemaName.Contains(txtFilterTableName.Text) And Not tableName.Contains(txtFilterTableName.Text) Then Continue For 'Include
                If Not txtExcludeTableName.Text = "" And (schemaName.Contains(txtExcludeTableName.Text) Or tableName.Contains(txtExcludeTableName.Text)) Then Continue For 'Exclude

                lvwTableRowCount.AddItem(dtTableRowCount.Rows(n)("object_id"), schemaName, tableName, rowCount.ToString())
            Next

            lblTableRowCount.Text = "Count: " & lvwTableRowCount.Items.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadUserRole()
        Try
            Dim qUserRole = Database.NewQuery
            qUserRole.Text = My.Resources.SystemQueryResource.ListUserRole
            Dim dtUserRole = qUserRole.ExecuteAsTable()
            lvwUserRole.ClearItems()

            For n As Integer = 0 To dtUserRole.Rows.Count - 1
                lvwUserRole.AddItem(dtUserRole.Rows(n)("principal_id"), dtUserRole.Rows(n)("type_desc").ToString(), dtUserRole.Rows(n)("name").ToString(), CDate(dtUserRole.Rows(n)("create_date")).ToString(), dtUserRole.Rows(n)("default_schema_name").ToString(), dtUserRole.Rows(n)("database_roles").ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadRestoreHistory()
        Try
            Dim qRestoreHistory = Database.NewQuery
            qRestoreHistory.Text = My.Resources.SystemQueryResource.GetDatabaseRestoreHistory
            Dim dtRestoreHistory = qRestoreHistory.ExecuteAsTable()
            lvwRestoreHistory.ClearItems()

            For n As Integer = 0 To dtRestoreHistory.Rows.Count - 1
                Dim restoreDate As DateTime? = Nothing

                If TypeOf dtRestoreHistory.Rows(n)("restore_date") Is Date Then
                    restoreDate = CDate(dtRestoreHistory.Rows(n)("restore_date"))
                ElseIf TypeOf dtRestoreHistory.Rows(n)("create_date") Is Date Then
                    restoreDate = CDate(dtRestoreHistory.Rows(n)("create_date"))
                End If

                lvwRestoreHistory.AddItem(restoreDate,
                                          restoreDate.ToString(),
                                          dtRestoreHistory.Rows(n)("user_name").ToString(),
                                          dtRestoreHistory.Rows(n)("restore_type").ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadSynonym()
        Try
            Dim qSynonym = Database.NewQuery
            qSynonym.Text = My.Resources.SystemQueryResource.GetSynonyms
            Dim dtSynonym = qSynonym.ExecuteAsTable()
            lvwSynonym.ClearItems()

            For n As Integer = 0 To dtSynonym.Rows.Count - 1
                lvwSynonym.AddItem(dtSynonym.Rows(n)("name").ToString(),
                                      dtSynonym.Rows(n)("name").ToString(),
                                      dtSynonym.Rows(n)("base_object_name").ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub btnFixOrphanedAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFixOrphanedUser.Click
        Dim defaultUser As String = ""
        If lvwUserRole.SelectedItems.Count > 0 Then
            defaultUser = lvwUserRole.SelectedItems(0).SubItems(1).Text
        End If

        Try
            Dim k = InputBox("Please input the user name." & vbCrLf & "sp_change_users_login", "Fix User", defaultUser)
            If k = "" Then Exit Sub
            Dim query = Database.NewQuery
            query.Text = My.Resources.SystemQueryResource.FixOrphanedUser
            query.Text = query.Text.Replace("@user", "'" & k & "'")
            query.ExecuteNonQuery()
            MessageBox.Show("Executed.", "Fix", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkHideEmptyTable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHideEmptyTable.CheckedChanged
        LoadData()
    End Sub

    Private Sub txtFilterTableName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFilterTableName.KeyDown, txtExcludeTableName.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadTableRowCount()
        End If
    End Sub

    Private Sub lvwSynonym_DoubleClick(sender As Object, e As EventArgs) Handles lvwSynonym.DoubleClick
        If lvwSynonym.SelectedItems.Count = 0 Then Exit Sub

        Dim f = ParentMainForm.CreateQueryWindow("")
        f.SetQuery(txtDatabaseName.Text, "SELECT TOP 100 t.* FROM " & lvwSynonym.SelectedItems(0).Text & " AS t" & vbCrLf & "--SELECT TOP 100 t.* FROM " & lvwSynonym.SelectedItems(1).Text & " AS t")
    End Sub

#Region "Toolstrip Button Events"
    Private Sub tsTableRowCount_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTableRowCount.CheckStateChanged
        gpTableRowCount.Visible = tsTableRowCount.Checked
        If gpTableRowCount.Visible Then LoadTableRowCount()
    End Sub

    Private Sub tsUserRole_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsUserRole.CheckStateChanged
        gpUserRole.Visible = tsUserRole.Checked
        If gpUserRole.Visible Then LoadUserRole()
    End Sub

    Private Sub tsRestoreHistory_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRestoreHistory.CheckStateChanged
        gpRestoreHistory.Visible = tsRestoreHistory.Checked
        If gpRestoreHistory.Visible Then LoadRestoreHistory()
    End Sub


    Private Sub tsSynonym_CheckStateChanged(sender As Object, e As EventArgs) Handles tsSynonym.CheckStateChanged
        gpSynonym.Visible = tsSynonym.Checked
        If gpSynonym.Visible Then LoadSynonym()
    End Sub
#End Region

#Region "Interfaces"
    Public Sub RefreshForm() Implements IFormRefresh.RefreshForm
        LoadData()
    End Sub

    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub



#End Region

End Class