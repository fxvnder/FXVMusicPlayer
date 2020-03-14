Imports FXVMusicPlayer.libZPlay

Public Class Form6
    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Dim MyDeviceContext As IntPtr = e.Graphics.GetHdc()
        FXVMusicPlayer.Form1.Player.DrawFFTGraphOnHDC(MyDeviceContext, 0, 0, PictureBox1.Width, PictureBox1.Height)
        e.Graphics.ReleaseHdc(MyDeviceContext)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim left As Integer = 0
        Dim right As Integer = 0

        If FFTEnabled.Checked Then
            PictureBox1.Refresh()
        End If

        'Dim leftamplitude(512) As Integer
        'player.GetFFTValues(1024, CWMp3x.TFFTWindow.fwBartlett, Nothing, Nothing, leftamplitude, Nothing, Nothing, Nothing)
        'leftvu.Value = leftamplitude(1)

        FXVMusicPlayer.Form1.Player.GetVUData(left, right)
    End Sub

    Private Sub FFTLinear_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FFTLinear.CheckedChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            If (CType(sender, CheckBox)).Checked Then
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpHorizontalScale, TFFTGraphHorizontalScale.gsLinear)
            Else
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpHorizontalScale, TFFTGraphHorizontalScale.gsLogarithmic)
            End If
        End If

    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            If (CType(sender, CheckBox)).Checked Then
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpFrequencyScaleVisible, 1)
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpDecibelScaleVisible, 1)
            Else
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpFrequencyScaleVisible, 0)
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpDecibelScaleVisible, 0)
            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            If (CType(sender, CheckBox)).Checked Then
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpFrequencyGridVisible, 1)
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpDecibelGridVisible, 1)
            Else
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpFrequencyGridVisible, 0)
                FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpDecibelGridVisible, 0)
            End If
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpGraphType, (CType(sender, ComboBox)).SelectedIndex)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim points As Integer = 0
        points = System.Convert.ToInt32(Math.Pow(2, (CType(sender, ComboBox)).SelectedIndex + 2))
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpFFTPoints, points)
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetFFTGraphParam(TFFTGraphParamID.gpWindow, (CType(sender, ComboBox)).SelectedIndex + 1)
        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 7
        ComboBox3.SelectedIndex = 11
    End Sub
End Class