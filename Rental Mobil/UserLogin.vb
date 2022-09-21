Imports MySql.Data.MySqlClient
Imports System.Data
Imports Common
Public Class UserLogin

    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=rental_mobil")

    Public Function LoginAdmin(user As String, pass As String) As Boolean

        connection.Open()
        Using Command = New MySqlCommand()
            Command.Connection = connection
            Command.CommandText = "SELECT * FROM `ADMIN` WHERE `USERNAME` = @username AND `PASSWORD` = @password"
            Command.Parameters.AddWithValue("@username", user)
            Command.Parameters.AddWithValue("@password", pass)
            Command.CommandType = CommandType.Text

            Dim reader = Command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    ActiveUser.id = reader.GetInt64(0)
                    ActiveUser.nama = reader.GetString(1)
                End While
                reader.Dispose()
                Return True
            Else
                Return False
            End If
        End Using
        'connection.Close()
    End Function

    Public Function LoginPegawai(user As String, pass As String) As Boolean
        connection.Open()
        Using Command = New MySqlCommand()
            Command.Connection = connection
            Command.CommandText = "SELECT * FROM `PEGAWAI` WHERE `USERNAME` = @username AND `PASSWORD` = @password"
            Command.Parameters.AddWithValue("@username", user)
            Command.Parameters.AddWithValue("@password", pass)
            Command.CommandType = CommandType.Text

            Dim reader = Command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    ActivePegawai.id = reader.GetInt64(0)
                    ActivePegawai.nama = reader.GetString(1)
                End While
                reader.Dispose()
                Return True
            Else
                Return False
            End If
        End Using
        'connection.Close()
    End Function


End Class
