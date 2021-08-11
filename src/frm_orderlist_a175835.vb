Public Class frm_orderlist_a175835
    Private Sub frm_orderlist_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        Dim myconnection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_antiqueelectronics_a175835.accdb;Persist Security Info=False;"

        Dim mysql As String = "select * from TBL_ORDER_A175835"

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        grd_order.DataSource = mytable

        grd_order.Columns(0).HeaderText = "Order Code"
        grd_order.Columns(1).HeaderText = "Customer Code"
        grd_order.Columns(2).HeaderText = "Staff Code"
        grd_order.Columns(3).HeaderText = "Date"


        lbl_date.BackColor = Color.Transparent


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim current_date As String = Date.Now
        lbl_date.Text = current_date

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lbl_date.Click

    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        frm_mainmenu_a175835.Show()
        Me.Close()
    End Sub

End Class