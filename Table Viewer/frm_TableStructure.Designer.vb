<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_TableStructure
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_TableStructure))
        Me.dgResult = New CHKControl.GridView.SmartDataGrid()
        Me.dcKey = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dcColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcDataType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcNullable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dcAutoIncrement = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcDefaultValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcComputedExpr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgConstraint = New CHKControl.GridView.SmartDataGrid()
        Me.dgcConstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcConstClause = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgFK = New CHKControl.GridView.SmartDataGrid()
        Me.dgcFKParentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFKRefTable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFKRefColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabConstraint = New System.Windows.Forms.TabPage()
        Me.tabFK = New System.Windows.Forms.TabPage()
        Me.tabUK = New System.Windows.Forms.TabPage()
        Me.dgUK = New CHKControl.GridView.SmartDataGrid()
        Me.dgcUKName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcUKColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcUKOrdinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabIX = New System.Windows.Forms.TabPage()
        Me.dgIX = New CHKControl.GridView.SmartDataGrid()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtVariable = New CHKControl.TextBox.SmartTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtTableName = New System.Windows.Forms.ToolStripTextBox()
        Me.btnChangeColumnName = New System.Windows.Forms.ToolStripButton()
        Me.btnChangeDataType = New System.Windows.Forms.ToolStripButton()
        Me.btnChangeDesc = New System.Windows.Forms.ToolStripButton()
        Me.btnAddColumn = New System.Windows.Forms.ToolStripButton()
        Me.btnDropColumn = New System.Windows.Forms.ToolStripButton()
        Me.btnCopyColumnDef = New System.Windows.Forms.ToolStripButton()
        Me.btnCreateTable = New System.Windows.Forms.ToolStripButton()
        Me.lblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.dgcIXName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcIXColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcIXOrdinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcIXInclude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgConstraint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgFK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabConstraint.SuspendLayout()
        Me.tabFK.SuspendLayout()
        Me.tabUK.SuspendLayout()
        CType(Me.dgUK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabIX.SuspendLayout()
        CType(Me.dgIX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgResult
        '
        Me.dgResult.AllowUserToResizeRows = False
        Me.dgResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcKey, Me.dcColumnName, Me.dcDataType, Me.dcDescription, Me.dcNullable, Me.dcAutoIncrement, Me.dgcDefaultValue, Me.dgcComputedExpr})
        Me.dgResult.GrowRowAtPaste = True
        Me.dgResult.Location = New System.Drawing.Point(5, 27)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.RowTemplate.Height = 24
        Me.dgResult.ShowCellErrors = False
        Me.dgResult.ShowCellToolTips = False
        Me.dgResult.ShowEditingIcon = False
        Me.dgResult.ShowRowErrors = False
        Me.dgResult.Size = New System.Drawing.Size(600, 524)
        Me.dgResult.TabIndex = 0
        '
        'dcKey
        '
        Me.dcKey.FalseValue = ""
        Me.dcKey.HeaderText = "Key"
        Me.dcKey.Name = "dcKey"
        Me.dcKey.Width = 50
        '
        'dcColumnName
        '
        Me.dcColumnName.HeaderText = "Column Name"
        Me.dcColumnName.Name = "dcColumnName"
        Me.dcColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcDataType
        '
        Me.dcDataType.HeaderText = "Data Type"
        Me.dcDataType.Name = "dcDataType"
        Me.dcDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcDataType.Width = 80
        '
        'dcDescription
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dcDescription.DefaultCellStyle = DataGridViewCellStyle2
        Me.dcDescription.HeaderText = "Description"
        Me.dcDescription.Name = "dcDescription"
        Me.dcDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcNullable
        '
        Me.dcNullable.FalseValue = ""
        Me.dcNullable.HeaderText = "Null"
        Me.dcNullable.Name = "dcNullable"
        Me.dcNullable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dcNullable.Width = 50
        '
        'dcAutoIncrement
        '
        Me.dcAutoIncrement.HeaderText = "Auto Id"
        Me.dcAutoIncrement.Name = "dcAutoIncrement"
        Me.dcAutoIncrement.ToolTipText = "Auto Increment"
        Me.dcAutoIncrement.Width = 50
        '
        'dgcDefaultValue
        '
        Me.dgcDefaultValue.HeaderText = "Default"
        Me.dgcDefaultValue.Name = "dgcDefaultValue"
        Me.dgcDefaultValue.Width = 80
        '
        'dgcComputedExpr
        '
        Me.dgcComputedExpr.HeaderText = "Computed Expr."
        Me.dgcComputedExpr.Name = "dgcComputedExpr"
        Me.dgcComputedExpr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcComputedExpr.Width = 120
        '
        'dgConstraint
        '
        Me.dgConstraint.AllowUserToAddRows = False
        Me.dgConstraint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgConstraint.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcConstName, Me.dgcConstClause})
        Me.dgConstraint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgConstraint.Location = New System.Drawing.Point(3, 3)
        Me.dgConstraint.Name = "dgConstraint"
        Me.dgConstraint.ReadOnly = True
        Me.dgConstraint.RowHeadersVisible = False
        Me.dgConstraint.Size = New System.Drawing.Size(291, 491)
        Me.dgConstraint.TabIndex = 24
        '
        'dgcConstName
        '
        Me.dgcConstName.HeaderText = "Name"
        Me.dgcConstName.Name = "dgcConstName"
        Me.dgcConstName.ReadOnly = True
        Me.dgcConstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dgcConstClause
        '
        Me.dgcConstClause.HeaderText = "Clause"
        Me.dgcConstClause.Name = "dgcConstClause"
        Me.dgcConstClause.ReadOnly = True
        Me.dgcConstClause.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcConstClause.Width = 150
        '
        'dgFK
        '
        Me.dgFK.AllowUserToAddRows = False
        Me.dgFK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFK.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcFKParentColumn, Me.dgcFKRefTable, Me.dgcFKRefColumn})
        Me.dgFK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFK.Location = New System.Drawing.Point(3, 3)
        Me.dgFK.Name = "dgFK"
        Me.dgFK.ReadOnly = True
        Me.dgFK.RowHeadersVisible = False
        Me.dgFK.Size = New System.Drawing.Size(291, 491)
        Me.dgFK.TabIndex = 26
        '
        'dgcFKParentColumn
        '
        Me.dgcFKParentColumn.HeaderText = "Column"
        Me.dgcFKParentColumn.Name = "dgcFKParentColumn"
        Me.dgcFKParentColumn.ReadOnly = True
        Me.dgcFKParentColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcFKParentColumn.Width = 80
        '
        'dgcFKRefTable
        '
        Me.dgcFKRefTable.HeaderText = "Ref. Table"
        Me.dgcFKRefTable.Name = "dgcFKRefTable"
        Me.dgcFKRefTable.ReadOnly = True
        Me.dgcFKRefTable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcFKRefTable.Width = 80
        '
        'dgcFKRefColumn
        '
        Me.dgcFKRefColumn.HeaderText = "Ref. Column"
        Me.dgcFKRefColumn.Name = "dgcFKRefColumn"
        Me.dgcFKRefColumn.ReadOnly = True
        Me.dgcFKRefColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcFKRefColumn.Width = 90
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabConstraint)
        Me.TabControl1.Controls.Add(Me.tabFK)
        Me.TabControl1.Controls.Add(Me.tabUK)
        Me.TabControl1.Controls.Add(Me.tabIX)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(611, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(305, 524)
        Me.TabControl1.TabIndex = 27
        '
        'tabConstraint
        '
        Me.tabConstraint.Controls.Add(Me.dgConstraint)
        Me.tabConstraint.Location = New System.Drawing.Point(4, 23)
        Me.tabConstraint.Name = "tabConstraint"
        Me.tabConstraint.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConstraint.Size = New System.Drawing.Size(297, 497)
        Me.tabConstraint.TabIndex = 0
        Me.tabConstraint.Text = "Constraints"
        Me.tabConstraint.UseVisualStyleBackColor = True
        '
        'tabFK
        '
        Me.tabFK.Controls.Add(Me.dgFK)
        Me.tabFK.Location = New System.Drawing.Point(4, 23)
        Me.tabFK.Name = "tabFK"
        Me.tabFK.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFK.Size = New System.Drawing.Size(297, 497)
        Me.tabFK.TabIndex = 1
        Me.tabFK.Text = "Foreign Keys"
        Me.tabFK.UseVisualStyleBackColor = True
        '
        'tabUK
        '
        Me.tabUK.Controls.Add(Me.dgUK)
        Me.tabUK.Location = New System.Drawing.Point(4, 23)
        Me.tabUK.Name = "tabUK"
        Me.tabUK.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUK.Size = New System.Drawing.Size(297, 497)
        Me.tabUK.TabIndex = 2
        Me.tabUK.Text = "Unique Keys"
        Me.tabUK.UseVisualStyleBackColor = True
        '
        'dgUK
        '
        Me.dgUK.AllowUserToAddRows = False
        Me.dgUK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUK.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcUKName, Me.dgcUKColumn, Me.dgcUKOrdinal})
        Me.dgUK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgUK.Location = New System.Drawing.Point(3, 3)
        Me.dgUK.Name = "dgUK"
        Me.dgUK.ReadOnly = True
        Me.dgUK.RowHeadersVisible = False
        Me.dgUK.Size = New System.Drawing.Size(291, 491)
        Me.dgUK.TabIndex = 28
        '
        'dgcUKName
        '
        Me.dgcUKName.HeaderText = "UK"
        Me.dgcUKName.Name = "dgcUKName"
        Me.dgcUKName.ReadOnly = True
        Me.dgcUKName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcUKName.Width = 80
        '
        'dgcUKColumn
        '
        Me.dgcUKColumn.HeaderText = "Column"
        Me.dgcUKColumn.Name = "dgcUKColumn"
        Me.dgcUKColumn.ReadOnly = True
        Me.dgcUKColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcUKColumn.Width = 90
        '
        'dgcUKOrdinal
        '
        Me.dgcUKOrdinal.HeaderText = "Ordinal"
        Me.dgcUKOrdinal.Name = "dgcUKOrdinal"
        Me.dgcUKOrdinal.ReadOnly = True
        Me.dgcUKOrdinal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcUKOrdinal.Width = 60
        '
        'tabIX
        '
        Me.tabIX.Controls.Add(Me.dgIX)
        Me.tabIX.Location = New System.Drawing.Point(4, 23)
        Me.tabIX.Name = "tabIX"
        Me.tabIX.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIX.Size = New System.Drawing.Size(297, 497)
        Me.tabIX.TabIndex = 4
        Me.tabIX.Text = "Indices"
        Me.tabIX.UseVisualStyleBackColor = True
        '
        'dgIX
        '
        Me.dgIX.AllowUserToAddRows = False
        Me.dgIX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgIX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcIXName, Me.dgcIXColumn, Me.dgcIXOrdinal, Me.dgcIXInclude})
        Me.dgIX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgIX.Location = New System.Drawing.Point(3, 3)
        Me.dgIX.Name = "dgIX"
        Me.dgIX.ReadOnly = True
        Me.dgIX.RowHeadersVisible = False
        Me.dgIX.Size = New System.Drawing.Size(291, 491)
        Me.dgIX.TabIndex = 29
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtVariable)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(297, 497)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Variable"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtVariable
        '
        Me.txtVariable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVariable.Location = New System.Drawing.Point(3, 3)
        Me.txtVariable.Multiline = True
        Me.txtVariable.Name = "txtVariable"
        Me.txtVariable.Size = New System.Drawing.Size(291, 491)
        Me.txtVariable.TabIndex = 0
        Me.txtVariable.Value = Nothing
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.txtTableName, Me.btnChangeColumnName, Me.btnChangeDataType, Me.btnChangeDesc, Me.btnAddColumn, Me.btnDropColumn, Me.btnCopyColumnDef, Me.btnCreateTable, Me.lblStatus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(920, 25)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripLabel1.Text = "Table Name"
        '
        'txtTableName
        '
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.ReadOnly = True
        Me.txtTableName.Size = New System.Drawing.Size(120, 25)
        '
        'btnChangeColumnName
        '
        Me.btnChangeColumnName.Image = CType(resources.GetObject("btnChangeColumnName.Image"), System.Drawing.Image)
        Me.btnChangeColumnName.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnChangeColumnName.Name = "btnChangeColumnName"
        Me.btnChangeColumnName.Size = New System.Drawing.Size(149, 22)
        Me.btnChangeColumnName.Text = "Change Column Name"
        '
        'btnChangeDataType
        '
        Me.btnChangeDataType.Image = CType(resources.GetObject("btnChangeDataType.Image"), System.Drawing.Image)
        Me.btnChangeDataType.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnChangeDataType.Name = "btnChangeDataType"
        Me.btnChangeDataType.Size = New System.Drawing.Size(121, 22)
        Me.btnChangeDataType.Text = "Change DataType"
        '
        'btnChangeDesc
        '
        Me.btnChangeDesc.Image = CType(resources.GetObject("btnChangeDesc.Image"), System.Drawing.Image)
        Me.btnChangeDesc.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnChangeDesc.Name = "btnChangeDesc"
        Me.btnChangeDesc.Size = New System.Drawing.Size(131, 22)
        Me.btnChangeDesc.Text = "Change Description"
        '
        'btnAddColumn
        '
        Me.btnAddColumn.Image = CType(resources.GetObject("btnAddColumn.Image"), System.Drawing.Image)
        Me.btnAddColumn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddColumn.Name = "btnAddColumn"
        Me.btnAddColumn.Size = New System.Drawing.Size(95, 22)
        Me.btnAddColumn.Text = "Add Column"
        '
        'btnDropColumn
        '
        Me.btnDropColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDropColumn.Image = CType(resources.GetObject("btnDropColumn.Image"), System.Drawing.Image)
        Me.btnDropColumn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDropColumn.Name = "btnDropColumn"
        Me.btnDropColumn.Size = New System.Drawing.Size(83, 22)
        Me.btnDropColumn.Text = "Drop Column"
        '
        'btnCopyColumnDef
        '
        Me.btnCopyColumnDef.Image = CType(resources.GetObject("btnCopyColumnDef.Image"), System.Drawing.Image)
        Me.btnCopyColumnDef.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopyColumnDef.Name = "btnCopyColumnDef"
        Me.btnCopyColumnDef.Size = New System.Drawing.Size(156, 20)
        Me.btnCopyColumnDef.Text = "Copy Column Definition"
        '
        'btnCreateTable
        '
        Me.btnCreateTable.Image = Global.Table_Viewer.My.Resources.Resources.new_icon
        Me.btnCreateTable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCreateTable.Name = "btnCreateTable"
        Me.btnCreateTable.Size = New System.Drawing.Size(93, 20)
        Me.btnCreateTable.Text = "Create Table"
        '
        'lblStatus
        '
        Me.lblStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 15)
        Me.lblStatus.Text = "Status"
        '
        'dgcIXName
        '
        Me.dgcIXName.HeaderText = "IX"
        Me.dgcIXName.Name = "dgcIXName"
        Me.dgcIXName.ReadOnly = True
        Me.dgcIXName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcIXName.Width = 80
        '
        'dgcIXColumn
        '
        Me.dgcIXColumn.HeaderText = "Column"
        Me.dgcIXColumn.Name = "dgcIXColumn"
        Me.dgcIXColumn.ReadOnly = True
        Me.dgcIXColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcIXColumn.Width = 90
        '
        'dgcIXOrdinal
        '
        Me.dgcIXOrdinal.HeaderText = "Ordinal"
        Me.dgcIXOrdinal.Name = "dgcIXOrdinal"
        Me.dgcIXOrdinal.ReadOnly = True
        Me.dgcIXOrdinal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgcIXOrdinal.Width = 60
        '
        'dgcIXInclude
        '
        Me.dgcIXInclude.HeaderText = "Include"
        Me.dgcIXInclude.Name = "dgcIXInclude"
        Me.dgcIXInclude.ReadOnly = True
        Me.dgcIXInclude.Width = 60
        '
        'frm_TableStructure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 554)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.dgResult)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_TableStructure"
        Me.Text = "Table Structure"
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgConstraint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgFK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabConstraint.ResumeLayout(False)
        Me.tabFK.ResumeLayout(False)
        Me.tabUK.ResumeLayout(False)
        CType(Me.dgUK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabIX.ResumeLayout(False)
        CType(Me.dgIX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgResult As CHKControl.GridView.SmartDataGrid
    Friend WithEvents dgConstraint As CHKControl.GridView.SmartDataGrid
    Friend WithEvents dgFK As CHKControl.GridView.SmartDataGrid
    Friend WithEvents dgcConstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcConstClause As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabConstraint As System.Windows.Forms.TabPage
    Friend WithEvents tabFK As System.Windows.Forms.TabPage
    Friend WithEvents tabUK As System.Windows.Forms.TabPage
    Friend WithEvents dgUK As CHKControl.GridView.SmartDataGrid
    Friend WithEvents dgcFKParentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFKRefTable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFKRefColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcUKName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcUKColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcUKOrdinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtTableName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnChangeDataType As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnChangeDesc As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnChangeColumnName As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAddColumn As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtVariable As CHKControl.TextBox.SmartTextBox
    Friend WithEvents tabIX As System.Windows.Forms.TabPage
    Friend WithEvents dgIX As CHKControl.GridView.SmartDataGrid
    Friend WithEvents btnDropColumn As System.Windows.Forms.ToolStripButton
    Friend WithEvents dcKey As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcNullable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcAutoIncrement As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcDefaultValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcComputedExpr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCreateTable As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCopyColumnDef As ToolStripButton
    Friend WithEvents dgcIXName As DataGridViewTextBoxColumn
    Friend WithEvents dgcIXColumn As DataGridViewTextBoxColumn
    Friend WithEvents dgcIXOrdinal As DataGridViewTextBoxColumn
    Friend WithEvents dgcIXInclude As DataGridViewTextBoxColumn
End Class
