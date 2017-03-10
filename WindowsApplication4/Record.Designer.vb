<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Record
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
        Me.components = New System.ComponentModel.Container()
        Me.recordBtn = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.stopBtn = New System.Windows.Forms.Button()
        Me.currData = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'recordBtn
        '
        Me.recordBtn.Location = New System.Drawing.Point(538, 430)
        Me.recordBtn.Name = "recordBtn"
        Me.recordBtn.Size = New System.Drawing.Size(75, 23)
        Me.recordBtn.TabIndex = 0
        Me.recordBtn.Text = "Record"
        Me.recordBtn.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'stopBtn
        '
        Me.stopBtn.Location = New System.Drawing.Point(619, 430)
        Me.stopBtn.Name = "stopBtn"
        Me.stopBtn.Size = New System.Drawing.Size(75, 23)
        Me.stopBtn.TabIndex = 1
        Me.stopBtn.Text = "Stop"
        Me.stopBtn.UseVisualStyleBackColor = True
        '
        'currData
        '
        Me.currData.Location = New System.Drawing.Point(12, 26)
        Me.currData.Multiline = True
        Me.currData.Name = "currData"
        Me.currData.Size = New System.Drawing.Size(710, 387)
        Me.currData.TabIndex = 2
        '
        'Record
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 521)
        Me.Controls.Add(Me.currData)
        Me.Controls.Add(Me.stopBtn)
        Me.Controls.Add(Me.recordBtn)
        Me.Name = "Record"
        Me.Text = "Record"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents recordBtn As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents stopBtn As Button
    Friend WithEvents currData As TextBox
End Class
