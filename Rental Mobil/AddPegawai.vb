Imports MySql.Data.MySqlClient
Imports MaterialSkin
Public Class AddPegawai

    Public cm As New MySqlCommand
    Public dr As MySqlDataReader
    Dim str As String = "datasource=localhost;port=3306;username=root;password=;database=rental_mobil"
    Dim con As New MySqlConnection(str)


    Private Sub btnAddContact_Click(sender As Object, e As EventArgs) Handles btnAddContact.Click

        con.Open()
        If txtNamaPegawai.Text = "" Or txtEmail.Text = "" Or txtAlamat.Text = "" Or txtUsername.Text = "" Or txtPassword.Text = "" Then
            Bunifu.Snackbar.Show(Me, "Lengkapi semua kolom terlebih dahulu", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dimiss")

        Else
            cm = New MySqlCommand("Select * FROM pegawai where nama = '" & txtNamaPegawai.Text & "'", con)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Bunifu.Snackbar.Show(Me, txtNamaPegawai.Text.Trim + " Telah Terdaftar", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dismiss")
            Else
                Tambah()
            End If
        End If
        con.Close()

    End Sub

    Sub Tambah()

        Dim SqlTrans As MySqlTransaction = Conn.BeginTransaction
        Dim CmdTrans As MySqlCommand = Conn.CreateCommand

        Try
            With CmdTrans

                If MsgBox("Yakin akan di tambahkan?", vbQuestion + vbYesNo, "Insert Record") = vbYes Then
                    .CommandText = "insert_pegawai"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Conn
                    .Transaction = SqlTrans
                    .Parameters.Add("in_id_pegawai", MySqlDbType.Int64, 255)
                    .Parameters.Add("in_nama_pegawai", MySqlDbType.VarChar, 30).Value = txtNamaPegawai.Text
                    .Parameters.Add("in_email_pegawai", MySqlDbType.VarChar, 30).Value = txtEmail.Text
                    .Parameters.Add("in_alamat_pegawai", MySqlDbType.VarChar, 30).Value = txtAlamat.Text
                    .Parameters.Add("in_username_pegawai", MySqlDbType.VarChar, 30).Value = txtUsername.Text
                    .Parameters.Add("in_password_pegawai", MySqlDbType.VarChar, 30).Value = txtPassword.Text
                    .Parameters.Add("in_mulaibekerja", MySqlDbType.Timestamp, 7)
                    .ExecuteNonQuery()
                    SqlTrans.Commit()
                    Bunifu.Snackbar.Show(Me, txtNamaPegawai.Text.Trim + " Berhasil di Tambahkan", 4000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
                    Menu_Admin.LoadDataPegawai()
                End If

            End With

        Catch ex As Exception
            SqlTrans.Rollback()
            Bunifu.Snackbar.Show(Me, "Data Gagal di tambahkan", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
        Finally
            Clear()
            SqlTrans.Dispose()
            CmdTrans.Dispose()
        End Try

    End Sub

    Sub Clear()
        txtNamaPegawai.Text = ""
        txtEmail.Text = ""
        txtAlamat.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Sub btnCancelPegawai_Click(sender As Object, e As EventArgs) Handles btnCancelPegawai.Click
        Me.Dispose()
        TransparentBg.Close()
    End Sub

    Private Sub AddPegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call BukaConn()
        Dim skinManager As MaterialSkinManager = MaterialSkinManager.Instance
        skinManager.AddFormToManage(Me)
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT
        skinManager.ColorScheme = New ColorScheme(Primary.Blue900, Primary.Blue700, Primary.Blue900, Accent.LightBlue200, TextShade.WHITE)

    End Sub

    Private Sub btnUpdatePegawai_Click(sender As Object, e As EventArgs) Handles btnUpdatePegawai.Click

        Try
            If MsgBox("Update this record?", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cm = New MySqlCommand("update pegawai set nama = '" & txtNamaPegawai.Text & "', email = '" & txtEmail.Text & "', alamat ='" & txtAlamat.Text & "', username ='" & txtUsername.Text & "', password = '" & txtPassword.Text & "'", con)
                cm.ExecuteNonQuery()
                Bunifu.Snackbar.Show(Me, txtNamaPegawai.Text.Trim + " Berhasil di Update", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
                Menu_Admin.LoadDataPegawai()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        Finally
            Clear()
            con.Close()
        End Try

    End Sub
End Class