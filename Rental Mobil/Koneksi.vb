Imports MySql.Data.MySqlClient

Module koneksi


    Public DtAdpt As MySqlDataAdapter
    Public dr As MySqlDataReader
    Public cm As MySqlCommand
    Public Dtset As DataSet
    Dim str As String
    Public Conn As MySqlConnection

    Sub BukaConn()
        Try
            str = "Server=localhost;Database=game;Uid=root;Pwd=;Port=3306"
            Conn = New MySqlConnection(str)
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Function GenerateTrans() As String

    '    Dim str As String
    '    Dim Query As String = "Select Max(no_transaksi) from peminjaman"
    '    Dim Command As New MySqlCommand(Query, Conn)
    '    DtAdpt = New MySqlDataAdapter(Command)
    '    Dim Builder As New MySqlCommandBuilder(DtAdpt)
    '    Conn.Open()
    '    dr = Command.ExecuteReader
    '    If IsDBNull(Command.ExecuteScalar) Then
    '            str = "10001"
    '        Else
    '            str = Command.ExecuteScalar + 1
    '        End If
    '        Conn.Close()
    '    Return str

    'End Function

    Function GenerateTrans() As String

        Dim str As String
        cm = New MySqlCommand("SELECT max(no_transaksi) from peminjaman", Conn)

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        If IsDBNull(cm.ExecuteScalar) Then
            str = "10001"
        Else
            str = cm.ExecuteScalar + 1
        End If
        Conn.Close()
        Return str

    End Function

    Public Function IS_EMPTY(ByRef sText As Object) As Boolean
        On Error Resume Next
        If sText.Text = "" Then
            IS_EMPTY = True
            MsgBox("Warning: Required missing field.", vbExclamation)
            sText.BackColor = Color.LemonChiffon
            sText.SetFocus()
        Else
            IS_EMPTY = False
            sText.BackColor = Color.White
        End If
        Return IS_EMPTY
    End Function

    'Public Sub konek(ByVal a As String,
    '                 ByVal b As String,
    '                 ByVal c As String,
    '                 ByVal d As String,
    '                 ByVal e As String)
    '    Dim Connstr As String
    '    Connstr = "server=" & a & ";" _
    '        & "port=" & b & ";user=" & c & ";" _
    '        & "password='" & d & "';" _
    '        & "database=" & e
    '    Conn = New MySqlConnection(Connstr)
    '    Conn.Open()
    'End Sub



    'Public Conn As MySqlConnection
    'Public Sub konek(ByVal a As String,
    '                 ByVal b As String,
    '                 ByVal c As String,
    '                 ByVal d As String,
    '                 ByVal e As String)
    '    Dim Connstr As String
    '    Connstr = "server=" & a & ";" _
    '        & "port=" & b & ";user=" & c & ";" _
    '        & "password='" & d & "';" _
    '        & "database=" & e
    '    Conn = New MySqlConnection(Connstr)
    '    Conn.Open()
    'End Sub


    'Sub Connection()
    '    With cn
    '        .ConnectionString = "server=localhost;user id=root;password=;database=rental_mobil;"
    '        .Open()
    '        .Close()
    '    End With
    'End Sub

    'Function GenerateTrans() As String

    '    Dim str As String
    '    cn.Open()
    '    cm = New MySqlCommand("SELECT MAX (no_transaksi) peminjaman", cn)
    '    If IsDBNull(cm.ExecuteScalar) Then
    '        str = "10001"
    '    Else
    '        str = cm.ExecuteScalar + 1
    '    End If
    '    cn.Close()
    '    Return str

    'End Function

End Module


