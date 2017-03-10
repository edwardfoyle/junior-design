Public Class Token
    Inherits ParseNode
    Dim type As TokenType
    Dim str As String

    Public Sub New(type As TokenType, str As String)
        Me.type = type
        Me.str = str
    End Sub

    Public Overrides Function ToString() As String
        Return str.ToUpper()
    End Function

    Public Enum TokenType
        Begin
        ForBegin
        Dots
        Colon
        ForLoop
        EndFor
        Park
        Slew
        SlewTo
        LParen
        RParen
        Semi
        Record
        StopRecord
        Int
        Float
    End Enum

End Class
