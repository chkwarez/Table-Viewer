Imports CHK

Public Class FindReplaceDialog
    Public RefCtrl As ScintillaEditor
    Dim FindStart As Integer
    Dim FindEnd As Integer
    Dim LastFoundPosition As Integer
    Dim LastFoundText As String
    Dim LastFoundRange As Integer

#Region "Form Event"
    Private Sub frm_Find_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If RefCtrl.TextArea.AnchorPosition <> RefCtrl.TextArea.CurrentPosition Then
            ddLookIn.SelectedIndex = 1 'Selection
        Else
            ddLookIn.SelectedIndex = 0 'Whole Text
        End If

        ddLookIn_SelectedIndexChanged(Nothing, Nothing) 'Initialize Index Change
    End Sub

    Private Sub frm_Find_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
#End Region

#Region "Button Event"
    Private Sub btnFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindNext.Click
        If ddFind.Text = "" Then Exit Sub
        ddFind.AddHistory()
        Find(FindType.FindNext)
    End Sub

    Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplace.Click
        If ddFind.Text = "" Then Exit Sub
        ddFind.AddHistory()
        ddReplace.AddHistory()
        ReplaceAll(ddFind.Text, ddReplace.Text)
    End Sub

    Private Sub btnRestartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestartFind.Click
        If ddFind.Text = "" Then Exit Sub
        ddFind.AddHistory()
        Find(FindType.NewFind)
    End Sub

    Private Sub chkBookmark_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBookmark.CheckedChanged
        'If chkBookmark.Checked = True Then
        '    BookmarkAll()
        'Else
        '    UnbookmarkAll()
        'End If
    End Sub

    Private Sub btnSwapFields_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSwapFields.Click
        Dim tmp As String = ddReplace.Text
        ddReplace.Text = ddFind.Text
        ddFind.Text = tmp
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub
#End Region

#Region "TextBox Event"
    Private Sub ddFindReplace_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddReplace.TextChanged, ddFind.TextChanged
        btnFindNext.Enabled = CType(IIf(ddFind.Text = "", False, True), Boolean)
        btnRestartFind.Enabled = btnFindNext.Enabled
        btnReplace.Enabled = btnFindNext.Enabled
        timerStatus.Enabled = True
    End Sub

    Private Sub ddFind_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ddFind.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                btnFindNext_Click(Nothing, Nothing)
                ddFind.SelectionStart = ddFind.Text.Length
                e.Handled = True
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub ddReplace_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ddReplace.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                btnReplace_Click(Nothing, Nothing)
                ddReplace.SelectionStart = ddReplace.Text.Length
                e.Handled = True
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub ddFind_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddFind.Enter
        lblHelp.Text = "Enter: Find Next"
    End Sub

    Private Sub ddReplace_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddReplace.Enter
        lblHelp.Text = "Enter: Replace All (Case Sensitive)"
    End Sub

    Private Sub ddLookIn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddLookIn.SelectedIndexChanged
        timerStatus.Enabled = True
    End Sub

    Private Sub ddLookIn_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ddLookIn.KeyUp
        If e.KeyCode = Keys.Enter Then
            If ddReplace.Text = "" Then 'Do Find
                btnFindNext_Click(Nothing, Nothing)
            Else 'Do Replace
                btnReplace_Click(Nothing, Nothing)
            End If
        End If
    End Sub
#End Region

#Region "Timer Event"
    Private Sub timerStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerStatus.Tick
        If Not ddFind.Text = "" Then 'Show Match Count
            lblStatus.Text = "No. of matches: " & CountFindResult().ToString() & " (" & ddFind.Text & ")"
        End If
        timerStatus.Enabled = False
    End Sub
#End Region

#Region "Find"
    Private Function CountFindResult() As Integer
        Return StringExtension.CountStr(GetWorkableText(), ddFind.Text, Not chkMatchCase.Checked)
    End Function

    Public Function FindNext() As Integer
        Find(FindType.FindNext)
        Return 0
    End Function


    Private Sub Find(type As FindType)
        Dim flags As ScintillaNET.SearchFlags
        flags = ScintillaNET.SearchFlags.None
        If chkMatchCase.Checked Then flags = flags Or ScintillaNET.SearchFlags.MatchCase
        If chkMatchWholeWord.Checked Then flags = flags Or ScintillaNET.SearchFlags.WholeWord

        With RefCtrl.TextArea
            HideMessage()

            .TargetStart = If(type = FindType.NewFind, 0, .CurrentPosition)
            .TargetEnd = .TextLength
            .SearchFlags = flags
            Dim k = .SearchInTarget(ddFind.Text)

            If k = -1 And type = FindType.FindNext Then 'Not found, find again once more from the top
                ShowMessage("All text in the range is found.")
                .TargetStart = 0
                .TargetEnd = .TextLength
                .SearchFlags = flags
                k = .SearchInTarget(ddFind.Text)
            End If

            If k >= 0 Then 'Found 'Select the occurance
                RefCtrl.TextArea.SetSelection(RefCtrl.TextArea.TargetEnd, RefCtrl.TextArea.TargetStart)
                RefCtrl.TextArea.ScrollCaret()
            Else
                ShowMessage("No match is found in the text.")
            End If
        End With
    End Sub

    '    Private Sub Find(ByVal type As FindType)
    '        If ddFind.Text = "" Then Exit Sub

    '        Dim s1 As Integer, s2 As Integer, foundIndex As Integer
    '        Select Case type
    '            Case FindType.NewFind
    'RetartNewFind:
    '                GetWorkableRange(s1, s2)
    '                FindStart = s1
    '                FindEnd = s2
    '                LastFoundPosition = -1
    '                LastFoundText = ddFind.Text
    '                LastFoundRange = ddLookIn.SelectedIndex
    '                ddFind.AddHistory()

    '            Case FindType.FindNext
    '                If Not LastFoundText = ddFind.Text Or Not LastFoundRange = ddLookIn.SelectedIndex Then GoTo RetartNewFind 'The Find Criteria has changed, restart new Find
    '                If LastFoundPosition = -1 Then
    '                    s1 = FindStart
    '                    s2 = FindEnd
    '                Else
    '                    s1 = LastFoundPosition + 1
    '                    s2 = FindEnd
    '                End If
    '            Case Else
    '                Throw New ApplicationException("FindType not support")
    '        End Select
    '        If s1 < 0 Or s2 < 0 Or s2 < s1 Then Exit Sub

    '        Dim options As Integer
    '        If chkMatchCase.Checked Then options = options Or RichTextBoxFinds.MatchCase
    '        If chkMatchWholeWord.Checked Then options = options Or RichTextBoxFinds.WholeWord
    '        foundIndex = RefCtrl.Find(ddFind.Text, s1, s2, options)

    '        'If chkMatchCase.Checked = True Then
    '        '    'foundIndex = RefCtrl.Find(ddFind.Text, s1, s2, StringComparison.InvariantCulture)
    '        'Else
    '        '    'foundIndex = RefCtrl.Find(ddFind.Text, s1, s2, StringComparison.InvariantCultureIgnoreCase)
    '        'End If

    '        If foundIndex = -1 Then 'Nothing is found
    '            Dim m As Integer = CountFindResult()
    '            If m = 0 Then 'There is really no match in the text
    '                ShowMessage("No match is found in the text.")
    '            Else 'New match can be found from top
    '                ShowMessage("All text in the range is found.")
    '                LastFoundPosition = -1
    '            End If
    '        Else 'Result is found
    '            LastFoundPosition = foundIndex
    '            HideMessage()
    '        End If
    '    End Sub

    'Public Sub BookmarkAll()
    '    'WindowUpdate.Lock(RefCtrl.Handle)
    '    'Dim stat As New TextEditor.ViewImage(RefCtrl)

    '    'Dim s1 As Integer, s2 As Integer, foundStart As Integer
    '    'Dim line As Integer, n As Integer
    '    If ddFind.Text = "" Then Exit Sub
    '    ddFind.AddHistory()
    '    RefCtrl.HighlightText(ddFind.Text)
    '    'GetWorkableRange(s1, s2)
    '    'foundStart = s1
    '    'Do
    '    '    If chkMatchCase.Checked = True Then
    '    '        n = RefCtrl.Find(ddFind.Text, foundStart, s2, RichTextBoxFinds.MatchCase)
    '    '    Else
    '    '        n = RefCtrl.Find(ddFind.Text, foundStart, s2, RichTextBoxFinds.None)
    '    '    End If
    '    '    If n = -1 Then Exit Do

    '    '    foundStart = n + 1
    '    '    line = RefCtrl.GetLineFromCharIndex(n)
    '    '    RefCtrl.HightlightLine(line, Color.Yellow)
    '    'Loop

    '    'stat.Apply()
    'End Sub

    'Public Sub UnbookmarkAll()
    '    RefCtrl.ClearAllHighlight()
    'End Sub
#End Region

#Region "Replace"
    Public Sub ReplaceAll(ByVal findText As String, ByVal replaceText As String)
        Dim tmp As String
        ShowMessage("Replacing Text...")
        tmp = GetWorkableText()
        tmp = tmp.Replace(findText, replaceText)
        SetWorkableText(tmp)
        timerStatus.Enabled = True 'Update Search Information
        HideMessage()
        timerStatus.Enabled = True
    End Sub
#End Region

#Region "Workable Range"
    'Private Sub GetWorkableRange(ByRef startIndex As Integer, ByRef endIndex As Integer)
    '    Select Case ddLookIn.SelectedIndex
    '        Case 0 'Whole Text
    '            startIndex = 0
    '            endIndex = RefCtrl.TextLength - 1
    '        Case 1 'Selection
    '            startIndex = RefCtrl.SelectionStart
    '            endIndex = RefCtrl.SelectionStart + RefCtrl.SelectionLength - 1
    '    End Select
    'End Sub

    Private Function GetWorkableText() As String
        Select Case ddLookIn.SelectedIndex
            Case 0 'Whole Text
                Return RefCtrl.TextArea.Text
            Case 1 'Selection
                Return RefCtrl.TextArea.SelectedText
            Case Else
                Return ""
        End Select
    End Function

    Private Sub SetWorkableText(text As String)
        Select Case ddLookIn.SelectedIndex
            Case 0 'Whole Text
                RefCtrl.TextArea.Text = text
            Case 1 'Selection
                RefCtrl.TextArea.ReplaceSelection(text)
            Case Else
                'Do Nothing
        End Select
    End Sub
#End Region

#Region "Enum"
    Public Enum FindReplaceAction
        Find
        FindAll
        ReplaceAll
    End Enum

    Private Enum FindType
        NewFind
        FindNext
        BookmarkAll
    End Enum
#End Region

#Region "Miscellaneous Function"
    'Private Sub SetDialogPosition()
    '    Dim p As System.Drawing.Point
    '    p = RefCtrl.GetPositionFromCharIndex(LastFoundPosition)
    '    'Me.Left = p.X + RefCtrl.Location.X + 100
    '    Me.Top = p.Y + RefCtrl.Location.Y
    'End Sub
    Public Sub SetFindCondition(ByVal findText As String, ByVal offset As Integer)
        If Not ddFind.Text = findText Then 'New find text, restart find
            ddFind.Text = findText
            LastFoundPosition = offset
        End If
    End Sub

    Private Sub ShowMessage(ByVal msg As String)
        lblMessage.Visible = True
        lblMessage.Text = msg
        Application.DoEvents()
    End Sub

    Private Sub HideMessage()
        lblMessage.Visible = False
    End Sub
#End Region

End Class
