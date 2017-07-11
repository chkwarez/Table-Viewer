Public Class frm_TableColumnEditor
    Public Table As Smart.SqlTable

    Private Sub btnAddColumn_Click(sender As System.Object, e As System.EventArgs) Handles btnAddColumn.Click
        Try
            Dim initValue As String
            If chkApplyInitValue.Checked Then
                initValue = txtInitValue.Text
            Else
                initValue = Nothing
            End If

            Table.AddColumn(txtColumnName.Text, txtDataType.Text, chkAllowNull.Checked, initValue)
            Table.RefreshColumnCache()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chkApplyInitValue_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkApplyInitValue.CheckedChanged
        txtInitValue.ReadOnly = Not chkApplyInitValue.Checked
        If txtInitValue.ReadOnly = False Then txtInitValue.Focus()
    End Sub

    Private Sub lnkNvarchar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNvarchar.LinkClicked
        txtDataType.Text = "nvarchar(50)"
    End Sub

    Private Sub lnkDatetime_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDatetime.LinkClicked
        txtDataType.Text = "datetime"
    End Sub

    Private Sub lnkDecimal_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDecimal.LinkClicked
        txtDataType.Text = "decimal(19,6))"
    End Sub
End Class