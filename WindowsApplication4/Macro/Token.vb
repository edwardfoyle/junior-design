Public Class Token

    Dim type As TokenType
    Dim str As String

    Public Sub New(type As TokenType, str As String)
        Me.type = type
        Me.str = str
    End Sub

    Public Enum TokenType
        ForBegin
        Dots
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
