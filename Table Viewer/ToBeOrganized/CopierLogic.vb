Public Class CopierLogic
    Public Sub New()

    End Sub


End Class

Public Class CopyItem
    Public ItemType As Smart.CommonProperty.DatabaseObject
    Public Source As Smart.SqlDatabaseObject
    Public Destination As Smart.SqlDatabaseObject
    Public DestinationDatabase As String
    Public TruncatesDestination As Boolean
    Public CreateNewAtDestination As Boolean
    Public Action As CopierAction
End Class


Public Enum CopierAction
    Copy
End Enum