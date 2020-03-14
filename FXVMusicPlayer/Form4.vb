Public Class Form4
    Private Sub VScrollBar12_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar12.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetPitch(200 - (CType(sender, VScrollBar)).Value)
        End If
    End Sub

    Private Sub VScrollBar13_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar13.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetTempo(200 - (CType(sender, VScrollBar)).Value)
        End If
    End Sub

    Private Sub VScrollBar14_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar14.ValueChanged
        If FXVMusicPlayer.Form1.Player IsNot Nothing Then
            FXVMusicPlayer.Form1.Player.SetRate(200 - (CType(sender, VScrollBar)).Value)
        End If
    End Sub
End Class