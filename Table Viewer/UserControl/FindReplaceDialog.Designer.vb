<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FindReplaceDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindReplaceDialog))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSwapFields = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.btnFindNext = New System.Windows.Forms.Button()
        Me.ddLookIn = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.radRE = New System.Windows.Forms.RadioButton()
        Me.radWildcards = New System.Windows.Forms.RadioButton()
        Me.chkUseWildRE = New System.Windows.Forms.CheckBox()
        Me.lblReplace = New System.Windows.Forms.Label()
        Me.timerStatus = New System.Windows.Forms.Timer(Me.components)
        Me.btnReplace = New System.Windows.Forms.Button()
        Me.chkMatchCase = New System.Windows.Forms.CheckBox()
        Me.btnRestartFind = New System.Windows.Forms.Button()
        Me.lblFind = New System.Windows.Forms.Label()
        Me.chkMatchWholeWord = New System.Windows.Forms.CheckBox()
        Me.ddReplace = New CHKControl.ExtendedComboBox()
        Me.ddFind = New CHKControl.ExtendedComboBox()
        Me.chkBookmark = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(393, 128)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(24, 24)
        Me.btnCancel.TabIndex = 49
        Me.btnCancel.TabStop = False
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSwapFields
        '
        Me.btnSwapFields.Image = Global.Table_Viewer.My.Resources.Resources.swap
        Me.btnSwapFields.Location = New System.Drawing.Point(389, 2)
        Me.btnSwapFields.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSwapFields.Name = "btnSwapFields"
        Me.btnSwapFields.Size = New System.Drawing.Size(28, 25)
        Me.btnSwapFields.TabIndex = 41
        Me.btnSwapFields.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(0, 178)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(423, 18)
        Me.lblMessage.TabIndex = 47
        Me.lblMessage.Text = "Message"
        Me.lblMessage.Visible = False
        '
        'lblHelp
        '
        Me.lblHelp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblHelp.Location = New System.Drawing.Point(192, 63)
        Me.lblHelp.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(225, 14)
        Me.lblHelp.TabIndex = 46
        Me.lblHelp.Text = "Enter: Find Next"
        Me.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnFindNext
        '
        Me.btnFindNext.Enabled = False
        Me.btnFindNext.Image = Global.Table_Viewer.My.Resources.Resources.Find
        Me.btnFindNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFindNext.Location = New System.Drawing.Point(51, 128)
        Me.btnFindNext.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(77, 24)
        Me.btnFindNext.TabIndex = 34
        Me.btnFindNext.Text = "Find Next"
        Me.btnFindNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindNext.UseVisualStyleBackColor = True
        '
        'ddLookIn
        '
        Me.ddLookIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddLookIn.FormattingEnabled = True
        Me.ddLookIn.Items.AddRange(New Object() {"Whole Text", "Selection"})
        Me.ddLookIn.Location = New System.Drawing.Point(65, 60)
        Me.ddLookIn.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.ddLookIn.Name = "ddLookIn"
        Me.ddLookIn.Size = New System.Drawing.Size(119, 22)
        Me.ddLookIn.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Look In"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStatus.Location = New System.Drawing.Point(5, 162)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(85, 14)
        Me.lblStatus.TabIndex = 44
        Me.lblStatus.Text = "Predicted Result"
        '
        'radRE
        '
        Me.radRE.AutoSize = True
        Me.radRE.Location = New System.Drawing.Point(130, 106)
        Me.radRE.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.radRE.Name = "radRE"
        Me.radRE.Size = New System.Drawing.Size(119, 18)
        Me.radRE.TabIndex = 38
        Me.radRE.Text = "Regular Expression"
        Me.radRE.UseVisualStyleBackColor = True
        Me.radRE.Visible = False
        '
        'radWildcards
        '
        Me.radWildcards.AutoSize = True
        Me.radWildcards.Checked = True
        Me.radWildcards.Location = New System.Drawing.Point(52, 105)
        Me.radWildcards.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.radWildcards.Name = "radWildcards"
        Me.radWildcards.Size = New System.Drawing.Size(73, 18)
        Me.radWildcards.TabIndex = 37
        Me.radWildcards.TabStop = True
        Me.radWildcards.Text = "Wildcards"
        Me.radWildcards.UseVisualStyleBackColor = True
        Me.radWildcards.Visible = False
        '
        'chkUseWildRE
        '
        Me.chkUseWildRE.AutoSize = True
        Me.chkUseWildRE.Location = New System.Drawing.Point(8, 106)
        Me.chkUseWildRE.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.chkUseWildRE.Name = "chkUseWildRE"
        Me.chkUseWildRE.Size = New System.Drawing.Size(45, 18)
        Me.chkUseWildRE.TabIndex = 35
        Me.chkUseWildRE.Text = "Use"
        Me.chkUseWildRE.UseVisualStyleBackColor = True
        Me.chkUseWildRE.Visible = False
        '
        'lblReplace
        '
        Me.lblReplace.AutoSize = True
        Me.lblReplace.Location = New System.Drawing.Point(5, 36)
        Me.lblReplace.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblReplace.Name = "lblReplace"
        Me.lblReplace.Size = New System.Drawing.Size(46, 14)
        Me.lblReplace.TabIndex = 43
        Me.lblReplace.Text = "Replace"
        '
        'timerStatus
        '
        Me.timerStatus.Interval = 500
        '
        'btnReplace
        '
        Me.btnReplace.Enabled = False
        Me.btnReplace.Image = CType(resources.GetObject("btnReplace.Image"), System.Drawing.Image)
        Me.btnReplace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReplace.Location = New System.Drawing.Point(205, 128)
        Me.btnReplace.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(84, 24)
        Me.btnReplace.TabIndex = 39
        Me.btnReplace.TabStop = False
        Me.btnReplace.Text = "Replace All"
        Me.btnReplace.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReplace.UseVisualStyleBackColor = True
        '
        'chkMatchCase
        '
        Me.chkMatchCase.AutoSize = True
        Me.chkMatchCase.Location = New System.Drawing.Point(8, 88)
        Me.chkMatchCase.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.chkMatchCase.Name = "chkMatchCase"
        Me.chkMatchCase.Size = New System.Drawing.Size(83, 18)
        Me.chkMatchCase.TabIndex = 33
        Me.chkMatchCase.Text = "Match Case"
        Me.chkMatchCase.UseVisualStyleBackColor = True
        '
        'btnRestartFind
        '
        Me.btnRestartFind.Enabled = False
        Me.btnRestartFind.Location = New System.Drawing.Point(130, 128)
        Me.btnRestartFind.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.btnRestartFind.Name = "btnRestartFind"
        Me.btnRestartFind.Size = New System.Drawing.Size(65, 24)
        Me.btnRestartFind.TabIndex = 36
        Me.btnRestartFind.Text = "Restart"
        Me.btnRestartFind.UseVisualStyleBackColor = True
        '
        'lblFind
        '
        Me.lblFind.AutoSize = True
        Me.lblFind.Location = New System.Drawing.Point(5, 7)
        Me.lblFind.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFind.Name = "lblFind"
        Me.lblFind.Size = New System.Drawing.Size(27, 14)
        Me.lblFind.TabIndex = 42
        Me.lblFind.Text = "Find"
        '
        'chkMatchWholeWord
        '
        Me.chkMatchWholeWord.AutoSize = True
        Me.chkMatchWholeWord.Location = New System.Drawing.Point(112, 88)
        Me.chkMatchWholeWord.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.chkMatchWholeWord.Name = "chkMatchWholeWord"
        Me.chkMatchWholeWord.Size = New System.Drawing.Size(117, 18)
        Me.chkMatchWholeWord.TabIndex = 50
        Me.chkMatchWholeWord.Text = "Match Whole Word"
        Me.chkMatchWholeWord.UseVisualStyleBackColor = True
        '
        'ddReplace
        '
        Me.ddReplace.FormattingEnabled = True
        Me.ddReplace.Location = New System.Drawing.Point(65, 33)
        Me.ddReplace.LossenValue = ""
        Me.ddReplace.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.ddReplace.Name = "ddReplace"
        Me.ddReplace.Size = New System.Drawing.Size(320, 22)
        Me.ddReplace.TabIndex = 31
        Me.ddReplace.Value = Nothing
        '
        'ddFind
        '
        Me.ddFind.FormattingEnabled = True
        Me.ddFind.Location = New System.Drawing.Point(65, 4)
        Me.ddFind.LossenValue = ""
        Me.ddFind.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.ddFind.Name = "ddFind"
        Me.ddFind.Size = New System.Drawing.Size(320, 22)
        Me.ddFind.TabIndex = 30
        Me.ddFind.Value = Nothing
        '
        'chkBookmark
        '
        Me.chkBookmark.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkBookmark.Image = CType(resources.GetObject("chkBookmark.Image"), System.Drawing.Image)
        Me.chkBookmark.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkBookmark.Location = New System.Drawing.Point(303, 128)
        Me.chkBookmark.Name = "chkBookmark"
        Me.chkBookmark.Size = New System.Drawing.Size(73, 24)
        Me.chkBookmark.TabIndex = 51
        Me.chkBookmark.Text = "Highlight"
        Me.chkBookmark.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBookmark.UseVisualStyleBackColor = True
        '
        'FindReplaceDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(423, 196)
        Me.Controls.Add(Me.chkBookmark)
        Me.Controls.Add(Me.chkMatchWholeWord)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSwapFields)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.btnFindNext)
        Me.Controls.Add(Me.ddLookIn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.radRE)
        Me.Controls.Add(Me.radWildcards)
        Me.Controls.Add(Me.chkUseWildRE)
        Me.Controls.Add(Me.ddReplace)
        Me.Controls.Add(Me.lblReplace)
        Me.Controls.Add(Me.ddFind)
        Me.Controls.Add(Me.btnReplace)
        Me.Controls.Add(Me.chkMatchCase)
        Me.Controls.Add(Me.btnRestartFind)
        Me.Controls.Add(Me.lblFind)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindReplaceDialog"
        Me.ShowInTaskbar = False
        Me.Text = "Find / Replace Dialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSwapFields As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents btnFindNext As System.Windows.Forms.Button
    Friend WithEvents ddLookIn As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents radRE As System.Windows.Forms.RadioButton
    Friend WithEvents radWildcards As System.Windows.Forms.RadioButton
    Friend WithEvents chkUseWildRE As System.Windows.Forms.CheckBox
    Friend WithEvents ddReplace As CHKControl.ExtendedComboBox
    Friend WithEvents lblReplace As System.Windows.Forms.Label
    Friend WithEvents ddFind As CHKControl.ExtendedComboBox
    Friend WithEvents timerStatus As System.Windows.Forms.Timer
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents chkMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents btnRestartFind As System.Windows.Forms.Button
    Friend WithEvents lblFind As System.Windows.Forms.Label
    Friend WithEvents chkMatchWholeWord As System.Windows.Forms.CheckBox
    Friend WithEvents chkBookmark As System.Windows.Forms.CheckBox
End Class
