﻿Public Class MacroScanner

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
                Case ","
                    newToken = New Token(Token.TokenType.Comma, ",")
                    tokens.AddLast(newToken)
                Case "("
                    newToken = New Token(Token.TokenType.LParen, "(")
                    tokens.AddLast(newToken)
                Case ")"
                    newToken = New Token(Token.TokenType.RParen, ")")
                    tokens.AddLast(newToken)
                Case " "
                Case vbCr
                Case vbTab
                Case vbCrLf
                Case vbLf
                Case Else
                    currToken = currToken + curr
                    Select Case currToken
                        Case "Park"
                            newToken = New Token(Token.TokenType.Park, "park")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "Slew"
                            newToken = New Token(Token.TokenType.Slew, "slew")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "Record"
                            newToken = New Token(Token.TokenType.Record, "record")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "Stop"
                            newToken = New Token(Token.TokenType.StopRecord, "stop")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "Begin"
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
                        Case "Done"
                            newToken = New Token(Token.TokenType.Done, "done")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "to"
                            newToken = New Token(Token.TokenType.SlewTo, "to")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "..."
                            newToken = New Token(Token.TokenType.Dots, "...")
                            tokens.AddLast(newToken)
                            currToken = ""
                        Case "End"
                            newToken = New Token(Token.TokenType.EndFor, "end")
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

