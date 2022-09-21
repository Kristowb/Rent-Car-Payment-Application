Imports MySql.Data.MySqlClient
Imports MaterialSkin

Public Class AddBrand

    Public cm As New MySqlCommand
    Public dr As MySqlDataReader

    Dim str As String = "datasource=localhost;port=3306;username=root;password=;database=rental_mobil"
    Dim con As New MySqlConnection(str)

    Private Sub btnAddContact_Click(sender As Object, e As EventArgs) Handles btnAddContact.Click

        con.Open()
        If txtMerk.Text = "" Then
            Bunifu.Snackbar.Show(Me, "Lengkapi semua kolom terlebih dahulu", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dimiss")

        Else
            cm = New MySqlCommand("Select * FROM Merk where merk = '" & txtMerk.Text & "'", con)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Bunifu.Snackbar.Show(Me, txtMerk.Text.Trim + " Telah Terdaftar", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dismiss")
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

                    .CommandText = "insert_merk"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Conn
                    .Transaction = SqlTrans
                    .Parameters.Add("in_merk", MySqlDbType.VarChar, 30).Value = txtMerk.Text
                    .ExecuteNonQuery()
                    SqlTrans.Commit()
                    Bunifu.Snackbar.Show(Me, txtMerk.Text.Trim + " Berhasil di Tambahkan", 4000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
                    Menu_Admin.LoadDataBrand()
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
        txtMerk.Clear()
    End Sub

    Private Sub AddBrand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call BukaConn()

        Dim skinManager As MaterialSkinManager = MaterialSkinManager.Instance
        skinManager.AddFormToManage(Me)
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT
        skinManager.ColorScheme = New ColorScheme(Primary.Blue900, Primary.Blue700, Primary.Blue900, Accent.LightBlue200, TextShade.WHITE)

    End Sub

    Private Sub btnCancelMobil_Click(sender As Object, e As EventArgs) Handles btnCancelMobil.Click
        Me.Dispose()
        TransparentBg.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If MsgBox("Update this record?", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cm = New MySqlCommand("update merk set merk = '" & txtMerk.Text & "'", con)
                cm.ExecuteNonQuery()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        Finally
            Bunifu.Snackbar.Show(Me, txtMerk.Text.Trim + " Berhasil di Update", 4000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information, "Dismiss")
            Menu_Admin.LoadDataBrand()
            Clear()
            con.Close()
        End Try
    End Sub
End Class