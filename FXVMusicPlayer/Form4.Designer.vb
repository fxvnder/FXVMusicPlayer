<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.VScrollBar14 = New System.Windows.Forms.VScrollBar()
        Me.VScrollBar13 = New System.Windows.Forms.VScrollBar()
        Me.VScrollBar12 = New System.Windows.Forms.VScrollBar()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.VScrollBar14)
        Me.GroupBox7.Controls.Add(Me.VScrollBar13)
        Me.GroupBox7.Controls.Add(Me.VScrollBar12)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(114, 141)
        Me.GroupBox7.TabIndex = 60
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Pitch Changer:"
        '
        'VScrollBar14
        '
        Me.VScrollBar14.LargeChange = 1
        Me.VScrollBar14.Location = New System.Drawing.Point(98, 16)
        Me.VScrollBar14.Maximum = 200
        Me.VScrollBar14.Name = "VScrollBar14"
        Me.VScrollBar14.Size = New System.Drawing.Size(13, 115)
        Me.VScrollBar14.TabIndex = 2
        Me.VScrollBar14.Value = 100
        '
        'VScrollBar13
        '
        Me.VScrollBar13.LargeChange = 1
        Me.VScrollBar13.Location = New System.Drawing.Point(53, 16)
        Me.VScrollBar13.Maximum = 200
        Me.VScrollBar13.Name = "VScrollBar13"
        Me.VScrollBar13.Size = New System.Drawing.Size(13, 115)
        Me.VScrollBar13.TabIndex = 1
        Me.VScrollBar13.Value = 100
        '
        'VScrollBar12
        '
        Me.VScrollBar12.LargeChange = 1
        Me.VScrollBar12.Location = New System.Drawing.Point(3, 16)
        Me.VScrollBar12.Maximum = 200
        Me.VScrollBar12.Name = "VScrollBar12"
        Me.VScrollBar12.Size = New System.Drawing.Size(13, 115)
        Me.VScrollBar12.TabIndex = 0
        Me.VScrollBar12.Value = 100
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(138, 172)
        Me.Controls.Add(Me.GroupBox7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form4"
        Me.Text = "Pitch"
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents VScrollBar14 As VScrollBar
    Friend WithEvents VScrollBar13 As VScrollBar
    Friend WithEvents VScrollBar12 As VScrollBar
End Class
