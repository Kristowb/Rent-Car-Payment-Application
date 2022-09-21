Public Class UserModel

    Dim UserLogin As New UserLogin()

    Public Function LoginAdmin(user As String, pass As String) As Boolean
        Return UserLogin.LoginAdmin(user, pass)
    End Function

    Public Function LoginPegawai(user As String, pass As String) As Boolean
        Return UserLogin.LoginPegawai(user, pass)
    End Function
End Class
