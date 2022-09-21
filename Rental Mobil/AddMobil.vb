Imports MySql.Data.MySqlClient
Imports MaterialSkin
Public Class Add
    Public cm As New MySqlCommand
    Public dr As MySqlDataReader

    Dim str As String = "datasource=localhost;port=3306;username=root;password=;database=rental_mobil"
    Dim con As New MySqlConnection(str)


    Private Sub btnAddContact_Click(sender As Object, e As EventArgs) Handles btnAddContact.Click
        con.Open()

        If txtNoPolisi.Text = "" Or txtNama.Text = "" Or cmbMerk.Text = "" Or txtModel.Text = "" Or txtWarna.Text = "" Or txtHargaSewa.Text = "" Or txtStatus.Text = "" Then
            Bunifu.Snackbar.Show(Me, "Lengkapi semua kolom terlebih dahulu", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)

        Else
            cm = New MySqlCommand("Select * FROM Mobil where no_polisi = '" & txtNoPolisi.Text & "'", con)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Bunifu.Snackbar.Show(Me, txtNoPolisi.Text.Trim + " Telah Terdaftar", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
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

                If MsgBox("Yakin akan di tambahkan??", vbQuestion + vbYesNo, "Delete Record") = vbYes Then
                    .CommandText = "insert_mobil"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Conn
                    .Transaction = SqlTrans
                    .Parameters.Add("in_no_polisi", MySqlDbType.VarChar, 30).Value = txtNoPolisi.Text
                    .Parameters.Add("in_merk", MySqlDbType.VarChar, 30).Value = cmbMerk.Text
                    .Parameters.Add("in_nama", MySqlDbType.VarChar, 30).Value = txtNama.Text
                    .Parameters.Add("in_model", MySqlDbType.VarChar, 30).Value = txtModel.Text
                    .Parameters.Add("in_warna", MySqlDbType.VarChar, 30).Value = txtWarna.Text
                    .Parameters.Add("in_hargasewa", MySqlDbType.Double, 11).Value = txtHargaSewa.Text
                    .Parameters.Add("in_status", MySqlDbType.VarChar, 30).Value = txtStatus.Text
                    .ExecuteNonQuery()
                    SqlTrans.Commit()
                    Bunifu.Snackbar.Show(Me, txtNama.Text.Trim + " Berhasil di Tambahkan", 4000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
                    Menu_Admin.LoadDataMobil()
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

        txtNama.Clear()
        txtNoPolisi.Clear()
        txtModel.Clear()
        txtWarna.Clear()
        txtHargaSewa.Clear()
        txtStatus.Clear()

    End Sub

    Private Sub btnCancelMobil_Click(sender As Object, e As EventArgs) Handles btnCancelMobil.Click
        Me.Dispose()
        TransparentBg.Close()
    End Sub

    Sub AutoSuggestModule()

        Try
            Dim query As String
            query = "Select * FROM MERK"
            cm = New MySqlCommand(query, Conn)
            dr = cm.ExecuteReader
            While dr.Read
                Dim sMerk = dr.GetString("merk")
                cmbMerk.Items.Add(sMerk)
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub AddMobil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoSuggestModule()
        Call BukaConn()

        Dim skinManager As MaterialSkinManager = MaterialSkinManager.Instance
        skinManager.AddFormToManage(Me)
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT
        skinManager.ColorScheme = New ColorScheme(Primary.Blue900, Primary.Blue700, Primary.Blue900, Accent.LightBlue200, TextShade.WHITE)
    End Sub

    Private Sub btnUpdateMobil_Click(sender As Object, e As EventArgs) Handles btnUpdateMobil.Click

        Try
            If MsgBox("Update this record?", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cm = New MySqlCommand("update mobil set merk = '" & cmbMerk.Text & "', nama = '" & txtNama.Text & "', model ='" & txtModel.Text & "', warna ='" & txtWarna.Text & "', hargasewa = '" & txtHargaSewa.Text & "' , status = '" & txtStatus.Text & "' where no_polisi like '" & txtNoPolisi.Text & "'", con)
                cm.ExecuteNonQuery()
                Bunifu.Snackbar.Show(Me, txtNama.Text.Trim + " Berhasil di Update", 4000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        Finally
            Menu_Admin.LoadDataMobil()
            Clear()
            con.Close()
        End Try

    End Sub

End Class