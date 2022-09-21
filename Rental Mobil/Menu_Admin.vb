Imports MySql.Data.MySqlClient
Imports Common
Imports Excel = Microsoft.Office.Interop.Excel


Public Class Menu_Admin
    ' Connection Dim
    Protected Const SQL_CONNECTION_STRING As String =
        "Server=localhost;Port=3306;Database=rental_mobil;UID=root"
    Protected strConn As String = SQL_CONNECTION_STRING

    Private DtSet As DataSet
    Private DtAdpt As MySqlDataAdapter
    Private DtView As DataView
    Private DtTable As DataTable

    ' Excel Dim
    Protected xlapp As Excel.Application
    Protected xlworkbook As Excel.Workbook
    Protected xlworksheet As Excel.Worksheet
    Protected misValue As Object = System.Reflection.Missing.Value
    Protected i As Int16, j As Int16

    Dim _no_polisi, _merkAddmobil, _namamobil, _model, _warnamobil, _hargasewamobil, _status As String 'AddMobil
    Dim _merkmobil As String 'AddBrand
    Dim _namapegawai, _emailpegawai, _alamatpegawai, _usernamepegawai, _passwordpegawai As String 'AddPegawai


    Private Sub Menu_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDataMobil()
        LoadDataAdmin()
        LoadDataPegawai()
        LoadDataBrand()
        Call BukaConn()

        txtNama.Text = ActiveUser.nama

    End Sub

    ' Load Data
    ' Load Data
    ' Load Data

    Sub LoadDataAdmin()

        Try
            Dim Scan As New MySqlConnection(strConn)
            Dim Query As String = "SELECT * FROM ADMIN"
            Dim Command As New MySqlCommand(Query, Scan)
            DtAdpt = New MySqlDataAdapter(Command)
            Dim Builder As New MySqlCommandBuilder(DtAdpt)
            DtSet = New DataSet()
            DtAdpt.Fill(DtSet, "Admin")
            DataAdmin.DataSource = DtSet.Tables(0)
            Call RapidGridAdmin(DataAdmin)
            Scan.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub RapidGridAdmin(ByVal Grid As DataGridView)

        Grid.Columns(0).HeaderText = "ID"
        Grid.Columns(1).HeaderText = "Nama"
        Grid.Columns(2).HeaderText = "Email"
        Grid.Columns(3).HeaderText = "Username"
        Grid.Columns(4).HeaderText = "Password"
        Grid.Columns(5).HeaderText = "Created At"

        Grid.Columns(0).Width = 15
        Grid.Columns(1).Width = 50
        Grid.Columns(2).Width = 80
        Grid.Columns(3).Width = 50
        Grid.Columns(4).Width = 50
        Grid.Columns(5).Width = 140

    End Sub

    Sub LoadDataPegawai()

        Try
            Dim Scan As New MySqlConnection(strConn)
            Dim Query As String = "SELECT * FROM PEGAWAI"
            Dim Command As New MySqlCommand(Query, Scan)
            DtAdpt = New MySqlDataAdapter(Command)
            Dim Builder As New MySqlCommandBuilder(DtAdpt)
            DtSet = New DataSet()
            DtAdpt.Fill(DtSet, "Pegawai")
            DataPegawai.DataSource = DtSet.Tables(0)
            Call RapidGridPegawai(DataPegawai)
            Scan.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub RapidGridPegawai(ByVal Grid As DataGridView)

        Grid.Columns(0).HeaderText = "ID"
        Grid.Columns(1).HeaderText = "Nama"
        Grid.Columns(2).HeaderText = "Email"
        Grid.Columns(3).HeaderText = "Alamat"
        Grid.Columns(4).HeaderText = "Username"
        Grid.Columns(5).HeaderText = "Password"
        Grid.Columns(6).HeaderText = "Mulai Bekerja"

        Grid.Columns(0).Width = 15
        Grid.Columns(1).Width = 50
        Grid.Columns(2).Width = 80
        Grid.Columns(3).Width = 50
        Grid.Columns(4).Width = 50
        Grid.Columns(5).Width = 50
        Grid.Columns(6).Width = 150

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

    Sub LoadDataBrand()

        Try
            Dim Scan As New MySqlConnection(strConn)
            Dim Query As String = "SELECT * FROM MERK"
            Dim Command As New MySqlCommand(Query, Scan)
            DtAdpt = New MySqlDataAdapter(Command)
            Dim Builder As New MySqlCommandBuilder(DtAdpt)
            DtSet = New DataSet()
            DtAdpt.Fill(DtSet, "Brand")
            DataBrand.DataSource = DtSet.Tables(0)
            Call RapidGridBrand(DataBrand)
            Scan.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub RapidGridBrand(ByVal Grid As DataGridView)

        Grid.Columns(0).HeaderText = "Merk"

    End Sub

    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '

    ' Data Untuk Mobil
    ' Data Untuk Mobil
    ' Data Untuk Mobil

    Private Sub btnAddMobil_Click(sender As Object, e As EventArgs) Handles btnAddMobil.Click
        TransparentBg.Show()
        With Add
            .btnUpdateMobil.Enabled = False
            .ShowDialog()
        End With
    End Sub


    Private Sub btnEditMobil_Click(sender As Object, e As EventArgs) Handles btnEditMobil.Click

        TransparentBg.Show()
        With Add
            .btnAddContact.Enabled = False
            .txtNoPolisi.Enabled = False
            .btnUpdateMobil.Enabled = True
            .txtNoPolisi.Text = _no_polisi
            .cmbMerk.Text = _merkAddmobil
            .txtNama.Text = _namamobil
            .txtModel.Text = _model
            .txtWarna.Text = _warnamobil
            .txtHargaSewa.Text = _hargasewamobil
            .txtStatus.Text = _status
            .ShowDialog()
        End With

    End Sub


    Private Sub btnDeleteMobil_Click(sender As Object, e As EventArgs) Handles btnDeleteMobil.Click
        DeleteMobil()
    End Sub

    Sub DeleteMobil()

        Dim SqlTrans As MySqlTransaction = Conn.BeginTransaction
        Dim CmdTrans As MySqlCommand = Conn.CreateCommand
        Dim Result As DialogResult
        If txtIDMobilHapus.Text <> "" Then
            Try
                With CmdTrans
                    Result = MsgBox("Yakin akan menghapus " & txtIDMobilHapus.Text & "?", vbQuestion + vbYesNo, "Delete Record") = vbYes = True
                    If Result = True Then
                        .CommandText = "delete_mobil"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("del_no_polisi", MySqlDbType.VarChar, 30).Value = txtIDMobilHapus.Text
                        .ExecuteNonQuery()
                        SqlTrans.Commit()
                        Bunifu.Snackbar.Show(Me, "Data Berhasil di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
                    End If
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
                SqlTrans.Rollback()
                Bunifu.Snackbar.Show(Me, "Data Gagal di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
            Finally
                LoadDataMobil()
                SqlTrans.Dispose()
                CmdTrans.Dispose()
            End Try
        End If

    End Sub

    Private Sub btnRefreshMobil_Click(sender As Object, e As EventArgs) Handles btnRefreshMobil.Click
        LoadDataMobil()
    End Sub

    Private Sub DataMobil_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataMobil.CellContentClick

        Dim row As DataGridViewRow = DataMobil.CurrentRow
        Try
            txtIDMobilHapus.Text = row.Cells(0).Value.ToString()
        Catch ex As Exception
        End Try

        ' Update Data
        Dim i As Integer
        i = DataMobil.CurrentRow.Index
        _no_polisi = DataMobil.Item(0, i).Value
        _merkAddmobil = DataMobil.Item(1, i).Value
        _namamobil = DataMobil.Item(2, i).Value
        _model = DataMobil.Item(3, i).Value
        _warnamobil = DataMobil.Item(4, i).Value
        _hargasewamobil = DataMobil.Item(5, i).Value
        _status = DataMobil.Item(6, i).Value

    End Sub

    Private Sub txtSearchMobilSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearchMobilSearch.TextChanged

        Dim adapater As MySqlDataAdapter
        Dim ds As New DataSet
        Try

            adapater = New MySqlDataAdapter("select * from mobil where merk like '%" & txtSearchMobilSearch.Text & "%'", SQL_CONNECTION_STRING)
            adapater.Fill(ds)
            DataMobil.DataSource = ds.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ExportExcelMobill_Click(sender As Object, e As EventArgs) Handles ExportExcelMobil.Click

        xlapp = New Excel.ApplicationClass
        xlworkbook = xlapp.Workbooks.Add(misValue)
        xlworksheet = xlworkbook.Sheets(1)


        SaveFileMobil.Title = "Save To"
        SaveFileMobil.Filter = "Excel Files |*.xlsx"
        SaveFileMobil.ShowDialog()

        For s = 0 To DataMobil.ColumnCount - 1
            xlworksheet.Cells(1, s + 1) = DataMobil.Columns(s).Name.ToString
        Next

        For i = 0 To DataMobil.RowCount - 2
            For j = 0 To DataMobil.ColumnCount - 1
                xlworksheet.Cells(i + 2, j + 1) = DataMobil(j, i).Value.ToString
            Next
        Next

        Try
            xlworkbook.SaveAs(txtSearchMobil.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        xlworkbook.Close()
        xlapp.Quit()
        ReleaseObject(xlapp)
        ReleaseObject(xlworkbook)
        ReleaseObject(xlworksheet)

        MsgBox("Berhasil", MsgBoxStyle.Information)
        Bunifu.Snackbar.Show(Me, "Data Berhasil di Export", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Success)



    End Sub

    Private Sub SaveFileMobil_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileMobil.FileOk
        txtSearchMobil.Text = SaveFileMobil.FileName
    End Sub

    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '

    ' Data Untuk Admin
    ' Data Untuk Admin
    ' Data Untuk Admin

    Private Sub btnAddAdmin_Click(sender As Object, e As EventArgs) Handles btnAddAdmin.Click

        TransparentBg.Show()
        AddAdmin.ShowDialog()

    End Sub

    Private Sub btnDeleteAdmin_Click(sender As Object, e As EventArgs) Handles btnDeleteAdmin.Click
        DeleteAdmin()
    End Sub

    Sub DeleteAdmin()

        Dim SqlTrans As MySqlTransaction = Conn.BeginTransaction
        Dim CmdTrans As MySqlCommand = Conn.CreateCommand
        Dim Result As DialogResult
        If txtHapusAdmin.Text <> "" Then
            Try
                With CmdTrans
                    Result = MsgBox("Yakin akan menghapus " & txtHapusAdmin.Text & "?", vbQuestion + vbYesNo, "Delete Record") = vbYes = True
                    If Result = True Then
                        .CommandText = "delete_admin"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("del_id_admin", MySqlDbType.Int64, 11).Value = txtHapusAdmin.Text
                        .ExecuteNonQuery()
                        SqlTrans.Commit()
                        Bunifu.Snackbar.Show(Me, "Data Berhasil di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
                        LoadDataAdmin()
                    End If
                End With
            Catch ex As Exception
                SqlTrans.Rollback()
                Bunifu.Snackbar.Show(Me, "Data Gagal di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dismiss")
            Finally
                SqlTrans.Dispose()
                CmdTrans.Dispose()
            End Try
        End If

    End Sub

    Private Sub btnRefreshAdmin_Click(sender As Object, e As EventArgs) Handles btnRefreshAdmin.Click
        LoadDataAdmin()
    End Sub

    Private Sub DataAdmin_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataAdmin.CellContentClick

        Dim row As DataGridViewRow = DataAdmin.CurrentRow
        Try
            txtHapusAdmin.Text = row.Cells(0).Value.ToString()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtSearchAdmin_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAdmin.TextChanged

        Dim adapater As MySqlDataAdapter
        Dim ds As New DataSet
        Try

            adapater = New MySqlDataAdapter("select * from admin where nama like '%" & txtSearchAdmin.Text & "%'", SQL_CONNECTION_STRING)
        adapater.Fill(ds)
            DataAdmin.DataSource = ds.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ExportExcelAdmin_Click(sender As Object, e As EventArgs) Handles ExportExcelAdmin.Click

        xlapp = New Excel.ApplicationClass
        xlworkbook = xlapp.Workbooks.Add(misValue)
        xlworksheet = xlworkbook.Sheets(1)


        SaveFileAdmin.Title = "Save To"
        SaveFileAdmin.Filter = "Excel Files |*.xlsx"
        SaveFileAdmin.ShowDialog()

        For s = 0 To DataAdmin.ColumnCount - 1
            xlworksheet.Cells(1, s + 1) = DataMobil.Columns(s).Name.ToString
        Next

        For i = 0 To DataAdmin.RowCount - 2
            For j = 0 To DataMobil.ColumnCount - 1
                xlworksheet.Cells(i + 2, j + 1) = DataMobil(j, i).Value.ToString
            Next
        Next

        Try
            xlworkbook.SaveAs(txtHapusAdmin.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Bunifu.Snackbar.Show(Me, "Data Berhasil di Export", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Success)
        End Try

        xlworkbook.Close()
        xlapp.Quit()
        ReleaseObject(xlapp)
        ReleaseObject(xlworkbook)
        ReleaseObject(xlworksheet)

        MsgBox("Data Berhasil di Export", MsgBoxStyle.Information, "Information")

    End Sub

    Private Sub SaveFileAdmin_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileAdmin.FileOk
        txtHapusAdmin.Text = SaveFileAdmin.FileName
    End Sub

    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '


    ' Data Untuk Pegawai
    ' Data Untuk Pegawai
    ' Data Untuk Pegawai

    Private Sub btnAddPegawai_Click(sender As Object, e As EventArgs) Handles btnAddPegawai.Click

        TransparentBg.Show()
        With AddPegawai
            .btnUpdatePegawai.Enabled = False
            .ShowDialog()
        End With

    End Sub

    Private Sub btnEditPegawai_Click(sender As Object, e As EventArgs) Handles btnEditPegawai.Click

        TransparentBg.Show()
        With AddPegawai
            .btnAddContact.Enabled = False
            .txtNamaPegawai.Text = _namapegawai
            .txtEmail.Text = _emailpegawai
            .txtAlamat.Text = _alamatpegawai
            .txtUsername.Text = _usernamepegawai
            .txtPassword.Text = _passwordpegawai
            .ShowDialog()
        End With

    End Sub

    Private Sub btnHapusPegawai_Click(sender As Object, e As EventArgs) Handles btnHapusPegawai.Click
        DeletePegawai()
    End Sub

    Sub DeletePegawai()

        Dim SqlTrans As MySqlTransaction = Conn.BeginTransaction
        Dim CmdTrans As MySqlCommand = Conn.CreateCommand
        Dim Result As DialogResult
        If txtHapusPegawai.Text <> "" Then
            Try
                With CmdTrans
                    Result = MsgBox("Yakin akan menghapus " & txtHapusPegawai.Text & "?", vbQuestion + vbYesNo, "Delete Record") = vbYes = True
                    If Result = True Then
                        .CommandText = "delete_pegawai"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("del_delete_pegawai", MySqlDbType.Int64, 11).Value = txtHapusPegawai.Text
                        .ExecuteNonQuery()
                        SqlTrans.Commit()
                        Bunifu.Snackbar.Show(Me, "Data Berhasil di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
                        LoadDataPegawai()
                    End If
                End With
            Catch ex As Exception
                SqlTrans.Rollback()
                Bunifu.Snackbar.Show(Me, "Data Gagal di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error, "Dismiss")
            Finally
                SqlTrans.Dispose()
                CmdTrans.Dispose()
            End Try
        End If

    End Sub

    Private Sub btnRefreshPegawai_Click(sender As Object, e As EventArgs) Handles btnRefreshPegawai.Click
        LoadDataPegawai()
    End Sub

    Private Sub DataPegawai_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataPegawai.CellContentClick

        Dim row As DataGridViewRow = DataPegawai.CurrentRow
        Try
            txtHapusPegawai.Text = row.Cells(0).Value.ToString()
        Catch ex As Exception

        End Try

        ' Update Data
        Dim p As Integer
        p = DataPegawai.CurrentRow.Index
        _namapegawai = DataPegawai.Item(1, p).Value
        _emailpegawai = DataPegawai.Item(2, p).Value
        _alamatpegawai = DataPegawai.Item(3, p).Value
        _usernamepegawai = DataPegawai.Item(4, p).Value
        _passwordpegawai = DataPegawai.Item(5, p).Value

    End Sub

    Private Sub txtSearchPegawai_TextChanged(sender As Object, e As EventArgs) Handles txtSearchPegawai.TextChanged

        Dim adapater As MySqlDataAdapter
        Dim ds As New DataSet
        Try

            adapater = New MySqlDataAdapter("select * from pegawai where nama like '%" & txtSearchPegawai.Text & "%'", SQL_CONNECTION_STRING)
                        adapater.Fill(ds)
            DataPegawai.DataSource = ds.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ExportExcelPegawai_Click(sender As Object, e As EventArgs) Handles ExportExcelPegawai.Click

        xlapp = New Excel.ApplicationClass
        xlworkbook = xlapp.Workbooks.Add(misValue)
        xlworksheet = xlworkbook.Sheets(1)


        SaveFilePegawai.Title = "Save To"
        SaveFilePegawai.Filter = "Excel Files |*.xlsx"
        SaveFilePegawai.ShowDialog()

        For s = 0 To DataPegawai.ColumnCount - 1
            xlworksheet.Cells(1, s + 1) = DataMobil.Columns(s).Name.ToString
        Next

        For i = 0 To DataPegawai.RowCount - 2
            For j = 0 To DataMobil.ColumnCount - 1
                xlworksheet.Cells(i + 2, j + 1) = DataMobil(j, i).Value.ToString
            Next
        Next

        Try
            xlworkbook.SaveAs(txtHapusPegawai.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        xlworkbook.Close()
        xlapp.Quit()
        ReleaseObject(xlapp)
        ReleaseObject(xlworkbook)
        ReleaseObject(xlworksheet)

        Bunifu.Snackbar.Show(Me, "Data Berhasil di Export", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Success)

    End Sub

    Private Sub SaveFilePegawai_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFilePegawai.FileOk
        txtHapusPegawai.Text = SaveFilePegawai.FileName
    End Sub

    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '

    'Data Untuk Brand
    'Data Untuk Brand
    'Data Untuk Brand

    Private Sub btnAddBrand_Click(sender As Object, e As EventArgs) Handles btnAddBrand.Click

        TransparentBg.Show()
        With AddBrand
            .btnUpdate.Enabled = False
            .btnAddContact.Enabled = True
            .txtMerk.Text = _merkmobil
            .ShowDialog()
        End With

    End Sub

    Private Sub btnEditBrand_Click(sender As Object, e As EventArgs) Handles btnEditBrand.Click

        TransparentBg.Show()
        With AddBrand
            .btnAddContact.Enabled = False
            .btnUpdate.Enabled = True
            .txtMerk.Text = _merkmobil
            .ShowDialog()
        End With

    End Sub

    Private Sub btnHapusBrand_Click(sender As Object, e As EventArgs) Handles btnHapusBrand.Click
        DeleteBrand()
    End Sub

    Private Sub txtSearchBrand_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBrand.TextChanged

        Dim adapater As MySqlDataAdapter
        Dim ds As New DataSet
        Try

            adapater = New MySqlDataAdapter("select * from merk where merk like '%" & txtSearchBrand.Text & "%'", SQL_CONNECTION_STRING)
            adapater.Fill(ds)
            DataBrand.DataSource = ds.Tables(0)

        Catch ex As Exception

        End Try
    End Sub

    Sub DeleteBrand()

        Dim SqlTrans As MySqlTransaction = Conn.BeginTransaction
        Dim CmdTrans As MySqlCommand = Conn.CreateCommand
        Dim Result As DialogResult
        If txtHapusBrand.Text <> "" Then
            Try
                With CmdTrans
                    Result = MsgBox("Yakin akan menghapus " & txtHapusBrand.Text & "?", vbQuestion + vbYesNo, "Delete Record") = vbYes = True
                    If Result = True Then
                        .CommandText = "delete_merk"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("del_merk", MySqlDbType.VarChar, 30).Value = txtHapusBrand.Text
                        .ExecuteNonQuery()
                        SqlTrans.Commit()
                        Bunifu.Snackbar.Show(Me, txtHapusBrand.Text.Trim + " Berhasil di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
                    End If
                End With
            Catch ex As Exception
                SqlTrans.Rollback()
                Bunifu.Snackbar.Show(Me, "Data Gagal di Hapus", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
            Finally
                LoadDataBrand()
                SqlTrans.Dispose()
                CmdTrans.Dispose()
            End Try
        End If

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDataBrand()
    End Sub

    Private Sub DataBrand_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataBrand.CellContentClick

        Dim row As DataGridViewRow = DataBrand.CurrentRow
        Try
            txtHapusBrand.Text = row.Cells(0).Value.ToString()
        Catch ex As Exception

        End Try

        Dim i As Integer
        i = DataBrand.CurrentRow.Index
        _merkmobil = DataBrand.Item(0, i).Value


    End Sub

    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '
    ' --------------------------------------------------------------------- '

    ' Button Clicked
    ' Button Clicked
    ' Button Clicked

    Private Sub btnLogout_Click_1(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        BunifuPages1.SetPage(0)
    End Sub

    Private Sub btnDatabase_Click(sender As Object, e As EventArgs) Handles btnDatabase.Click
        BunifuPages1.SetPage(1)
    End Sub

    Private Sub btnPegawai_Click(sender As Object, e As EventArgs) Handles btnPegawai.Click
        BunifuPages1.SetPage(2)
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        BunifuPages1.SetPage(3)
    End Sub

    Private Sub btnBrand_Click(sender As Object, e As EventArgs) Handles btnBrand.Click
        BunifuPages1.SetPage(4)
    End Sub

    Private Sub bunifuImageButton1_Click(sender As Object, e As EventArgs) Handles bunifuImageButton1.Click
        Application.Exit()
    End Sub


    Private Sub ReleaseObject(ByVal obj As Object)

        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            GC.Collect()
        End Try

    End Sub

End Class