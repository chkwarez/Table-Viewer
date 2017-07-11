<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AspxGen
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
        Me.dgResult = New CHKControl.GridView.SmartDataGrid()
        Me.dcKey = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dcColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcDataType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcSystemDataType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcNullable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dcReadOnly = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dcCtrlPrefix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcCtrlName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcCtrlValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcParseFunc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcDisplayFunc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcWebControl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcMaxLen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtBindData = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtUnbindData = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtGVInsert = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtGVEdit = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.txtFormView = New System.Windows.Forms.TextBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.txtParameters = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToResizeRows = False
        Me.dgResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcKey, Me.dcColumnName, Me.dcDataType, Me.dcSystemDataType, Me.dcNullable, Me.dcReadOnly, Me.dcCtrlPrefix, Me.dcCtrlName, Me.dcCtrlValue, Me.dcParseFunc, Me.dcDisplayFunc, Me.dcWebControl, Me.dcDesc, Me.dcMaxLen})
        Me.dgResult.GrowRowAtPaste = True
        Me.dgResult.Location = New System.Drawing.Point(3, 3)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.RowHeadersVisible = False
        Me.dgResult.RowTemplate.Height = 24
        Me.dgResult.ShowCellErrors = False
        Me.dgResult.ShowCellToolTips = False
        Me.dgResult.ShowEditingIcon = False
        Me.dgResult.ShowRowErrors = False
        Me.dgResult.Size = New System.Drawing.Size(932, 279)
        Me.dgResult.TabIndex = 1
        '
        'dcKey
        '
        Me.dcKey.FalseValue = ""
        Me.dcKey.HeaderText = "Key"
        Me.dcKey.Name = "dcKey"
        Me.dcKey.ReadOnly = True
        Me.dcKey.Width = 50
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
        Me.dcDataType.HeaderText = "DB Type"
        Me.dcDataType.Name = "dcDataType"
        Me.dcDataType.ReadOnly = True
        Me.dcDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcDataType.Width = 80
        '
        'dcSystemDataType
        '
        Me.dcSystemDataType.HeaderText = "Sys Type"
        Me.dcSystemDataType.Name = "dcSystemDataType"
        Me.dcSystemDataType.ReadOnly = True
        Me.dcSystemDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcSystemDataType.Width = 80
        '
        'dcNullable
        '
        Me.dcNullable.FalseValue = ""
        Me.dcNullable.HeaderText = "Null"
        Me.dcNullable.Name = "dcNullable"
        Me.dcNullable.ReadOnly = True
        Me.dcNullable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dcNullable.Width = 50
        '
        'dcReadOnly
        '
        Me.dcReadOnly.HeaderText = "Read"
        Me.dcReadOnly.Name = "dcReadOnly"
        Me.dcReadOnly.Width = 60
        '
        'dcCtrlPrefix
        '
        Me.dcCtrlPrefix.HeaderText = "Ctrl Prefix"
        Me.dcCtrlPrefix.Name = "dcCtrlPrefix"
        Me.dcCtrlPrefix.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcCtrlPrefix.Width = 80
        '
        'dcCtrlName
        '
        Me.dcCtrlName.HeaderText = "Ctrl Name"
        Me.dcCtrlName.Name = "dcCtrlName"
        Me.dcCtrlName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcCtrlValue
        '
        Me.dcCtrlValue.HeaderText = "Ctrl Value"
        Me.dcCtrlValue.Name = "dcCtrlValue"
        Me.dcCtrlValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcParseFunc
        '
        Me.dcParseFunc.HeaderText = "Parse Func"
        Me.dcParseFunc.Name = "dcParseFunc"
        Me.dcParseFunc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcDisplayFunc
        '
        Me.dcDisplayFunc.HeaderText = "ToString Func"
        Me.dcDisplayFunc.Name = "dcDisplayFunc"
        Me.dcDisplayFunc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcWebControl
        '
        Me.dcWebControl.HeaderText = "WebControl"
        Me.dcWebControl.Name = "dcWebControl"
        Me.dcWebControl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcDesc
        '
        Me.dcDesc.HeaderText = "Description"
        Me.dcDesc.Name = "dcDesc"
        Me.dcDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcMaxLen
        '
        Me.dcMaxLen.HeaderText = "Max Len"
        Me.dcMaxLen.Name = "dcMaxLen"
        Me.dcMaxLen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcMaxLen.Width = 70
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Location = New System.Drawing.Point(3, 334)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(932, 195)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtBindData)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(924, 169)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bind Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtBindData
        '
        Me.txtBindData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBindData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBindData.Location = New System.Drawing.Point(3, 3)
        Me.txtBindData.Multiline = True
        Me.txtBindData.Name = "txtBindData"
        Me.txtBindData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBindData.Size = New System.Drawing.Size(918, 163)
        Me.txtBindData.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtUnbindData)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(924, 169)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Unbind Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtUnbindData
        '
        Me.txtUnbindData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnbindData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUnbindData.Location = New System.Drawing.Point(3, 3)
        Me.txtUnbindData.Multiline = True
        Me.txtUnbindData.Name = "txtUnbindData"
        Me.txtUnbindData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUnbindData.Size = New System.Drawing.Size(918, 163)
        Me.txtUnbindData.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtGVInsert)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(924, 169)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "GV Row Insert"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtGVInsert
        '
        Me.txtGVInsert.BackColor = System.Drawing.Color.LightBlue
        Me.txtGVInsert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGVInsert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGVInsert.Location = New System.Drawing.Point(3, 3)
        Me.txtGVInsert.Multiline = True
        Me.txtGVInsert.Name = "txtGVInsert"
        Me.txtGVInsert.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGVInsert.Size = New System.Drawing.Size(918, 163)
        Me.txtGVInsert.TabIndex = 3
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtGVEdit)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(924, 169)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "GV Row Update"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtGVEdit
        '
        Me.txtGVEdit.BackColor = System.Drawing.Color.LightBlue
        Me.txtGVEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGVEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGVEdit.Location = New System.Drawing.Point(3, 3)
        Me.txtGVEdit.Multiline = True
        Me.txtGVEdit.Name = "txtGVEdit"
        Me.txtGVEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGVEdit.Size = New System.Drawing.Size(918, 163)
        Me.txtGVEdit.TabIndex = 2
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.txtFormView)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(924, 169)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Form View"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'txtFormView
        '
        Me.txtFormView.BackColor = System.Drawing.Color.LightPink
        Me.txtFormView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFormView.Location = New System.Drawing.Point(3, 3)
        Me.txtFormView.Multiline = True
        Me.txtFormView.Name = "txtFormView"
        Me.txtFormView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFormView.Size = New System.Drawing.Size(918, 163)
        Me.txtFormView.TabIndex = 3
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.txtParameters)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(924, 169)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Parameters"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'txtParameters
        '
        Me.txtParameters.BackColor = System.Drawing.Color.Purple
        Me.txtParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtParameters.ForeColor = System.Drawing.Color.White
        Me.txtParameters.Location = New System.Drawing.Point(3, 3)
        Me.txtParameters.Multiline = True
        Me.txtParameters.Name = "txtParameters"
        Me.txtParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtParameters.Size = New System.Drawing.Size(918, 163)
        Me.txtParameters.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 288)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(121, 40)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Language"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(51, 17)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(64, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "VB.NET"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 17)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "C#"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(712, 297)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(95, 31)
        Me.btnGenerate.TabIndex = 4
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnReset.Location = New System.Drawing.Point(170, 298)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 31)
        Me.btnReset.TabIndex = 5
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'frm_AspxGen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 532)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.dgResult)
        Me.Name = "frm_AspxGen"
        Me.Text = "ASPX Code Generator"
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgResult As CHKControl.GridView.SmartDataGrid
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents txtBindData As System.Windows.Forms.TextBox
    Friend WithEvents txtUnbindData As System.Windows.Forms.TextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtGVEdit As System.Windows.Forms.TextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents txtGVInsert As System.Windows.Forms.TextBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents txtFormView As System.Windows.Forms.TextBox
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents txtParameters As System.Windows.Forms.TextBox
    Friend WithEvents dcKey As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcSystemDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcNullable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcReadOnly As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcCtrlPrefix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcCtrlName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcCtrlValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcParseFunc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcDisplayFunc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcWebControl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcMaxLen As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
