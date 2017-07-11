Namespace Smart

    ''' <summary>
    ''' A class which build or parse connection string.
    ''' </summary>
    Public Class ConnectionString
        Public Server As String
        Public ReadOnly Property Port As Integer
            Get
                If Server.Contains(",") Then
                    Return Integer.Parse(CHK.StringExtension.RSStr(Server, ","))
                Else
                    Return 1433
                End If
            End Get
        End Property
        Public UserId As String
        Public Password As String
        Public IsTrust As Boolean
        Public DatabaseName As String

        Public Sub New()

        End Sub

        Public Overrides Function ToString() As String
            Dim sb As New System.Text.StringBuilder()
            sb.Append("Server=" & Server & ";")
            If IsTrust Then
                sb.Append("Trusted_Connection=True;")
            Else
                sb.Append("User ID=" & UserId & ";Password=" & Password & ";")
            End If
            If Not DatabaseName = "" Then sb.Append("Database=" & DatabaseName & ";")
            Return sb.ToString()
        End Function

        Private Shared Function GetParameters(s As String) As Dictionary(Of String, String)
            Dim strs = s.Split(New String() {";"}, StringSplitOptions.RemoveEmptyEntries)
            Dim dict As New Dictionary(Of String, String)

            For n As Integer = 0 To strs.Length - 1
                If strs(n).Contains("=") Then
                    Dim key = Trim(CHK.StringExtension.LSStr(strs(n), "=")).ToLower() 'Key are all lower cases
                    If dict.ContainsKey(key) Then 'Do Nothing
                        dict(key) = Trim(CHK.StringExtension.RSStr(strs(n), "="))
                    Else
                        dict.Add(key, Trim(CHK.StringExtension.RSStr(strs(n), "=")))
                    End If
                End If
            Next

            Return dict
        End Function

        Public Shared Function Parse(connStr As String) As ConnectionString
            Dim paras = GetParameters(connStr)

            Dim c As New ConnectionString()
            If paras.ContainsKey("server") Then c.Server = paras("server")
            If paras.ContainsKey("data source") Then c.Server = paras("data source")
            If paras.ContainsKey("database") Then c.DatabaseName = paras("database")
            If paras.ContainsKey("initial catalog") Then c.DatabaseName = paras("initial catalog")
            If paras.ContainsKey("user id") Then c.UserId = paras("user id")
            If paras.ContainsKey("password") Then c.Password = paras("password")
            If paras.ContainsKey("trusted_connection") Then c.IsTrust = CBool(paras("trusted_connection").ToLower() = "true")

            Return c
        End Function
    End Class

End Namespace
