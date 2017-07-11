<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Comparer
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
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lvwResult = New CHKControl.ExtendedListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtSuggestQuery = New CHKControl.TextBox.TextEditor()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lnkVWOpenQuery = New System.Windows.Forms.LinkLabel()
        Me.lnkFNOpenQuery = New System.Windows.Forms.LinkLabel()
        Me.lnkSPOpenQuery = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkVWOpenFile = New System.Windows.Forms.LinkLabel()
        Me.lnkFNOpenFile = New System.Windows.Forms.LinkLabel()
        Me.lnkSPOpenFile = New System.Windows.Forms.LinkLabel()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.radCompareByDate = New System.Windows.Forms.RadioButton()
        Me.radCompareByDefinition = New System.Windows.Forms.RadioButton()
        Me.chkCheckTF = New System.Windows.Forms.CheckBox()
        Me.chkCheckSP = New System.Windows.Forms.CheckBox()
        Me.chkCheckFN = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCheckTB = New System.Windows.Forms.CheckBox()
        Me.chkSkipDeleteDestTable = New System.Windows.Forms.CheckBox()
        Me.chkCheckVW = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOpenSuggestQuery = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ddSource = New CHKControl.ExtendedComboBox()
        Me.ddDest = New CHKControl.ExtendedComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExchange = New System.Windows.Forms.Button()
        Me.bwLogic = New System.ComponentModel.BackgroundWorker()
        Me.ddDestConnectionString = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCompare
        '
        Me.btnCompare.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnCompare.Location = New System.Drawing.Point(661, -1)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(102, 30)
        Me.btnCompare.TabIndex = 0
        Me.btnCompare.Text = "Compare"
        Me.btnCompare.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 73)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(937, 413)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lvwResult)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(929, 387)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Comparison Result"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lvwResult
        '
        Me.lvwResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwResult.CheckedTagIds = New Integer(-1) {}
        Me.lvwResult.CheckedTagValues = New String(-1) {}
        Me.lvwResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader5, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader3})
        Me.lvwResult.FullRowSelect = True
        Me.lvwResult.GridLines = True
        Me.lvwResult.Location = New System.Drawing.Point(3, 3)
        Me.lvwResult.Name = "lvwResult"
        Me.lvwResult.SelectedTag = Nothing
        Me.lvwResult.SelectedTagId = -2147483648
        Me.lvwResult.SelectedTagValue = Nothing
        Me.lvwResult.Size = New System.Drawing.Size(920, 378)
        Me.lvwResult.TabIndex = 0
        Me.lvwResult.UseCompatibleStateImageBehavior = False
        Me.lvwResult.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Table"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Column"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Database 1"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Database 2"
        Me.ColumnHeader4.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Description"
        Me.ColumnHeader3.Width = 200
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtSuggestQuery)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(929, 387)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Suggested SQL"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtSuggestQuery
        '
        Me.txtSuggestQuery.AcceptsTab = True
        Me.txtSuggestQuery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSuggestQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSuggestQuery.FileExtension = "txt"
        Me.txtSuggestQuery.HideSelection = False
        Me.txtSuggestQuery.Location = New System.Drawing.Point(3, 3)
        Me.txtSuggestQuery.Name = "txtSuggestQuery"
        Me.txtSuggestQuery.ShortcutsEnabled = False
        Me.txtSuggestQuery.Size = New System.Drawing.Size(923, 381)
        Me.txtSuggestQuery.TabIndex = 3
        Me.txtSuggestQuery.Text = ""
        Me.txtSuggestQuery.WordWrap = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lnkVWOpenQuery)
        Me.TabPage3.Controls.Add(Me.lnkFNOpenQuery)
        Me.TabPage3.Controls.Add(Me.lnkSPOpenQuery)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.lnkVWOpenFile)
        Me.TabPage3.Controls.Add(Me.lnkFNOpenFile)
        Me.TabPage3.Controls.Add(Me.lnkSPOpenFile)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(929, 387)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Script"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lnkVWOpenQuery
        '
        Me.lnkVWOpenQuery.AutoSize = True
        Me.lnkVWOpenQuery.Location = New System.Drawing.Point(267, 72)
        Me.lnkVWOpenQuery.Name = "lnkVWOpenQuery"
        Me.lnkVWOpenQuery.Size = New System.Drawing.Size(76, 13)
        Me.lnkVWOpenQuery.TabIndex = 8
        Me.lnkVWOpenQuery.TabStop = True
        Me.lnkVWOpenQuery.Text = "Open as query"
        '
        'lnkFNOpenQuery
        '
        Me.lnkFNOpenQuery.AutoSize = True
        Me.lnkFNOpenQuery.Location = New System.Drawing.Point(267, 42)
        Me.lnkFNOpenQuery.Name = "lnkFNOpenQuery"
        Me.lnkFNOpenQuery.Size = New System.Drawing.Size(76, 13)
        Me.lnkFNOpenQuery.TabIndex = 7
        Me.lnkFNOpenQuery.TabStop = True
        Me.lnkFNOpenQuery.Text = "Open as query"
        '
        'lnkSPOpenQuery
        '
        Me.lnkSPOpenQuery.AutoSize = True
        Me.lnkSPOpenQuery.Location = New System.Drawing.Point(267, 13)
        Me.lnkSPOpenQuery.Name = "lnkSPOpenQuery"
        Me.lnkSPOpenQuery.Size = New System.Drawing.Size(76, 13)
        Me.lnkSPOpenQuery.TabIndex = 6
        Me.lnkSPOpenQuery.TabStop = True
        Me.lnkSPOpenQuery.Text = "Open as query"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "View"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Scalar and Table Valued Function"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Stored Procedure"
        '
        'lnkVWOpenFile
        '
        Me.lnkVWOpenFile.AutoSize = True
        Me.lnkVWOpenFile.Location = New System.Drawing.Point(191, 72)
        Me.lnkVWOpenFile.Name = "lnkVWOpenFile"
        Me.lnkVWOpenFile.Size = New System.Drawing.Size(52, 13)
        Me.lnkVWOpenFile.TabIndex = 2
        Me.lnkVWOpenFile.TabStop = True
        Me.lnkVWOpenFile.Text = "Open File"
        '
        'lnkFNOpenFile
        '
        Me.lnkFNOpenFile.AutoSize = True
        Me.lnkFNOpenFile.Location = New System.Drawing.Point(191, 42)
        Me.lnkFNOpenFile.Name = "lnkFNOpenFile"
        Me.lnkFNOpenFile.Size = New System.Drawing.Size(52, 13)
        Me.lnkFNOpenFile.TabIndex = 1
        Me.lnkFNOpenFile.TabStop = True
        Me.lnkFNOpenFile.Text = "Open File"
        '
        'lnkSPOpenFile
        '
        Me.lnkSPOpenFile.AutoSize = True
        Me.lnkSPOpenFile.Location = New System.Drawing.Point(191, 13)
        Me.lnkSPOpenFile.Name = "lnkSPOpenFile"
        Me.lnkSPOpenFile.Size = New System.Drawing.Size(52, 13)
        Me.lnkSPOpenFile.TabIndex = 0
        Me.lnkSPOpenFile.TabStop = True
        Me.lnkSPOpenFile.Text = "Open File"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(929, 387)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Compare Options"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.chkCheckTF)
        Me.GroupBox2.Controls.Add(Me.chkCheckSP)
        Me.GroupBox2.Controls.Add(Me.chkCheckFN)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(481, 88)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.radCompareByDate)
        Me.Panel1.Controls.Add(Me.radCompareByDefinition)
        Me.Panel1.Location = New System.Drawing.Point(245, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(139, 48)
        Me.Panel1.TabIndex = 15
        '
        'radCompareByDate
        '
        Me.radCompareByDate.AutoSize = True
        Me.radCompareByDate.Checked = True
        Me.radCompareByDate.Location = New System.Drawing.Point(13, 3)
        Me.radCompareByDate.Name = "radCompareByDate"
        Me.radCompareByDate.Size = New System.Drawing.Size(106, 17)
        Me.radCompareByDate.TabIndex = 1
        Me.radCompareByDate.TabStop = True
        Me.radCompareByDate.Text = "By Modified Date"
        Me.radCompareByDate.UseVisualStyleBackColor = True
        '
        'radCompareByDefinition
        '
        Me.radCompareByDefinition.AutoSize = True
        Me.radCompareByDefinition.Location = New System.Drawing.Point(13, 23)
        Me.radCompareByDefinition.Name = "radCompareByDefinition"
        Me.radCompareByDefinition.Size = New System.Drawing.Size(84, 17)
        Me.radCompareByDefinition.TabIndex = 0
        Me.radCompareByDefinition.Text = "By Definition"
        Me.radCompareByDefinition.UseVisualStyleBackColor = True
        '
        'chkCheckTF
        '
        Me.chkCheckTF.AutoSize = True
        Me.chkCheckTF.Checked = True
        Me.chkCheckTF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCheckTF.Location = New System.Drawing.Point(6, 62)
        Me.chkCheckTF.Name = "chkCheckTF"
        Me.chkCheckTF.Size = New System.Drawing.Size(133, 17)
        Me.chkCheckTF.TabIndex = 14
        Me.chkCheckTF.Text = "Table Valued Function"
        Me.chkCheckTF.UseVisualStyleBackColor = True
        '
        'chkCheckSP
        '
        Me.chkCheckSP.AutoSize = True
        Me.chkCheckSP.Checked = True
        Me.chkCheckSP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCheckSP.Location = New System.Drawing.Point(6, 22)
        Me.chkCheckSP.Name = "chkCheckSP"
        Me.chkCheckSP.Size = New System.Drawing.Size(109, 17)
        Me.chkCheckSP.TabIndex = 12
        Me.chkCheckSP.Text = "Stored Procedure"
        Me.chkCheckSP.UseVisualStyleBackColor = True
        '
        'chkCheckFN
        '
        Me.chkCheckFN.AutoSize = True
        Me.chkCheckFN.Checked = True
        Me.chkCheckFN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCheckFN.Location = New System.Drawing.Point(6, 42)
        Me.chkCheckFN.Name = "chkCheckFN"
        Me.chkCheckFN.Size = New System.Drawing.Size(136, 17)
        Me.chkCheckFN.TabIndex = 13
        Me.chkCheckFN.Text = "Scalar Valued Function"
        Me.chkCheckFN.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCheckTB)
        Me.GroupBox1.Controls.Add(Me.chkSkipDeleteDestTable)
        Me.GroupBox1.Controls.Add(Me.chkCheckVW)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(481, 61)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'chkCheckTB
        '
        Me.chkCheckTB.AutoSize = True
        Me.chkCheckTB.Checked = True
        Me.chkCheckTB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCheckTB.Location = New System.Drawing.Point(6, 19)
        Me.chkCheckTB.Name = "chkCheckTB"
        Me.chkCheckTB.Size = New System.Drawing.Size(53, 17)
        Me.chkCheckTB.TabIndex = 11
        Me.chkCheckTB.Text = "Table"
        Me.chkCheckTB.UseVisualStyleBackColor = True
        '
        'chkSkipDeleteDestTable
        '
        Me.chkSkipDeleteDestTable.AutoSize = True
        Me.chkSkipDeleteDestTable.Location = New System.Drawing.Point(165, 19)
        Me.chkSkipDeleteDestTable.Name = "chkSkipDeleteDestTable"
        Me.chkSkipDeleteDestTable.Size = New System.Drawing.Size(172, 17)
        Me.chkSkipDeleteDestTable.TabIndex = 16
        Me.chkSkipDeleteDestTable.Text = "Skip Delete Destination Tables"
        Me.chkSkipDeleteDestTable.UseVisualStyleBackColor = True
        '
        'chkCheckVW
        '
        Me.chkCheckVW.AutoSize = True
        Me.chkCheckVW.Checked = True
        Me.chkCheckVW.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCheckVW.Location = New System.Drawing.Point(6, 38)
        Me.chkCheckVW.Name = "chkCheckVW"
        Me.chkCheckVW.Size = New System.Drawing.Size(49, 17)
        Me.chkCheckVW.TabIndex = 15
        Me.chkCheckVW.Text = "View"
        Me.chkCheckVW.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(206, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Check differences in the following objects:"
        '
        'btnOpenSuggestQuery
        '
        Me.btnOpenSuggestQuery.Location = New System.Drawing.Point(769, 1)
        Me.btnOpenSuggestQuery.Name = "btnOpenSuggestQuery"
        Me.btnOpenSuggestQuery.Size = New System.Drawing.Size(153, 28)
        Me.btnOpenSuggestQuery.TabIndex = 2
        Me.btnOpenSuggestQuery.Text = "Generate Script"
        Me.btnOpenSuggestQuery.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Source Database"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Destination Database"
        '
        'ddSource
        '
        Me.ddSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ddSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddSource.FormattingEnabled = True
        Me.ddSource.Location = New System.Drawing.Point(141, 6)
        Me.ddSource.LossenValue = ""
        Me.ddSource.Name = "ddSource"
        Me.ddSource.Size = New System.Drawing.Size(301, 21)
        Me.ddSource.TabIndex = 6
        Me.ddSource.Value = Nothing
        '
        'ddDest
        '
        Me.ddDest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ddDest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddDest.FormattingEnabled = True
        Me.ddDest.Location = New System.Drawing.Point(141, 31)
        Me.ddDest.LossenValue = ""
        Me.ddDest.Name = "ddDest"
        Me.ddDest.Size = New System.Drawing.Size(301, 21)
        Me.ddDest.TabIndex = 7
        Me.ddDest.Value = Nothing
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 489)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(937, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Ready"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Purple
        Me.Label3.Location = New System.Drawing.Point(163, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(378, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "The sql script is aimed to update the destination to match the source database."
        '
        'btnExchange
        '
        Me.btnExchange.Location = New System.Drawing.Point(448, 16)
        Me.btnExchange.Name = "btnExchange"
        Me.btnExchange.Size = New System.Drawing.Size(49, 23)
        Me.btnExchange.TabIndex = 10
        Me.btnExchange.Text = "Swap"
        Me.btnExchange.UseVisualStyleBackColor = True
        '
        'bwLogic
        '
        '
        'ddDestConnectionString
        '
        Me.ddDestConnectionString.FormattingEnabled = True
        Me.ddDestConnectionString.Location = New System.Drawing.Point(609, 31)
        Me.ddDestConnectionString.Name = "ddDestConnectionString"
        Me.ddDestConnectionString.Size = New System.Drawing.Size(318, 21)
        Me.ddDestConnectionString.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(523, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Other Conn."
        '
        'frm_Comparer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 511)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ddDestConnectionString)
        Me.Controls.Add(Me.btnExchange)
        Me.Controls.Add(Me.btnOpenSuggestQuery)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ddDest)
        Me.Controls.Add(Me.ddSource)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnCompare)
        Me.Name = "frm_Comparer"
        Me.Text = "Database Comparer"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lvwResult As CHKControl.ExtendedListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ddSource As CHKControl.ExtendedComboBox
    Friend WithEvents ddDest As CHKControl.ExtendedComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnExchange As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lnkSPOpenFile As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkFNOpenFile As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkVWOpenFile As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lnkVWOpenQuery As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkFNOpenQuery As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSPOpenQuery As System.Windows.Forms.LinkLabel
    Friend WithEvents bwLogic As System.ComponentModel.BackgroundWorker
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkCheckVW As System.Windows.Forms.CheckBox
    Friend WithEvents chkCheckTF As System.Windows.Forms.CheckBox
    Friend WithEvents chkCheckFN As System.Windows.Forms.CheckBox
    Friend WithEvents chkCheckSP As System.Windows.Forms.CheckBox
    Friend WithEvents chkCheckTB As System.Windows.Forms.CheckBox
    Friend WithEvents btnOpenSuggestQuery As System.Windows.Forms.Button
    Friend WithEvents txtSuggestQuery As CHKControl.TextBox.TextEditor
    Friend WithEvents ddDestConnectionString As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkSkipDeleteDestTable As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents radCompareByDate As System.Windows.Forms.RadioButton
    Friend WithEvents radCompareByDefinition As System.Windows.Forms.RadioButton
End Class
