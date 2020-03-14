Imports System.Data.SQLite
Public Class MusicDB
    Private _num As Integer
    Private _title As String
    Private _artist As String
    Private _album As String
    Private _filetype As String
    Private _bitrate As String
    Private _filename As String

    Dim MusicDB As String = Application.UserAppDataPath + "\MusicDB.db3"

#Region "propriedades"
    Public Property num() As Integer
        Get

            Return _num
        End Get
        Set(ByVal value As Integer)
            _num = value
        End Set
    End Property
    Public Property artist() As String
        Get
            Return _artist
        End Get
        Set(ByVal value As String)
            _artist = value
        End Set
    End Property
    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property
    Public Property album() As String
        Get
            Return _album
        End Get
        Set(ByVal value As String)
            _album = value
        End Set
    End Property
    Public Property filetype() As String
        Get
            Return _filetype
        End Get
        Set(ByVal value As String)
            _filetype = value
        End Set
    End Property
    Public Property bitrate() As String
        Get
            Return _bitrate
        End Get
        Set(ByVal value As String)
            _bitrate = value
        End Set
    End Property
    Public Property filename() As String
        Get
            Return _filename
        End Get
        Set(ByVal value As String)
            _filename = value
        End Set
    End Property

#End Region

#Region "contrutores"
    Public Sub New()
        _num = 0
        _title = ""
        _artist = ""
        _album = ""
        _filetype = ""
        _bitrate = ""
        _filename = ""
    End Sub

    Public Sub criaDB()

        Dim strSQL As String
        Dim SqlCmd As New SQLite.SQLiteCommand
        Dim Conexao As New SQLite.SQLiteConnection

        If Not IO.File.Exists(MusicDB) Then
            Try
                SQLiteConnection.CreateFile(MusicDB)
                Conexao.ConnectionString = "Data Source=" + MusicDB + "; Version=3"
                Conexao.Open()
                SqlCmd = Conexao.CreateCommand

                strSQL = "CREATE TABLE MusicDB(ID INTEGER PRIMARY KEY ASC, num INTEGER, title TEXT, artist TEXT, album TEXT, filetype TEXT," +
                    " bitrate TEXT, filename TEXT);"
                SqlCmd.CommandText = strSQL
                SqlCmd.ExecuteNonQuery()
                Conexao.Dispose()
            Catch ex As Exception
                MessageBox.Show("Erro ao criar Base de Dados MusicDB")
            End Try
        End If

    End Sub
#End Region

#Region "trabalhando com MusicDB"
    Public Function LeFicha(ByVal ID As Integer) As Integer

        Using conexao As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
            conexao.ConnectionString = "Data Source=" + MusicDB + "; Version=3"
            'abre a conexão
            conexao.Open()
            Dim tr1 As SQLite.SQLiteTransaction = conexao.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)

            Try
                'cria um comando
                Dim SqlCmd As New SQLite.SQLiteCommand
                SqlCmd = conexao.CreateCommand
                SqlCmd.Transaction = tr1
                'define a instrução sql
                Dim whereQuery As String = "SELECT * FROM MusicDB WHERE ID = " & ID.ToString
                'executa o comando e retorna um datareader
                SqlCmd.CommandText = whereQuery
                Dim SQLreader As SQLiteDataReader = SqlCmd.ExecuteReader()
                tr1.Commit()
                'os dados da ficha vão ficar disponíveis nas propriedades da classe
                While SQLreader.Read()
                    _num = SQLreader("num")
                    _title = SQLreader("title")
                    _artist = SQLreader("artist")
                    _album = SQLreader("album")
                    _filetype = SQLreader("filetype")
                    _bitrate = SQLreader("bitrate")
                    _filename = SQLreader("filename")
                End While
                SqlCmd.Dispose()
                conexao.Close()
                Return 1
            Catch ex As Exception
                tr1.Rollback()
                MessageBox.Show("Erro de leitura/escrita B.D.")
                conexao.Close()
                Return -1
            End Try
        End Using

    End Function
    Public Function IdMax_MusicDB() As Integer

        If System.IO.File.Exists(MusicDB) = False Then
            criaDB()
        End If

        Dim n_trab As Integer
        Try

            Using conexao As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
                conexao.ConnectionString = "Data Source=" + MusicDB + "; Version=3"
                'abre a conexão
                conexao.Open()

                Dim tr1 As SQLite.SQLiteTransaction = conexao.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
                'se houver ficheiro então lê os dados

                'Lê a última linha e acrescenta o ID +1
                Dim strSQL As String = "SELECT  max(ID) FROM MusicDB"
                Dim SqlCmd As New SQLite.SQLiteCommand
                SqlCmd = conexao.CreateCommand
                SqlCmd.Transaction = tr1
                SqlCmd.CommandText = strSQL
                Try
                    n_trab = SqlCmd.ExecuteScalar
                    tr1.Commit()
                Catch ex As Exception
                    n_trab = -1
                    tr1.Rollback()
                    tr1.Dispose()
                    Return n_trab
                End Try

                ' ***** Comando SQL bem feito
                tr1.Dispose()
                conexao.Dispose()
            End Using
        Catch ex As Exception
            n_trab = -1
            MessageBox.Show("Erro!")
        End Try
        Return n_trab
    End Function
    Public Function Escreve_MusicDB() As Integer

        If System.IO.File.Exists(MusicDB) = False Then
            criaDB()
        End If

        Dim n_trab As Integer
        Try
            Using conexao As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
                conexao.ConnectionString = "Data Source=" + MusicDB + "; Version=3"
                'abre a conexão
                conexao.Open()

                Dim tr1 As SQLite.SQLiteTransaction = conexao.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
                'se houver ficheiro então lê os dados

                'Lê a última linha e acrescenta o ID +1
                Dim strSQL As String = "SELECT  max(ID) FROM MusicDB"
                Dim SqlCmd As New SQLite.SQLiteCommand
                SqlCmd = conexao.CreateCommand
                SqlCmd.Transaction = tr1
                SqlCmd.CommandText = strSQL
                Try
                    n_trab = SqlCmd.ExecuteScalar
                    tr1.Commit()
                Catch ex As Exception
                    n_trab = 0
                    tr1.Rollback()
                End Try
                n_trab = n_trab + 1
                ' ***** Comando SQL bem feito
                tr1.Dispose()
                conexao.Dispose()
            End Using

            Using conexao2 As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
                conexao2.ConnectionString = "Data Source=" + MusicDB + "; Version=3"
                'abre a conexão
                conexao2.Open()

                Dim tr1 As SQLite.SQLiteTransaction = conexao2.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
                'novo comando e conexão - inserir dados
                Dim strSQL As String = "INSERT INTO MusicDB (ID,num,title,artist,album," +
                                "filetype,bitrate,filename) VALUES (@id, @num, @title, @artist, @album, @filetype, @bitrate, @filename)"

                Dim cmdTarefa As New SQLite.SQLiteCommand
                cmdTarefa = conexao2.CreateCommand
                cmdTarefa.Transaction = tr1

                With cmdTarefa
                    .Parameters.AddWithValue("@id", n_trab)
                    .Parameters.AddWithValue("@num", num)
                    .Parameters.AddWithValue("@title", title)
                    .Parameters.AddWithValue("@artist", artist)
                    .Parameters.AddWithValue("@album", album)
                    .Parameters.AddWithValue("@filetype", filetype)
                    .Parameters.AddWithValue("@bitrate", bitrate)
                    .Parameters.AddWithValue("@filename", filename)
                End With
                Try
                    cmdTarefa.CommandText = strSQL
                    cmdTarefa.ExecuteNonQuery()
                    tr1.Commit()
                    cmdTarefa.Dispose()
                    conexao2.Dispose()
                Catch ex As Exception
                    tr1.Rollback()
                    MessageBox.Show("Erro de leitura/escrita B.D.")
                    cmdTarefa.Dispose()
                    conexao2.Dispose()
                    Return -1
                End Try

                'retorna o ID 
                Return n_trab
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro de leitura/escrita B.D.")
            Return -1
        End Try
    End Function
    Public Sub ApagaFicha(ByRef i As Integer)
        Using conexao2 As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
            conexao2.ConnectionString = "Data Source=" + MusicDB + "; Version=3"
            'abre a conexão
            conexao2.Open()
            Dim tr1 As SQLite.SQLiteTransaction = conexao2.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
            Try
                Dim Sql As String = "delete from MusicDB where ID ='" + i.ToString + "'"
                Dim daUtilizador2 As SQLite.SQLiteDataAdapter = New SQLite.SQLiteDataAdapter(Sql, conexao2)
                daUtilizador2.DeleteCommand = conexao2.CreateCommand
                daUtilizador2.DeleteCommand.Transaction = tr1
                daUtilizador2.DeleteCommand.CommandText = Sql
                daUtilizador2.DeleteCommand.ExecuteNonQuery()
                tr1.Commit()
                daUtilizador2.Dispose()
                conexao2.Dispose()
            Catch ex As Exception
                tr1.Rollback()
                conexao2.Close()
                MessageBox.Show("Erro de leitura/escrita B.D.")
            End Try
        End Using
    End Sub
    Public Function Le_TelefoneDataset(ByVal f As Form) As DataSet

        If System.IO.File.Exists(MusicDB) = False Then
            criaDB()
        End If

        Try
            Dim dx As DataSet = New DataSet
            Dim conexao As New SQLite.SQLiteConnection
            conexao.ConnectionString = "Data Source=" + MusicDB + "; Version=3"
            conexao.Open()
            Dim sqlStr As String = "SELECT * from MusicDB"
            Dim daUtilizador As SQLite.SQLiteDataAdapter = New SQLite.SQLiteDataAdapter(sqlStr, conexao)
            daUtilizador.Fill(dx)
            daUtilizador.Dispose()
            conexao.Dispose()
            Return dx
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Sub AtualizaDataGridView(ByRef dx As DataSet)
        Dim conexao As New SQLite.SQLiteConnection
        conexao.ConnectionString = "Data Source=" + MusicDB + "; Version=3"
        conexao.Open()
        Try
            Dim sqlStr As String = "SELECT * from MusicDB"
            Dim daUtilizador As SQLite.SQLiteDataAdapter = New SQLite.SQLiteDataAdapter(sqlStr, conexao)
            Dim builder As SQLite.SQLiteCommandBuilder = New SQLite.SQLiteCommandBuilder(daUtilizador)
            daUtilizador.Update(dx)
            daUtilizador.Dispose()
            conexao.Dispose()
            MessageBox.Show("Gravou com sucesso!")
        Catch ex As Exception
            MessageBox.Show("Erro de leitura/escrita B.D.")
            conexao.Dispose()
        End Try

    End Sub

#End Region

End Class