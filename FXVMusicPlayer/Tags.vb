Imports System.IO

Public Class mfcReadID3v2Tag

    Private Structure mcsFrame
        Dim Tag As String
        Dim Flag As Integer
        Dim Size As Integer
        Dim Data1 As Byte()
        Dim Data2 As String
    End Structure

    Public Shared Function ReadID3v2Tag(ByVal sFilename As String) As mcTrack
        Try
            ' --------------------------------------------------
            Dim oFS As FileStream
            Dim baHeader(15) As Byte
            Dim oTrack As New mcTrack

            ' Load object with file path
            oTrack.Filename = sFilename

            oFS = New FileStream(sFilename, FileMode.Open)

            ' Get first 10 bytes, which holds the header tag, size and version.
            oFS.Read(baHeader, 0, 10)

            If (baHeader(0) = &H49) And (baHeader(1) = &H44) And (baHeader(2) = &H33) Then ' It's a proper MP3

                Dim oFrame As mcsFrame

                ' Start reading tags. I only use 5. There are more!
                oFrame = GetFrame(oFS)
                Do While Not IsNothing(oFrame.Tag)
                    Select Case oFrame.Tag
                        Case "TIT2" : oTrack.Track = oFrame.Data2    ' Song Title
                        Case "TPE1" : oTrack.Artist = oFrame.Data2    ' Artist
                        Case "TALB" : oTrack.Album = oFrame.Data2    ' Album
                        Case "TRCK" : oTrack.CDTrack = CInt(oFrame.Data2.Replace("/", "")) ' CD Track number
                        Case "TCON" : oTrack.Genre = oFrame.Data2    ' Genre Description
                    End Select

                    oFrame = New mcsFrame()
                    oFrame = GetFrame(oFS)
                Loop
            End If
            ReadID3v2Tag = oTrack

            oFS.Close()

            ' --------------------------------------------------
        Catch oError As Exception
            ReadID3v2Tag = Nothing
        End Try

    End Function
    Private Shared Function GetFrame(ByVal oFile As Stream) As mcsFrame
        Try
            ' --------------------------------------------------

            Dim oFrame As New mcsFrame()
            Dim baFrame() As Byte
            Dim oEncoding As New System.Text.ASCIIEncoding()

            ReDim baFrame(5)

            ' Pull frame name
            oFile.Read(baFrame, 0, 4)
            oFrame.Tag = oEncoding.GetString(baFrame)

            If baFrame(0) <> 0 Then
                oFrame.Tag = oFrame.Tag.Substring(0, 4).Trim

                ' Get 4 bytes for frame size
                oFile.Read(baFrame, 0, 4)
                oFrame.Size = (65536 * (baFrame(0) * 256 + baFrame(1))) + (baFrame(2) * 256 + baFrame(3))

                ' Skip padding
                oFile.Read(baFrame, 0, 3)

                If oFrame.Size > 0 Then
                    ReDim baFrame(oFrame.Size + 1)

                    oFile.Read(baFrame, 0, oFrame.Size - 1)
                    oFrame.Data1 = baFrame

                    If oFrame.Tag.Substring(0, 1) = "T" Then
                        oFrame.Data2 = oEncoding.GetString(baFrame).Trim.Replace(Chr(0), "")
                    End If
                End If

                GetFrame = oFrame
            Else
                GetFrame = Nothing
            End If

            ' --------------------------------------------------
        Catch oError As Exception
            GetFrame = Nothing
        End Try

    End Function

End Class

Public Class mcTrack

#Region "Public Declarations"

    Private psAlbum As String = ""            ' dbo.Album.Album_Name
    Private piAlbumID As Integer = 0        ' dbo.Album.Album_ID PK
    Private psArtist As String = ""            ' dbo.Artist.Artist_Name
    Private piArtistID As Integer = 0        ' dbo.Artist.Artist_ID PK
    Private pbBookmarked As Boolean = False
    Private piCDTrack As Integer = 0
    Private psFileName As String = ""
    Private psGenre As String = ""
    Private piID As Integer = 0                ' dbo.Tracks.Track_ID PK
    Private piIndex As Integer = -1            ' Listview index (To enable playing tracks in order regardless of listview's item focus, selections, ect)
    Private piMaxVolume As Integer = 100    ' To allow per-track volume so a particularly loud track can be kicked down a few decibles.
    Private pbPlayed As Boolean = False
    Private psPlayedOn As String = ""
    Private piPlayCount As Integer = 0
    Private psTrack As String = ""

#Region "-- Properties"

    Public Property Album() As String
        <DebuggerStepThrough()> _
        Get
            Album = psAlbum
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sAlbum As String)
            psAlbum = sAlbum
        End Set
    End Property
    Public Property AlbumID() As Integer
        <DebuggerStepThrough()> _
        Get
            AlbumID = piAlbumID
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iAlbumID As Integer)
            piAlbumID = iAlbumID
        End Set
    End Property
    Public Property Artist() As String
        <DebuggerStepThrough()> _
        Get
            Artist = psArtist
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sArtist As String)
            psArtist = sArtist
        End Set
    End Property
    Public Property ArtistID() As Integer
        <DebuggerStepThrough()> _
        Get
            ArtistID = piArtistID
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iArtistID As Integer)
            piArtistID = iArtistID
        End Set
    End Property
    Public Property Bookmarked() As Boolean
        <DebuggerStepThrough()> _
        Get
            Bookmarked = pbBookmarked
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal bBookmarked As Boolean)
            pbBookmarked = bBookmarked
        End Set
    End Property
    Public Property CDTrack() As Integer
        <DebuggerStepThrough()> _
        Get
            CDTrack = piCDTrack
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iCDTrack As Integer)
            piCDTrack = iCDTrack
        End Set
    End Property
    Public Property Filename() As String
        <DebuggerStepThrough()> _
        Get
            Filename = psFileName
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sFileName As String)
            psFileName = sFileName
        End Set
    End Property
    Public Property Genre() As String
        <DebuggerStepThrough()> _
        Get
            Genre = psGenre
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sGenre As String)
            psGenre = sGenre
        End Set
    End Property
    Public Property ID() As Integer
        <DebuggerStepThrough()> _
        Get
            Return piID
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iID As Integer)
            piID = iID
        End Set
    End Property
    Public Property Index() As Integer
        <DebuggerStepThrough()> _
        Get
            Index = piIndex
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iIndex As Integer)
            piIndex = iIndex
        End Set
    End Property
    Public Property MaxVolume() As Integer
        <DebuggerStepThrough()> _
        Get
            MaxVolume = piMaxVolume
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iMaxVolume As Integer)
            piMaxVolume = iMaxVolume
        End Set
    End Property
    Public Property PlayCount() As Integer
        <DebuggerStepThrough()> _
        Get
            PlayCount = piPlayCount
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal iPlayCount As Integer)
            piPlayCount = iPlayCount
        End Set
    End Property
    Public Property Played() As Boolean
        <DebuggerStepThrough()> _
        Get
            Played = pbPlayed
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal bPlayed As Boolean)
            pbPlayed = bPlayed
        End Set
    End Property
    Public Property PlayedOn() As String
        <DebuggerStepThrough()> _
        Get
            PlayedOn = psPlayedOn
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sPlayedOn As String)
            psPlayedOn = sPlayedOn
        End Set
    End Property
    Public Property Track() As String
        <DebuggerStepThrough()> _
        Get
            Track = psTrack
        End Get
        <DebuggerStepThrough()> _
        Set(ByVal sTrack As String)
            psTrack = sTrack
        End Set
    End Property

#End Region

    Public Sub New()
        MyBase.New()
        piID = -1
    End Sub

#End Region

End Class