Imports System.Collections.Generic

Namespace Smart.Consistency
    Public Class Map
        Public Database As SqlDatabase
        Public Columns As List(Of ColumnInfo)

        Public Sub New(db As SqlDatabase)
            Me.Database = db
            LoadObjects()
        End Sub

        Private Sub LoadObjects()
            Columns = New List(Of ColumnInfo)

            Dim query As Smart.SqlQuery = Database.NewQuery()
            query.Text = My.Resources.SystemQueryResource.GetAllColumns()
            Dim dt As DataTable = query.ExecuteAsTable() 'Get all table columns information

            'Build the map
            For n As Integer = 0 To dt.Rows.Count - 1
                Dim colName As String = dt.Rows(n)("ColumnName").ToString()
                Dim colObj As ColumnInfo = (From t In Columns Where t.ColumnName = colName Select t).FirstOrDefault()
                If colObj Is Nothing Then
                    Columns.Add(New ColumnInfo(Database.Name, dt.Rows(n)("FullName").ToString(), colName, dt.Rows(n)("DataType").ToString(), CInt(dt.Rows(n)("ObjectId"))))
                Else
                    colObj.AddReference(Database.Name, dt.Rows(n)("FullName").ToString(), dt.Rows(n)("DataType").ToString(), CInt(dt.Rows(n)("ObjectId")))
                End If
            Next

            'Sort the result
            For n As Integer = 0 To Columns.Count - 1
                Columns(n).UpdateStatistics()
            Next
            Columns.Sort()
        End Sub

#Region "Statistics Result"
        Public Function GetColumnInfo(name As String) As ColumnInfo
            Return (From t In Columns Where String.Equals(t.ColumnName, name, StringComparison.InvariantCultureIgnoreCase) Select t).FirstOrDefault()
        End Function

        Public Function SearchColumn(name As String) As List(Of ColumnInfo)
            Dim list = (From t In Columns Where CHK.StringExtension.Contains(t.ColumnName, name, False) And Not String.Equals(t.ColumnName, name, StringComparison.InvariantCultureIgnoreCase) Select t).ToList()
            Dim exactObj = GetColumnInfo(name)
            If exactObj IsNot Nothing Then list.Insert(0, exactObj)
            Return list
        End Function

        Public Function SearchDiscrepantColumn() As List(Of ColumnInfo)
            Dim list = (From t In Columns Where t.DataTypes.Count > 1 Select t).ToList()
            Return list
        End Function

        Public Function SearchByDataType(dataType As String) As List(Of ColumnInfo)
            Dim list = (From t In Columns Where t.DataTypes.Any(Function(f) f.DataType.StartsWith(dataType)) Select t).ToList()
            Return list
        End Function
#End Region
    End Class

    Public Class ColumnInfo : Implements IComparable(Of ColumnInfo)
        Public ColumnName As String
        Public DataTypes As New List(Of ColumnDataType)
        Public TotalFrequency As Integer
        Public FrequentDataTypeNames As String()
        Public FrequentDataType As ColumnDataType

        Public Sub New(dbName As String, dbObjName As String, colName As String, dataType As String, objId As Integer)
            ColumnName = colName
            AddReference(dbName, dbObjName, dataType, objId)
        End Sub

        Public Sub AddReference(dbName As String, objName As String, dataType As String, objId As Integer)
            Dim tran = (From t In DataTypes Where t.DataType = dataType).FirstOrDefault()
            If tran Is Nothing Then
                tran = New ColumnDataType(dataType)
                Me.DataTypes.Add(tran)
            End If
            tran.References.Add(New DbObjectRef(dbName, objName, objId))
        End Sub

        Public Sub UpdateStatistics()
            TotalFrequency = (From t In DataTypes Select t.Frequency).Sum()
            For n As Integer = 0 To Me.DataTypes.Count - 1
                With Me.DataTypes(n)
                    .Percent = .Frequency / TotalFrequency
                End With
            Next

            Dim maxFreq As Integer = (From t In DataTypes Select t.Frequency).Max()
            FrequentDataTypeNames = (From t In DataTypes Where t.Frequency = maxFreq Select t.DataType).ToArray()

            For n As Integer = 0 To Me.DataTypes.Count - 1
                Me.DataTypes(n).IsFrequent = CBool(Me.DataTypes(n).Frequency = maxFreq)
                If Me.DataTypes(n).IsFrequent Then Me.FrequentDataType = Me.DataTypes(n)
            Next
        End Sub

        Public Function CompareTo(other As ColumnInfo) As Integer Implements System.IComparable(Of ColumnInfo).CompareTo
            Return Me.ColumnName.CompareTo(other.ColumnName)
        End Function
    End Class

    Public Class ColumnDataType
        Public DataType As String
        Public References As New List(Of DbObjectRef)
        Public ReadOnly Property Frequency As Integer
            Get
                Return References.Count
            End Get
        End Property
        Public Percent As Double
        Public IsFrequent As Boolean

        Public Sub New(dataType As String)
            Me.DataType = dataType
        End Sub
    End Class

    Public Class DbObjectRef
        Public DatabaseName As String
        Public ObjectName As String
        Public ObjectId As Integer

        Public Sub New(dbName As String, objName As String, objId As Integer)
            Me.DatabaseName = dbName
            Me.ObjectName = objName
            Me.ObjectId = objId
        End Sub
    End Class
End Namespace