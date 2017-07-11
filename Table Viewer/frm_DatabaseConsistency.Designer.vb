<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_DatabaseConsistency
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_DatabaseConsistency))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtColumnName = New System.Windows.Forms.TextBox()
        Me.lvwColumn = New CHKControl.ExtendedListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnList = New System.Windows.Forms.Button()
        Me.btnAnalyze = New System.Windows.Forms.Button()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lvwReference = New CHKControl.ExtendedListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnListDiscrepancy = New System.Windows.Forms.Button()
        Me.lblResult2 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataType = New System.Windows.Forms.TextBox()
        Me.btnListByDataType = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Column Name"
        '
        'txtColumnName
        '
        Me.txtColumnName.Location = New System.Drawing.Point(107, 6)
        Me.txtColumnName.Name = "txtColumnName"
        Me.txtColumnName.Size = New System.Drawing.Size(135, 20)
        Me.txtColumnName.TabIndex = 0
        '
        'lvwColumn
        '
        Me.lvwColumn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwColumn.CheckedTagIds = New Integer(-1) {}
        Me.lvwColumn.CheckedTagValues = New String(-1) {}
        Me.lvwColumn.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader5})
        Me.lvwColumn.FullRowSelect = True
        Me.lvwColumn.GridLines = True
        Me.lvwColumn.HideSelection = False
        Me.lvwColumn.Location = New System.Drawing.Point(4, 70)
        Me.lvwColumn.Name = "lvwColumn"
        Me.lvwColumn.SelectedTag = Nothing
        Me.lvwColumn.SelectedTagId = -2147483648
        Me.lvwColumn.SelectedTagValue = Nothing
        Me.lvwColumn.Size = New System.Drawing.Size(389, 240)
        Me.lvwColumn.TabIndex = 10
        Me.lvwColumn.UseCompatibleStateImageBehavior = False
        Me.lvwColumn.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Column"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Most Common DataType"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Stat."
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 100
        '
        'btnList
        '
        Me.btnList.Image = CType(resources.GetObject("btnList.Image"), System.Drawing.Image)
        Me.btnList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnList.Location = New System.Drawing.Point(248, 4)
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(72, 23)
        Me.btnList.TabIndex = 3
        Me.btnList.TabStop = False
        Me.btnList.Text = "Search"
        Me.btnList.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnList.UseVisualStyleBackColor = True
        '
        'btnAnalyze
        '
        Me.btnAnalyze.Location = New System.Drawing.Point(682, 3)
        Me.btnAnalyze.Name = "btnAnalyze"
        Me.btnAnalyze.Size = New System.Drawing.Size(88, 23)
        Me.btnAnalyze.TabIndex = 4
        Me.btnAnalyze.Text = "Refresh All"
        Me.btnAnalyze.UseVisualStyleBackColor = True
        Me.btnAnalyze.Visible = False
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblResult.Location = New System.Drawing.Point(348, 54)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(39, 13)
        Me.lblResult.TabIndex = 5
        Me.lblResult.Text = "Label2"
        '
        'lvwReference
        '
        Me.lvwReference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwReference.CheckedTagIds = New Integer(-1) {}
        Me.lvwReference.CheckedTagValues = New String(-1) {}
        Me.lvwReference.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvwReference.FullRowSelect = True
        Me.lvwReference.GridLines = True
        Me.lvwReference.Location = New System.Drawing.Point(399, 70)
        Me.lvwReference.Name = "lvwReference"
        Me.lvwReference.SelectedTag = Nothing
        Me.lvwReference.SelectedTagId = -2147483648
        Me.lvwReference.SelectedTagValue = Nothing
        Me.lvwReference.Size = New System.Drawing.Size(375, 240)
        Me.lvwReference.TabIndex = 11
        Me.lvwReference.UseCompatibleStateImageBehavior = False
        Me.lvwReference.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Data Type"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Reference Object"
        Me.ColumnHeader4.Width = 219
        '
        'btnListDiscrepancy
        '
        Me.btnListDiscrepancy.Image = CType(resources.GetObject("btnListDiscrepancy.Image"), System.Drawing.Image)
        Me.btnListDiscrepancy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListDiscrepancy.Location = New System.Drawing.Point(351, 3)
        Me.btnListDiscrepancy.Name = "btnListDiscrepancy"
        Me.btnListDiscrepancy.Size = New System.Drawing.Size(143, 23)
        Me.btnListDiscrepancy.TabIndex = 3
        Me.btnListDiscrepancy.Text = "Show discrepancy only"
        Me.btnListDiscrepancy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnListDiscrepancy.UseVisualStyleBackColor = True
        '
        'lblResult2
        '
        Me.lblResult2.AutoSize = True
        Me.lblResult2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblResult2.Location = New System.Drawing.Point(1, 54)
        Me.lblResult2.Name = "lblResult2"
        Me.lblResult2.Size = New System.Drawing.Size(39, 13)
        Me.lblResult2.TabIndex = 8
        Me.lblResult2.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Data Type"
        '
        'txtDataType
        '
        Me.txtDataType.Location = New System.Drawing.Point(107, 29)
        Me.txtDataType.Name = "txtDataType"
        Me.txtDataType.Size = New System.Drawing.Size(135, 20)
        Me.txtDataType.TabIndex = 1
        '
        'btnListByDataType
        '
        Me.btnListByDataType.Image = CType(resources.GetObject("btnListByDataType.Image"), System.Drawing.Image)
        Me.btnListByDataType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListByDataType.Location = New System.Drawing.Point(248, 28)
        Me.btnListByDataType.Name = "btnListByDataType"
        Me.btnListByDataType.Size = New System.Drawing.Size(72, 23)
        Me.btnListByDataType.TabIndex = 11
        Me.btnListByDataType.TabStop = False
        Me.btnListByDataType.Text = "Search"
        Me.btnListByDataType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnListByDataType.UseVisualStyleBackColor = True
        '
        'frm_DatabaseConsistency
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 317)
        Me.Controls.Add(Me.btnListByDataType)
        Me.Controls.Add(Me.txtDataType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblResult2)
        Me.Controls.Add(Me.btnListDiscrepancy)
        Me.Controls.Add(Me.lvwReference)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.btnAnalyze)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.lvwColumn)
        Me.Controls.Add(Me.txtColumnName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_DatabaseConsistency"
        Me.Text = "Table Columns Consistency Check"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtColumnName As System.Windows.Forms.TextBox
    Friend WithEvents lvwColumn As CHKControl.ExtendedListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnList As System.Windows.Forms.Button
    Friend WithEvents btnAnalyze As System.Windows.Forms.Button
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lvwReference As CHKControl.ExtendedListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnListDiscrepancy As System.Windows.Forms.Button
    Friend WithEvents lblResult2 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDataType As System.Windows.Forms.TextBox
    Friend WithEvents btnListByDataType As System.Windows.Forms.Button
End Class
