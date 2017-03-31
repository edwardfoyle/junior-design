Option Explicit On
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Web
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Runtime.Serialization.Formatters.Binary
Imports WebEye.Controls.Wpf
Imports System.Windows
Imports System.Windows.Controls
Imports System.Drawing
Imports System.ComponentModel


Public Class MainWindow

    Public objTelescope As ASCOM.DriverAccess.Telescope
    Private snapshotName As String = "snapshot.jpg" ' DO NOT CHANGE
    Private defaultImage As String = "starsTest.jpg" ' DO NOT CHANGE
    Private useDefaultImage As Boolean = True
    Private noviceMode As Boolean = True
    Private clicked As Boolean = False
    Private api As New ApiManager

    'Private api As New APIManager
    'Public mySettings As New UserSettings

    Public Sub selectScope_Choose_Click(sender As Object, e As RoutedEventArgs)
        Dim obj As New ASCOM.Utilities.Chooser
        My.Settings.Telescope = obj.Choose(My.Settings.Telescope)
    End Sub

    Private Sub selectScope_Connect_Click(sender As Object, e As RoutedEventArgs)
        objTelescope = New ASCOM.DriverAccess.Telescope(My.Settings.Telescope)
        objTelescope.Connected = True
        autoAlign_Button.IsEnabled = True
        slew_Button.IsEnabled = True
        'RecordDataToolStripMenuItem.Enabled = True
        'LocationToolStripMenuItem.Enabled = True
    End Sub

    Private Sub slew_Button_Click(sender As Object, e As RoutedEventArgs)
        If (objTelescope IsNot Nothing) Then
            objTelescope.Tracking = True
            Dim thread As New System.Threading.Thread(Sub() objTelescope.SlewToCoordinates(Convert.ToDouble(My.Settings.RA) / 15, Convert.ToDouble(My.Settings.Dec)))
            thread.Start()
        End If
    End Sub

    Private Sub comboBox_Initialized(sender As Object, e As EventArgs)
        comboBox.ItemsSource = camControl.GetVideoCaptureDevices()
    End Sub

    Private Sub selectCam_Connect_Click(sender As Object, e As RoutedEventArgs)
        If selectCam_Connect.Content.Equals("Connect") Then
            camControl.StartCapture(CType(comboBox.SelectedItem, WebCameraId))
            selectCam_Connect.Content = "Disconnect"
        Else
            camControl.StopCapture()
            selectCam_Connect.Content = "Connect"
        End If

    End Sub

    Private Sub autoAlign_Button_Click(sender As Object, e As RoutedEventArgs)
        camControl.GetCurrentImage().Save(snapshotName)
        autoAlign_Button.Content = "Aligning Telescope..."
        api.Query(Me, useDefaultImage, snapshotName, defaultImage)
    End Sub

    Public Sub setRA_Dec_QueryResult(ra As Double, dec As Double)
        Dispatcher.BeginInvoke(Sub() Me.ra_Text.Text = CStr(ra))
        Dispatcher.BeginInvoke(Sub() Me.dec_Text.Text = CStr(dec))
        Dispatcher.BeginInvoke(Sub() Me.autoAlign_Button.Content = "Automatically Align Telescope")
    End Sub

    Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
        My.Settings.Save()
    End Sub
End Class
