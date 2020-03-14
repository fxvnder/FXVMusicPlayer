Option Strict Off
Imports System.Drawing
Imports FXVMusicPlayer.libZPlay 'Necessário para reproduzir a música e obter as tags sem necessitar de programas externos. Equalizador = OK!


'O ERRO DE RETURN NA FUNÇÃO É UM BUG DA CLASSE libZPlay E EM NADA AFETA O FUNCIONAMENTO DO PROGRAMA!
'Isto acontece devido à classe já ser velhinha, mas faz o serviço!
'Nenhum do código utilizado ou quaisquer classes/ícones/etc são protegidos por direitos de autor
'Todo o conteúdo que não foi feito por mim é opensource.


Public Class Form1
    Public Player As New ZPlay 'Variável para aceder à classe
    Dim MP3Tags As New mcTrack 'Variável para as MP3Tags (simples) - só funciona para MP3, a classe é utilizada para outros ficheiros como FLAC, AAC, etc
    Dim playpause As Boolean = False 'Variável para controlar o stream
    Dim info As New TID3InfoEx() 'Variável que irá carregar a versão do ID3 para dar as informações do ficheiro posteriormente
    Dim StreamInfo As New TStreamInfo() 'Variável que carrega dentro da classe várias informações do streaming
    Dim GetStatus As TStreamStatus 'Stream Status
    Dim n_musica As Integer = 0 'Nº da música adicionada - consecutiva. Começa no 0 para a primeira ser a 1ª
    Public startpos As New TStreamTime() 'FX
    Public endpos As New TStreamTime() 'FX
    Dim ds As DataSet 'controlo de dados na DataSet
    Dim infotxt As String 'mod. strings artista + album
    Dim musicdb2 As New MusicDB 'Entrada na BD MusicDB (com um 2 para não confundir o código)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen() 'Centra o Form no ecrã

#Region "Limpeza de labels"
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = "Play a song to"
        Label4.Text = "load it's info"
        Label5.Text = ""
        Label6.Text = ""
#End Region

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        ' OpenFileDialog1.InitialDirectory = Application.StartupPath 'OpenFileDialog vai abrir por predefinição no diretório do programa.

        ' DESATIVADO POR MOTIVOS DE UTILIDADE - O PROGRAMA IRÁ ABRIR NA ULTIMA PASTA ONDE O UTILIZADOR FOI BUSCAR FICHEIROS, OU SEJA, PROVAVELMENTE ONDE O UTILIZADOR TEM AS MÚSICAS.

        OpenFileDialog1.FileName = Nothing

#Region "Erros do OFD"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MessageBox.Show("Invalid file or cancelled operation. If this error persists, consult Help.")
            GoTo Skip
        Else
            If String.IsNullOrEmpty(OpenFileDialog1.FileName) Then
                MessageBox.Show("You need to enter a file path and/or a name first")
                Exit Sub
            End If
        End If

#End Region
        Timer1.Enabled = True
        'IMPORTANTE:
        'Player.GetStatus(GetStatus) > não é necessário
        Player.OpenFile(OpenFileDialog1.FileName, TStreamFormat.sfAutodetect) 'Reproduz o ficheiro do OFD
        n_musica = n_musica + 1
        musicdb2.num = n_musica

#Region "Tags Básicas para MP3 & Utilização do Shell32 para obter o bitrate"


        MP3Tags = mfcReadID3v2Tag.ReadID3v2Tag(OpenFileDialog1.FileName) 'Ler Tags do ficheiro OFD
        Dim FolderPath As String = IO.Path.GetDirectoryName(OpenFileDialog1.FileName)
        Dim FileName As String = IO.Path.GetFileName(OpenFileDialog1.FileName)
        Dim objShell As Shell32.Shell = CType(CreateObject("Shell.Application"), Shell32.Shell)
        Dim objFolder As Shell32.Folder = CType(objShell.NameSpace(FolderPath.ToString), Shell32.Folder)
        Label4.Text = objFolder.GetDetailsOf(objFolder.ParseName(FileName), 28) + objFolder.GetDetailsOf(objFolder.ParseName(FileName), 33)
        musicdb2.bitrate = Label4.Text.ToString

#End Region

#Region "Tags avançadas Para todos os formatos suportados & sua manípulação"

        If Player.LoadID3Ex(info, True) Then
            musicdb2.title = info.Title
            If info.Title = "" Then
                musicdb2.title = OpenFileDialog1.FileName
            End If
            musicdb2.artist = info.Artist
            If info.Artist = "" Then
                musicdb2.artist = "Não existem TAGS disponíveis."
            End If
            musicdb2.album = info.Album
            musicdb2.filename = OpenFileDialog1.FileName
            Form2.ListBox1.Items.Add(info.Title + " by " + info.Artist)
            Label1.Text = info.Title
            infotxt = "Album " + info.Album + " by " + info.Artist
            infotxt = infotxt.Replace("&", "&&") 'Os "&" não aparecem corretamente se a string não for editada
            Label2.Text = infotxt
            PictureBox4.Image = info.Picture.Bitmap
            'this.BlurApply(BlurRadius, New TimeSpan(0, 0, 1), TimeSpan.Zero);
            Dim StreamInfo As New TStreamInfo()
            Player.GetStreamInfo(StreamInfo) 'StreamInfo > ZPlay
            Label6.Text = Format(StreamInfo.Length.hms.hour, "00") & ":" & Format(StreamInfo.Length.hms.minute, "00") & ":" & Format(StreamInfo.Length.hms.second, "00") & "," & Format(StreamInfo.Length.hms.millisecond, "00")
            Label3.Text = StreamInfo.Description
#Region "tags"
            Select Case Label3.Text
                Case "FLAC STEREO"
                    Label3.Text = "FLAC"
                Case "MPEG 1 LAYER III JOINT STEREO"
                    Label3.Text = "MP3"
                Case "MPEG 1 LAYER III STEREO"
                    Label3.Text = "MP3"
                Case Else
                    Label3.Text = "OTHER"
#End Region
            End Select

            'IMPORTANTE: CÓDIGO DA PROGRESSBAR:

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = CInt(Fix(StreamInfo.Length.sec))
            ProgressBar1.Value = 0
        End If

#End Region



        If playpause = False Then
            Button5.PerformClick() 'Faz play da música mesmo que esteja no pause quando se abre um novo ficheiro
        Else
            Player.StartPlayback()
        End If
        musicdb2.filetype = Label3.Text
        Dim n As Integer = musicdb2.Escreve_MusicDB
        If n > 0 Then
        End If
Skip:
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Select Case info.Title
            Case Nothing
                MessageBox.Show("No music in the player! Add one to see the magic happens!")
            Case Else
                If playpause Then
                    Player.PausePlayback()
                    Button5.BackgroundImage = My.Resources.play_icon
                    playpause = False
                Else
                    Player.StartPlayback()
                    Button5.BackgroundImage = My.Resources.pause_icon
                    playpause = True
                End If
        End Select

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Form2.Show() 'Playlist
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim pos As New TStreamTime()
        Player.GetPosition(pos)

        If ProgressBar1.Maximum > CInt(Fix(pos.sec)) Then
            ProgressBar1.Value = CInt(Fix(pos.sec))
        End If

        Label5.Text = Format(pos.hms.hour, "00") & ":" & Format(pos.hms.minute, "00") & ":" & Format(pos.hms.second, "00") & "," & Format(pos.hms.millisecond, "000")

    End Sub

#Region "Progressbar Interativa"

    Private Sub ProgressBar1_MouseClick(sender As Object, e As MouseEventArgs) Handles ProgressBar1.MouseClick
        Dim newpos As New TStreamTime()
        Dim StreamInfo As New TStreamInfo()
        Player.GetStreamInfo(StreamInfo)
        newpos.sec = CUInt(e.X * StreamInfo.Length.sec / CDbl((CType(sender, ProgressBar)).Size.Width))
        Player.Seek(TTimeFormat.tfSecond, newpos, TSeekMethod.smFromBeginning)
    End Sub

#End Region

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Player.GetStatus(GetStatus)
        OpenFileDialog1.FileName = Nothing

#Region "Erros do OFD"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MessageBox.Show("Invalid file or cancelled operation. If this error persists, consult Help.")
        Else
            If String.IsNullOrEmpty(OpenFileDialog1.FileName) Then
                MessageBox.Show("You need to enter a file path and/or a name first")
                Exit Sub
            End If
        End If

#End Region

        Select Case GetStatus.fPlay

            Case True
                Player.AddFile(OpenFileDialog1.FileName, TStreamFormat.sfAutodetect)
            Case False
                Player.OpenFile(OpenFileDialog1.FileName, TStreamFormat.sfAutodetect)
        End Select

#Region "Tags Básicas para MP3 & Utilização do Shell32 para obter o bitrate"


        MP3Tags = mfcReadID3v2Tag.ReadID3v2Tag(OpenFileDialog1.FileName) 'Ler Tags do ficheiro OFD
        Dim FolderPath As String = IO.Path.GetDirectoryName(OpenFileDialog1.FileName)
        Dim FileName As String = IO.Path.GetFileName(OpenFileDialog1.FileName)
        Dim objShell As Shell32.Shell = CType(CreateObject("Shell.Application"), Shell32.Shell)
        Dim objFolder As Shell32.Folder = CType(objShell.NameSpace(FolderPath.ToString), Shell32.Folder)
        Label4.Text = objFolder.GetDetailsOf(objFolder.ParseName(FileName), 28) + objFolder.GetDetailsOf(objFolder.ParseName(FileName), 33)

#End Region

#Region "Tags avançadas Para todos os formatos suportados & sua manípulação"

        If Player.LoadID3Ex(info, True) Then
            Form2.ListBox1.Items.Add(info.Title + " by " + info.Artist)
            Label1.Text = info.Title
            infotxt = "Album " + info.Album + " by " + info.Artist
            infotxt = infotxt.Replace("&", "&&") 'Os "&" não aparecem corretamente se a string não for editada
            Label2.Text = infotxt
            PictureBox4.Image = info.Picture.Bitmap
            Dim StreamInfo As New TStreamInfo()
            Player.GetStreamInfo(StreamInfo) 'StreamInfo > ZPlay
            Label6.Text = Format(StreamInfo.Length.hms.hour, "00") & ":" & Format(StreamInfo.Length.hms.minute, "00") & ":" & Format(StreamInfo.Length.hms.second, "00") & "," & Format(StreamInfo.Length.hms.millisecond, "000")
            Label3.Text = StreamInfo.Description
#Region "tags"
            Select Case Label3.Text
                Case "FLAC STEREO"
                    Label3.Text = "FLAC"
                Case "MPEG 1 LAYER III JOINT STEREO"
                    Label3.Text = "MP3"
                Case "MPEG 1 LAYER III STEREO"
                    Label3.Text = "MP3"
                Case Else
                    Label3.Text = "OTHER"
#End Region
            End Select

            'IMPORTANTE: CÓDIGO DA PROGRESSBAR:

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = CInt(Fix(StreamInfo.Length.sec))
            ProgressBar1.Value = 0
        End If

#End Region

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If info.Title = "" Then info.Title = OpenFileDialog1.FileName.ToString
        Select Case info.Title
            Case Nothing
                MessageBox.Show("You need to add a music to the player to add it in the database... right?")
            Case Else
                Dim inputboxpln As Object
                inputboxpln = InputBox("Playlist Name? (If it doesn't exist, it will create a new one)", "Adding a song to a Playlist", "New Playlist")
                Try
                    Dim pldb As New PlaylistDB
                    Dim PLCheck As New PlaylistX
                    PLCheck.LeFicha(inputboxpln.ToString)
                    If PLCheck.achou = "yep" Then 'SE FOR REPETIDA
                        pldb.idmusic = musicdb2.IdMax_MusicDB()
                        pldb.idplaylist = PLCheck.playlistid
                        pldb.title = info.Title
                        pldb.path = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
                        pldb.artist = info.Artist
                        Dim n As Integer = pldb.Escreve_PlaylistDB
                        If n > 0 Then

                        End If
                    Else 'SE NÃO FOR REPETIDA

                        PLCheck.playlistid = inputboxpln.ToString
                        If inputboxpln = "" Then
                            'proteção código
                        Else
                            Dim pathrapido = System.IO.Path.GetDirectoryName(OpenFileDialog1.FileName).ToString
                            PLCheck.playlistpath = pathrapido
                            PLCheck.Escreve_PlaylistX()
                        End If
                        pldb.idmusic = musicdb2.IdMax_MusicDB()
                        pldb.idplaylist = PLCheck.playlistid
                        pldb.title = info.Title
                        pldb.path = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
                        pldb.artist = info.Artist
                        Dim n As Integer = pldb.Escreve_PlaylistDB
                        If n > 0 Then

                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Introduziu valores inválidos. Operação cancelada!")
                End Try
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case Form2.Visible
            Case True
                Form2.Visible = False
            Case False
                Form2.Visible = True
        End Select
    End Sub

    Private Sub EqualizerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EqualizerToolStripMenuItem.Click
        Form3.Visible = True
    End Sub

    Private Sub PitchControlerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PitchControlerToolStripMenuItem.Click
        Form4.Visible = True
    End Sub

    Private Sub FXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FXToolStripMenuItem.Click
        Form5.Visible = True
    End Sub

    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click
        Button3.PerformClick()
    End Sub

    Private Sub SaveOnPlaylistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveOnPlaylistToolStripMenuItem.Click
        Button2.PerformClick()
    End Sub

    Private Sub VisualizerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizerToolStripMenuItem.Click
        Form6.Visible = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form3.Visible = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        form7.visible = True
    End Sub

    Private Sub PlayHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayHistoryToolStripMenuItem.Click
        Form8.Visible = True
    End Sub

    Private Sub AjudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjudaToolStripMenuItem.Click
        Help.ShowHelp(Me, Application.StartupPath & "\FXVMusicPlayer.chm")
    End Sub
End Class
