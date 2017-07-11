<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ASPSyn
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgASP = New CHKControl.ExtendedDataGridView
        Me.dcColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcDataType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcSystemDataType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcControlType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcControlPrefix = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcControlID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcControlAttribute = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcControlDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.btnScript = New System.Windows.Forms.Button
        Me.btnScript2 = New System.Windows.Forms.Button
        Me.btnScript4 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabGeneral = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgGeneral = New CHKControl.ExtendedDataGridView
        Me.dcGeneralColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcGeneralDataType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcGeneralSystemDataType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcGeneralAllowNull = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tabASP = New System.Windows.Forms.TabPage
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnScript5 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.tabBLL = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.chkAutoSize = New System.Windows.Forms.CheckBox
        Me.btnGenerateBLL = New System.Windows.Forms.Button
        Me.txtBLLTemplatePath = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgBLL = New CHKControl.ExtendedDataGridView
        Me.dcBLLVariable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcBLLDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcBLLValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tabCode = New System.Windows.Forms.TabPage
        Me.txtCode = New System.Windows.Forms.RichTextBox
        Me.cmdgOpen = New System.Windows.Forms.OpenFileDialog
        Me.radVB = New System.Windows.Forms.RadioButton
        Me.radCSharp = New System.Windows.Forms.RadioButton
        CType(Me.dgASP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        CType(Me.dgGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabASP.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tabBLL.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgBLL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCode.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgASP
        '
        Me.dgASP.AllowUserToAddRows = False
        Me.dgASP.AllowUserToDeleteRows = False
        Me.dgASP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgASP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgASP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcColumnName, Me.dcDataType, Me.dcSystemDataType, Me.dcControlType, Me.dcControlPrefix, Me.dcControlID, Me.dcControlAttribute, Me.dcControlDesc})
        Me.dgASP.Location = New System.Drawing.Point(0, 0)
        Me.dgASP.Name = "dgASP"
        Me.dgASP.RowHeadersVisible = False
        Me.dgASP.RowTemplate.Height = 24
        Me.dgASP.ShowCellErrors = False
        Me.dgASP.ShowCellToolTips = False
        Me.dgASP.ShowEditingIcon = False
        Me.dgASP.ShowRowErrors = False
        Me.dgASP.Size = New System.Drawing.Size(698, 602)
        Me.dgASP.TabIndex = 0
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
        Me.dcDataType.Visible = False
        '
        'dcSystemDataType
        '
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Gray
        Me.dcSystemDataType.DefaultCellStyle = DataGridViewCellStyle9
        Me.dcSystemDataType.HeaderText = ".NET"
        Me.dcSystemDataType.Name = "dcSystemDataType"
        Me.dcSystemDataType.ReadOnly = True
        Me.dcSystemDataType.Width = 80
        '
        'dcControlType
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dcControlType.DefaultCellStyle = DataGridViewCellStyle10
        Me.dcControlType.HeaderText = "Control Type"
        Me.dcControlType.Name = "dcControlType"
        '
        'dcControlPrefix
        '
        Me.dcControlPrefix.HeaderText = "Control Prefix"
        Me.dcControlPrefix.Name = "dcControlPrefix"
        '
        'dcControlID
        '
        Me.dcControlID.HeaderText = "Control ID"
        Me.dcControlID.Name = "dcControlID"
        Me.dcControlID.Width = 120
        '
        'dcControlAttribute
        '
        Me.dcControlAttribute.HeaderText = "Attribute"
        Me.dcControlAttribute.Name = "dcControlAttribute"
        '
        'dcControlDesc
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dcControlDesc.DefaultCellStyle = DataGridViewCellStyle11
        Me.dcControlDesc.HeaderText = "Text"
        Me.dcControlDesc.Name = "dcControlDesc"
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(74, 6)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.ReadOnly = True
        Me.txtTableName.Size = New System.Drawing.Size(155, 20)
        Me.txtTableName.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Table Name"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(235, 9)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 14)
        Me.lblStatus.TabIndex = 22
        Me.lblStatus.Text = "Status"
        '
        'btnScript
        '
        Me.btnScript.Location = New System.Drawing.Point(6, 22)
        Me.btnScript.Name = "btnScript"
        Me.btnScript.Size = New System.Drawing.Size(150, 23)
        Me.btnScript.TabIndex = 23
        Me.btnScript.Text = "Control (Entry)"
        Me.btnScript.UseVisualStyleBackColor = True
        '
        'btnScript2
        '
        Me.btnScript2.Location = New System.Drawing.Point(6, 51)
        Me.btnScript2.Name = "btnScript2"
        Me.btnScript2.Size = New System.Drawing.Size(150, 23)
        Me.btnScript2.TabIndex = 25
        Me.btnScript2.Text = "Control Databind"
        Me.btnScript2.UseVisualStyleBackColor = True
        '
        'btnScript4
        '
        Me.btnScript4.Location = New System.Drawing.Point(6, 80)
        Me.btnScript4.Name = "btnScript4"
        Me.btnScript4.Size = New System.Drawing.Size(150, 23)
        Me.btnScript4.TabIndex = 30
        Me.btnScript4.Text = "ODS Select Parameter"
        Me.btnScript4.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabGeneral)
        Me.TabControl1.Controls.Add(Me.tabASP)
        Me.TabControl1.Controls.Add(Me.tabBLL)
        Me.TabControl1.Controls.Add(Me.tabCode)
        Me.TabControl1.Location = New System.Drawing.Point(4, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(927, 629)
        Me.TabControl1.TabIndex = 32
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.Panel2)
        Me.tabGeneral.Controls.Add(Me.dgGeneral)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 23)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGeneral.Size = New System.Drawing.Size(919, 602)
        Me.tabGeneral.TabIndex = 3
        Me.tabGeneral.Text = "General"
        Me.tabGeneral.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Location = New System.Drawing.Point(704, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(215, 606)
        Me.Panel2.TabIndex = 6
        '
        'dgGeneral
        '
        Me.dgGeneral.AllowUserToAddRows = False
        Me.dgGeneral.AllowUserToDeleteRows = False
        Me.dgGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgGeneral.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcGeneralColumnName, Me.dcGeneralDataType, Me.dcGeneralSystemDataType, Me.dcGeneralAllowNull})
        Me.dgGeneral.Location = New System.Drawing.Point(0, 0)
        Me.dgGeneral.Name = "dgGeneral"
        Me.dgGeneral.RowHeadersVisible = False
        Me.dgGeneral.RowTemplate.Height = 24
        Me.dgGeneral.ShowCellErrors = False
        Me.dgGeneral.ShowCellToolTips = False
        Me.dgGeneral.ShowEditingIcon = False
        Me.dgGeneral.ShowRowErrors = False
        Me.dgGeneral.Size = New System.Drawing.Size(698, 602)
        Me.dgGeneral.TabIndex = 1
        '
        'dcGeneralColumnName
        '
        Me.dcGeneralColumnName.HeaderText = "Column Name"
        Me.dcGeneralColumnName.Name = "dcGeneralColumnName"
        Me.dcGeneralColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dcGeneralDataType
        '
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Gray
        Me.dcGeneralDataType.DefaultCellStyle = DataGridViewCellStyle12
        Me.dcGeneralDataType.HeaderText = "Data Type"
        Me.dcGeneralDataType.Name = "dcGeneralDataType"
        Me.dcGeneralDataType.ReadOnly = True
        '
        'dcGeneralSystemDataType
        '
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Gray
        Me.dcGeneralSystemDataType.DefaultCellStyle = DataGridViewCellStyle13
        Me.dcGeneralSystemDataType.HeaderText = ".NET"
        Me.dcGeneralSystemDataType.Name = "dcGeneralSystemDataType"
        Me.dcGeneralSystemDataType.ReadOnly = True
        Me.dcGeneralSystemDataType.Width = 80
        '
        'dcGeneralAllowNull
        '
        Me.dcGeneralAllowNull.HeaderText = "Allow Null"
        Me.dcGeneralAllowNull.Name = "dcGeneralAllowNull"
        '
        'tabASP
        '
        Me.tabASP.Controls.Add(Me.Panel3)
        Me.tabASP.Controls.Add(Me.dgASP)
        Me.tabASP.Location = New System.Drawing.Point(4, 23)
        Me.tabASP.Name = "tabASP"
        Me.tabASP.Padding = New System.Windows.Forms.Padding(3)
        Me.tabASP.Size = New System.Drawing.Size(919, 602)
        Me.tabASP.TabIndex = 0
        Me.tabASP.Text = "ASP"
        Me.tabASP.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.btnScript5)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.btnScript)
        Me.Panel3.Controls.Add(Me.btnScript2)
        Me.Panel3.Controls.Add(Me.btnScript4)
        Me.Panel3.Location = New System.Drawing.Point(704, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(215, 606)
        Me.Panel3.TabIndex = 6
        '
        'btnScript5
        '
        Me.btnScript5.Location = New System.Drawing.Point(6, 109)
        Me.btnScript5.Name = "btnScript5"
        Me.btnScript5.Size = New System.Drawing.Size(150, 23)
        Me.btnScript5.TabIndex = 32
        Me.btnScript5.Text = "Control (GridView)"
        Me.btnScript5.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Generate"
        '
        'tabBLL
        '
        Me.tabBLL.Controls.Add(Me.Panel1)
        Me.tabBLL.Controls.Add(Me.dgBLL)
        Me.tabBLL.Location = New System.Drawing.Point(4, 23)
        Me.tabBLL.Name = "tabBLL"
        Me.tabBLL.Size = New System.Drawing.Size(919, 602)
        Me.tabBLL.TabIndex = 2
        Me.tabBLL.Text = "Business Logic Layer"
        Me.tabBLL.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.radCSharp)
        Me.Panel1.Controls.Add(Me.radVB)
        Me.Panel1.Controls.Add(Me.btnBrowse)
        Me.Panel1.Controls.Add(Me.chkAutoSize)
        Me.Panel1.Controls.Add(Me.btnGenerateBLL)
        Me.Panel1.Controls.Add(Me.txtBLLTemplatePath)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(704, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(215, 606)
        Me.Panel1.TabIndex = 5
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(188, 47)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 23)
        Me.btnBrowse.TabIndex = 5
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'chkAutoSize
        '
        Me.chkAutoSize.AutoSize = True
        Me.chkAutoSize.Location = New System.Drawing.Point(6, 3)
        Me.chkAutoSize.Name = "chkAutoSize"
        Me.chkAutoSize.Size = New System.Drawing.Size(73, 18)
        Me.chkAutoSize.TabIndex = 1
        Me.chkAutoSize.Text = "Auto Size"
        Me.chkAutoSize.UseVisualStyleBackColor = True
        '
        'btnGenerateBLL
        '
        Me.btnGenerateBLL.Location = New System.Drawing.Point(6, 74)
        Me.btnGenerateBLL.Name = "btnGenerateBLL"
        Me.btnGenerateBLL.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerateBLL.TabIndex = 4
        Me.btnGenerateBLL.Text = "Generate"
        Me.btnGenerateBLL.UseVisualStyleBackColor = True
        '
        'txtBLLTemplatePath
        '
        Me.txtBLLTemplatePath.Location = New System.Drawing.Point(6, 48)
        Me.txtBLLTemplatePath.Name = "txtBLLTemplatePath"
        Me.txtBLLTemplatePath.Size = New System.Drawing.Size(180, 20)
        Me.txtBLLTemplatePath.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "BLL Template"
        '
        'dgBLL
        '
        Me.dgBLL.AllowUserToAddRows = False
        Me.dgBLL.AllowUserToDeleteRows = False
        Me.dgBLL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgBLL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBLL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcBLLVariable, Me.dcBLLDesc, Me.dcBLLValue})
        Me.dgBLL.Location = New System.Drawing.Point(0, 0)
        Me.dgBLL.Name = "dgBLL"
        Me.dgBLL.RowHeadersVisible = False
        Me.dgBLL.Size = New System.Drawing.Size(698, 602)
        Me.dgBLL.TabIndex = 0
        '
        'dcBLLVariable
        '
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Gray
        Me.dcBLLVariable.DefaultCellStyle = DataGridViewCellStyle14
        Me.dcBLLVariable.HeaderText = "Variable"
        Me.dcBLLVariable.Name = "dcBLLVariable"
        Me.dcBLLVariable.ReadOnly = True
        Me.dcBLLVariable.Width = 70
        '
        'dcBLLDesc
        '
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Purple
        Me.dcBLLDesc.DefaultCellStyle = DataGridViewCellStyle15
        Me.dcBLLDesc.HeaderText = "Description"
        Me.dcBLLDesc.Name = "dcBLLDesc"
        Me.dcBLLDesc.ReadOnly = True
        Me.dcBLLDesc.Width = 150
        '
        'dcBLLValue
        '
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dcBLLValue.DefaultCellStyle = DataGridViewCellStyle16
        Me.dcBLLValue.HeaderText = "Value"
        Me.dcBLLValue.Name = "dcBLLValue"
        Me.dcBLLValue.Width = 450
        '
        'tabCode
        '
        Me.tabCode.Controls.Add(Me.txtCode)
        Me.tabCode.Location = New System.Drawing.Point(4, 23)
        Me.tabCode.Name = "tabCode"
        Me.tabCode.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCode.Size = New System.Drawing.Size(919, 602)
        Me.tabCode.TabIndex = 1
        Me.tabCode.Text = "Code"
        Me.tabCode.UseVisualStyleBackColor = True
        '
        'txtCode
        '
        Me.txtCode.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCode.Location = New System.Drawing.Point(4, 3)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(909, 596)
        Me.txtCode.TabIndex = 25
        Me.txtCode.Text = ""
        Me.txtCode.WordWrap = False
        '
        'radVB
        '
        Me.radVB.AutoSize = True
        Me.radVB.Location = New System.Drawing.Point(50, 113)
        Me.radVB.Name = "radVB"
        Me.radVB.Size = New System.Drawing.Size(85, 18)
        Me.radVB.TabIndex = 6
        Me.radVB.Text = "Visual Basic"
        Me.radVB.UseVisualStyleBackColor = True
        '
        'radCSharp
        '
        Me.radCSharp.AutoSize = True
        Me.radCSharp.Checked = True
        Me.radCSharp.Location = New System.Drawing.Point(6, 113)
        Me.radCSharp.Name = "radCSharp"
        Me.radCSharp.Size = New System.Drawing.Size(38, 18)
        Me.radCSharp.TabIndex = 7
        Me.radCSharp.TabStop = True
        Me.radCSharp.Text = "C#"
        Me.radCSharp.UseVisualStyleBackColor = True
        '
        'frm_ASPSyn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 664)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTableName)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_ASPSyn"
        Me.Text = "ASP Synthesizer"
        CType(Me.dgASP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        CType(Me.dgGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabASP.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tabBLL.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgBLL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCode.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgASP As CHKControl.ExtendedDataGridView
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnScript As System.Windows.Forms.Button
    Friend WithEvents btnScript2 As System.Windows.Forms.Button
    Friend WithEvents btnScript4 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabASP As System.Windows.Forms.TabPage
    Friend WithEvents tabCode As System.Windows.Forms.TabPage
    Friend WithEvents txtCode As System.Windows.Forms.RichTextBox
    Friend WithEvents tabBLL As System.Windows.Forms.TabPage
    Friend WithEvents dgBLL As CHKControl.ExtendedDataGridView
    Friend WithEvents chkAutoSize As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnGenerateBLL As System.Windows.Forms.Button
    Friend WithEvents txtBLLTemplatePath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents dcBLLVariable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcBLLDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcBLLValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents dgGeneral As CHKControl.ExtendedDataGridView
    Friend WithEvents dcGeneralColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcGeneralDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcGeneralSystemDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcGeneralAllowNull As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dcColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcSystemDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcControlType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcControlPrefix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcControlID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcControlAttribute As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcControlDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnScript5 As System.Windows.Forms.Button
    Friend WithEvents radCSharp As System.Windows.Forms.RadioButton
    Friend WithEvents radVB As System.Windows.Forms.RadioButton

End Class
