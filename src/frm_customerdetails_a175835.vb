Public Class frm_customerdetails_a175835
    Private Sub frm_customerlist_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        Dim mysql As String = "select FLD_CUST_ID from TBL_CUSTOMER_A175835 order by FLD_CUST_ID"

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        lst_customercode.DataSource = mytable
        lst_customercode.DisplayMember = "FLD_CUST_ID"

        refresh_text(lst_customercode.Text)

    End Sub

    Private Sub refresh_text(CUSTOMER_ID As String)

        Dim mysql As String = "select * from TBL_CUSTOMER_A175835 where FLD_CUST_ID ='" & CUSTOMER_ID & "'"

        'MsgBox(mysql)

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        txt_customercode.Text = mytable.Rows(0).Item("FLD_CUST_ID")
        txt_customername.Text = mytable.Rows(0).Item("FLD_CUST_NAME")
        txt_contact.Text = mytable.Rows(0).Item("FLD_CUST_CONTACT")


        pic_customer.BackgroundImage = Image.FromFile("Customer pictures/" & CUSTOMER_ID & ".jpg")


    End Sub

    Private Sub lst_customercode_MouseClick(sender As Object, e As MouseEventArgs) Handles lst_customercode.MouseClick

        refresh_text(lst_customercode.Text)

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