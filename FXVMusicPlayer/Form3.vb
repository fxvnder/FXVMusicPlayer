Public Class Form3
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        FXVMusicPlayer.Form1.Player.EnableEqualizer((CType(sender, CheckBox)).Checked)
    End Sub
    Private Sub VScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar1.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetEqualizerPreampGain(20000 - (CType(sender, VScrollBar)).Value * 1000)
        End If
    End Sub

    Private Sub VScrollBar2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar2.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetEqualizerBandGain(0, 20000 - (CType(sender, VScrollBar)).Value * 1000)
        End If
    End Sub

    Private Sub VScrollBar3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar3.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetEqualizerBandGain(1, 20000 - (CType(sender, VScrollBar)).Value * 1000)
        End If
    End Sub

    Private Sub VScrollBar4_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar4.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetEqualizerBandGain(2, 20000 - (CType(sender, VScrollBar)).Value * 1000)
        End If
    End Sub

    Private Sub VScrollBar5_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar5.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetEqualizerBandGain(3, 20000 - (CType(sender, VScrollBar)).Value * 1000)
        End If
    End Sub

    Private Sub VScrollBar6_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar6.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetEqualizerBandGain(4, 20000 - (CType(sender, VScrollBar)).Value * 1000)
        End If
    End Sub

    Private Sub VScrollBar7_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar7.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetEqualizerBandGain(5, 20000 - (CType(sender, VScrollBar)).Value * 1000)
        End If
    End Sub

    Private Sub VScrollBar8_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar8.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetEqualizerBandGain(6, 20000 - (CType(sender, VScrollBar)).Value * 1000)
        End If
    End Sub

End Class