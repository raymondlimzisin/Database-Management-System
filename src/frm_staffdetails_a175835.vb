Public Class frm_staffdetails_a175835
    Private Sub frm_staffdetails_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        Dim mysql As String = "select FLD_STAFF_ID from TBL_STAFF_A175835 order by FLD_STAFF_ID"

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        lst_staffcode.DataSource = mytable
        lst_staffcode.DisplayMember = "FLD_STAFF_ID"

        refresh_text(lst_staffcode.Text)

    End Sub
    Private Sub refresh_text(STAFF_ID As String)

        Dim mysql As String = "select * from TBL_STAFF_A175835 where FLD_STAFF_ID ='" & STAFF_ID & "'"

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        txt_staffcode.Text = mytable.Rows(0).Item("FLD_STAFF_ID")
        txt_staffname.Text = mytable.Rows(0).Item("FLD_STAFF_NAME")
        txt_contact.Text = mytable.Rows(0).Item("FLD_STAFF_CONTACT")


        Try

            pic_staff.BackgroundImage = Image.FromFile("Staff pictures/" & STAFF_ID & ".jpg")

        Catch ex As Exception

            pic_staff.BackgroundImage = Image.FromFile("Staff pictures/nophoto.jpg")

        End Try





    End Sub

    Private Sub lst_staffcode_MouseClick(sender As Object, e As MouseEventArgs) Handles lst_staffcode.MouseClick

        refresh_text(lst_staffcode.Text)

    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        frm_mainmenu_a175835.Show()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim current_date As String = Date.Now
        lbl_date.Text = current_date
    End Sub
End Class