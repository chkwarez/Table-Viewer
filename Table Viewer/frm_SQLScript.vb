Public Class frm_SQLScript : Implements IFormClose
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property
    Dim Table As Smart.SqlTable
    Dim DefaultWhereClause As String

    Private Sub frm_SQLScript_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        LoadResult()
    End Sub

    Private Sub LoadResult()
        Dim Query As Smart.SqlQuery = ParentMainForm.DatabaseWindow.Server.Database.NewQuery()
        Query.Text = txtSourceQuery.Text
        Dim result As Smart.SqlQueryResult() = Query.Execute(Smart.SqlQuery.ErrorDescription.Summary)

        If result.Length = 0 Then
            MessageBox.Show("The query does not return any results")
        Else
            With result(0)
                If .HasError = True Then
                    MessageBox.Show(.ErrorMessage)
                Else
                    If .Data.Tables.Count > 0 Then
                        SetGridView(.Data.Tables(0))
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub SetGridView(ByVal src As DataTable)
        src.Columns.Add("Select", GetType(Boolean))
        src.Columns(src.Columns.Count - 1).SetOrdinal(0) 'Show in first column
        BatchTable.SetColumnValue(src, "Select", False, False) 'Set as NOT selected
        dgContent.DataSource = src
        dgContent.Refresh()

        Dim n As Integer
        For n = 0 To src.PrimaryKey.Length - 1
            If n = 0 Then
                txtPrimaryKeys.Text = src.PrimaryKey(n).ColumnName
            Else
                txtPrimaryKeys.Text &= "," & src.PrimaryKey(n).ColumnName
            End If
        Next

        UpdateGridViewStatus()
    End Sub

    Private Sub UpdateGridViewStatus()
        Dim n As Integer, count As Integer = 0
        Dim b As Boolean

        For n = 0 To dgContent.Rows.Count - 1
            b = CBool(dgContent.Rows(n).Cells(0).Value)
            If b = True Then
                count += 1
                dgContent.Rows(n).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgContent.Rows(n).DefaultCellStyle.BackColor = Color.White
            End If
        Next

        If count = 0 Then
            btnScriptToClipboard.Enabled = False
            btnExportToHtml.Enabled = False
            btnScriptToNewQuery.Enabled = False
            btnScriptToFile.Enabled = False
        Else
            btnScriptToClipboard.Enabled = True
            btnExportToHtml.Enabled = True
            btnScriptToNewQuery.Enabled = True
            btnScriptToFile.Enabled = True
        End If
        lblContentStatus.Text = "Count: " & dgContent.Rows.Count & " Selected: " & count
    End Sub
    Private Sub txtSourceQuery_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtSourceQuery.PreviewKeyDown
        If e.KeyCode = Keys.F5 Then
            LoadResult()
        End If
    End Sub


    

    Private Sub btnScriptToNewQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScriptToNewQuery.Click
        dgContent.Update()
        Dim f As frm_SQL = ParentMainForm.CreateQueryWindow("Scripted Data")
        f.SetQuery(ParentMainForm.DatabaseWindow.SelectedDatabase, GetScriptedSQL())
    End Sub

    Private Sub btnScriptToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScriptToClipboard.Click
        dgContent.Update()
        Util.SetClipboardText(GetScriptedSQL())
    End Sub

    Private Function GetScriptedSQL() As String
        Dim oldStatus As String = lblContentStatus.Text
        lblContentStatus.Text = "Scripting..."
        Application.DoEvents()

        Dim src As DataTable = CType(dgContent.DataSource, DataTable)
        src.AcceptChanges()
        Dim dt As DataTable
        Dim rows As DataRow() = src.Select("[Select]=True")
        dt = BatchTable.CreateTableFromDataRows(src, rows)
        dt.Columns.Remove("Select")
        dt.TableName = txtTableName.Text

        Dim sql As New System.Text.StringBuilder()
        Dim builder As New CHK.Database.SmartCommandBuilder(dt)
        builder.UseUnionForInsert = True
        builder.ScriptNullValue = chkScriptNullValue.Checked
        builder.SetRules(txtPrimaryKeys.Text, "")
        dt.AcceptChanges()

        If radInsert.Checked Then
            If chkTruncateTable.Checked Then sql.AppendLine("TRUNCATE TABLE " & dt.TableName & vbCrLf & "GO" & vbCrLf)

            If chkIdentityInsert.Checked Then sql.AppendLine("SET IDENTITY_INSERT " & dt.TableName & " ON" & vbCrLf)

            For n As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(n).SetAdded()
            Next
            sql.AppendLine(builder.GetInsertCommand())

            If chkIdentityInsert.Checked Then sql.AppendLine("SET IDENTITY_INSERT " & dt.TableName & " OFF")

        ElseIf radUpdate.Checked Then
            For n As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(n).SetModified()
            Next
            sql.AppendLine(builder.GetUpdateCommand())
        ElseIf radDelete.Checked Then
            For n As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(n).Delete()
            Next
            sql.AppendLine(builder.GetDeleteCommand())
        End If

        lblContentStatus.Text = oldStatus
        Return sql.ToString()
    End Function

    Private Sub lnkCheckAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCheckAll.LinkClicked
        Dim n As Integer
        For n = 0 To dgContent.Rows.Count - 1
            dgContent.Rows(n).Cells(0).Value = True
        Next
        UpdateGridViewStatus()
    End Sub

    Private Sub lnkUncheckAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUncheckAll.LinkClicked
        Dim n As Integer
        For n = 0 To dgContent.Rows.Count - 1
            dgContent.Rows(n).Cells(0).Value = False
        Next
        UpdateGridViewStatus()
    End Sub

    Private Sub lnkInvert_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkInvert.LinkClicked
        Dim n As Integer
        Dim b As Boolean

        For n = 0 To dgContent.Rows.Count - 1
            b = CBool(dgContent.Rows(n).Cells(0).Value)
            dgContent.Rows(n).Cells(0).Value = Not b
        Next
        UpdateGridViewStatus()
    End Sub

    Public Sub SetParameter(ByVal t As Smart.SqlTable, ByVal whereClause As String)
        Me.Table = t
        Me.DefaultWhereClause = whereClause
    End Sub

    Public Sub LoadTable()
        Dim builder As New Smart.SqlQueryBuilder(Me.Table)
        txtTableName.Text = Me.Table.FullName
        txtSourceQuery.Text = builder.GetSelectSQL("", If(chkScriptReadOnlyColumns.Checked, Smart.SqlTable.ColumnType.AllColumns, Smart.SqlTable.ColumnType.WritableAndKeys), DefaultWhereClause)
        txtPrimaryKeys.Text = Smart.SqlQueryBuilder.GetSerializedColumnNames(Me.Table.GetPrimaryKeys(), "")
        LoadResult()
    End Sub

    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub

    Private Sub dgContent_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgContent.CellEndEdit
        If e.ColumnIndex > 0 Then Exit Sub
        UpdateGridViewStatus()
    End Sub

    Private Sub btnExportToHtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToHtml.Click
        Dim filePath As String = System.IO.Path.GetTempFileName() & ".htm"

        Dim src As DataTable = CType(dgContent.DataSource, DataTable)
        src.AcceptChanges()
        Dim destTable As DataTable
        Dim rows As DataRow() = src.Select("[Select]=True")
        destTable = BatchTable.CreateTableFromDataRows(src, rows)
        destTable.Columns.Remove("Select")

        Dim builder As New CHK.Web.HtmlTableBuilder(destTable)
        Dim content As CHK.Web.HtmlTableContent = builder.GenerateHtml()
        System.IO.File.WriteAllText(filePath, content.ToHtml())

        System.Diagnostics.Process.Start(filePath)
    End Sub

    Private Sub btnScriptToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScriptToFile.Click
        cmdgSave.Filter = "Sql File (*.sql)|*.sql"
        Dim rtvl As DialogResult = cmdgSave.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub
        System.IO.File.WriteAllText(cmdgSave.FileName, GetScriptedSQL(), System.Text.Encoding.UTF8)
    End Sub

    Private Sub btnSelectAndScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAndScript.Click
        Try
            LoadResult()
            lnkCheckAll_LinkClicked(lnkCheckAll, Nothing)
            btnScriptToClipboard_Click(btnScriptToClipboard, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkScriptReadOnlyColumns_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScriptReadOnlyColumns.CheckedChanged
        LoadTable()
    End Sub
End Class