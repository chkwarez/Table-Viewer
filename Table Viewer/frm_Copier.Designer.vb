<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Copier
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblStatistics1 = New System.Windows.Forms.Label()
        Me.lvwTable1 = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ddDatabase1 = New System.Windows.Forms.ComboBox()
        Me.ddConnectionString1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkCreateAtDestination = New System.Windows.Forms.CheckBox()
        Me.lblStatistics2 = New System.Windows.Forms.Label()
        Me.lvwTable2 = New System.Windows.Forms.ListView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ddDatabase2 = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnShowConnWizard2 = New System.Windows.Forms.Button()
        Me.btnShowConnWizard1 = New System.Windows.Forms.Button()
        Me.btnNextStep1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ddConnectionString2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkTruncateDestination = New System.Windows.Forms.CheckBox()
        Me.btnDeleteAction = New System.Windows.Forms.Button()
        Me.lvwAction = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddAction = New System.Windows.Forms.Button()
        Me.btnBack2 = New System.Windows.Forms.Button()
        Me.btnNext2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.txtResult = New System.Windows.Forms.RichTextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblStatistics1)
        Me.GroupBox1.Controls.Add(Me.lvwTable1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ddDatabase1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(838, 183)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Server 1"
        '
        'lblStatistics1
        '
        Me.lblStatistics1.AutoSize = True
        Me.lblStatistics1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblStatistics1.Location = New System.Drawing.Point(6, 66)
        Me.lblStatistics1.Name = "lblStatistics1"
        Me.lblStatistics1.Size = New System.Drawing.Size(49, 13)
        Me.lblStatistics1.TabIndex = 35
        Me.lblStatistics1.Text = "Statistics"
        '
        'lvwTable1
        '
        Me.lvwTable1.FullRowSelect = True
        Me.lvwTable1.HideSelection = False
        Me.lvwTable1.Location = New System.Drawing.Point(82, 42)
        Me.lvwTable1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvwTable1.Name = "lvwTable1"
        Me.lvwTable1.Size = New System.Drawing.Size(750, 132)
        Me.lvwTable1.TabIndex = 29
        Me.lvwTable1.UseCompatibleStateImageBehavior = False
        Me.lvwTable1.View = System.Windows.Forms.View.List
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 14)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Database"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 14)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Tables"
        '
        'ddDatabase1
        '
        Me.ddDatabase1.DropDownHeight = 250
        Me.ddDatabase1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddDatabase1.FormattingEnabled = True
        Me.ddDatabase1.IntegralHeight = False
        Me.ddDatabase1.ItemHeight = 13
        Me.ddDatabase1.Location = New System.Drawing.Point(82, 13)
        Me.ddDatabase1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ddDatabase1.Name = "ddDatabase1"
        Me.ddDatabase1.Size = New System.Drawing.Size(518, 21)
        Me.ddDatabase1.TabIndex = 28
        '
        'ddConnectionString1
        '
        Me.ddConnectionString1.FormattingEnabled = True
        Me.ddConnectionString1.Location = New System.Drawing.Point(152, 30)
        Me.ddConnectionString1.Name = "ddConnectionString1"
        Me.ddConnectionString1.Size = New System.Drawing.Size(663, 21)
        Me.ddConnectionString1.TabIndex = 26
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCreateAtDestination)
        Me.GroupBox2.Controls.Add(Me.lblStatistics2)
        Me.GroupBox2.Controls.Add(Me.lvwTable2)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.ddDatabase2)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 211)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(838, 210)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Server 2"
        '
        'chkCreateAtDestination
        '
        Me.chkCreateAtDestination.AutoSize = True
        Me.chkCreateAtDestination.Location = New System.Drawing.Point(82, 181)
        Me.chkCreateAtDestination.Name = "chkCreateAtDestination"
        Me.chkCreateAtDestination.Size = New System.Drawing.Size(233, 17)
        Me.chkCreateAtDestination.TabIndex = 42
        Me.chkCreateAtDestination.Text = "Copy as new table with basic table structure"
        Me.chkCreateAtDestination.UseVisualStyleBackColor = True
        '
        'lblStatistics2
        '
        Me.lblStatistics2.AutoSize = True
        Me.lblStatistics2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblStatistics2.Location = New System.Drawing.Point(6, 66)
        Me.lblStatistics2.Name = "lblStatistics2"
        Me.lblStatistics2.Size = New System.Drawing.Size(49, 13)
        Me.lblStatistics2.TabIndex = 41
        Me.lblStatistics2.Text = "Statistics"
        '
        'lvwTable2
        '
        Me.lvwTable2.FullRowSelect = True
        Me.lvwTable2.HideSelection = False
        Me.lvwTable2.Location = New System.Drawing.Point(82, 42)
        Me.lvwTable2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvwTable2.Name = "lvwTable2"
        Me.lvwTable2.Size = New System.Drawing.Size(750, 132)
        Me.lvwTable2.TabIndex = 37
        Me.lvwTable2.UseCompatibleStateImageBehavior = False
        Me.lvwTable2.View = System.Windows.Forms.View.List
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 14)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Database"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 14)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Tables"
        '
        'ddDatabase2
        '
        Me.ddDatabase2.DropDownHeight = 250
        Me.ddDatabase2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddDatabase2.FormattingEnabled = True
        Me.ddDatabase2.IntegralHeight = False
        Me.ddDatabase2.ItemHeight = 13
        Me.ddDatabase2.Location = New System.Drawing.Point(82, 13)
        Me.ddDatabase2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ddDatabase2.Name = "ddDatabase2"
        Me.ddDatabase2.Size = New System.Drawing.Size(518, 21)
        Me.ddDatabase2.TabIndex = 36
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(860, 609)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnShowConnWizard2)
        Me.TabPage1.Controls.Add(Me.btnShowConnWizard1)
        Me.TabPage1.Controls.Add(Me.btnNextStep1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.ddConnectionString2)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.ddConnectionString1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(852, 583)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Step 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnShowConnWizard2
        '
        Me.btnShowConnWizard2.Location = New System.Drawing.Point(728, 143)
        Me.btnShowConnWizard2.Name = "btnShowConnWizard2"
        Me.btnShowConnWizard2.Size = New System.Drawing.Size(87, 30)
        Me.btnShowConnWizard2.TabIndex = 31
        Me.btnShowConnWizard2.Text = "Connections"
        Me.btnShowConnWizard2.UseVisualStyleBackColor = True
        '
        'btnShowConnWizard1
        '
        Me.btnShowConnWizard1.Location = New System.Drawing.Point(728, 52)
        Me.btnShowConnWizard1.Name = "btnShowConnWizard1"
        Me.btnShowConnWizard1.Size = New System.Drawing.Size(87, 30)
        Me.btnShowConnWizard1.TabIndex = 30
        Me.btnShowConnWizard1.Text = "Connections"
        Me.btnShowConnWizard1.UseVisualStyleBackColor = True
        '
        'btnNextStep1
        '
        Me.btnNextStep1.Location = New System.Drawing.Point(701, 221)
        Me.btnNextStep1.Name = "btnNextStep1"
        Me.btnNextStep1.Size = New System.Drawing.Size(114, 38)
        Me.btnNextStep1.TabIndex = 29
        Me.btnNextStep1.Text = "Next"
        Me.btnNextStep1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Server 2 Connection String"
        '
        'ddConnectionString2
        '
        Me.ddConnectionString2.FormattingEnabled = True
        Me.ddConnectionString2.Location = New System.Drawing.Point(152, 120)
        Me.ddConnectionString2.Name = "ddConnectionString2"
        Me.ddConnectionString2.Size = New System.Drawing.Size(663, 21)
        Me.ddConnectionString2.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Server 1 Connection String"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Select Servers"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.btnBack2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.btnNext2)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(852, 583)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Step 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkTruncateDestination)
        Me.GroupBox3.Controls.Add(Me.btnDeleteAction)
        Me.GroupBox3.Controls.Add(Me.lvwAction)
        Me.GroupBox3.Controls.Add(Me.btnAddAction)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 427)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(729, 151)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Actions"
        '
        'chkTruncateDestination
        '
        Me.chkTruncateDestination.AutoSize = True
        Me.chkTruncateDestination.Location = New System.Drawing.Point(598, 71)
        Me.chkTruncateDestination.Name = "chkTruncateDestination"
        Me.chkTruncateDestination.Size = New System.Drawing.Size(125, 17)
        Me.chkTruncateDestination.TabIndex = 35
        Me.chkTruncateDestination.Text = "Truncate Destination"
        Me.chkTruncateDestination.UseVisualStyleBackColor = True
        '
        'btnDeleteAction
        '
        Me.btnDeleteAction.Location = New System.Drawing.Point(599, 123)
        Me.btnDeleteAction.Name = "btnDeleteAction"
        Me.btnDeleteAction.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteAction.TabIndex = 34
        Me.btnDeleteAction.Text = "Delete"
        Me.btnDeleteAction.UseVisualStyleBackColor = True
        '
        'lvwAction
        '
        Me.lvwAction.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvwAction.FullRowSelect = True
        Me.lvwAction.Location = New System.Drawing.Point(6, 19)
        Me.lvwAction.Name = "lvwAction"
        Me.lvwAction.Size = New System.Drawing.Size(587, 126)
        Me.lvwAction.TabIndex = 0
        Me.lvwAction.UseCompatibleStateImageBehavior = False
        Me.lvwAction.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "From"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "To"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Type"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Truncate"
        Me.ColumnHeader4.Width = 85
        '
        'btnAddAction
        '
        Me.btnAddAction.Location = New System.Drawing.Point(599, 94)
        Me.btnAddAction.Name = "btnAddAction"
        Me.btnAddAction.Size = New System.Drawing.Size(75, 23)
        Me.btnAddAction.TabIndex = 33
        Me.btnAddAction.Text = "Add"
        Me.btnAddAction.UseVisualStyleBackColor = True
        '
        'btnBack2
        '
        Me.btnBack2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack2.Location = New System.Drawing.Point(770, 528)
        Me.btnBack2.Name = "btnBack2"
        Me.btnBack2.Size = New System.Drawing.Size(75, 23)
        Me.btnBack2.TabIndex = 31
        Me.btnBack2.Text = "Back"
        Me.btnBack2.UseVisualStyleBackColor = True
        '
        'btnNext2
        '
        Me.btnNext2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext2.Location = New System.Drawing.Point(770, 557)
        Me.btnNext2.Name = "btnNext2"
        Me.btnNext2.Size = New System.Drawing.Size(75, 23)
        Me.btnNext2.TabIndex = 30
        Me.btnNext2.Text = "Next"
        Me.btnNext2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 20)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Select Objects"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnExecute)
        Me.TabPage3.Controls.Add(Me.txtResult)
        Me.TabPage3.Controls.Add(Me.ProgressBar1)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(852, 583)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Step 3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.Location = New System.Drawing.Point(717, 531)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(128, 46)
        Me.btnExecute.TabIndex = 6
        Me.btnExecute.Text = "Execute"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResult.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResult.Location = New System.Drawing.Point(7, 27)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(838, 469)
        Me.txtResult.TabIndex = 5
        Me.txtResult.Text = ""
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(7, 502)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(838, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Action"
        '
        'frm_Copier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 612)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_Copier"
        Me.Text = "Copy Database"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatistics1 As System.Windows.Forms.Label
    Friend WithEvents ddConnectionString1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvwTable1 As System.Windows.Forms.ListView
    Friend WithEvents ddDatabase1 As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ddConnectionString2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnNextStep1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBack2 As System.Windows.Forms.Button
    Friend WithEvents btnNext2 As System.Windows.Forms.Button
    Friend WithEvents lblStatistics2 As System.Windows.Forms.Label
    Friend WithEvents lvwTable2 As System.Windows.Forms.ListView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ddDatabase2 As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents txtResult As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lvwAction As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnDeleteAction As System.Windows.Forms.Button
    Friend WithEvents btnAddAction As System.Windows.Forms.Button
    Friend WithEvents chkTruncateDestination As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents chkCreateAtDestination As System.Windows.Forms.CheckBox
    Friend WithEvents btnShowConnWizard2 As Button
    Friend WithEvents btnShowConnWizard1 As Button
End Class
