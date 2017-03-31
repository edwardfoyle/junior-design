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

End Class