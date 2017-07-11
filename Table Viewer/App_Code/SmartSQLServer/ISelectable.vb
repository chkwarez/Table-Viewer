Public Interface ISelectable
    Function GetSelectSQL(ByVal objectAlias As String, ByVal showPrimaryKeyOnly As Boolean, ByVal useAsterisk As Boolean, Optional ByVal whereClause As String = "") As String
End Interface
