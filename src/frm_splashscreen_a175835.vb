Public Class frm_splashscreen_a175835
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_name.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lbl_welcome.Click

    End Sub

    Private Sub frm_splashscreen_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click

        'MsgBox("Welcome " & txt_name.Text & " to Lim's Antique Electronics Store System!")

        username = txt_name.Text

        frm_mainmenu_a175835.Show()
        Me.Hide()


    End Sub
End Class
