<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SQLSyn
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgResult = New CHKControl.GridView.DbDataGrid
        Me.dcAllowSearch = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dcColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcDataType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcVariableName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcAllowLike = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dcAllowStar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dcUseDateBetween = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dcAllowNull = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.gpInfo = New System.Windows.Forms.GroupBox
        Me.lblTable = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDatabase = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpSP = New System.Windows.Forms.GroupBox
        Me.lblSPPrefixWarning = New System.Windows.Forms.Label
        Me.txtSPPrefix = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblNameSearch = New System.Windows.Forms.Label
        Me.lblNameUpdate = New System.Windows.Forms.Label
        Me.lblNameGet = New System.Windows.Forms.Label
        Me.lblNameDelete = New System.Windows.Forms.Label
        Me.lblNameAdd = New System.Windows.Forms.Label
        Me.txtTableCaption = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkScriptSearch = New System.Windows.Forms.CheckBox
        Me.chkScriptAdd = New System.Windows.Forms.CheckBox
        Me.chkScriptUpdate = New System.Windows.Forms.CheckBox
        Me.chkScriptDelete = New System.Windows.Forms.CheckBox
        Me.chkScriptGet = New System.Windows.Forms.CheckBox
        Me.btnScriptToWindow = New System.Windows.Forms.Button
        Me.btnScript = New System.Windows.Forms.Button
        Me.gpOption = New System.Windows.Forms.GroupBox
        Me.radShowSP = New System.Windows.Forms.RadioButton
        Me.radShowSQL = New System.Windows.Forms.RadioButton
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.gpSQL = New System.Windows.Forms.GroupBox
        Me.txtTableAlias = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpInfo.SuspendLayout()
        Me.gpSP.SuspendLayout()
        Me.gpOption.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gpSQL.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToDeleteRows = False
        Me.dgResult.AllowUserToResizeRows = False
        Me.dgResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgResult.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcAllowSearch, Me.dcColumnName, Me.dcDataType, Me.dcVariableName, Me.dcAllowLike, Me.dcAllowStar, Me.dcUseDateBetween, Me.dcAllowNull})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgResult.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgResult.Location = New System.Drawing.Point(6, 16)
        Me.dgResult.Name = "dgResult"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgResult.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgResult.RowHeadersVisible = False
        Me.dgResult.RowTemplate.Height = 24
        Me.dgResult.ShowCellErrors = False
        Me.dgResult.ShowCellToolTips = False
        Me.dgResult.ShowEditingIcon = False
        Me.dgResult.ShowRowErrors = False
        Me.dgResult.Size = New System.Drawing.Size(583, 539)
        Me.dgResult.TabIndex = 1
        '
        'dcAllowSearch
        '
        Me.dcAllowSearch.HeaderText = ""
        Me.dcAllowSearch.Name = "dcAllowSearch"
        Me.dcAllowSearch.Width = 30
        '
        'dcColumnName
        '
        Me.dcColumnName.HeaderText = "Column Name"
        Me.dcColumnName.Name = "dcColumnName"
        Me.dcColumnName.ReadOnly = True
        Me.dcColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcDataType
        '
        Me.dcDataType.HeaderText = "Data Type"
        Me.dcDataType.Name = "dcDataType"
        Me.dcDataType.ReadOnly = True
        Me.dcDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcVariableName
        '
        Me.dcVariableName.HeaderText = "Variable Name"
        Me.dcVariableName.Name = "dcVariableName"
        '
        'dcAllowLike
        '
        Me.dcAllowLike.HeaderText = "Allow Like"
        Me.dcAllowLike.Name = "dcAllowLike"
        Me.dcAllowLike.Width = 80
        '
        'dcAllowStar
        '
        Me.dcAllowStar.HeaderText = "Allow *"
        Me.dcAllowStar.Name = "dcAllowStar"
        Me.dcAllowStar.Width = 80
        '
        'dcUseDateBetween
        '
        Me.dcUseDateBetween.HeaderText = "Date Between"
        Me.dcUseDateBetween.Name = "dcUseDateBetween"
        Me.dcUseDateBetween.Width = 80
        '
        'dcAllowNull
        '
        Me.dcAllowNull.FalseValue = ""
        Me.dcAllowNull.HeaderText = "Nullable"
        Me.dcAllowNull.Name = "dcAllowNull"
        Me.dcAllowNull.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dcAllowNull.Width = 80
        '
        'gpInfo
        '
        Me.gpInfo.Controls.Add(Me.lblTable)
        Me.gpInfo.Controls.Add(Me.Label2)
        Me.gpInfo.Controls.Add(Me.lblDatabase)
        Me.gpInfo.Controls.Add(Me.Label1)
        Me.gpInfo.Location = New System.Drawing.Point(2, 2)
        Me.gpInfo.Name = "gpInfo"
        Me.gpInfo.Size = New System.Drawing.Size(179, 49)
        Me.gpInfo.TabIndex = 2
        Me.gpInfo.TabStop = False
        Me.gpInfo.Text = "Information"
        '
        'lblTable
        '
        Me.lblTable.AutoSize = True
        Me.lblTable.Location = New System.Drawing.Point(65, 29)
        Me.lblTable.Name = "lblTable"
        Me.lblTable.Size = New System.Drawing.Size(39, 13)
        Me.lblTable.TabIndex = 4
        Me.lblTable.Text = "Label4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Table"
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(65, 16)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(39, 13)
        Me.lblDatabase.TabIndex = 3
        Me.lblDatabase.Text = "Label3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Database"
        '
        'gpSP
        '
        Me.gpSP.Controls.Add(Me.lblSPPrefixWarning)
        Me.gpSP.Controls.Add(Me.txtSPPrefix)
        Me.gpSP.Controls.Add(Me.Label4)
        Me.gpSP.Controls.Add(Me.lblNameSearch)
        Me.gpSP.Controls.Add(Me.lblNameUpdate)
        Me.gpSP.Controls.Add(Me.lblNameGet)
        Me.gpSP.Controls.Add(Me.lblNameDelete)
        Me.gpSP.Controls.Add(Me.lblNameAdd)
        Me.gpSP.Controls.Add(Me.txtTableCaption)
        Me.gpSP.Controls.Add(Me.Label3)
        Me.gpSP.Controls.Add(Me.chkScriptSearch)
        Me.gpSP.Controls.Add(Me.chkScriptAdd)
        Me.gpSP.Controls.Add(Me.chkScriptUpdate)
        Me.gpSP.Controls.Add(Me.chkScriptDelete)
        Me.gpSP.Controls.Add(Me.chkScriptGet)
        Me.gpSP.Location = New System.Drawing.Point(3, 3)
        Me.gpSP.Name = "gpSP"
        Me.gpSP.Size = New System.Drawing.Size(176, 248)
        Me.gpSP.TabIndex = 3
        Me.gpSP.TabStop = False
        Me.gpSP.Text = "Stored Procedure"
        '
        'lblSPPrefixWarning
        '
        Me.lblSPPrefixWarning.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSPPrefixWarning.ForeColor = System.Drawing.Color.Red
        Me.lblSPPrefixWarning.Location = New System.Drawing.Point(3, 189)
        Me.lblSPPrefixWarning.Name = "lblSPPrefixWarning"
        Me.lblSPPrefixWarning.Size = New System.Drawing.Size(170, 56)
        Me.lblSPPrefixWarning.TabIndex = 2
        Me.lblSPPrefixWarning.Text = "From MSDN: We recommend that you do not create any stored procedures using sp_ as" & _
            " a prefix."
        Me.lblSPPrefixWarning.Visible = False
        '
        'txtSPPrefix
        '
        Me.txtSPPrefix.Location = New System.Drawing.Point(6, 166)
        Me.txtSPPrefix.Name = "txtSPPrefix"
        Me.txtSPPrefix.Size = New System.Drawing.Size(164, 20)
        Me.txtSPPrefix.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Stored Procedure Prefix"
        '
        'lblNameSearch
        '
        Me.lblNameSearch.AutoSize = True
        Me.lblNameSearch.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblNameSearch.ForeColor = System.Drawing.Color.Blue
        Me.lblNameSearch.Location = New System.Drawing.Point(65, 92)
        Me.lblNameSearch.Name = "lblNameSearch"
        Me.lblNameSearch.Size = New System.Drawing.Size(13, 13)
        Me.lblNameSearch.TabIndex = 12
        Me.lblNameSearch.Text = "()"
        '
        'lblNameUpdate
        '
        Me.lblNameUpdate.AutoSize = True
        Me.lblNameUpdate.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblNameUpdate.ForeColor = System.Drawing.Color.Blue
        Me.lblNameUpdate.Location = New System.Drawing.Point(65, 74)
        Me.lblNameUpdate.Name = "lblNameUpdate"
        Me.lblNameUpdate.Size = New System.Drawing.Size(13, 13)
        Me.lblNameUpdate.TabIndex = 11
        Me.lblNameUpdate.Text = "()"
        '
        'lblNameGet
        '
        Me.lblNameGet.AutoSize = True
        Me.lblNameGet.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblNameGet.ForeColor = System.Drawing.Color.Blue
        Me.lblNameGet.Location = New System.Drawing.Point(65, 56)
        Me.lblNameGet.Name = "lblNameGet"
        Me.lblNameGet.Size = New System.Drawing.Size(13, 13)
        Me.lblNameGet.TabIndex = 10
        Me.lblNameGet.Text = "()"
        '
        'lblNameDelete
        '
        Me.lblNameDelete.AutoSize = True
        Me.lblNameDelete.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblNameDelete.ForeColor = System.Drawing.Color.Blue
        Me.lblNameDelete.Location = New System.Drawing.Point(65, 38)
        Me.lblNameDelete.Name = "lblNameDelete"
        Me.lblNameDelete.Size = New System.Drawing.Size(13, 13)
        Me.lblNameDelete.TabIndex = 9
        Me.lblNameDelete.Text = "()"
        '
        'lblNameAdd
        '
        Me.lblNameAdd.AutoSize = True
        Me.lblNameAdd.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblNameAdd.ForeColor = System.Drawing.Color.Blue
        Me.lblNameAdd.Location = New System.Drawing.Point(65, 20)
        Me.lblNameAdd.Name = "lblNameAdd"
        Me.lblNameAdd.Size = New System.Drawing.Size(13, 13)
        Me.lblNameAdd.TabIndex = 2
        Me.lblNameAdd.Text = "()"
        '
        'txtTableCaption
        '
        Me.txtTableCaption.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTableCaption.Location = New System.Drawing.Point(6, 127)
        Me.txtTableCaption.Name = "txtTableCaption"
        Me.txtTableCaption.Size = New System.Drawing.Size(164, 20)
        Me.txtTableCaption.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Table Caption"
        '
        'chkScriptSearch
        '
        Me.chkScriptSearch.AutoSize = True
        Me.chkScriptSearch.Location = New System.Drawing.Point(6, 91)
        Me.chkScriptSearch.Name = "chkScriptSearch"
        Me.chkScriptSearch.Size = New System.Drawing.Size(60, 17)
        Me.chkScriptSearch.TabIndex = 8
        Me.chkScriptSearch.Text = "Search"
        Me.chkScriptSearch.UseVisualStyleBackColor = True
        '
        'chkScriptAdd
        '
        Me.chkScriptAdd.AutoSize = True
        Me.chkScriptAdd.Location = New System.Drawing.Point(6, 19)
        Me.chkScriptAdd.Name = "chkScriptAdd"
        Me.chkScriptAdd.Size = New System.Drawing.Size(45, 17)
        Me.chkScriptAdd.TabIndex = 4
        Me.chkScriptAdd.Text = "Add"
        Me.chkScriptAdd.UseVisualStyleBackColor = True
        '
        'chkScriptUpdate
        '
        Me.chkScriptUpdate.AutoSize = True
        Me.chkScriptUpdate.Location = New System.Drawing.Point(6, 73)
        Me.chkScriptUpdate.Name = "chkScriptUpdate"
        Me.chkScriptUpdate.Size = New System.Drawing.Size(61, 17)
        Me.chkScriptUpdate.TabIndex = 7
        Me.chkScriptUpdate.Text = "Update"
        Me.chkScriptUpdate.UseVisualStyleBackColor = True
        '
        'chkScriptDelete
        '
        Me.chkScriptDelete.AutoSize = True
        Me.chkScriptDelete.Location = New System.Drawing.Point(6, 37)
        Me.chkScriptDelete.Name = "chkScriptDelete"
        Me.chkScriptDelete.Size = New System.Drawing.Size(57, 17)
        Me.chkScriptDelete.TabIndex = 5
        Me.chkScriptDelete.Text = "Delete"
        Me.chkScriptDelete.UseVisualStyleBackColor = True
        '
        'chkScriptGet
        '
        Me.chkScriptGet.AutoSize = True
        Me.chkScriptGet.Location = New System.Drawing.Point(6, 55)
        Me.chkScriptGet.Name = "chkScriptGet"
        Me.chkScriptGet.Size = New System.Drawing.Size(43, 17)
        Me.chkScriptGet.TabIndex = 6
        Me.chkScriptGet.Text = "Get"
        Me.chkScriptGet.UseVisualStyleBackColor = True
        '
        'btnScriptToWindow
        '
        Me.btnScriptToWindow.Location = New System.Drawing.Point(3, 332)
        Me.btnScriptToWindow.Name = "btnScriptToWindow"
        Me.btnScriptToWindow.Size = New System.Drawing.Size(167, 23)
        Me.btnScriptToWindow.TabIndex = 4
        Me.btnScriptToWindow.Text = "Script to Window"
        Me.btnScriptToWindow.UseVisualStyleBackColor = True
        '
        'btnScript
        '
        Me.btnScript.Location = New System.Drawing.Point(3, 303)
        Me.btnScript.Name = "btnScript"
        Me.btnScript.Size = New System.Drawing.Size(167, 23)
        Me.btnScript.TabIndex = 4
        Me.btnScript.Text = "Script and Execute"
        Me.btnScript.UseVisualStyleBackColor = True
        Me.btnScript.Visible = False
        '
        'gpOption
        '
        Me.gpOption.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpOption.Controls.Add(Me.dgResult)
        Me.gpOption.Location = New System.Drawing.Point(187, 2)
        Me.gpOption.Name = "gpOption"
        Me.gpOption.Size = New System.Drawing.Size(595, 561)
        Me.gpOption.TabIndex = 4
        Me.gpOption.TabStop = False
        Me.gpOption.Text = "Script Option"
        Me.gpOption.Visible = False
        '
        'radShowSP
        '
        Me.radShowSP.Appearance = System.Windows.Forms.Appearance.Button
        Me.radShowSP.Checked = True
        Me.radShowSP.Location = New System.Drawing.Point(2, 57)
        Me.radShowSP.Name = "radShowSP"
        Me.radShowSP.Size = New System.Drawing.Size(179, 24)
        Me.radShowSP.TabIndex = 2
        Me.radShowSP.TabStop = True
        Me.radShowSP.Text = "Script Stored Procedure"
        Me.radShowSP.UseVisualStyleBackColor = True
        '
        'radShowSQL
        '
        Me.radShowSQL.Appearance = System.Windows.Forms.Appearance.Button
        Me.radShowSQL.Location = New System.Drawing.Point(2, 81)
        Me.radShowSQL.Name = "radShowSQL"
        Me.radShowSQL.Size = New System.Drawing.Size(179, 24)
        Me.radShowSQL.TabIndex = 6
        Me.radShowSQL.Text = "Script SQL"
        Me.radShowSQL.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.gpSP)
        Me.FlowLayoutPanel1.Controls.Add(Me.gpSQL)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnScript)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnScriptToWindow)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(2, 111)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(185, 452)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'gpSQL
        '
        Me.gpSQL.Controls.Add(Me.txtTableAlias)
        Me.gpSQL.Controls.Add(Me.Label5)
        Me.gpSQL.Location = New System.Drawing.Point(3, 257)
        Me.gpSQL.Name = "gpSQL"
        Me.gpSQL.Size = New System.Drawing.Size(176, 40)
        Me.gpSQL.TabIndex = 2
        Me.gpSQL.TabStop = False
        Me.gpSQL.Text = "SQL"
        '
        'txtTableAlias
        '
        Me.txtTableAlias.Location = New System.Drawing.Point(38, 13)
        Me.txtTableAlias.Name = "txtTableAlias"
        Me.txtTableAlias.Size = New System.Drawing.Size(132, 20)
        Me.txtTableAlias.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Alias"
        '
        'frm_SQLSyn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.radShowSQL)
        Me.Controls.Add(Me.gpOption)
        Me.Controls.Add(Me.radShowSP)
        Me.Controls.Add(Me.gpInfo)
        Me.Name = "frm_SQLSyn"
        Me.Text = "Query Synthesizer"
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpInfo.ResumeLayout(False)
        Me.gpInfo.PerformLayout()
        Me.gpSP.ResumeLayout(False)
        Me.gpSP.PerformLayout()
        Me.gpOption.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.gpSQL.ResumeLayout(False)
        Me.gpSQL.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgResult As CHKControl.GridView.DbDataGrid
    Friend WithEvents gpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblTable As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpSP As System.Windows.Forms.GroupBox
    Friend WithEvents chkScriptAdd As System.Windows.Forms.CheckBox
    Friend WithEvents chkScriptDelete As System.Windows.Forms.CheckBox
    Friend WithEvents chkScriptGet As System.Windows.Forms.CheckBox
    Friend WithEvents chkScriptUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents chkScriptSearch As System.Windows.Forms.CheckBox
    Friend WithEvents btnScriptToWindow As System.Windows.Forms.Button
    Friend WithEvents btnScript As System.Windows.Forms.Button
    Friend WithEvents txtTableCaption As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gpOption As System.Windows.Forms.GroupBox
    Friend WithEvents lblNameAdd As System.Windows.Forms.Label
    Friend WithEvents lblNameSearch As System.Windows.Forms.Label
    Friend WithEvents lblNameUpdate As System.Windows.Forms.Label
    Friend WithEvents lblNameGet As System.Windows.Forms.Label
    Friend WithEvents lblNameDelete As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSPPrefix As System.Windows.Forms.TextBox
    Friend WithEvents lblSPPrefixWarning As System.Windows.Forms.Label
    Friend WithEvents radShowSP As System.Windows.Forms.RadioButton
    Friend WithEvents radShowSQL As System.Windows.Forms.RadioButton
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents gpSQL As System.Windows.Forms.GroupBox
    Friend WithEvents txtTableAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dcAllowSearch As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcVariableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcAllowLike As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcAllowStar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcUseDateBetween As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcAllowNull As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
