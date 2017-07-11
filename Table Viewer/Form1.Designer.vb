<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgContent = New System.Windows.Forms.DataGridView
        Me.btnLoad = New System.Windows.Forms.Button
        Me.ddDatabase = New System.Windows.Forms.ComboBox
        Me.btnShowFilterColumn = New System.Windows.Forms.Button
        Me.panelColumn = New System.Windows.Forms.Panel
        Me.btnCopyColumnName = New System.Windows.Forms.Button
        Me.dgTableColumn = New System.Windows.Forms.DataGridView
        Me.dcShow = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dcName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dcDataType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnToggleColumn = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.barProgress = New System.Windows.Forms.ToolStripProgressBar
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblStatus2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.groupConnection = New System.Windows.Forms.GroupBox
        Me.ddTable = New System.Windows.Forms.ListBox
        Me.btnShowConnection = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnAutoSize = New System.Windows.Forms.CheckBox
        Me.ddCommand = New System.Windows.Forms.ComboBox
        Me.timerFilter = New System.Windows.Forms.Timer(Me.components)
        Me.btnCommand = New System.Windows.Forms.Button
        Me.btnNewTab = New System.Windows.Forms.Button
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelColumn.SuspendLayout()
        CType(Me.dgTableColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.groupConnection.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgContent
        '
        Me.dgContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgContent.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgContent.Location = New System.Drawing.Point(170, 28)
        Me.dgContent.Name = "dgContent"
        DataGridViewCellStyle2.NullValue = "NULL"
        Me.dgContent.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgContent.Size = New System.Drawing.Size(683, 516)
        Me.dgContent.TabIndex = 0
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(168, 1)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(60, 21)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'ddDatabase
        '
        Me.ddDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddDatabase.FormattingEnabled = True
        Me.ddDatabase.Location = New System.Drawing.Point(6, 18)
        Me.ddDatabase.Name = "ddDatabase"
        Me.ddDatabase.Size = New System.Drawing.Size(150, 20)
        Me.ddDatabase.TabIndex = 2
        '
        'btnShowFilterColumn
        '
        Me.btnShowFilterColumn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowFilterColumn.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnShowFilterColumn.Location = New System.Drawing.Point(778, 3)
        Me.btnShowFilterColumn.Name = "btnShowFilterColumn"
        Me.btnShowFilterColumn.Size = New System.Drawing.Size(75, 21)
        Me.btnShowFilterColumn.TabIndex = 5
        Me.btnShowFilterColumn.Text = "Filter"
        Me.btnShowFilterColumn.UseVisualStyleBackColor = False
        '
        'panelColumn
        '
        Me.panelColumn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelColumn.Controls.Add(Me.btnCopyColumnName)
        Me.panelColumn.Controls.Add(Me.dgTableColumn)
        Me.panelColumn.Controls.Add(Me.btnToggleColumn)
        Me.panelColumn.Location = New System.Drawing.Point(628, 28)
        Me.panelColumn.Name = "panelColumn"
        Me.panelColumn.Size = New System.Drawing.Size(225, 516)
        Me.panelColumn.TabIndex = 7
        Me.panelColumn.Visible = False
        '
        'btnCopyColumnName
        '
        Me.btnCopyColumnName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopyColumnName.Location = New System.Drawing.Point(134, 492)
        Me.btnCopyColumnName.Name = "btnCopyColumnName"
        Me.btnCopyColumnName.Size = New System.Drawing.Size(81, 21)
        Me.btnCopyColumnName.TabIndex = 18
        Me.btnCopyColumnName.Text = "Copy"
        Me.btnCopyColumnName.UseVisualStyleBackColor = True
        '
        'dgTableColumn
        '
        Me.dgTableColumn.AllowUserToAddRows = False
        Me.dgTableColumn.AllowUserToDeleteRows = False
        Me.dgTableColumn.AllowUserToResizeRows = False
        Me.dgTableColumn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTableColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTableColumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcShow, Me.dcName, Me.dcDataType})
        Me.dgTableColumn.Location = New System.Drawing.Point(9, 3)
        Me.dgTableColumn.Name = "dgTableColumn"
        Me.dgTableColumn.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgTableColumn.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTableColumn.Size = New System.Drawing.Size(206, 488)
        Me.dgTableColumn.TabIndex = 17
        '
        'dcShow
        '
        Me.dcShow.HeaderText = " "
        Me.dcShow.Name = "dcShow"
        Me.dcShow.Width = 20
        '
        'dcName
        '
        Me.dcName.HeaderText = "Name"
        Me.dcName.Name = "dcName"
        Me.dcName.ReadOnly = True
        Me.dcName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcName.Width = 80
        '
        'dcDataType
        '
        Me.dcDataType.HeaderText = "DataType"
        Me.dcDataType.Name = "dcDataType"
        Me.dcDataType.ReadOnly = True
        Me.dcDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dcDataType.Width = 80
        '
        'btnToggleColumn
        '
        Me.btnToggleColumn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnToggleColumn.Location = New System.Drawing.Point(10, 492)
        Me.btnToggleColumn.Name = "btnToggleColumn"
        Me.btnToggleColumn.Size = New System.Drawing.Size(118, 21)
        Me.btnToggleColumn.TabIndex = 7
        Me.btnToggleColumn.Text = "Toogle"
        Me.btnToggleColumn.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(234, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(58, 21)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barProgress, Me.lblStatus, Me.lblStatus2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 546)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(855, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'barProgress
        '
        Me.barProgress.Name = "barProgress"
        Me.barProgress.Size = New System.Drawing.Size(500, 16)
        '
        'lblStatus
        '
        Me.lblStatus.ForeColor = System.Drawing.Color.Navy
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 17)
        Me.lblStatus.Text = "Status"
        '
        'lblStatus2
        '
        Me.lblStatus2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblStatus2.Name = "lblStatus2"
        Me.lblStatus2.Size = New System.Drawing.Size(44, 17)
        Me.lblStatus2.Text = "Status2"
        '
        'groupConnection
        '
        Me.groupConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupConnection.Controls.Add(Me.ddTable)
        Me.groupConnection.Controls.Add(Me.ddDatabase)
        Me.groupConnection.Location = New System.Drawing.Point(2, 24)
        Me.groupConnection.Name = "groupConnection"
        Me.groupConnection.Size = New System.Drawing.Size(162, 521)
        Me.groupConnection.TabIndex = 12
        Me.groupConnection.TabStop = False
        Me.groupConnection.Text = "Connection"
        '
        'ddTable
        '
        Me.ddTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ddTable.FormattingEnabled = True
        Me.ddTable.ItemHeight = 12
        Me.ddTable.Location = New System.Drawing.Point(6, 42)
        Me.ddTable.Name = "ddTable"
        Me.ddTable.Size = New System.Drawing.Size(150, 472)
        Me.ddTable.TabIndex = 18
        '
        'btnShowConnection
        '
        Me.btnShowConnection.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnShowConnection.Location = New System.Drawing.Point(2, 0)
        Me.btnShowConnection.Name = "btnShowConnection"
        Me.btnShowConnection.Size = New System.Drawing.Size(162, 21)
        Me.btnShowConnection.TabIndex = 13
        Me.btnShowConnection.Text = "Database && Table"
        Me.btnShowConnection.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'btnAutoSize
        '
        Me.btnAutoSize.Appearance = System.Windows.Forms.Appearance.Button
        Me.btnAutoSize.BackColor = System.Drawing.Color.GreenYellow
        Me.btnAutoSize.Location = New System.Drawing.Point(298, 1)
        Me.btnAutoSize.Name = "btnAutoSize"
        Me.btnAutoSize.Size = New System.Drawing.Size(67, 21)
        Me.btnAutoSize.TabIndex = 15
        Me.btnAutoSize.Text = "Auto Size"
        Me.btnAutoSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAutoSize.UseVisualStyleBackColor = False
        '
        'ddCommand
        '
        Me.ddCommand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddCommand.FormattingEnabled = True
        Me.ddCommand.Location = New System.Drawing.Point(493, 3)
        Me.ddCommand.Name = "ddCommand"
        Me.ddCommand.Size = New System.Drawing.Size(279, 20)
        Me.ddCommand.TabIndex = 16
        '
        'timerFilter
        '
        Me.timerFilter.Interval = 500
        '
        'btnCommand
        '
        Me.btnCommand.BackColor = System.Drawing.Color.Cyan
        Me.btnCommand.Location = New System.Drawing.Point(426, 1)
        Me.btnCommand.Name = "btnCommand"
        Me.btnCommand.Size = New System.Drawing.Size(61, 21)
        Me.btnCommand.TabIndex = 17
        Me.btnCommand.Text = "where"
        Me.btnCommand.UseVisualStyleBackColor = False
        '
        'btnNewTab
        '
        Me.btnNewTab.Location = New System.Drawing.Point(366, 1)
        Me.btnNewTab.Name = "btnNewTab"
        Me.btnNewTab.Size = New System.Drawing.Size(58, 21)
        Me.btnNewTab.TabIndex = 18
        Me.btnNewTab.Text = "New"
        Me.btnNewTab.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 568)
        Me.Controls.Add(Me.btnNewTab)
        Me.Controls.Add(Me.ddCommand)
        Me.Controls.Add(Me.btnAutoSize)
        Me.Controls.Add(Me.btnShowConnection)
        Me.Controls.Add(Me.btnCommand)
        Me.Controls.Add(Me.groupConnection)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.panelColumn)
        Me.Controls.Add(Me.btnShowFilterColumn)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.dgContent)
        Me.Name = "Form1"
        Me.Text = "Table Viewer"
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelColumn.ResumeLayout(False)
        CType(Me.dgTableColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.groupConnection.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgContent As System.Windows.Forms.DataGridView
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents ddDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents btnShowFilterColumn As System.Windows.Forms.Button
    Friend WithEvents panelColumn As System.Windows.Forms.Panel
    Friend WithEvents btnToggleColumn As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents barProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents groupConnection As System.Windows.Forms.GroupBox
    Friend WithEvents btnShowConnection As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnAutoSize As System.Windows.Forms.CheckBox
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatus2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ddCommand As System.Windows.Forms.ComboBox
    Friend WithEvents timerFilter As System.Windows.Forms.Timer
    Friend WithEvents dgTableColumn As System.Windows.Forms.DataGridView
    Friend WithEvents dcShow As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCommand As System.Windows.Forms.Button
    Friend WithEvents ddTable As System.Windows.Forms.ListBox
    Friend WithEvents btnNewTab As System.Windows.Forms.Button
    Friend WithEvents btnCopyColumnName As System.Windows.Forms.Button

End Class
