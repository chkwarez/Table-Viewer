Public Class ConnectionManager
    Public FavioriteTable As MiscDataSet.FavoriteConnectionDataTable

    Public Sub New()
        FavioriteTable = New MiscDataSet.FavoriteConnectionDataTable
    End Sub

    Public Sub LoadOption()
        Dim filePath As String = GetOptionFilePath()
        If System.IO.File.Exists(filePath) = False Then Exit Sub

        'Read
        Dim cipher = System.IO.File.ReadAllText(filePath, System.Text.Encoding.UTF8)

        'Decrypt
        Dim lines As String() 'encrypted
        If cipher.StartsWith("'''") Then
            lines = CryptorEngine.Decrypt(cipher.Substring(3), False).Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        Else 'not encrypted (old program)
            lines = cipher.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        End If

        For n As Integer = 0 To lines.Length - 1
            If lines(n).Trim() = "" Then Continue For 'Skip Empty Lines
            Dim values = Split(lines(n), vbTab)
            Dim r = FavioriteTable.NewFavoriteConnectionRow()
            r.FriendlyName = values(0)
            If values.Length > 1 Then r.ConnectionString = values(1)
            If values.Length > 2 Then r.DefaultDatabase = values(2)
            FavioriteTable.AddFavoriteConnectionRow(r)
        Next
    End Sub

    Public Sub SaveOption()
        Dim filePath As String = GetOptionFilePath()

        'Sort
        FavioriteTable.DefaultView.Sort = "FriendlyName asc"
        Dim dv = FavioriteTable.DefaultView

        'Write to File
        Dim sb As New System.Text.StringBuilder()
        For n As Integer = 0 To dv.Count - 1
            sb.AppendLine(dv(n)("FriendlyName").ToString() & vbTab & dv(n)("ConnectionString").ToString() & vbTab & dv(n)("DefaultDatabase").ToString())
        Next

        'Encrypt
        Dim cipher = "'''" & CryptorEngine.Encrypt(sb.ToString(), False)

        'Write
        System.IO.File.WriteAllText(filePath, cipher, System.Text.Encoding.UTF8)
    End Sub

    Private Function GetOptionFilePath() As String
        Return "FavoriteConnection.txt"
    End Function

End Class


