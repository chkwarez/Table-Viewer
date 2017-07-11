<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConnectionWizard
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ConnectionWizard))
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtConnStr = New System.Windows.Forms.TextBox()
        Me.chkTrustedConnection = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtServerName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgFavorite = New CHKControl.GridView.SmartDataGrid()
        Me.dgcSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgcName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcConnStr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcDefaultDatabase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAddConn = New System.Windows.Forms.Button()
        Me.btnSaveSelected = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgFavorite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(109, 64)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 3
        '
        'txtConnStr
        '
        Me.txtConnStr.Location = New System.Drawing.Point(119, 10)
        Me.txtConnStr.Name = "txtConnStr"
        Me.txtConnStr.Size = New System.Drawing.Size(480, 20)
        Me.txtConnStr.TabIndex = 0
        '
        'chkTrustedConnection
        '
        Me.chkTrustedConnection.AutoSize = True
        Me.chkTrustedConnection.Location = New System.Drawing.Point(9, 19)
        Me.chkTrustedConnection.Name = "chkTrustedConnection"
        Me.chkTrustedConnection.Size = New System.Drawing.Size(243, 17)
        Me.chkTrustedConnection.TabIndex = 1
        Me.chkTrustedConnection.Text = "Trusted Connection (Windows Authentication)"
        Me.chkTrustedConnection.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(6, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(256, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Indicate the port number followed by ',' (comma) sign."
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOK.Image = Global.Table_Viewer.My.Resources.Resources.Connect_Big
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOK.Location = New System.Drawing.Point(605, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(119, 88)
        Me.btnOK.TabIndex = 101
        Me.btnOK.Text = "Connect"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(97, 17)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(175, 20)
        Me.txtServerName.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Server Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDatabase)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtServerName)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(286, 95)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Server"
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(97, 63)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(175, 20)
        Me.txtDatabase.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Database"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(109, 40)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(100, 20)
        Me.txtUserID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "User ID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkTrustedConnection)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtUserID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(313, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(286, 95)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Account"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Connection String"
        '
        'dgFavorite
        '
        Me.dgFavorite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgFavorite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFavorite.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcSelect, Me.dgcName, Me.dgcConnStr, Me.dgcDefaultDatabase})
        Me.dgFavorite.Location = New System.Drawing.Point(3, 164)
        Me.dgFavorite.Name = "dgFavorite"
        Me.dgFavorite.Size = New System.Drawing.Size(721, 292)
        Me.dgFavorite.TabIndex = 102
        '
        'dgcSelect
        '
        Me.dgcSelect.HeaderText = "Connect"
        Me.dgcSelect.Name = "dgcSelect"
        Me.dgcSelect.Text = "Connect"
        Me.dgcSelect.Width = 55
        '
        'dgcName
        '
        Me.dgcName.DataPropertyName = "FriendlyName"
        Me.dgcName.HeaderText = "Name"
        Me.dgcName.Name = "dgcName"
        Me.dgcName.Width = 150
        '
        'dgcConnStr
        '
        Me.dgcConnStr.DataPropertyName = "ConnectionString"
        Me.dgcConnStr.HeaderText = "Connection String"
        Me.dgcConnStr.Name = "dgcConnStr"
        Me.dgcConnStr.Width = 300
        '
        'dgcDefaultDatabase
        '
        Me.dgcDefaultDatabase.DataPropertyName = "DefaultDatabase"
        Me.dgcDefaultDatabase.HeaderText = "Database"
        Me.dgcDefaultDatabase.Name = "dgcDefaultDatabase"
        Me.dgcDefaultDatabase.Width = 120
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Favorites"
        '
        'btnAddConn
        '
        Me.btnAddConn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddConn.Image = CType(resources.GetObject("btnAddConn.Image"), System.Drawing.Image)
        Me.btnAddConn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddConn.Location = New System.Drawing.Point(605, 106)
        Me.btnAddConn.Name = "btnAddConn"
        Me.btnAddConn.Size = New System.Drawing.Size(119, 52)
        Me.btnAddConn.TabIndex = 106
        Me.btnAddConn.Text = "Add to Favorite"
        Me.btnAddConn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddConn.UseVisualStyleBackColor = True
        '
        'btnSaveSelected
        '
        Me.btnSaveSelected.Location = New System.Drawing.Point(484, 135)
        Me.btnSaveSelected.Name = "btnSaveSelected"
        Me.btnSaveSelected.Size = New System.Drawing.Size(115, 23)
        Me.btnSaveSelected.TabIndex = 107
        Me.btnSaveSelected.Text = "Save to selected"
        Me.btnSaveSelected.UseVisualStyleBackColor = True
        '
        'frm_ConnectionWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 459)
        Me.Controls.Add(Me.btnSaveSelected)
        Me.Controls.Add(Me.btnAddConn)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgFavorite)
        Me.Controls.Add(Me.txtConnStr)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_ConnectionWizard"
        Me.Text = "Connection Wizard"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgFavorite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtConnStr As System.Windows.Forms.TextBox
    Friend WithEvents chkTrustedConnection As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgFavorite As CHKControl.GridView.SmartDataGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgcSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dgcName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcConnStr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcDefaultDatabase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAddConn As Button
    Friend WithEvents btnSaveSelected As Button
End Class
