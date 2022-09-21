Imports MySql.Data.MySqlClient
Imports MaterialSkin

Public Class AddAdmin

    Public cm As New MySqlCommand
    Public dr As MySqlDataReader
    Dim str As String = "datasource=localhost;port=3306;username=root;password=;database=rental_mobil"
    Dim con As New MySqlConnection(str)


    Private Sub btnAddContact_Click(sender As Object, e As EventArgs) Handles btnAddContact.Click

        con.Open()
        If txtNamaAdmin.Text = "" Or txtEmailAdmin.Text = "" Or txtUsername.Text = "" Or txtPassword.Text = "" Then
            Bunifu.Snackbar.Show(Me, "Lengkapi semua kolom terlebih dahulu", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dimiss")

        Else
            cm = New MySqlCommand("Select * FROM Admin where nama = '" & txtNamaAdmin.Text & "'", con)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Bunifu.Snackbar.Show(Me, txtNamaAdmin.Text.Trim + " Telah Terdaftar", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dismiss")
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

                If MsgBox("Yakin akan di tambahkan?", vbQuestion + vbYesNo, "Delete Record") = vbYes Then
                    .CommandText = "insert_admin"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Conn
                    .Transaction = SqlTrans
                    .Parameters.Add("in_id_admin", MySqlDbType.Int64, 11)
                    .Parameters.Add("in_nama_admin", MySqlDbType.VarChar, 25).Value = txtNamaAdmin.Text
                    .Parameters.Add("in_email_admin", MySqlDbType.VarChar, 25).Value = txtEmailAdmin.Text
                    .Parameters.Add("in_username_admin", MySqlDbType.VarChar, 25).Value = txtUsername.Text
                    .Parameters.Add("in_password_admin", MySqlDbType.VarChar, 25).Value = txtPassword.Text
                    .Parameters.Add("in_create_admin", MySqlDbType.Timestamp, 7)
                    .ExecuteNonQuery()
                    SqlTrans.Commit()
                    Bunifu.Snackbar.Show(Me, txtNamaAdmin.Text.Trim + " Berhasil di Tambahkan", 4000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
                    Menu_Admin.LoadDataAdmin()

                End If

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            SqlTrans.Rollback()
            Bunifu.Snackbar.Show(Me, "Data Gagal di tambahkan", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
        Finally
            Clear()
            SqlTrans.Dispose()
            CmdTrans.Dispose()
        End Try

    End Sub

    Private Sub btnCancelAdmin_Click(sender As Object, e As EventArgs) Handles btnCancelAdmin.Click
        Me.Dispose()
        TransparentBg.Close()
    End Sub

    Sub Clear()

        txtNamaAdmin.Clear()
        txtEmailAdmin.Clear()
        txtUsername.Clear()
        txtPassword.Clear()

    End Sub

    Private Sub AddAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call BukaConn()
        Dim skinManager As MaterialSkinManager = MaterialSkinManager.Instance
        skinManager.AddFormToManage(Me)
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT
        skinManager.ColorScheme = New ColorScheme(Primary.Blue900, Primary.Blue700, Primary.Blue900, Accent.LightBlue200, TextShade.WHITE)

    End Sub

End Class