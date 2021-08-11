Public Class frm_updateproduct_a175835

    Dim current_code As String
    Private Sub frm_updateproduct_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        cmb_type.Items.Add("Amplifier")
        cmb_type.Items.Add("Calculator")
        cmb_type.Items.Add("Capacitors")
        cmb_type.Items.Add("Cassette")
        cmb_type.Items.Add("Cassette Deck")
        cmb_type.Items.Add("Channel Divider")
        cmb_type.Items.Add("DVD LD PLAYER")
        cmb_type.Items.Add("Horn")
        cmb_type.Items.Add("Mechanical Calculator")
        cmb_type.Items.Add("Noise Meter")
        cmb_type.Items.Add("Radio tube")
        cmb_type.Items.Add("Recorder")
        cmb_type.Items.Add("Speaker")
        cmb_type.Items.Add("Tone arm")
        cmb_type.Items.Add("Cassette")
        cmb_type.Items.Add("Transformer")
        cmb_type.Items.Add("Tube Amplifier")
        cmb_type.Items.Add("Tube Pre-Amplifier")
        cmb_type.Items.Add("Tuner")
        cmb_type.Items.Add("Turntable")
        cmb_type.Items.Add("Vacuum Tube")
        cmb_type.Items.Add("VCR-DVD")
        cmb_type.Items.Add("Wristwatch")


        cmb_wireinvolvement.Items.Add("Wired")
        cmb_wireinvolvement.Items.Add("Wireless")

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

    Private Sub get_current_code()

        Dim current_row As Integer = grd_product.CurrentRow.Index

        current_code = grd_product(0, current_row).Value

        txt_productcode.Text = current_code
        txt_productname.Text = grd_product(1, current_row).Value
        txt_price.Text = grd_product(2, current_row).Value
        txt_description.Text = grd_product(3, current_row).Value
        txt_brand.Text = grd_product(4, current_row).Value
        cmb_type.Text = grd_product(5, current_row).Value
        cmb_wireinvolvement.Text = grd_product(6, current_row).Value




    End Sub

    Private Sub grd_product_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_product.CellClick

        get_current_code()

    End Sub



    Private Sub grd_product_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_product.CellContentClick

    End Sub

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_update.Click

        run_command("update TBL_PRODUCT_A175835 set  FLD_PRODUCT_NAME = '" & txt_productname.Text & "', FLD_PRICE = '" & txt_price.Text & "', FLD_DESCRIPTION = '" & txt_description.Text & "', FLD_BRAND = '" & txt_brand.Text & "', FLD_TYPE = '" & cmb_type.Text & "', FLD_WIRE_INVOLVEMENT = '" & cmb_wireinvolvement.Text & "' where FLD_PRODUCT_ID = '" & current_code & "'")

        refresh_grid()
        get_current_code()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_deleteproduct.Click



        Beep()
        Dim delete_confirmation = MsgBox("Are you SURE you would like to delete the product " & current_code & "?", MsgBoxStyle.YesNo)

        If delete_confirmation = MsgBoxResult.Yes Then

            run_command("delete from TBL_PRODUCT_A175835  where FLD_PRODUCT_ID = '" & current_code & "'")
            Beep()
            MsgBox("The product " & current_code & " has been deleted successfully")

            refresh_grid()
            get_current_code()

        End If





    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim current_date As String = Date.Now
        lbl_date.Text = current_date

    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        frm_mainmenu_a175835.Show()
        Me.Close()
    End Sub
End Class