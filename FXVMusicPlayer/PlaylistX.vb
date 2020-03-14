Imports System.Data.SQLite
Public Class PlaylistX
    Private _playlistid As String
    Private _playlistpath As String
    Public achou As String

    Dim PlaylistX As String = Application.UserAppDataPath + "\PlaylistX.db3"

#Region "propriedades"
    Public Property playlistid() As String
        Get

            Return _playlistid
        End Get
        Set(ByVal value As String)
            _playlistid = value
        End Set
    End Property
    Public Property playlistpath() As String
        Get
            Return _playlistpath
        End Get
        Set(ByVal value As String)
            _playlistpath = value
        End Set
    End Property

#End Region

#Region "contrutores"
    Public Sub New()
        _playlistid = ""
        _playlistpath = ""
    End Sub

    Public Sub criaDB()

        Dim strSQL As String
        Dim SqlCmd As New SQLite.SQLiteCommand
        Dim Conexao As New SQLite.SQLiteConnection

        If Not IO.File.Exists(PlaylistX) Then
            Try
                SQLiteConnection.CreateFile(PlaylistX)
                Conexao.ConnectionString = "Data Source=" + PlaylistX + "; Version=3"
                Conexao.Open()
                SqlCmd = Conexao.CreateCommand

                strSQL = "CREATE TABLE PlaylistX(ID INTEGER PRIMARY KEY ASC, playlistid TEXT, playlistpath TEXT);"
                SqlCmd.CommandText = strSQL
                SqlCmd.ExecuteNonQuery()
                Conexao.Dispose()
            Catch ex As Exception
                MessageBox.Show("Erro ao criar Base de Dados PlaylistX")
            End Try
        End If

    End Sub
#End Region

#Region "trabalhando com PlaylistDB"
    Public Function LeFicha(ByVal ID As String) As String

        Using conexao As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
            conexao.ConnectionString = "Data Source=" + PlaylistX + "; Version=3"
            'abre a conexão
            conexao.Open()
            Dim tr1 As SQLite.SQLiteTransaction = conexao.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)

            Try
                'cria um comando
                Dim SqlCmd As New SQLite.SQLiteCommand
                SqlCmd = conexao.CreateCommand
                SqlCmd.Transaction = tr1
                'define a instrução sql
                Dim whereQuery As String = "SELECT * FROM PlaylistX WHERE playlistid = " & ID.ToString
                'executa o comando e retorna um datareader
                SqlCmd.CommandText = whereQuery
                Dim mytable As New DataTable
                Dim SQLreader As SQLiteDataReader = SqlCmd.ExecuteReader()
                tr1.Commit()
                    'os dados da ficha vão ficar disponíveis nas propriedades da classe
                    While SQLreader.Read()
                        _playlistid = SQLreader("playlistid")
                        _playlistpath = SQLreader("playlistpath")
                    End While
                    SqlCmd.Dispose()
                    conexao.Close()
                    achou = "yep"
                Return 1
            Catch ex As Exception
                tr1.Rollback()
                conexao.Close()
                achou = "nope"
                Return -1
            End Try
        End Using
        Return Nothing
    End Function
    Public Function IdMax_PlaylistX() As Integer

        If System.IO.File.Exists(PlaylistX) = False Then
            criaDB()
        End If

        Dim n_trab As Integer
        Try

            Using conexao As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
                conexao.ConnectionString = "Data Source=" + PlaylistX + "; Version=3"
                'abre a conexão
                conexao.Open()

                Dim tr1 As SQLite.SQLiteTransaction = conexao.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
                'se houver ficheiro então lê os dados

                'Lê a última linha e acrescenta o ID +1
                Dim strSQL As String = "SELECT  max(ID) FROM PlaylistX"
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
    Public Function Escreve_PlaylistX() As Integer

        If System.IO.File.Exists(PlaylistX) = False Then
            criaDB()
        End If

        Dim n_trab As Integer
        Try
            Using conexao As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
                conexao.ConnectionString = "Data Source=" + PlaylistX + "; Version=3"
                'abre a conexão
                conexao.Open()

                Dim tr1 As SQLite.SQLiteTransaction = conexao.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
                'se houver ficheiro então lê os dados

                'Lê a última linha e acrescenta o ID +1
                Dim strSQL As String = "SELECT  max(ID) FROM PlaylistX"
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

            Using conexao3 As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
                conexao3.ConnectionString = "Data Source=" + PlaylistX + "; Version=3"
                'abre a conexão
                conexao3.Open()

                Dim tr1 As SQLite.SQLiteTransaction = conexao3.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
                'novo comando e conexão - inserir dados
                Dim strSQL As String = "INSERT INTO PlaylistX (ID,playlistid,playlistpath) VALUES (@id, @playlistid, @playlistpath)"

                Dim cmdTarefa As New SQLite.SQLiteCommand
                cmdTarefa = conexao3.CreateCommand
                cmdTarefa.Transaction = tr1

                With cmdTarefa
                    .Parameters.AddWithValue("@id", n_trab)
                    .Parameters.AddWithValue("@playlistid", playlistid)
                    .Parameters.AddWithValue("@playlistpath", playlistpath)
                End With
                Try
                    cmdTarefa.CommandText = strSQL
                    cmdTarefa.ExecuteNonQuery()
                    tr1.Commit()
                    cmdTarefa.Dispose()
                    conexao3.Dispose()
                Catch ex As Exception
                    tr1.Rollback()
                    cmdTarefa.Dispose()
                    conexao3.Dispose()
                    Return -1
                End Try

                'retorna o ID 
                Return n_trab
            End Using

        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Sub ApagaFicha(ByRef i As Integer)
        Using conexao2 As SQLite.SQLiteConnection = New SQLite.SQLiteConnection
            conexao2.ConnectionString = "Data Source=" + PlaylistX + "; Version=3"
            'abre a conexão
            conexao2.Open()
            Dim tr1 As SQLite.SQLiteTransaction = conexao2.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
            Try
                Dim Sql As String = "delete from PlaylistDB where ID ='" + i.ToString + "'"
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

        If System.IO.File.Exists(PlaylistX) = False Then
            criaDB()
        End If

        Try
            Dim dx As DataSet = New DataSet
            Dim conexao As New SQLite.SQLiteConnection
            conexao.ConnectionString = "Data Source=" + PlaylistX + "; Version=3"
            conexao.Open()
            Dim sqlStr As String = "SELECT * from PlaylistX"
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
        conexao.ConnectionString = "Data Source=" + PlaylistX + "; Version=3"
        conexao.Open()
        Try
            Dim sqlStr As String = "SELECT * from PlaylistX"
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