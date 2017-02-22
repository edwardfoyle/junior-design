<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnAlign = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SlewBtn = New System.Windows.Forms.Button()
        Me.TextDec = New System.Windows.Forms.TextBox()
        Me.TextRA = New System.Windows.Forms.TextBox()
        Me.tbTelescope = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.queryAPI = New System.Windows.Forms.Button()
        Me.sfdImage = New System.Windows.Forms.SaveFileDialog()
        Me.queryResults = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VideoDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvancedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecordDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(117, 60)
        Me.btnChoose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(75, 23)
        Me.btnChoose.TabIndex = 0
        Me.btnChoose.Text = "Choose"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(199, 62)
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 2
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnAlign
        '
        Me.btnAlign.Location = New System.Drawing.Point(660, 430)
        Me.btnAlign.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAlign.Name = "btnAlign"
        Me.btnAlign.Size = New System.Drawing.Size(163, 32)
        Me.btnAlign.TabIndex = 6
        Me.btnAlign.Text = "Automatically Align"
        Me.btnAlign.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'SlewBtn
        '
        Me.SlewBtn.Location = New System.Drawing.Point(224, 150)
        Me.SlewBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SlewBtn.Name = "SlewBtn"
        Me.SlewBtn.Size = New System.Drawing.Size(75, 23)
        Me.SlewBtn.TabIndex = 9
        Me.SlewBtn.Text = "Slew"
        Me.SlewBtn.UseVisualStyleBackColor = True
        '
        'TextDec
        '
        Me.TextDec.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.skyAutoTrack.My.MySettings.Default, "Dec", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextDec.Location = New System.Drawing.Point(117, 150)
        Me.TextDec.Margin = New System.Windows.Forms.Padding(2)
        Me.TextDec.Name = "TextDec"
        Me.TextDec.Size = New System.Drawing.Size(100, 22)
        Me.TextDec.TabIndex = 8
        Me.TextDec.Text = Global.skyAutoTrack.My.MySettings.Default.Dec
        Me.TextDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextRA
        '
        Me.TextRA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.skyAutoTrack.My.MySettings.Default, "RA", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextRA.Location = New System.Drawing.Point(9, 150)
        Me.TextRA.Margin = New System.Windows.Forms.Padding(2)
        Me.TextRA.Name = "TextRA"
        Me.TextRA.Size = New System.Drawing.Size(100, 22)
        Me.TextRA.TabIndex = 7
        Me.TextRA.Text = Global.skyAutoTrack.My.MySettings.Default.RA
        Me.TextRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTelescope
        '
        Me.tbTelescope.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.skyAutoTrack.My.MySettings.Default, "Telescope", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbTelescope.Location = New System.Drawing.Point(12, 60)
        Me.tbTelescope.Margin = New System.Windows.Forms.Padding(2)
        Me.tbTelescope.Name = "tbTelescope"
        Me.tbTelescope.Size = New System.Drawing.Size(100, 22)
        Me.tbTelescope.TabIndex = 1
        Me.tbTelescope.Text = Global.skyAutoTrack.My.MySettings.Default.Telescope
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(309, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Select and Connect Telescope"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(206, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Slew to Coordinates"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Right Ascension"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(125, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Declination"
        '
        'queryAPI
        '
        Me.queryAPI.Location = New System.Drawing.Point(360, 434)
        Me.queryAPI.Margin = New System.Windows.Forms.Padding(4)
        Me.queryAPI.Name = "queryAPI"
        Me.queryAPI.Size = New System.Drawing.Size(100, 28)
        Me.queryAPI.TabIndex = 19
        Me.queryAPI.Text = "Query API"
        Me.queryAPI.UseVisualStyleBackColor = True
        '
        'queryResults
        '
        Me.queryResults.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.queryResults.Location = New System.Drawing.Point(360, 62)
        Me.queryResults.Margin = New System.Windows.Forms.Padding(4)
        Me.queryResults.Multiline = True
        Me.queryResults.Name = "queryResults"
        Me.queryResults.Size = New System.Drawing.Size(160, 352)
        Me.queryResults.TabIndex = 20
        Me.queryResults.Text = "Query results will appear here"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.RecordDataToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1011, 28)
        Me.MenuStrip1.TabIndex = 21
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LocationToolStripMenuItem, Me.VideoDeviceToolStripMenuItem, Me.DisplayToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'LocationToolStripMenuItem
        '
        Me.LocationToolStripMenuItem.Name = "LocationToolStripMenuItem"
        Me.LocationToolStripMenuItem.Size = New System.Drawing.Size(172, 26)
        Me.LocationToolStripMenuItem.Text = "Location"
        '
        'VideoDeviceToolStripMenuItem
        '
        Me.VideoDeviceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectToolStripMenuItem})
        Me.VideoDeviceToolStripMenuItem.Name = "VideoDeviceToolStripMenuItem"
        Me.VideoDeviceToolStripMenuItem.Size = New System.Drawing.Size(172, 26)
        Me.VideoDeviceToolStripMenuItem.Text = "Video Device"
        '
        'ConnectToolStripMenuItem
        '
        Me.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem"
        Me.ConnectToolStripMenuItem.Size = New System.Drawing.Size(138, 26)
        Me.ConnectToolStripMenuItem.Text = "Connect"
        '
        'DisplayToolStripMenuItem
        '
        Me.DisplayToolStripMenuItem.CheckOnClick = True
        Me.DisplayToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NoviceToolStripMenuItem, Me.AdvancedToolStripMenuItem})
        Me.DisplayToolStripMenuItem.Name = "DisplayToolStripMenuItem"
        Me.DisplayToolStripMenuItem.Size = New System.Drawing.Size(172, 26)
        Me.DisplayToolStripMenuItem.Text = "Display"
        '
        'NoviceToolStripMenuItem
        '
        Me.NoviceToolStripMenuItem.Name = "NoviceToolStripMenuItem"
        Me.NoviceToolStripMenuItem.Size = New System.Drawing.Size(150, 26)
        Me.NoviceToolStripMenuItem.Text = "Novice"
        '
        'AdvancedToolStripMenuItem
        '
        Me.AdvancedToolStripMenuItem.Checked = True
        Me.AdvancedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AdvancedToolStripMenuItem.Name = "AdvancedToolStripMenuItem"
        Me.AdvancedToolStripMenuItem.Size = New System.Drawing.Size(150, 26)
        Me.AdvancedToolStripMenuItem.Text = "Advanced"
        '
        'RecordDataToolStripMenuItem
        '
        Me.RecordDataToolStripMenuItem.Name = "RecordDataToolStripMenuItem"
        Me.RecordDataToolStripMenuItem.Size = New System.Drawing.Size(104, 24)
        Me.RecordDataToolStripMenuItem.Text = "Record Data"
        '
        'picCapture
        '
        Me.picCapture.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.picCapture.Location = New System.Drawing.Point(552, 47)
        Me.picCapture.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(375, 368)
        Me.picCapture.TabIndex = 15
        Me.picCapture.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 487)
        Me.Controls.Add(Me.queryResults)
        Me.Controls.Add(Me.queryAPI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SlewBtn)
        Me.Controls.Add(Me.TextDec)
        Me.Controls.Add(Me.TextRA)
        Me.Controls.Add(Me.btnAlign)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.tbTelescope)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.picCapture)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.Text = "Sky AutoTrack"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnChoose As Button
    Friend WithEvents tbTelescope As TextBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnAlign As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextRA As TextBox
    Friend WithEvents TextDec As TextBox
    Friend WithEvents SlewBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents picCapture As PictureBox
    Friend WithEvents queryAPI As Button
    Friend WithEvents sfdImage As SaveFileDialog
    Friend WithEvents queryResults As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LocationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VideoDeviceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConnectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DisplayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NoviceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdvancedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecordDataToolStripMenuItem As ToolStripMenuItem
End Class
