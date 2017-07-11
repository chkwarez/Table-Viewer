Namespace Smart
    Public Class SqlServer
        Private Adapter As SmartDataAdapter
        ''' <summary>
        ''' Default database of the current connection
        ''' </summary>
        Public Database As SqlDatabase

#Region "Constructor"
        Public Sub New(ByVal existingAdapter As SmartDataAdapter)
            Adapter = existingAdapter
            Initialize()
        End Sub

        Public Sub New(ByVal connectionString As String)
            Connect(connectionString)
            Initialize()
        End Sub
#End Region

#Region "Connection"
        Public Sub Connect(ByVal connectionString As String)
            Adapter = New SmartDataAdapter(connectionString)
        End Sub

        Public Sub Disconnect()
            Adapter.CloseConnection()
        End Sub
#End Region

#Region "Database Functions"
        Public Sub ChangeDatabase(ByVal databaseName As String)
            Database.Name = databaseName
        End Sub

        Public Function GetDatabase(ByVal databaseName As String) As SqlDatabase
            Return New SqlDatabase(Adapter, databaseName)
        End Function

        Public Function GetDatabases(Optional ByVal onlineOnly As Boolean = True) As DataTable
            Dim dtTable As DataTable

            If Is2000 Then 'SQL Serve 2000
                Adapter.SetSelectCommand("SELECT [name],dbid AS database_id,'' AS state_desc,crdate AS create_date FROM master..sysdatabases WHERE [name] NOT IN ('master','model','msdb','tempdb') order by [name]", CommandType.Text)
            Else
                If onlineOnly Then
                    Adapter.SetSelectCommand("SELECT [name],database_id,state_desc,create_date FROM master.sys.databases WHERE state_desc = 'ONLINE' AND [name] NOT IN ('master','model','msdb','tempdb') order by [name]", CommandType.Text)
                Else
                    Adapter.SetSelectCommand("SELECT [name],database_id,state_desc,create_date FROM master.sys.databases WHERE [name] <> 'master' AND [name] NOT IN ('master','model','msdb','tempdb') order by [name]", CommandType.Text)
                End If
            End If

            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function

        Public Function GetSystemDatabases() As DataTable
            Dim dtTable As DataTable
            Adapter.SetSelectCommand("SELECT [name],database_id,state_desc,create_date FROM master.sys.databases WHERE [name] IN ('master','model','msdb','tempdb') order by [name]", CommandType.Text)
            dtTable = Adapter.GetDataTable()
            Return dtTable
        End Function
#End Region

#Region "Server Properties"
        Public ReadOnly Property ProductName() As String
            Get
                Dim ver As String = ProductVersion()
                If ver.StartsWith("13.") Then
                    Return "Microsoft SQL Server 2016"
                ElseIf ver.StartsWith("12.") Then
                    Return "Microsoft SQL Server 2014"
                ElseIf ver.StartsWith("11.") Then
                    Return "Microsoft SQL Server 2012"
                ElseIf ver.StartsWith("10.50.") Then
                    Return "Microsoft SQL Server 2008 R2"
                ElseIf ver.StartsWith("10.00.") Or ver.StartsWith("10.0.") Then
                    Return "Microsoft SQL Server 2008"
                ElseIf ver.StartsWith("9.") Then
                    Return "Microsoft SQL Server 2005"
                ElseIf ver.StartsWith("8.") Then
                    Return "Microsoft SQL Server 2000"
                Else
                    Return "Unknown"
                End If
            End Get
        End Property

        Public ReadOnly Property ServerName() As String
            Get
                Adapter.SetSelectCommand("SELECT SERVERPROPERTY('ServerName')", CommandType.Text)
                Return Adapter.ExecuteScalarString(CommandName.Select)
            End Get
        End Property

        Public ReadOnly Property Edition() As String
            Get
                Adapter.SetSelectCommand("SELECT SERVERPROPERTY('Edition')", CommandType.Text)
                Return Adapter.ExecuteScalarString(CommandName.Select)
            End Get
        End Property

        Public ReadOnly Property ProductVersion() As String
            Get
                Adapter.SetSelectCommand("SELECT SERVERPROPERTY('ProductVersion')", CommandType.Text)
                Return Adapter.ExecuteScalarString(CommandName.Select)
            End Get
        End Property

        Public ReadOnly Property ProductLevel() As String
            Get
                Adapter.SetSelectCommand("SELECT SERVERPROPERTY('ProductLevel')", CommandType.Text)
                Return Adapter.ExecuteScalarString(CommandName.Select)
            End Get
        End Property

        Public ReadOnly Property Is2000 As Boolean 'Is SQL Server 2000
            Get
                Return CBool(ProductName = "Microsoft SQL Server 2000")
            End Get
        End Property
#End Region

#Region "Query"
        Public Function NewQuery() As SqlQuery
            Dim q = New SqlQuery(Adapter)
            q.SetServer(Me)
            Return q
        End Function

#End Region

#Region "Temporary Stored Procedure"
        Public Sub InitializeTemporaryStoredProcedure()
            If Is2000 Then Exit Sub 'SQL Server 2000 doesn't support this SP
            If IsTemporaryStoredProcedureExist() = True Then Exit Sub
            Dim sql As String

            '##TABLEVIEWER_EXECUTESQL2
            Try
                Adapter.SetSelectCommand("DROP PROCEDURE ##TABLEVIEWER_EXECUTESQL2", CommandType.Text)
                Adapter.ExecuteNonQuery(CommandName.Select)
            Catch ex As Exception
            End Try
            sql = "CREATE PROCEDURE ##TABLEVIEWER_EXECUTESQL2"
            sql &= vbCrLf & "@statement nvarchar(max)"
            sql &= vbCrLf & "AS"
            sql &= vbCrLf & "BEGIN TRY"
            sql &= vbCrLf & "EXECUTE (@statement)"
            sql &= vbCrLf & "SELECT 'TABLE_VIEWER_SUCCESS' AS 'TABLE_VIEWER', ISNULL(@@rowCount, 0) AS 'AffectedRows'"
            sql &= vbCrLf & "END TRY"
            sql &= vbCrLf & "BEGIN CATCH"
            sql &= vbCrLf & "SELECT 'TABLE_VIEWER_ERROR' AS 'TABLE_VIEWER', ERROR_NUMBER() AS 'ERROR_NUMBER', ERROR_MESSAGE() AS 'ERROR_MESSAGE', ERROR_SEVERITY() AS 'ERROR_SEVERITY', ERROR_STATE() AS 'ERROR_STATE', ERROR_LINE() AS 'ERROR_LINE', ERROR_PROCEDURE() AS 'ERROR_PROCEDURE'"
            sql &= vbCrLf & "END CATCH"
            Adapter.SetSelectCommand(sql, CommandType.Text) 'Any Database
            Adapter.ExecuteNonQuery(CommandName.Select)
        End Sub

        Private Function IsTemporaryStoredProcedureExist() As Boolean
            Try
                Adapter.SetSelectCommand("EXEC ##TABLEVIEWER_EXECUTESQL2 @statement=''", CommandType.Text)
                Adapter.ExecuteNonQuery(CommandName.Select)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
#End Region

#Region "Initialize External Class"
        Private Sub Initialize()
            Database = New SqlDatabase(Adapter, "master")
            InitializeTemporaryStoredProcedure()
        End Sub
#End Region
    End Class
End Namespace