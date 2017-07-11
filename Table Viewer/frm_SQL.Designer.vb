<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SQL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SQL))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnLoadQuery = New System.Windows.Forms.ToolStripButton()
        Me.btnSaveQuery = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnSaveAsQuery = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ddDatabase = New System.Windows.Forms.ToolStripComboBox()
        Me.btnRunQuery = New System.Windows.Forms.ToolStripSplitButton()
        Me.chkResultToWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkResultToCsv = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtQueryResultExportPath = New System.Windows.Forms.ToolStripTextBox()
        Me.btnStopQuery = New System.Windows.Forms.ToolStripButton()
        Me.btnExecute = New System.Windows.Forms.ToolStripButton()
        Me.btnScheduleRun = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFindReplace = New System.Windows.Forms.ToolStripButton()
        Me.btnComment = New System.Windows.Forms.ToolStripButton()
        Me.btnUncomment = New System.Windows.Forms.ToolStripButton()
        Me.btnFormat = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnInsertSnippet = New System.Windows.Forms.ToolStripSplitButton()
        Me.mnuSnippet_AuthorComment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSnippet_CreateProc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSnippet_ConvertToAlterProc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSnippet_ConvertToCreateProc = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDo_SelectAllColumns = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDo_InnerJoin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSnippet_Cursor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSnippet_IdentityInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSnippet_CTE = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSnippet_TryCatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSnippet_CopyAndPasteColumnName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSnippet_SelectWholeText = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtQuery = New Table_Viewer.ScintillaEditor()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabMessage = New System.Windows.Forms.TabPage()
        Me.btnHideMessage = New System.Windows.Forms.Button()
        Me.btnGotoError = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.RichTextBox()
        Me.cmdgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.cmdgSave = New System.Windows.Forms.SaveFileDialog()
        Me.timerSchedule = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabMessage.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLoadQuery, Me.btnSaveQuery, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ddDatabase, Me.btnRunQuery, Me.btnStopQuery, Me.btnExecute, Me.btnScheduleRun, Me.ToolStripSeparator2, Me.btnFindReplace, Me.btnComment, Me.btnUncomment, Me.btnFormat, Me.ToolStripSeparator3, Me.btnInsertSnippet})
        Me.ToolStrip1.Location = New System.Drawing.Point(2, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(758, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnLoadQuery
        '
        Me.btnLoadQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLoadQuery.Image = CType(resources.GetObject("btnLoadQuery.Image"), System.Drawing.Image)
        Me.btnLoadQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLoadQuery.Name = "btnLoadQuery"
        Me.btnLoadQuery.Size = New System.Drawing.Size(23, 22)
        Me.btnLoadQuery.Text = "Load Query from File"
        '
        'btnSaveQuery
        '
        Me.btnSaveQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSaveQuery.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSaveAsQuery})
        Me.btnSaveQuery.Image = CType(resources.GetObject("btnSaveQuery.Image"), System.Drawing.Image)
        Me.btnSaveQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveQuery.Name = "btnSaveQuery"
        Me.btnSaveQuery.Size = New System.Drawing.Size(32, 22)
        Me.btnSaveQuery.Text = "Save Query"
        '
        'btnSaveAsQuery
        '
        Me.btnSaveAsQuery.Name = "btnSaveAsQuery"
        Me.btnSaveAsQuery.Size = New System.Drawing.Size(114, 22)
        Me.btnSaveAsQuery.Text = "Save As"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        Me.ddDatabase.Size = New System.Drawing.Size(150, 25)
        '
        'btnRunQuery
        '
        Me.btnRunQuery.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.chkResultToWindow, Me.chkResultToCsv, Me.ExportDirectoryToolStripMenuItem, Me.txtQueryResultExportPath})
        Me.btnRunQuery.Image = CType(resources.GetObject("btnRunQuery.Image"), System.Drawing.Image)
        Me.btnRunQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRunQuery.Name = "btnRunQuery"
        Me.btnRunQuery.Size = New System.Drawing.Size(60, 22)
        Me.btnRunQuery.Text = "Run"
        Me.btnRunQuery.ToolTipText = "Run (F5)"
        '
        'chkResultToWindow
        '
        Me.chkResultToWindow.Checked = True
        Me.chkResultToWindow.CheckOnClick = True
        Me.chkResultToWindow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkResultToWindow.Name = "chkResultToWindow"
        Me.chkResultToWindow.Size = New System.Drawing.Size(360, 22)
        Me.chkResultToWindow.Text = "Result to Window"
        '
        'chkResultToCsv
        '
        Me.chkResultToCsv.CheckOnClick = True
        Me.chkResultToCsv.Name = "chkResultToCsv"
        Me.chkResultToCsv.Size = New System.Drawing.Size(360, 22)
        Me.chkResultToCsv.Text = "Result to CSV"
        '
        'ExportDirectoryToolStripMenuItem
        '
        Me.ExportDirectoryToolStripMenuItem.BackColor = System.Drawing.Color.LightBlue
        Me.ExportDirectoryToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ExportDirectoryToolStripMenuItem.Name = "ExportDirectoryToolStripMenuItem"
        Me.ExportDirectoryToolStripMenuItem.Size = New System.Drawing.Size(360, 22)
        Me.ExportDirectoryToolStripMenuItem.Text = "Export Directory"
        '
        'txtQueryResultExportPath
        '
        Me.txtQueryResultExportPath.BackColor = System.Drawing.Color.Pink
        Me.txtQueryResultExportPath.Name = "txtQueryResultExportPath"
        Me.txtQueryResultExportPath.Size = New System.Drawing.Size(300, 23)
        '
        'btnStopQuery
        '
        Me.btnStopQuery.Enabled = False
        Me.btnStopQuery.Image = Global.Table_Viewer.My.Resources.Resources.Stop2
        Me.btnStopQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStopQuery.Name = "btnStopQuery"
        Me.btnStopQuery.Size = New System.Drawing.Size(51, 22)
        Me.btnStopQuery.Text = "Stop"
        '
        'btnExecute
        '
        Me.btnExecute.Image = CType(resources.GetObject("btnExecute.Image"), System.Drawing.Image)
        Me.btnExecute.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(67, 22)
        Me.btnExecute.Text = "Execute"
        '
        'btnScheduleRun
        '
        Me.btnScheduleRun.CheckOnClick = True
        Me.btnScheduleRun.Image = Global.Table_Viewer.My.Resources.Resources.Schedule
        Me.btnScheduleRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnScheduleRun.Name = "btnScheduleRun"
        Me.btnScheduleRun.Size = New System.Drawing.Size(75, 22)
        Me.btnScheduleRun.Text = "Schedule"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnFindReplace
        '
        Me.btnFindReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFindReplace.Image = CType(resources.GetObject("btnFindReplace.Image"), System.Drawing.Image)
        Me.btnFindReplace.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFindReplace.Name = "btnFindReplace"
        Me.btnFindReplace.Size = New System.Drawing.Size(23, 22)
        Me.btnFindReplace.Text = "Find and Replace"
        Me.btnFindReplace.ToolTipText = "Find and Replace (Ctrl+F)"
        '
        'btnComment
        '
        Me.btnComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnComment.Image = CType(resources.GetObject("btnComment.Image"), System.Drawing.Image)
        Me.btnComment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComment.Name = "btnComment"
        Me.btnComment.Size = New System.Drawing.Size(23, 22)
        Me.btnComment.Text = "Comment"
        Me.btnComment.ToolTipText = "Comment (Ctrl+K)"
        '
        'btnUncomment
        '
        Me.btnUncomment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUncomment.Image = CType(resources.GetObject("btnUncomment.Image"), System.Drawing.Image)
        Me.btnUncomment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUncomment.Name = "btnUncomment"
        Me.btnUncomment.Size = New System.Drawing.Size(23, 22)
        Me.btnUncomment.Text = "Uncoment"
        Me.btnUncomment.ToolTipText = "Uncoment (Ctrl+U)"
        '
        'btnFormat
        '
        Me.btnFormat.Image = CType(resources.GetObject("btnFormat.Image"), System.Drawing.Image)
        Me.btnFormat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFormat.Name = "btnFormat"
        Me.btnFormat.Size = New System.Drawing.Size(65, 22)
        Me.btnFormat.Text = "Format"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnInsertSnippet
        '
        Me.btnInsertSnippet.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSnippet_AuthorComment, Me.mnuSnippet_CreateProc, Me.mnuSnippet_ConvertToAlterProc, Me.mnuSnippet_ConvertToCreateProc, Me.ToolStripSeparator6, Me.mnuDo_SelectAllColumns, Me.mnuDo_InnerJoin, Me.ToolStripSeparator4, Me.mnuSnippet_Cursor, Me.mnuSnippet_IdentityInsert, Me.mnuSnippet_CTE, Me.mnuSnippet_TryCatch, Me.ToolStripSeparator5, Me.mnuSnippet_CopyAndPasteColumnName, Me.mnuSnippet_SelectWholeText})
        Me.btnInsertSnippet.Image = CType(resources.GetObject("btnInsertSnippet.Image"), System.Drawing.Image)
        Me.btnInsertSnippet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertSnippet.Name = "btnInsertSnippet"
        Me.btnInsertSnippet.Size = New System.Drawing.Size(79, 22)
        Me.btnInsertSnippet.Text = "Snippet"
        '
        'mnuSnippet_AuthorComment
        '
        Me.mnuSnippet_AuthorComment.Name = "mnuSnippet_AuthorComment"
        Me.mnuSnippet_AuthorComment.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_AuthorComment.Tag = "Author Comment"
        Me.mnuSnippet_AuthorComment.Text = "Author Comment"
        '
        'mnuSnippet_CreateProc
        '
        Me.mnuSnippet_CreateProc.Name = "mnuSnippet_CreateProc"
        Me.mnuSnippet_CreateProc.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_CreateProc.Text = "Stored Procedure Template"
        '
        'mnuSnippet_ConvertToAlterProc
        '
        Me.mnuSnippet_ConvertToAlterProc.Name = "mnuSnippet_ConvertToAlterProc"
        Me.mnuSnippet_ConvertToAlterProc.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_ConvertToAlterProc.Text = "CREATE -> ALTER"
        '
        'mnuSnippet_ConvertToCreateProc
        '
        Me.mnuSnippet_ConvertToCreateProc.Name = "mnuSnippet_ConvertToCreateProc"
        Me.mnuSnippet_ConvertToCreateProc.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_ConvertToCreateProc.Text = "ALTER -> CREATE"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(267, 6)
        '
        'mnuDo_SelectAllColumns
        '
        Me.mnuDo_SelectAllColumns.Name = "mnuDo_SelectAllColumns"
        Me.mnuDo_SelectAllColumns.Size = New System.Drawing.Size(270, 22)
        Me.mnuDo_SelectAllColumns.Text = "All table columns"
        '
        'mnuDo_InnerJoin
        '
        Me.mnuDo_InnerJoin.Name = "mnuDo_InnerJoin"
        Me.mnuDo_InnerJoin.Size = New System.Drawing.Size(270, 22)
        Me.mnuDo_InnerJoin.Text = "Inner Join"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(267, 6)
        '
        'mnuSnippet_Cursor
        '
        Me.mnuSnippet_Cursor.Name = "mnuSnippet_Cursor"
        Me.mnuSnippet_Cursor.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_Cursor.Tag = "Cursor"
        Me.mnuSnippet_Cursor.Text = "Cursor Declaration"
        '
        'mnuSnippet_IdentityInsert
        '
        Me.mnuSnippet_IdentityInsert.Name = "mnuSnippet_IdentityInsert"
        Me.mnuSnippet_IdentityInsert.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_IdentityInsert.Tag = "Identity Insert"
        Me.mnuSnippet_IdentityInsert.Text = "Identity Insert"
        '
        'mnuSnippet_CTE
        '
        Me.mnuSnippet_CTE.Name = "mnuSnippet_CTE"
        Me.mnuSnippet_CTE.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_CTE.Text = "Upcast to With CTE"
        '
        'mnuSnippet_TryCatch
        '
        Me.mnuSnippet_TryCatch.Name = "mnuSnippet_TryCatch"
        Me.mnuSnippet_TryCatch.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_TryCatch.Text = "Try Catch Block"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(267, 6)
        '
        'mnuSnippet_CopyAndPasteColumnName
        '
        Me.mnuSnippet_CopyAndPasteColumnName.Name = "mnuSnippet_CopyAndPasteColumnName"
        Me.mnuSnippet_CopyAndPasteColumnName.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.mnuSnippet_CopyAndPasteColumnName.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_CopyAndPasteColumnName.Text = "Copy and Paste column name"
        '
        'mnuSnippet_SelectWholeText
        '
        Me.mnuSnippet_SelectWholeText.Name = "mnuSnippet_SelectWholeText"
        Me.mnuSnippet_SelectWholeText.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuSnippet_SelectWholeText.Size = New System.Drawing.Size(270, 22)
        Me.mnuSnippet_SelectWholeText.Text = "Select and Copy whole text"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(194, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Use Database"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 29)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtQuery)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(831, 470)
        Me.SplitContainer1.SplitterDistance = 300
        Me.SplitContainer1.TabIndex = 8
        '
        'txtQuery
        '
        Me.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQuery.Location = New System.Drawing.Point(0, 0)
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.SelectedText = ""
        Me.txtQuery.SelectionEnd = 0
        Me.txtQuery.SelectionStart = 0
        Me.txtQuery.Size = New System.Drawing.Size(831, 300)
        Me.txtQuery.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabMessage)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(825, 160)
        Me.TabControl1.TabIndex = 3
        '
        'tabMessage
        '
        Me.tabMessage.Controls.Add(Me.btnHideMessage)
        Me.tabMessage.Controls.Add(Me.btnGotoError)
        Me.tabMessage.Controls.Add(Me.txtMessage)
        Me.tabMessage.Location = New System.Drawing.Point(4, 23)
        Me.tabMessage.Name = "tabMessage"
        Me.tabMessage.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMessage.Size = New System.Drawing.Size(817, 133)
        Me.tabMessage.TabIndex = 1
        Me.tabMessage.Text = "Message"
        Me.tabMessage.UseVisualStyleBackColor = True
        '
        'btnHideMessage
        '
        Me.btnHideMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHideMessage.Location = New System.Drawing.Point(694, 3)
        Me.btnHideMessage.Name = "btnHideMessage"
        Me.btnHideMessage.Size = New System.Drawing.Size(93, 27)
        Me.btnHideMessage.TabIndex = 2
        Me.btnHideMessage.Text = "Hide"
        Me.btnHideMessage.UseVisualStyleBackColor = True
        '
        'btnGotoError
        '
        Me.btnGotoError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGotoError.Location = New System.Drawing.Point(694, 31)
        Me.btnGotoError.Name = "btnGotoError"
        Me.btnGotoError.Size = New System.Drawing.Size(93, 27)
        Me.btnGotoError.TabIndex = 1
        Me.btnGotoError.Text = "Go to Error"
        Me.btnGotoError.UseVisualStyleBackColor = True
        Me.btnGotoError.Visible = False
        '
        'txtMessage
        '
        Me.txtMessage.BackColor = System.Drawing.Color.Purple
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessage.ForeColor = System.Drawing.Color.White
        Me.txtMessage.Location = New System.Drawing.Point(3, 3)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(811, 127)
        Me.txtMessage.TabIndex = 0
        Me.txtMessage.Text = ""
        '
        'cmdgOpen
        '
        Me.cmdgOpen.Filter = "SQL Query (*.sql)|*.sql|Text (*.txt)|*.txt|All Files|*.*"
        '
        'cmdgSave
        '
        Me.cmdgSave.Filter = "SQL Query (*.sql)|*.sql|Text (*.txt)|*.txt|All Files|*.*"
        '
        'timerSchedule
        '
        Me.timerSchedule.Interval = 10000
        '
        'frm_SQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 499)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_SQL"
        Me.Text = "Query Visualizer"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabMessage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnLoadQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ddDatabase As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnComment As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUncomment As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFindReplace As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFormat As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabMessage As System.Windows.Forms.TabPage
    Friend WithEvents txtMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents btnGotoError As System.Windows.Forms.Button
    Friend WithEvents btnInsertSnippet As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSnippet_AuthorComment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSnippet_Cursor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSnippet_IdentityInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSnippet_TryCatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnHideMessage As System.Windows.Forms.Button
    Friend WithEvents btnStopQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDo_InnerJoin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDo_SelectAllColumns As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSnippet_CreateProc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSaveQuery As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnSaveAsQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSnippet_ConvertToAlterProc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSnippet_CTE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSnippet_ConvertToCreateProc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnScheduleRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents timerSchedule As System.Windows.Forms.Timer
    Friend WithEvents btnRunQuery As ToolStripSplitButton
    Friend WithEvents chkResultToWindow As ToolStripMenuItem
    Friend WithEvents chkResultToCsv As ToolStripMenuItem
    Friend WithEvents btnExecute As ToolStripButton
    Friend WithEvents txtQueryResultExportPath As ToolStripTextBox
    Friend WithEvents ExportDirectoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents mnuSnippet_CopyAndPasteColumnName As ToolStripMenuItem
    Friend WithEvents mnuSnippet_SelectWholeText As ToolStripMenuItem
    Friend WithEvents txtQuery As ScintillaEditor
End Class
