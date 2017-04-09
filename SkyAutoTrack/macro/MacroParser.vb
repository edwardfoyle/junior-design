Public Class MacroParser
    Dim window As MacroEditor
    Dim tokens As LinkedList(Of Token)
    Dim current As Token
    Dim previous As Token

    Public Sub New(window As MacroEditor, tokens As LinkedList(Of Token))
        Me.window = window
        Me.tokens = tokens
        current = tokens.ElementAtOrDefault(0)
    End Sub

    Public Function Consume(type As Token.TokenType) As String
        If current IsNot Nothing And current.isType(type) Then
            previous = current
            tokens.RemoveFirst()
            current = tokens.ElementAtOrDefault(0)
            Return previous.ToString()
        Else
            Throw New Exception
            Return ""
        End If
    End Function

    Public Sub Parse()
        'Driver method that will call all recursive descent methods
        window.MacroStatus.Text = "Running macro ... "
        Try
            Program()
            window.MacroStatus.Text = "Done!"
        Catch e As Exception
            'Do exception handling
            window.MacroStatus.Text = "Unable to parse macro"
        End Try
    End Sub

    Public Sub Program()
        If current IsNot Nothing Then
            Consume(Token.TokenType.Begin)
            Statement_Series()
            Consume(Token.TokenType.Done)
        Else
            Throw New Exception
        End If
    End Sub

    Public Sub Statement_Series()
        Statement()
        If current IsNot Nothing Then
            If Not (current.isType(Token.TokenType.StopRecord) Or current.isType(Token.TokenType.EndFor) Or current.isType(Token.TokenType.Done)) Then
                Statement_Series()
            End If
        End If
    End Sub

    Public Sub Statement()
        If current IsNot Nothing Then
            If current.isType(Token.TokenType.ForBegin) Then
                ForLoop()
            ElseIf current.isType(Token.TokenType.Park) Then
                Park()
            ElseIf current.isType(Token.TokenType.Slew) Then
                Slew()
            ElseIf current.isType(Token.TokenType.Record) Then
                Record()
            Else
                window.MacroStatus.Text = "No statement found"
                Throw New Exception
            End If
        Else
            Throw New Exception
        End If
    End Sub

    Public Sub ForLoop()
        If current IsNot Nothing Then
            Consume(Token.TokenType.ForBegin)
            Dim beginFor As Integer = Convert.ToInt32(Consume(Token.TokenType.Int))
            Consume(Token.TokenType.Dots)
            Dim endFor As Integer = Convert.ToInt32(Consume(Token.TokenType.Int))
            Consume(Token.TokenType.ForLoop)
            Consume(Token.TokenType.Colon)
            Statement_Series()
            Consume(Token.TokenType.EndFor)
            Consume(Token.TokenType.Semi)
        Else
            Throw New Exception
        End If
    End Sub

    Public Sub Park()
        If current IsNot Nothing Then
            Consume(Token.TokenType.Park)
            Consume(Token.TokenType.Semi)
        Else
            Throw New Exception
        End If
    End Sub

    Public Sub Slew()
        If current IsNot Nothing Then
            Consume(Token.TokenType.Slew)
            Consume(Token.TokenType.SlewTo)
            Consume(Token.TokenType.LParen)
            Dim firstCoor As Double = Convert.ToDouble(Consume(Token.TokenType.Float))
            Consume(Token.TokenType.Comma)
            Dim secondCoor As Double = Convert.ToDouble(Consume(Token.TokenType.Float))
            Consume(Token.TokenType.RParen)
            Consume(Token.TokenType.Semi)
            window.objTelescope.SlewToCoordinates(firstCoor, secondCoor)
        Else
            Throw New Exception
        End If
    End Sub

    Public Sub Record()
        If current IsNot Nothing Then
            Consume(Token.TokenType.Record)
            Consume(Token.TokenType.Semi)
            Statement_Series()
            Consume(Token.TokenType.StopRecord)
            Consume(Token.TokenType.Semi)
        Else
            Throw New Exception
        End If
    End Sub

End Class
