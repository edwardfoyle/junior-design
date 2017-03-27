<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LatLong
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.txtLong = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Latitude"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Longitude"
        '
        'txtLat
        '
        Me.txtLat.Location = New System.Drawing.Point(12, 44)
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(100, 22)
        Me.txtLat.TabIndex = 2
        '
        'txtLong
        '
        Me.txtLong.Location = New System.Drawing.Point(12, 109)
        Me.txtLong.Name = "txtLong"
        Me.txtLong.Size = New System.Drawing.Size(100, 22)
        Me.txtLong.TabIndex = 3
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(130, 109)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'LatLong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 153)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtLong)
        Me.Controls.Add(Me.txtLat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "LatLong"
        Me.Text = "Location"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLat As TextBox
    Friend WithEvents txtLong As TextBox
    Friend WithEvents btnUpdate As Button
End Class
