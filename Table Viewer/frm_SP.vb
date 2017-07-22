Public Class frm_SP : Implements IFormClose, IFormRefresh
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


#Region "Form Event"
    Private Sub frm_SP_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If ParentMainForm.DatabaseWindow.Server Is Nothing Then Exit Sub
        LoadDatabaseList()
    End Sub

    Private Sub frm_SP_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
        ddSearchName.Focus()
    End Sub

    Private Sub frm_Database_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        ParentMainForm.SwitchStoredProcedureWindow(False)
    End Sub
#End Region

#Region "Other Control Event"
    Private Sub ddDatabase_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddDatabase.SelectedIndexChanged
        SearchDatabaseObject()
    End Sub

    Private Sub btnFind_Click(sender As System.Object, e As System.EventArgs) Handles btnFind.Click
        SearchDatabaseObject()
    End Sub

    Private Sub btnSetCurrentDatabase_Click(sender As System.Object, e As System.EventArgs) Handles btnSetCurrentDatabase.Click
        LoadDatabaseList()
        ddDatabase.Text = ParentMainForm.DatabaseWindow.SelectedDatabase
    End Sub

    Private Sub chkSearchModifiedDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSearchModifiedDate.CheckedChanged
        txtSearchModifiedDateS.Enabled = chkSearchModifiedDate.Checked
        txtSearchModifiedDateE.Enabled = chkSearchModifiedDate.Checked
    End Sub

    Private Sub ddSearchName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ddSearchName.KeyDown, ddSearchCode.KeyDown
        Dim ctl As CHKControl.ExtendedComboBox = CType(sender, CHKControl.ExtendedComboBox)

        If e.KeyCode = Keys.Enter Then
            SearchDatabaseObject()
            ctl.SelectAll()
        End If

        'If e.Alt = True Then
        '    If e.KeyCode = Keys.D1 Then
        '        radSelectSP.Checked = True
        '        SearchDatabaseObject()
        '        ctl.SelectAll()
        '    ElseIf e.KeyCode = Keys.D2 Then
        '        radSelectFN.Checked = True
        '        SearchDatabaseObject()
        '        ctl.SelectAll()
        '    ElseIf e.KeyCode = Keys.D3 Then
        '        radSelectTF.Checked = True
        '        SearchDatabaseObject()
        '        ctl.SelectAll()
        '    End If
        'End If

        If e.Alt = True Then
            Select Case e.KeyCode
                Case Keys.D1
                    If dgResult.Rows.Count >= 1 Then OpenQueryWindow(CInt(dgResult.Rows(0).Tag), DatabaseObjectOperation.Edit)
                Case Keys.D2
                    If dgResult.Rows.Count >= 2 Then OpenQueryWindow(CInt(dgResult.Rows(1).Tag), DatabaseObjectOperation.Edit)
                Case Keys.D3
                    If dgResult.Rows.Count >= 3 Then OpenQueryWindow(CInt(dgResult.Rows(2).Tag), DatabaseObjectOperation.Edit)
            End Select
        End If
    End Sub

    Private Sub txtSchema_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSchema.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchDatabaseObject()
        End If
    End Sub

    Private Sub btnFindColumn_Click(sender As System.Object, e As System.EventArgs) Handles btnFindColumn.Click
        SearchDatabaseObject(2)
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs)
        'OpenQueryWindow(QueryWindowSource.NewStoredProcedure, "")
    End Sub

    Private Sub radSelect_Click(sender As System.Object, e As System.EventArgs) Handles radSelectSP.Click, radSelectTF.Click, radSelectFN.Click
        SearchDatabaseObject()
    End Sub

    Private Sub btnVerifySyntax_Click(sender As System.Object, e As System.EventArgs) Handles btnVerifySyntax.Click
        VerifySyntax()
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles CreateToolStripMenuItem.Click, AlterToolStripMenuItem.Click, CraeteToFileToolStripMenuItem.Click, AlterToFileToolStripMenuItem.Click, ManagementStudioToolStripMenuItem.Click
        Dim b As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim rtvl As DialogResult

        Select Case b.Tag.ToString()
            Case "Create"
                Dim a As frm_SQL = ParentMainForm.CreateQueryWindow("")
                a.SetQuery(ddDatabase.Text, GetDatabaseObjectScriptForExport(True))
            Case "Alter"
                Dim a As frm_SQL = ParentMainForm.CreateQueryWindow("")
                a.SetQuery(ddDatabase.Text, GetDatabaseObjectScriptForExport(False))
            Case "CreateFile"
                rtvl = cmdgSave.ShowDialog()
                If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub
                System.IO.File.WriteAllText(cmdgSave.FileName, GetDatabaseObjectScriptForExport(True), System.Text.Encoding.UTF8)
            Case "AlterFile"
                rtvl = cmdgSave.ShowDialog()
                If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub
                System.IO.File.WriteAllText(cmdgSave.FileName, GetDatabaseObjectScriptForExport(False), System.Text.Encoding.UTF8)
            Case "SSMSE"
                Dim filePath As String = System.IO.Path.GetTempFileName() & ".sql"
                System.IO.File.WriteAllText(filePath, GetDatabaseObjectScriptForExport(False), System.Text.Encoding.UTF8)
                If System.IO.File.Exists(ConfigurationSettings.MsManagementStudioPath) Then
                    System.Diagnostics.Process.Start(ConfigurationSettings.MsManagementStudioPath, "-d """ & ddDatabase.Text & """ """ & filePath & """")
                End If
            Case Else
                Throw New ApplicationException("Operation " & b.Tag.ToString() & " is not implemented yet.")
        End Select
    End Sub

    Private Sub btnRename_Click(sender As System.Object, e As System.EventArgs) Handles btnRename.Click
        RenameDatabaseObject()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim rtvl As DialogResult
        rtvl = MessageBox.Show("Are you sure to delete the selected objects?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If rtvl = Windows.Forms.DialogResult.Yes Then DeleteDatabaseObject()
    End Sub

    Private Sub btnOpenAll_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenAll.Click
        For n As Integer = 0 To dgResult.Rows.Count - 1
            If DirectCast(dgResult.Rows(n).Cells(0).EditedFormattedValue, Boolean) = False Then Continue For 'Not Checked
            Dim objectID As Integer = CInt(dgResult.Rows(n).Tag)
            OpenQueryWindow(objectID, DatabaseObjectOperation.Edit)
        Next
    End Sub

    Private Sub btnCopyTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAndUpdate.Click, btnCopyAndCreate.Click
        If ddTargetDatabase.Text = "" Then
            MessageBox.Show("Please choose the target database.", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim isCreate As Boolean = sender.Equals(btnCopyAndCreate)

        Try
            Dim count As Integer = 0
            For n As Integer = 0 To dgResult.Rows.Count - 1
                If DirectCast(dgResult.Rows(n).Cells(0).EditedFormattedValue, Boolean) = False Then Continue For 'Not Checked
                Dim objectID As Integer = CInt(dgResult.Rows(n).Tag)
                count += 1

                ParentMainForm.DatabaseWindow.Server.ChangeDatabase(ddDatabase.Text) 'Source Database
                Dim obj As Smart.SqlDatabaseObject = ParentMainForm.DatabaseWindow.Server.Database.GetDatbaseObjectById(objectID)
                Dim query As String = obj.GetDefinition(isCreate) 'Get Definition with Create keyword

                ParentMainForm.DatabaseWindow.Server.ChangeDatabase(ddTargetDatabase.Text) 'Target Database
                Dim newQuery = ParentMainForm.DatabaseWindow.Server.Database.NewQuery()
                newQuery.Text = query
                newQuery.ExecuteNonQuery() 'Execute the object creation
            Next

            If count > 0 Then
                Dim rtvl As DialogResult = MessageBox.Show("The selected objects are copied to the target database " & ddTargetDatabase.Text & " successfully." & vbCrLf & "Do you want to switch to the target database now?", "Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If rtvl = Windows.Forms.DialogResult.Yes Then
                    ddDatabase.Text = ddTargetDatabase.Text
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Copy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Data GridView Event"

    Private Sub dgResult_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellClick
        If dgResult.CurrentRow Is Nothing Then Exit Sub
        Dim objectID As Integer = CInt(dgResult.CurrentRow.Tag)

        Select Case e.ColumnIndex
            Case 0
            Case 1
            Case 2 'Edit
                OpenQueryWindow(objectID, DatabaseObjectOperation.Edit)
            Case 3 'Execute
                OpenQueryWindow(objectID, DatabaseObjectOperation.Execute)
            Case 4
            Case 5
            Case 6
        End Select
    End Sub

    Private Sub dgSP_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellDoubleClick
        If dgResult.CurrentRow Is Nothing Then Exit Sub
        Dim objectID As Integer = CInt(dgResult.CurrentRow.Tag)

        Select Case e.ColumnIndex
            Case 0
            Case 1 'Edit
                OpenQueryWindow(objectID, DatabaseObjectOperation.Edit)
            Case 2
            Case 3
            Case 4
            Case 5
            Case 6
        End Select
    End Sub

    Private Sub dgSP_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dgResult.KeyDown
        If dgResult.CurrentRow Is Nothing Then Exit Sub

        If e.KeyCode = Keys.Control Then
            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(dgResult.CurrentRow.Tag.ToString())
            End If
        End If

        If e.KeyCode = Keys.F2 Then
            RenameDatabaseObject()
        End If

        If e.KeyCode = Keys.Space Then
            Dim n As Integer, b As Boolean
            For n = 0 To dgResult.SelectedCells.Count - 1
                b = CBool(dgResult.Rows(dgResult.SelectedCells(n).RowIndex).Cells(0).Value)
                dgResult.Rows(dgResult.SelectedCells(n).RowIndex).Cells(0).Value = Not b
            Next
        End If

        If e.KeyCode = Keys.Enter Then
            Dim objectID As Integer = CInt(dgResult.CurrentRow.Tag)
            OpenQueryWindow(objectID, DatabaseObjectOperation.Edit)
        End If
    End Sub

    Private Sub dgSP_ColumnHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgResult.ColumnHeaderMouseClick
        If e.ColumnIndex = 0 Then
            Dim n As Integer
            For n = 0 To dgResult.Rows.Count - 1
                dgResult.Rows(n).Cells(0).Value = True
            Next
        End If
    End Sub

#End Region

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

        ddTargetDatabase.Items.Clear()
        For n As Integer = 0 To dtTable.Rows.Count - 1
            ddTargetDatabase.Items.Add(dtTable.Rows(n)("name").ToString())
        Next
        ddTargetDatabase.Text = ""
    End Sub
#End Region

#Region "Database Object"
    Public Sub SearchDatabaseObject(Optional searchOption As Integer = 1)
        Dim dtSP As DataTable, n As Integer
        Dim objType As Smart.CommonProperty.DatabaseObject
        Dim objType2 As Smart.CommonProperty.DatabaseObject = Smart.CommonProperty.DatabaseObject.None

        If searchOption = 1 Then 'Normal Search
            If radSelectSP.Checked Then
                objType = Smart.CommonProperty.DatabaseObject.StoredProcedure
            ElseIf radSelectFN.Checked Then
                objType = Smart.CommonProperty.DatabaseObject.ScalarValuedFunction
            ElseIf radSelectTF.Checked Then
                objType = Smart.CommonProperty.DatabaseObject.TableValuedFunction
                objType2 = Smart.CommonProperty.DatabaseObject.InlineTableFunction
            Else
                Throw New ApplicationException("The object type is not recognized.")
            End If

            Dim d1, d2 As DateTime?
            If chkSearchModifiedDate.Checked Then
                d1 = txtSearchModifiedDateS.Value
                d2 = txtSearchModifiedDateE.Value
            Else
                d1 = Nothing
                d2 = Nothing
            End If

            ParentMainForm.DatabaseWindow.Server.ChangeDatabase(ddDatabase.Text)
            dtSP = ParentMainForm.DatabaseWindow.Server.Database.Search(ddSearchName.Text, txtSchema.Text, d1, d2, ddSearchCode.Text, objType, objType2)
            ddSearchName.AddHistory()
        ElseIf searchOption = 2 Then 'Table Column Search
            dtSP = ParentMainForm.DatabaseWindow.Server.Database.SearchByColumn(txtTableName.Text, txtColumnName.Text, txtDataType.Text)
        Else
            Exit Sub
        End If

        'Present Database Object in Grid
        Dim iRow As DataGridViewRow
        Dim objName As String, objSchema As String, lastUpdate As DateTime
        dgResult.Rows.Clear()
        For n = 0 To dtSP.Rows.Count - 1
            objName = dtSP.Rows(n)("name").ToString()
            objSchema = dtSP.Rows(n)("schema_name").ToString()
            lastUpdate = CDate(dtSP.Rows(n)("modify_date"))

            dgResult.Rows.Add()
            iRow = dgResult.Rows(dgResult.Rows.Count - 1)
            If objSchema = Smart.CommonProperty.UserDefaultSchema Then
                iRow.Cells(dgcSPName.Name).Value = objName
            Else
                iRow.Cells(dgcSPName.Name).Value = objSchema & "." & objName
            End If
            iRow.Cells(dgcSPLastUpdate.Name).Value = lastUpdate.ToString("yyyy-MM-dd HH:mm:ss")
            iRow.Cells(dgcSPName.Name).Style.ForeColor = GetColorFromObjectName(objName)
            iRow.Tag = dtSP.Rows(n)("object_id")
        Next

        GroupBox1.Text = Smart.CommonProperty.GetObjectName(objType) & "  (Count: " & dtSP.Rows.Count.ToString() & ")"
    End Sub

    Private Function GetDatabaseObjectFromGridView() As Smart.SqlDatabaseObject
        Return GetDatabaseObjectFromGridView(dgResult.CurrentRow.Index)
    End Function

    Private Function GetDatabaseObjectFromGridView(rowIndex As Integer) As Smart.SqlDatabaseObject
        Dim objectID As Integer
        objectID = CType(dgResult.Rows(rowIndex).Tag, Integer)
        Return ParentMainForm.DatabaseWindow.Server.Database.GetDatbaseObjectById(objectID)
    End Function
#End Region

#Region "Operation"
    Public Sub VerifySyntax()
        Dim n As Integer
        Dim objectID As Integer
        Dim dbObject As Smart.SqlDatabaseObject
        Dim tmp As String, errorMsg As String = "", isCorrect As Boolean

        tmp = lblStatus.Text

        For n = 0 To dgResult.Rows.Count - 1
            If n Mod 20 = 0 Then
                lblStatus.Text = "Checking... " & n.ToString() & "/" & dgResult.Rows.Count.ToString()
                Application.DoEvents()
            End If

            objectID = CInt(dgResult.Rows(n).Tag)
            ParentMainForm.DatabaseWindow.Server.ChangeDatabase(ddDatabase.Text)
            dbObject = ParentMainForm.DatabaseWindow.Server.Database.GetDatbaseObjectById(objectID)

            isCorrect = dbObject.VerifyDefinition(errorMsg)
            If isCorrect = True Then
                dgResult.Rows(n).Cells("dgcSPStatus").Value = "OK"
                dgResult.Rows(n).Cells("dgcSPStatus").Style.ForeColor = Color.Blue
            Else
                dgResult.Rows(n).Cells("dgcSPStatus").Value = "Error"
                dgResult.Rows(n).Cells("dgcSPStatus").Style.ForeColor = Color.Red
            End If
        Next

        dgResult.Visible = True
        lblStatus.Text = tmp
    End Sub

    Public Sub DeleteDatabaseObject()
        Dim n As Integer
        Dim objectID As Integer
        Dim dbObject As Smart.SqlDatabaseObject

        lblStatus.Text = "Dropping..."
        Application.DoEvents()
        For n = 0 To dgResult.Rows.Count - 1
            If DirectCast(dgResult.Rows(n).Cells(0).EditedFormattedValue, Boolean) = False Then Continue For 'Not Checked
            objectID = CInt(dgResult.Rows(n).Tag)
            ParentMainForm.DatabaseWindow.Server.ChangeDatabase(ddDatabase.Text)
            dbObject = ParentMainForm.DatabaseWindow.Server.Database.GetDatbaseObjectById(objectID)

            Try
                dbObject.Delete()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Next

        SearchDatabaseObject()
        lblStatus.Text = ""
    End Sub

    Public Sub RenameDatabaseObject()
        If dgResult.CurrentRow Is Nothing Then Exit Sub
        Dim objectID As Integer = CInt(dgResult.CurrentRow.Tag)
        Dim dbObject As Smart.SqlDatabaseObject
        Dim newSPName As String
        Dim errorMsg As String = ""

        ParentMainForm.DatabaseWindow.Server.ChangeDatabase(ddDatabase.Text)
        dbObject = ParentMainForm.DatabaseWindow.Server.Database.GetDatbaseObjectById(objectID)

        newSPName = InputBox("Please input the new object Name", "Rename", dbObject.Name)
        If newSPName.Trim() = "" Then Exit Sub

        Try
            dbObject.Rename(newSPName)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        SearchDatabaseObject()
    End Sub

    Public Function GetDatabaseObjectScriptForExport(isCreate As Boolean) As String
        Dim n As Integer
        Dim objectID As Integer
        Dim dbObject As Smart.SqlDatabaseObject
        Dim final As New System.Text.StringBuilder()
        Dim tmp As String

        tmp = lblStatus.Text
        lblStatus.Text = "Exporting..."
        Application.DoEvents()

        For n = 0 To dgResult.Rows.Count - 1
            If DirectCast(dgResult.Rows(n).Cells(0).EditedFormattedValue, Boolean) = False Then Continue For 'Not Checked
            objectID = CInt(dgResult.Rows(n).Tag)
            ParentMainForm.DatabaseWindow.Server.ChangeDatabase(ddDatabase.Text)
            dbObject = ParentMainForm.DatabaseWindow.Server.Database.GetDatbaseObjectById(objectID)

            Try
                final = final.AppendLine(dbObject.GetDefinition(isCreate))
                final = final.AppendLine()
                final = final.AppendLine("GO")
                final = final.AppendLine()
            Catch ex As Exception

            End Try
        Next

        lblStatus.Text = tmp
        Return final.ToString()
    End Function
#End Region

#Region "Function [External]"
    ''' <summary>
    ''' Open a new query window and display the script of selected operation
    ''' </summary>
    ''' <param name="objectID">The object ID of an IExecutable object</param>
    Private Sub OpenQueryWindow(objectID As Integer, operation As DatabaseObjectOperation)
        Dim obj As Smart.SqlDatabaseObject = ParentMainForm.DatabaseWindow.Server.Database.GetDatbaseObjectById(objectID)
        Dim query As String

        If operation = DatabaseObjectOperation.Edit Then
            Dim a As frm_SQL = ParentMainForm.CreateQueryWindow(obj.FullName)
            query = obj.GetDefinition(False)
            a.SetQuery(ddDatabase.Text, query)
            a.SetSource(obj)
        ElseIf operation = DatabaseObjectOperation.Execute Then
            Dim b As frm_SPExecutor = ParentMainForm.CreateSPExecutor(CType(obj, Smart.IExecutable))
            b.LoadObject()
        End If
    End Sub
#End Region

#Region "Interfaces"
    Public Sub CloseForm() Implements IFormClose.CloseForm
        ParentMainForm.SwitchStoredProcedureWindow(False)
    End Sub

    Public Sub RefreshForm() Implements IFormRefresh.RefreshForm
        btnFind_Click(Nothing, Nothing)
        ddSearchName.Focus()
        ddSearchName.SelectAll()
    End Sub
#End Region

#Region "Miscellaneous Function"
    Public Function GetColorFromObjectName(objName As String) As System.Drawing.Color
        If objName.StartsWith("Insert") Or objName.StartsWith("Add") Then
            Return Color.Green
        ElseIf objName.StartsWith("Delete") Then
            Return Color.Red
        ElseIf objName.StartsWith("Get") Then
            Return Color.Blue
        ElseIf objName.StartsWith("Search") Or objName.StartsWith("Summarize") Then
            Return Color.DarkBlue
        ElseIf objName.StartsWith("Update") Then
            Return Color.Orange
        ElseIf objName.StartsWith("rp_") Then
            Return Color.Red
        Else
            Return Color.Black
        End If
    End Function

    Public Sub SetSearchColumnFields(table As String, column As String, datatype As String)
        txtTableName.Text = table
        txtColumnName.Text = column
        txtDataType.Text = datatype
        'btnFindColumn_Click(Nothing, Nothing)
    End Sub
#End Region

    Private Enum DatabaseObjectOperation
        Edit
        Execute
    End Enum


  


End Class