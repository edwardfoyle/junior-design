Option Explicit On
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1

    Private objTelescope As ASCOM.DriverAccess.Telescope
    Private str As String

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
            If bReturn Then DeviceList.Items.Add(strName.Trim)
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim data As IDataObject
        Dim bmap As Image
        Using loWindow As New System.Windows.Forms.Form
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
            data = Clipboard.GetDataObject()
            Dim OutputPath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim FilenamePrefix As String = "snapshot"
            Dim lsFilename As String = Path.Combine(OutputPath, FilenamePrefix & ".jpg")
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

    Private Sub connect_Click(sender As Object, e As EventArgs) Handles connect.Click
        If Not clicked Then
            OpenPreviewWindow()
            clicked = True
        Else
            ClosePreviewWindow()
            clicked = False
        End If
    End Sub

    Private Sub DeviceList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DeviceList.SelectedIndexChanged

    End Sub

    Private Sub queryAPI_Click(sender As Object, e As EventArgs) Handles queryAPI.Click
        ' pyEx.Execute("c:/python27/python.exe", "C:\Users\Edward\SkyDrive\Documents\GaTech\Courses\04SeniorYear\CS3312\junior-design\APIClient\client25.py -k ahhxdcgzhkqyxwas -u C:\Users\Edward\SkyDrive\Documents\GaTech\Courses\04SeniorYear\CS3312\junior-design\TestingAssets\starsTest.jpg -w")
        Dim proc As New Process()
        proc.StartInfo.FileName = "C:/python27/python.exe"
        proc.StartInfo.Arguments = "C:\Users\Edward\SkyDrive\Documents\GaTech\Courses\04SeniorYear\CS3312\junior-design\APIClient\client25.py -k ahhxdcgzhkqyxwas -u C:\Users\Edward\SkyDrive\Documents\GaTech\Courses\04SeniorYear\CS3312\junior-design\TestingAssets\starsTest.jpg -w"
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.Start()

        Dim stdout As String
        Using outStreamReader As System.IO.StreamReader = proc.StandardOutput
            stdout = outStreamReader.ReadToEnd()
        End Using
        'stdout = ""Running with args ['C:\\Users\\Edward\\SkyDrive\\Documents\\GaTech\\Courses\\04SeniorYear\\CS3312\\junior-design\\APIClient\\client25.py', '-k', 'ahhxdcgzhkqyxwas', '-u', 'C:\\Users\\Edward\\SkyDrive\\Documents\\GaTech\\Courses\\04SeniorYear\\CS3312\\junior-design\\TestingAssets\\starsTest.jpg', '-w']" & vbCrLf & "Python: {'apikey': 'ahhxdcgzhkqyxwas'}" & vbCrLf & "Sending json: {""apikey"": ""ahhxdcgzhkqyxwas""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/login" & vbCrLf & "Sending form data: {'request-json': '{""apikey"": ""ahhxdcgzhkqyxwas""}'}" & vbCrLf & "Sending data: request-json=%7B%22apikey%22%3A+%22ahhxdcgzhkqyxwas%22%7D" & vbCrLf & "Got json: {""status"": ""success"", ""message"": ""authenticated user: pianoman2394@gmail.com"", ""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Got result: {u'status': u'success', u'message': u'authenticated user: pianoman2394@gmail.com', u'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Got status: success" & vbCrLf & "Got session: h4ojdrw954flzipg134y2yhpwdxtd03c" & vbCrLf & "Upload args: {'publicly_visible': 'y', 'allow_modifications': 'd', 'allow_commercial_use': 'd'}" & vbCrLf & "Python: {'publicly_visible': 'y', 'allow_modifications': 'd', 'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c', 'allow_commercial_use': 'd'}" & vbCrLf & "Sending json: {""publicly_visible"": ""y"", ""allow_modifications"": ""d"", ""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c"", ""allow_commercial_use"": ""d""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/upload" & vbCrLf & "Got json: {""status"": ""success"", ""subid"": 1430269, ""hash"": ""92b7763be0630513e62394a4868aba0991430d9a""}" & vbCrLf & "Got result: {u'status': u'success', u'subid': 1430269, u'hash': u'92b7763be0630513e62394a4868aba0991430d9a'}" & vbCrLf & "Got status: success" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/submissions/1430269" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""processing_started"": ""None"", ""job_calibrations"": [], ""jobs"": [], ""processing_finished"": ""None"", ""user"": 7836, ""user_images"": []}" & vbCrLf & "Got result: {u'processing_started': u'None', u'job_calibrations': [], u'jobs': [], u'processing_finished': u'None', u'user': 7836, u'user_images': []}" & vbCrLf & "Got status: None" & vbCrLf & "Got status: {u'processing_started': u'None', u'job_calibrations': [], u'jobs': [], u'processing_finished': u'None', u'user': 7836, u'user_images': []}" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/submissions/1430269" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""processing_started"": ""None"", ""job_calibrations"": [], ""jobs"": [], ""processing_finished"": ""None"", ""user"": 7836, ""user_images"": []}" & vbCrLf & "Got result: {u'processing_started': u'None', u'job_calibrations': [], u'jobs': [], u'processing_finished': u'None', u'user': 7836, u'user_images': []}" & vbCrLf & "Got status: None" & vbCrLf & "Got status: {u'processing_started': u'None', u'job_calibrations': [], u'jobs': [], u'processing_finished': u'None', u'user': 7836, u'user_images': []}" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/submissions/1430269" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""processing_started"": ""None"", ""job_calibrations"": [], ""jobs"": [], ""processing_finished"": ""None"", ""user"": 7836, ""user_images"": []}" & vbCrLf & "Got result: {u'processing_started': u'None', u'job_calibrations': [], u'jobs': [], u'processing_finished': u'None', u'user': 7836, u'user_images': []}" & vbCrLf & "Got status: None" & vbCrLf & "Got status: {u'processing_started': u'None', u'job_calibrations': [], u'jobs': [], u'processing_finished': u'None', u'user': 7836, u'user_images': []}" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/submissions/1430269" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""processing_started"": ""2017-01-30 23:53:50.948640"", ""job_calibrations"": [], ""jobs"": [], ""processing_finished"": ""None"", ""user"": 7836, ""user_images"": []}" & vbCrLf & "Got result: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [], u'processing_finished': u'None', u'user': 7836, u'user_images': []}" & vbCrLf & "Got status: None" & vbCrLf & "Got status: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [], u'processing_finished': u'None', u'user': 7836, u'user_images': []}" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/submissions/1430269" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""processing_started"": ""2017-01-30 23:53:50.948640"", ""job_calibrations"": [], ""jobs"": [null], ""processing_finished"": ""2017-01-30 23:53:52.565100"", ""user"": 7836, ""user_images"": [1474899]}" & vbCrLf & "Got result: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [None], u'processing_finished': u'2017-01-30 23:53:52.565100', u'user': 7836, u'user_images': [1474899]}" & vbCrLf & "Got status: None" & vbCrLf & "Got status: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [None], u'processing_finished': u'2017-01-30 23:53:52.565100', u'user': 7836, u'user_images': [1474899]}" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/submissions/1430269" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""processing_started"": ""2017-01-30 23:53:50.948640"", ""job_calibrations"": [], ""jobs"": [null], ""processing_finished"": ""2017-01-30 23:53:52.565100"", ""user"": 7836, ""user_images"": [1474899]}" & vbCrLf & "Got result: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [None], u'processing_finished': u'2017-01-30 23:53:52.565100', u'user': 7836, u'user_images': [1474899]}" & vbCrLf & "Got status: None" & vbCrLf & "Got status: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [None], u'processing_finished': u'2017-01-30 23:53:52.565100', u'user': 7836, u'user_images': [1474899]}" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/submissions/1430269" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""processing_started"": ""2017-01-30 23:53:50.948640"", ""job_calibrations"": [], ""jobs"": [null], ""processing_finished"": ""2017-01-30 23:53:52.565100"", ""user"": 7836, ""user_images"": [1474899]}" & vbCrLf & "Got result: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [None], u'processing_finished': u'2017-01-30 23:53:52.565100', u'user': 7836, u'user_images': [1474899]}" & vbCrLf & "Got status: None" & vbCrLf & "Got status: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [None], u'processing_finished': u'2017-01-30 23:53:52.565100', u'user': 7836, u'user_images': [1474899]}" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/submissions/1430269" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""processing_started"": ""2017-01-30 23:53:50.948640"", ""job_calibrations"": [], ""jobs"": [1921805], ""processing_finished"": ""2017-01-30 23:53:52.565100"", ""user"": 7836, ""user_images"": [1474899]}" & vbCrLf & "Got result: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [1921805], u'processing_finished': u'2017-01-30 23:53:52.565100', u'user': 7836, u'user_images': [1474899]}" & vbCrLf & "Got status: None" & vbCrLf & "Got status: {u'processing_started': u'2017-01-30 23:53:50.948640', u'job_calibrations': [], u'jobs': [1921805], u'processing_finished': u'2017-01-30 23:53:52.565100', u'user': 7836, u'user_images': [1474899]}" & vbCrLf & "Selecting job id 1921805" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/jobs/1921805" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""status"": ""solving""}" & vbCrLf & "Got result: {u'status': u'solving'}" & vbCrLf & "Got status: solving" & vbCrLf & "Got job status: {u'status': u'solving'}" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/jobs/1921805" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""status"": ""solving""}" & vbCrLf & "Got result: {u'status': u'solving'}" & vbCrLf & "Got status: solving" & vbCrLf & "Got job status: {u'status': u'solving'}" & vbCrLf & "Python: {'session': u'h4ojdrw954flzipg134y2yhpwdxtd03c'}" & vbCrLf & "Sending json: {""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}" & vbCrLf & "Sending to URL: http://nova.astrometry.net/api/jobs/1921805" & vbCrLf & "Sending form data: {'request-json': '{""session"": ""h4ojdrw954flzipg134y2yhpwdxtd03c""}'}" & vbCrLf & "Sending data: request-json=%7B%22session%22%3A+%22h4ojdrw954flzipg134y2yhpwdxtd03c%22%7D" & vbCrLf & "Got json: {""status"": ""success""}" & vbCrLf & "Got result: {u'status': u'success'}" & vbCrLf & "Got status: success" & vbCrLf & "Got job status: {u'status': u'success'}" & vbCrLf & "{""parity"": 1.0, ""orientation"": 83.38351006328078, ""pixscale"": 11.366927483539355, ""radius"": 1.208139433518881, ""ra"": 56.79069312423848, ""dec"": 24.134366949304628}""
        Dim pattern As String = "{((?!{).)*}\s*$"
        Dim match As Match = Regex.Match(stdout, pattern)
        stdout = match.Value
        Dim jsonObj As JObject = JObject.Parse(stdout)
        Dim ra As Double = jsonObj.Item("ra")
        Dim dec As Double = jsonObj.Item("dec")
        TextRA.Text = CStr(ra)
        TextDec.Text = CStr(dec)
        queryResults.Text = stdout
    End Sub
End Class
