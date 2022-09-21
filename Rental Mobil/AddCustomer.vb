Imports MySql.Data.MySqlClient
Imports MaterialSkin
Public Class AddCustomer
    Public cm As New MySqlCommand
    Public dr As MySqlDataReader

    Dim str As String = "datasource=localhost;port=3306;username=root;password=;database=rental_mobil"
    Dim con As New MySqlConnection(str)


    Private Sub btnAddContact_Click(sender As Object, e As EventArgs) Handles btnAddContact.Click

        con.Open()
        If txtNama.Text = "" Or txtAlamat.Text = "" Or txtKontak.Text = "" Or txtNoID.Text = "" Or cmbKartu.Text = "" Or txtDate.Text = "" Then
            Bunifu.Snackbar.Show(Me, "Lengkapi semua kolom terlebih dahulu", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dimiss")

        Else
            cm = New MySqlCommand("Select * FROM customer where idno = '" & txtNoID.Text & "'", con)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Bunifu.Snackbar.Show(Me, txtNoID.Text.Trim + " Telah Terdaftar", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dismiss")
            Else
                Tambah()
            End If
        End If
        con.Close()

    End Sub

    Sub Tambah()

        Dim SqlTrans As MySqlTransaction = Conn.BeginTransaction
        Dim CmdTrans As MySqlCommand = Conn.CreateCommand
        Dim sdate As String = txtDate.Value.ToString("yyyy-MM-dd")
        Try
            With CmdTrans

                If MsgBox("Yakin akan di tambahkan?", vbQuestion + vbYesNo, "Insert Record") = vbYes Then
                    .CommandText = "insert_customer"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Conn
                    .Transaction = SqlTrans
                    .Parameters.Add("in_id_customer", MySqlDbType.Int64, 11)
                    .Parameters.Add("in_nama_customer", MySqlDbType.VarChar, 30).Value = txtNama.Text
                    .Parameters.Add("in_alamat_customer", MySqlDbType.VarChar, 30).Value = txtAlamat.Text
                    .Parameters.Add("in_ulangtahun", MySqlDbType.Date, 10).Value = sdate
                    .Parameters.Add("in_kontak", MySqlDbType.VarChar, 20).Value = txtKontak.Text
                    .Parameters.Add("in_idtype", MySqlDbType.VarChar, 30).Value = cmbKartu.Text
                    .Parameters.Add("in_idno", MySqlDbType.Int64, 11).Value = txtNoID.Text
                    .ExecuteNonQuery()
                    SqlTrans.Commit()
                    Bunifu.Snackbar.Show(Me, txtNama.Text.Trim + " Berhasil di Tambahkan", 4000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
                    Menu_Pegawai.LoadDataCustomer()
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

    Sub Clear()
        cmbKartu.ResetText()
        txtNama.Clear()
        txtAlamat.Clear()
        txtKontak.Clear()
        txtNoID.Clear()

    End Sub

    Private Sub btnCancelMobil_Click(sender As Object, e As EventArgs) Handles btnCancelMobil.Click
        Me.Dispose()
        TransparentBg.Close()
    End Sub

    Private Sub AddCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call BukaConn()
        'AutoSuggestModule()
        Dim skinManager As MaterialSkinManager = MaterialSkinManager.Instance
        skinManager.AddFormToManage(Me)
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT
        skinManager.ColorScheme = New ColorScheme(Primary.Blue900, Primary.Blue700, Primary.Blue900, Accent.LightBlue200, TextShade.WHITE)

    End Sub

    Private Sub btnUpdateCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomer.Click
        UpdateCustomer()
    End Sub

    Sub UpdateCustomer()
        Dim sdated As String = txtDate.Value.ToString("yyyy-MM-dd")
        Try
            If MsgBox("Update this record?", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cm = New MySqlCommand("update customer set nama = '" & txtNama.Text & "', alamat = '" & txtAlamat.Text & "', ulangtahun ='" & sdated & "', kontak ='" & txtKontak.Text & "', idtype = '" & txtKartu.Text & ", idno = '" & txtNoID.Text & "'", con)
                cm.ExecuteNonQuery()
                Bunifu.Snackbar.Show(Me, txtNama.Text.Trim + " Berhasil di Update", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
                Menu_Admin.LoadDataPegawai()
                con.Close()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        Finally
            Clear()
        End Try
    End Sub
End Class
