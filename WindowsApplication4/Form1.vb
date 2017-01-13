Imports Emgu.CV
Imports Emgu.CV.Util
Imports Emgu.CV.Structure

Public Class Form1

    Private objTelescope As ASCOM.DriverAccess.Telescope

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        Dim obj As New ASCOM.Utilities.Chooser
        obj.DeviceType = "Telescope"
        My.Settings.Telescope = obj.Choose(My.Settings.Telescope)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        objTelescope = New ASCOM.DriverAccess.Telescope(My.Settings.Telescope)
        objTelescope.Connected = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

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

    Private Sub TextRA_TextChanged(sender As Object, e As EventArgs) Handles TextRA.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextDec_TextChanged(sender As Object, e As EventArgs) Handles TextDec.TextChanged

    End Sub
End Class
