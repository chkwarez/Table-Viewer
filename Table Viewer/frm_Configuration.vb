Imports Microsoft.Win32

Public Class frm_Configuration
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

    Private Sub frm_Configuration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadOption()
        lblVersion.Text = "Version: " & My.Application.Info.Version.ToString()
    End Sub

#Region "Button Events"
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveOption()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        LoadOption()
    End Sub
#End Region

#Region "Options"
    Private Sub LoadOption()
        txtDefaultDatabase.Text = ConfigurationSettings.DefaultDatabase
        SetDefaultConnectionString()
        chkPrintSPParameter.Checked = ConfigurationSettings.PrintStoredProcedureParameterFlag
        txtMaximumRecord.Text = ConfigurationSettings.MaximumRecordShown
        txtDummyColumns.Text = ConfigurationSettings.DummyColumns
        txtColumnPanelWidth.Text = ConfigurationSettings.ColumnPanelWidth.ToString()
        txtTableColumnDefaultWidth.Text = ConfigurationSettings.TableColumnDefaultWidth.ToString()
        FontDialog1.Font = New Font(ConfigurationSettings.QueryFontFamily, ConfigurationSettings.QueryFontSize, FontStyle.Regular, GraphicsUnit.Point, 0)
        UpdateFontResult()
        txtAuthorName.Text = ConfigurationSettings.AuthorName
        chkColorizeTableData.Checked = ConfigurationSettings.ColorizeTableData
        txtMsManagementStudioPath.Text = ConfigurationSettings.MsManagementStudioPath
        txtWinMergePath.Text = ConfigurationSettings.WinMergePath
        chkAutoFormatQuery.Checked = ConfigurationSettings.AutoFormatQuery
        chkAutoResizeQueryResult.Checked = ConfigurationSettings.AutoResizeQueryResult
        txtAspxTextBoxName.Text = ConfigurationSettings.AspxTextBoxName
        txtFavoriteDatabases.Text = ConfigurationSettings.FavoriteDatabases
        chkShowConnectionWizardAtStartUp.Checked = ConfigurationSettings.ShowConnectionWizardAtStartUp
        txtQueryResultExportPath.Text = ConfigurationSettings.QueryResultExportPath
    End Sub

    Private Sub SaveOption()
        ConfigurationSettings.DefaultConnectionString = ddConnectionString.Text
        ConfigurationSettings.DefaultDatabase = txtDefaultDatabase.Text
        ConfigurationSettings.PrintStoredProcedureParameterFlag = chkPrintSPParameter.Checked
        ConfigurationSettings.MaximumRecordShown = txtMaximumRecord.Text
        ConfigurationSettings.QueryFontFamily = FontDialog1.Font.FontFamily.Name
        ConfigurationSettings.QueryFontSize = FontDialog1.Font.Size
        ConfigurationSettings.DummyColumns = txtDummyColumns.Text
        ConfigurationSettings.ColumnPanelWidth = Integer.Parse(txtColumnPanelWidth.Text)
        ConfigurationSettings.TableColumnDefaultWidth = Integer.Parse(txtTableColumnDefaultWidth.Text)
        ConfigurationSettings.AuthorName = txtAuthorName.Text
        ConfigurationSettings.ColorizeTableData = chkColorizeTableData.Checked
        ConfigurationSettings.MsManagementStudioPath = txtMsManagementStudioPath.Text
        ConfigurationSettings.WinMergePath = txtWinMergePath.Text
        ConfigurationSettings.AutoFormatQuery = chkAutoFormatQuery.Checked
        ConfigurationSettings.AutoResizeQueryResult = chkAutoResizeQueryResult.Checked
        ConfigurationSettings.AspxTextBoxName = txtAspxTextBoxName.Text
        ConfigurationSettings.FavoriteDatabases = txtFavoriteDatabases.Text
        ConfigurationSettings.ShowConnectionWizardAtStartUp = chkShowConnectionWizardAtStartUp.Checked
        ConfigurationSettings.QueryResultExportPath = txtQueryResultExportPath.Text
    End Sub
#End Region

    Public Sub SetDefaultConnectionString()
        Dim allConnStrs() As String

        allConnStrs = ConfigurationSettings.GetAllConnectionStringHistory()
        If Not allConnStrs Is Nothing Then 'Has History
            ddConnectionString.Items.Clear()
            For n As Integer = 0 To allConnStrs.Length - 1
                If allConnStrs(n).Trim() = "" Then Continue For
                ddConnectionString.Items.Add(allConnStrs(n))
            Next
        End If

        ddConnectionString.Text = ConfigurationSettings.DefaultConnectionString
    End Sub

    Private Sub txtFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFont.Click
        FontDialog1.ShowDialog()
        UpdateFontResult()
    End Sub

    Private Sub UpdateFontResult()
        With FontDialog1.Font
            txtFont.Text = "Font Family: " & .FontFamily.Name & vbCrLf & "Font Size: " & .Size.ToString
        End With
    End Sub


End Class