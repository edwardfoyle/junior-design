Option Explicit On
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Web
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1

    Private objTelescope As ASCOM.DriverAccess.Telescope
    Private snapshotName As String = "snapshot.jpg" ' DO NOT CHANGE
    Private defaultImage As String = "starsTest.jpg" ' DO NOT CHANGE
    Private useDefaultImage As Boolean = True

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        Dim obj As New ASCOM.Utilities.Chooser
        obj.DeviceType = "Telescope"
        My.Settings.Telescope = obj.Choose(My.Settings.Telescope)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDeviceList()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        objTelescope = New ASCOM.DriverAccess.Telescope(My.Settings.Telescope)
        objTelescope.Connected = True

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    'Dim capturez As Capture = New Capture

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Dim imagez As Image(Of Bgr, Byte) = capturez.QueryFrame().ToImage(Of Bgr, Byte)
        'PictureBox1.Image = imagez.ToBitmap()
    End Sub

    Private Sub SlewBtn_Click(sender As Object, e As EventArgs) Handles SlewBtn.Click
        If (objTelescope IsNot Nothing) Then
            objTelescope.Tracking = True
            objTelescope.SlewToCoordinates(Convert.ToDouble(My.Settings.RA), Convert.ToDouble(My.Settings.Dec))
        End If
    End Sub

    'TEST STUFF

    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1
    Dim iDevice As Integer = 0
    Dim hHwnd As Integer
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Object) As Integer
    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean
    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean

    Private Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0
        Do
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            If bReturn Then
                Dim menuitem As New ToolStripMenuItem()
                menuitem.Text = strName.Trim
                VideoDeviceToolStripMenuItem.DropDownItems.Add(menuitem)
                menuitem.CheckOnClick = True
            End If
            x += 1
        Loop Until bReturn = False
    End Sub

    Private Sub OpenPreviewWindow()
        Dim iHeight As Integer = picCapture.Height
        Dim iWidth As Integer = picCapture.Width
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, picCapture.Handle.ToInt32, 0)
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height, SWP_NOMOVE Or SWP_NOZORDER)
        Else
            DestroyWindow(hHwnd)
        End If
    End Sub

    Private Sub btnAlign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlign.Click
        Dim data As IDataObject
        Dim bmap As Image
        Using loWindow As New System.Windows.Forms.Form
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
            data = Clipboard.GetDataObject()
            Dim OutputPath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim lsFilename As String = Path.Combine(OutputPath, snapshotName)
            If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
                bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
                picCapture.Image = bmap
                bmap.Save(lsFilename, Imaging.ImageFormat.Jpeg)
            End If
        End Using
    End Sub

    Private Sub ClosePreviewWindow()
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)
        DestroyWindow(hHwnd)
    End Sub

    Dim clicked As Boolean = False

    Private Sub connect_Click(sender As Object, e As EventArgs)
        If Not clicked Then
            OpenPreviewWindow()
            clicked = True
        Else
            ClosePreviewWindow()
            clicked = False
        End If
    End Sub

    Private Sub DeviceList_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub queryAPI_Click(sender As Object, e As EventArgs) Handles queryAPI.Click
        Dim thread As New System.Threading.Thread(Sub() asyncQuery(Me))
        thread.Start()
    End Sub

    Private Sub asyncQuery(Form1 As Form1)
        Dim proc As New Process()
        ' TODO: change this to a dynamic path at some point
        proc.StartInfo.FileName = "C:\Python27\python.exe"
        Dim pyPath As String = Path.Combine(Environment.CurrentDirectory, "client25.py")
        Dim imPath As String
        If useDefaultImage Then
            imPath = Path.Combine(Environment.CurrentDirectory, defaultImage)
        Else
            imPath = Path.Combine(Environment.CurrentDirectory, snapshotName)
        End If
        proc.StartInfo.Arguments = """" + pyPath + """" + " -k ahhxdcgzhkqyxwas -u " + """" + imPath + """" + " -w"
        proc.StartInfo.CreateNoWindow = False
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.Start()
        Dim stdout As String
        Using outStreamReader As StreamReader = proc.StandardOutput
            stdout = outStreamReader.ReadToEnd()
        End Using
        ' regular expression to match the last json object returned from the API query
        Dim pattern As String = "{((?!{).)*}\s*$"
        Dim match As Match = Regex.Match(stdout, pattern)
        stdout = match.Value
        Dim jsonObj As JObject = JObject.Parse(stdout)
        Dim ra As Double = jsonObj.Item("ra")
        Dim dec As Double = jsonObj.Item("dec")
        Form1.setRaDecRes(ra, dec, stdout)
    End Sub

    Public Sub setRaDecRes(ra As Double, dec As Double, raw As String)
        Me.BeginInvoke(Sub() Me.TextRA.Text = CStr(ra))
        Me.BeginInvoke(Sub() Me.TextDec.Text = CStr(dec))
        Me.BeginInvoke(Sub() Me.queryResults.Text = raw)
    End Sub

    Private Sub LocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocationToolStripMenuItem.Click
        Dim dialog As New Form2
        dialog.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        If Not clicked Then
            OpenPreviewWindow()
            clicked = True
        Else
            ClosePreviewWindow()
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

    Private Sub getNearbyObject()
        If objTelescope IsNot Nothing Then
            Dim RA As Integer = objTelescope.RightAscension
            Dim Dec As Integer = objTelescope.Declination
            Dim coord As String = CStr(RA) + "%3A00%3A00-" + CStr(Dec) + "00%3A00%3A00"
            Dim url As String = "http://simbad.u-strasbg.fr/simbad/sim-coo?Coord=" + coord + "&CooFrame=FK5&CooEpoch=2000&CooEqui=2000&CooDefinedFrames=none&Radius=2&Radius.unit=arcmin&submit=submit+query&CoordList="
            Dim request As WebRequest = WebRequest.Create(url)
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim document As New HtmlAgilityPack.HtmlDocument()



        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        getNearbyObject()
    End Sub

    Private Sub RecordDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordDataToolStripMenuItem.Click
        Dim record As New Record
        record.Show()
    End Sub
End Class
