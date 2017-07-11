<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.menuMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenDatabaseWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFindTable = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsRefreshAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsRefreshRegular = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCreateTable = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenColumnConsistency = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewQueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenQueryMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenExecuteQueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StoredProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSPManage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndexManage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDatabaseCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScriptDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManagementStudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FavoriteDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SwitchWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaximizeRestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinimizeRestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpenDatabase = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNewQuery = New System.Windows.Forms.ToolStripButton()
        Me.btnOpenSPManager = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.btnRestoreAll = New System.Windows.Forms.ToolStripButton()
        Me.btnTileHorizontal = New System.Windows.Forms.ToolStripButton()
        Me.btnTileVertical = New System.Windows.Forms.ToolStripButton()
        Me.btnCloseAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFullScreen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnTranslateChinese = New System.Windows.Forms.ToolStripButton()
        Me.TabBar1 = New CHKControl.TabBar()
        Me.cmdgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.timerAutoRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.menuMain.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuMain
        '
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem4, Me.QueryToolStripMenuItem, Me.StoredProcedureToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolsToolStripMenuItem, Me.FavoriteDatabaseToolStripMenuItem, Me.WToolStripMenuItem, Me.ToolStripMenuItem2})
        resources.ApplyResources(Me.menuMain, "menuMain")
        Me.menuMain.Name = "menuMain"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenDatabaseWindow, Me.mnuFindTable, Me.mnuClose, Me.ToolStripSeparator4, Me.RefreshToolStripMenuItem, Me.tsRefreshAll, Me.tsRefreshRegular, Me.ToolStripSeparator6, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        '
        'mnuOpenDatabaseWindow
        '
        Me.mnuOpenDatabaseWindow.Name = "mnuOpenDatabaseWindow"
        resources.ApplyResources(Me.mnuOpenDatabaseWindow, "mnuOpenDatabaseWindow")
        '
        'mnuFindTable
        '
        Me.mnuFindTable.Name = "mnuFindTable"
        resources.ApplyResources(Me.mnuFindTable, "mnuFindTable")
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        resources.ApplyResources(Me.mnuClose, "mnuClose")
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        resources.ApplyResources(Me.RefreshToolStripMenuItem, "RefreshToolStripMenuItem")
        '
        'tsRefreshAll
        '
        Me.tsRefreshAll.Name = "tsRefreshAll"
        resources.ApplyResources(Me.tsRefreshAll, "tsRefreshAll")
        '
        'tsRefreshRegular
        '
        Me.tsRefreshRegular.CheckOnClick = True
        Me.tsRefreshRegular.Name = "tsRefreshRegular"
        resources.ApplyResources(Me.tsRefreshRegular, "tsRefreshRegular")
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCreateTable, Me.mnuOpenColumnConsistency})
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'mnuCreateTable
        '
        Me.mnuCreateTable.Name = "mnuCreateTable"
        resources.ApplyResources(Me.mnuCreateTable, "mnuCreateTable")
        '
        'mnuOpenColumnConsistency
        '
        Me.mnuOpenColumnConsistency.Name = "mnuOpenColumnConsistency"
        resources.ApplyResources(Me.mnuOpenColumnConsistency, "mnuOpenColumnConsistency")
        '
        'QueryToolStripMenuItem
        '
        Me.QueryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewQueryToolStripMenuItem, Me.OpenQueryMenuItem, Me.OpenExecuteQueryToolStripMenuItem, Me.QueryHistoryToolStripMenuItem})
        Me.QueryToolStripMenuItem.Name = "QueryToolStripMenuItem"
        resources.ApplyResources(Me.QueryToolStripMenuItem, "QueryToolStripMenuItem")
        '
        'NewQueryToolStripMenuItem
        '
        Me.NewQueryToolStripMenuItem.Name = "NewQueryToolStripMenuItem"
        resources.ApplyResources(Me.NewQueryToolStripMenuItem, "NewQueryToolStripMenuItem")
        '
        'OpenQueryMenuItem
        '
        Me.OpenQueryMenuItem.Name = "OpenQueryMenuItem"
        resources.ApplyResources(Me.OpenQueryMenuItem, "OpenQueryMenuItem")
        '
        'OpenExecuteQueryToolStripMenuItem
        '
        Me.OpenExecuteQueryToolStripMenuItem.Name = "OpenExecuteQueryToolStripMenuItem"
        resources.ApplyResources(Me.OpenExecuteQueryToolStripMenuItem, "OpenExecuteQueryToolStripMenuItem")
        '
        'QueryHistoryToolStripMenuItem
        '
        Me.QueryHistoryToolStripMenuItem.Name = "QueryHistoryToolStripMenuItem"
        resources.ApplyResources(Me.QueryHistoryToolStripMenuItem, "QueryHistoryToolStripMenuItem")
        '
        'StoredProcedureToolStripMenuItem
        '
        Me.StoredProcedureToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSPManage})
        Me.StoredProcedureToolStripMenuItem.Name = "StoredProcedureToolStripMenuItem"
        resources.ApplyResources(Me.StoredProcedureToolStripMenuItem, "StoredProcedureToolStripMenuItem")
        '
        'mnuSPManage
        '
        Me.mnuSPManage.Name = "mnuSPManage"
        resources.ApplyResources(Me.mnuSPManage, "mnuSPManage")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuIndexManage})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuIndexManage
        '
        Me.mnuIndexManage.Name = "mnuIndexManage"
        resources.ApplyResources(Me.mnuIndexManage, "mnuIndexManage")
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptions, Me.ToolStripMenuItem3, Me.mnuDatabaseCopy, Me.ScriptDataToolStripMenuItem, Me.ManagementStudioToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        resources.ApplyResources(Me.ToolsToolStripMenuItem, "ToolsToolStripMenuItem")
        '
        'mnuOptions
        '
        Me.mnuOptions.Name = "mnuOptions"
        resources.ApplyResources(Me.mnuOptions, "mnuOptions")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'mnuDatabaseCopy
        '
        Me.mnuDatabaseCopy.Name = "mnuDatabaseCopy"
        resources.ApplyResources(Me.mnuDatabaseCopy, "mnuDatabaseCopy")
        '
        'ScriptDataToolStripMenuItem
        '
        Me.ScriptDataToolStripMenuItem.Name = "ScriptDataToolStripMenuItem"
        resources.ApplyResources(Me.ScriptDataToolStripMenuItem, "ScriptDataToolStripMenuItem")
        '
        'ManagementStudioToolStripMenuItem
        '
        Me.ManagementStudioToolStripMenuItem.Name = "ManagementStudioToolStripMenuItem"
        resources.ApplyResources(Me.ManagementStudioToolStripMenuItem, "ManagementStudioToolStripMenuItem")
        '
        'FavoriteDatabaseToolStripMenuItem
        '
        Me.FavoriteDatabaseToolStripMenuItem.Name = "FavoriteDatabaseToolStripMenuItem"
        resources.ApplyResources(Me.FavoriteDatabaseToolStripMenuItem, "FavoriteDatabaseToolStripMenuItem")
        '
        'WToolStripMenuItem
        '
        Me.WToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.HorizontalToolStripMenuItem, Me.VerticalToolStripMenuItem, Me.SwitchWindowToolStripMenuItem, Me.MaximizeRestoreToolStripMenuItem, Me.MinimizeRestoreToolStripMenuItem})
        Me.WToolStripMenuItem.Name = "WToolStripMenuItem"
        resources.ApplyResources(Me.WToolStripMenuItem, "WToolStripMenuItem")
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        resources.ApplyResources(Me.CascadeToolStripMenuItem, "CascadeToolStripMenuItem")
        '
        'HorizontalToolStripMenuItem
        '
        Me.HorizontalToolStripMenuItem.Name = "HorizontalToolStripMenuItem"
        resources.ApplyResources(Me.HorizontalToolStripMenuItem, "HorizontalToolStripMenuItem")
        '
        'VerticalToolStripMenuItem
        '
        Me.VerticalToolStripMenuItem.Name = "VerticalToolStripMenuItem"
        resources.ApplyResources(Me.VerticalToolStripMenuItem, "VerticalToolStripMenuItem")
        '
        'SwitchWindowToolStripMenuItem
        '
        Me.SwitchWindowToolStripMenuItem.Name = "SwitchWindowToolStripMenuItem"
        resources.ApplyResources(Me.SwitchWindowToolStripMenuItem, "SwitchWindowToolStripMenuItem")
        '
        'MaximizeRestoreToolStripMenuItem
        '
        Me.MaximizeRestoreToolStripMenuItem.Name = "MaximizeRestoreToolStripMenuItem"
        resources.ApplyResources(Me.MaximizeRestoreToolStripMenuItem, "MaximizeRestoreToolStripMenuItem")
        '
        'MinimizeRestoreToolStripMenuItem
        '
        Me.MinimizeRestoreToolStripMenuItem.Name = "MinimizeRestoreToolStripMenuItem"
        resources.ApplyResources(Me.MinimizeRestoreToolStripMenuItem, "MinimizeRestoreToolStripMenuItem")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpenDatabase, Me.ToolStripSeparator1, Me.btnNewQuery, Me.btnOpenSPManager, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.btnRestoreAll, Me.btnTileHorizontal, Me.btnTileVertical, Me.btnCloseAll, Me.ToolStripSeparator3, Me.btnFullScreen, Me.ToolStripSeparator5, Me.btnTranslateChinese})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'btnOpenDatabase
        '
        Me.btnOpenDatabase.CheckOnClick = True
        resources.ApplyResources(Me.btnOpenDatabase, "btnOpenDatabase")
        Me.btnOpenDatabase.Name = "btnOpenDatabase"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnNewQuery
        '
        resources.ApplyResources(Me.btnNewQuery, "btnNewQuery")
        Me.btnNewQuery.Name = "btnNewQuery"
        '
        'btnOpenSPManager
        '
        Me.btnOpenSPManager.CheckOnClick = True
        resources.ApplyResources(Me.btnOpenSPManager, "btnOpenSPManager")
        Me.btnOpenSPManager.Name = "btnOpenSPManager"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        resources.ApplyResources(Me.ToolStripLabel1, "ToolStripLabel1")
        '
        'btnRestoreAll
        '
        Me.btnRestoreAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnRestoreAll, "btnRestoreAll")
        Me.btnRestoreAll.Name = "btnRestoreAll"
        '
        'btnTileHorizontal
        '
        resources.ApplyResources(Me.btnTileHorizontal, "btnTileHorizontal")
        Me.btnTileHorizontal.Name = "btnTileHorizontal"
        '
        'btnTileVertical
        '
        resources.ApplyResources(Me.btnTileVertical, "btnTileVertical")
        Me.btnTileVertical.Name = "btnTileVertical"
        '
        'btnCloseAll
        '
        resources.ApplyResources(Me.btnCloseAll, "btnCloseAll")
        Me.btnCloseAll.Name = "btnCloseAll"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnFullScreen
        '
        Me.btnFullScreen.CheckOnClick = True
        Me.btnFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnFullScreen, "btnFullScreen")
        Me.btnFullScreen.Name = "btnFullScreen"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'btnTranslateChinese
        '
        resources.ApplyResources(Me.btnTranslateChinese, "btnTranslateChinese")
        Me.btnTranslateChinese.Name = "btnTranslateChinese"
        '
        'TabBar1
        '
        Me.TabBar1.DisplayGroupIndex = 1
        resources.ApplyResources(Me.TabBar1, "TabBar1")
        Me.TabBar1.EnableSelection = True
        Me.TabBar1.HideToolBarOnEmpty = True
        Me.TabBar1.HoverBorderColor = System.Drawing.Color.Purple
        Me.TabBar1.Name = "TabBar1"
        Me.TabBar1.TabExtraSize = 3
        Me.TabBar1.UseDefaultClickEvent = False
        '
        'cmdgOpen
        '
        resources.ApplyResources(Me.cmdgOpen, "cmdgOpen")
        Me.cmdgOpen.Multiselect = True
        '
        'timerAutoRefresh
        '
        Me.timerAutoRefresh.Interval = 30000
        '
        'frm_Main
        '
        Me.AllowDrop = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabBar1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.menuMain)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.menuMain
        Me.Name = "frm_Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.menuMain.ResumeLayout(False)
        Me.menuMain.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenDatabaseWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFindTable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SwitchWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StoredProcedureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSPManage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaximizeRestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinimizeRestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnTileHorizontal As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnOpenDatabase As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNewQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnOpenSPManager As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFullScreen As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCloseAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabBar1 As CHKControl.TabBar
    Friend WithEvents btnTranslateChinese As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnTileVertical As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRestoreAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefreshAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDatabaseCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManagementStudioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents QueryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewQueryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenQueryMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenExecuteQueryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QueryHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsRefreshRegular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timerAutoRefresh As System.Windows.Forms.Timer
    Friend WithEvents FavoriteDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIndexManage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCreateTable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenColumnConsistency As System.Windows.Forms.ToolStripMenuItem
End Class
