Public Interface IFormRefresh
    Sub RefreshForm()
End Interface

Public Interface IFormClose
    ''' <summary>
    ''' Close the Form in program defined ways, may be Hide or Close.
    ''' </summary>
    Sub CloseForm()
End Interface

Public Interface IFullScreenable
    Property FullScreen() As Boolean
End Interface