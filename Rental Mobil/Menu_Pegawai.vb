Imports MySql.Data.MySqlClient
Imports Common
Public Class Menu_Pegawai
    Protected Const SQL_CONNECTION_STRING As String =
        "Server=localhost;Port=3306;Database=rental_mobil;UID=root"
    Protected strConn As String = SQL_CONNECTION_STRING
    Private DtSet As DataSet
    Private DtAdpt As MySqlDataAdapter
    Private DtView As DataView
    Private DtTable As DataTable

    Dim _namacustomer, _alamat, _kontak, _idtype, _idno As String 'AddPegawai

    Private Sub Menu_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDataMobil()
        LoadDataCustomer()

        Call BukaConn()
        txtNama.Text = ActivePegawai.nama
    End Sub

    Sub LoadDataMobil()
        Try
            Dim Scan As New MySqlConnection(strConn)
            Dim Query As String = "SELECT * FROM MOBIL"
            Dim Command As New MySqlCommand(Query, Scan)
            DtAdpt = New MySqlDataAdapter(Command)
            Dim Builder As New MySqlCommandBuilder(DtAdpt)
            DtSet = New DataSet()
            DtAdpt.Fill(DtSet, "Mobil")
            DataMobil.DataSource = DtSet.Tables(0)
            Call RapidGridMobil(DataMobil)
            Scan.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RapidGridMobil(ByVal Grid As DataGridView)

        Grid.Columns(0).HeaderText = "No Polisi"
        Grid.Columns(1).HeaderText = "Merk"
        Grid.Columns(2).HeaderText = "Nama"
        Grid.Columns(3).HeaderText = "Model"
        Grid.Columns(4).HeaderText = "Warna"
        Grid.Columns(5).HeaderText = "Harga Sewa"
        Grid.Columns(6).HeaderText = "Status"

    End Sub

    Private Sub txtSearchMobil_TextChanged(sender As Object, e As EventArgs) Handles txtSearchMobil.TextChanged

        Dim adapater As MySqlDataAdapter
        Dim ds As New DataSet
        Try

            adapater = New MySqlDataAdapter("select * from mobil where merk like '%" & txtSearchMobil.Text & "%'", SQL_CONNECTION_STRING)
            adapater.Fill(ds)
            DataMobil.DataSource = ds.Tables(0)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefreshMobil_Click(sender As Object, e As EventArgs) Handles btnRefreshMobil.Click
        LoadDataMobil()
    End Sub

    Sub LoadDataCustomer()
        Try
            Dim Scan As New MySqlConnection(strConn)
            Dim Query As String = "SELECT * FROM Customer"
            Dim Command As New MySqlCommand(Query, Scan)
            DtAdpt = New MySqlDataAdapter(Command)
            Dim Builder As New MySqlCommandBuilder(DtAdpt)
            DtSet = New DataSet()
            DtAdpt.Fill(DtSet, "Customer")
            DataCustomer.DataSource = DtSet.Tables(0)
            Call RapidGridCustomer(DataCustomer)
            Scan.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RapidGridCustomer(ByVal Grid As DataGridView)

        Grid.Columns(0).HeaderText = "ID"
        Grid.Columns(1).HeaderText = "Nama"
        Grid.Columns(2).HeaderText = "Alamat"
        Grid.Columns(3).HeaderText = "Ulang Tahun"
        Grid.Columns(4).HeaderText = "Kontak"
        Grid.Columns(5).HeaderText = "ID Type"
        Grid.Columns(6).HeaderText = "ID No"

        '   Grid.Columns(0).Width = 20
        '   Grid.Columns(1).Width = 25
        '   Grid.Columns(2).Width = 25
        '   Grid.Columns(3).Width = 25
        '   Grid.Columns(4).Width = 25
        '   Grid.Columns(5).Width = 150

    End Sub

    Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs) Handles btnAddCustomer.Click
        TransparentBg.Show()
        AddCustomer.Show()
    End Sub

    Private Sub btnHapusCustomer_Click(sender As Object, e As EventArgs) Handles btnHapusCustomer.Click
        DeleteCustomer()
    End Sub

    Sub DeleteCustomer()

        Dim SqlTrans As MySqlTransaction = Conn.BeginTransaction
        Dim CmdTrans As MySqlCommand = Conn.CreateCommand
        Dim Result As DialogResult
        If txtHapusCustomer.Text <> "" Then
            Try
                With CmdTrans
                    Result = MsgBox("Yakin akan di hapus?" & txtHapusCustomer.Text & "?", vbQuestion + vbYesNo, "Delete Record") = vbYes = True
                    If Result = True Then
                        .CommandText = "delete_customer"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("del_id_customer", MySqlDbType.Int64, 11).Value = txtHapusCustomer.Text
                        .ExecuteNonQuery()
                        SqlTrans.Commit()
                        Bunifu.Snackbar.Show(Me, "Data Berhasil di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
                        LoadDataCustomer()
                    End If
                End With
            Catch ex As Exception
                SqlTrans.Rollback()
                Bunifu.Snackbar.Show(Me, "Data Gagal di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
            Finally
                SqlTrans.Dispose()
                CmdTrans.Dispose()
            End Try
        End If

    End Sub

    Private Sub btnRefreshCustomer_Click(sender As Object, e As EventArgs) Handles btnRefreshCustomer.Click
        LoadDataCustomer()
    End Sub

    Private Sub DataCustomer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataCustomer.CellContentClick
        Dim row As DataGridViewRow = DataCustomer.CurrentRow
        Try
            txtHapusCustomer.Text = row.Cells(0).Value.ToString()
        Catch ex As Exception

        End Try

        ' Update Data
        Dim i As Integer
        i = DataCustomer.CurrentRow.Index
        _namacustomer = DataCustomer.Item(1, i).Value
        _alamat = DataCustomer.Item(2, i).Value
        _kontak = DataCustomer.Item(4, i).Value
        _idtype = DataCustomer.Item(5, i).Value
        _idno = DataCustomer.Item(6, i).Value

    End Sub

    Private Sub txtSearchCustomer_TextChanged(sender As Object, e As EventArgs) Handles txtSearchCustomer.TextChanged
        Dim adapater As MySqlDataAdapter
        Dim ds As New DataSet
        Try

            adapater = New MySqlDataAdapter("select * from customer where nama like '%" & txtSearchCustomer.Text & "%'", SQL_CONNECTION_STRING)
            adapater.Fill(ds)
            DataCustomer.DataSource = ds.Tables(0)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        BunifuPages1.SetPage(0)
    End Sub

    Private Sub btnDaftarMobil_Click(sender As Object, e As EventArgs) Handles btnDaftarMobil.Click
        BunifuPages1.SetPage(1)
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        BunifuPages1.SetPage(2)
    End Sub

    Private Sub btnPeminjaman_Click(sender As Object, e As EventArgs) Handles btnPeminjaman.Click
        TransparentBg.Show()
        Menu_Peminjaman.ShowDialog()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Menu_Transaksi.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Hide()
        Login.Show()

    End Sub

    Private Sub bunifuImageButton1_Click(sender As Object, e As EventArgs) Handles bunifuImageButton1.Click
        Application.Exit()
    End Sub

    Private Sub btnPengembalian_Click(sender As Object, e As EventArgs) Handles btnPengembalian.Click
        Menu_Pengembalian.ShowDialog()
    End Sub

    Private Sub btnEditCustomer_Click(sender As Object, e As EventArgs) Handles btnEditCustomer.Click
        'TransparentBg.Show()
        'With AddCustomer
        '    .btnAddContact.Enabled = False
        '    .btnUpdateCustomer.Enabled = True
        '    .txtNama.Text = _namacustomer
        '    .txtAlamat.Text = _alamat
        '    .txtKontak.Text = _kontak
        '    .cmbKartu.Text = _idtype
        '    .txtNoID.Text = _idno
        '    .ShowDialog()
        'End With

    End Sub
End Class