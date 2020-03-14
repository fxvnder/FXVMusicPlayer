Imports FXVMusicPlayer.libZPlay

Public Class Form5
    Private Echo As Boolean
    Private VocalCut As Boolean = False
    Private SideCut As Boolean = False
    Private ReverseMode As Boolean
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim left As Integer = 0
        Dim right As Integer = 0


        FXVMusicPlayer.Form1.Player.GetPlayerVolume(left, right)
        FXVMusicPlayer.Form1.Player.GetPosition(FXVMusicPlayer.Form1.startpos)
        FXVMusicPlayer.Form1.endpos.sec = CType(FXVMusicPlayer.Form1.startpos.sec + 5, UInteger)
        FXVMusicPlayer.Form1.Player.SlideVolume(TTimeFormat.tfSecond, FXVMusicPlayer.Form1.startpos, left, right, TTimeFormat.tfSecond, FXVMusicPlayer.Form1.endpos, 100, 100)

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Echo = Not Echo
        FXVMusicPlayer.Form1.Player.EnableEcho(Echo)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim left As Integer = 0
        Dim right As Integer = 0

        FXVMusicPlayer.Form1.Player.GetPlayerVolume(left, right)
        FXVMusicPlayer.Form1.Player.GetPosition(FXVMusicPlayer.Form1.startpos)
        FXVMusicPlayer.Form1.endpos.sec = CType(FXVMusicPlayer.Form1.startpos.sec + 5, UInteger)
        FXVMusicPlayer.Form1.Player.SlideVolume(TTimeFormat.tfSecond, FXVMusicPlayer.Form1.startpos, left, right, TTimeFormat.tfSecond, FXVMusicPlayer.Form1.endpos, 0, 0)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SideCut = False
        VocalCut = Not VocalCut
        FXVMusicPlayer.Form1.Player.StereoCut(VocalCut, SideCut, True)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        SideCut = Not SideCut
        VocalCut = False
        FXVMusicPlayer.Form1.Player.StereoCut(VocalCut Or SideCut, SideCut, False)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ReverseMode = Not ReverseMode
        FXVMusicPlayer.Form1.Player.ReverseMode(ReverseMode)
    End Sub
End Class