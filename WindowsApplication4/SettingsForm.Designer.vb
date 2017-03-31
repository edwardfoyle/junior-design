<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DriverInfo = New System.Windows.Forms.Label()
        Me.DriverVersion = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtRAR = New System.Windows.Forms.TextBox()
        Me.TxtDR = New System.Windows.Forms.TextBox()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Driver:"
        '
        'DriverInfo
        '
        Me.DriverInfo.AutoSize = True
        Me.DriverInfo.Location = New System.Drawing.Point(59, 9)
        Me.DriverInfo.Name = "DriverInfo"
        Me.DriverInfo.Size = New System.Drawing.Size(0, 17)
        Me.DriverInfo.TabIndex = 1
        '
        'DriverVersion
        '
        Me.DriverVersion.AutoSize = True
        Me.DriverVersion.Location = New System.Drawing.Point(59, 26)
        Me.DriverVersion.Name = "DriverVersion"
        Me.DriverVersion.Size = New System.Drawing.Size(0, 17)
        Me.DriverVersion.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Right Ascension Rate:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Declination Rate:"
        '
        'TxtRAR
        '
        Me.TxtRAR.Location = New System.Drawing.Point(166, 55)
        Me.TxtRAR.Name = "TxtRAR"
        Me.TxtRAR.Size = New System.Drawing.Size(100, 22)
        Me.TxtRAR.TabIndex = 5
        '
        'TxtDR
        '
        Me.TxtDR.Location = New System.Drawing.Point(134, 127)
        Me.TxtDR.Name = "TxtDR"
        Me.TxtDR.Size = New System.Drawing.Size(100, 22)
        Me.TxtDR.TabIndex = 6
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(717, 315)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 7
        Me.SaveBtn.Text = "Save"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 350)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.TxtDR)
        Me.Controls.Add(Me.TxtRAR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DriverVersion)
        Me.Controls.Add(Me.DriverInfo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SettingsForm"
        Me.Text = "User Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DriverInfo As Label
    Friend WithEvents DriverVersion As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtRAR As TextBox
    Friend WithEvents TxtDR As TextBox
    Friend WithEvents SaveBtn As Button
End Class
