Option Explicit On
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Web
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Main

    Public objTelescope As ASCOM.DriverAccess.Telescope
    Private snapshotName As String = "snapshot.jpg" ' DO NOT CHANGE
    Private defaultImage As String = "starsTest.jpg" ' DO NOT CHANGE
    Private useDefaultImage As Boolean = True
    Private noviceMode As Boolean = True
    Private clicked As Boolean = False
    Private video As New VideoFeed
    Private api As New APIManager

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
    End Sub

    'Connects to the selected telescope from the ASCOM Chooser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        objTelescope = New ASCOM.DriverAccess.Telescope(My.Settings.Telescope)
        objTelescope.Connected = True

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

    Private Sub connect_Click(sender As Object, e As EventArgs)
        If Not clicked Then
            video.OpenPreviewWindow(Me.picCapture)
            clicked = True
        Else
            video.ClosePreviewWindow()
            clicked = False
        End If
    End Sub


    Private Sub queryAPI_Click(sender As Object, e As EventArgs) Handles queryAPI.Click
        queryResults.Text = "Solving Image..."
        api.Query(Me, useDefaultImage, snapshotName, defaultImage)
    End Sub

    Public Sub setRaDecRes(ra As Double, dec As Double, raw As String)
        Me.BeginInvoke(Sub() Me.TextRA.Text = CStr(ra))
        Me.BeginInvoke(Sub() Me.TextDec.Text = CStr(dec))
        Me.BeginInvoke(Sub() Me.queryResults.Text = raw)
        If NoviceToolStripMenuItem.Checked Then
            Me.BeginInvoke(Sub() Me.SlewBtn_Click(Nothing, Nothing))
        End If
    End Sub

    Private Sub LocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocationToolStripMenuItem.Click
        Dim dialog As New Form2
        dialog.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        If Not clicked Then
            video.OpenPreviewWindow(Me.picCapture)
            clicked = True
        Else
            video.ClosePreviewWindow()
            clicked = False
        End If
    End Sub

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

    Dim noviceCamPos As New Point(225, 47)
    Dim advancedCamPos As New Point(425, 47)

    Private Sub switchMode(camPos As Point)
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

    Private Sub RecordDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordDataToolStripMenuItem.Click
        Dim record As New Record
        record.Show()
    End Sub

    Private Sub NewMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewMacroToolStripMenuItem.Click
        Dim macro As New Macro
        macro.Show()
    End Sub

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
End Class
