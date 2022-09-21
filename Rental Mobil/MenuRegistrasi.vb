Imports MySql.Data.MySqlClient
Public Class MenuRegistrasi

    Public cm As New MySqlCommand
    Public dr As MySqlDataReader
    Dim str As String = "datasource=localhost;port=3306;username=root;password=;database=game"
    Dim con As New MySqlConnection(str)

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Hide()
        MenuLogin.Show()
    End Sub

    Private Sub btnDaftar_Click(sender As Object, e As EventArgs) Handles btnDaftar.Click
        con.Open()
        'If txtNama.Text = "" Or txtEmail.Text = "" Or txtUsername.Text = "" Or txtPassword.Text Then
        '    Bunifu.Snackbar.Show(Me, "Lengkapi semua kolom terlebih dahulu", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dimiss")

        'Else
        '    cm = New MySqlCommand("Select * FROM user where email = '" & txtEmail.Text & "'", con)
        '    dr = cm.ExecuteReader
        '    dr.Read()
        '    If dr.HasRows Then
        '        Bunifu.Snackbar.Show(Me, txtEmail.Text.Trim + " Telah Terdaftar", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dismiss")
        '    Else
        Tambah()
        'End If
        'End If
        'con.Close()

    End Sub

    Sub Tambah()

        Dim SqlTrans As MySqlTransaction = Conn.BeginTransaction
        Dim CmdTrans As MySqlCommand = Conn.CreateCommand

        Try
            With CmdTrans

                If MsgBox("Yakin akan di tambahkan?", vbQuestion + vbYesNo, "Delete Record") = vbYes Then
                    .CommandText = "data_user"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Conn
                    .Transaction = SqlTrans
                    .Parameters.Add("in_id", MySqlDbType.Int64, 11)
                    .Parameters.Add("in_nama", MySqlDbType.VarChar, 25).Value = txtNama.Text
                    .Parameters.Add("in_email", MySqlDbType.VarChar, 25).Value = txtEmail.Text
                    .Parameters.Add("in_username", MySqlDbType.VarChar, 25).Value = txtUsername.Text
                    .Parameters.Add("in_password", MySqlDbType.VarChar, 25).Value = txtPassword.Text
                    .Parameters.Add("in_created_At", MySqlDbType.Timestamp, 7)
                    .ExecuteNonQuery()
                    SqlTrans.Commit()
                    Bunifu.Snackbar.Show(Me, txtNama.Text.Trim + " Berhasil di Tambahkan", 4000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
                    Menu_Admin.LoadDataAdmin()

                End If

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            SqlTrans.Rollback()
            Bunifu.Snackbar.Show(Me, "Data Gagal di tambahkan", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
        Finally
            SqlTrans.Dispose()
            CmdTrans.Dispose()
        End Try

    End Sub
End Class