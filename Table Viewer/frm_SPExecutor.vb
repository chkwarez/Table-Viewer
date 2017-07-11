Public Class frm_SPExecutor : Implements IFormClose
    Public ExecutableObject As Smart.IExecutable
    Public Shared LastParameters As New Smart.ParameterCollection
    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

    Private Sub frm_SPExecutor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub


    Public Sub LoadObject()
        Dim dtTable As DataTable
        Dim n As Integer
        Dim value As String
        Dim variableName As String

        If CType(ExecutableObject, Smart.SqlDatabaseObject) IsNot Nothing Then
            Dim obj As Smart.SqlDatabaseObject = CType(ExecutableObject, Smart.SqlDatabaseObject)
            lblDatabase.Text = obj.Database
            lblObject.Text = obj.FullName
        End If

        dtTable = ExecutableObject.GetExecutionVariables()
        If dtTable.Rows.Count = 0 Then 'No Variable is required for this executable object
            CreateQueryWindow(ExecutableObject.GetExecutionScript())
            CloseForm()
            Exit Sub
        End If

        dgContent.Rows.Clear()
        dgContent.Rows.Add(dtTable.Rows.Count)
        For n = 0 To dtTable.Rows.Count - 1
            variableName = dtTable.Rows(n)("Name").ToString()
            dgContent.Rows(n).Cells("dcName").Value = variableName
            dgContent.Rows(n).Cells("dcDataType").Value = dtTable.Rows(n)("DBType").ToString().ToLower()

            value = LastParameters.GetValue(variableName, Nothing) 'Get Last value for re-access
            If value Is Nothing Then
                dgContent.Rows(n).Cells("dcUseNullValue").Value = True
                dgContent.Rows(n).Cells("dcValue").Value = ""
            Else
                dgContent.Rows(n).Cells("dcUseNullValue").Value = False
                dgContent.Rows(n).Cells("dcValue").Value = value
            End If
        Next

        dgContent.Focus()
        dgContent.CurrentCell = dgContent.Rows(0).Cells(dgContent.ColumnCount - 1)

        Decorate()
    End Sub

    Public Sub Run()
        Dim n As Integer
        Dim list As New Smart.ParameterCollection()
        Dim value As String

        For n = 0 To dgContent.Rows.Count - 1
            With dgContent.Rows(n)
                If CBool(.Cells("dcUseNullValue").Value) = True Then
                    value = Nothing
                Else
                    value = .Cells("dcValue").FormattedValue.ToString()
                End If
                list.Add(.Cells("dcName").Value.ToString(), value)
            End With
        Next

        LastParameters.Merge(list) 'Save the last parameter collection
        CreateQueryWindow(ExecutableObject.GetExecutionScript(list))
        CloseForm()
    End Sub

    Public Sub CreateQueryWindow(ByVal query As String)
        Dim a As frm_SQL = ParentMainForm.CreateQueryWindow(lblObject.Text & " [EXE]")
        a.SetQuery(lblDatabase.Text, query)
        a.RunQuery()
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Run()
    End Sub

    Protected Sub Decorate()
        Dim n As Integer, dataType As String
        With dgContent
            For n = 0 To .Rows.Count - 1
                If .Rows(n).Cells("dcDataType").Value Is Nothing Then
                    dataType = ""
                Else
                    dataType = .Rows(n).Cells("dcDataType").Value.ToString()
                End If
                .Rows(n).Cells("dcDataType").Style.ForeColor = frm_Table.GetDataTypeColor(dataType) 'Fore Color
                .Rows(n).Cells("dcName").Style.ForeColor = frm_Table.GetDataTypeColor(dataType) 'Fore Color
            Next
        End With
    End Sub

    Private Sub dgContent_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgContent.CellEndEdit
        If e.RowIndex = -1 Then Exit Sub

        With dgContent.Rows(e.RowIndex)
            If .Cells("dcValue").Value Is Nothing OrElse .Cells("dcValue").Value.ToString() = "" Then Exit Sub
            .Cells("dcUseNullValue").Value = False
        End With
    End Sub

#Region "Interfaces"
    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub
#End Region

    Private Sub frm_SPExecutor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub dgContent_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgContent.KeyUp
        If e.KeyCode = Keys.F5 Then
            btnRun.Focus()
            Run()
        End If
    End Sub
End Class