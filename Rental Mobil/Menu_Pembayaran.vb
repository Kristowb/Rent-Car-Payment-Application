Imports MaterialSkin
Imports MySql.Data.MySqlClient
Public Class Menu_Pembayaran

    Dim str As String = "datasource=localhost;port=3306;username=root;password=;database=rental_mobil"
    Dim con As New MySqlConnection(str)

    Private Sub Menu_Pembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim skinManager As MaterialSkinManager = MaterialSkinManager.Instance
        skinManager.AddFormToManage(Me)
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT
        skinManager.ColorScheme = New ColorScheme(Primary.Blue900, Primary.Blue700, Primary.Blue900, Accent.LightBlue200, TextShade.WHITE)
    End Sub

    Public bayar As String

    Private Sub radioATM_Click(sender As Object, e As EventArgs) Handles radioATM.Click
        txtMetodeBayar.Text = "ATM  :"
        bayar = "ATM"
    End Sub

    Private Sub radioTunai_Click(sender As Object, e As EventArgs) Handles radioTunai.Click
        txtMetodeBayar.Text = "Tunai :"
        bayar = "Tunai"
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click

        If IS_EMPTY(txtPembayaran) = True Then Return
        If CDbl(txtPembayaran.Text) < CDbl(txtTotal.Text) Then
            MsgBox("Jumlah Uang Kurang...", vbExclamation)
            Return
        Else
            If MsgBox("Bayarkan?", vbYesNo + vbQuestion) = vbYes Then
                Dim sdate As String = Now.Date.ToString("yyyy-MM-dd")
                con.Open()
                cm = New MySqlCommand("insert into pembayaran(no_transaksi, nama_customer, pembayaran, bayar, tgl_pembayaran) values('" & txtNoTransaksi.Text & "','" & txtNamaCustomer.Text & "','" & bayar & "','" & CDbl(txtPembayaran.Text) & "','" & sdate & "')", con)
                cm.ExecuteNonQuery()
                con.Close()

                txtPembayaran.Text = "0"
                txtTotal.Text = "0"
                Menu_Peminjaman.LoadAutoNo()
                Menu_Peminjaman.ClearPeminjaman()
                Menu_Peminjaman.LoadDataTransaksi()
                Menu_Peminjaman.btnBayar.Enabled = False

                Me.Dispose()
                TransparentBg2.Close()
            End If
        End If

    End Sub

    Private Sub txtPembayaran_TextChanged(sender As Object, e As EventArgs) Handles txtPembayaran.TextChanged

        Try
            Dim _total As Double
            _total = CDbl(txtPembayaran.Text) - (txtTotal.Text)
            txtKembalian.Text = _total
        Catch ex As Exception

        End Try

    End Sub


    Private Sub txtPembayaran_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPembayaran.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub


    Sub GetChange()
        Try
            If CDbl(txtPembayaran.Text) >= CDbl(txtTotal.Text) Then
                txtKembalian.Text = Format(CDbl(txtPembayaran.Text) - CDbl(txtTotal.Text), "#,##0.00")
            End If
        Catch ex As Exception
            txtKembalian.Text = "0.00"
        End Try
    End Sub
End Class