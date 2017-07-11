Public Class frm_Main
    Public DatabaseWindow As frm_Database
    Public QueryWindows As New List(Of frm_SQL)
    Public TableWindows As New List(Of frm_Table)
    Public StoredProcedureWindow As frm_SP
    Public QueryHistory As New QueryHistoryLogic(StackQueueCollection.StackQueueType.Stack, 50)
    Dim CurrentWindow As Form
    Dim LastWindow As Form
    Dim OpenedQueryWindowCount As Integer = 0
    Public ViewCaches As New System.Collections.Generic.Dictionary(Of String, TableViewStatus)

    Private Declare Function SetThreadExecutionState Lib "kernel32" (ByVal esFlags As Long) As Long
    Public Enum EXECUTION_STATE As Integer
        ES_CONTINUOUS = &H80000000
        ES_DISPLAY_REQUIRED = &H2
        ES_SYSTEM_REQUIRED = &H1
        ES_AWAYMODE_REQUIRED = &H40
    End Enum

#Region "Page Load"
    Private Sub frm_Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Resume Hiberate
        'SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED Or EXECUTION_STATE.ES_CONTINUOUS)
    End Sub

    Private Sub frm_Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim isNewUser As Boolean = ConfigurationSettings.IsNewUser()
        If isNewUser Then ConfigurationSettings.CreateProgramRegistryKey()

        InitializeStaticWindows()
        btnTranslateChinese.Text = My.Resources.Topic_ChineseTranslation

        If isNewUser = False Then
            DatabaseWindow.QuickConnect()
            SwitchDatabaseWindow(True)
            If ConfigurationSettings.ShowConnectionWizardAtStartUp Then DatabaseWindow.ShowConnectionWizard()
        End If

        'Load Option
        Dim favDbs As String() = ConfigurationSettings.FavoriteDatabases.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        For Each dbText In favDbs
            Dim mi As New ToolStripMenuItem()
            mi.Name = "miFavoriteDatabase_" & dbText
            mi.Text = dbText
            mi.Tag = dbText
            AddHandler mi.Click, AddressOf FavoriteDatabaseToolStripMenuItem_Click
            FavoriteDatabaseToolStripMenuItem.DropDownItems.Add(mi)
        Next

        'Load Argument
        Dim args = Environment.GetCommandLineArgs()
        If Array.IndexOf(args, "DatabaseCopy") >= 0 Then
            mnuDatabaseCopy_Click(mnuDatabaseCopy, Nothing)
        End If

        'Set Hibernate Off
        'SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS)
    End Sub

    Private Sub frm_Main_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub frm_Main_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim v As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If v IsNot Nothing Then
            For n As Integer = 0 To v.Length - 1
                If System.IO.File.Exists(v(n).ToString()) Then
                    Dim f As frm_SQL = CreateQueryWindow("")
                    f.LoadQueryFromFile(v(n).ToString())
                End If
            Next
        End If
    End Sub
#End Region

#Region "Menu Strips Events [File]"
    Private Sub mnuOpenDatabaseWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenDatabaseWindow.Click
        SwitchDatabaseWindow(Nothing)
    End Sub
    Private Sub mnuFindTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFindTable.Click
        SwitchDatabaseWindow(True)
        DatabaseWindow.txtSearchObject.Focus()
        DatabaseWindow.txtSearchObject.SelectAll()
        'Dim tmp As String
        'If DatabaseWindow.lvwTable.Items.Count = 0 Then
        '    MessageBox.Show("No database is chosen or there is no table in the database")
        '    Exit Sub
        'End If

        'tmp = InputBox("Please input the keyword of the table name" & vbCrLf & "Use Space to seperate each AND keyword", "Table Name", TableSearchHistory)
        'If tmp = "" Then Exit Sub

        'TableSearchHistory = tmp
        'DatabaseWindow.FindClosestDatabaseObject(tmp)
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        If CurrentWindow Is Nothing Or CurrentWindow.IsDisposed = True Then Exit Sub
        If TypeOf CurrentWindow Is IFormClose Then
            Dim a As IFormClose
            a = CType(CurrentWindow, IFormClose)
            a.CloseForm()
        End If
    End Sub


    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        If CurrentWindow Is Nothing Or CurrentWindow.IsDisposed = True Then Exit Sub
        If TypeOf CurrentWindow Is IFormRefresh Then
            Dim a As IFormRefresh
            a = CType(CurrentWindow, IFormRefresh)
            a.RefreshForm()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub tsRefreshAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRefreshAll.Click
        Dim n As Integer
        Dim f As CHKControl.TabBar.FormProperty()
        TabBar1.ClearSelection()
        f = TabBar1.GetUnselectedForms()

        For n = 0 To f.Length - 1
            If TypeOf f(n).WindowForm Is IFormRefresh Then
                Dim a As IFormRefresh = CType(f(n).WindowForm, IFormRefresh)
                a.RefreshForm()
            End If
        Next
    End Sub

    Private Sub tsRefreshRegular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRefreshRegular.CheckedChanged
        timerAutoRefresh.Enabled = tsRefreshRegular.Checked
    End Sub
#End Region

#Region "Menu Strips Events [Table]"
    Private Sub mnuOpenColumnConsistency_Click(sender As System.Object, e As System.EventArgs) Handles mnuOpenColumnConsistency.Click
        CreateConsistencyCheckWindow()
    End Sub

    Private Sub mnuCreateTable_Click(sender As System.Object, e As System.EventArgs) Handles mnuCreateTable.Click
        CreateTableStructureWindow()
    End Sub
#End Region

#Region "Menu Strips Events [Query]"
    Private Sub NewQueryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewQueryToolStripMenuItem.Click
        CreateQueryWindow("")
    End Sub

    Private Sub OpenQueryMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenQueryMenuItem.Click
        Dim rtvl = cmdgOpen.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub

        For n As Integer = 0 To cmdgOpen.FileNames.Length - 1
            Dim q = CreateQueryWindow("")
            q.LoadQueryFromFile(cmdgOpen.FileNames(n))
        Next
    End Sub

    Private Sub OpenExecuteQueryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenExecuteQueryToolStripMenuItem.Click
        Dim rtvl = cmdgOpen.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Or cmdgOpen.FileNames.Length = 0 Then Exit Sub

        Dim text As String = "Are you sure to execute the following queries on " & DatabaseWindow.SelectedDatabase & "?" & vbCrLf & String.Join(vbCrLf, cmdgOpen.FileNames)
        Dim rtvl2 = MessageBox.Show(text, "Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If rtvl2 = Windows.Forms.DialogResult.No Then Exit Sub

        Try
            For n As Integer = 0 To cmdgOpen.FileNames.Length - 1
                Dim q = DatabaseWindow.Server.NewQuery()
                q.Database = DatabaseWindow.SelectedDatabase
                q.Text = System.IO.File.ReadAllText(cmdgOpen.FileNames(n))
                Dim results = q.Execute(Smart.SqlQuery.ErrorDescription.Summary)

                Dim hasError As Boolean = False
                Dim errorMsg As New System.Text.StringBuilder()
                errorMsg.AppendLine("File '" & System.IO.Path.GetFileName(cmdgOpen.FileNames(n)) & "' has the following error(s):")
                For m As Integer = 0 To results.Length - 1
                    If results(m).HasError Then
                        hasError = True
                        errorMsg.Append(results(m).Message)
                    End If
                Next
                If hasError Then Throw New ApplicationException(errorMsg.ToString())
            Next
            MessageBox.Show("Queries are executed successfully.", "Query", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Menu Strips Events [Tools]"
    Private Sub mnuOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptions.Click
        Dim a As New frm_Configuration
        a.Show()
    End Sub

    Private Sub mnuDatabaseCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDatabaseCopy.Click
        Dim a As New frm_Copier
        a.MdiParent = Me
        a.Show()
    End Sub

    Private Sub ScriptDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptDataToolStripMenuItem.Click
        CreateSQLScripterWindow("")
    End Sub

    Private Sub ManagementStudioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagementStudioToolStripMenuItem.Click
        If System.IO.File.Exists(ConfigurationSettings.MsManagementStudioPath) Then
            Dim argument As New System.Text.StringBuilder()

            Dim cs = Smart.ConnectionString.Parse(DatabaseWindow.ddConnectionString.Text)
            argument.Append("-S " & cs.Server & " ")
            If cs.IsTrust Then argument.Append("-E ")
            If Not cs.UserId = "" Then
                argument.Append("-U " & cs.UserId & " -P " & cs.Password & " ")
            End If
            If DatabaseWindow.Server IsNot Nothing Then argument.Append("-d " & DatabaseWindow.Server.Database.Name & " ")
            argument.Append("-nosplash ")

            System.Diagnostics.Process.Start(ConfigurationSettings.MsManagementStudioPath, argument.ToString())
        Else
            MessageBox.Show("The path for Microsoft SQL Server Management Studio is not found, please enter the correct path in options.")
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Dim f As New frm_Comparer()
        f.MdiParent = Me
        f.Show()
        TabBar1.AddForm(f, Color.Black, Color.White, Color.DarkBlue)
        TabBar1.Refresh()
    End Sub
#End Region

#Region "Menu Strips Events [Window]"
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Public Sub HorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem.Click
        HideStaticWindows()
        If TabBar1.SelectedCount > 0 Then
            TabBar1.ManageWindow(CHKControl.TabBar.WindowActions.RestoreSelected)
            TabBar1.ManageWindow(CHKControl.TabBar.WindowActions.MinimizeUnselected)
        End If
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub VerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem.Click
        HideStaticWindows()
        If TabBar1.SelectedCount > 0 Then
            TabBar1.ManageWindow(CHKControl.TabBar.WindowActions.RestoreSelected)
            TabBar1.ManageWindow(CHKControl.TabBar.WindowActions.MinimizeUnselected)
        End If
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub SwitchWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchWindowToolStripMenuItem.Click
        SwitchWindow()
    End Sub

    Private Sub MaximizeRestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaximizeRestoreToolStripMenuItem.Click
        If CurrentWindow Is Nothing Or CurrentWindow.IsDisposed = True Then Exit Sub
        If CurrentWindow.WindowState = FormWindowState.Maximized Then
            CurrentWindow.WindowState = FormWindowState.Normal
        Else
            CurrentWindow.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub MinimizeRestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizeRestoreToolStripMenuItem.Click
        If CurrentWindow Is Nothing Or CurrentWindow.IsDisposed = True Then Exit Sub
        If CurrentWindow.WindowState = FormWindowState.Minimized Then
            CurrentWindow.WindowState = FormWindowState.Normal
        Else
            CurrentWindow.WindowState = FormWindowState.Minimized
        End If
    End Sub
#End Region

#Region "Menu Strips Events [Stored Procedure]"
    Private Sub mnuSPManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSPManage.Click
        SwitchStoredProcedureWindow(Nothing)
    End Sub

    Private Sub QueryHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryHistoryToolStripMenuItem.Click
        CreateQueryHistoryWindow()
    End Sub
#End Region

#Region "Menu Strips Events [Index]"
    Private Sub mnuIndexManage_Click(sender As System.Object, e As System.EventArgs) Handles mnuIndexManage.Click
        CreateIndexWindow()
    End Sub
#End Region

#Region "Menu Strips Events [Help]"
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim f As New AboutBox1()
        f.Show()
    End Sub
#End Region

#Region "Menu Strips Events [Favorite]"
    Private Sub FavoriteDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not TypeOf sender Is ToolStripMenuItem Then Exit Sub

        Dim mi = CType(sender, ToolStripMenuItem)
        DatabaseWindow.ddDatabase.SelectedValue = mi.Tag.ToString()
        StoredProcedureWindow.ddDatabase.Text = mi.Tag.ToString()
    End Sub
#End Region

#Region "ToolStrip Events"
    Private Sub btnTileHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTileHorizontal.Click
        HorizontalToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub btnTileVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTileVertical.Click
        VerticalToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub btnRestoreAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestoreAll.Click
        TabBar1.ManageWindow(CHKControl.TabBar.WindowActions.RestoreAll)
    End Sub

    Private Sub btnOpenDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenDatabase.Click
        SwitchDatabaseWindow(Nothing)
    End Sub

    Private Sub btnNewQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewQuery.Click
        If Not DatabaseWindow.ConnectionStatus = frm_Database.ConnectionStatusCode.Connected Then Exit Sub
        CreateQueryWindow("")
    End Sub

    Private Sub btnOpenSPManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenSPManager.Click
        If Not DatabaseWindow.ConnectionStatus = frm_Database.ConnectionStatusCode.Connected Then Exit Sub
        SwitchStoredProcedureWindow(Nothing)
    End Sub

    Private Sub btnFullScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFullScreen.Click
        Dim n As Integer
        If btnFullScreen.Checked = True Then 'Simple Mode
            For n = 0 To TableWindows.Count - 1
                TableWindows(n).StartSimpleMode()
            Next
        Else 'Normal Mode
            For n = 0 To TableWindows.Count - 1
                TableWindows(n).StartNormalMode()
            Next
        End If
    End Sub

    Private Sub btnCloseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseAll.Click
        TabBar1.ManageWindow(CHKControl.TabBar.WindowActions.CloseAll)

        DatabaseWindow.CloseForm()
        StoredProcedureWindow.CloseForm()
    End Sub

    Private Sub btnTranslateChinese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTranslateChinese.Click
        Dim a As New CHKControl.frm_Translation
        a.Show()
    End Sub
#End Region

#Region "Static Windows Management"
    Private Sub InitializeStaticWindows()
        DatabaseWindow = New frm_Database
        DatabaseWindow.MdiParent = Me

        StoredProcedureWindow = New frm_SP
        StoredProcedureWindow.MdiParent = Me
    End Sub

    Private Sub HideStaticWindows()
        DatabaseWindow.Hide()
        StoredProcedureWindow.Hide()

        btnOpenDatabase.Checked = False
        btnOpenSPManager.Checked = False
    End Sub

    Public Sub SwitchDatabaseWindow(ByVal showWindow As Nullable(Of Boolean))
        Dim visible As Boolean

        If showWindow.HasValue Then
            visible = showWindow.Value
        Else
            visible = Not DatabaseWindow.Visible
        End If

        If visible = True Then
            DatabaseWindow.Show()
            DatabaseWindow.Activate()
        Else
            DatabaseWindow.Hide()
        End If
        btnOpenDatabase.Checked = visible
    End Sub

    Public Sub SwitchStoredProcedureWindow(ByVal showWindow As Nullable(Of Boolean))
        Dim visible As Boolean

        If showWindow.HasValue Then
            visible = showWindow.Value
        Else
            visible = Not StoredProcedureWindow.Visible
        End If

        If visible = True Then
            StoredProcedureWindow.Show()
            StoredProcedureWindow.Activate()
        Else
            StoredProcedureWindow.Hide()
        End If
        btnOpenSPManager.Checked = visible
    End Sub


#End Region

#Region "General Windows Management"
    Public Sub RecordActiveWindow(ByVal win As Form)
        If win Is Nothing Then Exit Sub
        LastWindow = CurrentWindow
        CurrentWindow = win
    End Sub

    Public Sub SwitchWindow()
        If LastWindow Is Nothing Or LastWindow.IsDisposed = True Then Exit Sub
        LastWindow.Activate()
    End Sub
#End Region

#Region "External Windows Management"
    Public Function CreateTableWindow(ByVal table As Smart.SqlTable) As frm_Table
        'Check if table window is already opened
        For Each window As frm_Table In TableWindows
            If window.Table.Database = table.Database And window.Table.Schema = table.Schema And window.Table.Name = table.Name Then
                window.Show()
                window.Activate()
                window.LoadTableViewStatus(True)
                Return window
            End If
        Next

        'Create a New Window
        Dim a As New frm_Table
        a.MdiParent = Me
        a.Table = table
        TableWindows.Add(a)

        TabBar1.AddForm(a, Color.Black)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateQueryWindow(ByVal caption As String) As frm_SQL
        Dim a As New frm_SQL
        a.MdiParent = Me
        QueryWindows.Add(a)
        If caption = "" Then 'Use Default
            OpenedQueryWindowCount += 1
            a.Text = frm_SQL.CAPTION & " " & OpenedQueryWindowCount
        Else
            a.Text = caption
        End If

        TabBar1.AddForm(a, Color.AliceBlue, Color.White, Color.DarkBlue)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateSQLScripterWindow(ByVal caption As String) As frm_SQLScript
        Dim a As New frm_SQLScript
        a.MdiParent = Me
        If Not caption = "" Then a.Text = caption

        TabBar1.AddForm(a, Color.Black, Color.White, Color.Red)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateAspxGenerator(ByVal table As Smart.SqlTable) As frm_AspxGen
        Dim a As New frm_AspxGen
        a.MdiParent = Me
        a.Table = table

        TabBar1.AddForm(a, Color.Black, Color.White, Color.Purple)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateSQLSynthesizer(ByVal table As Smart.SqlTable) As frm_SQLSyn
        Dim a As New frm_SQLSyn
        a.MdiParent = Me
        a.Table = table

        TabBar1.AddForm(a, Color.Black, Color.White, Color.Violet)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateTableStructureWindow() As frm_TableStructure
        Dim a As New frm_TableStructure
        a.MdiParent = Me

        TabBar1.AddForm(a, Color.Black, Color.White, Color.Tan)
        a.Show()
        a.StartCreateMode()
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateTableStructureWindow(ByVal table As Smart.SqlTable) As frm_TableStructure
        Dim a As New frm_TableStructure
        a.MdiParent = Me

        TabBar1.AddForm(a, Color.Black, Color.White, Color.Tan)
        a.Show()
        a.StartEditMode(table)
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateSPExecutor(ByVal obj As Smart.IExecutable) As frm_SPExecutor
        Dim a As New frm_SPExecutor
        a.MdiParent = Me
        a.ExecutableObject = obj

        TabBar1.AddForm(a, Color.Black, Color.Yellow, Color.SpringGreen)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function

    Public Sub RemoveTableWindow(ByVal f As frm_Table)
        TableWindows.Remove(f)
    End Sub

    Public Sub RemoveQueryWindow(ByVal f As frm_SQL)
        QueryWindows.Remove(f)
    End Sub

    Public Function CreateDependencyWindow(ByVal objectID As Integer) As frm_Dependence
        Dim a As New frm_Dependence
        a.ParentMainForm = Me
        a.ObjectID = objectID
        a.LoadDependency()
        a.Show()
        Return a
    End Function

    Public Function CreateQueryHistoryWindow() As frm_QueryHistory
        Dim a As New frm_QueryHistory
        a.MdiParent = Me
        TabBar1.AddForm(a, Color.Black, Color.DarkBlue, Color.White)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateConsistencyCheckWindow() As frm_DatabaseConsistency
        Dim a As New frm_DatabaseConsistency
        a.MdiParent = Me
        TabBar1.AddForm(a, Color.Black, Color.LightCyan, Color.Aqua)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateDatabaseDetailsWindow() As frm_DatabaseDetails
        Dim a As New frm_DatabaseDetails
        a.MdiParent = Me
        TabBar1.AddForm(a, Color.Black, Color.LightCyan, Color.Aqua)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function

    Public Function CreateIndexWindow() As frm_DatabaseIndex
        Dim a As New frm_DatabaseIndex
        a.MdiParent = Me
        TabBar1.AddForm(a, Color.Black, Color.LightCyan, Color.Aqua)
        a.Show()
        TabBar1.Refresh()
        Return a
    End Function
#End Region

#Region "ToolStrip [Tab Switch]"
    Private Sub TabBar1_TabClick(ByVal f As CHKControl.TabBar.FormProperty, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabBar1.TabClick
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left
                If f.WindowForm.WindowState = FormWindowState.Minimized Then f.WindowForm.WindowState = FormWindowState.Normal
                f.WindowForm.Activate()
            Case Windows.Forms.MouseButtons.Middle
                f.WindowForm.Close()
            Case Windows.Forms.MouseButtons.Right

        End Select
    End Sub
#End Region

#Region "Miscellaneous Function"
    Private Sub timerAutoRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerAutoRefresh.Tick
        tsRefreshAll_Click(tsRefreshAll, Nothing)
    End Sub
#End Region

  
End Class