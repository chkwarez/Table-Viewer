<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SP
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SP))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgResult = New CHKControl.GridView.SmartDataGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSchema = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkSearchModifiedDate = New System.Windows.Forms.CheckBox()
        Me.txtSearchModifiedDateE = New CHKControl.ExtendedDateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearchModifiedDateS = New CHKControl.ExtendedDateTimePicker()
        Me.ddSearchCode = New CHKControl.ExtendedComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ddSearchName = New CHKControl.ExtendedComboBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.radSelectTF = New System.Windows.Forms.RadioButton()
        Me.radSelectFN = New System.Windows.Forms.RadioButton()
        Me.radSelectSP = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ddDatabase = New System.Windows.Forms.ToolStripComboBox()
        Me.btnSetCurrentDatabase = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.btnRename = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnCopyAndUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCopyAndCreate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ddTargetDatabase = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnVerifySyntax = New System.Windows.Forms.ToolStripButton()
        Me.btnExport = New System.Windows.Forms.ToolStripSplitButton()
        Me.CreateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CraeteToFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterToFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManagementStudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpenAll = New System.Windows.Forms.ToolStripButton()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnFindColumn = New System.Windows.Forms.Button()
        Me.txtDataType = New System.Windows.Forms.TextBox()
        Me.txtColumnName = New System.Windows.Forms.TextBox()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdgSave = New System.Windows.Forms.SaveFileDialog()
        Me.dgcSPSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcSPName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgcExecute = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgcShowDependencies = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgcSPLastUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcSPParameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcSPStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgResult)
        Me.GroupBox1.Location = New System.Drawing.Point(226, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(690, 525)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Result"
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToDeleteRows = False
        Me.dgResult.AllowUserToResizeRows = False
        Me.dgResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcSPSelect, Me.dgcSPName, Me.dgcEdit, Me.dgcExecute, Me.dgcShowDependencies, Me.dgcSPLastUpdate, Me.dgcSPParameter, Me.dgcSPStatus})
        Me.dgResult.Location = New System.Drawing.Point(6, 19)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.RowHeadersVisible = False
        Me.dgResult.RowTemplate.Height = 24
        Me.dgResult.Size = New System.Drawing.Size(678, 500)
        Me.dgResult.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSchema)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.chkSearchModifiedDate)
        Me.GroupBox2.Controls.Add(Me.txtSearchModifiedDateE)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSearchModifiedDateS)
        Me.GroupBox2.Controls.Add(Me.ddSearchCode)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ddSearchName)
        Me.GroupBox2.Controls.Add(Me.btnFind)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(213, 212)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "General Search"
        '
        'txtSchema
        '
        Me.txtSchema.Location = New System.Drawing.Point(54, 70)
        Me.txtSchema.Name = "txtSchema"
        Me.txtSchema.Size = New System.Drawing.Size(100, 23)
        Me.txtSchema.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Schema"
        '
        'chkSearchModifiedDate
        '
        Me.chkSearchModifiedDate.AutoSize = True
        Me.chkSearchModifiedDate.Location = New System.Drawing.Point(5, 101)
        Me.chkSearchModifiedDate.Name = "chkSearchModifiedDate"
        Me.chkSearchModifiedDate.Size = New System.Drawing.Size(155, 20)
        Me.chkSearchModifiedDate.TabIndex = 4
        Me.chkSearchModifiedDate.Text = "Date of Modification"
        Me.chkSearchModifiedDate.UseVisualStyleBackColor = True
        '
        'txtSearchModifiedDateE
        '
        Me.txtSearchModifiedDateE.Enabled = False
        Me.txtSearchModifiedDateE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtSearchModifiedDateE.Location = New System.Drawing.Point(110, 120)
        Me.txtSearchModifiedDateE.Name = "txtSearchModifiedDateE"
        Me.txtSearchModifiedDateE.Size = New System.Drawing.Size(97, 23)
        Me.txtSearchModifiedDateE.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(2, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(201, 33)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Use % to explicityly indicate starts with or ends with"
        '
        'txtSearchModifiedDateS
        '
        Me.txtSearchModifiedDateS.Enabled = False
        Me.txtSearchModifiedDateS.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtSearchModifiedDateS.Location = New System.Drawing.Point(5, 120)
        Me.txtSearchModifiedDateS.Name = "txtSearchModifiedDateS"
        Me.txtSearchModifiedDateS.Size = New System.Drawing.Size(95, 23)
        Me.txtSearchModifiedDateS.TabIndex = 5
        '
        'ddSearchCode
        '
        Me.ddSearchCode.EnableHistory = True
        Me.ddSearchCode.FormattingEnabled = True
        Me.ddSearchCode.Location = New System.Drawing.Point(54, 44)
        Me.ddSearchCode.LossenValue = ""
        Me.ddSearchCode.Name = "ddSearchCode"
        Me.ddSearchCode.Size = New System.Drawing.Size(153, 24)
        Me.ddSearchCode.TabIndex = 2
        Me.ddSearchCode.Value = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Name"
        '
        'ddSearchName
        '
        Me.ddSearchName.EnableHistory = True
        Me.ddSearchName.FormattingEnabled = True
        Me.ddSearchName.Location = New System.Drawing.Point(54, 19)
        Me.ddSearchName.LossenValue = ""
        Me.ddSearchName.Name = "ddSearchName"
        Me.ddSearchName.Size = New System.Drawing.Size(153, 24)
        Me.ddSearchName.TabIndex = 1
        Me.ddSearchName.Value = Nothing
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(5, 179)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(202, 23)
        Me.btnFind.TabIndex = 10
        Me.btnFind.Text = "Find (F5)"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.radSelectTF)
        Me.GroupBox4.Controls.Add(Me.radSelectFN)
        Me.GroupBox4.Controls.Add(Me.radSelectSP)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 249)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(213, 70)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Object"
        '
        'radSelectTF
        '
        Me.radSelectTF.AutoSize = True
        Me.radSelectTF.Location = New System.Drawing.Point(5, 49)
        Me.radSelectTF.Name = "radSelectTF"
        Me.radSelectTF.Size = New System.Drawing.Size(122, 20)
        Me.radSelectTF.TabIndex = 9
        Me.radSelectTF.Text = "Table Function"
        Me.radSelectTF.UseVisualStyleBackColor = True
        '
        'radSelectFN
        '
        Me.radSelectFN.AutoSize = True
        Me.radSelectFN.Location = New System.Drawing.Point(5, 31)
        Me.radSelectFN.Name = "radSelectFN"
        Me.radSelectFN.Size = New System.Drawing.Size(128, 20)
        Me.radSelectFN.TabIndex = 8
        Me.radSelectFN.Text = "Scalar Function"
        Me.radSelectFN.UseVisualStyleBackColor = True
        '
        'radSelectSP
        '
        Me.radSelectSP.AutoSize = True
        Me.radSelectSP.Checked = True
        Me.radSelectSP.Location = New System.Drawing.Point(5, 13)
        Me.radSelectSP.Name = "radSelectSP"
        Me.radSelectSP.Size = New System.Drawing.Size(141, 20)
        Me.radSelectSP.TabIndex = 7
        Me.radSelectSP.TabStop = True
        Me.radSelectSP.Text = "Stored Procedure"
        Me.radSelectSP.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ddDatabase, Me.btnSetCurrentDatabase, Me.ToolStripSeparator2, Me.ToolStripLabel2, Me.btnRename, Me.btnDelete, Me.ToolStripSplitButton1, Me.ddTargetDatabase, Me.ToolStripSeparator1, Me.btnVerifySyntax, Me.btnExport, Me.btnOpenAll})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(918, 27)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(73, 24)
        Me.ToolStripLabel1.Text = "Database"
        '
        'ddDatabase
        '
        Me.ddDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ddDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddDatabase.DropDownWidth = 200
        Me.ddDatabase.Name = "ddDatabase"
        Me.ddDatabase.Size = New System.Drawing.Size(120, 27)
        '
        'btnSetCurrentDatabase
        '
        Me.btnSetCurrentDatabase.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSetCurrentDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSetCurrentDatabase.Image = CType(resources.GetObject("btnSetCurrentDatabase.Image"), System.Drawing.Image)
        Me.btnSetCurrentDatabase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSetCurrentDatabase.Name = "btnSetCurrentDatabase"
        Me.btnSetCurrentDatabase.Size = New System.Drawing.Size(66, 24)
        Me.btnSetCurrentDatabase.Text = "Current"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(82, 24)
        Me.ToolStripLabel2.Text = "Operation"
        '
        'btnRename
        '
        Me.btnRename.Image = CType(resources.GetObject("btnRename.Image"), System.Drawing.Image)
        Me.btnRename.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(90, 24)
        Me.btnRename.Text = "Rename"
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(24, 24)
        Me.btnDelete.Text = "Delete"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCopyAndUpdate, Me.btnCopyAndCreate})
        Me.ToolStripSplitButton1.Image = Global.Table_Viewer.My.Resources.Resources.Copy2
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(39, 24)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'btnCopyAndUpdate
        '
        Me.btnCopyAndUpdate.Name = "btnCopyAndUpdate"
        Me.btnCopyAndUpdate.Size = New System.Drawing.Size(153, 26)
        Me.btnCopyAndUpdate.Text = "Update to"
        '
        'btnCopyAndCreate
        '
        Me.btnCopyAndCreate.Name = "btnCopyAndCreate"
        Me.btnCopyAndCreate.Size = New System.Drawing.Size(153, 26)
        Me.btnCopyAndCreate.Text = "Create at"
        '
        'ddTargetDatabase
        '
        Me.ddTargetDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ddTargetDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddTargetDatabase.DropDownWidth = 200
        Me.ddTargetDatabase.Name = "ddTargetDatabase"
        Me.ddTargetDatabase.Size = New System.Drawing.Size(120, 27)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'btnVerifySyntax
        '
        Me.btnVerifySyntax.Image = CType(resources.GetObject("btnVerifySyntax.Image"), System.Drawing.Image)
        Me.btnVerifySyntax.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVerifySyntax.Name = "btnVerifySyntax"
        Me.btnVerifySyntax.Size = New System.Drawing.Size(124, 24)
        Me.btnVerifySyntax.Text = "Verify Syntax"
        '
        'btnExport
        '
        Me.btnExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateToolStripMenuItem, Me.AlterToolStripMenuItem, Me.CraeteToFileToolStripMenuItem, Me.AlterToFileToolStripMenuItem, Me.ManagementStudioToolStripMenuItem})
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(92, 24)
        Me.btnExport.Text = "Export"
        '
        'CreateToolStripMenuItem
        '
        Me.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        Me.CreateToolStripMenuItem.Size = New System.Drawing.Size(227, 26)
        Me.CreateToolStripMenuItem.Tag = "Create"
        Me.CreateToolStripMenuItem.Text = "Create"
        '
        'AlterToolStripMenuItem
        '
        Me.AlterToolStripMenuItem.Name = "AlterToolStripMenuItem"
        Me.AlterToolStripMenuItem.Size = New System.Drawing.Size(227, 26)
        Me.AlterToolStripMenuItem.Tag = "Alter"
        Me.AlterToolStripMenuItem.Text = "Alter"
        '
        'CraeteToFileToolStripMenuItem
        '
        Me.CraeteToFileToolStripMenuItem.Name = "CraeteToFileToolStripMenuItem"
        Me.CraeteToFileToolStripMenuItem.Size = New System.Drawing.Size(227, 26)
        Me.CraeteToFileToolStripMenuItem.Tag = "CreateFile"
        Me.CraeteToFileToolStripMenuItem.Text = "Create (To File)"
        '
        'AlterToFileToolStripMenuItem
        '
        Me.AlterToFileToolStripMenuItem.Name = "AlterToFileToolStripMenuItem"
        Me.AlterToFileToolStripMenuItem.Size = New System.Drawing.Size(227, 26)
        Me.AlterToFileToolStripMenuItem.Tag = "AlterFile"
        Me.AlterToFileToolStripMenuItem.Text = "Alter (To File)"
        '
        'ManagementStudioToolStripMenuItem
        '
        Me.ManagementStudioToolStripMenuItem.Name = "ManagementStudioToolStripMenuItem"
        Me.ManagementStudioToolStripMenuItem.Size = New System.Drawing.Size(227, 26)
        Me.ManagementStudioToolStripMenuItem.Tag = "SSMSE"
        Me.ManagementStudioToolStripMenuItem.Text = "Management Studio"
        '
        'btnOpenAll
        '
        Me.btnOpenAll.Image = CType(resources.GetObject("btnOpenAll.Image"), System.Drawing.Image)
        Me.btnOpenAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpenAll.Name = "btnOpenAll"
        Me.btnOpenAll.Size = New System.Drawing.Size(71, 24)
        Me.btnOpenAll.Text = "Open"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblStatus.Location = New System.Drawing.Point(9, 445)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(48, 16)
        Me.lblStatus.TabIndex = 16
        Me.lblStatus.Text = "Status"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnFindColumn)
        Me.GroupBox3.Controls.Add(Me.txtDataType)
        Me.GroupBox3.Controls.Add(Me.txtColumnName)
        Me.GroupBox3.Controls.Add(Me.txtTableName)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 325)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(213, 117)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search by Column (Declared Variable)"
        '
        'btnFindColumn
        '
        Me.btnFindColumn.Location = New System.Drawing.Point(5, 89)
        Me.btnFindColumn.Name = "btnFindColumn"
        Me.btnFindColumn.Size = New System.Drawing.Size(202, 23)
        Me.btnFindColumn.TabIndex = 18
        Me.btnFindColumn.Text = "Find All Reference"
        Me.btnFindColumn.UseVisualStyleBackColor = True
        '
        'txtDataType
        '
        Me.txtDataType.Location = New System.Drawing.Point(88, 63)
        Me.txtDataType.Name = "txtDataType"
        Me.txtDataType.Size = New System.Drawing.Size(119, 23)
        Me.txtDataType.TabIndex = 5
        '
        'txtColumnName
        '
        Me.txtColumnName.Location = New System.Drawing.Point(88, 39)
        Me.txtColumnName.Name = "txtColumnName"
        Me.txtColumnName.Size = New System.Drawing.Size(119, 23)
        Me.txtColumnName.TabIndex = 4
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(88, 16)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(119, 23)
        Me.txtTableName.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Data Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Column Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Table"
        '
        'cmdgSave
        '
        Me.cmdgSave.Filter = "SQL Query (*.sql)|*.sql|Text (*.txt)|*.txt|All Files|*.*"
        '
        'dgcSPSelect
        '
        Me.dgcSPSelect.HeaderText = ""
        Me.dgcSPSelect.Name = "dgcSPSelect"
        Me.dgcSPSelect.Width = 20
        '
        'dgcSPName
        '
        Me.dgcSPName.HeaderText = "Name"
        Me.dgcSPName.Name = "dgcSPName"
        Me.dgcSPName.ReadOnly = True
        Me.dgcSPName.Width = 250
        '
        'dgcEdit
        '
        Me.dgcEdit.HeaderText = ""
        Me.dgcEdit.Image = CType(resources.GetObject("dgcEdit.Image"), System.Drawing.Image)
        Me.dgcEdit.Name = "dgcEdit"
        Me.dgcEdit.ToolTipText = "Edit"
        Me.dgcEdit.Width = 20
        '
        'dgcExecute
        '
        Me.dgcExecute.HeaderText = ""
        Me.dgcExecute.Image = CType(resources.GetObject("dgcExecute.Image"), System.Drawing.Image)
        Me.dgcExecute.Name = "dgcExecute"
        Me.dgcExecute.ToolTipText = "Execute"
        Me.dgcExecute.Width = 20
        '
        'dgcShowDependencies
        '
        Me.dgcShowDependencies.HeaderText = ""
        Me.dgcShowDependencies.Image = CType(resources.GetObject("dgcShowDependencies.Image"), System.Drawing.Image)
        Me.dgcShowDependencies.Name = "dgcShowDependencies"
        Me.dgcShowDependencies.ToolTipText = "Show Dependencies"
        Me.dgcShowDependencies.Visible = False
        Me.dgcShowDependencies.Width = 20
        '
        'dgcSPLastUpdate
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgcSPLastUpdate.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgcSPLastUpdate.HeaderText = "Last Updated"
        Me.dgcSPLastUpdate.Name = "dgcSPLastUpdate"
        Me.dgcSPLastUpdate.Width = 110
        '
        'dgcSPParameter
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgcSPParameter.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgcSPParameter.HeaderText = "Parameters"
        Me.dgcSPParameter.Name = "dgcSPParameter"
        Me.dgcSPParameter.ReadOnly = True
        '
        'dgcSPStatus
        '
        Me.dgcSPStatus.HeaderText = "Status"
        Me.dgcSPStatus.Name = "dgcSPStatus"
        Me.dgcSPStatus.ReadOnly = True
        '
        'frm_SP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 563)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_SP"
        Me.Text = "Stored Procedure Manager"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents dgResult As CHKControl.GridView.SmartDataGrid
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents radSelectFN As System.Windows.Forms.RadioButton
    Friend WithEvents radSelectSP As System.Windows.Forms.RadioButton
    Friend WithEvents ddSearchName As CHKControl.ExtendedComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ddSearchCode As CHKControl.ExtendedComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents radSelectTF As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ddDatabase As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnSetCurrentDatabase As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnRename As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnVerifySyntax As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents chkSearchModifiedDate As System.Windows.Forms.CheckBox
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents CreateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataType As System.Windows.Forms.TextBox
    Friend WithEvents txtColumnName As System.Windows.Forms.TextBox
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindColumn As System.Windows.Forms.Button
    Friend WithEvents btnOpenAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CraeteToFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterToFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ManagementStudioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSearchModifiedDateE As CHKControl.ExtendedDateTimePicker
    Friend WithEvents txtSearchModifiedDateS As CHKControl.ExtendedDateTimePicker
    Friend WithEvents txtSchema As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ddTargetDatabase As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnCopyAndUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCopyAndCreate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgcSPSelect As DataGridViewCheckBoxColumn
    Friend WithEvents dgcSPName As DataGridViewTextBoxColumn
    Friend WithEvents dgcEdit As DataGridViewImageColumn
    Friend WithEvents dgcExecute As DataGridViewImageColumn
    Friend WithEvents dgcShowDependencies As DataGridViewImageColumn
    Friend WithEvents dgcSPLastUpdate As DataGridViewTextBoxColumn
    Friend WithEvents dgcSPParameter As DataGridViewTextBoxColumn
    Friend WithEvents dgcSPStatus As DataGridViewTextBoxColumn
End Class
