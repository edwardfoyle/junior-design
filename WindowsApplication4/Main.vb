Option Explicit On
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Web
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Main

    Public objTelescope As ASCOM.DriverAccess.Telescope
    Private snapshotName As String = "snapshot.jpg" ' DO NOT CHANGE
    Private defaultImage As String = "starsTest.jpg" ' DO NOT CHANGE
    Private useDefaultImage As Boolean = True
    Private noviceMode As Boolean = True
    Private clicked As Boolean = False
    Private video As New VideoFeed
    Private api As New APIManager
    Public mySettings As New UserSettings

    'Opens the ASCOM Chooser
    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        Dim obj As New ASCOM.Utilities.Chooser
        obj.DeviceType = "Telescope"
        My.Settings.Telescope = obj.Choose(My.Settings.Telescope)
    End Sub

    'This method is called on starting the application
    'It is meant for initializing anything in the main application view
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        video.LoadDeviceList(Me.VideoDeviceToolStripMenuItem)
        If File.Exists("SavedSettings.bin") Then
            Dim myFileStream As Stream = File.OpenRead("SavedSettings.bin")
            Dim deserializer As New BinaryFormatter()
            mySettings = CType(deserializer.Deserialize(myFileStream), UserSettings)
            myFileStream.Close()
            If mySettings.mode Then
                NoviceToolStripMenuItem.Checked = True
                AdvancedToolStripMenuItem.Checked = False
                switchMode(noviceCamPos)
            End If
        End If
    End Sub

    'Handles management of persistent object when form closes
    Private Sub Form1_Close(send As Object, e As EventArgs) Handles MyBase.Closing
        mySettings.mode = NoviceToolStripMenuItem.Checked
        Dim myFileStream As Stream = File.Create("SavedSettings.bin")
        Dim serializer As New BinaryFormatter()
        serializer.Serialize(myFileStream, mySettings)
        myFileStream.Close()
    End Sub

    'Connects to the selected telescope from the ASCOM Chooser
    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        objTelescope = New ASCOM.DriverAccess.Telescope(My.Settings.Telescope)
        objTelescope.Connected = True
        UserSettingsToolStripMenuItem.Enabled = True
        queryAPI.Enabled = True
        btnAlign.Enabled = True
        RecordDataToolStripMenuItem.Enabled = True
        LocationToolStripMenuItem.Enabled = True
        If Not mySettings Is Nothing Then
            objTelescope.RightAscensionRate = mySettings.raRate
            objTelescope.DeclinationRate = mySettings.decRate
        End If
    End Sub

    'Moves the telescope to the coordinates entered into the RA and Dec text boxes 
    Private Sub SlewBtn_Click(sender As Object, e As EventArgs) Handles SlewBtn.Click
        If (objTelescope IsNot Nothing) Then
            objTelescope.Tracking = True
            objTelescope.SlewToCoordinates(Convert.ToDouble(My.Settings.RA) / 15, Convert.ToDouble(My.Settings.Dec))
        End If
    End Sub

    'When the align button is clicked, this method takes a picture of the current view and queries the API
    Private Sub btnAlign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlign.Click
        video.TakePicture(snapshotName, Me.picCapture)
        queryAPI_Click(Nothing, Nothing)
    End Sub

    'Connects to the selected video device and displays a preview screen
    Private Sub connect_Click(sender As Object, e As EventArgs)
        If Not clicked Then
            video.OpenPreviewWindow(Me.picCapture)
            clicked = True
        Else
            video.ClosePreviewWindow()
            clicked = False
        End If
    End Sub

    'Submits API query
    Private Sub queryAPI_Click(sender As Object, e As EventArgs) Handles queryAPI.Click
        queryResults.Text = "Solving Image..."
        api.Query(Me, useDefaultImage, snapshotName, defaultImage)
    End Sub

    'Updates telescope coordinates by slewing to selected coordinates
    Public Sub setRaDecRes(ra As Double, dec As Double, raw As String)
        Me.BeginInvoke(Sub() Me.TextRA.Text = CStr(ra))
        Me.BeginInvoke(Sub() Me.TextDec.Text = CStr(dec))
        Me.BeginInvoke(Sub() Me.queryResults.Text = raw)
        If NoviceToolStripMenuItem.Checked Then
            Me.BeginInvoke(Sub() Me.SlewBtn_Click(Nothing, Nothing))
        End If
    End Sub

    'Opens dialog for altering longitude and latitude
    Private Sub LocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocationToolStripMenuItem.Click
        Dim dialog As New LatLong(Me)
        dialog.Show()
    End Sub

    'Opens display for selected video device
    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        If Not clicked Then
            video.OpenPreviewWindow(Me.picCapture)
            clicked = True
        Else
            video.ClosePreviewWindow()
            clicked = False
        End If
    End Sub

    'Changes UI to novice mode
    Private Sub NoviceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoviceToolStripMenuItem.Click
        If NoviceToolStripMenuItem.Checked Then
            NoviceToolStripMenuItem.Checked = False
            AdvancedToolStripMenuItem.Checked = True
        Else
            NoviceToolStripMenuItem.Checked = True
            AdvancedToolStripMenuItem.Checked = False
            switchMode(noviceCamPos)
        End If
    End Sub

    Public noviceCamPos As New Point(225, 47)
    Public advancedCamPos As New Point(425, 47)

    'Helper method to switch between novice and advanced mode
    Public Sub switchMode(camPos As Point)
        queryResults.Visible = Not queryResults.Visible
        queryAPI.Visible = Not queryAPI.Visible
        Label2.Visible = Not Label2.Visible
        TextRA.Visible = Not TextRA.Visible
        TextDec.Visible = Not TextDec.Visible
        Label3.Visible = Not Label3.Visible
        Label4.Visible = Not Label4.Visible
        SlewBtn.Visible = Not SlewBtn.Visible
        picCapture.Location = camPos
        btnAlign.Location = New Point(camPos.X + 0.25 * picCapture.Size.Width, camPos.Y + 315)
    End Sub

    'Changes UI to advanced mode
    Private Sub AdvancedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvancedToolStripMenuItem.Click
        If AdvancedToolStripMenuItem.Checked Then
            NoviceToolStripMenuItem.Checked = True
            AdvancedToolStripMenuItem.Checked = False
        Else
            NoviceToolStripMenuItem.Checked = False
            AdvancedToolStripMenuItem.Checked = True
            switchMode(advancedCamPos)
        End If
    End Sub

    'Opens dialog box for recording data
    Private Sub RecordDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordDataToolStripMenuItem.Click
        Dim record As New Record
        record.Show()
    End Sub

    'Opens dialog box for writing/running new macro
    Private Sub NewMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewMacroToolStripMenuItem.Click
        Dim macro As New Macro
        macro.Show()
    End Sub

    'Opens dialog bix for editing/running previously written macros
    Private Sub OpenMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenMacroToolStripMenuItem.Click
        Dim result As DialogResult = MacroFileDialog.ShowDialog()

        Dim macro As New Macro

        If result = Windows.Forms.DialogResult.OK Then

            ' Get the file name.
            Dim path As String = MacroFileDialog.FileName
            Try
                ' Read in text. 
                Dim text As String = File.ReadAllText(path)
                macro.MacroText.Text = text
                macro.setCurrentFile(path)
                macro.Show()
                ' For debugging.


            Catch ex As Exception

                ' Report an error.
                Me.Text = "Error"

            End Try
        End If

    End Sub

    Private Sub UserSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserSettingsToolStripMenuItem.Click
        Dim settingsForm As New SettingsForm(Me, mySettings)
        settingsForm.Show()
    End Sub
End Class
