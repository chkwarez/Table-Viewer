Public Class frm_DatabaseConsistency : Implements IFormClose
    Dim Map As Smart.Consistency.Map

    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

#Region "Form Events"
    Private Sub frm_Check_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnAnalyze_Click(Nothing, Nothing)
    End Sub

    Private Sub frm_Check_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub
#End Region

#Region "Button Event"
    Private Sub btnAnalyze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyze.Click
        Dim adapter As SmartDataAdapter = ParentMainForm.DatabaseWindow.CreateDataAdapter() 'Acquire Adapter
        Map = New Smart.Consistency.Map(New Smart.SqlDatabase(adapter, ParentMainForm.DatabaseWindow.SelectedDatabase))
        lblResult.Text = "Total number of columns in " & ParentMainForm.DatabaseWindow.Server.Database.Name & " database: " & Map.Columns.Count
    End Sub

    Private Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click
        Dim result = Map.SearchColumn(txtColumnName.Text)
        lvwColumn.Items.Clear()

        For m As Integer = 0 To result.Count - 1
            With result(m)
                Dim i = lvwColumn.AddItem(.ColumnName, .ColumnName, .FrequentDataType.DataType, .FrequentDataType.Frequency & "/" & .TotalFrequency & " (" & .FrequentDataType.Percent.ToString("0.#%") & ")")
                i.UseItemStyleForSubItems = True
                If .FrequentDataType.Percent < 1 Then i.BackColor = Color.LightPink
            End With
        Next

        lblResult2.Text = "Number of result: " & lvwColumn.Items.Count
        If lvwColumn.Items.Count > 0 Then lvwColumn.Items(0).Selected = True
        lvwColumn_SelectedIndexChanged(lvwColumn, Nothing)
    End Sub

    Private Sub btnListDiscrepancy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListDiscrepancy.Click
        Dim result = Map.SearchDiscrepantColumn()
        lvwColumn.Items.Clear()

        For m As Integer = 0 To result.Count - 1
            With result(m)
                Dim i = lvwColumn.AddItem(.ColumnName, .ColumnName, .FrequentDataType.DataType, .FrequentDataType.Frequency & "/" & .TotalFrequency & " (" & .FrequentDataType.Percent.ToString("0.#%") & ")")
                i.UseItemStyleForSubItems = True
                If .FrequentDataType.Percent < 1 Then i.BackColor = Color.LightPink
            End With
        Next

        lblResult2.Text = "Number of result: " & lvwColumn.Items.Count
        If lvwColumn.Items.Count > 0 Then lvwColumn.Items(0).Selected = True
        lvwColumn_SelectedIndexChanged(lvwColumn, Nothing)
    End Sub

    Private Sub btnListByDataType_Click(sender As System.Object, e As System.EventArgs) Handles btnListByDataType.Click
        Dim result = Map.SearchByDataType(txtDataType.Text)
        lvwColumn.Items.Clear()

        For m As Integer = 0 To result.Count - 1
            With result(m)
                Dim i = lvwColumn.AddItem(.ColumnName, .ColumnName, .FrequentDataType.DataType, .FrequentDataType.Frequency & "/" & .TotalFrequency & " (" & .FrequentDataType.Percent.ToString("0.#%") & ")")
                i.UseItemStyleForSubItems = True
                If .FrequentDataType.Percent < 1 Then i.BackColor = Color.LightPink
            End With
        Next

        lblResult2.Text = "Number of result: " & lvwColumn.Items.Count
        If lvwColumn.Items.Count > 0 Then lvwColumn.Items(0).Selected = True
        lvwColumn_SelectedIndexChanged(lvwColumn, Nothing)
    End Sub
#End Region

#Region "Other Control Events"
    Private Sub txtColumnName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColumnName.TextChanged
        btnList_Click(Nothing, Nothing)
    End Sub

    Private Sub txtDataType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataType.TextChanged
        btnListByDataType_Click(Nothing, Nothing)
    End Sub

    Private Sub lvwColumn_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvwColumn.SelectedIndexChanged
        If lvwColumn.SelectedIndices.Count = 0 Then Exit Sub
        ListReferenceObjects(CStr(lvwColumn.SelectedItems(0).Tag))
    End Sub

    Private Sub lvwReference_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lvwReference.DoubleClick
        If lvwReference.SelectedItems.Count = 0 Then Exit Sub
        If TypeOf lvwReference.SelectedItems(0).Tag Is Integer Then
            Try
                Dim objectId As Integer = CInt(lvwReference.SelectedItems(0).Tag)
                ParentMainForm.DatabaseWindow.OpenTableFormById(objectId, "")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtColumnName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtColumnName.KeyDown
        Dim txt = CType(sender, TextBox)
        If e.KeyCode = Keys.Up Then
            e.Handled = True
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
        ElseIf e.KeyCode = Keys.Enter Then
            txt.SelectAll()
        End If
    End Sub
#End Region

#Region "Consistency Logic"
    Private Sub ListReferenceObjects(columnName As String)
        Dim info = Map.GetColumnInfo(columnName)
        lvwReference.Items.Clear()

        For m As Integer = 0 To info.DataTypes.Count - 1
            With info.DataTypes(m) 'Show Data Type
                For n As Integer = 0 To .References.Count - 1 'Show Reference Objects
                    Dim i As ListViewItem = lvwReference.AddItem(.References(n).ObjectId, .DataType, .References(n).ObjectName)
                    If Not .IsFrequent Then i.BackColor = Color.LightBlue
                Next
            End With
        Next
    End Sub
#End Region

#Region "Interfaces"
    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub
#End Region



End Class