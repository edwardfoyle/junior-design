Public Class SettingsForm

    Private mySettings As UserSettings
    Private main As Main

    Public Sub New(main As Main, mySettings As UserSettings)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mySettings = mySettings
        Me.main = main
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DriverInfo.Text = main.objTelescope.DriverInfo
        DriverVersion.Text = main.objTelescope.DriverVersion
        If DriverInfo.Text Is Nothing Then
            DriverInfo.Text = "No information available."
        End If
        TxtRAR.Text = main.objTelescope.RightAscensionRate
        TxtDR.Text = main.objTelescope.DeclinationRate
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        mySettings.raRate = Convert.ToDouble(TxtRAR.Text)
        mySettings.decRate = Convert.ToDouble(TxtDR.Text)
        main.objTelescope.DeclinationRate = mySettings.decRate
        main.objTelescope.RightAscensionRate = mySettings.raRate
    End Sub

End Class