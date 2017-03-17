Public Class MacroParser
    Dim tokens As LinkedList(Of Token)
    Dim current As Token
    Dim previous As Token
    Dim result As ParseNode

    Public Sub New(tokens As LinkedList(Of Token))
        Me.tokens = tokens
        current = tokens.ElementAtOrDefault(0)
    End Sub

    Public Function Consume(type As Token.TokenType) As Boolean
        If current.isType(type) Then
            previous = current
            tokens.RemoveFirst()
            current = tokens.ElementAtOrDefault(0)
            Return True
        Else
            'Throw exception dialog box
            Return False
        End If
    End Function

    Public Function Parse() As ParseNode
        'Driver method that will call all recursive descent methods
        Return Program()
    End Function

    Public Function Program() As ParseNode
        result = New ParseNode()
        If Consume(Token.TokenType.Begin) Then
            result.AddChild(StatementSeries())
            If Not Consume(Token.TokenType.Done) Then
                'Throw exception
            End If
        End If
        Return result
    End Function

    Public Function StatementSeries() As ParseNode
        'Do later
        Return Nothing
    End Function

    Public Function ForLoop() As ParseNode
        Dim currNode As New Nonterminal(Nonterminal.NonterminalType.ForLoop)
        If Consume(Token.TokenType.ForBegin) Then
            If Consume(Token.TokenType.Int) Then
                currNode.AddChild(previous)
                If Consume(Token.TokenType.Dots) Then
                    If Consume(Token.TokenType.Int) Then
                        currNode.AddChild(previous)
                        If Consume(Token.TokenType.ForLoop) Then
                            If Consume(Token.TokenType.Colon) Then
                                currNode.AddChild(StatementSeries())
                                If Consume(Token.TokenType.EndFor) Then
                                    If Consume(Token.TokenType.Semi) Then
                                        Return currNode
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return currNode
    End Function

    Public Function Park() As ParseNode
        Dim currNode As New Nonterminal(Nonterminal.NonterminalType.Park)
        If Consume(Token.TokenType.Park) Then
            If Consume(Token.TokenType.Semi) Then
                Return currNode
            End If
        End If
        Return currNode
    End Function

    Public Function Slew() As ParseNode
        Dim currNode As New Nonterminal(Nonterminal.NonterminalType.Slew)
        If Consume(Token.TokenType.Slew) Then
            If Consume(Token.TokenType.SlewTo) Then
                If Consume(Token.TokenType.LParen) Then
                    If Consume(Token.TokenType.Float) Then
                        currNode.AddChild(previous)
                        If Consume(Token.TokenType.Comma) Then
                            If Consume(Token.TokenType.Float) Then
                                currNode.AddChild(previous)
                                If Consume(Token.TokenType.RParen) Then
                                    If Consume(Token.TokenType.Semi) Then
                                        Return currNode
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return currNode
    End Function

    Public Function Record() As ParseNode
        Dim currNode As New Nonterminal(Nonterminal.NonterminalType.Record)
        If Consume(Token.TokenType.Record) Then
            If Consume(Token.TokenType.Semi) Then
                currNode.AddChild(StatementSeries())
                If Consume(Token.TokenType.StopRecord) Then
                    If Consume(Token.TokenType.Semi) Then
                        Return currNode
                    End If
                End If
            End If
        End If
        Return currNode
    End Function

End Class
