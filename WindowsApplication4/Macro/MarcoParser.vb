Public Class MarcoParser
    Dim tokens As LinkedList(Of Token)

    Public Sub New(tokens As LinkedList(Of Token))
        Me.tokens = tokens
    End Sub

    Public Function parse() As Nonterminal
        'Driver method that will call all recursive descent methods
        Return Nothing
    End Function
End Class
