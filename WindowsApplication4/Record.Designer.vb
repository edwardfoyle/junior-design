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
        Me.recordBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'recordBtn
        '
        Me.recordBtn.Location = New System.Drawing.Point(12, 103)
        Me.recordBtn.Name = "recordBtn"
        Me.recordBtn.Size = New System.Drawing.Size(75, 23)
        Me.recordBtn.TabIndex = 0
        Me.recordBtn.Text = "Record"
        Me.recordBtn.UseVisualStyleBackColor = True
        '
        'Record
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 521)
        Me.Controls.Add(Me.recordBtn)
        Me.Name = "Record"
        Me.Text = "Record"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents recordBtn As Button
End Class
