﻿Public Class Macro

    Dim currentFileName As String

    Public Sub setCurrentFile(fileName As String)
        currentFileName = fileName
    End Sub

    Private Sub RunMacroButton_Click(sender As Object, e As EventArgs) Handles RunMacroButton.Click
        MacroText.Text = currentFileName
    End Sub

    Private Sub OpenMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenMacroToolStripMenuItem.Click

    End Sub

    Private Sub SaveMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveMacroToolStripMenuItem.Click
        My.Computer.FileSystem.WriteAllText(currentFileName, MacroText.Text, False)
    End Sub
End Class