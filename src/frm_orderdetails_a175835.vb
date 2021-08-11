Public Class frm_orderdetails_a175835
    Private Sub frm_orderdetails_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        Dim mysql As String = "select * from TBL_ORDER_DETAILS_A175835"

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        grd_ordertdetails.DataSource = mytable

        grd_ordertdetails.Columns(0).HeaderText = "Order Code"
        grd_ordertdetails.Columns(1).HeaderText = "Product Code"
        grd_ordertdetails.Columns(2).HeaderText = "Product Name"
        grd_ordertdetails.Columns(3).HeaderText = "Quantity"


    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        frm_mainmenu_a175835.Show()
        Me.Close()
    End Sub

    Private Sub lbl_date_Click(sender As Object, e As EventArgs) Handles lbl_date.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim current_date As String = Date.Now
        lbl_date.Text = current_date

    End Sub
End Class