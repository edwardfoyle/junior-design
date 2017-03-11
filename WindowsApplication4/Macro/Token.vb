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

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim toke As Token = CType(obj, Token)
        If toke.type.Equals(Me.type) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function isType(type As TokenType) As Boolean
        Return type.Equals(Me.type)
    End Function

    Public Enum TokenType
        Begin
        ForBegin
        Done
        Dots
        Colon
        Comma
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
