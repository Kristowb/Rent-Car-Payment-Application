Imports MySql.Data.MySqlClient

Public Class Menu_Pengembalian

    Protected Const SQL_CONNECTION_STRING As String =
        "Server=localhost;Port=3306;Database=rental_mobil;UID=root"
    Protected strConn As String = SQL_CONNECTION_STRING

    Private DtSet As DataSet
    Private DtAdpt As MySqlDataAdapter
    Private DtView As DataView
    Private DtTable As DataTable
    Dim _no_transaksi, _nama_customer, _no_polisi, _mobil, _tanggalpinjam, _tanggalkembali, _lamapinjam, _totalbayar As String

    Dim str As String = "datasource=localhost;port=3306;username=root;password=;database=rental_mobil"
    Dim con As New MySqlConnection(str)

    Public bayar As String

    Private Sub Menu_Pengembalian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call BukaConn()
        LoadDataTransaksi()
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        bayar = "Tunai"
        HitungBayar()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadDataTransaksi()
    End Sub

    Private Sub bunifuImageButton1_Click(sender As Object, e As EventArgs) Handles bunifuImageButton1.Click
        Me.Dispose()
    End Sub

    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        HitungKembalian()
    End Sub

    Sub HitungKembalian()
        Try
            Dim _total As Double
            _total = CDbl(txtCash.Text) - (txtTotalBayar.Text)
            txtKembalian.Text = _total
        Catch ex As Exception
        End Try
    End Sub

    Sub HitungBayar()

        Try
            If IS_EMPTY(txtCash) = True Then Return
            If CDbl(txtCash.Text) < CDbl(txtTotalBayar.Text) Then
                MsgBox(" Jumlah Uang Kurang...", vbExclamation)
                Return
            Else
                Dim sdate As String = Now.Date.ToString("yyyy-MM-dd")
                con.Open()
                cm = New MySqlCommand("insert into pembayaran(no_transaksi, nama_customer, pembayaran, bayar, tgl_pembayaran) values('" & txtNoTransaksi.Text & "','" & txtNamaCustomer.Text & "','" & bayar & "','" & CDbl(txtCash.Text) & "','" & sdate & "')", con)
                cm.ExecuteNonQuery()
                con.Close()

                con.Open()
                cm = New MySqlCommand("update peminjaman set status = 'Returned' where no_transaksi like '" & _no_transaksi & "'", con)
                cm.ExecuteNonQuery()
                con.Close()

                con.Open()
                cm = New MySqlCommand("update mobil set status = 'Tersedia' where no_polisi like '" & _no_polisi & "'", con)
                cm.ExecuteNonQuery()
                con.Close()
                Bunifu.Snackbar.Show(Me, txtNoTransaksi.Text.Trim + " Berhasil di Bayarkan", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Success)

                LoadDataTransaksi()
                txtNoTransaksi.ResetText()
                txtNamaCustomer.ResetText()
                txtNoPolisi.ResetText()
                txtMobil.ResetText()
                txtTanggalPinjam.ResetText()
                txtTanggalKembali.ResetText()
                txtLamaPinjam.ResetText()
                txtTotalBayar.Text = "0.00"

            End If

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Sub LoadDataTransaksi()

        Try
            Dim Scan As New MySqlConnection(strConn)
            Dim Query As String = "SELECT * FROM PEMINJAMAN where status like 'Booked' AND nama_peminjam like'" & txtSearch.Text & "%'"
            Dim Command As New MySqlCommand(Query, Scan)
            DtAdpt = New MySqlDataAdapter(Command)
            Dim Builder As New MySqlCommandBuilder(DtAdpt)
            DtSet = New DataSet()
            DtAdpt.Fill(DtSet, "Transaksi")
            DataTransaksi.DataSource = DtSet.Tables(0)
            Call RapidGridAdmin(DataTransaksi)
            Scan.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub RapidGridAdmin(ByVal Grid As DataGridView)

        Grid.Columns(0).HeaderText = "No Transaksi"
        Grid.Columns(1).HeaderText = "No Polisi"
        Grid.Columns(2).HeaderText = "Mobil"
        Grid.Columns(3).HeaderText = "Customer"
        Grid.Columns(4).HeaderText = "Tanggal Pinjam"
        Grid.Columns(5).HeaderText = "Tanggal Kembali"
        Grid.Columns(6).HeaderText = "Total Bayar"
        Grid.Columns(7).HeaderText = "Lama Pinjam"
        Grid.Columns(8).HeaderText = "Status"

        Grid.Columns(0).Width = 116
        Grid.Columns(1).Width = 116
        Grid.Columns(2).Width = 116
        Grid.Columns(3).Width = 116
        Grid.Columns(4).Width = 116
        Grid.Columns(5).Width = 116
        Grid.Columns(6).Width = 116
        Grid.Columns(7).Width = 116
        Grid.Columns(8).Width = 116

    End Sub

    Private Sub DataTransaksi_Click(sender As Object, e As System.EventArgs) Handles DataTransaksi.CellContentClick

        Try
            txtNoTransaksi.Text = _no_transaksi
            txtNoPolisi.Text = _no_polisi
            txtMobil.Text = _mobil
            txtNamaCustomer.Text = _nama_customer
            txtTanggalPinjam.Text = _tanggalpinjam
            txtTanggalKembali.Text = _tanggalkembali
            txtTotalBayar.Text = _totalbayar
            txtLamaPinjam.Text = _lamapinjam

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataTransaksi_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataTransaksi.SelectionChanged

        Dim i As Integer
        i = DataTransaksi.CurrentRow.Index
        _no_transaksi = DataTransaksi.Item(0, i).Value
        _no_polisi = DataTransaksi.Item(1, i).Value
        _mobil = DataTransaksi.Item(2, i).Value
        _nama_customer = DataTransaksi.Item(3, i).Value
        _tanggalpinjam = DataTransaksi.Item(4, i).Value
        _tanggalkembali = DataTransaksi.Item(5, i).Value
        _totalbayar = DataTransaksi.Item(6, i).Value
        _lamapinjam = DataTransaksi.Item(7, i).Value

    End Sub

    Private Sub txtCash_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

End Class