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

    Private Sub RecordMenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim recordWindow = New RecordWindow(objTelescope)
        recordWindow.Show()
    End Sub

    Private Sub NewMacroMenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim macroEditor = New MacroEditor(objTelescope)
        macroEditor.Show()
    End Sub

    Private Sub OpenMacroMenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim openFileDialog As New Microsoft.Win32.OpenFileDialog
        Dim filename As String
        If openFileDialog.ShowDialog() Then
            filename = openFileDialog.FileName
            Dim macro As New MacroEditor(objTelescope)
            macro.setCurrentFile(filename, True)
            macro.Show()
        End If
    End Sub

    Private Sub RunMacroMenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim openFileDialog As New Microsoft.Win32.OpenFileDialog
        Dim filename As String
        If openFileDialog.ShowDialog() Then
            filename = openFileDialog.FileName
            Dim macro As New MacroEditor(objTelescope)
            macro.setCurrentFile(filename, True)
            macro.Show()
            macro.RunMacro()
        End If
    End Sub

    Private Sub searchResults_List_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles searchResults_List.SelectionChanged

    End Sub

    Private Sub search_Button_Click(sender As Object, e As RoutedEventArgs)
        Dim searchTerms As String = search_Text.Text
        If searchTerms.Length = 0 Or searchTerms = "Search Terms" Then
            Return
        End If
        ' wikisky.org API
        ' use http://server2.sky-map.org/getstars.jsp?ra=12&de=45&angle=30&max_stars=3&max_vmag=8 to query region of the sky
        ' cone search params: ra, de, angle, max_stars, max_vmag
        Dim ANGLE = "30"
        Dim MAX_STARS = "20"
        Dim MAX_VMAG = "8"
        Dim CONE_SEARCH_URL = "http://server2.sky-map.org/getstars.jsp?"
        Dim API_URL As String = "http://server1.sky-map.org/search?star="
        Dim query As String = WebUtility.HtmlEncode(API_URL + searchTerms)
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(query)
        Dim obj = XDocument.Parse(result)
        Dim err = obj.Element("response").Element("status")
        If err.Value = 0 Then
            Dim star = obj.Element("response").Element("object")
            Dim ra As String = star.Element("ra")
            Dim dec As String = star.Element("de")
            Dim name As String = star.Element("name").Value.ToString
            searchResults_List.Items.Clear()
            searchResults_List.Items.Add(New With {Key .Name = name, .RA = ra, .Dec = dec})
            query = CONE_SEARCH_URL + "ra=" + ra.ToString + "&de=" + dec.ToString + "&angle=" + ANGLE + "&max_stars=" + MAX_STARS + "&max_vmag=" + MAX_VMAG
            result = webClient.DownloadString(query)
            obj = XDocument.Parse(result)
            Try
                For Each item As XElement In obj.Descendants("star")
                    ra = item.Element("ra")
                    dec = item.Element("de")
                    name = item.Element("catId")
                    searchResults_List.Items.Add(New With {Key .Name = name, .RA = ra, .Dec = dec})
                Next item
            Catch ex As Exception
                ' couldn't load anymore results
            End Try
            err = obj.Element("response").Element("status")

            ' iterate through result
        Else
            searchResults_List.Items.Clear()
        End If
    End Sub

    Private Sub searchResults_List_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs)
        Dim selected = searchResults_List.SelectedItem
        ra_Text.Text = selected.RA
        dec_Text.Text = selected.Dec
    End Sub
End Class

Public Class ListItem
    Public Name As String
    Public RA As String
    Public Dec As String

    Public Sub New(ByVal new_name As String, ByVal new_ra As String, ByVal new_dec As String)
        Name = new_name
        RA = new_ra
        Dec = new_dec
    End Sub
End Class
