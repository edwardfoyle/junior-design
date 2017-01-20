Option Explicit On
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1

    Private objTelescope As ASCOM.DriverAccess.Telescope

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        Dim obj As New ASCOM.Utilities.Chooser
        obj.DeviceType = "Telescope"
        My.Settings.Telescope = obj.Choose(My.Settings.Telescope)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mLoadDeviceList()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        objTelescope = New ASCOM.DriverAccess.Telescope(My.Settings.Telescope)
        objTelescope.Connected = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        TakePicture()
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
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer,
        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer,
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer,
        ByVal nHeight As Short, ByVal hWndParent As Integer,
        ByVal nID As Integer) As Integer

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short,
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String,
        ByVal cbVer As Integer) As Boolean

    Public Devices As New List(Of String)
    Public Height As Integer = 480
    Public Width As Integer = 640
    Public OutputPath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
    Public FilenamePrefix As String = "snapshot"
    Private Sub mLoadDeviceList()
        Dim lsName As String = Space(100)
        Dim lsVers As String = Space(100)
        Dim lbReturn As Boolean
        Dim x As Integer = 0

        Do
            '   Get Driver name and version 
            lbReturn = capGetDriverDescriptionA(x, lsName, 100, lsVers, 100)

            ' If there was a device add device name to the list 
            If lbReturn Then Devices.Add(lsName.Trim)
            x += 1
        Loop Until lbReturn = False
    End Sub
    Public Sub TakePicture()
        For i = 0 To Me.Devices.Count - 1
            Dim lsFilename As String = Path.Combine(OutputPath, Me.FilenamePrefix & i & ".jpg")
            TakePicture(i, lsFilename)
        Next
    End Sub
    Public Sub TakePicture(ByVal iDevice As Integer)
        Me.TakePicture(iDevice, Path.Combine(OutputPath, Me.FilenamePrefix & ".jpg"))
    End Sub
    Public Sub TakePicture(ByVal iDevice As Integer, ByVal filename As String)

        Dim lhHwnd As Integer ' Handle to preview window

        ' Create a form to play with 
        Using loWindow As New System.Windows.Forms.Form

            ' Create capture window 
            lhHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, Me.Width,
               Me.Height, loWindow.Handle.ToInt32, 0)

            ' Hook up the device 
            SendMessage(lhHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0)
            ' Allow the webcam apeture to let enough light in 
            For i = 1 To 10
                Application.DoEvents()
            Next

            ' Copy image to clipboard 
            SendMessage(lhHwnd, WM_CAP_EDIT_COPY, 0, 0)

            ' Get image from clipboard and convert it to a bitmap 
            Dim loData As IDataObject = Clipboard.GetDataObject()
            If loData.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
                Using loBitmap As Image = CType(loData.GetData(GetType(System.Drawing.Bitmap)), Image)
                    loBitmap.Save(filename, Imaging.ImageFormat.Jpeg)
                End Using
            End If

            SendMessage(lhHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

        End Using

    End Sub

End Class
