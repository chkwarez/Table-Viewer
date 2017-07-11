Public Class frm_Database : Implements IFormClose, IFormRefresh
    Public SelectedDatabase As String
    Public SelectedConnectionString As String
    Dim SearchText As String = ""
    Dim DefaultDatabase As String = ConfigurationSettings.DefaultDatabase
    Public Server As Smart.SqlServer
    Dim _ConnectionStatus As ConnectionStatusCode = ConnectionStatusCode.NotConnected
    Public ReadOnly Property ConnectionStatus As ConnectionStatusCode
        Get
            Return _ConnectionStatus
        End Get
    End Property

    Public ReadOnly Property SelectedObjectID() As Integer
        Get
            If lvwTable.SelectedIndices.Count = 0 Then
                Return 0
            Else
                Return CType(lvwTable.Items(lvwTable.SelectedIndices(0)).Tag, Integer)
            End If
        End Get
    End Property

    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

#Region "Form Event"
    Private Sub frm_Database_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
        SearchText = ""
    End Sub

    Private Sub frm_Database_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RefreshLayout()
        RefreshConnectionStringHistory()
    End Sub

    Private Sub frm_Database_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        ParentMainForm.SwitchDatabaseWindow(False)
    End Sub

    Private Sub frm_Database_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        Me.Size = New Size(800, 440)
        Me.WindowState = FormWindowState.Normal
    End Sub
#End Region

#Region "Button Event"
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Connect()
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        Disconnect()
    End Sub

    Private Sub btnResetDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetDatabase.Click
        ddDatabase.SelectedValue = ConfigurationSettings.DefaultDatabase
    End Sub

    Private Sub chkSystemDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSystemDatabase.Click
        btnRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub btnNewConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewConnection.Click
        ShowConnectionWizard()
    End Sub
#End Region

#Region "ToolStrip Event"
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        If ddDatabase.SelectedValue Is Nothing Then Exit Sub
        ListDatabases(ddDatabase.SelectedValue.ToString())
    End Sub

    Private Sub btnBackupDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackupDatabase.Click
        Dim filePath As String
        Dim suggestedFileName As String = SelectedDatabase & "_" & DateTime.Now.ToString("yyyyMMdd")
        cmdgSave.Filter = "Database Backup File (*.bak)|*.bak"
        cmdgSave.FileName = suggestedFileName
        Dim rtvl As DialogResult = cmdgSave.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub
        filePath = cmdgSave.FileName

        Dim orgStatus As String
        orgStatus = lblStatistics.Text
        lblStatistics.Text = "Backuping Database " & SelectedDatabase & "..."
        Application.DoEvents()

        Try
            Server.ChangeDatabase(SelectedDatabase)
            Server.Database.Backup(filePath)
            MessageBox.Show("Backup Complete!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            RaiseErrorMessage(ex.Message)
        End Try

        lblStatistics.Text = orgStatus
    End Sub

    Private Sub btnRestoreDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestoreDatabase.Click
        Dim filePath As String
        cmdgOpen.Filter = "Database Backup File (*.bak)|*.bak|All Files|*.*"
        Dim rtvl As DialogResult = cmdgOpen.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub
        filePath = cmdgOpen.FileName

        Dim newDatabaseName As String
        newDatabaseName = InputBox("Please input the Database Name for restoration", "Restore", SelectedDatabase)
        If newDatabaseName = "" Then Exit Sub 'Cancel

        Dim orgStatus As String
        orgStatus = lblStatistics.Text
        lblStatistics.Text = "Restoring Database " & newDatabaseName & "..."
        Application.DoEvents()

        Try
            Server.ChangeDatabase(SelectedDatabase)
            Server.Database.Restore(filePath, newDatabaseName)
            MessageBox.Show("Restore Complete!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            RaiseErrorMessage(ex.Message)
        End Try

        lblStatistics.Text = orgStatus
    End Sub

    Private Sub btnCreateDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDatabase.Click
        Dim newDatabaseName As String
        newDatabaseName = InputBox("Please input the Database Name", "Create")
        If newDatabaseName = "" Then Exit Sub 'Cancel

        Try
            Server.Database.Create(newDatabaseName)
            ListDatabases(newDatabaseName)
        Catch ex As Exception
            RaiseErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnRenameDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenameDatabase.Click
        Dim newName As String
        newName = InputBox("Please input the new Database Name", "Rename", SelectedDatabase)
        If newName = "" Then Exit Sub 'Cancel

        Try
            Server.ChangeDatabase(SelectedDatabase)
            Server.Database.Rename(newName)
            ListDatabases(newName)
        Catch ex As Exception
            RaiseErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnDeleteDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDatabase.Click
        Dim rtvl As DialogResult
        rtvl = MessageBox.Show("Are you sure to drop the database " & SelectedDatabase & "?", "Drop", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        If rtvl = Windows.Forms.DialogResult.No Then Exit Sub

        Try
            Server.ChangeDatabase(SelectedDatabase)
            Server.Database.Drop("")
            ListDatabases(Nothing)
        Catch ex As Exception
            RaiseErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnRenameTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenameTable.Click
        If SelectedObjectID < 0 Then
            MessageBox.Show("This is a system object, operation is not allowed")
            Exit Sub
        ElseIf SelectedObjectID = 0 Then
            Exit Sub
        End If

        Dim dbObject As Smart.SqlDatabaseObject
        Server.ChangeDatabase(SelectedDatabase)
        dbObject = Server.Database.GetDatbaseObjectById(SelectedObjectID)

        Dim newName As String
        newName = InputBox("Please input the new Table/View Name", "Rename", dbObject.Name)
        If newName = "" Then Exit Sub 'Cancel

        dbObject.Rename(newName)
        ListDatabaseObjects()
    End Sub

    Private Sub btnDeleteTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTable.Click
        If SelectedObjectID < 0 Then
            MessageBox.Show("This is a system object, operation is not allowed")
            Exit Sub
        ElseIf SelectedObjectID = 0 Then
            Exit Sub
        End If

        Dim dbObject As Smart.SqlDatabaseObject
        Server.ChangeDatabase(SelectedDatabase)
        dbObject = Server.Database.GetDatbaseObjectById(SelectedObjectID)

        Dim rtvl As DialogResult
        rtvl = MessageBox.Show("Are you sure to drop the object " & dbObject.Name & "?", "Drop", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        If rtvl = Windows.Forms.DialogResult.No Then Exit Sub

        dbObject.Delete()
        ListDatabaseObjects()
    End Sub

    Private Sub btnEditTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTable.Click
        Server.ChangeDatabase(SelectedDatabase)

        For n As Integer = 0 To lvwTable.SelectedItems.Count - 1
            Dim objectID As Integer = CInt(lvwTable.SelectedItems(n).Tag)
            If objectID < 0 Then Continue For

            Dim dbObject As Smart.SqlDatabaseObject = Server.Database.GetDatbaseObjectById(objectID)
            If dbObject.ObjectType = Smart.CommonProperty.GetObjectTypeCode(Smart.CommonProperty.DatabaseObject.Table) Then 'Table
                Dim a As frm_TableStructure = ParentMainForm.CreateTableStructureWindow(CType(dbObject, Smart.SqlTable))
            Else
                Dim a As frm_SQL = ParentMainForm.CreateQueryWindow(dbObject.Name)
                a.SetQuery(dbObject.Database, dbObject.GetDefinition(False))
            End If
        Next
    End Sub

    Private Sub btnShowDatabaseDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowDatabaseDetails.Click
        Dim f = ParentMainForm.CreateDatabaseDetailsWindow()
        f.Database = Server.GetDatabase(SelectedDatabase)
        f.RefreshForm()
    End Sub
#End Region

#Region "Backgroundworker Events"
    Private Sub bgConnect_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgConnect.DoWork
        _ConnectionStatus = ConnectionStatusCode.Connecting
        Me.Invoke(New ShowStatusDelegate(AddressOf RefreshLayout))

        SelectedConnectionString = CStr(e.Argument)
        Try
            Server = New Smart.SqlServer(SelectedConnectionString)
            _ConnectionStatus = ConnectionStatusCode.Connected
            Me.Invoke(New ShowStatusDelegate(AddressOf RefreshLayout))
            'TODO: ConfigurationSettings.AddConnectionStringHistory(SelectedConnectionString) 
            Me.Invoke(New ListDatabasesDelegate(AddressOf ListDatabases), DefaultDatabase)
        Catch ex2 As System.Threading.ThreadAbortException
            'Do Nothing
        Catch ex As Exception 'Connection Fail
            _ConnectionStatus = ConnectionStatusCode.NotConnected
            Me.Invoke(New ShowStatusDelegate(AddressOf RefreshLayout))
            RaiseErrorMessage(ex.Message)
        End Try
    End Sub
#End Region

#Region "List View Event"
    Private Sub lvwTable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwTable.KeyDown
        If e.Control = True And e.KeyCode = Keys.C Then 'Copy Table/View Name
            Dim sb As New System.Text.StringBuilder()
            For n As Integer = 0 To lvwTable.SelectedItems.Count - 1
                sb.AppendLine(lvwTable.SelectedItems(n).Text)
            Next
            If sb.Length > 0 Then
                Try
                    Clipboard.Clear()
                    Clipboard.SetDataObject(sb.ToString().Trim(), True, 5, 200)
                Catch ex As Exception

                End Try
                e.Handled = True
            End If
        End If

        Select Case e.KeyCode
            Case Keys.Enter
                OpenAllSelectedObjects()
        End Select
    End Sub

    Private Sub lvwTable_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwTable.DoubleClick
        OpenAllSelectedObjects()
    End Sub

    Private Sub lvwTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwTable.Click
        'If lvwTable.SelectedItems.Count = 0 Then Exit Sub

        'Server.ChangeDatabase(SelectedDatabase)
        'Dim objectID As Integer = CInt(lvwTable.SelectedItems(0).Tag)
        'Dim dbObject As Smart.SqlDatabaseObject = Server.Database.GetDatbaseObjectById(objectID)
        'ToolStripLabel2.Text = Smart.CommonProperty.GetObjectName(Smart.CommonProperty.GetObjectTypeByCode(dbObject.ObjectType))
    End Sub

    Private Sub lvwTable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvwTable.KeyPress
        If Char.IsLetter(e.KeyChar) Or e.KeyChar = "_"c Or e.KeyChar = "."c Or Char.IsDigit(e.KeyChar) Then 'Capture all Printable Keys
            SearchText &= e.KeyChar.ToString().ToLower()
            HighlightDatabaseObjectList()
            e.Handled = True
        End If
    End Sub

    Private Sub lvwTable_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwTable.KeyUp
        Select Case e.KeyCode
            Case Keys.Delete
                SearchText = ""
                lblTableMatch.Text = SearchText
            Case Keys.Back
                SearchText = StringExtension.SubStr(SearchText, 0, -1) 'Remove last charater
                HighlightDatabaseObjectList()
            Case Else
        End Select
    End Sub
#End Region

#Region "Drop Down List Event"
    Private Sub ddConnectionString_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ddConnectionString.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnConnect_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ddDatabase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddDatabase.SelectedIndexChanged
        If ddDatabase.SelectedValue Is Nothing Then Exit Sub
        SelectedDatabase = ddDatabase.SelectedValue.ToString()
        Server.ChangeDatabase(SelectedDatabase)
        ListDatabaseObjects()
    End Sub
#End Region

#Region "Other Controls Event"
    Private Sub chkInformationSchema_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUserTable.CheckedChanged, chkInformationSchema.CheckedChanged, chkUserView.CheckedChanged, chkUserTableAndView.CheckedChanged, chkSystemView.CheckedChanged
        Dim chk = CType(sender, RadioButton)
        If chk.Checked = False Then Exit Sub 'The Checked radio button will fire again
        If SelectedConnectionString = "" Or SelectedDatabase = "" Then Exit Sub
        ListDatabaseObjects()
    End Sub

    Private Sub txtSearchObject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchObject.TextChanged
        If txtSearchObject.Text = "" Then
            txtSearchResult.Text = ""
            Exit Sub
        ElseIf txtSearchObject.Text = "\" Then
            btnResetDatabase_Click(btnResetDatabase, Nothing)
            txtSearchObject.Text = "" 'Clear Original Entry (Call Search Object again)
        End If

        Dim index As Integer, matchPercent As Double
        If txtSearchObject.Text.Contains("\") Then 'Contains Database Name
            FindClosestDatabase(StringExtension.LSStr(txtSearchObject.Text, "\"), index, matchPercent)
            If index = -1 Then Exit Sub
            ddDatabase.SelectedIndex = index
            txtSearchObject.Text = "" 'Clear Original Entry (Call Search Object again)
        Else 'Contains only Table Name
            FindClosestDatabaseObject(txtSearchObject.Text, index, matchPercent)
            If index = -1 Then Exit Sub
            txtSearchResult.Text = matchPercent.ToString("p") & " " & lvwTable.Items(index).Text
        End If
    End Sub

    Private Sub txtSearchObject_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchObject.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim index As Integer, matchPercent As Double
            FindClosestDatabaseObject(txtSearchObject.Text, index, matchPercent)
            If index = -1 Then Exit Sub
            OpenItem(index)
            txtSearchObject.SelectAll()
        End If
    End Sub

    Private Sub lblTableMatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTableMatch.Click
        lvwTable.Focus()
        HighlightDatabaseObjectList()
    End Sub
#End Region

#Region "Connection Functions"
    Public Sub Connect()
        bgConnect.RunWorkerAsync(ddConnectionString.Text)
    End Sub

    Public Sub Connect(defaultDB As String)
        DefaultDatabase = defaultDB
        bgConnect.RunWorkerAsync(ddConnectionString.Text)
    End Sub

    Public Sub Disconnect()
        If bgConnect.IsBusy Then
            _ConnectionStatus = ConnectionStatusCode.Disabled
            RefreshLayout()
            bgConnect.Abort()
        End If

        If Server IsNot Nothing Then Server.Disconnect()
        _ConnectionStatus = ConnectionStatusCode.NotConnected
        RefreshLayout()
    End Sub
#End Region

#Region "Database Functions"
    Private Sub ListDatabases(ByVal defaultDatabase As String)
        'Show Dynamic Progress
        ddDatabase.Text = "Listing..."
        Application.DoEvents()

        'Get Data Source
        Dim dtTable As DataTable
        dtTable = Server.GetDatabases(True) 'Only Online Non-System Database
        If chkSystemDatabase.Checked Then 'Include System Databasese
            BatchTable.Copy(Server.GetSystemDatabases(), dtTable, New String() {}) 'Insert All
        End If

        'Present Data
        BatchTable.CreateColumnFromColumns(dtTable, "DisplayText", New String() {"name", "database_id"}, "{0} ({1})")

        'List Data in the Control
        ddDatabase.DisplayMember = "DisplayText"
        ddDatabase.ValueMember = "name"
        ddDatabase.DataSource = dtTable

        'Try to select the Default Database, if not exist, find closest
        If Not defaultDatabase = "" Then
            Dim tmpInd As Integer = ddDatabase.SelectedIndex
            ddDatabase.SelectedValue = defaultDatabase 'If such item is not found, the SelectedValue becomes NULL
            If ddDatabase.SelectedValue Is Nothing Then 'The default database is not found
                ddDatabase.SelectedIndex = tmpInd 'Resume original selection
                txtSearchObject.Text = defaultDatabase & "\" 'Auto Find the closest database
            Else
                lvwTable.Focus()
            End If
        End If
    End Sub

    Public Sub QuickConnect()
    End Sub

    Public Sub FindClosestDatabase(ByVal name As String, ByRef outItemIndex As Integer, ByRef outPercentMatch As Double)
        Dim searchText As String()
        Dim n As Integer
        Dim dbName As String, foundIndex As Integer = -1, foundPercent As Double = 0, matchPercent As Double
        searchText = name.Split(" ".ToCharArray())

        For n = 0 To ddDatabase.Items.Count - 1
            dbName = CType(ddDatabase.Items(n), DataRowView).Item("name").ToString()
            matchPercent = StringExtension.GetSimilarityPercent(dbName, name, True) 'The match percentage between the search and the actual table name

            If matchPercent > foundPercent And matchPercent > 0 Then
                foundIndex = n
                foundPercent = matchPercent
            End If
        Next

        outItemIndex = foundIndex
        outPercentMatch = foundPercent
    End Sub
#End Region

#Region "Database Object Functions"
    Private Sub OpenAllSelectedObjects()
        Dim n As Integer
        Dim count As Integer = lvwTable.SelectedIndices.Count
        If count = 0 Then Exit Sub

        If count > 10 Then
            Dim rtvl As DialogResult
            rtvl = MessageBox.Show("The process will open " + count.ToString() + " tables, are you sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If

        For n = 0 To count - 1
            OpenItem(lvwTable.SelectedIndices(n))
        Next

        CloseForm()
    End Sub

    Private Sub OpenItem(ByVal index As Integer)
        With lvwTable.Items(index)
            If TypeOf .Tag Is Integer Then 'Object ID (Information Schema has no id)
                Try
                    OpenTableFormById(CInt(.Tag), "")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    ListDatabaseObjects()
                End Try
            End If
        End With
    End Sub

    ''' <summary>
    ''' Create a table editor window based on the dastabase object id.
    ''' </summary>
    Public Function OpenTableFormById(ByVal id As Integer, ByVal whereClause As String) As frm_Table
        Server.ChangeDatabase(SelectedDatabase)
        Dim dbObject = Server.Database.GetDatbaseObjectById(id)
        If TypeOf dbObject Is Smart.SqlTable Then
            Dim table = CType(dbObject, Smart.SqlTable)

            If Not whereClause = "" Then
                'Build cache to load the Where Clause
                Dim vs As New TableViewStatus(table.FullName)
                vs.WhereConditions.Add(whereClause)
                If ParentMainForm.ViewCaches.ContainsKey(vs.TableName) Then
                    ParentMainForm.ViewCaches(vs.TableName) = vs
                Else
                    ParentMainForm.ViewCaches.Add(vs.TableName, vs)
                End If
            End If

            Return ParentMainForm.CreateTableWindow(CType(dbObject, Smart.SqlTable))
        Else
            Return Nothing
        End If
    End Function


    Private Sub ListDatabaseObjects()
        If SelectedDatabase = "" Then 'No Database is found
            lvwTable.Items.Clear()
            Exit Sub
        End If

        'Show Dynamic Progress
        lvwTable.Items.Clear()
        lvwTable.Items.Add("Listing...")
        Application.DoEvents()

        'Get Data Source
        Dim dtTable As DataTable
        Try
            If chkUserTable.Checked = True Then
                dtTable = Server.Database.GetTables()
            ElseIf chkUserView.Checked Then
                dtTable = Server.Database.GetViews()
            ElseIf chkUserTableAndView.Checked Then
                dtTable = Server.Database.GetTablesAndViews()
            ElseIf chkInformationSchema.Checked = True Then
                dtTable = Server.Database.GetInformationSchemas()
            ElseIf chkSystemView.Checked = True Then
                dtTable = Server.Database.GetSystemViews()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            RaiseErrorMessage(ex.Message)
            Exit Sub
        End Try

        'List Data in the Control
        Dim tableCount As Integer = 0, viewCount As Integer = 0
        Dim tableName As String, lastSchema As String = ""
        Dim twoColors As Color() = New Color() {Color.White, Color.LightYellow}
        Dim schemaCount As Integer = 0
        lvwTable.Items.Clear()

        For n As Integer = 0 To dtTable.Rows.Count - 1
            Dim item As ListViewItem = New ListViewItem()
            Dim tableSchema As String = dtTable.Rows(n)("schema_name").ToString()
            tableName = dtTable.Rows(n)("name").ToString()
            If Smart.CommonProperty.UserDefaultSchema = tableSchema Then
                item.Text = tableName
                item.Tag = dtTable.Rows(n)("object_id")
            Else
                item.Text = tableSchema & "." & tableName
                item.Tag = dtTable.Rows(n)("object_id")
            End If

            If Not tableSchema = lastSchema Then
                schemaCount += 1
                lastSchema = tableSchema
            End If

            'Be-careful, the type is char(2), which will return redundant empty
            Select Case dtTable.Rows(n)("type").ToString().Trim()
                Case Smart.CommonProperty.GetObjectTypeCode(Smart.CommonProperty.DatabaseObject.Table)
                    item.ForeColor = Color.Black
                    tableCount += 1
                Case Smart.CommonProperty.GetObjectTypeCode(Smart.CommonProperty.DatabaseObject.View)
                    item.ForeColor = Color.MediumSeaGreen
                    viewCount += 1
            End Select
            item.BackColor = twoColors(schemaCount Mod 2)
            lvwTable.Items.Add(item)
        Next

        'Print Statistics
        lblDatabaseProperty.Text = "Collation: " & Server.Database.Collation & "  Create Date: " & Server.Database.CreateDate.ToString() & "  Size: " & CHK.FileSystem.FormatFileSize(Server.Database.Size)
        lblStatistics.Text = "Table: " & tableCount.ToString() & "  View: " & viewCount.ToString()
    End Sub

    Public Sub HighlightDatabaseObjectList()
        Dim n As Integer, tableName As String, count As Integer = 0, firstItemIndex As Integer = -1
        'Highlight exact item
        For n = 0 To lvwTable.Items.Count - 1
            tableName = lvwTable.Items(n).Tag.ToString()
            If tableName.ToLower() = SearchText.ToLower() Then 'Found the exact item, finished searching
                lvwTable.Items(n).Selected = True
                count += 1
                firstItemIndex = n
                GoTo finished
            End If
        Next

        'Highlight potential items
        For n = 0 To lvwTable.Items.Count - 1
            tableName = lvwTable.Items(n).Text.ToString()
            If tableName.ToLower().Contains(SearchText) = True And Not SearchText = "" Then
                lvwTable.Items(n).Selected = True
                count += 1
                If firstItemIndex = -1 Then firstItemIndex = n
            Else
                lvwTable.Items(n).Selected = False
            End If
        Next

Finished:
        'Update Statistics
        If SearchText = "" Then
            lblTableMatch.Text = "You can search table by typing the name directly"
        Else
            lblTableMatch.Text = SearchText & " (Matched: " & count.ToString() & ")"
            If firstItemIndex > -1 Then lvwTable.EnsureVisible(firstItemIndex)
            lvwTable.Update()
        End If
    End Sub

    Private Sub FindClosestDatabaseObject(ByVal name As String, ByRef outItemIndex As Integer, ByRef outPercentMatch As Double)
        Dim searchText As String()
        Dim n As Integer
        Dim tableName As String, foundIndex As Integer = -1, foundPercent As Double = 0, matchPercent As Double
        searchText = name.Split(" ".ToCharArray())

        For n = 0 To lvwTable.Items.Count - 1
            tableName = lvwTable.Items(n).Text
            matchPercent = StringExtension.GetSimilarityPercent(tableName, name, True) 'The match percentage between the search and the actual table name

            If matchPercent > foundPercent And matchPercent > 0 Then
                foundIndex = n
                foundPercent = matchPercent
            End If
        Next

        outItemIndex = foundIndex
        outPercentMatch = foundPercent
    End Sub
#End Region

#Region "DropDownList Items Maintenance"
    Public Sub RefreshConnectionStringHistory()
        Dim tmp As String(), n As Integer
        tmp = ConfigurationSettings.GetAllConnectionStringHistory()
        If tmp Is Nothing Then Exit Sub

        ddConnectionString.Items.Clear()
        For n = 0 To tmp.Length - 1
            If Not tmp(n) = "" Then ddConnectionString.Items.Add(tmp(n))
        Next

        ddConnectionString.Text = ConfigurationSettings.DefaultConnectionString
    End Sub
#End Region

#Region "Miscellaneous Functions"
    Public Enum ConnectionStatusCode
        Connecting
        Connected
        NotConnected
        Disabled
    End Enum

    Public Delegate Sub ShowStatusDelegate()

    Private Sub RefreshLayout()
        'Button
        btnConnect.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.NotConnected)
        btnDisconnect.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected Or ConnectionStatus = ConnectionStatusCode.Connecting)
        ddConnectionString.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.NotConnected)
        ddDatabase.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected)
        btnResetDatabase.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected)

        'ToolStrip
        btnRefresh.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected)
        btnNewConnection.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.NotConnected)
        btnBackupDatabase.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected)
        btnRestoreDatabase.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected)
        btnShowDatabaseDetails.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected)
        btnRenameTable.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected)
        btnEditTable.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected)
        btnDeleteTable.Enabled = CBool(ConnectionStatus = ConnectionStatusCode.Connected)

        'Text Display
        Select Case ConnectionStatus
            Case ConnectionStatusCode.NotConnected
                lblDatabaseProperty.Text = ""
                lblServerProperty.Text = ""
                ParentMainForm.Text = My.Application.Info.Title & " " & My.Application.Info.Version.ToString()
                lvwTable.Items.Clear()
            Case ConnectionStatusCode.Connecting
                lblServerProperty.Text = "Connecting..."
            Case ConnectionStatusCode.Connected
                lblDatabaseProperty.Text = ""
                lblServerProperty.Text = Server.ProductName & " " & Server.Edition & " " & Server.ProductLevel & " " & Server.ProductVersion
                ParentMainForm.Text = Server.ServerName & " - " & My.Application.Info.ProductName 'Change Text
        End Select

        Application.DoEvents()
    End Sub

    Public Delegate Sub ListDatabasesDelegate(ByVal dbName As String)

    Private Sub RaiseErrorMessage(ByVal msg As String)
        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub ShowConnectionWizard()
        Dim f As New frm_ConnectionWizard
        f.MdiParent = Me.ParentMainForm
        f.LoadFromConnectionString(ddConnectionString.Text, "")
        f.Show()
    End Sub
#End Region

#Region "Function [External]"
    Public Function CreateDataAdapter() As SmartDataAdapter
        If SelectedConnectionString = "" Then Throw New ApplicationException("The connection string is not set.")
        Dim a As New SmartDataAdapter(SelectedConnectionString)
        a.ChangeDatabase(SelectedDatabase)
        Return a
    End Function

#End Region

#Region "Interfaces"
    Public Sub CloseForm() Implements IFormClose.CloseForm
        ParentMainForm.SwitchDatabaseWindow(False)
    End Sub

    Public Sub RefreshForm() Implements IFormRefresh.RefreshForm
        btnRefresh_Click(Nothing, Nothing)
    End Sub
#End Region

End Class