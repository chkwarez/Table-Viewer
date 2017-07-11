Imports System.Data.SqlClient

Public Class frm_ASPSyn : Implements IFormRefresh, IFormClose
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property
    Public Table As Smart.SqlTable

#Region "Form Events"
    Private Sub frm_ASPSyn_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub

    Private Sub frm_ASPSyn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Table IsNot Nothing Then
            LoadASP()
            LoadTableColumns()
            LoadBLLVariables()
            txtBLLTemplatePath.Text = ConfigurationLogic.BLLTemplatePath
        End If
    End Sub
#End Region

#Region "Button and Other Controls Events"
    Private Sub btnScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScript.Click
        PrintCode(GenerateScript(1), False)
    End Sub

    Private Sub btnScript2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScript2.Click
        PrintCode(GenerateScript(2), False)
    End Sub

    Private Sub btnScript4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScript4.Click
        PrintCode(GenerateScript(4), True)
    End Sub

    Private Sub btnScript5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScript5.Click
        PrintCode(GenerateScript(5), True)
    End Sub

    Private Sub radVB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radVB.Click, radCSharp.Click
        LoadBLLVariables()
    End Sub
#End Region

#Region "Tab Events [BLL]"
    Private Sub chkAutoSize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoSize.CheckedChanged
        dgBLL.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgBLL.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        cmdgOpen.InitialDirectory = txtBLLTemplatePath.Text
        Dim rtvl As DialogResult = cmdgOpen.ShowDialog()
        If rtvl = Windows.Forms.DialogResult.Cancel Then Exit Sub
        txtBLLTemplatePath.Text = cmdgOpen.FileName
    End Sub

    Private Sub btnGenerateBLL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateBLL.Click
        GenerateBLL()
    End Sub
#End Region

#Region "Data Grid View Events"
    Private Sub dgResult_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgASP.CellEndEdit
        AutoComplete()
        Decorate(e.RowIndex)
    End Sub
#End Region

#Region "Script Generation"
    Public Function GenerateScript(ByVal mode As Integer) As String
        Dim n As Integer, tmp As String = "", isFirst As Boolean
        Dim columnName As String, columnDataType As String, controlPrefix As String, controlID As String, controlType As String, controlText As String, controlAttribute As String
        Dim code As New System.Text.StringBuilder()
        Dim seperator As String

        'Pre Generation
        Select Case mode
            Case 1
                seperator = vbCrLf
                code.AppendLine("<table>")
            Case 2, 4
                seperator = vbCrLf
            Case 5
                seperator = vbCrLf
                code.AppendLine("<asp:GridView ID=""GridView1"" runat=""server"" AutoGenerateColumns=""False"">")
                code.AppendLine("<Columns>")
            Case Else
                seperator = ""
        End Select

        'Body Generation
        isFirst = True
        For n = 0 To dgASP.Rows.Count - 1
            With dgASP.Rows(n)
                columnName = GetString(.Cells(dcColumnName.Name).Value)
                columnDataType = GetString(.Cells(dcSystemDataType.Name).Value)
                controlType = GetString(.Cells(dcControlType.Name).Value)
                controlPrefix = GetString(.Cells(dcControlPrefix.Name).Value)
                controlID = GetString(.Cells(dcControlID.Name).Value)
                controlAttribute = GetString(.Cells(dcControlAttribute.Name).Value)
                controlText = GetString(.Cells(dcControlDesc.Name).Value)

                'Obtain Variables
                Select Case mode
                    Case 1
                        tmp = Script1(controlPrefix, controlID, controlAttribute, controlType, controlText)
                    Case 2
                        tmp = Script2(columnName, columnDataType, controlPrefix, controlID, controlAttribute)
                    Case 4
                        tmp = Script4(columnName, columnDataType, controlPrefix, controlID, controlAttribute)
                    Case 5
                        tmp = Script5(columnName, columnDataType, controlPrefix, controlID, controlAttribute, controlText)
                    Case Else
                        tmp = ""
                End Select

                If tmp = "" Then Continue For 'Skip empty item

                If isFirst = True Then
                    code.Append(tmp)
                    isFirst = False
                Else
                    code.Append(seperator & tmp)
                End If
            End With
        Next

        'Post Generation
        Select Case mode
            Case 1
                code.AppendLine(seperator & "</table>")
            Case 2
            Case 4
            Case 5
                code.AppendLine(seperator & "</Columns>")
                code.AppendLine("</asp:GridView>")
        End Select

        Return code.ToString()
    End Function

    Private Function Script1(ByVal controlPrefix As String, ByVal controlID As String, ByVal controlAttribute As String, ByVal controlType As String, ByVal controlText As String) As String
        If controlID = "" Or controlType = "" Then Return ""

        Dim tmp As String
        tmp = "<tr>"
        If controlText = "" Then 'No Label
            tmp &= vbCrLf & "<td></td>"
        Else
            tmp &= vbCrLf & "<td><asp:Label ID=""lbl" & controlID & """ Text=""" & controlText & """ runat=""server"" /></td>"
        End If
        tmp &= vbCrLf & "<td><" & controlType & " ID=""" & controlPrefix & controlID & """ runat=""server"" /></td>"
        tmp &= vbCrLf & "</tr>"
        Return tmp
    End Function

    Private Function Script2(ByVal columnName As String, ByVal columnDataType As String, ByVal controlPrefix As String, ByVal controlID As String, ByVal controlAttribute As String) As String
        If controlID = "" Then Return ""
        Return controlPrefix & controlID & "." & controlAttribute & " = iRow[""" & columnName & """].ToString();"
    End Function

    Public Function Script4(ByVal columnName As String, ByVal columnDataType As String, ByVal controlPrefix As String, ByVal controlID As String, ByVal controlAttribute As String) As String
        If controlID = "" Then Return ""
        Return "e.InputParameters[""" & columnName & """] = " & controlPrefix & controlID & "." & controlAttribute & ";"
    End Function

    Public Function Script5(ByVal columnName As String, ByVal columnDataType As String, ByVal controlPrefix As String, ByVal controlID As String, ByVal controlAttribute As String, ByVal controlText As String) As String
        If controlID = "" Then Return ""
        Dim tmp As String

        tmp = "<asp:TemplateField HeaderText=""" & controlText & """ SortExpression=""" & columnName & """>"
        tmp &= vbCrLf & "<ItemTemplate>"
        tmp &= vbCrLf & "<asp:Label ID=""lbl" & controlID & "V"" runat=""server"" Text='<%# Eval(""" & columnName & """) %>'></asp:Label>"
        tmp &= vbCrLf & "</ItemTemplate>"
        tmp &= vbCrLf & "</asp:TemplateField>"

        Return tmp
    End Function
#End Region

#Region "Presentation"
    Protected Sub Decorate(Optional ByVal specificIndex As Integer = -1)
        'Dim n As Integer, dataType As String, isKey As Boolean

        'If specificIndex = -1 Then
        '    For n = 0 To dgResult.Rows.Count - 2
        '        If dgResult.Rows(n).Cells("dcDataType").Value Is Nothing Then
        '            dataType = ""
        '        Else
        '            dataType = dgResult.Rows(n).Cells("dcDataType").Value.ToString()
        '        End If
        '        dgResult.Rows(n).Cells("dcDataType").Style.ForeColor = GetDataTypeColor(dataType)

        '        isKey = CType(dgResult.Rows(n).Cells("dcKey").FormattedValue, Boolean)
        '        dgResult.Rows(n).DefaultCellStyle.BackColor = CType(IIf(isKey = True, Color.LightYellow, Color.White), Color)
        '    Next
        'Else
        '    n = specificIndex
        '    If dgResult.Rows(n).Cells("dcDataType").Value Is Nothing Then
        '        dataType = ""
        '    Else
        '        dataType = dgResult.Rows(n).Cells("dcDataType").Value.ToString()
        '    End If
        '    dgResult.Rows(n).Cells("dcDataType").Style.ForeColor = GetDataTypeColor(dataType)

        '    isKey = CType(dgResult.Rows(n).Cells("dcKey").FormattedValue, Boolean)
        '    dgResult.Rows(n).DefaultCellStyle.BackColor = CType(IIf(isKey = True, Color.LightYellow, Color.White), Color)
        'End If
    End Sub

    Protected Sub AutoComplete()
        Dim n As Integer
        'Control Type and ID auto fill
        For n = 0 To dgASP.Rows.Count - 1
            With dgASP.Rows(n)
                If Not GetString(.Cells(dcControlID.Name).Value) = "" AndAlso GetString(.Cells(dcControlAttribute.Name).Value) = "" Then 'No Attribute but Control ID is present
                    .Cells(dcControlAttribute.Name).Value = "Text"
                End If

                If GetString(.Cells(dcControlType.Name).Value) = "" Then 'Control Type is not filled
                    Select Case GetString(.Cells(dcDataType.Name).Value)
                        Case "nvarchar(1)"
                            .Cells(dcControlType.Name).Value = "asp:DropDownList"
                        Case Else
                            .Cells(dcControlType.Name).Value = "asp:TextBox"
                    End Select
                End If

                If Not GetString(.Cells(dcControlDesc.Name).Value) = "" AndAlso GetString(.Cells(dcControlID.Name).Value) = "" Then 'No Control ID but Control Text is present
                    .Cells(dcControlID.Name).Value = .Cells(dcControlDesc.Name).Value.ToString().Replace(" ", "")
                End If

                If Not GetString(.Cells(dcControlType.Name).Value) = "" Then
                    Dim prefix As String = "", valueAttributeName As String = ""
                    GetControlProperty(GetString(.Cells(dcControlType.Name).Value), prefix, valueAttributeName)
                    .Cells(dcControlPrefix.Name).Value = prefix
                    .Cells(dcControlAttribute.Name).Value = valueAttributeName
                End If
            End With
        Next
    End Sub

    Private Sub PrintCode(ByVal code As String, ByVal wordWrap As Boolean)
        txtCode.Text = code
        txtCode.WordWrap = wordWrap
        TabControl1.SelectTab(tabCode)
    End Sub
#End Region

#Region "Common"
    Public Sub LoadTableColumns()
        Dim dtTable As DataTable
        Dim n As Integer

        dtTable = Table.GetTableSchema()

        'Remove Dummy Columns
        Dim dummyColumns As String() = ConfigurationLogic.DummyColumns.Split(","c)
        For n = dtTable.Rows.Count - 1 To 0 Step -1
            If Array.IndexOf(dummyColumns, dtTable.Rows(n)("ColumnName").ToString()) >= 0 Then dtTable.Rows.RemoveAt(n)
        Next

        dgGeneral.Rows.Clear()
        dgGeneral.Rows.Add(dtTable.Rows.Count) 'Add all rows first
        For n = 0 To dtTable.Rows.Count - 1
            With dgGeneral.Rows(n)
                .Cells(dcGeneralColumnName.Name).Value = dtTable.Rows(n)("ColumnName").ToString()
                .Cells(dcGeneralDataType.Name).Value = dtTable.Rows(n)("DataTypePrint").ToString()
                .Cells(dcGeneralSystemDataType.Name).Value = GetAbstractDataType(dtTable.Rows(n)("DataType").ToString())
            End With
        Next

        txtTableName.Text = Table.FullName
    End Sub
#End Region

#Region "ASP Generation"
    Public Sub LoadASP()
        Dim dtTable As DataTable
        Dim n As Integer

        dtTable = Table.GetTableSchema()

        'Remove Dummy Columns
        Dim dummyColumns As String() = ConfigurationLogic.DummyColumns.Split(","c)
        For n = dtTable.Rows.Count - 1 To 0 Step -1
            If Array.IndexOf(dummyColumns, dtTable.Rows(n)("ColumnName").ToString()) >= 0 Then dtTable.Rows.RemoveAt(n)
        Next

        dgASP.Rows.Clear()
        dgASP.Rows.Add(dtTable.Rows.Count) 'Add all rows first
        For n = 0 To dtTable.Rows.Count - 1
            With dgASP.Rows(n)
                .Cells(dcColumnName.Name).Value = dtTable.Rows(n)("ColumnName").ToString()
                .Cells(dcDataType.Name).Value = dtTable.Rows(n)("DataTypePrint").ToString()
                .Cells(dcSystemDataType.Name).Value = GetAbstractDataType(dtTable.Rows(n)("DataType").ToString())
            End With
        Next

        txtTableName.Text = Table.FullName

        AutoComplete()
        Decorate()
    End Sub
#End Region

#Region "BLL Generation"
    Public Sub LoadBLLVariables()
        Dim pks As Smart.SqlColumn() = Table.GetColumns(Smart.SqlTable.ColumnType.PrimaryKeys)
        Dim cols As Smart.SqlColumn() = Table.GetColumns(Smart.SqlTable.ColumnType.NonPrimaryKeys)
        Dim n As Integer
        Dim tmp As String
        Dim r As DataGridViewRow

        'Remove Dummy Columns
        Dim dummyColumns As String() = ConfigurationLogic.DummyColumns.Split(","c)
        Dim tmpList As New System.Collections.Generic.List(Of Table_Viewer.Smart.SqlTable.ColumnNameDataTypePair)
        tmpList.AddRange(cols)
        For n = tmpList.Count - 1 To 0 Step -1
            If Array.IndexOf(dummyColumns, tmpList(n).Name) >= 0 Then tmpList.RemoveAt(n)
        Next
        cols = tmpList.ToArray()

        dgBLL.Rows.Clear()

        'Variable 0 [Keyword]
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV0%"
        r.Cells("dcBLLDesc").Value = "Keyword"
        r.Cells("dcBLLValue").Value = "" 'User Input

        'Variable 1 [BLL Name]
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV1%"
        r.Cells("dcBLLDesc").Value = "BLL Name"
        r.Cells("dcBLLValue").Value = "" 'User Input

        'Variable 2 [DataSet Name]
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV2%"
        r.Cells("dcBLLDesc").Value = "DataSet Name"
        r.Cells("dcBLLValue").Value = "" 'User Input

        'Variable 3 [DataTable Prefix]
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV3%"
        r.Cells("dcBLLDesc").Value = "DataTable Prefix"
        r.Cells("dcBLLValue").Value = "" 'User Input

        'Variable 4 [Primary Keys Definition]
        tmp = ""
        If radCSharp.Checked Then
            For n = 0 To pks.Length - 1
                If n = 0 Then
                    tmp = GetAbstractDataType(pks(n).SystemDataType) & " " & pks(n).Name
                Else
                    tmp &= ", " & GetAbstractDataType(pks(n).SystemDataType) & " " & pks(n).Name
                End If
            Next
        ElseIf radVB.Checked Then
            For n = 0 To pks.Length - 1
                If n = 0 Then
                    tmp = pks(n).Name & " As " & GetAbstractDataType(pks(n).SystemDataType)
                Else
                    tmp &= ", " & pks(n).Name & " As " & GetAbstractDataType(pks(n).SystemDataType)
                End If
            Next
        End If
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV4%"
        r.Cells("dcBLLDesc").Value = "Primary Keys Definition"
        r.Cells("dcBLLValue").Value = tmp

        'Variable 5 [Primary Keys Parameters]
        tmp = ""
        For n = 0 To pks.Length - 1
            If n = 0 Then
                tmp = pks(n).Name
            Else
                tmp &= ", " & pks(n).Name
            End If
        Next
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV5%"
        r.Cells("dcBLLDesc").Value = "Primary Keys Parameters"
        r.Cells("dcBLLValue").Value = tmp

        'Variable 6 [Columns Definition]
        tmp = ""
        If radCSharp.Checked Then
            For n = 0 To pks.Length - 1
                If n = 0 Then
                    tmp = GetAbstractDataType(pks(n).SystemDataType) & " " & pks(n).Name
                Else
                    tmp &= ", " & GetAbstractDataType(pks(n).SystemDataType) & " " & pks(n).Name
                End If
            Next
            For n = 0 To cols.Length - 1
                If n = 0 And pks.Length = 0 Then 'Is First Column (No Primary Key)
                    tmp = GetAbstractDataType(cols(n).SystemDataType) & " " & cols(n).Name
                Else
                    tmp &= ", " & GetAbstractDataType(cols(n).SystemDataType) & " " & cols(n).Name
                End If
            Next
        ElseIf radVB.Checked Then
            For n = 0 To pks.Length - 1
                If n = 0 Then
                    tmp = pks(n).Name & " As " & GetAbstractDataType(pks(n).SystemDataType)
                Else
                    tmp &= ", " & pks(n).Name & " As " & GetAbstractDataType(pks(n).SystemDataType)
                End If
            Next
            For n = 0 To cols.Length - 1
                If n = 0 And pks.Length = 0 Then 'Is First Column (No Primary Key)
                    tmp = cols(n).Name & " As " & GetAbstractDataType(cols(n).SystemDataType)
                Else
                    tmp &= ", " & cols(n).Name & " As " & GetAbstractDataType(cols(n).SystemDataType)
                End If
            Next
        End If
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV6%"
        r.Cells("dcBLLDesc").Value = "Columns Definition"
        r.Cells("dcBLLValue").Value = tmp

        'Variable 7 [Columns Parameters]
        tmp = ""
        For n = 0 To pks.Length - 1
            If n = 0 Then
                tmp = pks(n).Name
            Else
                tmp &= ", " & pks(n).Name
            End If
        Next
        For n = 0 To cols.Length - 1
            If n = 0 And pks.Length = 0 Then 'Is First Column (No Primary Key)
                tmp = cols(n).Name
            Else
                tmp &= ", " & cols(n).Name
            End If
        Next
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV7%"
        r.Cells("dcBLLDesc").Value = "Columns Parameters"
        r.Cells("dcBLLValue").Value = tmp

        'Variable 8 [Key Entries]
        tmp = ""
        For n = 0 To pks.Length - 1
            If n = 0 Then
                tmp = "iRow." & pks(n).Name & " = " & pks(n).Name & ";"
            Else
                tmp &= vbCrLf & "iRow." & pks(n).Name & " = " & pks(n).Name & ";"
            End If
        Next
        If radVB.Checked Then tmp = tmp.Replace(";", "")
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV8%"
        r.Cells("dcBLLDesc").Value = "Key Entries"
        r.Cells("dcBLLValue").Value = tmp

        'Variable 9 [Non-Key Entries]
        tmp = ""
        For n = 0 To cols.Length - 1
            If n = 0 Then
                tmp = "iRow." & cols(n).Name & " = " & cols(n).Name & ";"
            Else
                tmp &= vbCrLf & "iRow." & cols(n).Name & " = " & cols(n).Name & ";"
            End If
        Next
        If radVB.Checked Then tmp = tmp.Replace(";", "")
        dgBLL.Rows.Add()
        r = dgBLL.Rows(dgBLL.RowCount - 1)
        r.Cells("dcBLLVariable").Value = "%TV9%"
        r.Cells("dcBLLDesc").Value = "Non-Key Entries"
        r.Cells("dcBLLValue").Value = tmp

    End Sub

    Private Sub GenerateBLL()
        Dim n As Integer
        Dim variable As String, value As String

        'Load Template
        If System.IO.File.Exists(txtBLLTemplatePath.Text) = False Then Exit Sub
        Dim template As String
        template = System.IO.File.ReadAllText(txtBLLTemplatePath.Text)

        For n = 0 To dgBLL.RowCount - 1
            variable = dgBLL.Rows(n).Cells("dcBLLVariable").Value.ToString()
            value = dgBLL.Rows(n).Cells("dcBLLValue").Value.ToString()

            template = template.Replace(variable, value)
        Next

        ConfigurationLogic.BLLTemplatePath = txtBLLTemplatePath.Text
        PrintCode(template, True)
    End Sub
#End Region

#Region "Miscellaneous Functions"
    Private Function GetString(ByVal b As Object) As String
        If b Is Nothing Then
            Return ""
        Else
            Return b.ToString()
        End If
    End Function

    Private Function GetAbstractDataType(ByVal t As Type) As String
        If radCSharp.Checked Then
            Select Case t.Name
                Case "System.String", "System.Decimal", "System.Double"
                    Return t.Name.Replace("System.", "").ToLower()
                Case "System.Int16", "System.Int32"
                    Return "int"
                Case Else
                    Return t.Name.Replace("System.", "")
            End Select
        ElseIf radVB.Checked Then
            Select Case t.Name
                Case "System.String", "System.Decimal", "System.Double"
                    Return t.Name.Replace("System.", "")
                Case "System.Int16", "System.Int32"
                    Return "Integer"
                Case Else
                    Return t.Name.Replace("System.", "")
            End Select
        Else
            Throw New ApplicationException("Please choose the programming language")
        End If
    End Function

    Private Sub GetControlProperty(ByVal controlName As String, ByRef prefix As String, ByRef valueAttributeName As String)
        controlName = controlName.ToLower()
        'Source: http://www.visualize.uk.com/resources/asp-net-standards.asp
        'Slightly modified

        If controlName.Contains("label") Then
            prefix = "lbl"
            valueAttributeName = "Text"
        ElseIf controlName.Contains("textbox") Then
            prefix = "txt"
            valueAttributeName = "Text"
        ElseIf controlName.Contains("datagrid") Then
            prefix = "dg"
        ElseIf controlName.Contains("gridview") Then
            prefix = "gv"
        ElseIf controlName.Contains("imagebutton") Then
            prefix = "ibtn"
            valueAttributeName = "Text"
        ElseIf controlName.Contains("button") Then
            prefix = "btn"
            valueAttributeName = "Text"
        ElseIf controlName.Contains("hyperlink") Then
            prefix = "lnk"
            valueAttributeName = "Text"
        ElseIf controlName.Contains("dropdownlist") Then
            prefix = "dd"
            valueAttributeName = "SelectedValue"
        ElseIf controlName.Contains("listbox") Then
            prefix = "list"
        ElseIf controlName.Contains("datalist") Then
            prefix = "dlst"
        ElseIf controlName.Contains("checkbox") Then
            prefix = "chk"
            valueAttributeName = "Checked"
        ElseIf controlName.Contains("radiobutton") Then
            prefix = "rad"
            valueAttributeName = "SelectedValue"
        ElseIf controlName.Contains("image") Then
            prefix = "img"
        ElseIf controlName.Contains("panel") Then
            prefix = "panel"
        ElseIf controlName.Contains("calender") Then
            prefix = "cal"
        ElseIf controlName.Contains("table") Then
            prefix = "tbl"
        Else
            prefix = ""
        End If

    End Sub
#End Region

#Region "Interfaces"
    Public Sub RefreshForm() Implements IFormRefresh.RefreshForm
        LoadASP()
    End Sub

    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub
#End Region







End Class
