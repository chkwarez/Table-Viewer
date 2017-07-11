<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SQLScript
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtSourceQuery = New CHKControl.TextBox.SqlEditor()
        Me.dgContent = New CHKControl.GridView.DbDataGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrimaryKeys = New System.Windows.Forms.TextBox()
        Me.btnScriptToClipboard = New System.Windows.Forms.Button()
        Me.btnScriptToNewQuery = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.lnkCheckAll = New System.Windows.Forms.LinkLabel()
        Me.lnkUncheckAll = New System.Windows.Forms.LinkLabel()
        Me.lnkInvert = New System.Windows.Forms.LinkLabel()
        Me.lblContentStatus = New System.Windows.Forms.Label()
        Me.chkScriptNullValue = New System.Windows.Forms.CheckBox()
        Me.radInsert = New System.Windows.Forms.RadioButton()
        Me.radUpdate = New System.Windows.Forms.RadioButton()
        Me.radDelete = New System.Windows.Forms.RadioButton()
        Me.btnExportToHtml = New System.Windows.Forms.Button()
        Me.btnScriptToFile = New System.Windows.Forms.Button()
        Me.cmdgSave = New System.Windows.Forms.SaveFileDialog()
        Me.btnSelectAndScript = New System.Windows.Forms.Button()
        Me.chkScriptReadOnlyColumns = New System.Windows.Forms.CheckBox()
        Me.chkIdentityInsert = New System.Windows.Forms.CheckBox()
        Me.chkTruncateTable = New System.Windows.Forms.CheckBox()
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSourceQuery
        '
        Me.txtSourceQuery.AcceptsTab = True
        Me.txtSourceQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSourceQuery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSourceQuery.DetectUrls = False
        Me.txtSourceQuery.FileExtension = "txt"
        Me.txtSourceQuery.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSourceQuery.HideSelection = False
        Me.txtSourceQuery.Location = New System.Drawing.Point(2, 3)
        Me.txtSourceQuery.Name = "txtSourceQuery"
        Me.txtSourceQuery.ShortcutsEnabled = False
        Me.txtSourceQuery.Size = New System.Drawing.Size(858, 95)
        Me.txtSourceQuery.TabIndex = 0
        Me.txtSourceQuery.Text = ""
        Me.txtSourceQuery.WordWrap = False
        '
        'dgContent
        '
        Me.dgContent.AllowUserToAddRows = False
        Me.dgContent.AllowUserToDeleteRows = False
        Me.dgContent.AllowUserToResizeRows = False
        Me.dgContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = "NULL"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgContent.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgContent.Location = New System.Drawing.Point(2, 159)
        Me.dgContent.Name = "dgContent"
        Me.dgContent.RowHeadersVisible = False
        DataGridViewCellStyle2.NullValue = "NULL"
        Me.dgContent.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgContent.ShowRowErrors = False
        Me.dgContent.Size = New System.Drawing.Size(858, 324)
        Me.dgContent.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(243, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Primary Keys"
        '
        'txtPrimaryKeys
        '
        Me.txtPrimaryKeys.Location = New System.Drawing.Point(316, 133)
        Me.txtPrimaryKeys.Name = "txtPrimaryKeys"
        Me.txtPrimaryKeys.Size = New System.Drawing.Size(544, 20)
        Me.txtPrimaryKeys.TabIndex = 3
        '
        'btnScriptToClipboard
        '
        Me.btnScriptToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnScriptToClipboard.Location = New System.Drawing.Point(2, 502)
        Me.btnScriptToClipboard.Name = "btnScriptToClipboard"
        Me.btnScriptToClipboard.Size = New System.Drawing.Size(115, 28)
        Me.btnScriptToClipboard.TabIndex = 4
        Me.btnScriptToClipboard.Text = "Script to Clipboard"
        Me.btnScriptToClipboard.UseVisualStyleBackColor = True
        '
        'btnScriptToNewQuery
        '
        Me.btnScriptToNewQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnScriptToNewQuery.Location = New System.Drawing.Point(117, 502)
        Me.btnScriptToNewQuery.Name = "btnScriptToNewQuery"
        Me.btnScriptToNewQuery.Size = New System.Drawing.Size(118, 28)
        Me.btnScriptToNewQuery.TabIndex = 5
        Me.btnScriptToNewQuery.Text = "Script to New Query"
        Me.btnScriptToNewQuery.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(2, 101)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(152, 26)
        Me.btnSelect.TabIndex = 6
        Me.btnSelect.Text = "Run Query (F5)"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Table Name"
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(68, 133)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(170, 20)
        Me.txtTableName.TabIndex = 8
        '
        'lnkCheckAll
        '
        Me.lnkCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkCheckAll.AutoSize = True
        Me.lnkCheckAll.Location = New System.Drawing.Point(4, 486)
        Me.lnkCheckAll.Name = "lnkCheckAll"
        Me.lnkCheckAll.Size = New System.Drawing.Size(52, 13)
        Me.lnkCheckAll.TabIndex = 9
        Me.lnkCheckAll.TabStop = True
        Me.lnkCheckAll.Text = "Check All"
        '
        'lnkUncheckAll
        '
        Me.lnkUncheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkUncheckAll.AutoSize = True
        Me.lnkUncheckAll.Location = New System.Drawing.Point(55, 486)
        Me.lnkUncheckAll.Name = "lnkUncheckAll"
        Me.lnkUncheckAll.Size = New System.Drawing.Size(65, 13)
        Me.lnkUncheckAll.TabIndex = 10
        Me.lnkUncheckAll.TabStop = True
        Me.lnkUncheckAll.Text = "Uncheck All"
        '
        'lnkInvert
        '
        Me.lnkInvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkInvert.AutoSize = True
        Me.lnkInvert.Location = New System.Drawing.Point(120, 486)
        Me.lnkInvert.Name = "lnkInvert"
        Me.lnkInvert.Size = New System.Drawing.Size(34, 13)
        Me.lnkInvert.TabIndex = 11
        Me.lnkInvert.TabStop = True
        Me.lnkInvert.Text = "Invert"
        '
        'lblContentStatus
        '
        Me.lblContentStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblContentStatus.AutoSize = True
        Me.lblContentStatus.ForeColor = System.Drawing.Color.Navy
        Me.lblContentStatus.Location = New System.Drawing.Point(171, 486)
        Me.lblContentStatus.Name = "lblContentStatus"
        Me.lblContentStatus.Size = New System.Drawing.Size(39, 13)
        Me.lblContentStatus.TabIndex = 12
        Me.lblContentStatus.Text = "Label3"
        '
        'chkScriptNullValue
        '
        Me.chkScriptNullValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkScriptNullValue.AutoSize = True
        Me.chkScriptNullValue.Location = New System.Drawing.Point(594, 485)
        Me.chkScriptNullValue.Name = "chkScriptNullValue"
        Me.chkScriptNullValue.Size = New System.Drawing.Size(113, 17)
        Me.chkScriptNullValue.TabIndex = 13
        Me.chkScriptNullValue.Text = "Script NULL value"
        Me.chkScriptNullValue.UseVisualStyleBackColor = True
        '
        'radInsert
        '
        Me.radInsert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.radInsert.AutoSize = True
        Me.radInsert.Checked = True
        Me.radInsert.Location = New System.Drawing.Point(528, 508)
        Me.radInsert.Name = "radInsert"
        Me.radInsert.Size = New System.Drawing.Size(102, 17)
        Me.radInsert.TabIndex = 14
        Me.radInsert.TabStop = True
        Me.radInsert.Text = "Insert Statement"
        Me.radInsert.UseVisualStyleBackColor = True
        '
        'radUpdate
        '
        Me.radUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.radUpdate.AutoSize = True
        Me.radUpdate.Location = New System.Drawing.Point(636, 508)
        Me.radUpdate.Name = "radUpdate"
        Me.radUpdate.Size = New System.Drawing.Size(111, 17)
        Me.radUpdate.TabIndex = 15
        Me.radUpdate.Text = "Update Statement"
        Me.radUpdate.UseVisualStyleBackColor = True
        '
        'radDelete
        '
        Me.radDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.radDelete.AutoSize = True
        Me.radDelete.Location = New System.Drawing.Point(753, 508)
        Me.radDelete.Name = "radDelete"
        Me.radDelete.Size = New System.Drawing.Size(107, 17)
        Me.radDelete.TabIndex = 16
        Me.radDelete.Text = "Delete Statement"
        Me.radDelete.UseVisualStyleBackColor = True
        '
        'btnExportToHtml
        '
        Me.btnExportToHtml.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportToHtml.Location = New System.Drawing.Point(323, 502)
        Me.btnExportToHtml.Name = "btnExportToHtml"
        Me.btnExportToHtml.Size = New System.Drawing.Size(106, 28)
        Me.btnExportToHtml.TabIndex = 17
        Me.btnExportToHtml.Text = "Export to Html"
        Me.btnExportToHtml.UseVisualStyleBackColor = True
        '
        'btnScriptToFile
        '
        Me.btnScriptToFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnScriptToFile.Location = New System.Drawing.Point(235, 502)
        Me.btnScriptToFile.Name = "btnScriptToFile"
        Me.btnScriptToFile.Size = New System.Drawing.Size(88, 28)
        Me.btnScriptToFile.TabIndex = 18
        Me.btnScriptToFile.Text = "Script to File"
        Me.btnScriptToFile.UseVisualStyleBackColor = True
        '
        'btnSelectAndScript
        '
        Me.btnSelectAndScript.Location = New System.Drawing.Point(160, 101)
        Me.btnSelectAndScript.Name = "btnSelectAndScript"
        Me.btnSelectAndScript.Size = New System.Drawing.Size(178, 26)
        Me.btnSelectAndScript.TabIndex = 19
        Me.btnSelectAndScript.Text = "Run and Script all to clipboard"
        Me.btnSelectAndScript.UseVisualStyleBackColor = True
        '
        'chkScriptReadOnlyColumns
        '
        Me.chkScriptReadOnlyColumns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkScriptReadOnlyColumns.AutoSize = True
        Me.chkScriptReadOnlyColumns.Location = New System.Drawing.Point(713, 485)
        Me.chkScriptReadOnlyColumns.Name = "chkScriptReadOnlyColumns"
        Me.chkScriptReadOnlyColumns.Size = New System.Drawing.Size(147, 17)
        Me.chkScriptReadOnlyColumns.TabIndex = 20
        Me.chkScriptReadOnlyColumns.Text = "Script Computed Columns"
        Me.chkScriptReadOnlyColumns.UseVisualStyleBackColor = True
        '
        'chkIdentityInsert
        '
        Me.chkIdentityInsert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkIdentityInsert.AutoSize = True
        Me.chkIdentityInsert.Location = New System.Drawing.Point(463, 485)
        Me.chkIdentityInsert.Name = "chkIdentityInsert"
        Me.chkIdentityInsert.Size = New System.Drawing.Size(125, 17)
        Me.chkIdentityInsert.TabIndex = 21
        Me.chkIdentityInsert.Text = "Enable Identity Insert"
        Me.chkIdentityInsert.UseVisualStyleBackColor = True
        '
        'chkTruncateTable
        '
        Me.chkTruncateTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkTruncateTable.AutoSize = True
        Me.chkTruncateTable.Location = New System.Drawing.Point(358, 485)
        Me.chkTruncateTable.Name = "chkTruncateTable"
        Me.chkTruncateTable.Size = New System.Drawing.Size(99, 17)
        Me.chkTruncateTable.TabIndex = 22
        Me.chkTruncateTable.Text = "Truncate Table"
        Me.chkTruncateTable.UseVisualStyleBackColor = True
        '
        'frm_SQLScript
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 535)
        Me.Controls.Add(Me.chkTruncateTable)
        Me.Controls.Add(Me.chkIdentityInsert)
        Me.Controls.Add(Me.chkScriptReadOnlyColumns)
        Me.Controls.Add(Me.btnSelectAndScript)
        Me.Controls.Add(Me.btnScriptToFile)
        Me.Controls.Add(Me.btnExportToHtml)
        Me.Controls.Add(Me.radDelete)
        Me.Controls.Add(Me.radUpdate)
        Me.Controls.Add(Me.radInsert)
        Me.Controls.Add(Me.chkScriptNullValue)
        Me.Controls.Add(Me.lblContentStatus)
        Me.Controls.Add(Me.lnkInvert)
        Me.Controls.Add(Me.lnkUncheckAll)
        Me.Controls.Add(Me.lnkCheckAll)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnScriptToNewQuery)
        Me.Controls.Add(Me.btnScriptToClipboard)
        Me.Controls.Add(Me.txtPrimaryKeys)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgContent)
        Me.Controls.Add(Me.txtSourceQuery)
        Me.Name = "frm_SQLScript"
        Me.Text = "Script SQL From Data"
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSourceQuery As CHKControl.TextBox.SqlEditor
    Friend WithEvents dgContent As CHKControl.GridView.DbDataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrimaryKeys As System.Windows.Forms.TextBox
    Friend WithEvents btnScriptToClipboard As System.Windows.Forms.Button
    Friend WithEvents btnScriptToNewQuery As System.Windows.Forms.Button
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents lnkCheckAll As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkUncheckAll As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkInvert As System.Windows.Forms.LinkLabel
    Friend WithEvents lblContentStatus As System.Windows.Forms.Label
    Friend WithEvents chkScriptNullValue As System.Windows.Forms.CheckBox
    Friend WithEvents radInsert As System.Windows.Forms.RadioButton
    Friend WithEvents radUpdate As System.Windows.Forms.RadioButton
    Friend WithEvents radDelete As System.Windows.Forms.RadioButton
    Friend WithEvents btnExportToHtml As System.Windows.Forms.Button
    Friend WithEvents btnScriptToFile As System.Windows.Forms.Button
    Friend WithEvents cmdgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnSelectAndScript As System.Windows.Forms.Button
    Friend WithEvents chkScriptReadOnlyColumns As System.Windows.Forms.CheckBox
    Friend WithEvents chkIdentityInsert As System.Windows.Forms.CheckBox
    Friend WithEvents chkTruncateTable As System.Windows.Forms.CheckBox
End Class
