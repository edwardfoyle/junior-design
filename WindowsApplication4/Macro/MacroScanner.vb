Public Class MacroScanner

    Dim tokens As New LinkedList(Of Token)


    Public Function scan(buffer As String) As LinkedList(Of Token)

        Dim currToken As String = ""

        'Loop through input string
        For index As Integer = 0 To Len(buffer) - 1
            Dim curr As Char = buffer.ElementAt(index)
            Dim lookAhead As Char
            If index + 1 < Len(buffer) Then
                lookAhead = buffer.ElementAt(index + 1)
            Else
                lookAhead = " "
            End If

            'Switch statement for lexing
            Dim newToken As Token
            Select Case curr
                Case ";"
                    newToken = New Token(Token.TokenType.Semi, ";")
                    tokens.AddLast(newToken)
                Case ":"
                    newToken = New Token(Token.TokenType.Colon, ":")
                    tokens.AddLast(newToken)
                Case " "
                Case Else
                    currToken = currToken + curr
                    Select Case currToken
                        Case "park"
                            newToken = New Token(Token.TokenType.Park, "park")
                            tokens.AddLast(newToken)
                        Case "slew"
                            newToken = New Token(Token.TokenType.Slew, "slew")
                            tokens.AddLast(newToken)
                        Case "record"
                            newToken = New Token(Token.TokenType.Record, "record")
                            tokens.AddLast(newToken)
                        Case "stop"
                            newToken = New Token(Token.TokenType.StopRecord, "stop")
                            tokens.AddLast(newToken)
                        Case "begin"
                            newToken = New Token(Token.TokenType.Begin, "begin")
                            tokens.AddLast(newToken)
                        Case "for"
                            newToken = New Token(Token.TokenType.ForBegin, "for")
                            tokens.AddLast(newToken)
                        Case "loop"
                            newToken = New Token(Token.TokenType.ForLoop, "loop")
                            tokens.AddLast(newToken)
                    End Select
            End Select
        Next
        Return tokens
    End Function

End Class
