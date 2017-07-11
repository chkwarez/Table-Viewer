Imports ScintillaNET

Public Class ScintillaEditor
    Public TextArea As New ScintillaNET.Scintilla
    Public FindDialog As FindReplaceDialog

#Region "Form Events"
    Private Sub ScintillaEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' CREATE CONTROL
        'TextArea = New ScintillaNET.Scintilla()
        Me.Controls.Add(TextArea)

        ' BASIC CONFIG
        TextArea.Dock = System.Windows.Forms.DockStyle.Fill
        'AddHandler TextArea.TextChanged, AddressOf Me.TextArea_OnTextChanged

        ' INITIAL VIEW CONFIG
        TextArea.WrapMode = WrapMode.None
        TextArea.IndentationGuides = IndentView.LookBoth

        ' STYLING
        InitColors()
        InitSyntaxColoring()

        ' NUMBER MARGIN
        InitNumberMargin()

        ' BOOKMARK MARGIN
        'InitBookmarkMargin();

        ' CODE FOLDING MARGIN
        'InitCodeFolding();

        ' DRAG DROP
        'InitDragDropFile()

        ' INIT HOTKEYS
        InitHotkeys()

        ' Create Find / Replace Dialog
        FindDialog = New FindReplaceDialog()
        FindDialog.RefCtrl = Me
        FindDialog.TopMost = True

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If CInt(keyData) = Keys.Control + Keys.F Then
            ShowFindDialog()
            Return False
        ElseIf CInt(keyData) = Keys.Control + Keys.K Then
            CommentLines()
            Return False
        ElseIf CInt(keyData) = Keys.Control + Keys.U Then
            UncommentLines()
            Return False
        ElseIf keyData = Keys.F1 Or keyData = Keys.F2 Or keyData = Keys.F3 Or keyData = Keys.F4 Or keyData = Keys.F5 Or keyData = Keys.F6 Or keyData = Keys.F7 Or keyData = Keys.F8 Or keyData = Keys.F9 Or keyData = Keys.F10 Or keyData = Keys.F11 Or keyData = Keys.F12 Then
            OnKeyUp(New KeyEventArgs(keyData))
            Return False
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
    End Function

#End Region

#Region "Public Properties"
    Public Overrides Property Text As String
        Get
            Return TextArea.Text
        End Get
        Set(value As String)
            TextArea.Text = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property SelectedText As String
        Get
            If DesignMode Then Return ""
            Return TextArea.SelectedText
        End Get
        Set(value As String)
            If DesignMode Then Exit Property
            TextArea.ReplaceSelection(value)
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property SelectionStart As Integer
        Get
            If DesignMode Then Return 0
            Return TextArea.SelectionStart
        End Get
        Set(value As Integer)
            If DesignMode Then Exit Property
            TextArea.SelectionStart = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property SelectionEnd As Integer
        Get
            If DesignMode Then Return 0
            Return TextArea.SelectionEnd
        End Get
        Set(value As Integer)
            If DesignMode Then Exit Property
            TextArea.SelectionEnd = value
        End Set
    End Property
#End Region

#Region "Public Functions"
    ''' <summary>
    ''' Scroll to line, line no. start from 0.
    ''' </summary>
    Public Sub ScrollToLine(lineNo As Integer)
        If lineNo >= Me.TextArea.Lines.Count Then Exit Sub
        Dim l = Me.TextArea.Lines(lineNo)
        'Me.TextArea.ScrollRange(l.Position, l.Position)
        Me.TextArea.SelectionStart = l.Position
        Me.TextArea.SelectionEnd = l.Position
        Me.TextArea.ScrollCaret()
    End Sub

    Public Function CurrentLineText() As String
        Return Me.TextArea.Lines(Me.TextArea.CurrentLine).Text
    End Function
#End Region

#Region "Initialization"
    Private Sub InitColors()
        TextArea.SetSelectionBackColor(True, IntToColor(&H114D9C))
        TextArea.CaretForeColor = Color.White
    End Sub

    Private Sub InitHotkeys()

        ' register the hotkeys with the form
        'HotKeyManager.AddHotKey(this, OpenSearch, Keys.F, true);
        'HotKeyManager.AddHotKey(Me, AddressOf OpenFindDialog, Keys.F, True, False, True)
        'HotKeyManager.AddHotKey(Me, AddressOf OpenReplaceDialog, Keys.R, True)
        'HotKeyManager.AddHotKey(Me, AddressOf OpenReplaceDialog, Keys.H, True)
        'HotKeyManager.AddHotKey(Me, AddressOf Uppercase, Keys.U, True)
        'HotKeyManager.AddHotKey(Me, AddressOf Lowercase, Keys.L, True)
        'HotKeyManager.AddHotKey(Me, AddressOf ZoomIn, Keys.Oemplus, True)
        'HotKeyManager.AddHotKey(Me, AddressOf ZoomOut, Keys.OemMinus, True)
        'HotKeyManager.AddHotKey(Me, AddressOf ZoomDefault, Keys.D0, True)
        'HotKeyManager.AddHotKey(this, CloseSearch, Keys.Escape);

        ' remove conflicting hotkeys from scintilla

        TextArea.ClearCmdKey(Keys.Control Or Keys.D)
        TextArea.ClearCmdKey(Keys.Control Or Keys.E)
        TextArea.ClearCmdKey(Keys.Control Or Keys.F)
        TextArea.ClearCmdKey(Keys.Control Or Keys.F)
        TextArea.ClearCmdKey(Keys.Control Or Keys.K)
        TextArea.ClearCmdKey(Keys.Control Or Keys.R)
        TextArea.ClearCmdKey(Keys.Control Or Keys.H)
        TextArea.ClearCmdKey(Keys.Control Or Keys.L)
        TextArea.ClearCmdKey(Keys.Control Or Keys.Q)
        TextArea.ClearCmdKey(Keys.Control Or Keys.U)
        TextArea.ClearCmdKey(Keys.Control Or Keys.S)
    End Sub

    Private Sub InitSyntaxColoring()

        ' Configure the default style
        TextArea.StyleResetDefault()
        TextArea.Styles(Style.[Default]).Font = "Consolas"
        TextArea.Styles(Style.[Default]).Size = 10
        TextArea.Styles(Style.[Default]).BackColor = IntToColor(&H212121)
        TextArea.Styles(Style.[Default]).ForeColor = IntToColor(&HFFFFFF)
        TextArea.StyleClearAll()

        ' Configure the CPP (C#) lexer styles
        TextArea.Styles(Style.Sql.Identifier).ForeColor = IntToColor(&HD0DAE2)
        TextArea.Styles(Style.Sql.Comment).ForeColor = IntToColor(&HBD758B)
        TextArea.Styles(Style.Sql.CommentLine).ForeColor = IntToColor(&H40BF57)
        TextArea.Styles(Style.Sql.CommentDoc).ForeColor = IntToColor(&H2FAE35)
        TextArea.Styles(Style.Sql.Number).ForeColor = IntToColor(&HFFFF00)
        TextArea.Styles(Style.Sql.[String]).ForeColor = IntToColor(&HFFFF00)
        TextArea.Styles(Style.Sql.Character).ForeColor = IntToColor(&HE95454)
        TextArea.Styles(Style.Sql.[Operator]).ForeColor = IntToColor(&HE0E0E0)
        TextArea.Styles(Style.Sql.CommentLineDoc).ForeColor = IntToColor(&H77A7DB)
        TextArea.Styles(Style.Sql.Word).ForeColor = IntToColor(&H48A8EE)
        TextArea.Styles(Style.Sql.Word2).ForeColor = IntToColor(&HF98906)
        TextArea.Styles(Style.Sql.CommentDocKeyword).ForeColor = IntToColor(&HB3D991)
        TextArea.Styles(Style.Sql.CommentDocKeywordError).ForeColor = IntToColor(&HFF0000)

        TextArea.Lexer = Lexer.Sql

        TextArea.SetKeywords(0, "select from where update delete print order over by set declare procedure function inner left outer join desc then asc is use as max min avg group distinct on in exec insert union into values open top fetch next while close decryption encryption for deallocate symmetric key certificate constraint with primary view identity between truncate off transaction transfer execute revert exists commit rollback all option maxrecursion column create alter drop add if begin end case when else try catch returns return")
        TextArea.SetKeywords(1, "sum isnull cast convert substring dateadd datediff datename datepart day getdate month year ascii char charindex difference left len lower ltrim nchar patindex replace quotename replicate reverse right rtrim soundex space str stuff unicode upper raiserror identity_insert object_id is_member error_number error_severity error_state error_procedure error_line error_message output row_number parse try_parse try_convert datefromparts datetimefromparts datetime2fromparts smalldatetimefromparts datetimeoffsetfromparts timefromparts eomonth choose iif concat format bigint binary bit char cursor datetime decimal float image int money nchar ntext numeric nvarchar real smalldatetime smallint smallmoney sql_variant table text timestamp tinyint uniqueidentifier varbinary varchar null")
    End Sub

#End Region

#Region "Numbers, Bookmarks, Code Folding"

    ''' <summary>
    ''' the background color of the text area
    ''' </summary>
    Private Const BACK_COLOR As Integer = &H2A211C

    ''' <summary>
    ''' default text color of the text area
    ''' </summary>
    Private Const FORE_COLOR As Integer = &HB7B7B7

    ''' <summary>
    ''' change this to whatever margin you want the line numbers to show in
    ''' </summary>
    Private Const NUMBER_MARGIN As Integer = 1

    ''' <summary>
    ''' change this to whatever margin you want the bookmarks/breakpoints to show in
    ''' </summary>
    Private Const BOOKMARK_MARGIN As Integer = 2
    Private Const BOOKMARK_MARKER As Integer = 2

    ''' <summary>
    ''' change this to whatever margin you want the code folding tree (+/-) to show in
    ''' </summary>
    Private Const FOLDING_MARGIN As Integer = 3

    ''' <summary>
    ''' set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
    ''' </summary>
    Private Const CODEFOLDING_CIRCULAR As Boolean = True

    Private Sub InitNumberMargin()

        TextArea.Styles(Style.LineNumber).BackColor = IntToColor(BACK_COLOR)
        TextArea.Styles(Style.LineNumber).ForeColor = IntToColor(FORE_COLOR)
        TextArea.Styles(Style.IndentGuide).ForeColor = IntToColor(FORE_COLOR)
        TextArea.Styles(Style.IndentGuide).BackColor = IntToColor(BACK_COLOR)

        Dim nums = TextArea.Margins(NUMBER_MARGIN)
        nums.Width = 30
        nums.Type = MarginType.Number
        nums.Sensitive = True
        nums.Mask = 0

        AddHandler TextArea.MarginClick, AddressOf TextArea_MarginClick
    End Sub

    Private Sub InitBookmarkMargin()

        'TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

        Dim margin = TextArea.Margins(BOOKMARK_MARGIN)
        margin.Width = 20
        margin.Sensitive = True
        margin.Type = MarginType.Symbol
        margin.Mask = (1 << BOOKMARK_MARKER)
        'margin.Cursor = MarginCursor.Arrow;

        Dim marker = TextArea.Markers(BOOKMARK_MARKER)
        marker.Symbol = MarkerSymbol.Circle
        marker.SetBackColor(IntToColor(&HFF003B))
        marker.SetForeColor(IntToColor(&H0))
        marker.SetAlpha(100)

    End Sub

    Private Sub InitCodeFolding()

        TextArea.SetFoldMarginColor(True, IntToColor(BACK_COLOR))
        TextArea.SetFoldMarginHighlightColor(True, IntToColor(BACK_COLOR))

        ' Enable code folding
        TextArea.SetProperty("fold", "1")
        TextArea.SetProperty("fold.compact", "1")

        ' Configure a margin to display folding symbols
        TextArea.Margins(FOLDING_MARGIN).Type = MarginType.Symbol
        TextArea.Margins(FOLDING_MARGIN).Mask = Marker.MaskFolders
        TextArea.Margins(FOLDING_MARGIN).Sensitive = True
        TextArea.Margins(FOLDING_MARGIN).Width = 20

        ' Set colors for all folding markers
        For i As Integer = 25 To 31
            TextArea.Markers(i).SetForeColor(IntToColor(BACK_COLOR))
            ' styles for [+] and [-]
            ' styles for [+] and [-]
            TextArea.Markers(i).SetBackColor(IntToColor(FORE_COLOR))
        Next

        ' Configure folding markers with respective symbols
        TextArea.Markers(Marker.Folder).Symbol = If(CODEFOLDING_CIRCULAR, MarkerSymbol.CirclePlus, MarkerSymbol.BoxPlus)
        TextArea.Markers(Marker.FolderOpen).Symbol = If(CODEFOLDING_CIRCULAR, MarkerSymbol.CircleMinus, MarkerSymbol.BoxMinus)
        TextArea.Markers(Marker.FolderEnd).Symbol = If(CODEFOLDING_CIRCULAR, MarkerSymbol.CirclePlusConnected, MarkerSymbol.BoxPlusConnected)
        TextArea.Markers(Marker.FolderMidTail).Symbol = MarkerSymbol.TCorner
        TextArea.Markers(Marker.FolderOpenMid).Symbol = If(CODEFOLDING_CIRCULAR, MarkerSymbol.CircleMinusConnected, MarkerSymbol.BoxMinusConnected)
        TextArea.Markers(Marker.FolderSub).Symbol = MarkerSymbol.VLine
        TextArea.Markers(Marker.FolderTail).Symbol = MarkerSymbol.LCorner

        ' Enable automatic folding
        TextArea.AutomaticFold = (AutomaticFold.Show Or AutomaticFold.Click Or AutomaticFold.Change)

    End Sub

    Private Sub TextArea_MarginClick(sender As Object, e As MarginClickEventArgs)
        If e.Margin = BOOKMARK_MARGIN Then
            ' Do we have a marker for this line?
            Const mask As UInteger = (1 << BOOKMARK_MARKER)
            Dim line = TextArea.Lines(TextArea.LineFromPosition(e.Position))
            If (line.MarkerGet() And mask) > 0 Then
                ' Remove existing bookmark
                line.MarkerDelete(BOOKMARK_MARKER)
            Else
                ' Add bookmark
                line.MarkerAdd(BOOKMARK_MARKER)
            End If
        End If
    End Sub

#End Region

#Region "Drag & Drop File"

    'Public Sub InitDragDropFile()

    '    TextArea.AllowDrop = True
    '    TextArea.DragEnter += Sub(sender As Object, e As DragEventArgs) If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '            e.Effect = DragDropEffects.Copy
    '    Else
    '    e.Effect = DragDropEffects.None
    '    End If

    '    ' get file drop
    '    TextArea.DragDrop += Sub(sender As Object, e As DragEventArgs) If e.Data.GetDataPresent(DataFormats.FileDrop) Then

    '            Dim a As Array = DirectCast(e.Data.GetData(DataFormats.FileDrop), Array)
    '    If a IsNot Nothing Then

    '        Dim path As String = a.GetValue(0).ToString()


    '        LoadDataFromFile(path)
    '    End If
    '    End If

    'End Sub

    Public Sub LoadFile(path As String)
        If System.IO.File.Exists(path) Then
            Me.Text = System.IO.Path.GetFileName(path)
            TextArea.Text = System.IO.File.ReadAllText(path)
        End If
    End Sub

#End Region

#Region "Main Menu Commands"

    'private void openToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    if (openFileDialog.ShowDialog() == DialogResult.OK)
    '    {
    '        LoadDataFromFile(openFileDialog.FileName);
    '    }
    '}

    'private void findToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    OpenSearch();
    '}

    'private void findDialogToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    OpenFindDialog();
    '}

    'private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    OpenReplaceDialog();
    '}

    'private void cutToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    TextArea.Cut();
    '}

    'private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    TextArea.Copy();
    '}

    'private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    TextArea.Paste();
    '}

    'private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    TextArea.SelectAll();
    '}

    'private void selectLineToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    Line line = TextArea.Lines[TextArea.CurrentLine];
    '    TextArea.SetSelection(line.Position + line.Length, line.Position);
    '}

    'private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    TextArea.SetEmptySelection(0);
    '}

    'private void indentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    Indent();
    '}

    'private void outdentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    Outdent();
    '}

    'private void uppercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    Uppercase();
    '}

    'private void lowercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    Lowercase();
    '}

    'private void wordWrapToolStripMenuItem1_Click(object sender, EventArgs e)
    '{

    '    // toggle word wrap
    '    wordWrapItem.Checked = !wordWrapItem.Checked;
    '    TextArea.WrapMode = wordWrapItem.Checked ? WrapMode.Word : WrapMode.None;
    '}

    'private void indentGuidesToolStripMenuItem_Click(object sender, EventArgs e)
    '{

    '    // toggle indent guides
    '    indentGuidesItem.Checked = !indentGuidesItem.Checked;
    '    TextArea.IndentationGuides = indentGuidesItem.Checked ? IndentView.LookBoth : IndentView.None;
    '}

    'private void hiddenCharactersToolStripMenuItem_Click(object sender, EventArgs e)
    '{

    '    // toggle view whitespace
    '    hiddenCharactersItem.Checked = !hiddenCharactersItem.Checked;
    '    TextArea.ViewWhitespace = hiddenCharactersItem.Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible;
    '}

    'private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    ZoomIn();
    '}

    'private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    ZoomOut();
    '}

    'private void zoom100ToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    ZoomDefault();
    '}

    'private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    TextArea.FoldAll(FoldAction.Contract);
    '}

    'private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
    '{
    '    TextArea.FoldAll(FoldAction.Expand);
    '}


#End Region

#Region "Indent / Outdent"

    'Private Sub Indent()
    '    ' we use this hack to send "Shift+Tab" to scintilla, since there is no known API to indent,
    '    ' although the indentation function exists. Pressing TAB with the editor focused confirms this.
    '    GenerateKeystrokes("{TAB}")
    'End Sub

    'Private Sub Outdent()
    '    ' we use this hack to send "Shift+Tab" to scintilla, since there is no known API to outdent,
    '    ' although the indentation function exists. Pressing Shift+Tab with the editor focused confirms this.
    '    GenerateKeystrokes("+{TAB}")
    'End Sub

    'Private Sub GenerateKeystrokes(keys As String)
    '    HotKeyManager.Enable = False
    '    TextArea.Focus()
    '    SendKeys.Send(keys)
    '    HotKeyManager.Enable = True
    'End Sub

#End Region

#Region "Comment"
    Public Const CommentSet As String = "--"

    Public Sub CommentLines()
        CommentLines(Me.TextArea.LineFromPosition(Me.SelectionStart), Me.TextArea.LineFromPosition(Me.SelectionEnd))
    End Sub

    Public Sub CommentLines(lineFrom As Integer, lineTo As Integer)
        If lineFrom > lineTo Or lineFrom >= Me.TextArea.Lines.Count Or lineTo >= Me.TextArea.Lines.Count Then Exit Sub
        Dim operatedLength As Integer = 0

        'Action
        For n As Integer = lineFrom To lineTo
            Me.TextArea.TargetStart = Me.TextArea.Lines(n).Position
            Me.TextArea.TargetEnd = Me.TextArea.Lines(n).EndPosition

            Dim tabCount As Integer = GetPaddedTabCount(Me.TextArea.Lines(n).Text)
            Dim tmp As String = StrDup(tabCount, vbTab) & CommentSet & Me.TextArea.Lines(n).Text.TrimStart() 'New line with comment
            Me.TextArea.ReplaceTarget(tmp)
            operatedLength += CommentSet.Length
        Next

        'If lineFrom <> lineTo Then 'offset the selection
        '    Me.TextArea.SetSelection(Me.TextArea.SelectionStart, Me.TextArea.SelectionEnd + operatedLength)
        'End If
    End Sub

    Public Sub UncommentLines()
        UncommentLines(Me.TextArea.LineFromPosition(Me.SelectionStart), Me.TextArea.LineFromPosition(Me.SelectionEnd))
    End Sub

    Public Sub UncommentLines(lineFrom As Integer, lineTo As Integer)
        If lineFrom > lineTo Or lineFrom >= Me.TextArea.Lines.Count Or lineTo >= Me.TextArea.Lines.Count Then Exit Sub
        Dim operatedLength As Integer = 0

        'Action
        For n As Integer = lineFrom To lineTo
            If Me.TextArea.Lines(n).Text.Trim().StartsWith(CommentSet) Then 'Is Comment Present
                Me.TextArea.TargetStart = Me.TextArea.Lines(n).Position
                Me.TextArea.TargetEnd = Me.TextArea.Lines(n).EndPosition

                Dim tabCount As Integer = GetPaddedTabCount(Me.TextArea.Lines(n).Text)
                Dim tmp As String = StrDup(tabCount, vbTab) & StringExtension.RSStr(Me.TextArea.Lines(n).Text, CommentSet)
                Me.TextArea.ReplaceTarget(tmp)
                operatedLength += CommentSet.Length
            End If
        Next

    End Sub
#End Region


#Region "Zoom"

    Private Sub ZoomIn()
        TextArea.ZoomIn()
    End Sub

    Private Sub ZoomOut()
        TextArea.ZoomOut()
    End Sub

    Private Sub ZoomDefault()
        TextArea.Zoom = 0
    End Sub


#End Region

#Region "Find & Replace Dialog"
    Public Sub ShowFindDialog()
        FindDialog.Show()
        FindDialog.Activate()
    End Sub

    Public Sub HideFindDialog()
        FindDialog.Hide()
    End Sub
#End Region

#Region "Utils"
    ''' <summary>
    ''' Count the number of tabs preceding in a line.
    ''' </summary>
    Public Overridable Function GetPaddedTabCount(text As String) As Integer
        If Me.Text = "" Then Return 0 'No Text currently

        Dim lineChars As Char() = text.ToCharArray()
        Dim count As Integer = 0
        For n As Integer = 0 To lineChars.Length - 1
            If lineChars(n) = vbTab Then 'Tab
                count += 1
            Else 'Other character discovered, end of process
                Exit For
            End If
        Next

        Return count
    End Function

    Public Shared Function IntToColor(rgb As Integer) As Color
        Dim bytes = System.BitConverter.GetBytes(rgb)
        If bytes.Length = 1 Then
            Return Color.FromArgb(255, 0, 0, bytes(0))
        ElseIf bytes.Length = 2 Then
            Return Color.FromArgb(255, 0, bytes(1), bytes(0))
        Else
            Return Color.FromArgb(255, bytes(2), bytes(1), bytes(0))
        End If
    End Function

    Public Sub InvokeIfNeeded(action As Action)
        If Me.InvokeRequired Then
            Me.BeginInvoke(action)
        Else
            action.Invoke()
        End If
    End Sub
#End Region

End Class
