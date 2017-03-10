Public Class Macro

    Dim currentFileName As String
    Dim lexer As New MacroScanner()

    Public Sub setCurrentFile(fileName As String)
        currentFileName = fileName
    End Sub

    Private Sub RunMacroButton_Click(sender As Object, e As EventArgs) Handles RunMacroButton.Click
        'MacroText.Text = currentFileName
        Dim tokens As LinkedList(Of Token) = lexer.scan(MacroText.Text)
        Dim parser As New MacroParser(tokens)
    End Sub

    Private Sub OpenMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenMacroToolStripMenuItem.Click

    End Sub

    Private Sub SaveMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveMacroToolStripMenuItem.Click
        My.Computer.FileSystem.WriteAllText(currentFileName, MacroText.Text, False)
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub
End Class