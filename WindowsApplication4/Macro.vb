Imports System.IO.Stream

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
        OpenFileDialog1.ShowDialog()
        setCurrentFile(OpenFileDialog1.FileName)
        MacroText.Text = My.Computer.FileSystem.ReadAllText(currentFileName)
    End Sub

    Private Sub SaveMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveMacroToolStripMenuItem.Click
        If currentFileName Is Nothing Then
            SaveFileDialog1.ShowDialog()
            setCurrentFile(SaveFileDialog1.FileName)
        End If
        My.Computer.FileSystem.WriteAllText(currentFileName, MacroText.Text, False)
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub NewMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewMacroToolStripMenuItem.Click
        Dim nextMarco As New Macro
        nextMarco.Show()
    End Sub
End Class