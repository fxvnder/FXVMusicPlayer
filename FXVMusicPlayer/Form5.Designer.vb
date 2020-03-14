<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(81, 41)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(63, 23)
        Me.Button16.TabIndex = 66
        Me.Button16.Text = "Side cut"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(11, 41)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(64, 23)
        Me.Button15.TabIndex = 65
        Me.Button15.Text = "Echo"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(81, 12)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(63, 23)
        Me.Button14.TabIndex = 64
        Me.Button14.Text = "Fade out"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(12, 12)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(63, 23)
        Me.Button13.TabIndex = 63
        Me.Button13.Text = "Fade in"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(150, 41)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(63, 23)
        Me.Button12.TabIndex = 62
        Me.Button12.Text = "Reverse"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(150, 12)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(63, 23)
        Me.Button8.TabIndex = 61
        Me.Button8.Text = "Vocal cut"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(224, 78)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form5"
        Me.Text = "FX"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button16 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button8 As Button
End Class
