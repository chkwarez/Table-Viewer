Public Class frm_AspxGen : Implements IFormClose, IFormRefresh
    Public Table As Smart.SqlTable
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

#Region "Form Events"
    Private Sub frm_AspxGen_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub

    Private Sub frm_AspxGen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ConfigurationSettings.DefaultLanguage = Language.CSharp.ToString() Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If

        LoadTable()
        GenerateCode()
    End Sub
#End Region

#Region "Button and Other Controls Events"
    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        GenerateCode()
    End Sub
#End Region

#Region "Data Grid View Events"
    'Private Sub dgResult_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellEndEdit
    '    Decorate(e.RowIndex)
    'End Sub

    'Private Sub dgResult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellContentClick
    '    If dgResult.Columns(e.ColumnIndex).Name = dcRename.Name Then 'Rename Table Column
    '        Dim currentName, newName As String, datatype As String
    '        With dgResult.Rows(e.RowIndex)
    '            currentName = .Cells(dcColumnName.Name).Value.ToString()
    '            newName = InputBox("Please enter the new column name.", "Rename", currentName)
    '            If newName = "" Or newName = currentName Then Exit Sub
    '            datatype = .Cells(dcDataType.Name).Value.ToString()

    '            Try
    '                Table.RenameColumn(currentName, newName)
    '                LoadTable()
    '                ParentMainForm.StoredProcedureWindow.SetSearchColumnFields(Table.Name, currentName, datatype)
    '                'ParentMainForm.StoredProcedureWindow.Show()
    '                'ParentMainForm.StoredProcedureWindow.Activate()
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message)
    '            End Try
    '        End With
    '    ElseIf dgResult.Columns(e.ColumnIndex).Name = dcChangeDataType.Name Then 'Change Column Data Type
    '        Dim columnName, oldDataType, newDataType As String
    '        With dgResult.Rows(e.RowIndex)
    '            columnName = .Cells(dcColumnName.Name).Value.ToString()
    '            oldDataType = .Cells(dcDataType.Name).Value.ToString()
    '            newDataType = InputBox("Please enter a new data type for column " & columnName, "Rename", oldDataType)
    '            If newDataType = "" Or newDataType = oldDataType Then Exit Sub

    '            Try
    '                Table.ChangeColumnDataType(columnName, newDataType)
    '                LoadTable()
    '                ParentMainForm.StoredProcedureWindow.SetSearchColumnFields(Table.Name, columnName, oldDataType)
    '                'ParentMainForm.StoredProcedureWindow.Show()
    '                'ParentMainForm.StoredProcedureWindow.Activate()
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message)
    '            End Try
    '        End With
    '    ElseIf dgResult.Columns(e.ColumnIndex).Name = dcChangeDescription.Name Then 'Change Description
    '        Dim columnName, oldDesc, newDesc As String
    '        With dgResult.Rows(e.RowIndex)
    '            columnName = .Cells(dcColumnName.Name).Value.ToString()
    '            oldDesc = .Cells(dcDescription.Name).Value.ToString()
    '            newDesc = InputBox("Please enter the description for column " & columnName, "Rename", oldDesc)
    '            If newDesc = "" Or newDesc = oldDesc Then Exit Sub

    '            Try
    '                Table.SetColumnDescription(columnName, newDesc)
    '                LoadTable()
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message)
    '            End Try
    '        End With
    '    End If
    'End Sub
#End Region

#Region "Table Functions"
    Public Sub LoadTable()
        Dim lang As Language = If(RadioButton1.Checked, Language.CSharp, Language.VB)
        Dim columns As Smart.SqlColumn() = Table.GetColumns(Smart.SqlTable.ColumnType.AllColumns)
        dgResult.Rows.Clear()
        dgResult.Rows.Add(columns.Count)

        For n As Integer = 0 To columns.Count - 1
            Dim gr As DataGridViewRow = dgResult.Rows(n)
            With columns(n)
                gr.Cells(dcKey.Name).Value = .IsKey
                gr.Cells(dcColumnName.Name).Value = .Name
                gr.Cells(dcDataType.Name).Value = .DataType
                gr.Cells(dcSystemDataType.Name).Value = .SystemDataType.ToString().Replace("System.", "")
                gr.Cells(dcNullable.Name).Value = .IsNullable
                gr.Cells(dcDesc.Name).Value = .Name

                gr.Cells(dcCtrlName.Name).Value = .Name
                If .DataType = "bit" Then
                    gr.Cells(dcCtrlPrefix.Name).Value = "chk"
                    gr.Cells(dcCtrlValue.Name).Value = "Checked"
                    gr.Cells(dcWebControl.Name).Value = "asp:CheckBox"
                Else
                    gr.Cells(dcCtrlPrefix.Name).Value = "txt"
                    gr.Cells(dcCtrlValue.Name).Value = "Text"
                    gr.Cells(dcWebControl.Name).Value = ConfigurationSettings.AspxTextBoxName
                End If

                If .DataType.Contains("int") Then
                    If .IsNullable Then
                        gr.Cells(dcParseFunc.Name).Value = "CHK.StringConverter.ToIntegerNull"
                    Else
                        gr.Cells(dcParseFunc.Name).Value = If(lang = Language.CSharp, "int.Parse", "Integer.Parse")
                    End If
                    gr.Cells(dcDisplayFunc.Name).Value = "ToString()"
                ElseIf .DataType.Contains("decimal") Or .DataType.Contains("numeric") Then
                    If .IsNullable Then
                        gr.Cells(dcParseFunc.Name).Value = "CHK.StringConverter.ToDecimalNull"
                    Else
                        gr.Cells(dcParseFunc.Name).Value = If(lang = Language.CSharp, "decimal.Parse", "Decimal.Parse")
                    End If
                    gr.Cells(dcDisplayFunc.Name).Value = "ToString()"
                ElseIf .DataType.Contains("date") Then
                    If .IsNullable Then
                        gr.Cells(dcParseFunc.Name).Value = "CHK.StringConverter.ToDateTimeNull"
                    Else
                        gr.Cells(dcParseFunc.Name).Value = If(lang = Language.CSharp, "DateTime.Parse", "Date.Parse")
                    End If
                    gr.Cells(dcDisplayFunc.Name).Value = "ToShortDateString()"
                ElseIf .DataType = "bit" Then
                    gr.Cells(dcParseFunc.Name).Value = ""
                    gr.Cells(dcDisplayFunc.Name).Value = ""
                Else
                    gr.Cells(dcParseFunc.Name).Value = ""
                    gr.Cells(dcDisplayFunc.Name).Value = ""
                    gr.Cells(dcMaxLen.Name).Value = .ColumnSize
                End If

                If .IsAutoIncrement Or .Name = "CreatedUser" Or .Name = "CreatedDate" Or .Name = "ModifiedUser" Or .Name = "ModifiedDate" Or .Name = "ApproverdUser" Or .Name = "ApprovedDate" Then
                    gr.Cells(dcReadOnly.Name).Value = True
                Else
                    gr.Cells(dcReadOnly.Name).Value = False
                End If
            End With
        Next

        Decorate()
    End Sub
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

#End Region

#Region "Interfaces"
    Public Sub RefreshForm() Implements IFormRefresh.RefreshForm
        LoadTable()
    End Sub

    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub
#End Region


    Public Sub GenerateCode()
        Dim lang As Language = If(RadioButton1.Checked, Language.CSharp, Language.VB)
        txtBindData.Text = GenerateCode_BindData(lang)
        txtUnbindData.Text = GenerateCode_UnbindData(lang)
        txtGVEdit.Text = GenerateCode_GVUpdate(lang)
        txtGVInsert.Text = GenerateCode_GVInsert(lang)
        txtFormView.Text = GenerateCode_FormView()
        txtParameters.Text = GenerateCode_Parameters(lang)
    End Sub

    Public Function GenerateCode_BindData(ByVal lang As Language) As String
        Dim sb As New System.Text.StringBuilder()
        For n As Integer = 0 To dgResult.Rows.Count - 1
            With dgResult
                If .GetCellString(n, dcCtrlName.Index) = "" Then Continue For
                If .GetCellString(n, dcDisplayFunc.Index) = "" Then
                    If lang = Language.CSharp Then
                        sb.AppendLine(.GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & " = t." & .GetCellString(n, dcColumnName.Index) & ";")
                    Else
                        sb.AppendLine(.GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & " = t." & .GetCellString(n, dcColumnName.Index))
                    End If
                Else
                    If lang = Language.CSharp Then
                        sb.AppendLine(.GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & " = t." & .GetCellString(n, dcColumnName.Index) & "." & .GetCellString(n, dcDisplayFunc.Index) & ";")
                    Else
                        sb.AppendLine(.GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & " = t." & .GetCellString(n, dcColumnName.Index) & "." & .GetCellString(n, dcDisplayFunc.Index))
                    End If
                End If
            End With
        Next
        Return sb.ToString()
    End Function

    Public Function GenerateCode_UnbindData(ByVal lang As Language) As String
        Dim sb As New System.Text.StringBuilder()
        For n As Integer = 0 To dgResult.Rows.Count - 1
            With dgResult
                If .GetCellString(n, dcCtrlName.Index) = "" Or CBool(.Rows(n).Cells(dcReadOnly.Index).Value) = True Or CBool(.Rows(n).Cells(dcReadOnly.Index).Value) = True Then Continue For
                If .GetCellString(n, dcParseFunc.Index) = "" Then
                    If lang = Language.CSharp Then
                        sb.AppendLine("t." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & ";")
                    Else
                        sb.AppendLine("t." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index))
                    End If
                Else
                    If lang = Language.CSharp Then
                        sb.AppendLine("t." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcParseFunc.Index) & "(" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & ");")
                    Else
                        sb.AppendLine("t." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcParseFunc.Index) & "(" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & ")")
                    End If
                End If
            End With
        Next
        Return sb.ToString()
    End Function

    Public Function GenerateCode_GVInsert(ByVal lang As Language) As String
        Dim sb As New System.Text.StringBuilder()
        For n As Integer = 0 To dgResult.Rows.Count - 1
            With dgResult
                Dim ctlType As String = CHK.StringExtension.RSStr(.GetCellString(n, dcWebControl.Index), ":")
                If .GetCellString(n, dcCtrlName.Index) = "" Or CBool(.Rows(n).Cells(dcReadOnly.Index).Value) = True Then Continue For
                If lang = Language.CSharp Then
                    sb.AppendLine(ctlType & " " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & " = (TextBox) GV.FooterRow.FindControl(""" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "I"");")
                Else
                    sb.AppendLine("Dim " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & " As " & ctlType & " = CType(GV.FooterRow.FindControl(""" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "I""), " & ctlType & ")")
                End If
            End With
        Next
        sb.AppendLine()
        For n As Integer = 0 To dgResult.Rows.Count - 1
            With dgResult
                If .GetCellString(n, dcCtrlName.Index) = "" Or CBool(.Rows(n).Cells(dcReadOnly.Index).Value) = True Then Continue For
                If .GetCellString(n, dcDisplayFunc.Index) = "" Then
                    If lang = Language.CSharp Then
                        sb.AppendLine("d." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & ";")
                    Else
                        sb.AppendLine("d." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index))
                    End If
                Else
                    If lang = Language.CSharp Then
                        sb.AppendLine("d." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcParseFunc.Index) & "(" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & ");")
                    Else
                        sb.AppendLine("d." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcParseFunc.Index) & "(" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & ")")
                    End If
                End If
            End With
        Next

        Return sb.ToString()
    End Function

    Public Function GenerateCode_GVUpdate(ByVal lang As Language) As String
        Dim sb As New System.Text.StringBuilder()
        For n As Integer = 0 To dgResult.Rows.Count - 1
            With dgResult
                Dim ctlType As String = CHK.StringExtension.RSStr(.GetCellString(n, dcWebControl.Index), ":")
                If .GetCellString(n, dcCtrlName.Index) = "" Or .GetCellString(n, dcKey.Index) = "True" Or CBool(.Rows(n).Cells(dcReadOnly.Index).Value) = True Then Continue For
                If lang = Language.CSharp Then
                    sb.AppendLine(ctlType & " " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & " = (TextBox) GV.Rows[rowIndex].FindControl(""" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "E"");")
                Else
                    sb.AppendLine("Dim " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & " As " & ctlType & " = CType(GV.Rows(rowIndex).FindControl(""" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "E""), " & ctlType & ")")
                End If
            End With
        Next
        sb.AppendLine()
        For n As Integer = 0 To dgResult.Rows.Count - 1
            With dgResult
                If .GetCellString(n, dcCtrlName.Index) = "" Or .GetCellString(n, dcKey.Index) = "True" Or CBool(.Rows(n).Cells(dcReadOnly.Index).Value) = True Then Continue For
                If .GetCellString(n, dcDisplayFunc.Index) = "" Then
                    If lang = Language.CSharp Then
                        sb.AppendLine("d." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & ";")
                    Else
                        sb.AppendLine("d." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index))
                    End If
                Else
                    If lang = Language.CSharp Then
                        sb.AppendLine("d." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcParseFunc.Index) & "(" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & ");")
                    Else
                        sb.AppendLine("d." & .GetCellString(n, dcColumnName.Index) & " = " & .GetCellString(n, dcParseFunc.Index) & "(" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & "." & .GetCellString(n, dcCtrlValue.Index) & ")")
                    End If
                End If
            End With
        Next

        Return sb.ToString()
    End Function


    Public Function GenerateCode_FormView() As String
        Dim sb As New System.Text.StringBuilder()
        For n As Integer = 0 To dgResult.Rows.Count - 1
            With dgResult
                Dim maxLen As String = If(.GetCellString(n, dcMaxLen.Index) = "", "", " MaxLength=""" & .GetCellString(n, dcMaxLen.Index) & """")
                sb.AppendLine("<tr>")
                sb.AppendLine("<td><asp:Label ID=""lbl" & .GetCellString(n, dcColumnName.Index) & """ runat=""server"" Text=""" & .GetCellString(n, dcDesc.Index) & """></asp:Label></td>")
                sb.AppendLine("<td><" & .GetCellString(n, dcWebControl.Index) & " ID=""" & .GetCellString(n, dcCtrlPrefix.Index) & .GetCellString(n, dcCtrlName.Index) & """ runat=""server""" & maxLen & "></" & .GetCellString(n, dcWebControl.Index) & "></td>")
                sb.AppendLine("</tr>")
            End With
        Next

        Return sb.ToString()
    End Function

    Public Function GenerateCode_Parameters(ByVal lang As Language) As String
        Dim sb As New System.Text.StringBuilder()
        For n As Integer = 0 To dgResult.Rows.Count - 1
            With dgResult
                Dim colName As String = .GetCellString(n, dcColumnName.Index)
                If colName.Length > 0 Then colName = CHK.StringExtension.ReplaceRange(colName, Char.ToLower(colName.Chars(0)).ToString(), 0, 0)

                If lang = Language.CSharp Then
                    sb.AppendLine(.GetCellString(n, dcSystemDataType.Index) & " " & colName)
                Else
                    sb.AppendLine(colName & " As " & .GetCellString(n, dcSystemDataType.Index))
                End If
            End With
        Next

        Return sb.ToString()
    End Function


    Public Enum Language
        CSharp
        VB
    End Enum

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        LoadTable()
        GenerateCode()
    End Sub

    Private Sub frm_AspxGen_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ConfigurationSettings.DefaultLanguage = If(RadioButton1.Checked, Language.CSharp.ToString(), Language.VB.ToString())
    End Sub

    Private Sub txtBindData_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBindData.KeyDown, txtUnbindData.KeyDown, txtGVEdit.KeyDown, txtGVInsert.KeyDown, txtParameters.KeyDown, txtFormView.KeyDown
        Dim txt = CType(sender, TextBox)
        If e.Control = True And e.KeyCode = Keys.A Then
            txt.SelectAll()
        End If
    End Sub
End Class