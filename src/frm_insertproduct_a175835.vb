Public Class frm_insertproduct_a175835

    Dim defaultpicture As String = Application.StartupPath & "\Product pictures\noproductphoto.jpg"
    Private Sub frm_insertproduct_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        'Dim mysql As String = "select FLD_TYPE from TBL_PRODUCT_A175835"

        'Dim mytable As New DataTable

        'Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        'myreader.Fill(mytable)

        'cmb_type.DataSource = mytable
        'cmb_type.DisplayMember = "FLD_TYPE"


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

        txt_productcode.Text = generate_productID()

        txt_productphoto.Text = defaultpicture
        pic_product.BackgroundImage = Image.FromFile(defaultpicture)

        grd_product.Columns(0).HeaderText = "Product Code"
        grd_product.Columns(1).HeaderText = "Product Name"
        grd_product.Columns(2).HeaderText = "Price"
        grd_product.Columns(3).HeaderText = "Description"
        grd_product.Columns(4).HeaderText = "Brand"
        grd_product.Columns(5).HeaderText = "Type"
        grd_product.Columns(6).HeaderText = "Wire Involvement"


    End Sub

    Private Function generate_productID() As String

        Dim lastproductID As String = run_select("select max(FLD_PRODUCT_ID) as maxproductID from TBL_PRODUCT_A175835").Rows(0).Item("maxproductID")

        'MsgBox(lastproductID)

        Dim newproductID As String = "A" & Mid(lastproductID, 2) + 1

        Return newproductID

    End Function
    Private Sub txt_brand_TextChanged(sender As Object, e As EventArgs) Handles txt_brand.TextChanged

    End Sub

    Private Sub txt_price_TextChanged(sender As Object, e As EventArgs) Handles txt_price.TextChanged

    End Sub

    Private Sub txt_productname_TextChanged(sender As Object, e As EventArgs) Handles txt_productname.TextChanged

    End Sub

    Private Sub clear_fields()

        'txt_productcode.Text = ""
        txt_productname.Text = ""
        txt_brand.Text = ""
        txt_price.Text = ""
        txt_description.Text = ""
        cmb_type.SelectedIndex = 0
        cmb_wireinvolvement.SelectedIndex = 0

    End Sub

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click

        Dim mysql As String = "insert into TBL_PRODUCT_A175835 values('" & txt_productcode.Text & "','" & txt_productname.Text & "','" & txt_brand.Text & "','" & txt_price.Text & "','" & cmb_wireinvolvement.Text & "','" & cmb_type.Text & "','" & txt_description.Text & "')"

        MsgBox(mysql)

        Dim mywriter As New OleDb.OleDbCommand(mysql, myconnection2)

        Try

            mywriter.Connection.Open()
            mywriter.ExecuteNonQuery()
            mywriter.Connection.Close()

            refresh_grid()
            clear_fields()

        Catch ex As Exception

            Beep()
            MsgBox("There is a mistake in the data you entered:  " & ex.Message)
            mywriter.Connection.Close()

        End Try



    End Sub

    Private Sub lbl_price_Click(sender As Object, e As EventArgs) Handles lbl_price.Click

    End Sub

    Private Sub btn_productpic_Click(sender As Object, e As EventArgs) Handles btn_productpic.Click

        Dim mydesktop As String = My.Computer.FileSystem.SpecialDirectories.Desktop

        OpenFileDialog1.InitialDirectory = mydesktop
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG files (*.jpg|*.jpg"
        OpenFileDialog1.ShowDialog()

        txt_productphoto.Text = OpenFileDialog1.FileName
        pic_product.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)

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