Public Class frm_insertcustomer_a175835

    Dim defaultpicture As String = Application.StartupPath & "\Customer pictures\nophoto.jpg"
    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insertcustomer.Click

        Dim mysql As String = "insert into TBL_CUSTOMER_A175835 values ('" & txt_customercode.Text & "', '" & txt_customername.Text & "','" & txt_customercontact.Text & "')"

        MsgBox(mysql)

        Dim mywriter As New OleDb.OleDbCommand(mysql, myconnection2)

        Try

            mywriter.Connection.Open()
            mywriter.ExecuteNonQuery()
            mywriter.Connection.Close()

            My.Computer.FileSystem.CopyFile(txt_customerphoto.Text, "Customer pictures\" & txt_customercode.Text & ".jpg")

            refresh_grid()
            txt_customername.Text = ""
            txt_customercontact.Text = ""

        Catch ex As Exception

            Beep()
            MsgBox("There is a mistake in the data that you entered as shown below: " & vbCrLf & vbCrLf & ex.Message)
            mywriter.Connection.Close()

        End Try
    End Sub


    Private Sub frm_insertcustomer_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Timer1.Enabled = True

        refresh_grid()

    End Sub

    Private Sub refresh_grid()

        grd_customer.DataSource = run_select("select * from TBL_CUSTOMER_A175835 order by FLD_CUST_ID ")

        txt_customercode.Text = generate_customerID()

        txt_customerphoto.Text = defaultpicture
        pic_customer.BackgroundImage = Image.FromFile(defaultpicture)


        grd_customer.Columns(0).HeaderText = "Customer Code"
        grd_customer.Columns(1).HeaderText = "Customer Name"
        grd_customer.Columns(2).HeaderText = "Customer Contact"



    End Sub
    Private Function generate_customerID() As String

        Dim lastcustomerID As String = run_select("select max(FLD_CUST_ID) as maxcustomerID from TBL_CUSTOMER_A175835").Rows(0).Item("maxcustomerID")

        'MsgBox(lastcustomerID)

        Dim newcustomerID As String = "C" & Mid(lastcustomerID, 2) + 1

        Return newcustomerID

    End Function

    Private Sub grd_customer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_customer.CellContentClick

    End Sub

    Private Sub btn_customerpic_Click(sender As Object, e As EventArgs) Handles btn_customerpic.Click

        Dim mydesktop As String = My.Computer.FileSystem.SpecialDirectories.Desktop

        OpenFileDialog1.InitialDirectory = mydesktop
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG files (*.jpg|*.jpg"
        OpenFileDialog1.ShowDialog()

        txt_customerphoto.Text = OpenFileDialog1.FileName
        pic_customer.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)

    End Sub

    Private Sub txt_customercode_TextChanged(sender As Object, e As EventArgs) Handles txt_customercode.TextChanged

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