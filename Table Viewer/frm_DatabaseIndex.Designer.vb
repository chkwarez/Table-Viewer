<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_DatabaseIndex
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_DatabaseIndex))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ddDatabase = New System.Windows.Forms.ToolStripComboBox()
        Me.btnSetCurrentDatabase = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.btnCheckHealth = New System.Windows.Forms.ToolStripButton()
        Me.btnGetRebuildSQL = New System.Windows.Forms.ToolStripButton()
        Me.btnRebuildTableIndices = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgHealth = New CHKControl.GridView.SmartDataGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgcHealthSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgcTableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcIndexName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFragementPct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcSuggestSQL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSuggestSQL = New System.Windows.Forms.RichTextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgHealth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ddDatabase, Me.btnSetCurrentDatabase, Me.ToolStripSeparator2, Me.ToolStripLabel2, Me.btnCheckHealth, Me.btnGetRebuildSQL, Me.btnRebuildTableIndices})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(683, 25)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripLabel1.Text = "Database"
        '
        'ddDatabase
        '
        Me.ddDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ddDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddDatabase.DropDownWidth = 200
        Me.ddDatabase.Name = "ddDatabase"
        Me.ddDatabase.Size = New System.Drawing.Size(120, 25)
        '
        'btnSetCurrentDatabase
        '
        Me.btnSetCurrentDatabase.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSetCurrentDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSetCurrentDatabase.Image = CType(resources.GetObject("btnSetCurrentDatabase.Image"), System.Drawing.Image)
        Me.btnSetCurrentDatabase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSetCurrentDatabase.Name = "btnSetCurrentDatabase"
        Me.btnSetCurrentDatabase.Size = New System.Drawing.Size(51, 22)
        Me.btnSetCurrentDatabase.Text = "Current"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripLabel2.Text = "Operation"
        '
        'btnCheckHealth
        '
        Me.btnCheckHealth.Image = Global.Table_Viewer.My.Resources.Resources.Process
        Me.btnCheckHealth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCheckHealth.Name = "btnCheckHealth"
        Me.btnCheckHealth.Size = New System.Drawing.Size(60, 22)
        Me.btnCheckHealth.Text = "Check"
        Me.btnCheckHealth.ToolTipText = "For index fragmentation," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "> 15%, REBUILD is recommended" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "else, REORGANIZE is reco" & _
    "mmended."
        '
        'btnGetRebuildSQL
        '
        Me.btnGetRebuildSQL.Image = Global.Table_Viewer.My.Resources.Resources.sql_icon
        Me.btnGetRebuildSQL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGetRebuildSQL.Name = "btnGetRebuildSQL"
        Me.btnGetRebuildSQL.Size = New System.Drawing.Size(112, 22)
        Me.btnGetRebuildSQL.Text = "Get Rebuild SQL"
        '
        'btnRebuildTableIndices
        '
        Me.btnRebuildTableIndices.Image = Global.Table_Viewer.My.Resources.Resources.PrimaryKey3
        Me.btnRebuildTableIndices.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRebuildTableIndices.Name = "btnRebuildTableIndices"
        Me.btnRebuildTableIndices.Size = New System.Drawing.Size(124, 22)
        Me.btnRebuildTableIndices.Text = "Rebuild All Indices"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 497)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(683, 22)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Status"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(683, 472)
        Me.TabControl1.TabIndex = 19
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgHealth)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(675, 446)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Fragmentation Check"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgHealth
        '
        Me.dgHealth.AllowUserToAddRows = False
        Me.dgHealth.AllowUserToDeleteRows = False
        Me.dgHealth.AllowUserToResizeRows = False
        Me.dgHealth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHealth.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcHealthSelect, Me.dgcTableName, Me.dgcIndexName, Me.dgcFragementPct, Me.dgcStatus, Me.dgcSuggestSQL})
        Me.dgHealth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgHealth.Location = New System.Drawing.Point(3, 3)
        Me.dgHealth.Name = "dgHealth"
        Me.dgHealth.RowHeadersVisible = False
        Me.dgHealth.RowTemplate.Height = 24
        Me.dgHealth.Size = New System.Drawing.Size(669, 440)
        Me.dgHealth.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtSuggestSQL)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(675, 446)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Suggest SQL"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgcHealthSelect
        '
        Me.dgcHealthSelect.HeaderText = ""
        Me.dgcHealthSelect.Name = "dgcHealthSelect"
        Me.dgcHealthSelect.Width = 20
        '
        'dgcTableName
        '
        Me.dgcTableName.DataPropertyName = "TableName"
        Me.dgcTableName.HeaderText = "TableName"
        Me.dgcTableName.Name = "dgcTableName"
        Me.dgcTableName.ReadOnly = True
        Me.dgcTableName.Width = 200
        '
        'dgcIndexName
        '
        Me.dgcIndexName.DataPropertyName = "IndexName"
        Me.dgcIndexName.HeaderText = "Index Name"
        Me.dgcIndexName.Name = "dgcIndexName"
        Me.dgcIndexName.ReadOnly = True
        Me.dgcIndexName.Width = 200
        '
        'dgcFragementPct
        '
        Me.dgcFragementPct.DataPropertyName = "FragementPct"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.dgcFragementPct.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgcFragementPct.HeaderText = "Fragment (%)"
        Me.dgcFragementPct.Name = "dgcFragementPct"
        Me.dgcFragementPct.ReadOnly = True
        '
        'dgcStatus
        '
        Me.dgcStatus.DataPropertyName = "Status"
        Me.dgcStatus.HeaderText = "Status"
        Me.dgcStatus.Name = "dgcStatus"
        Me.dgcStatus.ReadOnly = True
        '
        'dgcSuggestSQL
        '
        Me.dgcSuggestSQL.DataPropertyName = "SuggestSQL"
        Me.dgcSuggestSQL.HeaderText = "Suggest SQL"
        Me.dgcSuggestSQL.Name = "dgcSuggestSQL"
        Me.dgcSuggestSQL.Visible = False
        '
        'txtSuggestSQL
        '
        Me.txtSuggestSQL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSuggestSQL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSuggestSQL.Location = New System.Drawing.Point(3, 3)
        Me.txtSuggestSQL.Name = "txtSuggestSQL"
        Me.txtSuggestSQL.Size = New System.Drawing.Size(669, 440)
        Me.txtSuggestSQL.TabIndex = 0
        Me.txtSuggestSQL.Text = ""
        '
        'frm_Index
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 519)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frm_Index"
        Me.Text = "Table Index Manager"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgHealth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ddDatabase As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnSetCurrentDatabase As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnCheckHealth As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnRebuildTableIndices As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnGetRebuildSQL As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgHealth As CHKControl.GridView.SmartDataGrid
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgcHealthSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgcTableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcIndexName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFragementPct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcSuggestSQL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtSuggestSQL As System.Windows.Forms.RichTextBox
End Class
