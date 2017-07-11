Public Class frm_SQL : Implements IFormClose
    Public Const CAPTION As String = "Query"
    Private SourceObject As Smart.SqlDatabaseObject
    Private FellowSQLWindow As frm_SQL
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property
    Dim StartExecutionTime As DateTime
    Dim IsExecuting As Boolean
    Dim RunningThread As Threading.Thread
    Dim TimerThread As Threading.Thread
    Dim RunningQuery As Smart.SqlQuery
    Dim _CurrentFileName As String
    Private Property CurrentFileName() As String
        Get
            Return _CurrentFileName
        End Get
        Set(value As String)
            _CurrentFileName = value
            Me.Text = System.IO.Path.GetFileName(value)
        End Set
    End Property
    Dim NextScheduleTime As Date
    Dim SchedulePeriod As TimeSpan

#Region "Form Method"
    Private Sub frm_SQL_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
        txtQuery.Focus()
        txtQuery.AllowDrop = True
    End Sub

    Private Sub frm_SQL_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If SourceObject Is Nothing Then
            ParentMainForm.QueryHistory.Add(New QueryItem(ddDatabase.Text, txtQuery.Text, Me.Text))
        End If

        ParentMainForm.RemoveQueryWindow(Me)
    End Sub

    Private Sub frm_SQL_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        SplitContainer1.Panel2Collapsed = True
        'txtQuery.AutoCase = ConfigurationLogic.AutoFormatQuery
        txtQueryResultExportPath.Text = ConfigurationSettings.QueryResultExportPath
        LoadDatabaseList()
        Decorate()
        InitializeTab()
    End Sub

#End Region

#Region "Button, TextBox Method"
    Private Sub btnGotoError_Click(sender As System.Object, e As System.EventArgs) Handles btnGotoError.Click
        Dim k As Integer
        If TypeOf btnGotoError.Tag Is Integer Then
            Try
                k = CInt(btnGotoError.Tag)
                txtQuery.ScrollToLine(k - 1) 'Line Index
                txtQuery.Focus()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtMessage_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtMessage.DoubleClick
        btnGotoError_Click(Nothing, Nothing)
    End Sub

    Private Sub btnHideMessage_Click(sender As System.Object, e As System.EventArgs) Handles btnHideMessage.Click
        SplitContainer1.Panel2Collapsed = True
    End Sub

    Private Sub ddDatabase_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ddDatabase.KeyUp
        If e.KeyCode = Keys.F5 Then
            If btnRunQuery.Enabled = True Then RunQuery()
        End If
    End Sub

    Private Sub btnScheduleRun_CheckedChanged(sender As Object, e As EventArgs) Handles btnScheduleRun.CheckedChanged
        If btnScheduleRun.Checked Then 'Initiate
            Dim k As String = InputBox("Please enter the desired time to run the SQL query." & vbCrLf & "Separate the interval with a semicolon ;" & vbCrLf & "HH:mm, day, hour" & vbCrLf & "Example: 2016-12-31 15:00;day", "Schedule Run", DateTime.Now.ToString())
            If k = "" Then Exit Sub

            If k.Contains(";") Then
                NextScheduleTime = DateTime.Parse(CHK.StringExtension.LSStr(k, ";"))

                Select Case CHK.StringExtension.RSStr(k, ";")
                    Case "d", "dd", "day"
                        SchedulePeriod = New TimeSpan(1, 0, 0, 0)
                    Case "H", "HH", "hour"
                        SchedulePeriod = New TimeSpan(1, 0, 0)
                    Case Else
                        SchedulePeriod = TimeSpan.Parse(CHK.StringExtension.RSStr(k, ";"))
                End Select
            Else
                NextScheduleTime = DateTime.Parse(k)
                SchedulePeriod = TimeSpan.Zero
            End If

            timerSchedule.Start()
        Else
            timerSchedule.Stop()
        End If
        UpdateScheduleMessage()
    End Sub
#End Region

#Region "CheckBox Method"

#End Region


#Region "ToolStrip Method"
    Private Sub btnRunQuery_ButtonClick(sender As Object, e As EventArgs) Handles btnRunQuery.ButtonClick
        RunQuery()
    End Sub

    Private Sub btnStopQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnStopQuery.Click
        TerminateQuery()
    End Sub

    Private Sub btnLoadQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadQuery.Click
        Dim rtvl As DialogResult = cmdgOpen.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub
        LoadQueryFromFile(cmdgOpen.FileName)
    End Sub

    Private Sub btnSaveQuery_ButtonClick(sender As System.Object, e As System.EventArgs) Handles btnSaveQuery.ButtonClick
        If Not String.IsNullOrEmpty(CurrentFileName) AndAlso System.IO.File.Exists(CurrentFileName) Then
            SaveQueryToFile(CurrentFileName)
        Else
            btnSaveAsQuery_Click(btnSaveAsQuery, Nothing)
        End If
    End Sub

    Private Sub btnSaveAsQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAsQuery.Click
        cmdgSave.FileName = CurrentFileName
        Dim rtvl As DialogResult = cmdgSave.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub
        SaveQueryToFile(cmdgSave.FileName)
    End Sub

    Private Sub btnComment_Click(sender As System.Object, e As System.EventArgs) Handles btnComment.Click
        txtQuery.CommentLines()
    End Sub

    Private Sub btnUncomment_Click(sender As System.Object, e As System.EventArgs) Handles btnUncomment.Click
        txtQuery.UncommentLines()
    End Sub

    Private Sub btnFindReplace_Click(sender As System.Object, e As System.EventArgs) Handles btnFindReplace.Click
        txtQuery.ShowFindDialog()
    End Sub

    Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click
        Dim iExec As Smart.IExecutable

        If TypeOf SourceObject Is Smart.IExecutable Then
            iExec = CType(SourceObject, Smart.IExecutable)

            Dim a As frm_SPExecutor = ParentMainForm.CreateSPExecutor(iExec)
            a.LoadObject()
        End If
    End Sub

    Private Sub btnFormat_Click(sender As System.Object, e As System.EventArgs) Handles btnFormat.Click
        FormatQuery()
    End Sub

    Private Sub btnInsertSnippet_ButtonClick(sender As System.Object, e As System.EventArgs) Handles btnInsertSnippet.ButtonClick
        mnuSnippet_Click(mnuSnippet_AuthorComment, Nothing)
    End Sub

    Private Sub mnuSnippet_Click(sender As System.Object, e As System.EventArgs) Handles mnuSnippet_AuthorComment.Click, mnuSnippet_Cursor.Click, mnuSnippet_IdentityInsert.Click, mnuSnippet_TryCatch.Click, mnuSnippet_CreateProc.Click, mnuSnippet_ConvertToAlterProc.Click, mnuSnippet_CTE.Click, mnuSnippet_ConvertToCreateProc.Click, mnuSnippet_CopyAndPasteColumnName.Click, mnuSnippet_SelectWholeText.Click
        Dim b As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim sb As New System.Text.StringBuilder()

        Select Case b.Name
            Case mnuSnippet_AuthorComment.Name
                sb.AppendLine("-- =============================================")
                sb.AppendLine("-- Author:	" & ConfigurationSettings.AuthorName)
                sb.AppendLine("-- Create date:	" & DateTime.Now.ToString)
                sb.AppendLine("-- Description:	")
                sb.AppendLine("-- =============================================")
                txtQuery.Text = sb.ToString() & vbCrLf & txtQuery.Text
            Case mnuSnippet_Cursor.Name
                sb.AppendLine("DECLARE MyCursor CURSOR FOR SELECT")
                sb.AppendLine("OPEN MyCursor")
                sb.AppendLine()
                sb.AppendLine("FETCH NEXT FROM MyCursor INTO @")
                sb.AppendLine("WHILE @@FETCH_STATUS = 0 BEGIN")
                sb.AppendLine()
                sb.AppendLine(" FETCH NEXT FROM MyCursor INTO @")
                sb.AppendLine("END")
                sb.AppendLine()
                sb.AppendLine("CLOSE MyCursor")
                sb.AppendLine("DEALLOCATE MyCursor")
                txtQuery.SelectedText = sb.ToString()
                txtQuery.Refresh()
            Case mnuSnippet_IdentityInsert.Name
                Dim k As String = InputBox("Please input the table name.")
                If k = "" Then Exit Select
                txtQuery.SelectedText = "SET IDENTITY_INSERT " & k & " ON" & vbCrLf & txtQuery.SelectedText & vbCrLf & "SET IDENTITY_INSERT " & k & " OFF"
                txtQuery.Refresh()
            Case mnuSnippet_CTE.Name
                sb.AppendLine("WITH cte AS (")
                sb.AppendLine(txtQuery.SelectedText)
                sb.AppendLine(")")
                sb.AppendLine("SELECT * FROM cte")
                txtQuery.SelectedText = sb.ToString()
                txtQuery.Refresh()
            Case mnuSnippet_TryCatch.Name
                sb.AppendLine("BEGIN TRY")
                sb.AppendLine(vbTab & "BEGIN TRANSACTION")
                sb.AppendLine(vbTab)
                sb.AppendLine(vbTab & "COMMIT TRANSACTION")
                sb.AppendLine("END TRY")
                sb.AppendLine("BEGIN CATCH")
                sb.AppendLine(vbTab)
                sb.AppendLine(vbTab & "ROLLBACK TRANSACTION")
                sb.AppendLine("END CATCH")
                txtQuery.SelectedText = sb.ToString()
                txtQuery.Refresh()
            Case mnuSnippet_CreateProc.Name
                sb.AppendLine("CREATE PROCEDURE [dbo].[]")
                sb.AppendLine()
                sb.AppendLine("AS")
                sb.AppendLine("BEGIN")
                sb.AppendLine("SET NOCOUNT ON;")
                sb.AppendLine()
                sb.AppendLine(txtQuery.Text)
                sb.AppendLine()
                sb.AppendLine("END")
                txtQuery.Text = sb.ToString()
                txtQuery.Refresh()
                FormatQuery()
            Case mnuSnippet_ConvertToAlterProc.Name
                txtQuery.Text = Smart.SqlQuery.GetObjectAlterationQuery(txtQuery.Text)
                txtQuery.Refresh()
            Case mnuSnippet_ConvertToCreateProc.Name
                txtQuery.Text = Smart.SqlQuery.GetObjectCreationQuery(txtQuery.Text)
                txtQuery.Refresh()
            Case mnuSnippet_CopyAndPasteColumnName.Name
                Dim currentLineText As String = txtQuery.CurrentLineText
                txtQuery.SelectedText = StringExtension.MidStr(currentLineText, ".", "=").Trim()
                txtQuery.Refresh()
            Case mnuSnippet_SelectWholeText.Name
                'Dim currentLineText As String = txtQuery.CurrentLineText
                'If currentLineText.Contains("'") Then 'Has Single Quote, may be word
                '    Dim lineIndexStart As Integer = txtQuery.GetFirstCharIndexOfCurrentLine()
                '    Dim currentLineCharIndex As Integer = Math.Min(txtQuery.SelectionStart - lineIndexStart, currentLineText.Length - 1) 'May at position 7 for a text with length 6.
                '    Dim i1 = currentLineText.LastIndexOf("'"c, currentLineCharIndex - 1)
                '    Dim i2 = currentLineText.IndexOf("'"c, currentLineCharIndex)
                '    If i1 >= 0 And i2 >= 0 And i2 - i1 >= 2 Then 'Must be at least 3 characters for selection 'A'
                '        txtQuery.SelectionStart = lineIndexStart + i1 + 1
                '        txtQuery.SelectionLength = i2 - i1 - 1
                '        Clipboard.Clear()
                '        Clipboard.SetText(txtQuery.SelectedText)
                '    End If
                'End If
            Case Else
                Throw New ApplicationException(b.Tag.ToString())
        End Select
    End Sub

    Private Sub mnuDo_InnerJoin_Click(sender As System.Object, e As System.EventArgs) Handles mnuDo_InnerJoin.Click
        Dim tableName1 As String = InputBox("Enter the name of Table 1, use space to seperate the Alias.", "Inner Join Tables", txtQuery.SelectedText)
        If tableName1 = "" Then Exit Sub
        Dim tableName2 As String = InputBox("Enter the name of Table 2, use space to seperate the Alias.", "Inner Join Tables")
        If tableName2 = "" Then Exit Sub

        Dim alias1 As String = "t1", alias2 As String = "t2"
        If tableName1.Contains(" AS ") Then
            alias1 = CHK.StringExtension.RSStr(tableName1, " AS ")
            tableName1 = CHK.StringExtension.LSStr(tableName1, " AS ")
        End If
        If tableName2.Contains(" AS ") Then
            alias2 = CHK.StringExtension.RSStr(tableName2, " AS ")
            tableName2 = CHK.StringExtension.LSStr(tableName2, " AS ")
        End If

        Dim dummys As String() = ConfigurationSettings.DummyColumns.Split(","c)

        Try
            ParentMainForm.DatabaseWindow.Server.ChangeDatabase(ddDatabase.Text)
            Dim db As Smart.SqlDatabase = ParentMainForm.DatabaseWindow.Server.Database
            Dim t1 As Smart.SqlTable = db.GetTable(tableName1)
            Dim t2 As Smart.SqlTable = db.GetTable(tableName2)
            Dim cols1 As String() = t1.GetColumnNames(Smart.SqlTable.ColumnType.AllColumns)
            Dim cols2 As String() = t2.GetColumnNames(Smart.SqlTable.ColumnType.AllColumns)


            Dim result As List(Of String) = cols1.Intersect(cols2).Except(dummys).ToList()
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("FROM " & tableName1 & " AS " & alias1)
            sb.AppendLine("INNER JOIN " & tableName2 & " AS " & alias2)
            For n As Integer = 0 To result.Count - 1
                If n = 0 Then
                    sb.AppendLine("ON " & alias1 & "." & result(n) & " = " & alias2 & "." & result(n))
                Else
                    sb.AppendLine("AND " & alias1 & "." & result(n) & " = " & alias2 & "." & result(n))
                End If
            Next
            txtQuery.SelectedText = sb.ToString()
            txtQuery.Refresh()
        Catch ex As Exception
            MessageBox.Show("Table " & tableName1 & " or " & tableName2 & " cannot be obtained.")
        End Try
    End Sub

    Private Sub mnuDo_SelectAllColumns_Click(sender As System.Object, e As System.EventArgs) Handles mnuDo_SelectAllColumns.Click
        Dim tableHint As String = txtQuery.SelectedText

        Dim dummyColumns As String() = ConfigurationSettings.DummyColumns.Split(","c)

        Try
            Dim tableAlias As String = CHK.StringExtension.RSStrRev(tableHint, "AS").Trim()
            Dim tableName As String = CHK.StringExtension.LSStrRev(tableHint, "AS", True).Trim()
            If tableName = "" Then Exit Sub

            ParentMainForm.DatabaseWindow.Server.ChangeDatabase(ddDatabase.Text)
            Dim db As Smart.SqlDatabase = ParentMainForm.DatabaseWindow.Server.Database
            Dim t1 As Smart.SqlTable = db.GetTable(tableName)
            Dim cols1 As String() = t1.GetColumnNames(Smart.SqlTable.ColumnType.AllColumns)

            Dim outputColumns As List(Of String) = cols1.Except(dummyColumns).ToList()
            Dim sb As New System.Text.StringBuilder()
            For n As Integer = 0 To outputColumns.Count - 1
                If n = 0 Then
                    sb.Append("SELECT " & If(tableAlias = "", "", tableAlias & ".") & outputColumns(n))
                Else
                    sb.Append(", " & If(tableAlias = "", "", tableAlias & ".") & outputColumns(n))
                End If
            Next
            sb.Append(vbCrLf & "FROM " & t1.FullName & If(tableAlias = "", "", " AS " & tableAlias))
            txtQuery.SelectedText = sb.ToString()
            txtQuery.Refresh()
        Catch ex As Exception
            MessageBox.Show("Table cannot be obtained.")
        End Try
    End Sub
#End Region

#Region "RichTextBox Method"
    Private Sub txtQuery_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim s As String = e.Data.GetData(DataFormats.Text).ToString()
            txtQuery.SelectedText = s
        ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim v As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If v IsNot Nothing AndAlso v.Length > 0 Then
                If Not txtQuery.Text = "" Then
                    Dim rtvl As DialogResult = MessageBox.Show("Are you sure to abandon the current query and load the file?", "Load", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If rtvl = Windows.Forms.DialogResult.No Then Exit Sub
                End If
                LoadQueryFromFile(v(0).ToString())
            End If
        End If
    End Sub

    Private Sub txtQuery_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.Text) Or e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtQuery_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuery.KeyPress
        'If SplitContainer1.Panel2Collapsed = False And txtQuery.Lines.Length > 10 Then SplitContainer1.Panel2Collapsed = True
    End Sub

    Private Sub txtQuery_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtQuery.KeyUp
        If e.KeyCode = Keys.F5 Then
            If btnRunQuery.Enabled = True Then RunQuery()
        End If

        If e.KeyCode = Keys.Escape Then
            SplitContainer1.Panel2Collapsed = True
        End If
    End Sub
#End Region

#Region "Timer Events"
    Private Sub timerSchedule_Tick(sender As Object, e As EventArgs) Handles timerSchedule.Tick
        If btnRunQuery.Enabled = True And DateTime.Now >= NextScheduleTime Then
            If SchedulePeriod = TimeSpan.Zero Then 'Run once, can stop
                btnScheduleRun.Checked = False
                timerSchedule.Stop()
            Else
                NextScheduleTime = NextScheduleTime.Add(SchedulePeriod)
                UpdateScheduleMessage()
            End If
            RunQuery()
        End If
    End Sub
#End Region

#Region "DataGridView Method"

#End Region

#Region "Operation"
    Public Sub LoadDatabaseList()
        Try
            'Show Dynamic Progress
            ddDatabase.Text = "Listing..."
            Application.DoEvents()

            'Get Data from Server
            Dim dtTable As DataTable
            dtTable = ParentMainForm.DatabaseWindow.Server.GetDatabases(True)

            'List Data in the Control
            ddDatabase.Items.Clear()
            For n As Integer = 0 To dtTable.Rows.Count - 1
                ddDatabase.Items.Add(dtTable.Rows(n)("name").ToString())
            Next
            ddDatabase.Text = ParentMainForm.DatabaseWindow.SelectedDatabase
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RunQuery()
        SplitContainer1.Panel2Collapsed = False
        TabControl1.SelectTab(tabMessage)
        StartExecutionTime = DateTime.Now
        IsExecuting = True
        btnRunQuery.Enabled = False
        btnStopQuery.Enabled = Not btnRunQuery.Enabled

        Control.CheckForIllegalCrossThreadCalls = False
        RunningThread = New System.Threading.Thread(AddressOf StartQueryThread)
        TimerThread = New System.Threading.Thread(AddressOf StartTimerThread)
        RunningThread.Start()
        TimerThread.Start()
    End Sub

    Public Sub TerminateQuery()
        If RunningThread.ThreadState = Threading.ThreadState.Running Then
            RunningQuery.Stop()
        End If
    End Sub

    Private Delegate Sub RunQueryDelegeate(executionResults As List(Of Smart.SqlQueryResult))
#End Region

#Region "Message Driven and Asynchronous Query"
    Public Sub StartQueryThread() 'May be Time Consuming
        Dim db As Smart.SqlDatabase = ParentMainForm.DatabaseWindow.Server.GetDatabase(ddDatabase.Text)
        RunningQuery = db.NewQuery()
        RunningQuery.SetServer(ParentMainForm.DatabaseWindow.Server)
        RunningQuery.Text = txtQuery.Text
        Dim results As Smart.SqlQueryResult() = RunningQuery.Execute(Smart.SqlQuery.ErrorDescription.SingleDetail) 'Multiple set of results are returned
        IsExecuting = False
        Me.Invoke(New RunQueryDelegeate(AddressOf RunQueryAsync), results.ToList())
    End Sub

    Public Sub StartTimerThread()
        Do While IsExecuting
            Dim s As TimeSpan = DateTime.Now.Subtract(StartExecutionTime)
            txtMessage.Text = "Query is executing... " & vbCrLf & "Time Elasped: " & s.TotalSeconds.ToString("0.0") & "s"
            System.Threading.Thread.Sleep(100)
        Loop
    End Sub

    Public Sub RunQueryAsync(executionResults As List(Of Smart.SqlQueryResult))
        'Query has finished processing
        btnRunQuery.Enabled = True
        btnStopQuery.Enabled = Not btnRunQuery.Enabled
        txtMessage.Text = ""
        If executionResults Is Nothing OrElse executionResults.Count = 0 Then Exit Sub 'No Result

        'Bind result tables
        SplitContainer1.Panel2Collapsed = False
        RemoveAllDataTabs()

        'Show dataset result to Window, show the first execute result (first GO) only
        If chkResultToWindow.Checked Then
            BindQueryResultToWindow(executionResults)
        End If

        'Export dataset result
        Dim addMessage As String = ""
        If chkResultToCsv.Checked Then
            addMessage = ExportQueryResultToCsv(executionResults)
        End If

        'Show the query result successful and error messages
        BindQueryMessageToWindow(executionResults, addMessage)

        UpdateTabLayout()
        txtQuery.Focus()
    End Sub

    Private Sub BindQueryResultToWindow(executionResults As List(Of Smart.SqlQueryResult))
        With executionResults(0)
            If .Data IsNot Nothing Then
                Dim tmp As String
                For n As Integer = 0 To .Data.Tables.Count - 1
                    tmp = "No. of rows: " & .Data.Tables(n).Rows.Count & "  columns: " & .Data.Tables(n).Columns.Count & "  Execution Time: " & .ExecutionTime.TotalMilliseconds & " ms"
                    CreateDataTab(.Data.Tables(n), tmp)
                Next
            End If
        End With
    End Sub

    Private Function ExportQueryResultToCsv(executionResults As List(Of Smart.SqlQueryResult)) As String
        Dim msg As New System.Text.StringBuilder
        Dim fileNamePattern As String = "TableViewer_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & "_{0}.csv"
        If System.IO.Directory.Exists(txtQueryResultExportPath.Text) Then 'append directory
            fileNamePattern = CHK.FileSystem.NormalizeDirectory(txtQueryResultExportPath.Text) & fileNamePattern
        End If
        msg.AppendLine("Export File Name: " & fileNamePattern)

        'Only export first result
        With executionResults(0)
            If .HasError = False And .Data IsNot Nothing Then
                For n As Integer = 0 To .Data.Tables.Count - 1
                    msg.AppendLine("Exporting Result " & (n + 1) & ": " & .Data.Tables(n).Rows.Count)
                    Try
                        CHK.BatchTable.ExportToCSV(.Data.Tables(n).DefaultView, String.Format(fileNamePattern, (n + 1).ToString()), True)
                    Catch ex As Exception
                        msg.AppendLine(ex.Message)
                    End Try
                Next
            End If
        End With

        Return msg.ToString()
    End Function

    Private Sub BindQueryMessageToWindow(executionResults As List(Of Smart.SqlQueryResult), addMessage As String)
        'Show Message for all resutls
        Dim containsError As Boolean = False
        Dim msg As New System.Text.StringBuilder
        Dim queryStartTime As Date, queryEndTime As Date

        For n As Integer = 0 To executionResults.Count - 1
            With executionResults(n)
                If n = 0 Then queryStartTime = .StartTime
                If n = executionResults.Count - 1 Then queryEndTime = .EndTime

                msg.AppendLine("Execution Result " & (n + 1) & ":")
                If .HasError = True Then 'Has Error
                    msg.AppendLine("Line " & .ErrorLine & ", Message " & .ErrorNumber & ", Severity " & .ErrorSeverity & ", State " & .ErrorState & vbCrLf & .ErrorMessage)
                    msg.AppendLine("Dump Message:" & vbCrLf & .Message)
                    btnGotoError.Tag = .ErrorLine 'Save the Error Line Number
                    containsError = True
                Else 'Success
                    msg.AppendLine(CStr(IIf(.Message = "", "Command executed successfully.", .Message)))
                    msg.AppendLine("Affected Rows: " & .AffectedRows.ToString())
                    msg.AppendLine("Execution Time: " & .ExecutionTime.TotalMilliseconds & " ms    " & CHK.DateTimeExtension.FormatShortDuration(.ExecutionTime))
                End If
            End With
            msg.AppendLine()
        Next
        msg.Insert(0, "Execution Start: " + queryStartTime.ToString() & vbCrLf)
        If Not String.IsNullOrEmpty(addMessage) Then msg.AppendLine(addMessage)
        msg.AppendLine("Execution End: " + queryEndTime.ToString())
        txtMessage.Text = msg.ToString()

        If containsError = True Then
            TabControl1.SelectedTab = tabMessage 'Must show Error Message
            btnGotoError.Visible = True
            txtMessage.ForeColor = Color.Red
        Else
            If DataTabPages.Count > 0 Then TabControl1.SelectedTab = DataTabPages(0)
            btnGotoError.Visible = False
            txtMessage.ForeColor = Color.White
        End If
    End Sub
#End Region

#Region "Tab Management"
    Dim DataTabPages As New List(Of TabPage)
    Dim StaticTabPages As New List(Of TabPage)

    Private Sub InitializeTab()
        StaticTabPages.Add(tabMessage)
    End Sub

    Private Sub UpdateTabLayout()
        TabControl1.TabPages.Clear()
        For n As Integer = 0 To DataTabPages.Count - 1
            TabControl1.TabPages.Add(DataTabPages(n))
        Next
        For n As Integer = 0 To StaticTabPages.Count - 1
            TabControl1.TabPages.Add(StaticTabPages(n))
        Next
    End Sub

    Private Sub CreateDataTab(dtSrc As DataTable, status As String)
        Dim index As Integer = CInt(DataTabPages.Count + 1)
        Dim tab As New TabPage
        tab.Name = "tabData" & index.ToString()
        tab.Text = "Data " & index.ToString() & " (" & dtSrc.Rows.Count & " rows " & dtSrc.Columns.Count & " cols)"

        Dim dg As New CHKControl.GridView.DbDataGrid()
        dg.Name = "dgData" & index.ToString()
        dg.Location = New Point(0, 20)
        dg.Size = New Size(SplitContainer1.Panel2.Width - 15, SplitContainer1.Panel2.Height - 55)
        dg.Dock = DockStyle.Fill
        dg.ReadOnly = True
        dg.AllowUserToAddRows = False
        dg.AutoGenerateColumns = True
        'dg.RowHeadersVisible = False
        dg.DataSource = dtSrc
        dg.Refresh()
        tab.Controls.Add(dg)

        TabControl1.TabPages.Add(tab)
        DataTabPages.Add(tab)
        If ConfigurationSettings.AutoResizeQueryResult Then dg.AutoResizeColumns()
    End Sub

    Private Sub RemoveAllDataTabs()
        For Each t As TabPage In DataTabPages
            TabControl1.TabPages.Remove(t)
        Next
        DataTabPages.Clear()
    End Sub
#End Region

#Region "Function [Layout]"
    Public Sub AutoSizeGrid()
        'If btnAutoSize.Checked = True Then
        '    ShowStatus("Resizing...")
        '    Application.DoEvents()
        '    dgResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        '    dgResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'Else
        '    ShowStatus("Restoring...")
        '    Application.DoEvents()
        '    dgResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        '    dgResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        'End If

        'RestoreStatus()
    End Sub

    Public Sub Decorate()
        Dim f As Font
        f = New Font(ConfigurationSettings.QueryFontFamily, ConfigurationSettings.QueryFontSize, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtQuery.Font = f

        If SourceObject IsNot Nothing AndAlso TypeOf SourceObject Is Smart.IExecutable Then
            btnExecute.Visible = True
        Else
            btnExecute.Visible = False
        End If
    End Sub

    Public Sub UpdateScheduleMessage()
        If timerSchedule.Enabled Then
            btnScheduleRun.Text = "Schedule (" & NextScheduleTime.ToLongTimeString & ")"
            btnScheduleRun.ToolTipText = "Next Run Time: " & NextScheduleTime.ToString() & If(SchedulePeriod <> TimeSpan.Zero, vbCrLf & "Every " & CHK.DateTimeExtension.FormatDuration(SchedulePeriod, False), "")
        Else
            btnScheduleRun.Text = "Schedule"
            btnScheduleRun.ToolTipText = ""
        End If
    End Sub
#End Region

#Region "Function [Query File Management]"
    Public Sub SaveQueryToFile(path As String)
        System.IO.File.WriteAllText(path, txtQuery.Text, System.Text.Encoding.UTF8)
        CurrentFileName = path
    End Sub

    Public Sub LoadQueryFromFile(database As String, path As String)
        ddDatabase.Text = database
        LoadQueryFromFile(path)
    End Sub

    Public Sub LoadQueryFromFile(path As String)
        If System.IO.File.Exists(path) Then
            txtQuery.Text = System.IO.File.ReadAllText(path)
            CurrentFileName = path
        Else
            MessageBox.Show("File is not found. " & path)
        End If
    End Sub
#End Region

#Region "Miscellaneous Functions"
    Private Sub ShowStatus(msg As String)
        ShowStatus(msg, False)
    End Sub

    Private Sub ShowStatus(msg As String, isError As Boolean)
        txtMessage.Tag = txtMessage.Text 'Record Old Msg
        txtMessage.Text = msg
        If isError = False Then
            txtMessage.ForeColor = Color.Black
        Else
            txtMessage.ForeColor = Color.Red
        End If
        Application.DoEvents()
    End Sub

    Private Sub RestoreStatus()
        txtMessage.Text = txtMessage.Tag.ToString()
    End Sub

    Public Sub SetSource(obj As Smart.SqlDatabaseObject)
        SourceObject = obj
        Decorate()
    End Sub

    Public Sub SetQuery(database As String, query As String)
        ddDatabase.Text = database
        txtQuery.Text = query
    End Sub

    Public Sub FormatQuery()
        'txtQuery.FormatDoc()
    End Sub
#End Region

#Region "Interfaces"
    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub

#End Region

End Class
