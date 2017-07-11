Imports Microsoft.Win32

Module ConfigurationSettings
    Private Const CONNECTIONSTRING_COUNT As Integer = 10

#Region "Connection String History"
    Public Sub AddConnectionStringHistory(ByVal connStr As String)
        Dim n As Integer
        Dim RegKey As RegistryKey = GetProgramRegistryKey(True)
        Dim History() As String = GetAllConnectionStringHistory()

        If Array.IndexOf(History, connStr) >= 0 Then Exit Sub 'Item is already exists

        For n = 2 To CONNECTIONSTRING_COUNT 'Shift All History Down By 1
            RegKey.SetValue("ConnectionString" & n.ToString(), History(n - 2))
        Next

        RegKey.SetValue("ConnectionString1", connStr, RegistryValueKind.String)
    End Sub

    Public Function GetAllConnectionStringHistory() As String()
        Dim n As Integer
        Dim RegKey As RegistryKey = GetProgramRegistryKey(False)
        Dim Result(CONNECTIONSTRING_COUNT - 1) As String

        For n = 1 To CONNECTIONSTRING_COUNT 'Read All History
            Result(n - 1) = RegKey.GetValue("ConnectionString" & n.ToString(), "").ToString()
        Next

        Return Result
    End Function
#End Region

#Region "Single Registry Entry"
    Public Property DefaultConnectionString() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("DefaultConnectionString", "").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("DefaultConnectionString", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property DefaultDatabase() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("DefaultDatabase", "").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("DefaultDatabase", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property DummyColumns() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("DummyColumns", "crea_uid,crea_date,last_updt_uid,last_updt_date,updt_uid,updt_date").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("DummyColumns", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property MaximumRecordShown() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("MaximumRecordShown", "250").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("MaximumRecordShown", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property AuthorName() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("AuthorName", "").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("AuthorName", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property PrintStoredProcedureParameterFlag() As Boolean
        Get
            Dim RegKey As RegistryKey
            Dim value As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            value = RegKey.GetValue("PrintStoredProcedureParameterFlag", "0").ToString()
            Return CType(IIf(value = "1", True, False), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Dim RegKey As RegistryKey
            Dim tmp As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            tmp = CType(IIf(value = True, "1", "0"), String)
            RegKey.SetValue("PrintStoredProcedureParameterFlag", tmp, RegistryValueKind.String)
        End Set
    End Property

    Public Property QueryFontFamily() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("QueryFontFamily", "Arial").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("QueryFontFamily", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property QueryFontSize() As Single
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)

            Dim tmp As String = RegKey.GetValue("QueryFontSize", "").ToString()
            Dim value As Single

            If Single.TryParse(tmp, value) = True Then 'Succeed
                Return value
            Else
                Return 9
            End If
        End Get
        Set(ByVal value As Single)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("QueryFontSize", value.ToString(), RegistryValueKind.String)
        End Set
    End Property

    Public Property ColorizeTableData() As Boolean
        Get
            Dim RegKey As RegistryKey
            Dim value As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            value = RegKey.GetValue("ColorizeTableData", "1").ToString()
            Return CType(IIf(value = "1", True, False), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Dim RegKey As RegistryKey
            Dim tmp As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            tmp = CType(IIf(value = True, "1", "0"), String)
            RegKey.SetValue("ColorizeTableData", tmp, RegistryValueKind.String)
        End Set
    End Property

    Public Property BLLTemplatePath() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("BLLTemplatePath", "").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("BLLTemplatePath", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property ColumnPanelWidth() As Integer
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return CHK.StringConverter.ToInteger(RegKey.GetValue("ColumnPanelWidth", "").ToString(), 220)
        End Get
        Set(ByVal value As Integer)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("ColumnPanelWidth", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property TableColumnDefaultWidth() As Integer
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return CHK.StringConverter.ToInteger(RegKey.GetValue("TableColumnDefaultWidth", "").ToString(), 100)
        End Get
        Set(ByVal value As Integer)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("TableColumnDefaultWidth", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property QuerySplitterDistance() As Integer
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return CHK.StringConverter.ToInteger(RegKey.GetValue("QuerySplitterDistance", "").ToString(), 220)
        End Get
        Set(ByVal value As Integer)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("QuerySplitterDistance", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property MsManagementStudioPath() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("MsManagementStudioPath", "").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("MsManagementStudioPath", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property WinMergePath() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("WinMergePath", "").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("WinMergePath", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property AutoFormatQuery() As Boolean
        Get
            Dim RegKey As RegistryKey
            Dim value As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            value = RegKey.GetValue("AutoFormatQuery", "0").ToString()
            Return CType(IIf(value = "1", True, False), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Dim RegKey As RegistryKey
            Dim tmp As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            tmp = CType(IIf(value = True, "1", "0"), String)
            RegKey.SetValue("AutoFormatQuery", tmp, RegistryValueKind.String)
        End Set
    End Property

    Public Property DefaultLanguage() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("DefaultLanguage", "VB").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("DefaultLanguage", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property AspxTextBoxName() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("AspxTextBoxName", "asp:TextBox").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("AspxTextBoxName", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property AutoResizeQueryResult() As Boolean
        Get
            Dim RegKey As RegistryKey
            Dim value As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            value = RegKey.GetValue("AutoResizeQueryResult", "1").ToString()
            Return CType(IIf(value = "1", True, False), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Dim RegKey As RegistryKey
            Dim tmp As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            tmp = CType(IIf(value = True, "1", "0"), String)
            RegKey.SetValue("AutoResizeQueryResult", tmp, RegistryValueKind.String)
        End Set
    End Property

    Public Property FavoriteDatabases() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("FavoriteDatabases", "").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("FavoriteDatabases", value, RegistryValueKind.String)
        End Set
    End Property

    Public Property ShowConnectionWizardAtStartUp() As Boolean
        Get
            Dim RegKey As RegistryKey
            Dim value As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            value = RegKey.GetValue("ShowConnectionWizardAtStartUp", "0").ToString()
            Return CType(IIf(value = "1", True, False), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Dim RegKey As RegistryKey
            Dim tmp As String
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            tmp = CType(IIf(value = True, "1", "0"), String)
            RegKey.SetValue("ShowConnectionWizardAtStartUp", tmp, RegistryValueKind.String)
        End Set
    End Property

    Public Property QueryResultExportPath() As String
        Get
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(False)
            Return RegKey.GetValue("QueryResultExportPath", "").ToString()
        End Get
        Set(ByVal value As String)
            Dim RegKey As RegistryKey
            RegKey = ConfigurationSettings.GetProgramRegistryKey(True)
            RegKey.SetValue("QueryResultExportPath", value, RegistryValueKind.String)
        End Set
    End Property
#End Region

#Region "General Windows Registry Function"
    Public Function GetProgramRegistryKey(ByVal CreateKey As Boolean) As RegistryKey
        Dim RegKey As RegistryKey
        RegKey = Registry.CurrentUser.OpenSubKey("Software", False).OpenSubKey(My.Resources.RegistryKeyName, True) 'HKEY_CURRENT_USER Registry Key

        If RegKey Is Nothing And CreateKey = True Then
            RegKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey(My.Resources.RegistryKeyName)
        End If

        Return RegKey
    End Function

    Public Sub CreateProgramRegistryKey()
        GetProgramRegistryKey(True)
    End Sub

    Public Function IsNewUser() As Boolean
        If GetProgramRegistryKey(False) Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
End Module

