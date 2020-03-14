<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rightplayervolume = New System.Windows.Forms.VScrollBar()
        Me.rightmastervolume = New System.Windows.Forms.VScrollBar()
        Me.leftplayervolume = New System.Windows.Forms.VScrollBar()
        Me.leftmastervolume = New System.Windows.Forms.VScrollBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.rightplayervolume)
        Me.GroupBox3.Controls.Add(Me.rightmastervolume)
        Me.GroupBox3.Controls.Add(Me.leftplayervolume)
        Me.GroupBox3.Controls.Add(Me.leftmastervolume)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(258, 172)
        Me.GroupBox3.TabIndex = 52
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Master - Player volume"
        '
        'rightplayervolume
        '
        Me.rightplayervolume.LargeChange = 1
        Me.rightplayervolume.Location = New System.Drawing.Point(242, 16)
        Me.rightplayervolume.Name = "rightplayervolume"
        Me.rightplayervolume.Size = New System.Drawing.Size(13, 115)
        Me.rightplayervolume.TabIndex = 1
        '
        'rightmastervolume
        '
        Me.rightmastervolume.LargeChange = 1
        Me.rightmastervolume.Location = New System.Drawing.Point(82, 15)
        Me.rightmastervolume.Name = "rightmastervolume"
        Me.rightmastervolume.Size = New System.Drawing.Size(13, 114)
        Me.rightmastervolume.TabIndex = 1
        '
        'leftplayervolume
        '
        Me.leftplayervolume.LargeChange = 1
        Me.leftplayervolume.Location = New System.Drawing.Point(166, 15)
        Me.leftplayervolume.Name = "leftplayervolume"
        Me.leftplayervolume.Size = New System.Drawing.Size(13, 115)
        Me.leftplayervolume.TabIndex = 0
        '
        'leftmastervolume
        '
        Me.leftmastervolume.LargeChange = 1
        Me.leftmastervolume.Location = New System.Drawing.Point(3, 16)
        Me.leftmastervolume.Name = "leftmastervolume"
        Me.leftmastervolume.Size = New System.Drawing.Size(13, 115)
        Me.leftmastervolume.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Left" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Master" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Right" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Master" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(143, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Left" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Player"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(222, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 26)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Right" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Player"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 190)
        Me.Controls.Add(Me.GroupBox3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form7"
        Me.Text = "Volume"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rightplayervolume As VScrollBar
    Friend WithEvents rightmastervolume As VScrollBar
    Friend WithEvents leftplayervolume As VScrollBar
    Friend WithEvents leftmastervolume As VScrollBar
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
