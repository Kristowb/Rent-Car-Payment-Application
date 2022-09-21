Imports MySql.Data.MySqlClient
Public Class Menu_Peminjaman

    Private DtSet As DataSet
    Private DtAdpt As MySqlDataAdapter
    Private DtView As DataView
    Private DtTable As DataTable

    Protected stringz As String = "datasource=localhost;port=3306;username=root;password=;database=rental_mobil"
    Protected conz As New MySqlConnection(stringz)


    Dim _id, _plate As String

    Private Sub Menu_Peminjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call BukaConn()
        'LoadDataTransaksi()
        LoadAutoNo()
        AutoSuggestModule()
        AutoSuggestModule1()
    End Sub

    Sub LoadAutoNo()
        txtNoTransaksi.Text = GenerateTrans()
        'Dim rand = New Random
        'txtNoTransaksi.Text = rand.Next(11111111, 99999999)
    End Sub

    Sub AutoSuggestModule()
        conz.Open()
        cm = New MySqlCommand("SELECT * from customer", conz)
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(cm)
        da.Fill(ds, "customer")
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            col.Add(ds.Tables(0).Rows(i)("nama").ToString())
        Next
        conz.Close()
        txtCariCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCariCustomer.AutoCompleteCustomSource = col
        txtCariCustomer.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub

    Sub AutoSuggestModule1()
        conz.Open()
        cm = New MySqlCommand("SELECT * from mobil where status like 'Tersedia'", conz)
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(cm)
        da.Fill(ds, "mobil")
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            col.Add(ds.Tables(0).Rows(i)("no_polisi").ToString())
        Next
        conz.Close()
        txtCariNoPolisi.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCariNoPolisi.AutoCompleteCustomSource = col
        txtCariNoPolisi.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub

    Private Sub txtCariCustomer_TextChanged(sender As Object, e As EventArgs) Handles txtCariCustomer.TextChanged
        Try
            conz.Open()
            cm = New MySqlCommand("Select * from customer where nama like '" & txtCariCustomer.Text & "'", conz)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                'txtCariCustomer.Text = dr.Item("id").ToString
                txtNamaCustomer.Text = dr.Item("nama").ToString
                txtNoHandphone.Text = dr.Item("kontak").ToString
            Else
                'txtCariCustomer.Clear()
                txtNamaCustomer.Clear()
                txtNoHandphone.Clear()
            End If
            dr.Close()
            conz.Close()
        Catch ex As Exception
            conz.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub


    Private Sub txtCariNoPolisi_TextChanged(sender As Object, e As EventArgs) Handles txtCariNoPolisi.TextChanged
        Try
            conz.Open()
            cm = New MySqlCommand("Select * from mobil where no_polisi like '" & txtCariNoPolisi.Text & "'", conz)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                txtNoPolisi.Text = dr.Item("no_polisi").ToString
                txtMobil.Text = dr.Item("merk").ToString
                txtBiayaSewa.Text = Format(CDbl(dr.Item("hargasewa").ToString), "#,##0.00")

            Else
                txtNoPolisi.Clear()
                txtMobil.Clear()
                txtBiayaSewa.Clear()
            End If
            dr.Close()
            conz.Close()
        Catch ex As Exception
            conz.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub txtDate_ValueChanged(sender As Object, e As EventArgs) Handles txtDate.ValueChanged
        GetTotal()
    End Sub

    Private Sub btnRent_Click(sender As Object, e As EventArgs) Handles btnRent.Click
        Tambah()

    End Sub

    Sub Tambah()

        Call BukaConn()
        Dim SqlTrans As MySqlTransaction = Conn.BeginTransaction
        Dim CmdTrans As MySqlCommand = Conn.CreateCommand
        Dim tglPinjam As String = Now.Date.ToString("yyyy-MM-dd")
        Dim tglKembali As String = txtDate.Value.ToString("yyyy-MM-dd")

        Try
            If IS_EMPTY(txtNoPolisi) = True Then Return
            If IS_EMPTY(txtNamaCustomer) = True Then Return
            With CmdTrans
                If MsgBox("Yakin akan di tambahkan??", vbQuestion + vbYesNo) = vbYes Then
                    .CommandText = "insert_peminjaman"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Conn
                    .Transaction = SqlTrans
                    .Parameters.Add("in_no_transaksi", MySqlDbType.VarChar, 30).Value = txtNoTransaksi.Text
                    .Parameters.Add("in_no_polisi", MySqlDbType.VarChar, 30).Value = txtNoPolisi.Text
                    .Parameters.Add("in_nama_mobil", MySqlDbType.VarChar, 30).Value = txtMobil.Text
                    .Parameters.Add("in_nama_customer_peminjam", MySqlDbType.VarChar, 30).Value = txtNamaCustomer.Text
                    .Parameters.Add("in_tgl_pinjam", MySqlDbType.Date, 30).Value = tglPinjam
                    .Parameters.Add("in_tgl_kembali", MySqlDbType.Date, 30).Value = tglKembali
                    .Parameters.Add("in_total_bayar", MySqlDbType.Double, 11).Value = txtTotalBayar.Text
                    .Parameters.Add("in_lama_pinjam", MySqlDbType.Double, 11).Value = txtHari.Text
                    .Parameters.Add("in_status", MySqlDbType.VarChar, 30).Value = txtStatus.Text
                    .ExecuteNonQuery()
                    SqlTrans.Commit()
                    Bunifu.Snackbar.Show(Me, txtMobil.Text.Trim + " Berhasil di Tambahkan", 4000, Snackbar.Views.SnackbarDesigner.MessageTypes.Information)
                    btnBayar.Enabled = True
                End If
            End With
            cm = New MySqlCommand("update mobil set status ='Booked' where no_polisi like '" & txtNoPolisi.Text & "'", Conn)
            cm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            SqlTrans.Rollback()
            Bunifu.Snackbar.Show(Me, "Data Gagal di tambahkan", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
        Finally
            LoadDataTransaksi()
            SqlTrans.Dispose()
            CmdTrans.Dispose()
            LoadAutoNo()
            txtDate.Value = Now.Date
            AutoSuggestModule1()

        End Try
    End Sub

    Sub GetTotal()
        Try
            Dim day As Integer
            day = DateDiff("d", Now.Date.ToString("yyyy-MM-dd"), txtDate.Value.ToString("yyyy-MM-dd"))
            day += 1
            txtHari.Text = day
            txtTotalBayar.Text = Format(day * CDbl(txtBiayaSewa.Text), "#,##0.00")
        Catch ex As Exception
            txtTotalBayar.Text = ""
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
        TransparentBg.Close()
    End Sub

    Sub LoadDataTransaksi()

        Dim total As Double
        DataTransaksi.Rows.Clear()
        conz.Open()
        cm = New MySqlCommand("Select * from peminjaman where no_transaksi like '" & txtNoTransaksi.Text & "'", conz)
        dr = cm.ExecuteReader
        While dr.Read
            total += CDbl(dr.Item("total_bayar").ToString)
            DataTransaksi.Rows.Add(dr.Item("no_transaksi").ToString, dr.Item("no_polisi").ToString, Format(CDbl(dr.Item("total_bayar").ToString), "#,##0.00"), Format(CDate(dr.Item("tgl_pinjam").ToString), "yyyy-MM-dd"), Format(CDate(dr.Item("tgl_kembali").ToString), "yyyy-MM-dd"))
        End While
        dr.Close()
        conz.Close()

    End Sub

    Private Sub DataTransaksi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataTransaksi.CellContentClick

        Call BukaConn()
        Dim cmd As MySqlCommand
        Dim columsString As String = Me.DataTransaksi.Columns(e.ColumnIndex).Name
        Try
            If columsString = "btnDelete" Then
                If MsgBox("Yakin akan dihapus ?", vbYesNo + vbQuestion) = vbYes Then
                    cmd = New MySqlCommand("DELETE FROM peminjaman where no_transaksi = '" & _id & "'", Conn)
                    cmd.ExecuteNonQuery()
                    MsgBox("Record successfully removed from the list.", vbInformation)
                    LoadDataTransaksi()
                    ClearPeminjaman()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cm = New MySqlCommand("update mobil set status = 'Tersedia' where no_polisi like '" & _plate & "'", Conn)
            cm.ExecuteNonQuery()
            LoadAutoNo()
            AutoSuggestModule1()
        End Try

    End Sub

    Private Sub DataTransaksi_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataTransaksi.SelectionChanged
        Dim i As Integer
        i = DataTransaksi.CurrentRow.Index
        _id = DataTransaksi.Item(0, i).Value
        _plate = DataTransaksi.Item(1, i).Value
    End Sub

    Private Sub bunifuImageButton1_Click(sender As Object, e As EventArgs) Handles bunifuImageButton1.Click
        Me.Dispose()
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        TransparentBg2.Show()
        With Menu_Pembayaran
            .txtNoTransaksi.Text = txtNoTransaksi.Text
            .txtNamaCustomer.Text = txtNamaCustomer.Text
            .txtMobil.Text = txtMobil.Text
            .txtTotal.Text = txtTotalBayar.Text
            .ShowDialog()
        End With
    End Sub

    Sub ClearPeminjaman()
        txtCariNoPolisi.Clear()
        txtNoPolisi.Clear()
        txtMobil.Clear()
        txtBiayaSewa.Clear()
        txtTotalBayar.Clear()
        txtCariCustomer.Clear()
        txtNamaCustomer.Clear()
        txtNoTransaksi.Clear()
        txtNoHandphone.Clear()
        Bunifu.Snackbar.Show(Me, txtNoTransaksi.Text.Trim + " Berhasil di Bayarkan", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Success)
    End Sub


End Class