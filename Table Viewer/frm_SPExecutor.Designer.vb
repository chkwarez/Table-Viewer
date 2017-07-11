<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SPExecutor
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.lblObject = New System.Windows.Forms.Label()
        Me.dgContent = New CHKControl.GridView.DbDataGrid()
        Me.dcName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcDataType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcUseNullValue = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dcValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRun = New System.Windows.Forms.Button()
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Database"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Executable Object"
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(123, 9)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(39, 13)
        Me.lblDatabase.TabIndex = 2
        Me.lblDatabase.Text = "Label3"
        '
        'lblObject
        '
        Me.lblObject.AutoSize = True
        Me.lblObject.Location = New System.Drawing.Point(123, 25)
        Me.lblObject.Name = "lblObject"
        Me.lblObject.Size = New System.Drawing.Size(39, 13)
        Me.lblObject.TabIndex = 3
        Me.lblObject.Text = "Label4"
        '
        'dgContent
        '
        Me.dgContent.AllowUserToAddRows = False
        Me.dgContent.AllowUserToDeleteRows = False
        Me.dgContent.AllowUserToResizeRows = False
        Me.dgContent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgContent.BackgroundColor = System.Drawing.Color.White
        Me.dgContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgContent.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcName, Me.dcDataType, Me.dcUseNullValue, Me.dcValue})
        Me.dgContent.Location = New System.Drawing.Point(12, 49)
        Me.dgContent.Name = "dgContent"
        Me.dgContent.RowHeadersVisible = False
        DataGridViewCellStyle1.NullValue = "NULL"
        Me.dgContent.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgContent.Size = New System.Drawing.Size(492, 346)
        Me.dgContent.TabIndex = 4
        '
        'dcName
        '
        Me.dcName.HeaderText = "Variable"
        Me.dcName.Name = "dcName"
        '
        'dcDataType
        '
        Me.dcDataType.HeaderText = "Data Type"
        Me.dcDataType.Name = "dcDataType"
        '
        'dcUseNullValue
        '
        Me.dcUseNullValue.HeaderText = "Pass Null Value"
        Me.dcUseNullValue.Name = "dcUseNullValue"
        '
        'dcValue
        '
        Me.dcValue.HeaderText = "Value"
        Me.dcValue.Name = "dcValue"
        Me.dcValue.Width = 150
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(429, 20)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(75, 23)
        Me.btnRun.TabIndex = 5
        Me.btnRun.Text = "Run (F5)"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'frm_SPExecutor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 405)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.dgContent)
        Me.Controls.Add(Me.lblObject)
        Me.Controls.Add(Me.lblDatabase)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_SPExecutor"
        Me.Text = "Stored Procedure Executor"
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents lblObject As System.Windows.Forms.Label
    Friend WithEvents dgContent As CHKControl.GridView.DbDataGrid
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents dcName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcUseNullValue As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dcValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
