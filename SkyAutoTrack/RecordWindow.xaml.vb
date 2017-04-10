Imports System.IO
Imports System
Imports System.Text
Imports System.Windows.Threading

Public Class RecordWindow
    ' TODO Migrate data recording code

    Dim timer As System.Windows.Threading.DispatcherTimer
    Dim strLine As String
    Dim fso As New Scripting.FileSystemObject
    Dim fsoStream As Scripting.TextStream
    Dim recording As Boolean = False
    Dim todaysDate As String = Today.ToString().Replace(" ", "_").Replace(":", "_").Replace("/", "_")
    Dim fileString As String = "data_" + todaysDate
    Dim fileName As String = Path.Combine(Environment.CurrentDirectory, fileString) + ".csv"
    Dim objTelescope As ASCOM.DriverAccess.Telescope

    Public Sub New(objTelescope As ASCOM.DriverAccess.Telescope)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.objTelescope = objTelescope
    End Sub

    Private Sub RecordWindow_Load(sender As Object, e As RoutedEventArgs)
        Dim fs As FileStream = File.Create(fileName)
        fs.Close()
        fsoStream = fso.CreateTextFile(fileName)
        strLine = "Time, RA, DEC"
        fsoStream.WriteLine(strLine)
        DataBox.AppendText(strLine + vbNewLine)
        timer = New DispatcherTimer()
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Interval = TimeSpan.FromSeconds(1)
        timer.Start()
    End Sub

    Private Sub RecordStart_Click(sender As Object, e As RoutedEventArgs)
        recording = True
    End Sub

    Public Sub Record_Start_Stop()
        recording = Not recording
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        If recording Then
            strLine = System.DateTime.Now().ToString() + "," + objTelescope.RightAscension.ToString() + "," + objTelescope.Declination.ToString()
            fsoStream.WriteLine(strLine)
            DataBox.AppendText(strLine + vbNewLine)
        End If
    End Sub

    Private Sub RecordReset_Click(sender As Object, e As RoutedEventArgs)
        recording = False
        fsoStream.Close()
    End Sub

    Private Sub RecordSave_Click(sender As Object, e As RoutedEventArgs)
        Dim dialog As New Microsoft.Win32.SaveFileDialog
        If dialog.ShowDialog() Then
            fileName = dialog.FileName
            File.WriteAllText(fileName, DataBox.Text)
        End If
    End Sub

    Private Sub RecordWindow_Closing()

    End Sub
End Class