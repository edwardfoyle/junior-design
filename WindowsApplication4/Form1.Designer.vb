﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.queryAPI = New System.Windows.Forms.Button()
        Me.sfdImage = New System.Windows.Forms.SaveFileDialog()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(88, 49)
        Me.btnChoose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(56, 19)
        Me.btnChoose.TabIndex = 0
        Me.btnChoose.Text = "Choose"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(149, 50)
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(56, 19)
        Me.btnConnect.TabIndex = 2
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(497, 353)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 26)
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
        Me.SlewBtn.Location = New System.Drawing.Point(168, 122)
        Me.SlewBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.SlewBtn.Name = "SlewBtn"
        Me.SlewBtn.Size = New System.Drawing.Size(56, 19)
        Me.SlewBtn.TabIndex = 9
        Me.SlewBtn.Text = "Slew"
        Me.SlewBtn.UseVisualStyleBackColor = True
        '
        'TextDec
        '
        Me.TextDec.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WindowsApplication4.My.MySettings.Default, "Dec", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextDec.Location = New System.Drawing.Point(88, 122)
        Me.TextDec.Margin = New System.Windows.Forms.Padding(2)
        Me.TextDec.Name = "TextDec"
        Me.TextDec.Size = New System.Drawing.Size(76, 20)
        Me.TextDec.TabIndex = 8
        Me.TextDec.Text = Global.WindowsApplication4.My.MySettings.Default.Dec
        Me.TextDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextRA
        '
        Me.TextRA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WindowsApplication4.My.MySettings.Default, "RA", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextRA.Location = New System.Drawing.Point(9, 122)
        Me.TextRA.Margin = New System.Windows.Forms.Padding(2)
        Me.TextRA.Name = "TextRA"
        Me.TextRA.Size = New System.Drawing.Size(76, 20)
        Me.TextRA.TabIndex = 7
        Me.TextRA.Text = Global.WindowsApplication4.My.MySettings.Default.RA
        Me.TextRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTelescope
        '
        Me.tbTelescope.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WindowsApplication4.My.MySettings.Default, "Telescope", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbTelescope.Location = New System.Drawing.Point(9, 49)
        Me.tbTelescope.Margin = New System.Windows.Forms.Padding(2)
        Me.tbTelescope.Name = "tbTelescope"
        Me.tbTelescope.Size = New System.Drawing.Size(76, 20)
        Me.tbTelescope.TabIndex = 1
        Me.tbTelescope.Text = Global.WindowsApplication4.My.MySettings.Default.Telescope
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 20)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Select and Connect Telescope"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 92)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Slew to Coordinates"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 142)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Right Ascension"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(94, 142)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Declination"
        '
        'picCapture
        '
        Me.picCapture.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.picCapture.Location = New System.Drawing.Point(414, 38)
        Me.picCapture.Margin = New System.Windows.Forms.Padding(2)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(281, 299)
        Me.picCapture.TabIndex = 15
        Me.picCapture.TabStop = False
        '
        'DeviceList
        '
        Me.DeviceList.FormattingEnabled = True
        Me.DeviceList.Location = New System.Drawing.Point(7, 202)
        Me.DeviceList.Margin = New System.Windows.Forms.Padding(2)
        Me.DeviceList.Name = "DeviceList"
        Me.DeviceList.Size = New System.Drawing.Size(218, 69)
        Me.DeviceList.TabIndex = 17
        '
        'connect
        '
        Me.connect.Location = New System.Drawing.Point(7, 276)
        Me.connect.Margin = New System.Windows.Forms.Padding(2)
        Me.connect.Name = "connect"
        Me.connect.Size = New System.Drawing.Size(64, 19)
        Me.connect.TabIndex = 18
        Me.connect.Text = "Connect"
        Me.connect.UseVisualStyleBackColor = True
        '
        'queryAPI
        '
        Me.queryAPI.Location = New System.Drawing.Point(270, 331)
        Me.queryAPI.Name = "queryAPI"
        Me.queryAPI.Size = New System.Drawing.Size(75, 23)
        Me.queryAPI.TabIndex = 19
        Me.queryAPI.Text = "Query API"
        Me.queryAPI.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 396)
        Me.Controls.Add(Me.queryAPI)
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
        Me.Margin = New System.Windows.Forms.Padding(2)
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
    Friend WithEvents queryAPI As Button
    Friend WithEvents sfdImage As SaveFileDialog
End Class
