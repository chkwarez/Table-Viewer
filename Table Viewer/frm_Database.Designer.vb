<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Database
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Database))
        Me.ddDatabase = New System.Windows.Forms.ComboBox()
        Me.lvwTable = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ddConnectionString = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnResetDatabase = New System.Windows.Forms.Button()
        Me.lblTableMatch = New System.Windows.Forms.Label()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.lblStatistics = New System.Windows.Forms.Label()
        Me.cmdgSave = New System.Windows.Forms.SaveFileDialog()
        Me.cmdgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.chkInformationSchema = New System.Windows.Forms.RadioButton()
        Me.chkUserTable = New System.Windows.Forms.RadioButton()
        Me.chkSystemView = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNewConnection = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.btnBackupDatabase = New System.Windows.Forms.ToolStripButton()
        Me.btnRestoreDatabase = New System.Windows.Forms.ToolStripButton()
        Me.btnCreateDatabase = New System.Windows.Forms.ToolStripButton()
        Me.btnRenameDatabase = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleteDatabase = New System.Windows.Forms.ToolStripButton()
        Me.btnShowDatabaseDetails = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.btnRenameTable = New System.Windows.Forms.ToolStripButton()
        Me.btnEditTable = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleteTable = New System.Windows.Forms.ToolStripButton()
        Me.lblServerProperty = New System.Windows.Forms.Label()
        Me.lblDatabaseProperty = New System.Windows.Forms.Label()
        Me.chkSystemDatabase = New System.Windows.Forms.CheckBox()
        Me.txtSearchObject = New System.Windows.Forms.TextBox()
        Me.txtSearchResult = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bgConnect = New CHKControl.ExtendedBackgroundWorker()
        Me.chkUserView = New System.Windows.Forms.RadioButton()
        Me.chkUserTableAndView = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ddDatabase
        '
        Me.ddDatabase.DropDownHeight = 250
        Me.ddDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddDatabase.FormattingEnabled = True
        Me.ddDatabase.IntegralHeight = False
        Me.ddDatabase.ItemHeight = 14
        Me.ddDatabase.Location = New System.Drawing.Point(86, 66)
        Me.ddDatabase.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ddDatabase.Name = "ddDatabase"
        Me.ddDatabase.Size = New System.Drawing.Size(518, 22)
        Me.ddDatabase.TabIndex = 1
        '
        'lvwTable
        '
        Me.lvwTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwTable.FullRowSelect = True
        Me.lvwTable.Location = New System.Drawing.Point(86, 122)
        Me.lvwTable.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvwTable.Name = "lvwTable"
        Me.lvwTable.Size = New System.Drawing.Size(694, 236)
        Me.lvwTable.TabIndex = 2
        Me.lvwTable.UseCompatibleStateImageBehavior = False
        Me.lvwTable.View = System.Windows.Forms.View.List
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Database"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tables and Views"
        '
        'ddConnectionString
        '
        Me.ddConnectionString.FormattingEnabled = True
        Me.ddConnectionString.Location = New System.Drawing.Point(86, 28)
        Me.ddConnectionString.Name = "ddConnectionString"
        Me.ddConnectionString.Size = New System.Drawing.Size(518, 22)
        Me.ddConnectionString.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Connection"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(610, 28)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(74, 22)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnResetDatabase
        '
        Me.btnResetDatabase.Location = New System.Drawing.Point(610, 66)
        Me.btnResetDatabase.Name = "btnResetDatabase"
        Me.btnResetDatabase.Size = New System.Drawing.Size(74, 22)
        Me.btnResetDatabase.TabIndex = 10
        Me.btnResetDatabase.Text = "Reset"
        Me.btnResetDatabase.UseVisualStyleBackColor = True
        '
        'lblTableMatch
        '
        Me.lblTableMatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTableMatch.AutoSize = True
        Me.lblTableMatch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableMatch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTableMatch.Location = New System.Drawing.Point(373, 361)
        Me.lblTableMatch.Name = "lblTableMatch"
        Me.lblTableMatch.Size = New System.Drawing.Size(287, 14)
        Me.lblTableMatch.TabIndex = 11
        Me.lblTableMatch.Text = "You can search objects by typing the name directly above"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Enabled = False
        Me.btnDisconnect.Location = New System.Drawing.Point(683, 28)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(74, 22)
        Me.btnDisconnect.TabIndex = 13
        Me.btnDisconnect.Text = "Disconnected"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'lblStatistics
        '
        Me.lblStatistics.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatistics.AutoSize = True
        Me.lblStatistics.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblStatistics.Location = New System.Drawing.Point(83, 361)
        Me.lblStatistics.Name = "lblStatistics"
        Me.lblStatistics.Size = New System.Drawing.Size(51, 14)
        Me.lblStatistics.TabIndex = 14
        Me.lblStatistics.Text = "Statistics"
        '
        'cmdgOpen
        '
        Me.cmdgOpen.FileName = "OpenFileDialog1"
        '
        'chkInformationSchema
        '
        Me.chkInformationSchema.AutoSize = True
        Me.chkInformationSchema.Location = New System.Drawing.Point(313, 102)
        Me.chkInformationSchema.Name = "chkInformationSchema"
        Me.chkInformationSchema.Size = New System.Drawing.Size(120, 18)
        Me.chkInformationSchema.TabIndex = 21
        Me.chkInformationSchema.Tag = "IS"
        Me.chkInformationSchema.Text = "Information Schema"
        Me.chkInformationSchema.UseVisualStyleBackColor = True
        '
        'chkUserTable
        '
        Me.chkUserTable.AutoSize = True
        Me.chkUserTable.Location = New System.Drawing.Point(207, 102)
        Me.chkUserTable.Name = "chkUserTable"
        Me.chkUserTable.Size = New System.Drawing.Size(50, 18)
        Me.chkUserTable.TabIndex = 19
        Me.chkUserTable.Tag = "USER"
        Me.chkUserTable.Text = "Table"
        Me.chkUserTable.UseVisualStyleBackColor = True
        '
        'chkSystemView
        '
        Me.chkSystemView.AutoSize = True
        Me.chkSystemView.Location = New System.Drawing.Point(439, 102)
        Me.chkSystemView.Name = "chkSystemView"
        Me.chkSystemView.Size = New System.Drawing.Size(90, 18)
        Me.chkSystemView.TabIndex = 22
        Me.chkSystemView.Tag = "IS"
        Me.chkSystemView.Text = "System View"
        Me.chkSystemView.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRefresh, Me.ToolStripSeparator1, Me.btnNewConnection, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.btnBackupDatabase, Me.btnRestoreDatabase, Me.btnCreateDatabase, Me.btnRenameDatabase, Me.btnDeleteDatabase, Me.btnShowDatabaseDetails, Me.ToolStripSeparator2, Me.ToolStripLabel2, Me.btnRenameTable, Me.btnEditTable, Me.btnDeleteTable})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(66, 22)
        Me.btnRefresh.Text = "Refresh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnNewConnection
        '
        Me.btnNewConnection.Image = Global.Table_Viewer.My.Resources.Resources.Connect
        Me.btnNewConnection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNewConnection.Name = "btnNewConnection"
        Me.btnNewConnection.Size = New System.Drawing.Size(116, 22)
        Me.btnNewConnection.Text = "New Connection"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripLabel1.Text = "Database"
        '
        'btnBackupDatabase
        '
        Me.btnBackupDatabase.Image = CType(resources.GetObject("btnBackupDatabase.Image"), System.Drawing.Image)
        Me.btnBackupDatabase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBackupDatabase.Name = "btnBackupDatabase"
        Me.btnBackupDatabase.Size = New System.Drawing.Size(66, 22)
        Me.btnBackupDatabase.Text = "Backup"
        '
        'btnRestoreDatabase
        '
        Me.btnRestoreDatabase.Image = CType(resources.GetObject("btnRestoreDatabase.Image"), System.Drawing.Image)
        Me.btnRestoreDatabase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRestoreDatabase.Name = "btnRestoreDatabase"
        Me.btnRestoreDatabase.Size = New System.Drawing.Size(66, 22)
        Me.btnRestoreDatabase.Text = "Restore"
        '
        'btnCreateDatabase
        '
        Me.btnCreateDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCreateDatabase.Image = CType(resources.GetObject("btnCreateDatabase.Image"), System.Drawing.Image)
        Me.btnCreateDatabase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCreateDatabase.Name = "btnCreateDatabase"
        Me.btnCreateDatabase.Size = New System.Drawing.Size(23, 22)
        Me.btnCreateDatabase.Text = "Create"
        Me.btnCreateDatabase.Visible = False
        '
        'btnRenameDatabase
        '
        Me.btnRenameDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRenameDatabase.Image = CType(resources.GetObject("btnRenameDatabase.Image"), System.Drawing.Image)
        Me.btnRenameDatabase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRenameDatabase.Name = "btnRenameDatabase"
        Me.btnRenameDatabase.Size = New System.Drawing.Size(23, 22)
        Me.btnRenameDatabase.Text = "Rename"
        Me.btnRenameDatabase.Visible = False
        '
        'btnDeleteDatabase
        '
        Me.btnDeleteDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeleteDatabase.Image = CType(resources.GetObject("btnDeleteDatabase.Image"), System.Drawing.Image)
        Me.btnDeleteDatabase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeleteDatabase.Name = "btnDeleteDatabase"
        Me.btnDeleteDatabase.Size = New System.Drawing.Size(23, 22)
        Me.btnDeleteDatabase.Text = "Delete"
        Me.btnDeleteDatabase.Visible = False
        '
        'btnShowDatabaseDetails
        '
        Me.btnShowDatabaseDetails.Image = Global.Table_Viewer.My.Resources.Resources.Details2
        Me.btnShowDatabaseDetails.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShowDatabaseDetails.Name = "btnShowDatabaseDetails"
        Me.btnShowDatabaseDetails.Size = New System.Drawing.Size(62, 22)
        Me.btnShowDatabaseDetails.Text = "Details"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel2.Text = "Table"
        '
        'btnRenameTable
        '
        Me.btnRenameTable.Image = CType(resources.GetObject("btnRenameTable.Image"), System.Drawing.Image)
        Me.btnRenameTable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRenameTable.Name = "btnRenameTable"
        Me.btnRenameTable.Size = New System.Drawing.Size(70, 22)
        Me.btnRenameTable.Text = "Rename"
        '
        'btnEditTable
        '
        Me.btnEditTable.Image = CType(resources.GetObject("btnEditTable.Image"), System.Drawing.Image)
        Me.btnEditTable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditTable.Name = "btnEditTable"
        Me.btnEditTable.Size = New System.Drawing.Size(47, 22)
        Me.btnEditTable.Text = "Edit"
        '
        'btnDeleteTable
        '
        Me.btnDeleteTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeleteTable.Image = CType(resources.GetObject("btnDeleteTable.Image"), System.Drawing.Image)
        Me.btnDeleteTable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeleteTable.Name = "btnDeleteTable"
        Me.btnDeleteTable.Size = New System.Drawing.Size(23, 22)
        Me.btnDeleteTable.Text = "Delete"
        '
        'lblServerProperty
        '
        Me.lblServerProperty.BackColor = System.Drawing.Color.Transparent
        Me.lblServerProperty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerProperty.ForeColor = System.Drawing.Color.Gray
        Me.lblServerProperty.Location = New System.Drawing.Point(87, 49)
        Me.lblServerProperty.Name = "lblServerProperty"
        Me.lblServerProperty.Size = New System.Drawing.Size(518, 15)
        Me.lblServerProperty.TabIndex = 23
        Me.lblServerProperty.Text = "Server"
        Me.lblServerProperty.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDatabaseProperty
        '
        Me.lblDatabaseProperty.BackColor = System.Drawing.Color.Transparent
        Me.lblDatabaseProperty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabaseProperty.ForeColor = System.Drawing.Color.Gray
        Me.lblDatabaseProperty.Location = New System.Drawing.Point(86, 87)
        Me.lblDatabaseProperty.Name = "lblDatabaseProperty"
        Me.lblDatabaseProperty.Size = New System.Drawing.Size(518, 15)
        Me.lblDatabaseProperty.TabIndex = 24
        Me.lblDatabaseProperty.Text = "Database"
        Me.lblDatabaseProperty.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkSystemDatabase
        '
        Me.chkSystemDatabase.AutoSize = True
        Me.chkSystemDatabase.Location = New System.Drawing.Point(690, 69)
        Me.chkSystemDatabase.Name = "chkSystemDatabase"
        Me.chkSystemDatabase.Size = New System.Drawing.Size(79, 18)
        Me.chkSystemDatabase.TabIndex = 25
        Me.chkSystemDatabase.Text = "System DB"
        Me.chkSystemDatabase.UseVisualStyleBackColor = True
        '
        'txtSearchObject
        '
        Me.txtSearchObject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSearchObject.Location = New System.Drawing.Point(86, 378)
        Me.txtSearchObject.Name = "txtSearchObject"
        Me.txtSearchObject.Size = New System.Drawing.Size(157, 20)
        Me.txtSearchObject.TabIndex = 26
        '
        'txtSearchResult
        '
        Me.txtSearchResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSearchResult.AutoSize = True
        Me.txtSearchResult.ForeColor = System.Drawing.Color.Purple
        Me.txtSearchResult.Location = New System.Drawing.Point(249, 381)
        Me.txtSearchResult.Name = "txtSearchResult"
        Me.txtSearchResult.Size = New System.Drawing.Size(75, 14)
        Me.txtSearchResult.TabIndex = 27
        Me.txtSearchResult.Text = "Search Result"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 381)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 14)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Search (F3)"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(533, 381)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(247, 14)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Press 'Enter' to open object, '\' to switch database"
        '
        'bgConnect
        '
        Me.bgConnect.WorkerReportsProgress = True
        Me.bgConnect.WorkerSupportsCancellation = True
        '
        'chkUserView
        '
        Me.chkUserView.AutoSize = True
        Me.chkUserView.Location = New System.Drawing.Point(260, 102)
        Me.chkUserView.Name = "chkUserView"
        Me.chkUserView.Size = New System.Drawing.Size(51, 18)
        Me.chkUserView.TabIndex = 20
        Me.chkUserView.Tag = "USER"
        Me.chkUserView.Text = "View"
        Me.chkUserView.UseVisualStyleBackColor = True
        '
        'chkUserTableAndView
        '
        Me.chkUserTableAndView.AutoSize = True
        Me.chkUserTableAndView.Checked = True
        Me.chkUserTableAndView.Location = New System.Drawing.Point(113, 102)
        Me.chkUserTableAndView.Name = "chkUserTableAndView"
        Me.chkUserTableAndView.Size = New System.Drawing.Size(89, 18)
        Me.chkUserTableAndView.TabIndex = 23
        Me.chkUserTableAndView.TabStop = True
        Me.chkUserTableAndView.Tag = "USER"
        Me.chkUserTableAndView.Text = "Table && View"
        Me.chkUserTableAndView.UseVisualStyleBackColor = True
        '
        'frm_Database
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 402)
        Me.Controls.Add(Me.chkUserTableAndView)
        Me.Controls.Add(Me.chkUserView)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSearchResult)
        Me.Controls.Add(Me.txtSearchObject)
        Me.Controls.Add(Me.chkSystemDatabase)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.chkSystemView)
        Me.Controls.Add(Me.chkInformationSchema)
        Me.Controls.Add(Me.chkUserTable)
        Me.Controls.Add(Me.lblStatistics)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.lblTableMatch)
        Me.Controls.Add(Me.btnResetDatabase)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ddConnectionString)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvwTable)
        Me.Controls.Add(Me.ddDatabase)
        Me.Controls.Add(Me.lblServerProperty)
        Me.Controls.Add(Me.lblDatabaseProperty)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_Database"
        Me.Text = "Database, Table and View"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ddDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents lvwTable As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ddConnectionString As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnResetDatabase As System.Windows.Forms.Button
    Friend WithEvents lblTableMatch As System.Windows.Forms.Label
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents lblStatistics As System.Windows.Forms.Label
    Friend WithEvents cmdgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmdgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkInformationSchema As System.Windows.Forms.RadioButton
    Friend WithEvents chkUserTable As System.Windows.Forms.RadioButton
    Friend WithEvents chkSystemView As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRestoreDatabase As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBackupDatabase As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRenameDatabase As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDeleteDatabase As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnRenameTable As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeleteTable As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCreateDatabase As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblServerProperty As System.Windows.Forms.Label
    Friend WithEvents lblDatabaseProperty As System.Windows.Forms.Label
    Friend WithEvents chkSystemDatabase As System.Windows.Forms.CheckBox
    Friend WithEvents txtSearchObject As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchResult As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnEditTable As System.Windows.Forms.ToolStripButton
    Friend WithEvents bgConnect As CHKControl.ExtendedBackgroundWorker
    Friend WithEvents btnShowDatabaseDetails As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNewConnection As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkUserView As System.Windows.Forms.RadioButton
    Friend WithEvents chkUserTableAndView As System.Windows.Forms.RadioButton
End Class
