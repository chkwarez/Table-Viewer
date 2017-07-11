Public Class frm_ConnectionWizard : Implements IFormClose
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

    Public IsDialog As Boolean = False
    Public Delegate Sub ConnectionStringCallbackDelegate(connStr As String)
    Public CallbackDelegate As ConnectionStringCallbackDelegate

#Region "Form Events"
    Private Sub frm_ConnectionWizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ParentMainForm.RecordActiveWindow(Me)

        Dim mgr As New ConnectionManager
        mgr.LoadOption()
        dgFavorite.AutoGenerateColumns = False
        dgFavorite.DataSource = mgr.FavioriteTable
        dgFavorite.Refresh()
        dgFavorite.AutoResizeRows()
    End Sub
#End Region

#Region "Button Events"
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim conn = BuildConnectionString()

        If IsDialog = False Then 'Open from database window
            ParentMainForm.DatabaseWindow.ddConnectionString.Text = conn.ToString()
            ParentMainForm.DatabaseWindow.Connect(txtDatabase.Text)
        Else
            If CallbackDelegate IsNot Nothing Then CallbackDelegate(conn.ToString())
        End If

        Me.Close()
    End Sub

    Private Sub btnSaveSelected_Click(sender As Object, e As EventArgs) Handles btnSaveSelected.Click
        If dgFavorite.SelectedCells.Count = 0 Then Exit Sub

        dgFavorite.CurrentCell = dgFavorite.SelectedCells(0)
        Dim k As Integer = dgFavorite.CurrentCell.RowIndex
        dgFavorite.SetCellValue(k, dgcConnStr.Index, BuildConnectionString().ToString())
        dgFavorite.SetCellValue(k, dgcDefaultDatabase.Index, txtDatabase.Text)
        dgFavorite.NotifyCurrentCellDirty(True) 'Tell the grid to add a new row
        dgFavorite.EndEdit() 'Tell the grid to finish edit on this cell
        dgFavorite.NotifyCurrentCellDirty(False) 'Tell the grid that it can accept new dirty cell
    End Sub
#End Region

#Region "Other Control Events"
    Private Sub chkTrustedConnection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrustedConnection.CheckedChanged
        txtUserID.ReadOnly = chkTrustedConnection.Checked
        txtPassword.ReadOnly = chkTrustedConnection.Checked
        txtConnStr.Text = BuildConnectionString().ToString()
    End Sub
#End Region

    Public Sub LoadFromConnectionString(ByVal connString As String, db As String)
        txtConnStr.Text = connString
        Dim conn As Smart.ConnectionString = Smart.ConnectionString.Parse(connString)
        txtServerName.Text = conn.Server
        txtUserID.Text = conn.UserId
        txtPassword.Text = conn.Password
        chkTrustedConnection.Checked = conn.IsTrust
        chkTrustedConnection_CheckedChanged(chkTrustedConnection, Nothing)
        txtDatabase.Text = db
    End Sub

#Region "Interfaces"
    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub
#End Region

    Private Function BuildConnectionString() As Smart.ConnectionString
        Dim conn As New Smart.ConnectionString()
        conn.Server = txtServerName.Text
        conn.UserId = txtUserID.Text
        conn.Password = txtPassword.Text
        conn.IsTrust = chkTrustedConnection.Checked
        Return conn
    End Function


    Private Sub dgFavorite_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFavorite.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim connStr As String = dgFavorite.GetCellString(e.RowIndex, dgcConnStr.Index)
        Dim defaultDB As String = dgFavorite.GetCellString(e.RowIndex, dgcDefaultDatabase.Index)

        If e.ColumnIndex = dgcSelect.Index Then 'Select Button
            If IsDialog = False Then 'Open from database window
                ParentMainForm.DatabaseWindow.ddConnectionString.Text = dgFavorite.GetCellString(e.RowIndex, dgcConnStr.Index)
                ParentMainForm.DatabaseWindow.Connect(defaultDB)
            Else
                If CallbackDelegate IsNot Nothing Then CallbackDelegate(dgFavorite.GetCellString(e.RowIndex, dgcConnStr.Index))
            End If
            Me.Close()
            End If
    End Sub


    Private Sub dgFavorite_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFavorite.CellClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = dgcConnStr.Index Or e.ColumnIndex = dgcDefaultDatabase.Index Then 'Select Button
            LoadFromConnectionString(dgFavorite.GetCellString(e.RowIndex, dgcConnStr.Index), dgFavorite.GetCellString(e.RowIndex, dgcDefaultDatabase.Index))
        End If
    End Sub

    Private Sub txtServerName_TextChanged(sender As Object, e As EventArgs) Handles txtServerName.TextChanged, txtDatabase.TextChanged, txtUserID.TextChanged, txtPassword.TextChanged
        txtConnStr.Text = BuildConnectionString().ToString()
    End Sub

    Private Sub btnAddConn_Click(sender As Object, e As EventArgs) Handles btnAddConn.Click
        If txtConnStr.Text = "" Then Exit Sub

        Dim k As Integer = dgFavorite.Rows.Count - 1
        Dim connName As String = txtDatabase.Text.Replace("_", " ")
        If connName = "" Then connName = "New Connection"

        dgFavorite.CurrentCell = dgFavorite.Rows(k).Cells(0)
        dgFavorite.SetCellValue(k, dgcConnStr.Index, BuildConnectionString().ToString())
        dgFavorite.SetCellValue(k, dgcDefaultDatabase.Index, txtDatabase.Text)
        dgFavorite.SetCellValue(k, dgcName.Index, connName) 'New Connection Name

        dgFavorite.NotifyCurrentCellDirty(True) 'Tell the grid to add a new row
        dgFavorite.EndEdit() 'Tell the grid to finish edit on this cell
        dgFavorite.NotifyCurrentCellDirty(False) 'Tell the grid that it can accept new dirty cell
    End Sub

    Private Sub frm_ConnectionWizard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If IsDialog = False Then 'Auto Save
            Dim mgr As New ConnectionManager
            mgr.FavioriteTable = CType(dgFavorite.DataSource, MiscDataSet.FavoriteConnectionDataTable)
            mgr.SaveOption()
        End If
    End Sub

    Public Sub SetDialogMode(delg As ConnectionStringCallbackDelegate)
        IsDialog = True
        CallbackDelegate = delg
        btnAddConn.Enabled = False
        btnSaveSelected.Enabled = False
    End Sub
End Class
