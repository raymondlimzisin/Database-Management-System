Public Class frm_productlist_a175835
    Private Sub frm_productlist_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        refresh_grid()

    End Sub

    Private Sub refresh_grid()

        Dim mysql As String = "select * from TBL_PRODUCT_A175835 order by FLD_PRODUCT_ID"

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        grd_product.DataSource = mytable

        grd_product.Columns(0).HeaderText = "Product Code"
        grd_product.Columns(1).HeaderText = "Product Name"
        grd_product.Columns(2).HeaderText = "Price"
        grd_product.Columns(3).HeaderText = "Description"
        grd_product.Columns(4).HeaderText = "Brand"
        grd_product.Columns(5).HeaderText = "Type"
        grd_product.Columns(6).HeaderText = "Wire Involvement"


    End Sub

    Private Sub grd_product_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_product.CellContentClick

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