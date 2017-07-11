Imports System.Data.SqlClient

Public Class Form1
    Dim Adapter As SmartDataAdapter
    Dim CurrentDatabase, CurrentTable As String
    Dim TableSwitched As Boolean = False
    Dim CommandMode As enumProgramCommandMode
    Dim TableSearchHistory As String = ""
    Const Version As String = "Table Viewer"
    Const MaximumCommandHistory As Integer = 15
    Const MaximumTableHistory As Integer = 10
    Const DBNullText As String = "NULL"

#Region "Form Events"
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adapter = New SmartDataAdapter("Data Source=CHKMOS\SQLEXPRESS; Initial Catalog=stock;User ID=sa;Password=hashk;")
        RefreshDatabaseDropDownList()
        CommandMode = enumProgramCommandMode.Where
        ProcessEXEArguments()
    End Sub
#End Region

#Region "Button and Other Controls Events"
    Private Sub btnShowFilterColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFilterColumn.Click
        panelColumn.Visible = Not panelColumn.Visible
        If panelColumn.Visible = True Then
            dgContent.Width = dgContent.Width - panelColumn.Width
        Else
            dgContent.Width = dgContent.Width + panelColumn.Width
        End If
    End Sub

    Private Sub btnShowConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowConnection.Click
        groupConnection.Visible = Not groupConnection.Visible
        If groupConnection.Visible = True Then
            dgContent.Left = dgContent.Left + groupConnection.Width
            dgContent.Width = dgContent.Width - groupConnection.Width
        Else
            dgContent.Left = dgContent.Left - groupConnection.Width
            dgContent.Width = dgContent.Width + groupConnection.Width
        End If
    End Sub

    Private Sub btnAutoSize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoSize.CheckedChanged
        If btnAutoSize.Checked = True Then
            lblStatus.Text = "Resizing..."
            Application.DoEvents()
            dgContent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            dgContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Else
            lblStatus.Text = "Restoring..."
            Application.DoEvents()
            dgContent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            dgContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        End If

        lblStatus.Text = ""
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        LoadTable(CurrentTable, False)
    End Sub


    Private Sub btnToggleColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleColumn.Click
        Dim b As Boolean, n As Integer, a As DataGridViewRow

        For Each a In dgTableColumn.Rows
            b = DirectCast(a.Cells(0).FormattedValue, Boolean)
            a.Cells(0).Value = Not b
        Next

        ApplyColumnFilter()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim SourceTable As DataTable, ChangesTable As DataTable
        barProgress.Maximum = 1
        barProgress.Value = 0
        Application.DoEvents()

        SourceTable = dgContent.DataSource
        ChangesTable = SourceTable.GetChanges()

        If ChangesTable Is Nothing OrElse ChangesTable.Rows.Count = 0 Then
            'Do Nothing
        Else
            Try
                Adapter.Update(ChangesTable, PrepareParameterMode.BuildSQL)
                SourceTable.AcceptChanges()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        barProgress.Value = 1
        lblStatus.Text = "Saved on " & DateTime.Now.ToLongTimeString()
    End Sub

    Private Sub timerFilter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerFilter.Tick
        ApplyColumnFilter()
        timerFilter.Enabled = False
    End Sub

    Private Sub btnCopyColumnName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyColumnName.Click
        Dim TableAlias As String, Seperator As String
        Dim Final As String = "", n As Integer, IsFirst As Boolean = True
        TableAlias = InputBox("Please input the Table Alias", "", "t")
        Seperator = InputBox("Please input the Seperator between the column names", "", ", ")

        If Seperator = "\r\n" Or Seperator = "\n" Or Seperator = "\n\r" Then Seperator = vbCrLf
        If Not TableAlias = "" Then TableAlias = TableAlias & "."

        For n = 0 To dgTableColumn.Rows.Count - 1
            If IsFirst = True Then
                Final = TableAlias & dgTableColumn.Rows(n).Cells(1).Value
                IsFirst = False
            Else
                Final = Final & Seperator & TableAlias & dgTableColumn.Rows(n).Cells(1).Value
            End If
        Next

        'MessageBox.Show(Final)
        Clipboard.Clear()
        Clipboard.SetText(Final)
    End Sub

    Private Sub btnCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommand.Click
        If CommandMode = enumProgramCommandMode.Where Then
            CommandMode = enumProgramCommandMode.SQL
            btnCommand.Text = "SQL"
            ddCommand.Text = GetSelectSQL(CurrentTable, ddCommand.Text)
        ElseIf CommandMode = enumProgramCommandMode.SQL Then
            CommandMode = enumProgramCommandMode.Where
            btnCommand.Text = "Where"
            ddCommand.Text = ""
        End If
    End Sub
#End Region

#Region "Combo Box and List Events"
    Private Sub ddCommand_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ddCommand.KeyUp
        If e.KeyCode = Keys.Enter Then
            AutoCompleteWhereClause()
            LoadTable(CurrentTable, False)
            AddCommandHistory(ddCommand.Text)
            ddCommand.SelectAll()
        End If
    End Sub

    Private Sub ddDatabase_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ddDatabase.MouseUp

    End Sub

    Private Sub ddDatabase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddDatabase.SelectedIndexChanged
        ChangeDatabase(ddDatabase.SelectedItem.ToString())
    End Sub

    Private Sub ddTable_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddTable.DoubleClick
        CurrentTable = ddTable.SelectedItem.ToString()
        TableSwitched = True
        LoadTable(CurrentTable, True)
        btnShowConnection_Click(Nothing, Nothing)
    End Sub

    Private Sub ddTable_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ddTable.KeyUp
        If e.KeyCode = Keys.Enter Then
            CurrentTable = ddTable.Text
            TableSwitched = True
            LoadTable(CurrentTable, True)
            btnShowConnection_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ddTable_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ddTable.MouseUp, btnShowConnection.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim tmp As String, iItem As ListItem, n As Integer, m As Integer, SearchText As String(), IsMatched As Boolean = False
            'Dim MatchedListIndex As New List(Of Integer)

            tmp = InputBox("Please input the keyword of the table name" & vbCrLf & "Use Space to seperate each AND keyword", "Table Name", TableSearchHistory)
            If tmp = "" Then Exit Sub
            TableSearchHistory = tmp

            SearchText = tmp.Split(" ")

            For n = 0 To ddTable.Items.Count - 1
                iItem = ddTable.Items(n)
                IsMatched = True

                For m = 0 To SearchText.Length - 1 'Investigate each SearchText
                    If iItem.Value.Contains(SearchText(m)) = False Then IsMatched = False
                Next

                If IsMatched = True Then 'Success, matched all search text
                    ddTable.SelectedIndex = n
                    ddTable_DoubleClick(Nothing, Nothing)
                    Exit For
                End If
            Next
        End If

        If e.Button = Windows.Forms.MouseButtons.Middle Then
            Dim arg As String = " " & CurrentDatabase & " " & ddTable.SelectedItem.ToString()
            'Shell(Application.ExecutablePath & arg, AppWinStyle.MinimizedFocus)
            Shell(Application.ExecutablePath & arg, AppWinStyle.NormalFocus)
        End If
    End Sub

#End Region

#Region "Data Grid View Events"
    Private Sub dgTableColumn_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTableColumn.CellClick
        Select Case e.ColumnIndex
            Case 0 'Check Box
            Case 1 'Column Name, do navigation
                FindAndHighlightColumn(dgTableColumn.CurrentRow.Cells(1).Value)
                btnShowFilterColumn_Click(Nothing, Nothing)
            Case 2 'DataType
                Clipboard.Clear()
                Clipboard.SetText(dgTableColumn.CurrentRow.Cells(1).Value)
        End Select
    End Sub

    Private Sub dgTableColumn_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTableColumn.CellContentClick
        Select Case e.ColumnIndex
            Case 0 'Check Box
                ApplyColumnFilter() 'Immediate Version
            Case 1 'Column Name, do navigation
            Case 2 'DataType
        End Select
    End Sub

    Private Sub dgContent_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgContent.KeyUp
        Dim StartRowIndex As Integer = dgContent.SelectedCells(0).RowIndex 'get the row and column of selected cell in grid
        Dim StartColumnIndex As Integer = dgContent.SelectedCells(0).ColumnIndex

        If e.Control And e.KeyCode = Keys.V Then 'Ctrl+V (paste from clipboard)
            Dim ClipboardData As IDataObject = Clipboard.GetDataObject() 'get text from clipboard
            Dim tmp As String = DirectCast(ClipboardData.GetData(DataFormats.Text), String)
            Dim n As Integer = 0, m As Integer, PasteStartIndex As Integer
            Dim ResultR As String(), ResultC As String()

            ResultR = tmp.Split(New Char() {Chr(13), Chr(10)}, StringSplitOptions.RemoveEmptyEntries) 'split it into lines
            If ResultR Is Nothing Then Exit Sub

            'Process for the First Row Only
            For n = 0 To ResultR.Length - 1 'Insert for every Row
                ResultC = ResultR(n).Split(New Char() {Chr(9)}) ' loop through the lines, split them into cells and place the values in the corresponding cell, split row into cell values
                If ResultC Is Nothing Then Continue For

                If ResultC(0) = String.Empty Then PasteStartIndex = 1 Else PasteStartIndex = 0

                For m = PasteStartIndex To ResultC.Length - 1 'every element in the row
                    If StartColumnIndex + m - PasteStartIndex >= dgContent.ColumnCount Then Exit For 'Input exceeds the number of columns in current table
                    If ResultC(m) = DBNullText Then
                        dgContent.Rows(StartRowIndex + n).Cells(StartColumnIndex + m - PasteStartIndex).Value = DBNull.Value
                    Else
                        dgContent.Rows(StartRowIndex + n).Cells(StartColumnIndex + m - PasteStartIndex).Value = ResultC(m)
                    End If
                Next
            Next
        End If

        If e.KeyCode = Keys.Back Then 'BackSpace
            dgContent.Rows(StartRowIndex).Cells(StartColumnIndex).Value = DBNull.Value
        End If
    End Sub

#End Region

#Region "Program Core Functions"
    Public Sub ChangeServer(ByVal IP As String, ByVal Username As String, ByVal Password As String)

    End Sub

    Public Sub ChangeDatabase(ByVal Databasename As String)
        CurrentDatabase = Databasename
        RefreshTableDropDownList()
    End Sub

    Public Sub LoadTable(ByVal Tablename As String, ByVal RefreshFilterColumnList As Boolean)
        Dim dtTable As DataTable
        Dim sql As String
        Dim PrimaryKey() As String
        Dim n As Integer
        Dim IsCorrect As Boolean

        lblStatus.Text = "Loading Table Data..."
        Application.DoEvents()

        sql = GetSQL(Tablename, ddCommand.Text)

        If TableSwitched = True Then 'Another Table is chosen, check if the WHERE clause is valid for this table
            IsCorrect = Adapter.VertifySQLSyntax(sql)
            If IsCorrect = False Then 'The SQL is not correct, restart by removing the WHERE clause
                sql = GetSQL(Tablename, "")
                ddCommand.Text = ""
            End If
        End If

        Try
            Adapter.SetSelectCommand(sql, CommandType.Text)
            dtTable = Adapter.GetDataTable(0, False) 'SQL Exception may be produced here
            PrimaryKey = Adapter.GetTablePrimaryKeyFromSelectCommand()
            dgContent.DataSource = Nothing
            dgContent.DataSource = dtTable
            dgContent.Refresh()
        Catch ex As Exception 'SQL exception
            MessageBox.Show(ex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        'Generate and Apply Column Filter
        If RefreshFilterColumnList = True Then CreateFilterColumnList()
        BeginApplyColumnFilter()

        'Highlight Key Column in DataGridVeiw
        For n = 0 To dgContent.ColumnCount - 1
            If Array.IndexOf(PrimaryKey, dgContent.Columns(n).HeaderText) >= 0 Then
                dgContent.Columns(n).DefaultCellStyle.BackColor = Color.LightYellow
            Else
                dgContent.Columns(n).DefaultCellStyle.BackColor = Color.White
            End If
        Next

        'DataGridView Column Style
        Dim CellStyle As New DataGridViewCellStyle
        CellStyle.WrapMode = DataGridViewTriState.True
        dgContent.DefaultCellStyle = CellStyle
        ddCommand.Focus()

        'Program Caption and Status Display
        Me.Text = Tablename & " - [" & CurrentDatabase & "] - " & Version
        lblStatus2.Text = "No. of record: " & dgContent.Rows.Count - 1 & "  No. of column: " & dgContent.Columns.Count
        TableSwitched = False
        lblStatus.Text = ""
    End Sub

#End Region

#Region "SQL Generation"
    Public Function GetSQL(ByVal Tablename As String, ByVal WhereClause As String) As String
        Dim sql As String = ""

        If CommandMode = enumProgramCommandMode.Where Then
            sql = GetSelectSQL(Tablename, WhereClause)
        ElseIf CommandMode = enumProgramCommandMode.SQL Then
            sql = ddCommand.Text
        End If

        Return sql
    End Function

    Private Function GetSelectSQL(ByVal Tablename As String, ByVal WhereClause As String) As String
        Dim sql As String = ""
        If WhereClause = "" Then
            sql = "select * from " & Tablename
        Else
            sql = "select * from " & Tablename & " where " & WhereClause
        End If
        Return sql
    End Function

    Public Sub AutoCompleteWhereClause()
        Dim sql1 As String
        Dim sql2 As String
        Dim count As Integer = 0

        sql1 = ddCommand.Text
        sql2 = ddCommand.Text
        count = CountStr(sql1, "'")

        If count Mod 2 = 1 Then 'Is Odd
            sql2 = sql1 & "'"
        End If

        ddCommand.Text = sql2
    End Sub
#End Region

#Region "Panel: Tables"
    Public Function SearchTableList(ByVal PartialTableName As String) As Integer
        Dim SearchText As String()
        Dim n As Integer, m As Integer
        Dim iItem As ListItem
        Dim IsMatched As Boolean
        Dim PotentialIndex As Integer = -1
        SearchText = PartialTableName.Split(" ")

        For n = 0 To ddTable.Items.Count - 1
            iItem = ddTable.Items(n)
            IsMatched = True

            For m = 0 To SearchText.Length - 1 'Investigate each SearchText
                If iItem.Value.Contains(SearchText(m)) = False Then IsMatched = False
            Next

            If IsMatched = True Then 'Success, matched all search text
                PotentialIndex = n
                Exit For
            End If
        Next

        Return PotentialIndex
    End Function
#End Region

#Region "Panel: Columns"
    ''' <summary>
    ''' An Asychronoous version of applying column filter, will start after 500ms
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BeginApplyColumnFilter()
        timerFilter.Enabled = True
    End Sub

    Public Sub CreateFilterColumnList()
        Dim n As Integer, GridViewRow As DataGridViewRow, InputTable As DataTable
        Dim iRow As DataRow, vRow As DataRowView
        Dim UncheckColumnList As String() = {"crea_uid", "crea_date", "last_updt_uid", "last_updt_date", "updt_uid", "updt_date"}

        dgTableColumn.Rows.Clear()
        InputTable = Adapter.GetTableSchemaFromSelectCommand()

        'Print All Column which is Primary Key
        For n = 0 To InputTable.Rows.Count - 1
            iRow = InputTable.Rows(n)
            If Not iRow("IsKey") = "true" Then Continue For

            dgTableColumn.Rows.Add()
            GridViewRow = dgTableColumn.Rows(dgTableColumn.Rows.Count - 1)
            If Array.IndexOf(UncheckColumnList, iRow("ColumnName").ToString()) >= 0 Then
                GridViewRow.Cells(0).Value = False
            Else
                GridViewRow.Cells(0).Value = True
            End If
            GridViewRow.Cells("dcName").Value = iRow("ColumnName").ToString()
            GridViewRow.Cells("dcDataType").Value = iRow("DataTypePrint").ToString()
            GridViewRow.DefaultCellStyle.BackColor = Color.LightYellow
            GridViewRow.DefaultCellStyle.ForeColor = GetDataTypeColor(iRow("DataTypeName").ToString())
        Next

        'Remove All Primary Key
        For n = InputTable.Rows.Count - 1 To 0 Step -1
            If Not InputTable.Rows(n)("IsKey") = "true" Then Continue For
            InputTable.Rows.RemoveAt(n)
        Next

        'Sort and Print other Columns (Non-Primary Key)
        InputTable.DefaultView.Sort = "ColumnName asc"
        For n = 0 To InputTable.DefaultView.Count - 1
            vRow = InputTable.DefaultView(n)
            dgTableColumn.Rows.Add()
            GridViewRow = dgTableColumn.Rows(dgTableColumn.Rows.Count - 1)
            If Array.IndexOf(UncheckColumnList, vRow("ColumnName").ToString()) >= 0 Then
                GridViewRow.Cells(0).Value = False
            Else
                GridViewRow.Cells(0).Value = True
            End If
            GridViewRow.Cells("dcName").Value = vRow("ColumnName").ToString()
            GridViewRow.Cells("dcDataType").Value = vRow("DataTypePrint").ToString()
            GridViewRow.DefaultCellStyle.BackColor = Color.White
            GridViewRow.DefaultCellStyle.ForeColor = GetDataTypeColor(vRow("DataTypeName").ToString())
        Next
    End Sub


    Public Sub ApplyColumnFilter()
        Dim a As DataGridViewRow, n As Integer, msg As String = ""

        For n = 0 To dgContent.Columns.Count - 1 'show all column first
            dgContent.Columns(n).Visible = True
        Next

        For Each a In dgTableColumn.Rows
            If DirectCast(a.Cells(0).EditedFormattedValue, Boolean) = False Then 'Column to be HIDDEN
                For n = 0 To dgContent.Columns.Count - 1 'Column to be shown
                    If dgContent.Columns(n).Name = a.Cells("dcName").Value.ToString() Then
                        dgContent.Columns(n).Visible = False
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub FindAndHighlightColumn(ByVal ColumnName As String) 'Scroll to the input Column Name
        Dim RowIndex As Integer
        Dim n As Integer

        If dgContent.SelectedCells.Count > 0 Then
            RowIndex = dgContent.SelectedCells(0).RowIndex
        Else 'Focus First Row if not selected
            RowIndex = 0 'Must have at least one row since the last row must be INSERT
        End If

        For n = 0 To dgContent.Columns.Count - 1
            If dgContent.Columns(n).Name = ColumnName And dgContent.Columns(n).Visible = True Then
                dgContent.CurrentCell = dgContent.Rows(RowIndex).Cells(n)
            End If
        Next
    End Sub

#End Region

#Region "Tab Management"
    Private Sub ProcessEXEArguments()
        With My.Application.CommandLineArgs
            Select Case .Count
                Case 0
                    Me.WindowState = FormWindowState.Maximized
                    ddDatabase.SelectedIndex = ddDatabase.FindString("BSTESTDB")
                Case 1
                    ddDatabase.SelectedIndex = ddDatabase.FindString(.Item(0)) 'DataBase
                Case 2
                    ddDatabase.SelectedIndex = ddDatabase.FindString(.Item(0)) 'DataBase
                    ddDatabase_SelectedIndexChanged(Nothing, Nothing)
                    ddTable.SelectedIndex = ddTable.FindString(.Item(1)) 'Table
                    ddTable_DoubleClick(Nothing, Nothing)
            End Select
        End With
    End Sub

#End Region

#Region "Cascade DropDownList and Events"
    Private Sub RefreshDatabaseDropDownList()
        Dim dtTable As DataTable
        Adapter.ChangeDatabase("master")
        Adapter.SetSelectCommand("select name from sysdatabases order by name", CommandType.Text)
        dtTable = Adapter.GetDataTable()
        BindTableToComboBox(ddDatabase, dtTable, 0, 0)
    End Sub

    Private Sub RefreshTableDropDownList()
        Dim dtTable As DataTable
        Adapter.ChangeDatabase(CurrentDatabase)
        Adapter.SetSelectCommand("Select DISTINCT TABLE_NAME from INFORMATION_SCHEMA.COLUMNS order by TABLE_NAME", CommandType.Text)
        dtTable = Adapter.GetDataTable()
        BindTableToListBox(ddTable, dtTable, 0, 0)
    End Sub

    Private Sub BindTableToListBox(ByVal Control As System.Windows.Forms.ListBox, ByVal InputTable As DataTable, ByVal KeyColumn As String, ByVal ValueColumn As String)
        BindTableToListBox(Control, InputTable, InputTable.Columns.IndexOf(KeyColumn), InputTable.Columns.IndexOf(ValueColumn))
    End Sub

    Private Sub BindTableToComboBox(ByVal Control As System.Windows.Forms.ComboBox, ByVal InputTable As DataTable, ByVal KeyColumn As String, ByVal ValueColumn As String)
        BindTableToComboBox(Control, InputTable, InputTable.Columns.IndexOf(KeyColumn), InputTable.Columns.IndexOf(ValueColumn))
    End Sub

    Private Sub BindTableToListBox(ByVal Control As System.Windows.Forms.ListBox, ByVal InputTable As DataTable, ByVal KeyColumnIndex As Integer, ByVal ValueColumnIndex As Integer)
        Control.Items.Clear()
        Dim n As Integer

        For n = 0 To InputTable.Rows.Count - 1
            Control.Items.Add(New ListItem(InputTable.Rows(n)(KeyColumnIndex).ToString(), InputTable.Rows(n)(ValueColumnIndex).ToString()))
        Next
    End Sub

    Private Sub BindTableToComboBox(ByVal Control As System.Windows.Forms.ComboBox, ByVal InputTable As DataTable, ByVal KeyColumnIndex As Integer, ByVal ValueColumnIndex As Integer)
        Control.Items.Clear()
        Dim n As Integer

        For n = 0 To InputTable.Rows.Count - 1
            Control.Items.Add(New ListItem(InputTable.Rows(n)(KeyColumnIndex).ToString(), InputTable.Rows(n)(ValueColumnIndex).ToString()))
        Next
    End Sub

    Private Sub btnNewTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewTab.Click
        Shell(Application.ExecutablePath, AppWinStyle.NormalFocus)
    End Sub
#End Region

#Region "Command History"
    Private Sub AddCommandHistory(ByVal Command As String)
        Dim n As Integer
        If ddCommand.FindStringExact(Command) >= 0 Then

        Else
            For n = ddCommand.Items.Count - 1 To MaximumCommandHistory - 1 Step -1 'Remove History
                ddCommand.Items.RemoveAt(n)
            Next
            ddCommand.Items.Insert(0, New ListItem(Command, Command))
        End If
    End Sub

#End Region

#Region "Miscellaneous Functions"
    Private Function GetDataTypeColor(ByVal DataType As String) As System.Drawing.Color
        Select Case DataType
            Case "decimal"
                Return Color.Blue
            Case "datetime"
                Return Color.Red
            Case Else
                Return Color.Black
        End Select
    End Function
#End Region
End Class

Public Enum enumProgramCommandMode
    [Where]
    SQL
End Enum

Public Class ListItem
    Public Text As String
    Public Value As String

    Public Sub New(ByVal InputText As String, ByVal InputValue As String)
        Text = InputText
        Value = InputValue
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class