<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Configuration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkShowConnectionWizardAtStartUp = New System.Windows.Forms.CheckBox()
        Me.txtDefaultDatabase = New System.Windows.Forms.TextBox()
        Me.ddConnectionString = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMaximumRecord = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkAutoResizeQueryResult = New System.Windows.Forms.CheckBox()
        Me.chkAutoFormatQuery = New System.Windows.Forms.CheckBox()
        Me.txtAuthorName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFont = New System.Windows.Forms.TextBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTableColumnDefaultWidth = New CHKControl.ExtendedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtColumnPanelWidth = New CHKControl.ExtendedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkColorizeTableData = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDummyColumns = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.txtMsManagementStudioPath = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtAspxTextBoxName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtFavoriteDatabases = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.txtWinMergePath = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkPrintSPParameter = New System.Windows.Forms.CheckBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtQueryResultExportPath = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Connection String"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkShowConnectionWizardAtStartUp)
        Me.GroupBox1.Controls.Add(Me.txtDefaultDatabase)
        Me.GroupBox1.Controls.Add(Me.ddConnectionString)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(780, 79)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection Information"
        '
        'chkShowConnectionWizardAtStartUp
        '
        Me.chkShowConnectionWizardAtStartUp.AutoSize = True
        Me.chkShowConnectionWizardAtStartUp.Location = New System.Drawing.Point(329, 44)
        Me.chkShowConnectionWizardAtStartUp.Name = "chkShowConnectionWizardAtStartUp"
        Me.chkShowConnectionWizardAtStartUp.Size = New System.Drawing.Size(203, 18)
        Me.chkShowConnectionWizardAtStartUp.TabIndex = 17
        Me.chkShowConnectionWizardAtStartUp.Text = "Show Connection Wizard at Start Up"
        Me.chkShowConnectionWizardAtStartUp.UseVisualStyleBackColor = True
        '
        'txtDefaultDatabase
        '
        Me.txtDefaultDatabase.Location = New System.Drawing.Point(141, 42)
        Me.txtDefaultDatabase.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDefaultDatabase.Name = "txtDefaultDatabase"
        Me.txtDefaultDatabase.Size = New System.Drawing.Size(156, 20)
        Me.txtDefaultDatabase.TabIndex = 4
        '
        'ddConnectionString
        '
        Me.ddConnectionString.FormattingEnabled = True
        Me.ddConnectionString.Location = New System.Drawing.Point(141, 13)
        Me.ddConnectionString.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ddConnectionString.Name = "ddConnectionString"
        Me.ddConnectionString.Size = New System.Drawing.Size(633, 22)
        Me.ddConnectionString.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Default Database"
        '
        'txtMaximumRecord
        '
        Me.txtMaximumRecord.Location = New System.Drawing.Point(141, 19)
        Me.txtMaximumRecord.Name = "txtMaximumRecord"
        Me.txtMaximumRecord.Size = New System.Drawing.Size(54, 20)
        Me.txtMaximumRecord.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Maximum Record Shown"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(652, 278)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 24)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(730, 278)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Font"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkAutoResizeQueryResult)
        Me.GroupBox2.Controls.Add(Me.chkAutoFormatQuery)
        Me.GroupBox2.Controls.Add(Me.txtAuthorName)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtFont)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(678, 102)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Query Editor"
        '
        'chkAutoResizeQueryResult
        '
        Me.chkAutoResizeQueryResult.AutoSize = True
        Me.chkAutoResizeQueryResult.Location = New System.Drawing.Point(107, 78)
        Me.chkAutoResizeQueryResult.Name = "chkAutoResizeQueryResult"
        Me.chkAutoResizeQueryResult.Size = New System.Drawing.Size(151, 18)
        Me.chkAutoResizeQueryResult.TabIndex = 12
        Me.chkAutoResizeQueryResult.Text = "Auto Resize Query Result"
        Me.chkAutoResizeQueryResult.UseVisualStyleBackColor = True
        '
        'chkAutoFormatQuery
        '
        Me.chkAutoFormatQuery.AutoSize = True
        Me.chkAutoFormatQuery.Location = New System.Drawing.Point(107, 59)
        Me.chkAutoFormatQuery.Name = "chkAutoFormatQuery"
        Me.chkAutoFormatQuery.Size = New System.Drawing.Size(122, 18)
        Me.chkAutoFormatQuery.TabIndex = 11
        Me.chkAutoFormatQuery.Text = "Auto Format Syntax"
        Me.chkAutoFormatQuery.UseVisualStyleBackColor = True
        '
        'txtAuthorName
        '
        Me.txtAuthorName.Location = New System.Drawing.Point(461, 13)
        Me.txtAuthorName.Name = "txtAuthorName"
        Me.txtAuthorName.Size = New System.Drawing.Size(211, 20)
        Me.txtAuthorName.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(364, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Author Name"
        '
        'txtFont
        '
        Me.txtFont.Location = New System.Drawing.Point(107, 13)
        Me.txtFont.Multiline = True
        Me.txtFont.Name = "txtFont"
        Me.txtFont.Size = New System.Drawing.Size(227, 40)
        Me.txtFont.TabIndex = 9
        '
        'FontDialog1
        '
        Me.FontDialog1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtTableColumnDefaultWidth)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtColumnPanelWidth)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.chkColorizeTableData)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtDummyColumns)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtMaximumRecord)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 108)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(780, 94)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Table Editor"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(548, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 14)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "px"
        '
        'txtTableColumnDefaultWidth
        '
        Me.txtTableColumnDefaultWidth.InputMode = CHKControl.ExtendedTextBox.InputModes.PositiveInteger
        Me.txtTableColumnDefaultWidth.Location = New System.Drawing.Point(500, 19)
        Me.txtTableColumnDefaultWidth.Name = "txtTableColumnDefaultWidth"
        Me.txtTableColumnDefaultWidth.Size = New System.Drawing.Size(48, 20)
        Me.txtTableColumnDefaultWidth.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(422, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 14)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Column Width"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(377, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 14)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "px"
        '
        'txtColumnPanelWidth
        '
        Me.txtColumnPanelWidth.InputMode = CHKControl.ExtendedTextBox.InputModes.PositiveInteger
        Me.txtColumnPanelWidth.Location = New System.Drawing.Point(329, 19)
        Me.txtColumnPanelWidth.Name = "txtColumnPanelWidth"
        Me.txtColumnPanelWidth.Size = New System.Drawing.Size(48, 20)
        Me.txtColumnPanelWidth.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(222, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 14)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Column Panel Width"
        '
        'chkColorizeTableData
        '
        Me.chkColorizeTableData.AutoSize = True
        Me.chkColorizeTableData.Location = New System.Drawing.Point(582, 21)
        Me.chkColorizeTableData.Name = "chkColorizeTableData"
        Me.chkColorizeTableData.Size = New System.Drawing.Size(90, 18)
        Me.chkColorizeTableData.TabIndex = 6
        Me.chkColorizeTableData.Text = "Colorize Data"
        Me.chkColorizeTableData.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(6, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(577, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "This field indicates which columns are default to be hidden in the editor. Sepera" &
    "ted each column names with comma (,)"
        '
        'txtDummyColumns
        '
        Me.txtDummyColumns.Location = New System.Drawing.Point(141, 42)
        Me.txtDummyColumns.Name = "txtDummyColumns"
        Me.txtDummyColumns.Size = New System.Drawing.Size(633, 20)
        Me.txtDummyColumns.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Dummy Columns"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblVersion.Location = New System.Drawing.Point(5, 283)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(44, 14)
        Me.lblVersion.TabIndex = 11
        Me.lblVersion.Text = "Version"
        '
        'txtMsManagementStudioPath
        '
        Me.txtMsManagementStudioPath.Location = New System.Drawing.Point(253, 6)
        Me.txtMsManagementStudioPath.Name = "txtMsManagementStudioPath"
        Me.txtMsManagementStudioPath.Size = New System.Drawing.Size(435, 20)
        Me.txtMsManagementStudioPath.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(233, 14)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Microsoft SQL Server Management Studio Path"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtAspxTextBoxName)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(678, 47)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = ".NET Class Generation"
        '
        'txtAspxTextBoxName
        '
        Me.txtAspxTextBoxName.Location = New System.Drawing.Point(141, 19)
        Me.txtAspxTextBoxName.Name = "txtAspxTextBoxName"
        Me.txtAspxTextBoxName.Size = New System.Drawing.Size(200, 20)
        Me.txtAspxTextBoxName.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 14)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "TextBox Name"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(800, 263)
        Me.TabControl1.TabIndex = 14
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(792, 236)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtQueryResultExportPath)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(792, 236)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SQL Query"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(792, 236)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = ".NET Generation"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(792, 236)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "My Favorite"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtFavoriteDatabases)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(363, 224)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Favorite Databases (seperated by line break)"
        '
        'txtFavoriteDatabases
        '
        Me.txtFavoriteDatabases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFavoriteDatabases.Location = New System.Drawing.Point(3, 16)
        Me.txtFavoriteDatabases.Multiline = True
        Me.txtFavoriteDatabases.Name = "txtFavoriteDatabases"
        Me.txtFavoriteDatabases.Size = New System.Drawing.Size(357, 205)
        Me.txtFavoriteDatabases.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.txtWinMergePath)
        Me.TabPage5.Controls.Add(Me.Label15)
        Me.TabPage5.Controls.Add(Me.chkPrintSPParameter)
        Me.TabPage5.Controls.Add(Me.txtMsManagementStudioPath)
        Me.TabPage5.Controls.Add(Me.Label8)
        Me.TabPage5.Location = New System.Drawing.Point(4, 23)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(792, 236)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Miscellaneous"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'txtWinMergePath
        '
        Me.txtWinMergePath.Location = New System.Drawing.Point(253, 54)
        Me.txtWinMergePath.Name = "txtWinMergePath"
        Me.txtWinMergePath.Size = New System.Drawing.Size(435, 20)
        Me.txtWinMergePath.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(203, 14)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "WinMerge Path (include WinMergeU.exe)"
        '
        'chkPrintSPParameter
        '
        Me.chkPrintSPParameter.AutoSize = True
        Me.chkPrintSPParameter.Location = New System.Drawing.Point(253, 30)
        Me.chkPrintSPParameter.Name = "chkPrintSPParameter"
        Me.chkPrintSPParameter.Size = New System.Drawing.Size(201, 18)
        Me.chkPrintSPParameter.TabIndex = 6
        Me.chkPrintSPParameter.Text = "Show Stored Procedure Parameters"
        Me.chkPrintSPParameter.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(574, 278)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 24)
        Me.btnReset.TabIndex = 15
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(157, 283)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(335, 14)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Some options require restarting the program in order to be effective."
        '
        'txtQueryResultExportPath
        '
        Me.txtQueryResultExportPath.Location = New System.Drawing.Point(113, 114)
        Me.txtQueryResultExportPath.Name = "txtQueryResultExportPath"
        Me.txtQueryResultExportPath.Size = New System.Drawing.Size(227, 20)
        Me.txtQueryResultExportPath.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 117)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 14)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Csv Export Path"
        '
        'frm_Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 306)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_Configuration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuration"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ddConnectionString As System.Windows.Forms.ComboBox
    Friend WithEvents txtDefaultDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtMaximumRecord As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFont As System.Windows.Forms.TextBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDummyColumns As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAuthorName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents chkColorizeTableData As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMsManagementStudioPath As System.Windows.Forms.TextBox
    Friend WithEvents chkAutoFormatQuery As System.Windows.Forms.CheckBox
    Friend WithEvents txtColumnPanelWidth As CHKControl.ExtendedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAspxTextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkAutoResizeQueryResult As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTableColumnDefaultWidth As CHKControl.ExtendedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents chkPrintSPParameter As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFavoriteDatabases As System.Windows.Forms.TextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkShowConnectionWizardAtStartUp As System.Windows.Forms.CheckBox
    Friend WithEvents txtWinMergePath As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtQueryResultExportPath As TextBox
    Friend WithEvents Label16 As Label
End Class
