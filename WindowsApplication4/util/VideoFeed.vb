﻿Imports System.IO

'This class includes all methods for controlling the video display
Public Class VideoFeed

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

    'Checks the computer for all video inputs and adds them to the provided ToolStripMenuItem as subitems
    Public Sub LoadDeviceList(VideoDeviceToolStripMenuItem As ToolStripMenuItem)
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

    'Initializes the current feed from the selected camera
    Public Sub OpenPreviewWindow(picCapture As PictureBox)
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

    'Cuts the feed from the selected camera
    Public Sub ClosePreviewWindow()
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)
        DestroyWindow(hHwnd)
    End Sub

    'Takes a pictures of the current frame of the video feed
    Public Sub TakePicture(snapshotName As String, picCapture As PictureBox)
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

End Class