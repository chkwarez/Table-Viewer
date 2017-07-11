Public Class frm_Comparer : Implements IFormClose
    Dim SPScriptFileName As String
    Dim FNScriptFileName As String
    Dim VWScriptFileName As String

    Private ReadOnly Property ParentMainForm() As frm_Main
        Get
            Return CType(Me.ParentForm, frm_Main)
        End Get
    End Property

#Region "Form Events"
    Private Sub frm_Comparer_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ParentMainForm.RecordActiveWindow(Me)
    End Sub

    Private Sub frm_Comparer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frm_Comparer.CheckForIllegalCrossThreadCalls = False
        LoadDatabaseList()
        SetDefaultConnectionString()
    End Sub
#End Region

#Region "Button Events"
    Private Sub btnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click
        If ddSource.Text = "" Or ddDest.Text = "" Then Exit Sub
        bwLogic.RunWorkerAsync()
    End Sub

    Private Sub btnExchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchange.Click
        Dim a As String = ddSource.Text
        ddSource.Text = ddDest.Text
        ddDest.Text = a
    End Sub

    Private Sub btnOpenSuggestQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenSuggestQuery.Click
        Dim q = ParentMainForm.CreateQueryWindow("")
        q.SetQuery(ddDest.Text, txtSuggestQuery.Text)
    End Sub

    Private Sub lnkSPOpenFile_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSPOpenFile.LinkClicked
        If System.IO.File.Exists(SPScriptFileName) Then
            System.Diagnostics.Process.Start(SPScriptFileName)
        End If
    End Sub

    Private Sub lnkFNOpenFile_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFNOpenFile.LinkClicked
        If System.IO.File.Exists(FNScriptFileName) Then
            System.Diagnostics.Process.Start(FNScriptFileName)
        End If
    End Sub

    Private Sub lnkVWOpenFile_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkVWOpenFile.LinkClicked
        If System.IO.File.Exists(VWScriptFileName) Then
            System.Diagnostics.Process.Start(VWScriptFileName)
        End If
    End Sub

    Private Sub lnkSPOpenQuery_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSPOpenQuery.LinkClicked
        If System.IO.File.Exists(SPScriptFileName) Then
            Dim q = ParentMainForm.CreateQueryWindow("")
            q.LoadQueryFromFile(ddDest.Text, SPScriptFileName)
        End If
    End Sub

    Private Sub lnkFNOpenQuery_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFNOpenQuery.LinkClicked
        If System.IO.File.Exists(FNScriptFileName) Then
            Dim q = ParentMainForm.CreateQueryWindow("")
            q.LoadQueryFromFile(ddDest.Text, FNScriptFileName)
        End If
    End Sub

    Private Sub lnkVWOpenQuery_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkVWOpenQuery.LinkClicked
        If System.IO.File.Exists(VWScriptFileName) Then
            Dim q = ParentMainForm.CreateQueryWindow("")
            q.LoadQueryFromFile(ddDest.Text, VWScriptFileName)
        End If
    End Sub
#End Region

#Region "Other Control Events"
    Private Sub bwLogic_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLogic.DoWork
        StartComparison()
    End Sub
#End Region

#Region "Prorgram Functions"
    Public Sub LoadDatabaseList()
        Try
            Dim dtTable As DataTable
            dtTable = ParentMainForm.DatabaseWindow.Server.GetDatabases(True)

            ddSource.Items.Clear()
            For n As Integer = 0 To dtTable.Rows.Count - 1
                ddSource.Items.Add(dtTable.Rows(n)("name").ToString())
            Next
            ddSource.Text = ParentMainForm.DatabaseWindow.SelectedDatabase

            ddDest.Items.Clear()
            For n As Integer = 0 To dtTable.Rows.Count - 1
                ddDest.Items.Add(dtTable.Rows(n)("name").ToString())
            Next
            'ddDest.Text = ParentMainForm.DatabaseWindow.SelectedDatabase

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub SetDefaultConnectionString()
        Dim allConnStrs() As String

        allConnStrs = ConfigurationSettings.GetAllConnectionStringHistory()
        If Not allConnStrs Is Nothing Then 'Has History
            ddDestConnectionString.Items.Clear()
            For n As Integer = 0 To allConnStrs.Length - 1
                If allConnStrs(n).Trim() = "" Then Continue For
                ddDestConnectionString.Items.Add(allConnStrs(n))
            Next
        End If
    End Sub
#End Region

#Region "Comparing Algorithm"
    Private Sub StartComparison()
        TabControl1.TabIndex = 0
        lvwResult.ClearItems()
        lvwResult.Columns(2).Text = "[" & ddSource.Text & "]"
        lvwResult.Columns(3).Text = "[" & ddDest.Text & "]"
        ddSource.Enabled = False
        ddDest.Enabled = False
        btnCompare.Enabled = False
        btnExchange.Enabled = False

        CompareDatabase()

        ddSource.Enabled = True
        ddDest.Enabled = True
        btnCompare.Enabled = True
        btnExchange.Enabled = True
    End Sub

    Private Sub CompareDatabase()
        Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Initializing Database...")

        Dim conn1 As CHK.SmartDataAdapter = ParentMainForm.DatabaseWindow.CreateDataAdapter()
        Dim db1 As New Smart.SqlDatabase(conn1, ddSource.Text)

        Dim conn2 As CHK.SmartDataAdapter
        Dim db2 As Smart.SqlDatabase
        If ddDestConnectionString.Text = "" Then
            conn2 = ParentMainForm.DatabaseWindow.CreateDataAdapter()
            db2 = New Smart.SqlDatabase(conn2, ddDest.Text)
        Else
            conn2 = New SmartDataAdapter(ddDestConnectionString.Text)
            db2 = New Smart.SqlDatabase(conn2, ddDest.Text)
        End If

        'Suggestion Script for Sync.
        Dim suggestedSql As New System.Text.StringBuilder()
        SPScriptFileName = System.IO.Path.GetTempFileName & ".txt"
        Dim fileSP As New System.IO.StreamWriter(SPScriptFileName)
        FNScriptFileName = System.IO.Path.GetTempFileName & ".txt"
        Dim fileFN As New System.IO.StreamWriter(FNScriptFileName)
        VWScriptFileName = System.IO.Path.GetTempFileName & ".txt"
        Dim fileVW As New System.IO.StreamWriter(VWScriptFileName)

        '=============Tables=============
        If chkCheckTB.Checked Then
            Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Analyzing Tables...")

            'Check Table Existence
            Dim tables1 As List(Of Smart.SqlTable) = db1.GetTableList()
            Dim tables2 As List(Of Smart.SqlTable) = db2.GetTableList()

            Dim trsp1 As List(Of Smart.SqlTable) = (From p In tables1 Where Not (From q In tables2 Select q.FullName).Contains(p.FullName) Select p).ToList() 'In 1, Not In 2
            Dim trsp2 As List(Of Smart.SqlTable) = (From q In tables2 Where Not (From p In tables1 Select p.FullName).Contains(q.FullName) Select q).ToList() 'In 2, Not In 1

            For Each i As Smart.SqlTable In trsp1
                Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "Exists", "", "")
                item.Group = lvwResult.GetGroup("Table Existence")
            Next

            If chkSkipDeleteDestTable.Checked = False Then
                For Each i As Smart.SqlTable In trsp2
                    suggestedSql.AppendLine(i.GetDeleteSQL())
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "", "Exists", "")
                    item.Group = lvwResult.GetGroup("Table Existence")
                Next
            End If

            'Columns and Indices
            Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Analyzing Table Columns...")
            Dim commTables1 As List(Of Smart.SqlTable) = (From p In tables1 Where (From q In tables2 Select q.FullName).Contains(p.FullName) Select p Order By p.FullName).ToList()
            Dim commTables2 As List(Of Smart.SqlTable) = (From q In tables2 Where (From p In tables1 Select p.FullName).Contains(q.FullName) Select q Order By q.FullName).ToList()

            For n As Integer = 0 To commTables1.Count - 1 'Should be same order as table 2
                Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Analyzing Table " & commTables1(n).FullName & "...")

                'Check Column Existence
                Dim cols1 As Smart.SqlColumn() = commTables1(n).GetColumns(Smart.SqlTable.ColumnType.AllColumns)
                Dim cols2 As Smart.SqlColumn() = commTables2(n).GetColumns(Smart.SqlTable.ColumnType.AllColumns)

                Dim trsp3 As List(Of Smart.SqlColumn) = (From p In cols1 Where Not (From q In cols2 Select q.Name).Contains(p.Name) Select p).ToList()
                Dim trsp4 As List(Of Smart.SqlColumn) = (From q In cols2 Where Not (From p In cols1 Select p.Name).Contains(q.Name) Select q).ToList()

                For Each i As Smart.SqlColumn In trsp3
                    Dim sql = "ALTER TABLE " & commTables1(n).FullName & " ADD [" & i.Name & "] " & i.DataType & If(i.IsNullable, "", " NOT NULL")
                    suggestedSql.AppendLine(sql)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, commTables1(n).FullName, i.Name, i.DataType, "", sql)
                    item.Group = lvwResult.GetGroup("Column Existence")
                Next

                For Each i As Smart.SqlColumn In trsp4
                    Dim sql = "ALTER TABLE " & commTables2(n).FullName & " DROP COLUMN [" & i.Name & "]"
                    suggestedSql.AppendLine(sql)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, commTables2(n).FullName, i.Name, "", i.DataType, sql)
                    item.Group = lvwResult.GetGroup("Column Existence")
                Next

                'Check Column Properties
                Dim commCols1 As List(Of Smart.SqlColumn) = (From p In cols1 Where (From q In cols2 Select q.Name).Contains(p.Name) Select p Order By p.Name).ToList()
                Dim commCols2 As List(Of Smart.SqlColumn) = (From q In cols2 Where (From p In cols1 Select p.Name).Contains(q.Name) Select q Order By q.Name).ToList()

                For m As Integer = 0 To commCols1.Count - 1 'Should be the same order as column 2
                    If Not commCols1(m).IsKey = commCols2(m).IsKey Then
                        Dim item As ListViewItem = lvwResult.AddItem(Nothing, commTables2(n).FullName, commCols2(m).Name, commCols1(m).IsKey.ToString(), commCols2(m).IsKey.ToString(), "")
                        item.Group = lvwResult.GetGroup("Primary Key")
                    End If

                    If Not commCols1(m).IsNullable = commCols2(m).IsNullable Then
                        Dim item As ListViewItem = lvwResult.AddItem(Nothing, commTables2(n).FullName, commCols2(m).Name, commCols1(m).IsNullable.ToString(), commCols2(m).IsNullable.ToString(), "")
                        item.Group = lvwResult.GetGroup("Nullable")
                    End If

                    If Not commCols1(m).IsAutoIncrement = commCols2(m).IsAutoIncrement Then
                        Dim item As ListViewItem = lvwResult.AddItem(Nothing, commTables2(n).FullName, commCols2(m).Name, commCols1(m).IsAutoIncrement.ToString(), commCols2(m).IsAutoIncrement.ToString(), "")
                        item.Group = lvwResult.GetGroup("Auto Increment")
                    End If

                    If Not commCols1(m).IsUnique = commCols2(m).IsUnique Then
                        Dim item As ListViewItem = lvwResult.AddItem(Nothing, commTables2(n).FullName, commCols2(m).Name, commCols1(m).IsUnique.ToString(), commCols2(m).IsUnique.ToString(), "")
                        item.Group = lvwResult.GetGroup("Unique")
                    End If

                    If Not commCols1(m).DataType = commCols2(m).DataType Then
                        Dim sql = "ALTER TABLE " & commTables2(n).FullName & " ALTER COLUMN [" & commCols2(m).Name & "] " & commCols1(m).DataType & If(commCols1(m).IsNullable, "", " NOT NULL")
                        suggestedSql.AppendLine(sql)
                        Dim item As ListViewItem = lvwResult.AddItem(Nothing, commTables2(n).FullName, commCols2(m).Name, commCols1(m).DataType, commCols2(m).DataType, sql)
                        item.Group = lvwResult.GetGroup("Data Types")
                    End If

                    If Not commCols1(m).DefaultValue = commCols2(m).DefaultValue Then
                        Dim item As ListViewItem = lvwResult.AddItem(Nothing, commTables2(n).FullName, commCols2(m).Name, commCols1(m).DefaultValue.ToString(), commCols2(m).DefaultValue.ToString(), "")
                        item.Group = lvwResult.GetGroup("Default Value")
                    End If
                Next

                'Check Indices
                Dim ixs1 As Smart.SqlIndex() = commTables1(n).GetIndices()
                Dim ixs2 As Smart.SqlIndex() = commTables2(n).GetIndices()

                Dim trix1 As List(Of Smart.SqlIndex) = (From p In ixs1 Where Not (From q In ixs2 Select q.Name).Contains(p.Name) Select p).ToList() 'In 1, Not In 2
                Dim trix2 As List(Of Smart.SqlIndex) = (From p In ixs2 Where Not (From q In ixs1 Select q.Name).Contains(p.Name) Select p).ToList() 'In 2, Not In 1

                For Each i As Smart.SqlIndex In trix1
                    Dim sql = "CREATE NONCLUSTERED INDEX " & i.Name & " ON  " & commTables1(n).FullName & " (" & i.ToColumnString & ")"
                    suggestedSql.AppendLine(sql)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.Name, "", "Exists", "", i.ToColumnString)
                    item.Group = lvwResult.GetGroup("Index Existence")
                Next

                For Each i As Smart.SqlIndex In trix2
                    Dim sql = "CREATE NONCLUSTERED INDEX " & i.Name & " ON  " & commTables1(n).FullName & " (" & i.ToColumnString & ")"
                    suggestedSql.AppendLine(sql)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.Name, "", "", "Exists", i.ToColumnString)
                    item.Group = lvwResult.GetGroup("Index Existence")
                Next

                Dim commix1 As List(Of Smart.SqlIndex) = (From p In ixs1 Where (From q In ixs2 Select q.Name).Contains(p.Name) Select p Order By p.Name).ToList()
                Dim commix2 As List(Of Smart.SqlIndex) = (From q In ixs2 Where (From p In ixs1 Select p.Name).Contains(q.Name) Select q Order By q.Name).ToList()
                For m As Integer = 0 To commix1.Count - 1 'Should be same order as index 2
                    If Not commix1(m).ToColumnString = commix2(m).ToColumnString Then
                        Dim item As ListViewItem = lvwResult.AddItem(Nothing, commix1(m).Name, "", commix1(m).ToColumnString, commix2(m).ToColumnString, "")
                        item.Group = lvwResult.GetGroup("Index Column")
                    End If
                Next

                'Check Unique Keys
                Dim uks1 As Smart.SqlUniqueKey() = commTables1(n).GetUniqueKeys()
                Dim uks2 As Smart.SqlUniqueKey() = commTables2(n).GetUniqueKeys()

                Dim truk1 As List(Of Smart.SqlUniqueKey) = (From p In uks1 Where Not (From q In uks2 Select q.Name).Contains(p.Name) Select p).ToList() 'In 1, Not In 2
                Dim truk2 As List(Of Smart.SqlUniqueKey) = (From p In uks2 Where Not (From q In uks1 Select q.Name).Contains(p.Name) Select p).ToList() 'In 2, Not In 1

                For Each i As Smart.SqlUniqueKey In truk1
                    Dim sql = "ALTER TABLE " & commTables1(n).FullName & " ADD CONSTRAINT " & i.Name & " UNIQUE (" & i.ToColumnString & ")"
                    suggestedSql.AppendLine(sql)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.Name, "", "Exists", "", i.ToColumnString)
                    item.Group = lvwResult.GetGroup("Unique Key Existence")
                Next

                For Each i As Smart.SqlUniqueKey In truk2
                    Dim sql = "ALTER TABLE " & commTables1(n).FullName & " ADD CONSTRAINT " & i.Name & " UNIQUE (" & i.ToColumnString & ")"
                    suggestedSql.AppendLine(sql)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.Name, "", "", "Exists", i.ToColumnString)
                    item.Group = lvwResult.GetGroup("Unique Key Existence")
                Next

                Dim commuk1 As List(Of Smart.SqlUniqueKey) = (From p In uks1 Where (From q In uks2 Select q.Name).Contains(p.Name) Select p Order By p.Name).ToList()
                Dim commuk2 As List(Of Smart.SqlUniqueKey) = (From q In uks2 Where (From p In uks1 Select p.Name).Contains(q.Name) Select q Order By q.Name).ToList()
                For m As Integer = 0 To commuk1.Count - 1 'Should be same order as index 2
                    If Not commuk1(m).ToColumnString = commuk2(m).ToColumnString Then
                        Dim item As ListViewItem = lvwResult.AddItem(Nothing, commuk1(m).Name, "", commuk1(m).ToColumnString, commuk2(m).ToColumnString, "")
                        item.Group = lvwResult.GetGroup("Unique Key Column")
                    End If
                Next
            Next
        End If

        '=============Stored Procedure=============
        If chkCheckSP.Checked Then
            CompareStoredProcedures(db1, db2, fileSP, suggestedSql)
        End If

        '=============Scalar Valued Function=============
        If chkCheckFN.Checked Then
            Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Analyzing Scalar Valued Functions...")
            Dim fn1 As List(Of Smart.SqlScalarValuedFunction) = db1.GetScalarValuedFunctionList()
            Dim fn2 As List(Of Smart.SqlScalarValuedFunction) = db2.GetScalarValuedFunctionList()

            Dim trsp7 As List(Of Smart.SqlScalarValuedFunction) = (From p In fn1 Where Not (From q In fn2 Select q.FullName).Contains(p.FullName) Select p).ToList() 'In 1, Not In 2
            Dim trsp8 As List(Of Smart.SqlScalarValuedFunction) = (From q In fn2 Where Not (From p In fn1 Select p.FullName).Contains(q.FullName) Select q).ToList() 'In 2, Not In 1

            For Each i As Smart.SqlScalarValuedFunction In trsp7
                fileFN.WriteLine(i.GetDefinition(True) & vbCrLf & vbCrLf & "GO" & vbCrLf)
                Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "Exists", "", "")
                item.Group = lvwResult.GetGroup("Scalar Valued Function Existence")
            Next

            For Each i As Smart.SqlScalarValuedFunction In trsp8
                suggestedSql.AppendLine(i.GetDeleteSQL())
                Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "", "Exists", "")
                item.Group = lvwResult.GetGroup("Scalar Valued Function Existence")
            Next

            Dim commFn1 As List(Of Smart.SqlScalarValuedFunction) = (From p In fn1 Where (From q In fn2 Select q.FullName).Contains(p.FullName) Order By p.FullName Select p).ToList()
            Dim commFn2 As List(Of Smart.SqlScalarValuedFunction) = (From q In fn2 Where (From p In fn1 Select p.FullName).Contains(q.FullName) Order By q.FullName Select q).ToList()

            For m As Integer = 0 To commFn1.Count - 1 'Should be the same order as sp 2
                If commFn1(m).ModifiedDate > commFn2(m).ModifiedDate Then
                    fileFN.WriteLine(commFn1(m).GetDefinition(False) & vbCrLf & vbCrLf & "GO" & vbCrLf)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, commFn1(m).FullName, "ModifiedDate", commFn1(m).ModifiedDate.ToString(), commFn2(m).ModifiedDate.ToString(), "")
                    item.Group = lvwResult.GetGroup("Scalar Valued Function Updated")
                End If
            Next
        End If

        '=============Table Valued Function=============
        If chkCheckTF.Checked Then
            Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Analyzing Table Valued Functions...")
            Dim tf1 As List(Of Smart.SqlTableValuedFunction) = db1.GetTableValuedFunctionList()
            Dim tf2 As List(Of Smart.SqlTableValuedFunction) = db2.GetTableValuedFunctionList()

            Dim trsp9 As List(Of Smart.SqlTableValuedFunction) = (From p In tf1 Where Not (From q In tf2 Select q.FullName).Contains(p.FullName) Select p).ToList() 'In 1, Not In 2
            Dim trsp10 As List(Of Smart.SqlTableValuedFunction) = (From q In tf2 Where Not (From p In tf1 Select p.FullName).Contains(q.FullName) Select q).ToList() 'In 2, Not In 1

            For Each i As Smart.SqlTableValuedFunction In trsp9
                fileFN.WriteLine(i.GetDefinition(True) & vbCrLf & vbCrLf & "GO" & vbCrLf)
                Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "Exists", "", "")
                item.Group = lvwResult.GetGroup("Table Valued Function Existence")
            Next

            For Each i As Smart.SqlTableValuedFunction In trsp10
                suggestedSql.AppendLine(i.GetDeleteSQL())
                Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "", "Exists", "")
                item.Group = lvwResult.GetGroup("Table Valued Function Existence")
            Next

            Dim commTf1 As List(Of Smart.SqlTableValuedFunction) = (From p In tf1 Where (From q In tf2 Select q.FullName).Contains(p.FullName) Order By p.FullName Select p).ToList()
            Dim commTf2 As List(Of Smart.SqlTableValuedFunction) = (From q In tf2 Where (From p In tf1 Select p.FullName).Contains(q.FullName) Order By q.FullName Select q).ToList()

            For m As Integer = 0 To commTf1.Count - 1 'Should be the same order as sp 2
                If commTf1(m).ModifiedDate > commTf2(m).ModifiedDate Then
                    fileFN.WriteLine(commTf1(m).GetDefinition(False) & vbCrLf & vbCrLf & "GO" & vbCrLf)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, commTf1(m).FullName, "ModifiedDate", commTf1(m).ModifiedDate.ToString(), commTf2(m).ModifiedDate.ToString(), "")
                    item.Group = lvwResult.GetGroup("Table Valued Function Updated")
                End If
            Next
        End If

        '=============Inline Table Valued Function=============
        If chkCheckTF.Checked Then
            Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Analyzing Inline Table Valued Functions...")
            Dim if1 As List(Of Smart.SqlInlineTableFunction) = db1.GetInlineTableFunctionList()
            Dim if2 As List(Of Smart.SqlInlineTableFunction) = db2.GetInlineTableFunctionList()

            Dim trsp11 As List(Of Smart.SqlInlineTableFunction) = (From p In if1 Where Not (From q In if2 Select q.FullName).Contains(p.FullName) Select p).ToList() 'In 1, Not In 2
            Dim trsp12 As List(Of Smart.SqlInlineTableFunction) = (From q In if2 Where Not (From p In if1 Select p.FullName).Contains(q.FullName) Select q).ToList() 'In 2, Not In 1

            For Each i As Smart.SqlInlineTableFunction In trsp11
                fileFN.WriteLine(i.GetDefinition(True) & vbCrLf & vbCrLf & "GO" & vbCrLf)
                Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "Exists", "", "")
                item.Group = lvwResult.GetGroup("Table Valued Function Existence")
            Next

            For Each i As Smart.SqlInlineTableFunction In trsp12
                suggestedSql.AppendLine(i.GetDeleteSQL())
                Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "", "Exists", "")
                item.Group = lvwResult.GetGroup("Table Valued Function Existence")
            Next

            Dim commif1 As List(Of Smart.SqlInlineTableFunction) = (From p In if1 Where (From q In if2 Select q.FullName).Contains(p.FullName) Order By p.FullName Select p).ToList()
            Dim commif2 As List(Of Smart.SqlInlineTableFunction) = (From q In if2 Where (From p In if1 Select p.FullName).Contains(q.FullName) Order By q.FullName Select q).ToList()

            For m As Integer = 0 To commif1.Count - 1 'Should be the same order as sp 2
                If commif1(m).ModifiedDate > commif2(m).ModifiedDate Then
                    fileFN.WriteLine(commif1(m).GetDefinition(False) & vbCrLf & vbCrLf & "GO" & vbCrLf)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, commif1(m).FullName, "ModifiedDate", commif1(m).ModifiedDate.ToString(), commif2(m).ModifiedDate.ToString(), "")
                    item.Group = lvwResult.GetGroup("Table Valued Function Updated")
                End If
            Next
        End If

        '=============View=============
        If chkCheckVW.Checked Then
            CompareViews(db1, db2, fileVW, suggestedSql)
        End If

        'Finish routine
        conn1.CloseConnection()
        conn2.CloseConnection()

        fileSP.Close()
        fileFN.Close()
        fileVW.Close()
        txtSuggestQuery.Text = suggestedSql.ToString()

        Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Done")
    End Sub

    Private Sub CompareStoredProcedures(db1 As Smart.SqlDatabase, db2 As Smart.SqlDatabase, fileScript As System.IO.StreamWriter, simpleScript As System.Text.StringBuilder)
        Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Retrieving Stored Procedures...")
        Dim sp1 As List(Of Smart.SqlStoredProcedure) = db1.GetStoredProcedureList()
        Dim sp2 As List(Of Smart.SqlStoredProcedure) = db2.GetStoredProcedureList()

        Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Analyzing Stored Procedures... (Source: " & sp1.Count & "  Dest: " & sp2.Count & ")")
        'Existence
        Dim trsp5 As List(Of Smart.SqlStoredProcedure) = (From p In sp1 Where Not (From q In sp2 Select q.FullName).Contains(p.FullName) Select p).ToList() 'In 1, Not In 2
        Dim trsp6 As List(Of Smart.SqlStoredProcedure) = (From q In sp2 Where Not (From p In sp1 Select p.FullName).Contains(q.FullName) Select q).ToList() 'In 2, Not In 1

        For Each i As Smart.SqlStoredProcedure In trsp5
            fileScript.WriteLine(i.GetDefinition(True) & vbCrLf & vbCrLf & "GO" & vbCrLf)
            Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "Exists", "", "")
            item.Group = lvwResult.GetGroup("Stored Procedure Existence")
        Next

        For Each i As Smart.SqlStoredProcedure In trsp6
            simpleScript.AppendLine(i.GetDeleteSQL())
            Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "", "Exists", "")
            item.Group = lvwResult.GetGroup("Stored Procedure Existence")
        Next

        'Update
        Dim commSp1 As List(Of Smart.SqlStoredProcedure) = (From p In sp1 Where (From q In sp2 Select q.FullName).Contains(p.FullName) Order By p.FullName Select p).ToList()
        Dim commSp2 As List(Of Smart.SqlStoredProcedure) = (From q In sp2 Where (From p In sp1 Select p.FullName).Contains(q.FullName) Order By q.FullName Select q).ToList()

        For m As Integer = 0 To commSp1.Count - 1 'Should be the same order as sp 2
            If radCompareByDate.Checked Then
                If commSp1(m).ModifiedDate > commSp2(m).ModifiedDate Then
                    fileScript.WriteLine(commSp1(m).GetDefinition(False) & vbCrLf & vbCrLf & "GO" & vbCrLf)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, commSp1(m).FullName, "ModifiedDate", commSp1(m).ModifiedDate.ToString(), commSp2(m).ModifiedDate.ToString(), "")
                    item.Group = lvwResult.GetGroup("Stored Procedure Updated")
                End If

            ElseIf radCompareByDefinition.Checked Then
                Dim resSp = DatabaseComparisonLogic.CompareText(commSp1(m).GetDefinition(False), commSp2(m).GetDefinition(False)) '.Replace(vbCrLf, vbLf)
                If resSp.IsEqual = False Then
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, commSp1(m).FullName, "Definition", commSp1(m).ModifiedDate.ToString(), commSp2(m).ModifiedDate.ToString(), resSp.Difference1)
                    item.Group = lvwResult.GetGroup("Stored Procedure Updated")
                End If
            End If
        Next
    End Sub

    Private Sub CompareViews(db1 As Smart.SqlDatabase, db2 As Smart.SqlDatabase, fileScript As System.IO.StreamWriter, simpleScript As System.Text.StringBuilder)
        Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Retrieving Views...")
        Dim vw1 As List(Of Smart.SqlView) = db1.GetViewList()
        Dim vw2 As List(Of Smart.SqlView) = db2.GetViewList()

        Me.Invoke(New ShowStatusDelegate(AddressOf ShowStatus), "Analyzing Views... (Source: " & vw1.Count & "  Dest: " & vw2.Count & ")")
        'Existence
        Dim trsp13 As List(Of Smart.SqlView) = (From p In vw1 Where Not (From q In vw2 Select q.FullName).Contains(p.FullName) Select p).ToList() 'In 1, Not In 2
        Dim trsp14 As List(Of Smart.SqlView) = (From q In vw2 Where Not (From p In vw1 Select p.FullName).Contains(q.FullName) Select q).ToList() 'In 2, Not In 1

        For Each i As Smart.SqlView In trsp13
            fileScript.WriteLine(i.GetDefinition(True) & vbCrLf & vbCrLf & "GO" & vbCrLf)
            Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "Exists", "", "")
            item.Group = lvwResult.GetGroup("View Existence")
        Next

        For Each i As Smart.SqlView In trsp14
            simpleScript.AppendLine(i.GetDeleteSQL())
            Dim item As ListViewItem = lvwResult.AddItem(Nothing, i.FullName, "", "", "Exists", "")
            item.Group = lvwResult.GetGroup("View Existence")
        Next

        'Update
        Dim commVw1 As List(Of Smart.SqlView) = (From p In vw1 Where (From q In vw2 Select q.FullName).Contains(p.FullName) Order By p.FullName Select p).ToList()
        Dim commVw2 As List(Of Smart.SqlView) = (From q In vw2 Where (From p In vw1 Select p.FullName).Contains(q.FullName) Order By q.FullName Select q).ToList()

        For m As Integer = 0 To commVw1.Count - 1 'Should be the same order as sp 2
            If radCompareByDate.Checked Then
                If commVw1(m).ModifiedDate > commVw2(m).ModifiedDate Then
                    fileScript.WriteLine(commVw1(m).GetDefinition(False) & vbCrLf & vbCrLf & "GO" & vbCrLf)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, commVw1(m).FullName, "ModifiedDate", commVw1(m).ModifiedDate.ToString(), commVw2(m).ModifiedDate.ToString(), "")
                    item.Group = lvwResult.GetGroup("View Updated")
                End If

            ElseIf radCompareByDefinition.Checked Then
                Dim def1 = commVw1(m).GetDefinition(False).Replace(vbCrLf, vbLf)
                Dim def2 = commVw2(m).GetDefinition(False).Replace(vbCrLf, vbLf)

                If Not def1 = def2 Then
                    fileScript.WriteLine(commVw1(m).GetDefinition(False) & vbCrLf & vbCrLf & "GO" & vbCrLf)
                    Dim item As ListViewItem = lvwResult.AddItem(Nothing, commVw1(m).FullName, "Definition", commVw1(m).ModifiedDate.ToString(), commVw2(m).ModifiedDate.ToString(), "")
                    item.Group = lvwResult.GetGroup("View Updated")
                End If
            End If
        Next
    End Sub
#End Region

#Region "Miscellaneous Functions"
    Public Delegate Sub ShowStatusDelegate(ByVal msg As String)

    Public Sub ShowStatus(ByVal msg As String)
        lblStatus.Text = msg
    End Sub
#End Region

#Region "Interfaces"
    Public Sub CloseForm() Implements IFormClose.CloseForm
        Me.Close()
    End Sub
#End Region



    'Private Sub ddDest_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ddDest.Validating
    '    If ddDest.Text = "" Then
    '        Me.ErrorProvider1.SetError(CType(sender, Control), "Please fill in the blank.")
    '        e.Cancel = True
    '    End If
    'End Sub

    'Private Sub ddDest_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddDest.Validated
    '    Me.ErrorProvider1.SetError(CType(sender, Control), "")
    'End Sub
End Class



