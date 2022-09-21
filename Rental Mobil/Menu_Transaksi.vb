Imports MySql.Data.MySqlClient
Public Class Menu_Transaksi

    Protected Const SQL_CONNECTION_STRING As String =
        "Server=localhost;Port=3306;Database=rental_mobil;UID=root"
    Protected strConn As String = SQL_CONNECTION_STRING

    Private DtSet As DataSet
    Private DtAdpt As MySqlDataAdapter
    Private DtView As DataView
    Private DtTable As DataTable

    Private Sub Menu_Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataTransaksi()
    End Sub

    Sub LoadDataTransaksi()

        Try
            Dim Scan As New MySqlConnection(strConn)
            Dim Query As String = "SELECT * FROM PEMINJAMAN WHERE nama_peminjam like '" & txtSearch.Text & "%'"
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

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadDataTransaksi()
    End Sub

    Private Sub txtPrintPDF_Click(sender As Object, e As EventArgs) Handles txtPrintPDF.Click
        TransparentBg2.Show()
        Dim DT As New DataTable
        Dim Cr As New CrTransLog

        DT.Columns.Add("no_transaksi")
        DT.Columns.Add("nama_peminjam")
        DT.Columns.Add("tgl_pinjam")
        DT.Columns.Add("total_bayar")

        For Each dr As DataGridViewRow In Me.DataTransaksi.Rows
            DT.Rows.Add(dr.Cells(0).Value, dr.Cells(3).Value, dr.Cells(5).Value, dr.Cells(6).Value)
        Next
        Cr.SetDataSource(DT)
        With Print
            .CrystalReportViewer1.ReportSource = Cr
            .ShowDialog()
        End With


    End Sub

    Private Sub bunifuImageButton1_Click(sender As Object, e As EventArgs) Handles bunifuImageButton1.Click
        Me.Dispose()
    End Sub
End Class