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
                Case vbCr
                Case vbTab
                Case vbCrLf
                Case vbLf
                Case Else
                    currToken = currToken + curr
                    Select Case currToken
                        Case "park"
                            newToken = New Token(Token.TokenType.Park, "park")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "slew"
                            newToken = New Token(Token.TokenType.Slew, "slew")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "record"
                            newToken = New Token(Token.TokenType.Record, "record")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "stop"
                            newToken = New Token(Token.TokenType.StopRecord, "stop")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "begin"
                            newToken = New Token(Token.TokenType.Begin, "begin")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "for"
                            newToken = New Token(Token.TokenType.ForBegin, "for")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "loop"
                            newToken = New Token(Token.TokenType.ForLoop, "loop")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case Else
                            If IsNumeric(currToken) And Not IsNumeric(lookAhead) Then
                                If lookAhead <> "." Then
                                    If currToken.Contains(".") Then
                                        newToken = New Token(Token.TokenType.Float, currToken)
                                        currToken = ""
                                    Else
                                        newToken = New Token(Token.TokenType.Int, currToken)
                                        currToken = ""
                                    End If
                                    tokens.AddLast(newToken)
                                End If
                            End If
                    End Select
            End Select
        Next
        Return tokens
    End Function

End Class
