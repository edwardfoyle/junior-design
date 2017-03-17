Public Class Nonterminal
    Inherits ParseNode
    Dim type As NonterminalType

    Public Sub New(type As NonterminalType)
        Me.type = type
    End Sub

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
