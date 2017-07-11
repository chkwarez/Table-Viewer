Public Class frm_SQLSyn : Implements IFormClose
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property
    Public Table As Smart.SqlTable

#Region "Interfaces"
    Public Sub CloseForm() Implements IFormClose.CloseForm
        'Me.Hide()
        Me.Close()
    End Sub
#End Region

    Public Sub LoadTable()
        Dim dtTable As DataTable
        Dim n As Integer
        Try
            dtTable = Table.GetTableSchema()
        Catch ex As Exception 'SQL exception
            MessageBox.Show(ex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        lblDatabase.Text = Table.Database
        lblTable.Text = Table.Name

        dgResult.Rows.Clear()
        dgResult.Rows.Add(dtTable.Rows.Count)
        Dim gr As DataGridViewRow
        Dim isKey As Boolean
        For n = 0 To dtTable.Rows.Count - 1
            gr = dgResult.Rows(n)
            isKey = CType(dtTable.Rows(n)("IsKey"), Boolean)
            If isKey = True Then
                gr.DefaultCellStyle.BackColor = Color.LightYellow
            End If
            gr.Cells("dcColumnName").Value = dtTable.Rows(n)("ColumnName").ToString()
            gr.Cells("dcDataType").Value = dtTable.Rows(n)("DataTypePrint").ToString()
            gr.Cells("dcAllowSearch").Value = False
            gr.Cells("dcAllowLike").Value = False
            gr.Cells("dcAllowStar").Value = False
            gr.Cells("dcUseDateBetween").Value = False
            gr.Cells("dcAllowNull").Value = False
        Next

        Decorate()
    End Sub

    Protected Sub Decorate()
        Dim n As Integer, dataType As String
        For n = 0 To dgResult.Rows.Count - 1
            If dgResult.Rows(n).Cells("dcDataType").Value Is Nothing Then
                dataType = ""
            Else
                dataType = dgResult.Rows(n).Cells("dcDataType").Value.ToString()
            End If
            dgResult.Rows(n).Cells("dcDataType").Style.ForeColor = GetDataTypeColor(dataType)
        Next
    End Sub

    Private Sub chkScriptSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScriptSearch.CheckedChanged
        gpOption.Visible = chkScriptSearch.Checked
    End Sub

    Private Shared Function GetDataTypeColor(ByVal DataType As String) As System.Drawing.Color
        Select Case DataType
            Case "numeric", "decimal"
                Return Color.Blue
            Case "datetime"
                Return Color.Red
            Case "int", "tinyint", "smallint", "bigint", "float", "double"
                Return Color.DarkBlue
            Case Else
                Return Color.Black
        End Select
    End Function

#Region "Form Event"
    Private Sub frm_SQLSyn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadTable()
    End Sub

    Private Sub frm_SQLSyn_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub
#End Region

    Private Sub DecorateScriptOption()
        lblNameAdd.Text = SPAddName
        lblNameDelete.Text = SPDeleteName
        lblNameGet.Text = SPGetName
        lblNameSearch.Text = SPSearchName
        lblNameUpdate.Text = SPUpdateName

        If txtSPPrefix.Text = "sp_" Then
            lblSPPrefixWarning.Visible = True
        Else
            lblSPPrefixWarning.Visible = False
        End If
    End Sub

    Private Sub txtTableCaption_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTableCaption.TextChanged
        DecorateScriptOption()
    End Sub

    Private Sub txtSPPrefix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSPPrefix.TextChanged
        DecorateScriptOption()
    End Sub

    Private Sub btnScriptToWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScriptToWindow.Click
        Dim a As frm_SQL = ParentMainForm.CreateQueryWindow("")
        If radShowSP.Checked Then
            a.SetQuery(Table.Database, ScriptStoredProcedure())
        Else
            a.SetQuery(Table.Database, ScriptSQL())
        End If
    End Sub

    Private Function ScriptStoredProcedure() As String
        Dim sb As New System.Text.StringBuilder
        Dim builder As New Smart.SqlQueryBuilder(Table)

        If chkScriptAdd.Checked Then
            sb.Append(builder.GetInsertStoredProcedure(SPAddName, True))
            sb.AppendLine("GO" & System.Environment.NewLine)
        End If

        If chkScriptDelete.Checked Then
            sb.Append(builder.GetDeleteStoredProcedure(SPDeleteName, True))
            sb.AppendLine("GO" & System.Environment.NewLine)
        End If

        If chkScriptGet.Checked Then
            sb.Append(builder.GetSelectStoredProcedure(SPGetName, True))
            sb.AppendLine("GO" & System.Environment.NewLine)
        End If

        If chkScriptSearch.Checked Then
            sb.Append(builder.GetSearchStoredProcedure(SPSearchName, True, GetSearchColumnSummary()))
            sb.AppendLine("GO" & System.Environment.NewLine)
        End If

        If chkScriptUpdate.Checked Then
            sb.Append(builder.GetUpdateStoredProcedure(SPUpdateName, True))
            sb.AppendLine("GO" & System.Environment.NewLine)
        End If

        Return sb.ToString()
    End Function

    Private Function ScriptSQL() As String
        Dim sb As New System.Text.StringBuilder
        Dim builder As New Smart.SqlQueryBuilder(Table)
        sb.Append(builder.GetSelectSQL(txtTableAlias.Text, Smart.SqlTable.ColumnType.AllColumns, ""))
        Return sb.ToString()
    End Function

    Private Function GetSearchColumnSummary() As Smart.SqlQueryBuilder.SearchColumn()
        Dim n As Integer
        Dim cols As New System.Collections.Generic.List(Of Smart.SqlQueryBuilder.SearchColumn)
        Dim types As Integer
        Dim iCol As Smart.SqlQueryBuilder.SearchColumn

        For n = 0 To dgResult.Rows.Count - 1
            If CBool(dgResult.Rows(n).Cells("dcAllowSearch").Value) = False Then Continue For

            types = CInt(Smart.SqlQueryBuilder.SearchType.Normal)
            If CBool(dgResult.Rows(n).Cells("dcAllowLike").Value) = True Then types *= CInt(Smart.SqlQueryBuilder.SearchType.PartialMatch)
            If CBool(dgResult.Rows(n).Cells("dcAllowStar").Value) = True Then types *= CInt(Smart.SqlQueryBuilder.SearchType.Star)
            If CBool(dgResult.Rows(n).Cells("dcUseDateBetween").Value) = True Then types *= CInt(Smart.SqlQueryBuilder.SearchType.DateBetween)

            iCol = New Smart.SqlQueryBuilder.SearchColumn
            iCol.Name = CStr(dgResult.Rows(n).Cells("dcColumnName").Value)
            iCol.Types = types
            iCol.CombinedVariableName = CStr(dgResult.Rows(n).Cells("dcVariableName").Value)
            cols.Add(iCol)
        Next

        Return cols.ToArray()
    End Function

    Private Sub radShowPanel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radShowSP.CheckedChanged, radShowSQL.CheckedChanged
        gpSP.Visible = radShowSP.Checked
        gpSQL.Visible = radShowSQL.Checked

        If radShowSP.Checked Then
            radShowSP.Font = New System.Drawing.Font(radShowSP.Font, FontStyle.Bold)
            radShowSQL.Font = New System.Drawing.Font(radShowSQL.Font, FontStyle.Regular)
        Else
            radShowSP.Font = New System.Drawing.Font(radShowSP.Font, FontStyle.Regular)
            radShowSQL.Font = New System.Drawing.Font(radShowSQL.Font, FontStyle.Bold)
        End If
    End Sub

#Region "Stored Procedure Name"
    Private ReadOnly Property SPAddName() As String
        Get
            Return txtSPPrefix.Text & "Add" & txtTableCaption.Text
        End Get
    End Property

    Private ReadOnly Property SPDeleteName() As String
        Get
            Return txtSPPrefix.Text & "Delete" & txtTableCaption.Text
        End Get
    End Property

    Private ReadOnly Property SPGetName() As String
        Get
            Return txtSPPrefix.Text & "Get" & txtTableCaption.Text
        End Get
    End Property

    Private ReadOnly Property SPSearchName() As String
        Get
            Return txtSPPrefix.Text & "Search" & txtTableCaption.Text
        End Get
    End Property

    Private ReadOnly Property SPUpdateName() As String
        Get
            Return txtSPPrefix.Text & "Update" & txtTableCaption.Text
        End Get
    End Property
#End Region




End Class