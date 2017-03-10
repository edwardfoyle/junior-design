Public Class Nonterminal
    Inherits ParseNode
    Dim str As NonterminalType
    Dim children As LinkedList(Of ParseNode)

    Public Enum NonterminalType
        Program
        ForLoop
        Park
        Slew
        Record
        StatementSeries
        Statement
    End Enum

End Class
