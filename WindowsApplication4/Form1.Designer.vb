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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SlewBtn = New System.Windows.Forms.Button()
        Me.TextDec = New System.Windows.Forms.TextBox()
        Me.TextRA = New System.Windows.Forms.TextBox()
        Me.tbTelescope = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.DeviceList = New System.Windows.Forms.ListBox()
        Me.connect = New System.Windows.Forms.Button()
        Me.sfdImage = New System.Windows.Forms.SaveFileDialog()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(118, 60)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(75, 23)
        Me.btnChoose.TabIndex = 0
        Me.btnChoose.Text = "Choose"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(199, 61)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 2
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(663, 435)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(162, 32)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Automatically Align"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'SlewBtn
        '
        Me.SlewBtn.Location = New System.Drawing.Point(224, 150)
        Me.SlewBtn.Name = "SlewBtn"
        Me.SlewBtn.Size = New System.Drawing.Size(75, 23)
        Me.SlewBtn.TabIndex = 9
        Me.SlewBtn.Text = "Slew"
        Me.SlewBtn.UseVisualStyleBackColor = True
        '
        'TextDec
        '
        Me.TextDec.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WindowsApplication4.My.MySettings.Default, "Dec", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextDec.Location = New System.Drawing.Point(118, 150)
        Me.TextDec.Name = "TextDec"
        Me.TextDec.Size = New System.Drawing.Size(100, 22)
        Me.TextDec.TabIndex = 8
        Me.TextDec.Text = Global.WindowsApplication4.My.MySettings.Default.Dec
        Me.TextDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextRA
        '
        Me.TextRA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WindowsApplication4.My.MySettings.Default, "RA", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextRA.Location = New System.Drawing.Point(12, 150)
        Me.TextRA.Name = "TextRA"
        Me.TextRA.Size = New System.Drawing.Size(100, 22)
        Me.TextRA.TabIndex = 7
        Me.TextRA.Text = Global.WindowsApplication4.My.MySettings.Default.RA
        Me.TextRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTelescope
        '
        Me.tbTelescope.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WindowsApplication4.My.MySettings.Default, "Telescope", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbTelescope.Location = New System.Drawing.Point(12, 60)
        Me.tbTelescope.Name = "tbTelescope"
        Me.tbTelescope.Size = New System.Drawing.Size(100, 22)
        Me.tbTelescope.TabIndex = 1
        Me.tbTelescope.Text = Global.WindowsApplication4.My.MySettings.Default.Telescope
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 21)
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
        'picCapture
        '
        Me.picCapture.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.picCapture.Location = New System.Drawing.Point(552, 47)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(375, 368)
        Me.picCapture.TabIndex = 15
        Me.picCapture.TabStop = False
        '
        'DeviceList
        '
        Me.DeviceList.FormattingEnabled = True
        Me.DeviceList.ItemHeight = 16
        Me.DeviceList.Location = New System.Drawing.Point(9, 249)
        Me.DeviceList.Name = "DeviceList"
        Me.DeviceList.Size = New System.Drawing.Size(290, 84)
        Me.DeviceList.TabIndex = 17
        '
        'connect
        '
        Me.connect.Location = New System.Drawing.Point(9, 340)
        Me.connect.Name = "connect"
        Me.connect.Size = New System.Drawing.Size(85, 23)
        Me.connect.TabIndex = 18
        Me.connect.Text = "Connect"
        Me.connect.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 487)
        Me.Controls.Add(Me.connect)
        Me.Controls.Add(Me.DeviceList)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SlewBtn)
        Me.Controls.Add(Me.TextDec)
        Me.Controls.Add(Me.TextRA)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.tbTelescope)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.picCapture)
        Me.Name = "Form1"
        Me.Text = "Sky AutoTrack"
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnChoose As Button
    Friend WithEvents tbTelescope As TextBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextRA As TextBox
    Friend WithEvents TextDec As TextBox
    Friend WithEvents SlewBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents picCapture As PictureBox
    Friend WithEvents DeviceList As ListBox
    Friend WithEvents connect As Button
    Friend WithEvents sfdImage As SaveFileDialog
End Class
