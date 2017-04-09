Imports System.IO
Imports System
Imports System.Text

Public Class RecordWindow
    ' TODO Migrate data recording code

    Private Sub RecordStart_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub RecordReset_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub RecordSave_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub RecordWindow_Closing()

    End Sub
End Class

'Dim strLine As String
'Dim fso As New Scripting.FileSystemObject
'Dim fsoStream As Scripting.TextStream
'Dim recording As Boolean = False
'Dim todaysDate As String = Today.ToString().Replace(" ", "_").Replace(":", "_").Replace("/", "_")
'Dim fileString As String = "data_" + todaysDate
'Dim fileName As String = Path.Combine(Environment.CurrentDirectory, fileString) + ".csv"

'Private Sub RecordBtn_Click(sender As Object, e As EventArgs) Handles recordBtn.Click
'    recording = True
'End Sub

'Private Sub Record_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'    Dim fs As FileStream = File.Create(fileName)
'    fs.Close()
'    fsoStream = fso.CreateTextFile(fileName)
'    strLine = "Time, RA, DEC"
'    fsoStream.WriteLine(strLine)
'    currData.AppendText(strLine + vbNewLine)
'End Sub

'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
'    If recording Then
'        strLine = System.DateTime.Now().ToString() + "," + Main.objTelescope.RightAscension.ToString() + "," + Main.objTelescope.Declination.ToString()
'        fsoStream.WriteLine(strLine)
'        currData.AppendText(strLine + vbNewLine)
'    End If
'End Sub

'Private Sub StopBtn_Click(sender As Object, e As EventArgs) Handles stopBtn.Click
'    recording = False
'    fsoStream.Close()
'End Sub