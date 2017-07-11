<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_TableColumnEditor
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtColumnName = New CHKControl.ExtendedTextBox()
        Me.txtDataType = New CHKControl.ExtendedTextBox()
        Me.chkAllowNull = New System.Windows.Forms.CheckBox()
        Me.txtInitValue = New CHKControl.ExtendedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkApplyInitValue = New System.Windows.Forms.CheckBox()
        Me.btnAddColumn = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lnkNvarchar = New System.Windows.Forms.LinkLabel()
        Me.lnkDatetime = New System.Windows.Forms.LinkLabel()
        Me.lnkDecimal = New System.Windows.Forms.LinkLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.38168!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.61832!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtColumnName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDataType, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkAllowNull, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtInitValue, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chkApplyInitValue, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(273, 120)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Column Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Allow Null?"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Initial Value"
        '
        'txtColumnName
        '
        Me.txtColumnName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtColumnName.Location = New System.Drawing.Point(140, 3)
        Me.txtColumnName.Name = "txtColumnName"
        Me.txtColumnName.Size = New System.Drawing.Size(130, 20)
        Me.txtColumnName.TabIndex = 4
        '
        'txtDataType
        '
        Me.txtDataType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDataType.Location = New System.Drawing.Point(140, 27)
        Me.txtDataType.Name = "txtDataType"
        Me.txtDataType.Size = New System.Drawing.Size(130, 20)
        Me.txtDataType.TabIndex = 5
        '
        'chkAllowNull
        '
        Me.chkAllowNull.AutoSize = True
        Me.chkAllowNull.Location = New System.Drawing.Point(140, 51)
        Me.chkAllowNull.Name = "chkAllowNull"
        Me.chkAllowNull.Size = New System.Drawing.Size(15, 14)
        Me.chkAllowNull.TabIndex = 6
        Me.chkAllowNull.UseVisualStyleBackColor = True
        '
        'txtInitValue
        '
        Me.txtInitValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInitValue.Location = New System.Drawing.Point(140, 99)
        Me.txtInitValue.Name = "txtInitValue"
        Me.txtInitValue.ReadOnly = True
        Me.txtInitValue.Size = New System.Drawing.Size(130, 20)
        Me.txtInitValue.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Apply Initial Value?"
        '
        'chkApplyInitValue
        '
        Me.chkApplyInitValue.AutoSize = True
        Me.chkApplyInitValue.Location = New System.Drawing.Point(140, 75)
        Me.chkApplyInitValue.Name = "chkApplyInitValue"
        Me.chkApplyInitValue.Size = New System.Drawing.Size(15, 14)
        Me.chkApplyInitValue.TabIndex = 9
        Me.chkApplyInitValue.UseVisualStyleBackColor = True
        '
        'btnAddColumn
        '
        Me.btnAddColumn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddColumn.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAddColumn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAddColumn.Location = New System.Drawing.Point(251, 132)
        Me.btnAddColumn.Name = "btnAddColumn"
        Me.btnAddColumn.Size = New System.Drawing.Size(92, 30)
        Me.btnAddColumn.TabIndex = 2
        Me.btnAddColumn.Text = "Add Column"
        Me.btnAddColumn.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(349, 132)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 30)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lnkNvarchar
        '
        Me.lnkNvarchar.AutoSize = True
        Me.lnkNvarchar.Location = New System.Drawing.Point(287, 38)
        Me.lnkNvarchar.Name = "lnkNvarchar"
        Me.lnkNvarchar.Size = New System.Drawing.Size(49, 13)
        Me.lnkNvarchar.TabIndex = 10
        Me.lnkNvarchar.TabStop = True
        Me.lnkNvarchar.Text = "nvarchar"
        '
        'lnkDatetime
        '
        Me.lnkDatetime.AutoSize = True
        Me.lnkDatetime.Location = New System.Drawing.Point(340, 38)
        Me.lnkDatetime.Name = "lnkDatetime"
        Me.lnkDatetime.Size = New System.Drawing.Size(47, 13)
        Me.lnkDatetime.TabIndex = 11
        Me.lnkDatetime.TabStop = True
        Me.lnkDatetime.Text = "datetime"
        '
        'lnkDecimal
        '
        Me.lnkDecimal.AutoSize = True
        Me.lnkDecimal.Location = New System.Drawing.Point(393, 38)
        Me.lnkDecimal.Name = "lnkDecimal"
        Me.lnkDecimal.Size = New System.Drawing.Size(43, 13)
        Me.lnkDecimal.TabIndex = 12
        Me.lnkDecimal.TabStop = True
        Me.lnkDecimal.Text = "decimal"
        '
        'frm_TableColumnEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 169)
        Me.Controls.Add(Me.lnkDecimal)
        Me.Controls.Add(Me.lnkDatetime)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddColumn)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lnkNvarchar)
        Me.Name = "frm_TableColumnEditor"
        Me.Text = "Table Column"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAddColumn As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtColumnName As CHKControl.ExtendedTextBox
    Friend WithEvents txtDataType As CHKControl.ExtendedTextBox
    Friend WithEvents chkAllowNull As System.Windows.Forms.CheckBox
    Friend WithEvents txtInitValue As CHKControl.ExtendedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkApplyInitValue As System.Windows.Forms.CheckBox
    Friend WithEvents lnkNvarchar As LinkLabel
    Friend WithEvents lnkDatetime As LinkLabel
    Friend WithEvents lnkDecimal As LinkLabel
End Class
