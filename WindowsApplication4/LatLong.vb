Public Class LatLong

    Dim main As Main

    Public Sub New(main As Main)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.main = main
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtLat.Text = main.objTelescope.SiteLatitude.ToString()
        txtLong.Text = main.objTelescope.SiteLongitude.ToString()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        main.objTelescope.SiteLatitude = Double.Parse(txtLat.Text)
        main.objTelescope.SiteLongitude = Double.Parse(txtLong.Text)
    End Sub
End Class