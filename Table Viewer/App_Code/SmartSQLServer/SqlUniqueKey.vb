Namespace Smart
    Public Class SqlUniqueKey : Inherits SqlIndex
        Public Overrides ReadOnly Property IsUnique As Boolean
            Get
                Return False
            End Get
        End Property

        Public Sub New()

        End Sub
    End Class
End Namespace