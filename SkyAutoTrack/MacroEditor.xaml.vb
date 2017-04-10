Public Class MacroEditor

    Dim currentFileName As String
    Dim lexer As New MacroScanner()
    Public objTelescope As ASCOM.DriverAccess.Telescope

    Public Sub New(objTelescope As ASCOM.DriverAccess.Telescope)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.objTelescope = objTelescope
    End Sub
    Private Sub NewMacroMenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim nextMarco = New MacroEditor(objTelescope)
        nextMarco.Show()
    End Sub

    Private Sub OpenMacroMenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim fileDialog = New Microsoft.Win32.OpenFileDialog()
        fileDialog.ShowDialog()
        setCurrentFile(fileDialog.FileName, True)
    End Sub

    Private Sub HelpMenuItem_Click(sender As Object, e As RoutedEventArgs)
        ' open PDF documentation here
    End Sub

    Public Sub setCurrentFile(fileName As String, read As Boolean)
        currentFileName = fileName
        If read Then
            MacroText.Text = My.Computer.FileSystem.ReadAllText(currentFileName)
        Else
            My.Computer.FileSystem.WriteAllText(currentFileName, MacroText.Text, False)
        End If
    End Sub

    Private Sub RunMacroButton_Click(sender As Object, e As EventArgs)
        'MacroText.Text = currentFileName
        If objTelescope IsNot Nothing Then
            Dim tokens As LinkedList(Of Token) = lexer.scan(MacroText.Text)
            Dim parser As New MacroParser(Me, tokens)
            parser.Parse()
        Else
            MacroStatus.Text = "No telescope detected"
        End If
    End Sub

    Public Sub RunMacro()
        If objTelescope IsNot Nothing Then
            Dim tokens As LinkedList(Of Token) = lexer.scan(MacroText.Text)
            Dim parser As New MacroParser(Me, tokens)
            parser.Parse()
        Else
            MacroStatus.Text = "No telescope detected"
        End If
    End Sub



    Private Sub SaveButton_Click(sender As Object, e As RoutedEventArgs)
        If currentFileName Is Nothing Then
            Dim fileDialog = New Microsoft.Win32.SaveFileDialog()
            fileDialog.ShowDialog()
            setCurrentFile(fileDialog.FileName, False)
        End If
        setCurrentFile(currentFileName, False)
    End Sub

    Private Sub MacroText_TextChanged(sender As Object, e As TextChangedEventArgs) Handles MacroText.TextChanged
        MacroStatus.Text = "OK"
    End Sub
End Class
