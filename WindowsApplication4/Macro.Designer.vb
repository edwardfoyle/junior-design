<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Macro
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
        Me.MacroText = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMacroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMacroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunMacroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveMacroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunMacroButton = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MacroText
        '
        Me.MacroText.Location = New System.Drawing.Point(12, 41)
        Me.MacroText.Multiline = True
        Me.MacroText.Name = "MacroText"
        Me.MacroText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.MacroText.Size = New System.Drawing.Size(865, 372)
        Me.MacroText.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(889, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMacroToolStripMenuItem, Me.OpenMacroToolStripMenuItem, Me.RunMacroToolStripMenuItem, Me.SaveMacroToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewMacroToolStripMenuItem
        '
        Me.NewMacroToolStripMenuItem.Name = "NewMacroToolStripMenuItem"
        Me.NewMacroToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.NewMacroToolStripMenuItem.Text = "New Macro"
        '
        'OpenMacroToolStripMenuItem
        '
        Me.OpenMacroToolStripMenuItem.Name = "OpenMacroToolStripMenuItem"
        Me.OpenMacroToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.OpenMacroToolStripMenuItem.Text = "Open Macro"
        '
        'RunMacroToolStripMenuItem
        '
        Me.RunMacroToolStripMenuItem.Name = "RunMacroToolStripMenuItem"
        Me.RunMacroToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.RunMacroToolStripMenuItem.Text = "Run Macro"
        '
        'SaveMacroToolStripMenuItem
        '
        Me.SaveMacroToolStripMenuItem.Name = "SaveMacroToolStripMenuItem"
        Me.SaveMacroToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.SaveMacroToolStripMenuItem.Text = "Save Macro"
        '
        'RunMacroButton
        '
        Me.RunMacroButton.Location = New System.Drawing.Point(777, 430)
        Me.RunMacroButton.Name = "RunMacroButton"
        Me.RunMacroButton.Size = New System.Drawing.Size(75, 23)
        Me.RunMacroButton.TabIndex = 2
        Me.RunMacroButton.Text = "Run"
        Me.RunMacroButton.UseVisualStyleBackColor = True
        '
        'Macro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 530)
        Me.Controls.Add(Me.RunMacroButton)
        Me.Controls.Add(Me.MacroText)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Macro"
        Me.Text = "Macro"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MacroText As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewMacroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenMacroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunMacroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveMacroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunMacroButton As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
