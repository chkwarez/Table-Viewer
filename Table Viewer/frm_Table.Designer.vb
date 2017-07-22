<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Table
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
    Private components As System.ComponentModel.IContainer = New System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Table))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelColumn = New System.Windows.Forms.Panel()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.dgTableColumn = New CHKControl.GridView.SmartDataGrid()
        Me.dgcShow = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcDataType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnCopyColumn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnShowKey = New System.Windows.Forms.ToolStripButton()
        Me.btnShowOtherColumn = New System.Windows.Forms.ToolStripButton()
        Me.btnShowDummyColumn = New System.Windows.Forms.ToolStripButton()
        Me.btnAutoSelectColumn = New System.Windows.Forms.ToolStripButton()
        Me.txtFastSwitchColumnName = New System.Windows.Forms.ToolStripTextBox()
        Me.timerFilter = New System.Windows.Forms.Timer(Me.components)
        Me.tsBottom = New System.Windows.Forms.ToolStrip()
        Me.lblStatus2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.barProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtRecordLimit = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.txtFindData = New System.Windows.Forms.ToolStripTextBox()
        Me.lblFindStatus = New System.Windows.Forms.ToolStripLabel()
        Me.lblStatistics = New System.Windows.Forms.ToolStripLabel()
        Me.panelTop = New System.Windows.Forms.Panel()
        Me.txtOrderClause = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ddWhereClause = New CHKControl.ExtendedComboBox()
        Me.lblWhereClause = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnExportCsv = New System.Windows.Forms.ToolStripMenuItem()
        Me.btmExportHtml = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGenerateGUID = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRefresh = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAddRows = New System.Windows.Forms.ToolStripButton()
        Me.btnAutoSize = New System.Windows.Forms.ToolStripButton()
        Me.btnGenerateSQL = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TruncateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AdvancedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyTableNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnShowColumnsPanel = New System.Windows.Forms.ToolStripButton()
        Me.btnEditStructure = New System.Windows.Forms.ToolStripButton()
        Me.btnShowDependencies = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnShowRelatedTables = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnShowAllDependencies = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdgSave = New System.Windows.Forms.SaveFileDialog()
        Me.dgContent = New CHKControl.GridView.DbDataGrid()
        Me.timerFind = New System.Windows.Forms.Timer(Me.components)
        Me.panelColumn.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.dgTableColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.tsBottom.SuspendLayout()
        Me.panelTop.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelColumn
        '
        Me.panelColumn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelColumn.Controls.Add(Me.ToolStripContainer1)
        Me.panelColumn.Location = New System.Drawing.Point(674, 33)
        Me.panelColumn.Name = "panelColumn"
        Me.panelColumn.Size = New System.Drawing.Size(220, 602)
        Me.panelColumn.TabIndex = 7
        Me.panelColumn.Visible = False
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.dgTableColumn)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(220, 575)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(220, 602)
        Me.ToolStripContainer1.TabIndex = 26
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'dgTableColumn
        '
        Me.dgTableColumn.AllowUserToAddRows = False
        Me.dgTableColumn.AllowUserToDeleteRows = False
        Me.dgTableColumn.AllowUserToResizeRows = False
        Me.dgTableColumn.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgTableColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTableColumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcShow, Me.dgcName, Me.dgcDataType})
        Me.dgTableColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTableColumn.Location = New System.Drawing.Point(0, 0)
        Me.dgTableColumn.Name = "dgTableColumn"
        Me.dgTableColumn.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgTableColumn.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTableColumn.RowTemplate.Height = 24
        Me.dgTableColumn.Size = New System.Drawing.Size(220, 575)
        Me.dgTableColumn.TabIndex = 17
        '
        'dgcShow
        '
        Me.dgcShow.HeaderText = " "
        Me.dgcShow.Name = "dgcShow"
        Me.dgcShow.Width = 20
        '
        'dgcName
        '
        Me.dgcName.HeaderText = "Name"
        Me.dgcName.Name = "dgcName"
        Me.dgcName.ReadOnly = True
        Me.dgcName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcName.Width = 90
        '
        'dgcDataType
        '
        Me.dgcDataType.HeaderText = "DataType"
        Me.dgcDataType.Name = "dgcDataType"
        Me.dgcDataType.ReadOnly = True
        Me.dgcDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcDataType.Width = 80
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCopyColumn, Me.ToolStripSeparator3, Me.btnShowKey, Me.btnShowOtherColumn, Me.btnShowDummyColumn, Me.btnAutoSelectColumn, Me.txtFastSwitchColumnName})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(207, 27)
        Me.ToolStrip2.TabIndex = 25
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnCopyColumn
        '
        Me.btnCopyColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCopyColumn.Image = CType(resources.GetObject("btnCopyColumn.Image"), System.Drawing.Image)
        Me.btnCopyColumn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopyColumn.Name = "btnCopyColumn"
        Me.btnCopyColumn.Size = New System.Drawing.Size(24, 24)
        Me.btnCopyColumn.Text = "Copy Columns Structure"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'btnShowKey
        '
        Me.btnShowKey.CheckOnClick = True
        Me.btnShowKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnShowKey.Image = CType(resources.GetObject("btnShowKey.Image"), System.Drawing.Image)
        Me.btnShowKey.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShowKey.Name = "btnShowKey"
        Me.btnShowKey.Size = New System.Drawing.Size(24, 24)
        Me.btnShowKey.Tag = "KEY"
        Me.btnShowKey.Text = "Toogle Primary Key"
        '
        'btnShowOtherColumn
        '
        Me.btnShowOtherColumn.CheckOnClick = True
        Me.btnShowOtherColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnShowOtherColumn.Image = CType(resources.GetObject("btnShowOtherColumn.Image"), System.Drawing.Image)
        Me.btnShowOtherColumn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShowOtherColumn.Name = "btnShowOtherColumn"
        Me.btnShowOtherColumn.Size = New System.Drawing.Size(24, 24)
        Me.btnShowOtherColumn.Tag = "NORMAL"
        Me.btnShowOtherColumn.Text = "Toogle Other Columns"
        '
        'btnShowDummyColumn
        '
        Me.btnShowDummyColumn.CheckOnClick = True
        Me.btnShowDummyColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnShowDummyColumn.Image = CType(resources.GetObject("btnShowDummyColumn.Image"), System.Drawing.Image)
        Me.btnShowDummyColumn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShowDummyColumn.Name = "btnShowDummyColumn"
        Me.btnShowDummyColumn.Size = New System.Drawing.Size(24, 24)
        Me.btnShowDummyColumn.Tag = "DUMMY"
        Me.btnShowDummyColumn.Text = "Toggle Dummy Columns"
        '
        'btnAutoSelectColumn
        '
        Me.btnAutoSelectColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAutoSelectColumn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoSelectColumn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAutoSelectColumn.Image = CType(resources.GetObject("btnAutoSelectColumn.Image"), System.Drawing.Image)
        Me.btnAutoSelectColumn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAutoSelectColumn.Name = "btnAutoSelectColumn"
        Me.btnAutoSelectColumn.Size = New System.Drawing.Size(41, 24)
        Me.btnAutoSelectColumn.Text = "Auto"
        Me.btnAutoSelectColumn.ToolTipText = "Automatically hide columns without data."
        '
        'txtFastSwitchColumnName
        '
        Me.txtFastSwitchColumnName.BackColor = System.Drawing.Color.White
        Me.txtFastSwitchColumnName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFastSwitchColumnName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFastSwitchColumnName.Name = "txtFastSwitchColumnName"
        Me.txtFastSwitchColumnName.Size = New System.Drawing.Size(50, 27)
        '
        'timerFilter
        '
        Me.timerFilter.Interval = 500
        '
        'tsBottom
        '
        Me.tsBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tsBottom.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsBottom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus2, Me.lblStatus, Me.barProgress, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.txtRecordLimit, Me.ToolStripLabel4, Me.txtFindData, Me.lblFindStatus, Me.lblStatistics})
        Me.tsBottom.Location = New System.Drawing.Point(0, 636)
        Me.tsBottom.Name = "tsBottom"
        Me.tsBottom.Size = New System.Drawing.Size(896, 27)
        Me.tsBottom.TabIndex = 22
        Me.tsBottom.Text = "ToolStrip1"
        '
        'lblStatus2
        '
        Me.lblStatus2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblStatus2.Name = "lblStatus2"
        Me.lblStatus2.Size = New System.Drawing.Size(56, 22)
        Me.lblStatus2.Text = "Status2"
        '
        'lblStatus
        '
        Me.lblStatus.ForeColor = System.Drawing.Color.Navy
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(48, 22)
        Me.lblStatus.Text = "Status"
        '
        'barProgress
        '
        Me.barProgress.Name = "barProgress"
        Me.barProgress.Size = New System.Drawing.Size(50, 24)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(108, 24)
        Me.ToolStripLabel1.Text = "Limit Record To"
        '
        'txtRecordLimit
        '
        Me.txtRecordLimit.Name = "txtRecordLimit"
        Me.txtRecordLimit.Size = New System.Drawing.Size(40, 27)
        Me.txtRecordLimit.Text = "100"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripLabel4.Text = "Highlight"
        '
        'txtFindData
        '
        Me.txtFindData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtFindData.Name = "txtFindData"
        Me.txtFindData.Size = New System.Drawing.Size(100, 27)
        '
        'lblFindStatus
        '
        Me.lblFindStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblFindStatus.Name = "lblFindStatus"
        Me.lblFindStatus.Size = New System.Drawing.Size(73, 24)
        Me.lblFindStatus.Text = "Enter Text"
        '
        'lblStatistics
        '
        Me.lblStatistics.ForeColor = System.Drawing.Color.Purple
        Me.lblStatistics.Name = "lblStatistics"
        Me.lblStatistics.Size = New System.Drawing.Size(64, 24)
        Me.lblStatistics.Text = "Statistics"
        '
        'panelTop
        '
        Me.panelTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelTop.Controls.Add(Me.txtOrderClause)
        Me.panelTop.Controls.Add(Me.Label1)
        Me.panelTop.Controls.Add(Me.ddWhereClause)
        Me.panelTop.Controls.Add(Me.lblWhereClause)
        Me.panelTop.Controls.Add(Me.ToolStrip1)
        Me.panelTop.Location = New System.Drawing.Point(0, 2)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Size = New System.Drawing.Size(894, 28)
        Me.panelTop.TabIndex = 23
        '
        'txtOrderClause
        '
        Me.txtOrderClause.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderClause.Location = New System.Drawing.Point(791, 4)
        Me.txtOrderClause.Name = "txtOrderClause"
        Me.txtOrderClause.Size = New System.Drawing.Size(100, 23)
        Me.txtOrderClause.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(742, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "order by"
        '
        'ddWhereClause
        '
        Me.ddWhereClause.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddWhereClause.EnableHistory = True
        Me.ddWhereClause.FormattingEnabled = True
        Me.ddWhereClause.Location = New System.Drawing.Point(419, 3)
        Me.ddWhereClause.LossenValue = ""
        Me.ddWhereClause.Name = "ddWhereClause"
        Me.ddWhereClause.Size = New System.Drawing.Size(323, 24)
        Me.ddWhereClause.TabIndex = 0
        Me.ddWhereClause.Value = Nothing
        '
        'lblWhereClause
        '
        Me.lblWhereClause.AutoSize = True
        Me.lblWhereClause.Location = New System.Drawing.Point(378, 7)
        Me.lblWhereClause.Name = "lblWhereClause"
        Me.lblWhereClause.Size = New System.Drawing.Size(46, 16)
        Me.lblWhereClause.TabIndex = 25
        Me.lblWhereClause.Text = "where"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnRefresh, Me.btnAddRows, Me.btnAutoSize, Me.btnGenerateSQL, Me.btnShowColumnsPanel, Me.btnEditStructure, Me.btnShowDependencies})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(504, 27)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportCsv, Me.btmExportHtml, Me.btnGenerateGUID})
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(39, 24)
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save (Ctrl+S)"
        '
        'btnExportCsv
        '
        Me.btnExportCsv.Name = "btnExportCsv"
        Me.btnExportCsv.Size = New System.Drawing.Size(180, 26)
        Me.btnExportCsv.Text = "Export to CSV"
        '
        'btmExportHtml
        '
        Me.btmExportHtml.Name = "btmExportHtml"
        Me.btmExportHtml.Size = New System.Drawing.Size(180, 26)
        Me.btmExportHtml.Text = "Export to HTML"
        '
        'btnGenerateGUID
        '
        Me.btnGenerateGUID.Name = "btnGenerateGUID"
        Me.btnGenerateGUID.Size = New System.Drawing.Size(180, 26)
        Me.btnGenerateGUID.Text = "Generate GUID"
        '
        'btnRefresh
        '
        Me.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRefresh.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnReset})
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(39, 24)
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.ToolTipText = "Refresh (F5)"
        '
        'btnReset
        '
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(119, 26)
        Me.btnReset.Text = "Reset"
        '
        'btnAddRows
        '
        Me.btnAddRows.Image = CType(resources.GetObject("btnAddRows.Image"), System.Drawing.Image)
        Me.btnAddRows.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddRows.Name = "btnAddRows"
        Me.btnAddRows.Size = New System.Drawing.Size(95, 24)
        Me.btnAddRows.Text = "Add Rows"
        '
        'btnAutoSize
        '
        Me.btnAutoSize.Image = CType(resources.GetObject("btnAutoSize.Image"), System.Drawing.Image)
        Me.btnAutoSize.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAutoSize.Name = "btnAutoSize"
        Me.btnAutoSize.Size = New System.Drawing.Size(92, 24)
        Me.btnAutoSize.Text = "Auto Size"
        '
        'btnGenerateSQL
        '
        Me.btnGenerateSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGenerateSQL.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.SelectToolStripMenuItem, Me.InsertToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.UpdateToolStripMenuItem1, Me.TruncateToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripSeparator2, Me.AdvancedToolStripMenuItem, Me.DataToolStripMenuItem, Me.ToolStripSeparator4, Me.CopyTableNameToolStripMenuItem})
        Me.btnGenerateSQL.Image = CType(resources.GetObject("btnGenerateSQL.Image"), System.Drawing.Image)
        Me.btnGenerateSQL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerateSQL.Name = "btnGenerateSQL"
        Me.btnGenerateSQL.Size = New System.Drawing.Size(39, 24)
        Me.btnGenerateSQL.Text = "Generate SQL"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.Color.Navy
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(211, 26)
        Me.ToolStripMenuItem1.Text = "Quick Script"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.SelectToolStripMenuItem.Tag = "SQLSelect"
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.InsertToolStripMenuItem.Tag = "SQLInsert"
        Me.InsertToolStripMenuItem.Text = "Insert"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.DeleteToolStripMenuItem.Tag = "SQLDelete"
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'UpdateToolStripMenuItem1
        '
        Me.UpdateToolStripMenuItem1.Name = "UpdateToolStripMenuItem1"
        Me.UpdateToolStripMenuItem1.Size = New System.Drawing.Size(211, 26)
        Me.UpdateToolStripMenuItem1.Tag = "SQLUpdate"
        Me.UpdateToolStripMenuItem1.Text = "Update"
        '
        'TruncateToolStripMenuItem
        '
        Me.TruncateToolStripMenuItem.Name = "TruncateToolStripMenuItem"
        Me.TruncateToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.TruncateToolStripMenuItem.Tag = "SQLTruncate"
        Me.TruncateToolStripMenuItem.Text = "Truncate"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(211, 26)
        Me.ToolStripMenuItem2.Tag = "SQLDrop"
        Me.ToolStripMenuItem2.Text = "Drop Table"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(211, 26)
        Me.ToolStripMenuItem3.Tag = "SQLGroup"
        Me.ToolStripMenuItem3.Text = "Select ... Group By"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(208, 6)
        '
        'AdvancedToolStripMenuItem
        '
        Me.AdvancedToolStripMenuItem.Name = "AdvancedToolStripMenuItem"
        Me.AdvancedToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.AdvancedToolStripMenuItem.Tag = "Advanced"
        Me.AdvancedToolStripMenuItem.Text = "Advanced"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.DataToolStripMenuItem.Tag = "Data"
        Me.DataToolStripMenuItem.Text = "Script Data"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(208, 6)
        '
        'CopyTableNameToolStripMenuItem
        '
        Me.CopyTableNameToolStripMenuItem.Name = "CopyTableNameToolStripMenuItem"
        Me.CopyTableNameToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.CopyTableNameToolStripMenuItem.Text = "Copy Table Name"
        '
        'btnShowColumnsPanel
        '
        Me.btnShowColumnsPanel.CheckOnClick = True
        Me.btnShowColumnsPanel.Image = CType(resources.GetObject("btnShowColumnsPanel.Image"), System.Drawing.Image)
        Me.btnShowColumnsPanel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShowColumnsPanel.Name = "btnShowColumnsPanel"
        Me.btnShowColumnsPanel.Size = New System.Drawing.Size(86, 24)
        Me.btnShowColumnsPanel.Text = "Columns"
        Me.btnShowColumnsPanel.ToolTipText = "Columns (Middle Click)"
        '
        'btnEditStructure
        '
        Me.btnEditStructure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditStructure.Image = CType(resources.GetObject("btnEditStructure.Image"), System.Drawing.Image)
        Me.btnEditStructure.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditStructure.Name = "btnEditStructure"
        Me.btnEditStructure.Size = New System.Drawing.Size(24, 24)
        Me.btnEditStructure.Text = "Structure"
        '
        'btnShowDependencies
        '
        Me.btnShowDependencies.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnShowDependencies.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnShowRelatedTables, Me.btnShowAllDependencies})
        Me.btnShowDependencies.Image = CType(resources.GetObject("btnShowDependencies.Image"), System.Drawing.Image)
        Me.btnShowDependencies.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShowDependencies.Name = "btnShowDependencies"
        Me.btnShowDependencies.Size = New System.Drawing.Size(39, 24)
        Me.btnShowDependencies.Text = "Dependencies"
        Me.btnShowDependencies.Visible = False
        '
        'btnShowRelatedTables
        '
        Me.btnShowRelatedTables.Name = "btnShowRelatedTables"
        Me.btnShowRelatedTables.Size = New System.Drawing.Size(192, 26)
        Me.btnShowRelatedTables.Text = "Related Tables"
        '
        'btnShowAllDependencies
        '
        Me.btnShowAllDependencies.Name = "btnShowAllDependencies"
        Me.btnShowAllDependencies.Size = New System.Drawing.Size(192, 26)
        Me.btnShowAllDependencies.Text = "All Dependencies"
        '
        'dgContent
        '
        Me.dgContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgContent.GrowRowAtPaste = True
        Me.dgContent.Location = New System.Drawing.Point(0, 33)
        Me.dgContent.Name = "dgContent"
        DataGridViewCellStyle1.NullValue = "NULL"
        Me.dgContent.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgContent.ShowBooleanAsTextBox = True
        Me.dgContent.Size = New System.Drawing.Size(894, 598)
        Me.dgContent.TabIndex = 0
        '
        'timerFind
        '
        Me.timerFind.Interval = 500
        '
        'frm_Table
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 663)
        Me.Controls.Add(Me.panelTop)
        Me.Controls.Add(Me.tsBottom)
        Me.Controls.Add(Me.panelColumn)
        Me.Controls.Add(Me.dgContent)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_Table"
        Me.Text = "Table Viewer"
        Me.panelColumn.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        CType(Me.dgTableColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tsBottom.ResumeLayout(False)
        Me.tsBottom.PerformLayout()
        Me.panelTop.ResumeLayout(False)
        Me.panelTop.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelColumn As System.Windows.Forms.Panel
    Friend WithEvents timerFilter As System.Windows.Forms.Timer
    Friend WithEvents dgTableColumn As CHKControl.GridView.SmartDataGrid
    Friend WithEvents tsBottom As System.Windows.Forms.ToolStrip
    Friend WithEvents lblStatus2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents barProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtRecordLimit As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lblStatistics As System.Windows.Forms.ToolStripLabel
    Friend WithEvents panelTop As System.Windows.Forms.Panel
    Friend WithEvents ddWhereClause As CHKControl.ExtendedComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAddRows As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGenerateSQL As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents lblWhereClause As System.Windows.Forms.Label
    Friend WithEvents btnAutoSize As System.Windows.Forms.ToolStripButton
    Friend WithEvents SelectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnShowColumnsPanel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditStructure As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvancedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnExportCsv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgContent As CHKControl.GridView.DbDataGrid
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnCopyColumn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnShowKey As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnShowOtherColumn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnShowDummyColumn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAutoSelectColumn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnReset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtFindData As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents timerFind As System.Windows.Forms.Timer
    Friend WithEvents lblFindStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtOrderClause As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFastSwitchColumnName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TruncateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btmExportHtml As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgcShow As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnShowDependencies As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnShowRelatedTables As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnShowAllDependencies As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGenerateGUID As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents CopyTableNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
End Class
