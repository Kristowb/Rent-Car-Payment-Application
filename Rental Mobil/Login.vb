Imports MySql.Data.MySqlClient

Public Class Login

    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=rental_mobil")

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnLoginAdmin_Click(sender As Object, e As EventArgs) Handles btnLoginAdmin.Click

        'Menu_Admin.Show()
        'Me.Hide()

        Dim userModel As New UserModel
        Dim validLogin = userModel.LoginAdmin(txtUsernameAdmin.Text, txtPasswordAdmin.Text)

        If validLogin = True Then
            Me.Hide()
            Menu_Welcome.ShowDialog()
            Menu_Admin.Show()

            txtUsernameAdmin.Clear()
            txtPasswordAdmin.Clear()
        Else
            Bunifu.Snackbar.Show(Me, "Invalid username atau Password ", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
            txtUsernameAdmin.Clear()
            txtPasswordAdmin.Clear()
        End If

    End Sub


    Private Sub btnLoginPegawai_Click(sender As Object, e As EventArgs) Handles btnLoginPegawai.Click

        Dim userModel As New UserModel

        Dim validLoginPegawai = userModel.LoginPegawai(txtUsernamePegawai.Text, txtPasswordPegawai.Text)

        If validLoginPegawai = True Then
            Me.Hide()
            Menu_Welcome_Pegawai.ShowDialog()
            Menu_Pegawai.Show()

            txtUsernamePegawai.Clear()
            txtPasswordPegawai.Clear()
        Else
            Bunifu.Snackbar.Show(Me, "Invalid username atau Password ", 3000, Snackbar.Views.SnackbarDesigner.MessageTypes.Error)
            txtUsernamePegawai.Clear()
            txtPasswordPegawai.Clear()
        End If

    End Sub


    Private Sub WelcomeLogin_Click(sender As Object, e As EventArgs) Handles WelcomeLogin.Click
        BunifuPages1.SetPage(1)
    End Sub

    Private Sub BtnSlidePegawai_Click(sender As Object, e As EventArgs) Handles BtnSlidePegawai.Click
        BunifuPages1.SetPage(2)
    End Sub

    Private Sub BtnSlideAdmin_Click(sender As Object, e As EventArgs) Handles BtnSlideAdmin.Click
        BunifuPages1.SetPage(1)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Menu_Admin.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Menu_Pegawai.Show()
        Me.Hide()
    End Sub

    Private Sub bunifuImageButton1_Click(sender As Object, e As EventArgs) Handles bunifuImageButton1.Click
        Me.Close()
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Me.Close()
    End Sub

    Private Sub ShowPass_Click(sender As Object, e As EventArgs) Handles ShowPass.Click

        If txtPasswordPegawai.UseSystemPasswordChar = True Then
            txtPasswordPegawai.UseSystemPasswordChar = False
            HidePass.BringToFront()

        End If

    End Sub

    Private Sub HidePass_Click(sender As Object, e As EventArgs) Handles HidePass.Click

        If txtPasswordPegawai.UseSystemPasswordChar = False Then
            txtPasswordPegawai.UseSystemPasswordChar = True
            ShowPass.BringToFront()

        End If

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPasswordPegawai.UseSystemPasswordChar = True
        txtPasswordAdmin.UseSystemPasswordChar = True
        ShowPassAdmin.IconVisible = True
        HidePassAdmin.IconVisible = True
        ShowPass.IconVisible = True
        HidePass.IconVisible = True
    End Sub

    Private Sub ShowPassAdmin_Click(sender As Object, e As EventArgs) Handles ShowPassAdmin.Click

        If txtPasswordAdmin.UseSystemPasswordChar = True Then
            txtPasswordAdmin.UseSystemPasswordChar = False
            HidePassAdmin.BringToFront()

        End If

    End Sub

    Private Sub HidePassAdmin_Click(sender As Object, e As EventArgs) Handles HidePassAdmin.Click

        If txtPasswordAdmin.UseSystemPasswordChar = False Then
            txtPasswordAdmin.UseSystemPasswordChar = True
            ShowPassAdmin.BringToFront()

        End If

    End Sub
End Class