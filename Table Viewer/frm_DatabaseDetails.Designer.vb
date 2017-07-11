<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_DatabaseDetails
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvwFiles = New CHKControl.ExtendedListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtDatabaseName = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsTableRowCount = New System.Windows.Forms.ToolStripButton()
        Me.tsUserRole = New System.Windows.Forms.ToolStripButton()
        Me.tsRestoreHistory = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFixOrphanedUser = New System.Windows.Forms.ToolStripButton()
        Me.tsSynonym = New System.Windows.Forms.ToolStripButton()
        Me.lvwTableRowCount = New CHKControl.ExtendedListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFilterTableName = New CHKControl.ExtendedTextBox()
        Me.chkHideEmptyTable = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gpTableRowCount = New System.Windows.Forms.GroupBox()
        Me.lblTableRowCount = New System.Windows.Forms.Label()
        Me.txtExcludeTableName = New CHKControl.ExtendedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.gpUserRole = New System.Windows.Forms.GroupBox()
        Me.lvwUserRole = New CHKControl.ExtendedListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gpRestoreHistory = New System.Windows.Forms.GroupBox()
        Me.lvwRestoreHistory = New CHKControl.ExtendedListView()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gpSynonym = New System.Windows.Forms.GroupBox()
        Me.lvwSynonym = New CHKControl.ExtendedListView()
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRecoveryMode = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.gpTableRowCount.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gpUserRole.SuspendLayout()
        Me.gpRestoreHistory.SuspendLayout()
        Me.gpSynonym.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data Files and Log Files"
        '
        'lvwFiles
        '
        Me.lvwFiles.CheckedTagIds = New Integer(-1) {}
        Me.lvwFiles.CheckedTagValues = New String(-1) {}
        Me.lvwFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvwFiles.FullRowSelect = True
        Me.lvwFiles.GridLines = True
        Me.lvwFiles.Location = New System.Drawing.Point(0, 46)
        Me.lvwFiles.Name = "lvwFiles"
        Me.lvwFiles.SelectedTag = Nothing
        Me.lvwFiles.SelectedTagId = -2147483648
        Me.lvwFiles.SelectedTagValue = Nothing
        Me.lvwFiles.Size = New System.Drawing.Size(659, 98)
        Me.lvwFiles.TabIndex = 1
        Me.lvwFiles.UseCompatibleStateImageBehavior = False
        Me.lvwFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Type"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Logical Name"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Physical File Path"
        Me.ColumnHeader3.Width = 400
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.txtDatabaseName, Me.ToolStripSeparator1, Me.tsTableRowCount, Me.tsUserRole, Me.tsRestoreHistory, Me.ToolStripSeparator2, Me.btnFixOrphanedUser, Me.tsSynonym})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(669, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripLabel1.Text = "Database"
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.ReadOnly = True
        Me.txtDatabaseName.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsTableRowCount
        '
        Me.tsTableRowCount.CheckOnClick = True
        Me.tsTableRowCount.Image = Global.Table_Viewer.My.Resources.Resources.Numbers_icon
        Me.tsTableRowCount.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsTableRowCount.Name = "tsTableRowCount"
        Me.tsTableRowCount.Size = New System.Drawing.Size(92, 22)
        Me.tsTableRowCount.Text = "Table Count"
        '
        'tsUserRole
        '
        Me.tsUserRole.CheckOnClick = True
        Me.tsUserRole.Image = Global.Table_Viewer.My.Resources.Resources.page_user_light
        Me.tsUserRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUserRole.Name = "tsUserRole"
        Me.tsUserRole.Size = New System.Drawing.Size(109, 22)
        Me.tsUserRole.Text = "Users and Roles"
        '
        'tsRestoreHistory
        '
        Me.tsRestoreHistory.CheckOnClick = True
        Me.tsRestoreHistory.Image = Global.Table_Viewer.My.Resources.Resources.Restore
        Me.tsRestoreHistory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRestoreHistory.Name = "tsRestoreHistory"
        Me.tsRestoreHistory.Size = New System.Drawing.Size(107, 22)
        Me.tsRestoreHistory.Text = "Restore History"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnFixOrphanedUser
        '
        Me.btnFixOrphanedUser.Image = Global.Table_Viewer.My.Resources.Resources.page_user_dark
        Me.btnFixOrphanedUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFixOrphanedUser.Name = "btnFixOrphanedUser"
        Me.btnFixOrphanedUser.Size = New System.Drawing.Size(123, 22)
        Me.btnFixOrphanedUser.Text = "Fix Orphaned User"
        '
        'tsSynonym
        '
        Me.tsSynonym.CheckOnClick = True
        Me.tsSynonym.Image = Global.Table_Viewer.My.Resources.Resources.S_icon
        Me.tsSynonym.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSynonym.Name = "tsSynonym"
        Me.tsSynonym.Size = New System.Drawing.Size(77, 20)
        Me.tsSynonym.Text = "Synonym"
        '
        'lvwTableRowCount
        '
        Me.lvwTableRowCount.AllowSort = True
        Me.lvwTableRowCount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwTableRowCount.CheckedTagIds = New Integer(-1) {}
        Me.lvwTableRowCount.CheckedTagValues = New String(-1) {}
        Me.lvwTableRowCount.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvwTableRowCount.FullRowSelect = True
        Me.lvwTableRowCount.GridLines = True
        Me.lvwTableRowCount.Location = New System.Drawing.Point(6, 19)
        Me.lvwTableRowCount.Name = "lvwTableRowCount"
        Me.lvwTableRowCount.SelectedTag = Nothing
        Me.lvwTableRowCount.SelectedTagId = -2147483648
        Me.lvwTableRowCount.SelectedTagValue = Nothing
        Me.lvwTableRowCount.Size = New System.Drawing.Size(348, 175)
        Me.lvwTableRowCount.TabIndex = 7
        Me.lvwTableRowCount.UseCompatibleStateImageBehavior = False
        Me.lvwTableRowCount.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Schema Name"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Table Name"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "No. of rows"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 100
        '
        'txtFilterTableName
        '
        Me.txtFilterTableName.Location = New System.Drawing.Point(414, 19)
        Me.txtFilterTableName.Name = "txtFilterTableName"
        Me.txtFilterTableName.Size = New System.Drawing.Size(100, 20)
        Me.txtFilterTableName.TabIndex = 8
        '
        'chkHideEmptyTable
        '
        Me.chkHideEmptyTable.AutoSize = True
        Me.chkHideEmptyTable.Location = New System.Drawing.Point(368, 73)
        Me.chkHideEmptyTable.Name = "chkHideEmptyTable"
        Me.chkHideEmptyTable.Size = New System.Drawing.Size(110, 17)
        Me.chkHideEmptyTable.TabIndex = 15
        Me.chkHideEmptyTable.Text = "Hide Empty Table"
        Me.chkHideEmptyTable.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(365, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Filter"
        '
        'gpTableRowCount
        '
        Me.gpTableRowCount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpTableRowCount.Controls.Add(Me.lblTableRowCount)
        Me.gpTableRowCount.Controls.Add(Me.txtExcludeTableName)
        Me.gpTableRowCount.Controls.Add(Me.Label4)
        Me.gpTableRowCount.Controls.Add(Me.lvwTableRowCount)
        Me.gpTableRowCount.Controls.Add(Me.Label3)
        Me.gpTableRowCount.Controls.Add(Me.txtFilterTableName)
        Me.gpTableRowCount.Controls.Add(Me.chkHideEmptyTable)
        Me.gpTableRowCount.Location = New System.Drawing.Point(3, 3)
        Me.gpTableRowCount.Name = "gpTableRowCount"
        Me.gpTableRowCount.Size = New System.Drawing.Size(644, 200)
        Me.gpTableRowCount.TabIndex = 11
        Me.gpTableRowCount.TabStop = False
        Me.gpTableRowCount.Text = "Table Row Count"
        Me.gpTableRowCount.Visible = False
        '
        'lblTableRowCount
        '
        Me.lblTableRowCount.AutoSize = True
        Me.lblTableRowCount.Location = New System.Drawing.Point(365, 104)
        Me.lblTableRowCount.Name = "lblTableRowCount"
        Me.lblTableRowCount.Size = New System.Drawing.Size(35, 13)
        Me.lblTableRowCount.TabIndex = 16
        Me.lblTableRowCount.Text = "Count"
        '
        'txtExcludeTableName
        '
        Me.txtExcludeTableName.Location = New System.Drawing.Point(414, 44)
        Me.txtExcludeTableName.Name = "txtExcludeTableName"
        Me.txtExcludeTableName.Size = New System.Drawing.Size(100, 20)
        Me.txtExcludeTableName.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(365, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Exclude "
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.gpTableRowCount)
        Me.FlowLayoutPanel1.Controls.Add(Me.gpUserRole)
        Me.FlowLayoutPanel1.Controls.Add(Me.gpRestoreHistory)
        Me.FlowLayoutPanel1.Controls.Add(Me.gpSynonym)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 148)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(669, 292)
        Me.FlowLayoutPanel1.TabIndex = 12
        '
        'gpUserRole
        '
        Me.gpUserRole.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpUserRole.Controls.Add(Me.lvwUserRole)
        Me.gpUserRole.Location = New System.Drawing.Point(3, 209)
        Me.gpUserRole.Name = "gpUserRole"
        Me.gpUserRole.Size = New System.Drawing.Size(644, 200)
        Me.gpUserRole.TabIndex = 12
        Me.gpUserRole.TabStop = False
        Me.gpUserRole.Text = "Users and Roles"
        Me.gpUserRole.Visible = False
        '
        'lvwUserRole
        '
        Me.lvwUserRole.CheckedTagIds = New Integer(-1) {}
        Me.lvwUserRole.CheckedTagValues = New String(-1) {}
        Me.lvwUserRole.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader14})
        Me.lvwUserRole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwUserRole.FullRowSelect = True
        Me.lvwUserRole.GridLines = True
        Me.lvwUserRole.Location = New System.Drawing.Point(3, 16)
        Me.lvwUserRole.Name = "lvwUserRole"
        Me.lvwUserRole.SelectedTag = Nothing
        Me.lvwUserRole.SelectedTagId = -2147483648
        Me.lvwUserRole.SelectedTagValue = Nothing
        Me.lvwUserRole.Size = New System.Drawing.Size(638, 181)
        Me.lvwUserRole.TabIndex = 0
        Me.lvwUserRole.UseCompatibleStateImageBehavior = False
        Me.lvwUserRole.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Type"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Name"
        Me.ColumnHeader8.Width = 200
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Create Date"
        Me.ColumnHeader9.Width = 120
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Schema"
        Me.ColumnHeader10.Width = 80
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Roles"
        Me.ColumnHeader14.Width = 100
        '
        'gpRestoreHistory
        '
        Me.gpRestoreHistory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpRestoreHistory.Controls.Add(Me.lvwRestoreHistory)
        Me.gpRestoreHistory.Location = New System.Drawing.Point(3, 415)
        Me.gpRestoreHistory.Name = "gpRestoreHistory"
        Me.gpRestoreHistory.Size = New System.Drawing.Size(644, 150)
        Me.gpRestoreHistory.TabIndex = 13
        Me.gpRestoreHistory.TabStop = False
        Me.gpRestoreHistory.Text = "Restore History"
        Me.gpRestoreHistory.Visible = False
        '
        'lvwRestoreHistory
        '
        Me.lvwRestoreHistory.CheckedTagIds = New Integer(-1) {}
        Me.lvwRestoreHistory.CheckedTagValues = New String(-1) {}
        Me.lvwRestoreHistory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.lvwRestoreHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwRestoreHistory.FullRowSelect = True
        Me.lvwRestoreHistory.GridLines = True
        Me.lvwRestoreHistory.Location = New System.Drawing.Point(3, 16)
        Me.lvwRestoreHistory.Name = "lvwRestoreHistory"
        Me.lvwRestoreHistory.SelectedTag = Nothing
        Me.lvwRestoreHistory.SelectedTagId = -2147483648
        Me.lvwRestoreHistory.SelectedTagValue = Nothing
        Me.lvwRestoreHistory.Size = New System.Drawing.Size(638, 131)
        Me.lvwRestoreHistory.TabIndex = 0
        Me.lvwRestoreHistory.UseCompatibleStateImageBehavior = False
        Me.lvwRestoreHistory.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Restore Time"
        Me.ColumnHeader11.Width = 120
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "User"
        Me.ColumnHeader12.Width = 120
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Restore Type"
        Me.ColumnHeader13.Width = 80
        '
        'gpSynonym
        '
        Me.gpSynonym.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpSynonym.Controls.Add(Me.lvwSynonym)
        Me.gpSynonym.Location = New System.Drawing.Point(3, 571)
        Me.gpSynonym.Name = "gpSynonym"
        Me.gpSynonym.Size = New System.Drawing.Size(644, 200)
        Me.gpSynonym.TabIndex = 14
        Me.gpSynonym.TabStop = False
        Me.gpSynonym.Text = "Synonym"
        Me.gpSynonym.Visible = False
        '
        'lvwSynonym
        '
        Me.lvwSynonym.CheckedTagIds = New Integer(-1) {}
        Me.lvwSynonym.CheckedTagValues = New String(-1) {}
        Me.lvwSynonym.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader15, Me.ColumnHeader16})
        Me.lvwSynonym.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwSynonym.FullRowSelect = True
        Me.lvwSynonym.GridLines = True
        Me.lvwSynonym.Location = New System.Drawing.Point(3, 16)
        Me.lvwSynonym.Name = "lvwSynonym"
        Me.lvwSynonym.SelectedTag = Nothing
        Me.lvwSynonym.SelectedTagId = -2147483648
        Me.lvwSynonym.SelectedTagValue = Nothing
        Me.lvwSynonym.Size = New System.Drawing.Size(638, 181)
        Me.lvwSynonym.TabIndex = 0
        Me.lvwSynonym.UseCompatibleStateImageBehavior = False
        Me.lvwSynonym.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Name"
        Me.ColumnHeader15.Width = 120
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Linked Object"
        Me.ColumnHeader16.Width = 300
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Recovery Mode"
        '
        'lblRecoveryMode
        '
        Me.lblRecoveryMode.AutoSize = True
        Me.lblRecoveryMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecoveryMode.Location = New System.Drawing.Point(301, 30)
        Me.lblRecoveryMode.Name = "lblRecoveryMode"
        Me.lblRecoveryMode.Size = New System.Drawing.Size(96, 13)
        Me.lblRecoveryMode.TabIndex = 14
        Me.lblRecoveryMode.Text = "Recovery Mode"
        '
        'frm_DatabaseDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 443)
        Me.Controls.Add(Me.lblRecoveryMode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lvwFiles)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_DatabaseDetails"
        Me.Text = "Database Details"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gpTableRowCount.ResumeLayout(False)
        Me.gpTableRowCount.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.gpUserRole.ResumeLayout(False)
        Me.gpRestoreHistory.ResumeLayout(False)
        Me.gpSynonym.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvwFiles As CHKControl.ExtendedListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtDatabaseName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnFixOrphanedUser As System.Windows.Forms.ToolStripButton
    Friend WithEvents lvwTableRowCount As CHKControl.ExtendedListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFilterTableName As CHKControl.ExtendedTextBox
    Friend WithEvents chkHideEmptyTable As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gpTableRowCount As System.Windows.Forms.GroupBox
    Friend WithEvents tsTableRowCount As System.Windows.Forms.ToolStripButton
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblRecoveryMode As System.Windows.Forms.Label
    Friend WithEvents gpUserRole As System.Windows.Forms.GroupBox
    Friend WithEvents lvwUserRole As CHKControl.ExtendedListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tsUserRole As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtExcludeTableName As CHKControl.ExtendedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTableRowCount As System.Windows.Forms.Label
    Friend WithEvents gpRestoreHistory As System.Windows.Forms.GroupBox
    Friend WithEvents lvwRestoreHistory As CHKControl.ExtendedListView
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tsRestoreHistory As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents gpSynonym As GroupBox
    Friend WithEvents lvwSynonym As CHKControl.ExtendedListView
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents tsSynonym As ToolStripButton
End Class
