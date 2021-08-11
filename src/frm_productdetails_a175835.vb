Public Class frm_productdetails_a175835
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles lbl_wireinvolvement.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles lbl_select.Click

    End Sub

    Private Sub lbl_type_Click(sender As Object, e As EventArgs) Handles lbl_type.Click

    End Sub

    Private Sub lbl_price_Click(sender As Object, e As EventArgs) Handles lbl_price.Click

    End Sub

    Private Sub frm_productdetails_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Timer1.Enabled = True

        Dim mysql As String = "select FLD_PRODUCT_ID from TBL_PRODUCT_A175835 order by FLD_PRODUCT_ID"

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        lst_productcode.DataSource = mytable
        lst_productcode.DisplayMember = "FLD_PRODUCT_ID"

        refresh_text(lst_productcode.Text)

    End Sub

    Private Sub refresh_text(PRODUCT_ID As String)

        Dim mysql As String = "select * from TBL_PRODUCT_A175835 where FLD_PRODUCT_ID ='" & PRODUCT_ID & "'"

        'MsgBox(mysql)

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        txt_productcode.Text = mytable.Rows(0).Item("FLD_PRODUCT_ID")
        txt_productname.Text = mytable.Rows(0).Item("FLD_PRODUCT_NAME")
        txt_price.Text = mytable.Rows(0).Item("FLD_PRICE")
        txt_description.Text = mytable.Rows(0).Item("FLD_DESCRIPTION")
        txt_brand.Text = mytable.Rows(0).Item("FLD_BRAND")
        txt_type.Text = mytable.Rows(0).Item("FLD_TYPE")
        txt_wireinvolvement.Text = mytable.Rows(0).Item("FLD_WIRE_INVOLVEMENT")

        pic_product.BackgroundImage = Image.FromFile("Product pictures/" & PRODUCT_ID & ".jpg")


    End Sub

    Private Sub lst_productcode_MouseClick(sender As Object, e As MouseEventArgs) Handles lst_productcode.MouseClick

        refresh_text(lst_productcode.Text)

    End Sub

    Private Sub txt_brand_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub pic_product_Click(sender As Object, e As EventArgs) Handles pic_product.Click

    End Sub

    Private Sub lst_productcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_productcode.SelectedIndexChanged

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