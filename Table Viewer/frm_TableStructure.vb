Imports System.Data.SqlClient

Public Class frm_TableStructure : Implements IFormRefresh, IFormClose
    Public Table As Smart.SqlTable
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

#Region "Form Events"
    Private Sub frm_TableStructure_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub

    Private Sub frm_TableStructure_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
#End Region

#Region "Button Events"
    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadTable()
    End Sub

    Private Sub btnChangeColumnName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeColumnName.Click
        Dim currentName, newName As String
        With dgResult.CurrentRow
            currentName = .Cells(dcColumnName.Name).Value.ToString()
            newName = InputBox("Please enter a new column name.", "Rename Column", currentName)
            If newName = "" Or newName = currentName Then Exit Sub

            Try
                Table.RenameColumn(currentName, newName)
                Table.RefreshColumnCache()
                LoadTable()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End With
    End Sub

    Private Sub btnChangeDataType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeDataType.Click
        Dim columnName, oldDataType, newDataType As String
        With dgResult.CurrentRow
            columnName = .Cells(dcColumnName.Name).Value.ToString()
            oldDataType = .Cells(dcDataType.Name).Value.ToString()
            newDataType = InputBox("Please enter a new data type for column " & columnName, "Change DataType", oldDataType)
            If newDataType = "" Or newDataType = oldDataType Then Exit Sub

            Try
                Table.ChangeColumnDataType(columnName, newDataType)
                Table.RefreshColumnCache()
                LoadTable()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End With
    End Sub

    Private Sub btnChangeDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeDesc.Click
        Dim columnName, oldDesc, newDesc As String
        With dgResult.CurrentRow
            columnName = .Cells(dcColumnName.Name).Value.ToString()
            oldDesc = .Cells(dcDescription.Name).Value.ToString()
            newDesc = InputBox("Please enter the description for column " & columnName, "Change Description", oldDesc)
            If newDesc = "" Or newDesc = oldDesc Then Exit Sub

            Try
                Table.SetColumnDescription(columnName, newDesc)
                Table.RefreshColumnCache()
                LoadTable()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End With
    End Sub

    Private Sub btnAddColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddColumn.Click
        Dim f As New frm_TableColumnEditor
        f.Table = Table
        Dim rtvl = f.ShowDialog()
        If Not rtvl = Windows.Forms.DialogResult.Cancel Then LoadTable()
    End Sub

    Private Sub btnDropColumn_Click(sender As System.Object, e As System.EventArgs) Handles btnDropColumn.Click
        Dim columnName As String = dgResult.GetCellString(dgResult.CurrentRow.Index, dcColumnName.Index)

        Dim rtvl = MessageBox.Show("Are you sure to delete the column '" & columnName & "' ?", "Drop Column", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If rtvl = Windows.Forms.DialogResult.No Then Exit Sub

        Try
            Table.DropColumn(columnName)
            Table.RefreshColumnCache()
            LoadTable()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCreateTable_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateTable.Click
        If txtTableName.Text = "" Then
            MessageBox.Show("Please input a table name, you can separate the schema by comma sign. i.e. CHK.TableViewer")
            Exit Sub
        End If
        If txtTableName.Text.Contains(" ") Or txtTableName.Text.Contains("[") Or txtTableName.Text.Contains("]") Then
            MessageBox.Show("The table name contains illegal characters, please correct.")
            Exit Sub
        End If

        Dim query As String = ScriptTable()

        Dim f = ParentMainForm.CreateQueryWindow("SCRIPT TABLE " & txtTableName.Text)
        f.SetQuery(ParentMainForm.DatabaseWindow.SelectedDatabase, query.ToString())
        f.FormatQuery()
    End Sub

    Private Sub btnCopyColumnDef_Click(sender As Object, e As EventArgs) Handles btnCopyColumnDef.Click
        Dim columnName As String = dgResult.GetCellString(dgResult.CurrentRow.Index, dcColumnName.Index)
        Clipboard.Clear()
        Clipboard.SetText(Table.GetColumnDefinition(columnName), TextDataFormat.UnicodeText)
    End Sub

#End Region

#Region "Data Grid View Events"
    Private Sub dgResult_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellEndEdit
        Decorate(e.RowIndex)
    End Sub
#End Region

#Region "Other Controls Events"
    Private Sub txtTableName_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtTableName.DoubleClick
        dgResult.AutoResizeRows()
    End Sub


    Private Sub txtTableName_Click(sender As Object, e As EventArgs) Handles txtTableName.Click
        Dim txt = CType(sender, ToolStripTextBox)
        txt.SelectAll()
    End Sub
#End Region

#Region "Program Modes"
    Public Sub StartCreateMode()
        btnChangeColumnName.Visible = False
        btnChangeDataType.Visible = False
        btnChangeDesc.Visible = False
        btnAddColumn.Visible = False
        btnDropColumn.Visible = False
        txtTableName.ReadOnly = False

        dgResult.ReadOnly = False
        dgResult.AllowUserToAddRows = True
        dgResult.RowHeadersVisible = True
    End Sub

    Public Sub StartEditMode(t As Smart.SqlTable)
        btnCreateTable.Visible = False
        txtTableName.ReadOnly = True

        dgResult.ReadOnly = True
        dgResult.AllowUserToAddRows = False
        dgResult.RowHeadersVisible = False

        Me.Table = t
        LoadTable()
    End Sub

    Private Sub LoadTable()
        lblStatus.Text = "Loading Table Structure..."
        Me.Text = Table.FullName & " - Structure"
        Application.DoEvents()

        txtTableName.Text = Table.FullName

        Dim columns As Smart.SqlColumn() = Table.GetColumns(Smart.SqlTable.ColumnType.AllColumns)
        dgResult.Rows.Clear()
        dgResult.Rows.Add(columns.Count)
        For n As Integer = 0 To columns.Count - 1
            Dim gr As DataGridViewRow = dgResult.Rows(n)
            With columns(n)
                gr.Cells(dcKey.Name).Value = .IsKey
                gr.Cells(dcColumnName.Name).Value = .Name
                gr.Cells(dcDataType.Name).Value = .DataType
                gr.Cells(dcNullable.Name).Value = .IsNullable
                gr.Cells(dcAutoIncrement.Name).Value = .IsAutoIncrement
                gr.Cells(dcDescription.Name).Value = .Description
                gr.Cells(dgcDefaultValue.Name).Value = .DefaultValue
                gr.Cells(dgcComputedExpr.Name).Value = .ComputedExpression
                If .IsAutoIncrement Then gr.Cells(dgcDefaultValue.Name).Value = "Current: " & Table.GetCurrentIdentity().ToString()
            End With
        Next


        Dim consts As Smart.SqlConstraint() = Table.GetConstraints()
        dgConstraint.Rows.Clear()
        tabConstraint.Text = "Constraint (" & consts.Length & ")"
        If consts.Length > 0 Then
            dgConstraint.Rows.Add(consts.Count)
            For n As Integer = 0 To consts.Count - 1
                Dim gr As DataGridViewRow = dgConstraint.Rows(n)
                With consts(n)
                    gr.Cells(dgcConstName.Name).Value = .Name
                    gr.Cells(dgcConstClause.Name).Value = .CheckClause
                End With
            Next
        End If

        Dim fks As Smart.SqlForeignKey() = Table.GetForeignKeys()
        dgFK.Rows.Clear()
        tabFK.Text = "Foreign Key (" & fks.Length & ")"
        If fks.Length > 0 Then
            dgFK.Rows.Add(fks.Count)
            For n As Integer = 0 To fks.Count - 1
                Dim gr As DataGridViewRow = dgFK.Rows(n)
                With fks(n)
                    gr.Cells(dgcFKParentColumn.Name).Value = .ColumnName
                    gr.Cells(dgcFKRefTable.Name).Value = .RefTableSchema & "." & .RefTableName
                    gr.Cells(dgcFKRefColumn.Name).Value = .RefColumnName
                End With
            Next
        End If

        Dim uks As Smart.SqlUniqueKey() = Table.GetUniqueKeys()
        tabUK.Text = "Unique Key (" & uks.Length & ")"
        If uks.Length > 0 Then
            For n As Integer = 0 To uks.Count - 1
                For m As Integer = 0 To uks(n).Columns.Count - 1
                    dgUK.Rows.Add()
                    Dim gr As DataGridViewRow = dgUK.Rows(dgUK.RowCount - 1)
                    With uks(n).Columns(m)
                        gr.Cells(dgcUKName.Name).Value = uks(n).Name
                        gr.Cells(dgcUKColumn.Name).Value = .ColumnName
                        gr.Cells(dgcUKOrdinal.Name).Value = .Ordinal
                    End With
                Next
            Next
        End If

        Dim ixs As Smart.SqlIndex() = Table.GetIndices()
        tabIX.Text = "Index (" & ixs.Length & ")"
        If ixs.Length > 0 Then
            For n As Integer = 0 To ixs.Count - 1
                For m As Integer = 0 To ixs(n).Columns.Count - 1
                    dgIX.Rows.Add()
                    Dim gr As DataGridViewRow = dgIX.Rows(dgIX.RowCount - 1)
                    With ixs(n).Columns(m)
                        gr.Cells(dgcIXName.Name).Value = ixs(n).Name
                        gr.Cells(dgcIXColumn.Name).Value = .ColumnName
                        gr.Cells(dgcIXOrdinal.Name).Value = .Ordinal
                        gr.Cells(dgcIXInclude.Name).Value = .IsInclude
                    End With
                Next
            Next
        End If

        Dim sbVariable As New System.Text.StringBuilder()
        For n As Integer = 0 To columns.Count - 1
            sbVariable.AppendLine("DECLARE @" & columns(n).Name & " " & columns(n).DataType)
        Next
        txtVariable.Text = sbVariable.ToString

        lblStatus.Text = ""
        Decorate()
    End Sub

    Public Function ScriptTable() As String
        Dim query As New System.Text.StringBuilder
        Dim pks As New List(Of String)

        Dim tableName As String = CHK.StringExtension.RSStr(txtTableName.Text, ".", True)
        Dim schema As String = CHK.StringExtension.LSStr(txtTableName.Text, ".")

        If schema = "" Then
            schema = Smart.CommonProperty.UserDefaultSchema
        End If

        query.AppendLine("CREATE TABLE " & Smart.SqlQueryBuilder.EncodeObjectName(schema) & "." & Smart.SqlQueryBuilder.EncodeObjectName(tableName))
        query.AppendLine("(")

        For n As Integer = 0 To dgResult.RowCount - 1
            If dgResult.Rows(n).IsNewRow Then Continue For

            Dim suffix As String
            If CHK.StringConverter.ToBoolean(dgResult.GetCellString(n, dcAutoIncrement.Index), False) Then
                suffix = "IDENTITY(1,1)"
            ElseIf Not dgResult.GetCellString(n, dgcComputedExpr.Index) = "" Then
                suffix = "AS " & dgResult.GetCellString(n, dgcComputedExpr.Index)
            Else
                If CHK.StringConverter.ToBoolean(dgResult.GetCellString(n, dcNullable.Index), False) Then
                    suffix = "NULL"
                Else
                    suffix = "NOT NULL"
                End If
            End If

            query.Append("[" & dgResult.GetCellString(n, dcColumnName.Index) & "] " & dgResult.GetCellString(n, dcDataType.Index) & " " & suffix)
            If n < dgResult.RowCount - 1 Then 'not last row
                query.AppendLine(",")
            Else 'last row
                query.AppendLine()
            End If

            'Record PK
            If CHK.StringConverter.ToBoolean(dgResult.GetCellString(n, dcKey.Index), False) Then
                pks.Add(dgResult.GetCellString(n, dcColumnName.Index))
            End If
        Next

        'Add PK statement
        If pks.Count > 0 Then
            query.AppendLine("Constraint PK_" & txtTableName.Text)
            query.AppendLine("PRIMARY KEY CLUSTERED (" & String.Join(",", pks.ToArray()) & ")")
            query.AppendLine("With (IGNORE_DUP_KEY = OFF)")
        End If

        query.AppendLine(");")

        'Add Column Descrption
        For n As Integer = 0 To dgResult.RowCount - 1
            If dgResult.Rows(n).IsNewRow Then Continue For

            If Not dgResult.GetCellString(n, dcDescription.Index) = "" Then 'Has Description
                query.AppendLine("GO")
                query.AppendLine(GetAddColumnDescriptionQuery(schema, tableName, dgResult.GetCellString(n, dcColumnName.Index), dgResult.GetCellString(n, dcDescription.Index)))
            End If
        Next

        Return query.ToString()
    End Function
#End Region

#Region "Presentation"
    Protected Sub Decorate(Optional ByVal specificIndex As Integer = -1)
        Dim n As Integer, dataType As String, isKey As Boolean

        If specificIndex = -1 Then
            For n = 0 To dgResult.Rows.Count - 1
                If dgResult.Rows(n).Cells(dcDataType.Name).Value Is Nothing Then
                    dataType = ""
                Else
                    dataType = dgResult.Rows(n).Cells(dcDataType.Name).Value.ToString()
                End If
                dgResult.Rows(n).Cells(dcDataType.Name).Style.ForeColor = frm_Table.GetDataTypeColor(dataType) 'Fore Color
                dgResult.Rows(n).Cells(dcColumnName.Name).Style.ForeColor = frm_Table.GetDataTypeColor(dataType) 'Fore Color

                isKey = CType(dgResult.Rows(n).Cells(dcKey.Name).FormattedValue, Boolean)
                dgResult.Rows(n).DefaultCellStyle.BackColor = CType(IIf(isKey = True, Color.LightYellow, Color.White), Color) 'Back Color
            Next
        Else
            n = specificIndex
            If dgResult.Rows(n).Cells(dcDataType.Name).Value Is Nothing Then
                dataType = ""
            Else
                dataType = dgResult.Rows(n).Cells(dcDataType.Name).Value.ToString()
            End If
            dgResult.Rows(n).Cells(dcDataType.Name).Style.ForeColor = frm_Table.GetDataTypeColor(dataType) 'Fore Color
            dgResult.Rows(n).Cells(dcColumnName.Name).Style.ForeColor = frm_Table.GetDataTypeColor(dataType) 'Fore Color

            isKey = CType(dgResult.Rows(n).Cells(dcKey.Name).FormattedValue, Boolean)
            dgResult.Rows(n).DefaultCellStyle.BackColor = CType(IIf(isKey = True, Color.LightYellow, Color.White), Color) 'Back Color
        End If
    End Sub
#End Region

#Region "Miscellaneous Functions"
    Public Function GetAddColumnDescriptionQuery(schema As String, tableName As String, columnName As String, desc As String) As String
        desc = Smart.SqlQueryBuilder.EncodeText(desc)
        Return "EXEC sp_addextendedproperty N'MS_Description', N'" & desc & "', N'SCHEMA', N'" & schema & "', N'TABLE', N'" & tableName & "', N'COLUMN', N'" & columnName & "'"
    End Function

#End Region

#Region "Interfaces"
    Public Sub RefreshForm() Implements IFormRefresh.RefreshForm
        LoadTable()
    End Sub

    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub


#End Region



End Class
