Public Class frm_Copier
    Dim Server1 As Smart.SqlServer
    Dim Server2 As Smart.SqlServer
    Dim Actions As New List(Of CopyItem)

    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

    Private Sub ListDatabases(index As Integer, defaultDatabase As String)
        Dim dd As ComboBox
        Dim dtSource As DataTable 'Data Source

        If index = 1 Then
            dd = ddDatabase1
            dtSource = Server1.GetDatabases(True) 'Only Online Non-System Database
        Else
            dd = ddDatabase2
            dtSource = Server2.GetDatabases(True) 'Only Online Non-System Database
        End If

        'List Data in the Control
        dd.DisplayMember = "name"
        dd.ValueMember = "name"
        dd.DataSource = dtSource

        'Apply Default Value
        If Not defaultDatabase = "" Then
            Dim tmpInd As Integer = dd.SelectedIndex
            dd.SelectedValue = defaultDatabase 'If such item is not found, the SelectedValue becomes NULL
            If dd.SelectedValue Is Nothing Then 'The default database is not found
                dd.SelectedIndex = tmpInd 'Resume original selection
            End If
        End If

        dd.SelectedValue = ConfigurationSettings.DefaultDatabase 'If such item is not found, the SelectedValue becomes NULL
    End Sub

    Private Sub ListTables(index As Integer)
        Dim lvwTable As ListView
        Dim lblStatistics As Label
        Dim dtSource As DataTable 'Data Source

        If index = 1 Then
            lvwTable = lvwTable1
            lblStatistics = lblStatistics1
        Else
            lvwTable = lvwTable2
            lblStatistics = lblStatistics2
        End If

        Try
            If index = 1 Then
                If Server1.Database Is Nothing Then 'No Database is found
                    lvwTable.Items.Clear()
                    Exit Sub
                Else
                    dtSource = Server1.Database.GetTablesAndViews() 'Allow Table or Views to be read
                End If
            Else
                If Server2.Database Is Nothing Then 'No Database is found
                    lvwTable.Items.Clear()
                    Exit Sub
                Else
                    dtSource = Server2.Database.GetTables() 'Allow Table only for update
                End If
            End If

            'Show Dynamic Progress
            lvwTable.Items.Clear()
            lvwTable.Items.Add("Listing...")
            Application.DoEvents()

            'List Data in the Control
            Dim n As Integer, item As ListViewItem
            Dim tableName As String, tableSchema As String
            lvwTable.Items.Clear()

            For n = 0 To dtSource.Rows.Count - 1
                item = New ListViewItem()

                tableSchema = dtSource.Rows(n)("schema_name").ToString()
                tableName = dtSource.Rows(n)("name").ToString()
                If Smart.CommonProperty.UserDefaultSchema = tableSchema Then
                    item.Text = tableName
                    item.Tag = dtSource.Rows(n)("object_id")
                Else
                    item.Text = tableSchema & "." & tableName
                    item.Tag = dtSource.Rows(n)("object_id")
                End If

                lvwTable.Items.Add(item)
            Next

            'Print Statistics
            lblStatistics.Text = "Table: " & dtSource.Rows.Count.ToString()
        Catch ex As Exception
            lblStatistics.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub ddDatabase1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddDatabase1.SelectedIndexChanged
        Dim d As ComboBox = CType(sender, ComboBox)
        If d.SelectedValue Is Nothing Then Exit Sub
        Server1.ChangeDatabase(d.SelectedValue.ToString())
        ListTables(1)
    End Sub

    Private Sub ddDatabase2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddDatabase2.SelectedIndexChanged
        Dim d As ComboBox = CType(sender, ComboBox)
        If d.SelectedValue Is Nothing Then Exit Sub
        Server2.ChangeDatabase(d.SelectedValue.ToString())
        ListTables(2)
    End Sub

    Private Sub StartStep(stepIndex As Integer)
        Select Case stepIndex
            Case 1 'Initialize (Select Connection String)
                TabControl1.SelectedIndex = 0
                If Server1 IsNot Nothing Then Server1.Disconnect()
                If Server2 IsNot Nothing Then Server2.Disconnect()
                Server1 = Nothing
                Server2 = Nothing
                RefreshConnectionStringHistory()
            Case 2 'Load Table
                TabControl1.SelectedIndex = 1
                Try
                    Server1 = New Smart.SqlServer(ddConnectionString1.Text)
                    Server2 = New Smart.SqlServer(ddConnectionString2.Text)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Exit Sub
                End Try
                ListDatabases(1, "")
                ListDatabases(2, "")
            Case 3 'Execute
                TabControl1.SelectedIndex = 2
                btnExecute.Visible = True
                txtResult.Text = ""
                ProgressBar1.Value = 0
                PrintSequentialAction()
        End Select
    End Sub

#Region "Layout"
    Private Sub RaiseErrorMessage(msg As String)
        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
#End Region

#Region "Form Events"

    Private Sub frm_Copier_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        StartStep(1)
    End Sub
#End Region

#Region "Button Events"
    Private Sub btnNextStep1_Click(sender As System.Object, e As System.EventArgs) Handles btnNextStep1.Click
        StartStep(2)
    End Sub

    Private Sub btnBack2_Click(sender As System.Object, e As System.EventArgs) Handles btnBack2.Click
        StartStep(1)
    End Sub

    Private Sub btnNext2_Click(sender As System.Object, e As System.EventArgs) Handles btnNext2.Click
        StartStep(3)
    End Sub

    Private Sub btnAddAction_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAction.Click
        Dim t1 As Integer
        Dim t2 As Integer
        If lvwTable1.SelectedItems.Count = 0 Then Exit Sub

        Dim item As New CopyItem
        t1 = CType(lvwTable1.SelectedItems(0).Tag, Integer)
        item.Source = Server1.Database.GetDatbaseObjectById(t1)
        item.ItemType = Smart.CommonProperty.DatabaseObject.Table
        item.CreateNewAtDestination = chkCreateAtDestination.Checked

        If chkCreateAtDestination.Checked = True Then 'Create New Table
            item.Destination = Nothing
            item.DestinationDatabase = ddDatabase2.SelectedValue.ToString() 'Current Selected Database
            item.TruncatesDestination = False
        Else 'Copy to existing table
            If lvwTable2.SelectedItems.Count = 0 Then Exit Sub
            t2 = CType(lvwTable2.SelectedItems(0).Tag, Integer)
            item.Destination = Server2.Database.GetDatbaseObjectById(t2)
            item.TruncatesDestination = chkTruncateDestination.Checked
        End If
        Actions.Add(item)

        RefreshActionList()
    End Sub
#End Region

    Private Sub RefreshActionList()
        lvwAction.Items.Clear()
        Dim n As Integer
        For n = 0 To Actions.Count - 1
            Dim i As New ListViewItem
            With Actions(n)
                i.Text = .Source.FullName & " (" & .Source.Database & ")"
                If .CreateNewAtDestination = True Then
                    i.SubItems.Add("[NEW TABLE] (" & .DestinationDatabase & ")")
                Else
                    i.SubItems.Add(.Destination.FullName & " (" & .Destination.Database & ")")
                End If
                i.SubItems.Add(.ItemType.ToString())
                i.SubItems.Add(If(.TruncatesDestination, "Destination", ""))
                i.Tag = n
            End With
            lvwAction.Items.Add(i)
        Next
    End Sub

    Private Sub PrintSequentialAction()
        Dim sb As New System.Text.StringBuilder()
        Dim n As Integer

        For n = 0 To Actions.Count - 1
            With Actions(n)
                sb.AppendLine((n + 1) & ".")
                If .TruncatesDestination = True Then sb.AppendLine("Truncate " & .Destination.Database & "." & .Destination.FullName)
                If .CreateNewAtDestination = True Then
                    sb.AppendLine("Copy " & .Source.Database & "." & .Source.FullName & " To " & .DestinationDatabase & ".[NEW TABLE]")
                Else
                    sb.AppendLine("Copy " & .Source.Database & "." & .Source.FullName & " To " & .Destination.Database & "." & .Destination.FullName)
                End If
                sb.AppendLine()
            End With
        Next

        txtResult.Text = sb.ToString()
    End Sub

    Private Sub Execute()
        Dim n As Integer
        Dim dtTable1 As DataTable, dtTable2 As DataTable

        txtResult.Text = ""
        ProgressBar1.Maximum = Actions.Count
        PrintResult(DateTime.Now.ToString(), False)
        PrintResult("Operation starts, total number of action is " & Actions.Count, True)
        For n = 0 To Actions.Count - 1
            With Actions(n)
                PrintResult("Action " & (n + 1), True)
                If .ItemType = Smart.CommonProperty.DatabaseObject.Table Then
                    'Prepare Table Structure
                    Dim t1 As Smart.SqlTable, t2 As Smart.SqlTable, count1 As Integer, count2 As Integer
                    t1 = CType(.Source, Smart.SqlTable)
                    t2 = CType(.Destination, Smart.SqlTable)

                    If .CreateNewAtDestination = True Then 'Create the New Table in Destination and reassigned to the variable t2
                        PrintResult("[Destination: " & .DestinationDatabase & "] Creating table " & t1.FullName & "... ", True)
                        Dim builder As New Smart.SqlTableBuilder(t1)
                        Dim query As Smart.SqlQuery = Server2.NewQuery()
                        query.Database = .DestinationDatabase
                        query.Text = builder.GetCreateSQL(builder.GetSchemaTable(), True) 'Because you are coping data, the auto-increment column must be skipped
                        query.Execute(Smart.SqlQuery.ErrorDescription.Summary)
                        Server2.ChangeDatabase(.DestinationDatabase)
                        t2 = Server2.Database.GetTable(t1.FullName)
                    End If

                    'Data Operation
                    If .TruncatesDestination = True Then
                        PrintResult("[Destination: " & t2.Database & "] Truncating table " & t2.FullName & "... ", True)
                        t2.Truncate()
                        PrintResult("Done", False)
                    End If

                    With t1
                        PrintResult("[Source: " & .Database & "] Reading data " & .FullName & "... ", True)
                        dtTable1 = .GetData("SELECT * FROM " & .FullName, 0, Nothing, count1)
                        PrintResult("Found " & count1 & " records", False)
                    End With

                    With t2
                        PrintResult("[Destination: " & .Database & "] Reading data" & .FullName & "... ", True)
                        dtTable2 = .GetData("SELECT * FROM " & .FullName, 0, Nothing, count2)
                        PrintResult("Found " & count2 & " records", False)
                    End With

                    Try
                        PrintResult("Building final result... ", True)
                        If .TruncatesDestination = True Then 'Can direct Copy
                            BatchTable.Copy(dtTable1, dtTable2, New String() {}) 'Faster
                        Else
                            BatchTable.Copy(dtTable1, dtTable2, t1.GetPrimaryKeys()) 'Slower
                        End If
                        PrintResult("Done", False)
                    Catch ex As Exception
                        PrintResult(ex.Message, True)
                    End Try

                    Try
                        PrintResult("Updating... ", True)
                        t2.UpdateData(dtTable2)
                        PrintResult("Done", False)
                    Catch ex As Exception
                        PrintResult(ex.Message, True)
                    End Try
                End If
                PrintResult("", True)
                txtResult.ScrollToCaret()
                ProgressBar1.Value = n + 1
            End With
        Next
        PrintResult("Operation completed", True)
        PrintResult(DateTime.Now.ToString(), True)
    End Sub

    Private Sub btnDeleteAction_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteAction.Click
        If lvwAction.SelectedItems.Count = 0 Then Exit Sub
        Dim n As Integer = CType(lvwAction.SelectedItems(0).Tag, Integer)
        Actions.RemoveAt(n)
        RefreshActionList()
    End Sub

    Private Sub PrintResult(msg As String, newLine As Boolean)
        If newLine = True Then
            txtResult.Text &= vbCrLf & msg
        Else
            txtResult.Text &= msg
        End If
        Application.DoEvents()
    End Sub

    Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click
        btnExecute.Visible = False
        Application.DoEvents()
        Execute()
    End Sub

    Private Sub chkCreateAtDestination_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCreateAtDestination.CheckedChanged
        lvwTable2.Enabled = Not chkCreateAtDestination.Checked
    End Sub

    Public Sub RefreshConnectionStringHistory()
        Dim tmp As String(), n As Integer
        tmp = ConfigurationSettings.GetAllConnectionStringHistory()
        If tmp Is Nothing Then Exit Sub

        ddConnectionString1.Items.Clear()
        ddConnectionString2.Items.Clear()

        For n = 0 To tmp.Length - 1
            If Not tmp(n) = "" Then ddConnectionString1.Items.Add(tmp(n))
            If Not tmp(n) = "" Then ddConnectionString2.Items.Add(tmp(n))
        Next

        ddConnectionString1.Text = ConfigurationSettings.DefaultConnectionString
        ddConnectionString2.Text = ConfigurationSettings.DefaultConnectionString
    End Sub

    Private Sub lvwTable1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwTable1.SelectedIndexChanged
        Dim n As Integer
        Dim tmp As String
        If lvwTable1.SelectedItems.Count = 0 Then Exit Sub

        tmp = lvwTable1.SelectedItems(0).Text
        For n = 0 To lvwTable2.Items.Count - 1
            If lvwTable2.Items(n).Text = tmp Then
                lvwTable2.Items(n).Selected = True
            Else
                lvwTable2.Items(n).Selected = False
            End If
        Next

    End Sub

    Private Sub lvwTable1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lvwTable1.DoubleClick
        btnAddAction_Click(Nothing, Nothing)
    End Sub

    Private Sub btnShowConnWizard1_Click(sender As Object, e As EventArgs) Handles btnShowConnWizard1.Click
        Dim f As New frm_ConnectionWizard
        f.MdiParent = Me.ParentMainForm
        f.Show()
        f.SetDialogMode(New frm_ConnectionWizard.ConnectionStringCallbackDelegate(AddressOf SetConnectionString1))
    End Sub

    Private Sub btnShowConnWizard2_Click(sender As Object, e As EventArgs) Handles btnShowConnWizard2.Click
        Dim f As New frm_ConnectionWizard
        f.MdiParent = Me.ParentMainForm
        f.Show()
        f.SetDialogMode(New frm_ConnectionWizard.ConnectionStringCallbackDelegate(AddressOf SetConnectionString2))
    End Sub

#Region "Delegate Functions"
    Public Sub SetConnectionString1(connStr As String)
        ddConnectionString1.Text = connStr
    End Sub

    Public Sub SetConnectionString2(connStr As String)
        ddConnectionString2.Text = connStr
    End Sub
#End Region
End Class