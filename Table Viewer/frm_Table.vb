Imports System.Data.SqlClient

Public Class frm_Table : Implements IFormRefresh, IFormClose
    Public Table As Smart.SqlTable
    Dim ColumnsListSorted As String = ""
    Dim ColumnsListUnsorted As String = ""
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property
    Private ReadOnly Property DummyColumns() As String()
        Get
            Return ConfigurationSettings.DummyColumns.Split(","c)
        End Get
    End Property

#Region "Form Events"
    Private Sub frm_Table_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub

    Private Sub frm_Table_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AreChangesExist() Then
            Dim rtvl As DialogResult
            rtvl = MessageBox.Show("Do want to discard changes?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
            If rtvl = Windows.Forms.DialogResult.No Then 'Cancel Exit
                e.Cancel = True
                Exit Sub
            End If
        End If


        Dim vs As New TableViewStatus(Table.FullName)
        vs.WhereConditions.Add(ddWhereClause.Text)
        vs.Ordering = txtOrderClause.Text
        For Each a As DataGridViewRow In dgTableColumn.Rows
            Dim b As Boolean = DirectCast(a.Cells(0).FormattedValue, Boolean)
            If b = False Then vs.InvisibleColumns.Add(a.Cells(1).Value.ToString())
        Next

        If ParentMainForm.ViewCaches.ContainsKey(vs.TableName) Then
            ParentMainForm.ViewCaches(vs.TableName) = vs
        Else
            ParentMainForm.ViewCaches.Add(vs.TableName, vs)
        End If

        ParentMainForm.RemoveTableWindow(Me)
    End Sub

    Private Sub frm_Table_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        panelColumn.Width = ConfigurationSettings.ColumnPanelWidth
        panelColumn.Location = New Point(Me.Width - panelColumn.Width - 15, panelColumn.Location.Y)
        dgcName.Width = dgTableColumn.Width - 130

        txtRecordLimit.Text = ConfigurationSettings.MaximumRecordShown

        LoadTableViewStatus(True)
    End Sub

    ''' <summary>
    ''' Load the last stored view status of this window, e.g. where clauses, column visibilities.
    ''' </summary>
    Public Sub LoadTableViewStatus(withRefresh As Boolean)
        If ParentMainForm.ViewCaches.ContainsKey(Table.FullName) Then
            Dim vs As TableViewStatus = ParentMainForm.ViewCaches(Table.FullName)
            If vs.WhereConditions.Count > 0 Then ddWhereClause.Text = vs.WhereConditions(0)
            txtOrderClause.Text = vs.Ordering
        End If

        If withRefresh Then LoadTable()
    End Sub
#End Region

#Region "Button and Other Controls Events"
    Private Sub btnShowColumnsPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColumnsPanel.Click
        SwitchColumnPanel()
    End Sub

    Private Sub btnAutoSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoSize.Click
        AutoSizeGrid()
    End Sub

    Private Sub btnRefresh_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.ButtonClick
        LoadTable(False)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        LoadTable(True)
    End Sub

    Private Sub timerFilter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerFilter.Tick
        ApplyColumnFilter()
        timerFilter.Enabled = False
    End Sub

    Private Sub timerFind_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerFind.Tick
        dgContent.ClearHighlight(True)
        lblFindStatus.Text = ""
        txtFindData.BackColor = Color.White
        timerFind.Enabled = False
        If txtFindData.Text = "" Then Exit Sub

        lblFindStatus.Text = "Highlighting..."
        Application.DoEvents()
        Dim c As DataGridViewCell = dgContent.HighlightCells(txtFindData.Text, True)
        If c IsNot Nothing Then dgContent.FirstDisplayedScrollingRowIndex = c.RowIndex
    End Sub



    Private Sub btnAddRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRows.Click
        Dim k As Integer, tmp As String
        Dim defRows As String = ""
        Dim tmpR As String() = GetClipboardDataRows()
        defRows = tmpR.Length.ToString()

        tmp = InputBox("Please enter the number of rows you would like to add, the number of rows is default from your clipboard data", "Add Rows", defRows)
        If tmp = "" Then Exit Sub
        k = Integer.Parse(tmp)
        If k <= 0 Then Exit Sub

        dgContent.AddEmptyRows(k, True)
    End Sub

    Private Sub btnEditStructure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditStructure.Click
        If Table.ObjectType = Smart.CommonProperty.GetObjectTypeCode(Smart.CommonProperty.DatabaseObject.Table) Then 'Table
            Dim a As frm_TableStructure = ParentMainForm.CreateTableStructureWindow(Table)
        Else
            Dim a As frm_SQL = ParentMainForm.CreateQueryWindow(Table.Name)
            a.SetQuery(Table.Database, Table.GetDefinition(False))
        End If
    End Sub

    Private Sub txtFindData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindData.TextChanged
        timerFind.Enabled = True
        txtFindData.BackColor = Color.LightBlue
    End Sub

    Private Sub txtFindData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindData.DoubleClick
        timerFind.Enabled = True
        txtFindData.BackColor = Color.LightBlue
    End Sub

    Private Sub lblWhereClause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblWhereClause.Click
        If ddWhereClause.Text = "" Then
            ddWhereClause.Text = "1=2"
        Else
            ddWhereClause.Text = ""
        End If
        LoadTable()
    End Sub

    Private Sub txtRecordLimit_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecordLimit.KeyUp
        If e.KeyCode = Keys.Enter Then
            RefreshForm()
        End If
    End Sub

    Private Sub btnGenerateSQL_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateSQL.ButtonClick
        mnuGenerateQuery_Click(DataToolStripMenuItem, Nothing)
    End Sub

    Private Sub mnuGenerateQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem1.Click, ToolStripSeparator2.Click, SelectToolStripMenuItem.Click, InsertToolStripMenuItem.Click, DeleteToolStripMenuItem.Click, AdvancedToolStripMenuItem.Click, DataToolStripMenuItem.Click, TruncateToolStripMenuItem.Click, ToolStripMenuItem2.Click, ToolStripMenuItem3.Click
        Dim btn As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim code As String = ""
        Dim builder As New Smart.SqlQueryBuilder(Table)

        Select Case btn.Tag.ToString() 'Command Name
            Case "SQLSelect"
                code = builder.GetSelectSQL("", Smart.SqlTable.ColumnType.Asterisk, ddWhereClause.Text)
                code &= vbCrLf & "--" & builder.GetSelectSQL("t", Smart.SqlTable.ColumnType.AllColumns, ddWhereClause.Text)
            Case "SQLInsert"
                code = builder.GetInsertSQL(Smart.SqlTable.ColumnType.AllColumns)
            Case "SQLDelete"
                code = builder.GetDeleteSQL(ddWhereClause.Text)
            Case "SQLUpdate"
                code = builder.GetUpdateSQL(Smart.SqlTable.ColumnType.NonPrimaryKeys, ddWhereClause.Text)
            Case "SQLTruncate"
                code = builder.GetTruncateSQL()
            Case "SQLDrop"
                code = builder.GetDropSQL(True)
            Case "Advanced"
                ParentMainForm.CreateSQLSynthesizer(Table)
                Exit Sub
            Case "SQLGroup"
                code = builder.GetSelectGroupBySQL(GetSeletedColumnsFromCells().ToArray(), "t", ddWhereClause.Text)
            Case "Data"
                Dim c As frm_SQLScript = ParentMainForm.CreateSQLScripterWindow("SQL Scripter: " & Table.Name)
                c.SetParameter(Table, ddWhereClause.Text)
                c.LoadTable()
                Exit Sub
            Case Else
                Throw New ApplicationException("The command " + btn.Tag.ToString() + " is not found.")
        End Select

        Dim a As frm_SQL = ParentMainForm.CreateQueryWindow("")
        a.SetQuery(Table.Database, code)
        a.Show()
    End Sub

    'Private Sub btnShowDependencies_ButtonClick(sender As System.Object, e As System.EventArgs) Handles btnShowDependencies.ButtonClick
    '    btnShowRelatedTables_Click(Nothing, Nothing)
    'End Sub

    'Private Sub btnShowAllDependencies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAllDependencies.Click
    '    ParentMainForm.CreateDependencyWindow(Table.ObjectID)
    'End Sub

    'Private Sub btnShowRelatedTables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowRelatedTables.Click
    '    If dgContent.CurrentCell Is Nothing Then Exit Sub
    '    ParentMainForm.DatabaseWindow.Server.ChangeDatabase(Table.Database)
    '    Dim keyName As String = dgContent.Columns(dgContent.CurrentCell.ColumnIndex).HeaderText
    '    Dim tables As Integer() = ParentMainForm.DatabaseWindow.Server.Database.SearchTableByPrimaryKey(keyName)

    '    Dim builder As New CHK.Database.SmartCommandBuilder()
    '    For n As Integer = 0 To tables.Length - 1
    '        If tables(n) = Me.Table.ObjectID Then Continue For 'Your own table, skip
    '        Dim f = ParentMainForm.DatabaseWindow.OpenTableFormById(tables(n), Database.SmartCommandBuilder.GetFormattedColumnName(keyName) & " = " & builder.GetFormattedValue(dgContent.CurrentCell.Value))
    '        f.AutoSizeGrid()
    '    Next
    'End Sub

    Private Sub btnSave_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.ButtonClick
        SaveTable()
    End Sub

    Private Sub btnExportCsv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportCsv.Click
        Dim rtvl As DialogResult
        cmdgSave.Filter = "Comma-seperated Values (*.csv)|*.csv"
        rtvl = cmdgSave.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim source As DataTable = CType(dgContent.DataSource, DataTable)
        BatchTable.ExportToCSV(source.DefaultView, cmdgSave.FileName, True)
    End Sub

    Private Sub btmExportHtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmExportHtml.Click
        Dim rtvl As DialogResult
        cmdgSave.Filter = "HTML file (*.htm)|*.htm"
        rtvl = cmdgSave.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub

        'Dim source As DataTable = CType(dgContent.DataSource, DataTable)
        'BatchTable.ExportToHtml(source.DefaultView, cmdgSave.FileName, True)
    End Sub



    Private Sub btnGenerateGUID_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerateGUID.Click
        lblStatus.Text = "Generating GUID..."
        Application.DoEvents()
        ParentMainForm.DatabaseWindow.Server.ChangeDatabase(Table.Database)
        For n As Integer = 0 To dgContent.SelectedCells.Count - 1
            dgContent.SetCellValue(dgContent.SelectedCells(n).RowIndex, dgContent.SelectedCells(n).ColumnIndex, ParentMainForm.DatabaseWindow.Server.Database.GetNewGUID())
        Next
        lblStatus.Text = ""
    End Sub
#End Region

#Region "Table Column Panel Events"
    'Private Sub btnToggleColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim b As Boolean, a As DataGridViewRow

    '    For Each a In dgTableColumn.Rows
    '        b = DirectCast(a.Cells(0).FormattedValue, Boolean)
    '        a.Cells(0).Value = Not b
    '    Next

    '    ApplyColumnFilter()
    'End Sub


    Private Sub btnCopyColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyColumn.Click
        Dim rtvl As DialogResult
        rtvl = MessageBox.Show("Do you want to copy the unsorted version of columns list?" & vbCrLf & "Press Yes for unsorted" & vbCrLf & "Press No for sorted", "Copy", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)

        Select Case rtvl
            Case Windows.Forms.DialogResult.Yes
                Clipboard.Clear()
                Clipboard.SetText(ColumnsListUnsorted)
            Case Windows.Forms.DialogResult.No
                Clipboard.Clear()
                Clipboard.SetText(ColumnsListSorted)
        End Select
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOtherColumn.Click, btnShowKey.Click, btnShowDummyColumn.Click
        Dim c As ToolStripButton = CType(sender, ToolStripButton)
        Dim tag As String = c.Tag.ToString() 'Column Type
        Dim checked As Boolean = c.Checked

        Dim r As DataGridViewRow
        For Each r In dgTableColumn.Rows
            If r.Tag.ToString() = tag Then 'Same Column Type
                r.Cells(0).Value = checked
            End If
        Next

        ApplyColumnFilter()
    End Sub

    Private Sub btnAutoSelectColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoSelectColumn.Click
        SelectCommonlyUsedColumnInColumnPanel()
    End Sub

    Private Sub txtFastSwitchColumnName_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFastSwitchColumnName.KeyUp
        Dim inputText As String = txtFastSwitchColumnName.Text

        If e.KeyCode = Keys.Enter Then 'Toggle Column Visibility
            For n As Integer = 0 To dgTableColumn.RowCount - 1
                If dgTableColumn.Rows(n).Visible Then
                    dgTableColumn.Rows(n).Cells(dgcShow.Index).Value = Not CBool(dgTableColumn.Rows(n).Cells(dgcShow.Index).Value)
                    If e.Shift = False Then Exit For 'For SHIFT+ENTER, Select All
                End If
            Next
            ApplyColumnFilter()

        ElseIf inputText = "\" Then 'Hide All
            Dim r As DataGridViewRow
            For Each r In dgTableColumn.Rows
                If r.Tag.ToString() = "KEY" Then 'Is Primary Key, show
                    r.Cells(0).Value = True
                Else
                    r.Cells(0).Value = False
                End If
            Next
            txtFastSwitchColumnName.Text = "" 'Reset text
            ApplyColumnFilter()

        ElseIf inputText = "" Then 'Reset Filter to Column List
            For n As Integer = 0 To dgTableColumn.RowCount - 1
                dgTableColumn.Rows(n).Visible = True
            Next

        Else 'Filter Column List
            For n As Integer = 0 To dgTableColumn.RowCount - 1
                Dim tmpC As String = dgTableColumn.GetCellString(n, dgcName.Index)
                If CHK.StringExtension.Contains(tmpC, inputText, False) Then
                    dgTableColumn.Rows(n).Visible = True
                Else
                    dgTableColumn.Rows(n).Visible = False
                End If
            Next
        End If
    End Sub
#End Region

#Region "Combo Box and List Events"
    Private Sub ddWhereClause_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ddWhereClause.KeyDown
        If e.KeyCode = Keys.Enter Then
            If AreChangesExist() Then
                Dim rtvl As DialogResult
                rtvl = MessageBox.Show("Do want to discard changes?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                If rtvl = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            LoadTable(False)
            ddWhereClause.AddHistory()
            ddWhereClause.SelectAll()
        End If
    End Sub

    Private Sub txtOrderClause_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrderClause.KeyDown
        If e.KeyCode = Keys.Enter Then
            If AreChangesExist() Then
                Dim rtvl As DialogResult
                rtvl = MessageBox.Show("Do want to discard changes?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                If rtvl = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            LoadTable(False)
        End If

        If e.KeyCode = Keys.Up Then
            If txtOrderClause.Text.EndsWith(" desc") Then txtOrderClause.Text = StringExtension.LSStr(txtOrderClause.Text, " desc")
        End If
        If e.KeyCode = Keys.Down Then
            If Not txtOrderClause.Text.EndsWith("desc") Then txtOrderClause.Text &= " desc"
        End If
    End Sub
#End Region

#Region "Data Grid View Events"
    Private Sub dgTableColumn_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTableColumn.CellClick
        Select Case e.ColumnIndex
            Case 0 'Check Box
            Case 1 'Column Name, do navigation
                FindAndHighlightColumnInDataGrid(dgTableColumn.CurrentRow.Cells(1).Value.ToString())
                SwitchColumnPanel()
            Case 2 'DataType
                Clipboard.Clear()
                Clipboard.SetText(dgTableColumn.CurrentRow.Cells(1).Value.ToString())
        End Select
    End Sub

    Private Sub dgContent_CellHighlighted(ByVal highlightText As String, ByVal e As CHKControl.GridView.SmartDataGrid.CellHighlightedEventArgs) Handles dgContent.CellHighlighted
        lblFindStatus.Text = "Match: " & e.MatchCount.ToString() & "E / " & e.PartialMatchCount.ToString() & "P"
    End Sub

    Private Sub dgTableColumn_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgTableColumn.ColumnHeaderMouseClick
        If e.ColumnIndex = 0 Then 'Check/Uncheck All
            If dgTableColumn.Rows.Count = 0 Then Exit Sub

            Dim n As Integer, b As Boolean
            b = CBool(dgTableColumn.Rows(0).Cells(0).Value) 'Get the first row check status
            For n = 0 To dgTableColumn.Rows.Count - 1
                dgTableColumn.Rows(n).Cells(0).Value = Not b
            Next

            ApplyColumnFilter()
        End If
    End Sub

    'Private Sub dgTableColumn_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTableColumn.CellValueChanged
    '    If e.ColumnIndex = 0 Then ApplyColumnFilter()
    'End Sub

    Private Sub dgTableColumn_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTableColumn.CellContentClick
        Select Case e.ColumnIndex
            Case 0 'Check Box
                ApplyColumnFilter() 'Immediate Version
            Case 1 'Column Name, do navigation
            Case 2 'DataType
        End Select
    End Sub

    Private Sub dgContent_CellMouseDown(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgContent.CellMouseDown
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then 'Data Row
            If e.Button = Windows.Forms.MouseButtons.Middle Then SwitchColumnPanel()
            HighlightColumnInColumnPanel(dgContent.Columns(e.ColumnIndex).Name)
        Else 'Header Row
            If e.ColumnIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Middle Then
                Dim currentColumn As String = dgContent.Columns(e.ColumnIndex).Name
                For n As Integer = 0 To dgTableColumn.Rows.Count - 1
                    Dim tmp As String = dgTableColumn.Rows(n).Cells(dgcName.Index).Value.ToString()
                    If tmp = currentColumn Then
                        dgTableColumn.Rows(n).Cells(dgcShow.Index).Value = False
                        Exit For
                    End If
                Next
                ApplyColumnFilter()
            End If
        End If
    End Sub

    Private Sub dgContent_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgContent.CellMouseUp
        If e.RowIndex = -1 And e.ColumnIndex = -1 Then Exit Sub 'Corner Selected, Exit
        Dim s As CHKControl.GridView.SmartDataGrid.GridViewStatistics = dgContent.GetStatistics()
        If s.Count > 1 Then
            Dim msg As String = ""
            msg &= "Count:" & s.ValidCount
            msg &= " Rows:" & s.RowCount
            If s.Sum > 0 Then
                msg &= " Sum:" & s.Sum
                If s.ValidCount > 0 Then msg &= " Avg:" & Math.Round((s.Sum / s.ValidCount), 6)
            Else
                msg &= " Length:" & s.Length
            End If
            lblStatistics.Text = msg
        Else
            lblStatistics.Text = "Length:" & s.Length
        End If
    End Sub

    Private Sub dgContent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgContent.KeyDown
        If e.KeyCode = Keys.F3 Then
            e.Handled = True
        End If

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.S 'Ctrl + S (Save)
                    SaveTable()
            End Select
        End If
    End Sub

    Private Sub dgContent_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgContent.KeyUp
        'If e.KeyCode = Keys.Apps Then
        '    SwitchColumnPanel()
        'End If
    End Sub

    Private Sub dgTableColumn_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgTableColumn.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            SwitchColumnPanel()
        End If
    End Sub

    Private Sub dgContent_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgContent.MouseUp

    End Sub

    Private Sub dgContent_SQLWhereCopied(ByVal sender As System.Object, ByVal sql As System.String) Handles dgContent.SQLWhereCopied
        ddWhereClause.Text = sql
        ddWhereClause_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub
#End Region

#Region "Table and Grid (Data)"
    Public Sub LoadTable()
        LoadTable(True)
    End Sub

    Public Sub LoadTable(ByVal RefreshFilterColumnList As Boolean)
        lblStatus.Text = "Loading Table Data..."
        Application.DoEvents()

        Dim bench1 As New BenchmarkItem("Load Table")
        Dim pk() As String = Nothing
        Dim dtTable As DataTable = Nothing
        Dim totalCount As Integer

Restart:
        bench1.Reset()

        'Prepare SQL
        Dim builder As New Smart.SqlQueryBuilder(Table)
        Dim sqlData As String, sqlCount As String
        If ddWhereClause.Text = "" And Not TypeOf Table Is Smart.SqlView Then
            sqlCount = builder.GetTableRowCount() 'Faster (get from system table directly, only appliable to table)
        Else
            sqlCount = builder.GetCountSQL(ddWhereClause.Text) 'Slower (get from count(*))
        End If
        sqlData = builder.GetSelectSQL("", Smart.SqlTable.ColumnType.Asterisk, ddWhereClause.Text, txtOrderClause.Text, StringConverter.ToIntegerNull(txtRecordLimit.Text))

        Try
            bench1.Start()
            'dtTable = Table.GetData(sqlData, 0, StringConverter.ToIntegerNull(txtRecordLimit.Text), totalCount)
            dtTable = Table.GetFastData(sqlData, sqlCount, totalCount)
            bench1.Stop()
            pk = Table.GetPrimaryKeys()

            For m As Integer = 0 To dtTable.Columns.Count - 1
                If Table.Columns.ContainsKey(dtTable.Columns(m).ColumnName) Then
                    dtTable.Columns(m).ReadOnly = Table.Columns(dtTable.Columns(m).ColumnName).ReadOnly
                End If
            Next

            'dgContent.DataSource = Nothing
            'dgContent.DataSource = dtTable
            'dgContent.Refresh()
            dgContent.BindDataTable(dtTable, True)
        Catch ex As SqlClient.SqlException
            If ex.Number = 105 And Not ddWhereClause.Text.EndsWith("'") Then 'Error Number 105 (Missing Closing Quote)
                ddWhereClause.Text &= "'" 'Try add single quote at the back
                GoTo Restart 'Retry
            Else
                MessageBox.Show(ex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Catch ex As Exception 'SQL exception
            MessageBox.Show(ex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        'Check is Table or View and Control Program Buttons
        Dim isTable As Boolean = CBool(IIf(Table.ObjectType = Smart.CommonProperty.GetObjectTypeCode(Smart.CommonProperty.DatabaseObject.Table), True, False))
        btnSave.Enabled = isTable
        btnAddRows.Enabled = isTable
        dgContent.AllowUserToAddRows = isTable
        dgContent.AllowUserToDeleteRows = isTable

        'Generate Column Panel
        If RefreshFilterColumnList = True Then
            CreateColumnPanel()
        Else
            ApplyColumnFilter()
        End If

        'Highlight Key Column in DataGridVeiw
        Dim defWidth As Integer = ConfigurationSettings.TableColumnDefaultWidth
        For n As Integer = 0 To dgContent.ColumnCount - 1
            If Array.IndexOf(pk, dgContent.Columns(n).HeaderText) >= 0 Then
                dgContent.Columns(n).DefaultCellStyle.BackColor = Color.LightYellow
            Else
                dgContent.Columns(n).DefaultCellStyle.BackColor = Color.White
            End If

            If dgContent.Columns(n).ReadOnly Then
                dgContent.Columns(n).DefaultCellStyle.ForeColor = Color.Gray
            End If

            dgContent.Columns(n).Width = defWidth
        Next

        'Check for Auto Increment
        Dim autoIncrementColumn As String = Table.GetAutoIncrementColumn()
        If Not autoIncrementColumn = "" Then
            dgContent.Columns(autoIncrementColumn).ReadOnly = True
            dgContent.Columns(autoIncrementColumn).DefaultCellStyle.ForeColor = Color.Gray
        End If

        'DataGridView Column Style
        Dim cellStyle As New DataGridViewCellStyle
        cellStyle.WrapMode = DataGridViewTriState.True
        dgContent.DefaultCellStyle = cellStyle
        ddWhereClause.Focus()

        'Program Caption and Status Display
        Me.Text = Table.FullName & " - " & Table.Database & ""
        lblStatus2.Text = "Records: " & dtTable.Rows.Count.ToString() & "/" & totalCount & "  Columns: " & dgContent.Columns.Count & "  Time: " & DateTimeExtension.FormatShortDuration(bench1.Duration)
        lblStatus.Text = ""

        'Table Data Decoration
        If ConfigurationSettings.ColorizeTableData = True Then DecorateGrid()
    End Sub

    Public Sub SaveTable()
        Dim SourceTable As DataTable, ChangesTable As DataTable
        Dim x As Integer, y As Integer
        lblStatus.Text = "Saving Table Data..."
        If dgContent.CurrentCell IsNot Nothing Then
            x = dgContent.CurrentCell.RowIndex 'Save Current Cell Position
            y = dgContent.CurrentCell.ColumnIndex
            dgContent.CurrentCell = Nothing 'Clear Current Cell to reflect changes complete
        End If
        Application.DoEvents()

        SourceTable = CType(dgContent.DataSource, DataTable)
        TrimTable(SourceTable)
        ChangesTable = SourceTable.GetChanges()

        If ChangesTable Is Nothing OrElse ChangesTable.Rows.Count = 0 Then
            lblStatus.Text = ""
        Else
            Try
                Dim rowsAffected As Integer = ChangesTable.Rows.Count
                Table.UpdateData(ChangesTable)
                SourceTable.AcceptChanges()
                lblStatus.Text = "Saved at " & DateTime.Now.ToLongTimeString() & " (" & rowsAffected & " rows affected)"
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                lblStatus.Text = "Save Failure"
            End Try
        End If

    End Sub

    Public Sub TrimTable(ByVal inputTable As DataTable)
        If inputTable Is Nothing Then Exit Sub

        Dim pks As String() = Table.GetPrimaryKeys()
        Dim autoInc As String = Table.GetAutoIncrementColumn()
        Dim isEmptyRow As Boolean = True

        For n As Integer = inputTable.Rows.Count - 1 To 0 Step -1 'Loop each row
            If Not inputTable.Rows(n).RowState = DataRowState.Added Then Continue For 'Skip if rows is Modified or Deleted

            isEmptyRow = True
            For k As Integer = 0 To inputTable.Columns.Count - 1
                If inputTable.Columns(k).DataType Is GetType(Boolean) Then Continue For
                If inputTable.Rows(n)(k) IsNot Nothing And inputTable.Rows(n)(k) IsNot DBNull.Value Then
                    isEmptyRow = False
                    Exit For
                End If
            Next

            If isEmptyRow Then inputTable.Rows.RemoveAt(n)
        Next
    End Sub

    Public Sub DecorateGrid()
        For n As Integer = 0 To dgContent.Columns.Count - 1
            If dgContent.Columns(n).ReadOnly = True Then Continue For 'Ignored, text should be in gray already
            Dim colName As String = dgContent.Columns(n).Name.Replace(BatchTable.BINARYCOLUMN_SUFFIX, "")
            If Table.Columns.ContainsKey(colName) = False Then Continue For
            dgContent.Columns(n).DefaultCellStyle.ForeColor = GetDataTypeColor(Table.Columns(colName).DataType)
        Next
    End Sub

    Public Sub AutoSizeGrid()
        lblStatus.Text = "Resizing..."
        Application.DoEvents()
        dgContent.AutoResizeColumns()
        dgContent.AutoResizeRows()
        lblStatus.Text = ""
    End Sub

    Public Function GetSeletedColumnsFromCells() As List(Of String)
        Dim list As New List(Of String)
        For n As Integer = 0 To dgContent.SelectedCells.Count - 1
            Dim columnName = dgContent.Columns(dgContent.SelectedCells(n).ColumnIndex).Name
            If Not list.Contains(columnName) Then
                list.Add(columnName)
            End If
        Next
        Return list
    End Function
#End Region

#Region "Message Driven and Asynchronous Query"

#End Region

#Region "Table Columns Panel"
    Public Sub OpenColumnPanel()
        If panelColumn.Visible = False Then SwitchColumnPanel()
    End Sub

    Public Sub HideColumnPanel()
        If panelColumn.Visible = True Then SwitchColumnPanel()
    End Sub

    Public Sub SwitchColumnPanel()
        panelColumn.Visible = Not panelColumn.Visible
        btnShowColumnsPanel.Checked = panelColumn.Visible

        If panelColumn.Visible = True Then 'Reposition
            dgContent.Width = dgContent.Width - panelColumn.Width
            dgTableColumn.Focus()
        Else
            dgContent.Width = dgContent.Width + panelColumn.Width
        End If
        txtFastSwitchColumnName.Focus()
    End Sub

    Public Sub CreateColumnPanel()
        Dim n As Integer, gr As DataGridViewRow, dtColumns As DataTable
        Dim iRow As DataRow, vRow As DataRowView

        dgTableColumn.Rows.Clear()
        dtColumns = Table.GetTableSchema()

        'Clear Column Lists in Text
        ColumnsListSorted = ""
        ColumnsListUnsorted = ""

        'Print All Column which is Primary Key
        For n = 0 To dtColumns.Rows.Count - 1
            iRow = dtColumns.Rows(n)
            ColumnsListUnsorted &= iRow("ColumnName").ToString() & Chr(9) & iRow("DataTypePrint").ToString() & vbCrLf
            If Not CType(iRow("IsKey"), Boolean) = True Then Continue For
            ColumnsListSorted &= iRow("ColumnName").ToString() & Chr(9) & iRow("DataTypePrint").ToString() & vbCrLf

            dgTableColumn.Rows.Add()
            gr = dgTableColumn.Rows(dgTableColumn.Rows.Count - 1)
            gr.Cells(0).Value = True 'Unchecked
            gr.Cells(dgcName.Index).Value = iRow("ColumnName").ToString()
            gr.Cells(dgcDataType.Index).Value = iRow("DataTypePrint").ToString()
            gr.Tag = "KEY"
            gr.DefaultCellStyle.BackColor = Color.LightYellow
            gr.DefaultCellStyle.ForeColor = GetDataTypeColor(iRow("DataTypeName").ToString())
        Next


        'Remove All Primary Key in the Data Table
        For n = dtColumns.Rows.Count - 1 To 0 Step -1
            If Not CType(dtColumns.Rows(n)("IsKey"), Boolean) = True Then Continue For
            dtColumns.Rows.RemoveAt(n)
        Next

        'Sort and Print other Columns (Non-Primary Key)
        dtColumns.DefaultView.Sort = "ColumnName asc"
        For n = 0 To dtColumns.DefaultView.Count - 1
            vRow = dtColumns.DefaultView(n)
            ColumnsListSorted &= vRow("ColumnName").ToString() & Chr(9) & vRow("DataTypePrint").ToString() & vbCrLf

            dgTableColumn.Rows.Add() 'Create new entry in datagridview
            gr = dgTableColumn.Rows(dgTableColumn.Rows.Count - 1)
            gr.Cells(dgcName.Index).Value = vRow("ColumnName").ToString()
            gr.Cells(dgcDataType.Index).Value = vRow("DataTypePrint").ToString()
            If Array.IndexOf(DummyColumns, vRow("ColumnName").ToString()) >= 0 Then
                gr.Cells(0).Value = False 'Unchecked
                gr.DefaultCellStyle.BackColor = Color.LightGray
                gr.Tag = "DUMMY"
            Else
                gr.Cells(0).Value = True 'Unchecked
                gr.DefaultCellStyle.BackColor = Color.White
                gr.Tag = "NORMAL"
            End If
            gr.DefaultCellStyle.ForeColor = GetDataTypeColor(vRow("DataTypeName").ToString())
        Next

        BeginApplyColumnFilter()
    End Sub

    ''' <summary>
    ''' An Asychronoous version of applying column filter, will start after 500ms
    ''' </summary>
    Private Sub BeginApplyColumnFilter()
        timerFilter.Enabled = True
    End Sub

    Private Sub ApplyColumnFilter()
        Dim a As DataGridViewRow, n As Integer, msg As String = ""
        Dim columnName As String

        For n = 0 To dgContent.Columns.Count - 1 'show all column first
            dgContent.Columns(n).Visible = True
        Next

        For Each a In dgTableColumn.Rows
            If DirectCast(a.Cells(0).EditedFormattedValue, Boolean) = True Then Continue For 'Column is shown
            columnName = a.Cells(dgcName.Index).Value.ToString()
            For n = 0 To dgContent.Columns.Count - 1 'Column to be shown
                If dgContent.Columns(n).Name = columnName Or dgContent.Columns(n).Name = columnName & BatchTable.BINARYCOLUMN_SUFFIX Then
                    dgContent.Columns(n).Visible = False
                End If
            Next
        Next

        DecorateColumnButtons()
    End Sub

    Private Sub DecorateColumnButtons()
        Dim a As DataGridViewRow
        Dim b As Boolean
        Dim type As String
        Dim showKey As Boolean
        Dim showNormal As Boolean
        Dim showDummy As Boolean

        showKey = True
        showNormal = True
        showDummy = True

        For Each a In dgTableColumn.Rows
            b = DirectCast(a.Cells(0).EditedFormattedValue, Boolean)
            type = a.Tag.ToString()

            If b = False Then
                Select Case type
                    Case "NORMAL"
                        showNormal = False
                    Case "KEY"
                        showKey = False
                    Case "DUMMY"
                        showDummy = False
                End Select
            End If
        Next

        btnShowKey.Checked = showKey
        btnShowOtherColumn.Checked = showNormal
        btnShowDummyColumn.Checked = showDummy
    End Sub

    Public Sub FindAndHighlightColumnInDataGrid(ByVal columnName As String) 'Scroll to the input Column Name
        Dim rowIndex As Integer
        Dim n As Integer

        If dgContent.SelectedCells.Count > 0 Then
            rowIndex = dgContent.SelectedCells(0).RowIndex
        Else 'Focus First Row if not selected
            rowIndex = 0 'Must have at least one row since the last row must be INSERT
        End If

        For n = 0 To dgContent.Columns.Count - 1
            If (dgContent.Columns(n).Name = columnName Or dgContent.Columns(n).Name = columnName & BatchTable.BINARYCOLUMN_SUFFIX) And dgContent.Columns(n).Visible = True Then
                dgContent.CurrentCell = dgContent.Rows(rowIndex).Cells(n)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Based on the cell selected in the DataGrid, highlight the corresponding column in the column panel.
    ''' </summary>
    Public Sub HighlightColumnInColumnPanel(ByVal targetColumnName As String)
        If dgContent.CurrentCell Is Nothing Then Exit Sub
        'Dim currentColumn As String = dgContent.Columns(dgContent.CurrentCell.ColumnIndex).Name

        For n As Integer = 0 To dgTableColumn.Rows.Count - 1
            Dim tmp As String = dgTableColumn.GetCellString(n, dgcName.Index)
            If tmp = targetColumnName Then
                If dgTableColumn.Rows(n).Visible Then
                    dgTableColumn.CurrentCell = dgTableColumn.Rows(n).Cells(dgcName.Index)
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub SelectCommonlyUsedColumnInColumnPanel()
        If dgContent.DataSource Is Nothing And panelColumn.Visible = False Then Exit Sub

        Dim source As DataTable = CType(dgContent.DataSource, DataTable)
        Dim cols As String() = BatchTable.GetUsedColumns(source)

        Dim tmp As String
        For n As Integer = 0 To dgTableColumn.Rows.Count - 1
            tmp = dgTableColumn.Rows(n).Cells(dgcName.Index).Value.ToString()
            If Array.IndexOf(cols, tmp) >= 0 And Array.IndexOf(DummyColumns, tmp) < 0 Then 'Commonly used columns and is not in the exclusion list
                dgTableColumn.Rows(n).Cells(dgcShow.Index).Value = True
            Else
                dgTableColumn.Rows(n).Cells(dgcShow.Index).Value = False
            End If
        Next

        ApplyColumnFilter()
    End Sub
#End Region

#Region "Miscellaneous Functions"
    Public Shared Function GetDataTypeColor(ByVal dataType As String) As System.Drawing.Color
        dataType = StringExtension.LSStr(dataType, "(", True)

        Select Case dataType.ToLower()
            Case "numeric", "decimal"
                Return Color.Blue
            Case "datetime", "date"
                Return Color.Red
            Case "bit", "boolean"
                Return Color.Green
            Case "int", "tinyint", "smallint", "bigint", "float", "double"
                Return Color.DarkBlue
            Case "xml"
                Return Color.Orange
            Case "uniqueidentifier"
                Return Color.Gray
            Case Else 'char, varchar, nchar, nvarchar, text
                Return Color.Black
        End Select
    End Function

    Private Function GetClipboardDataRows() As String()
        Dim tmp As String = Clipboard.GetText(System.Windows.Forms.TextDataFormat.UnicodeText)
        Dim rows As String()
        rows = tmp.Split(New String() {vbCrLf}, StringSplitOptions.None) 'split it into lines
        Return rows
    End Function

    Public Function AreChangesExist() As Boolean
        Dim a As DataTable
        Dim SourceTable As DataTable

        SourceTable = CType(dgContent.DataSource, DataTable)
        If SourceTable Is Nothing Then Return False
        a = SourceTable.GetChanges()
        If a IsNot Nothing AndAlso a.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Layout"
    Public Sub StartSimpleMode()
        If tsBottom.Visible = False Then Exit Sub 'Already in Simple Mode
        panelTop.Visible = False
        tsBottom.Visible = False
        dgContent.Top -= panelTop.Height
        dgContent.Height += panelTop.Height + tsBottom.Height
    End Sub

    Public Sub StartNormalMode()
        If tsBottom.Visible = True Then Exit Sub 'Already in Normal Mode
        tsBottom.Visible = True
        panelTop.Visible = True
        dgContent.Top += panelTop.Height
        dgContent.Height -= panelTop.Height + tsBottom.Height
    End Sub

#End Region

#Region "Interfaces"
    Public Sub RefreshForm() Implements IFormRefresh.RefreshForm
        LoadTable(False)
    End Sub

    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub
#End Region

#Region "Right Hover Color Bar"

    'Private Sub frm_Table_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
    '    Dim loc As Point = Me.Location
    '    If loc.X >= Me.Parent.Width Then
    '        MsgBox("Right")
    '    ElseIf loc.X = 0 Then
    '        MsgBox("Left")
    '    End If
    'End Sub

    Private Sub frm_Table_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'If picHover.Height <= 0 Then Exit Sub

        'Dim brush As New System.Drawing.Drawing2D.LinearGradientBrush(New PointF(5, 0), New PointF(5, picHover.Height), Color.SkyBlue, Color.DarkBlue)
        'Dim g As Graphics = picHover.CreateGraphics()

        'Dim cb As New System.Drawing.Drawing2D.ColorBlend()
        'cb.Colors = New Color() {Color.Transparent, Color.DarkBlue, Color.SkyBlue}
        'cb.Positions = New Single() {0, 0.6, 1}
        'brush.InterpolationColors = cb
        'g.FillRectangle(brush, 0, 0, 10, picHover.Height)

        'brush.Dispose()
    End Sub

    Private Sub picHover_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OpenColumnPanel()
    End Sub

    Private Sub CopyTableNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyTableNameToolStripMenuItem.Click
        Clipboard.Clear()
        Clipboard.SetText(Table.FullName)
    End Sub
#End Region




End Class
