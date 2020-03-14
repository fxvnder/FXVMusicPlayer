Public Class Form7
    Public Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim BlockSlideLeft As Boolean = False
        Dim BlockSlideRight As Boolean = False
        FXVMusicPlayer.Form1.Player.GetMasterVolume(Left, Right)
        FXVMusicPlayer.Form1.Player.GetPlayerVolume(Left, Right)
    End Sub

    Private Sub leftmastervolume_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles leftmastervolume.ValueChanged
        Dim left As Integer
        Dim right As Integer
        FXVMusicPlayer.Form1.Player.GetMasterVolume(left, right)
        FXVMusicPlayer.Form1.Player.SetMasterVolume(100 - (CType(sender, VScrollBar)).Value, right)
    End Sub

    Private Sub rightmastervolume_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rightmastervolume.ValueChanged
        Dim left As Integer
        Dim right As Integer
        FXVMusicPlayer.Form1.Player.GetMasterVolume(left, right)
        FXVMusicPlayer.Form1.Player.SetMasterVolume(left, 100 - (CType(sender, VScrollBar)).Value)
    End Sub

    Private Sub leftplayervolume_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles leftplayervolume.ValueChanged
        Dim BlockSlideLeft As Boolean = False
        Dim BlockSlideRight As Boolean = False
        If Not BlockSlideLeft Then
            Dim left As Integer
            Dim right As Integer
            FXVMusicPlayer.Form1.Player.GetPlayerVolume(left, right)
            FXVMusicPlayer.Form1.Player.SetPlayerVolume(100 - (CType(sender, VScrollBar)).Value, right)
        End If
        BlockSlideLeft = False
    End Sub

    Private Sub rightplayervolume_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rightplayervolume.ValueChanged
        Dim BlockSlideLeft As Boolean = False
        Dim BlockSlideRight As Boolean = False
        If Not BlockSlideRight Then
            Dim left As Integer
            Dim right As Integer
            FXVMusicPlayer.Form1.Player.GetPlayerVolume(left, right)
            FXVMusicPlayer.Form1.Player.SetPlayerVolume(left, 100 - (CType(sender, VScrollBar)).Value)
        End If
        BlockSlideRight = False
    End Sub


End Class