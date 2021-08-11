Public Class frm_makeorder_a175835

    Dim number As Double
    Dim num As Integer
    Dim current_code As String
    Private Sub frm_makeorder_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        refresh_grid()
        get_current_code()
        Dim current_date As String = Date.Now
        txt_date.Text = current_date
        refresh_count()
        refresh_staff()
        btn_addtocart.Enabled = False
        btn_confirm.Enabled = False
        btn_delete.Enabled = False


        Dim mysql As String = "SELECT * FROM TBL_PRODUCT_A175835 order by FLD_PRODUCT_ID"

        Dim mytable As New DataTable

        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)

        myreader.Fill(mytable)

        lst_product.DataSource = mytable
        lst_product.DisplayMember = "FLD_PRODUCT_ID"


        refresh_text(lst_product.Text)

    End Sub

    Private Sub lst_product_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_product.SelectedIndexChanged

    End Sub

    Private Sub lst_product_MouseClick(sender As Object, e As MouseEventArgs) Handles lst_product.MouseClick

        refresh_text(lst_product.Text)

    End Sub

    Private Sub get_current_code()
        Dim current_row As Integer = grd_customer.CurrentRow.Index
        current_code = grd_customer(0, current_row).Value
        txt_customercode.Text = current_code
        txt_customername.Text = grd_customer(1, current_row).Value
        txt_customercontact.Text = grd_customer(2, current_row).Value

    End Sub

    Private Sub grd_customer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_customer.CellContentClick

    End Sub

    Private Sub grd_customer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_customer.CellClick

        get_current_code()

    End Sub

    Private Sub refresh_grid()
        Dim mysql2 As String = "SELECT * FROM TBL_CUSTOMER_A175835 order by FLD_CUST_ID"
        Dim mytable2 As New DataTable
        Dim myreader2 As New OleDb.OleDbDataAdapter(mysql2, myconnection)
        myreader2.Fill(mytable2)
        grd_customer.DataSource = mytable2
        grd_customer.Columns(0).HeaderText = "Customer Code"
        grd_customer.Columns(1).HeaderText = "Customer Name"
        grd_customer.Columns(2).HeaderText = "Customer Contact"

    End Sub
    Private Sub refresh_count()

        Dim count As Integer = 1
        Dim mysql As String = "SELECT COUNT(FLD_ORDER_ID) As count_id FROM TBL_ORDER_A175835"
        Dim mydatatable As New DataTable
        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)
        myreader.Fill(mydatatable)
        count += mydatatable.Rows(0).Item("count_id")
        lbl_orderID.Text = "ORD" + count.ToString("000")

    End Sub

    Private Sub refresh_staff()

        Dim mysql As String = "SELECT FLD_STAFF_ID FROM TBL_STAFF_A175835"
        Dim mydatatable As New DataTable
        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)
        myreader.Fill(mydatatable)
        cmb_staffid.DataSource = mydatatable
        cmb_staffid.DisplayMember = "FLD_STAFF_ID"

    End Sub

    Private Sub btn_neworder_Click(sender As Object, e As EventArgs) Handles btn_neworder.Click

        Dim mytransaction As OleDb.OleDbTransaction
        myconnection2.Open()
        mytransaction = myconnection2.BeginTransaction

        Try

            Dim mysql As String = "INSERT INTO TBL_ORDER_A175835 (FLD_ORDER_ID,FLD_CUST_ID,FLD_ORDER_DATE,FLD_STAFF_ID) values (""" &
            lbl_orderID.Text & """,""" & txt_customercode.Text & """,""" & txt_date.Text & """,""" & cmb_staffid.Text & """)"

            Dim mywriter As New OleDb.OleDbCommand(mysql, myconnection2,
            mytransaction)

            mywriter.ExecuteNonQuery()
            mytransaction.Commit()
            myconnection2.Close()
            Beep()
            MsgBox("You can make new order now!")
            refresh_grid()
            grd_productorder.Rows.Clear()

        Catch ex As Exception

            Beep()
            MsgBox("Problem with transaction:" & vbCrLf & vbCrLf & ex.Message)
            mytransaction.Rollback()
            myconnection2.Close()
            refresh_grid()

        End Try

        btn_addtocart.Enabled = True
        btn_confirm.Enabled = True
        btn_delete.Enabled = True
        btn_neworder.Enabled = False


    End Sub
    Private Sub refresh_price()

        If grd_productorder.RowCount > 0 Then
            Dim sbttls As Double
            sbttls = 0

            For index As Integer = 0 To grd_productorder.RowCount - 1
                sbttls += Convert.ToDouble(grd_productorder.Rows(index).Cells(3).Value)
            Next

            lbl_total.Text = "RM " & sbttls

        ElseIf grd_productorder.RowCount = 0 Then

            lbl_total.Text = "RM 0.00"

        End If

    End Sub

    Private Sub btn_addtocart_Click(sender As Object, e As EventArgs) Handles btn_addtocart.Click

        grd_productorder.Rows.Add(New String() {txt_productcode.Text, txt_productname.Text, nud_quantity.Value, txt_total.Text})
        nud_quantity.Value = 1
        refresh_price()

    End Sub
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Dim delete_order = MsgBox("Confirm to delete this item from list?", MsgBoxStyle.YesNo)

        If delete_order = MsgBoxResult.Yes Then
            grd_productorder.Rows.Remove(grd_productorder.CurrentRow)
            refresh_price()
        Else
            refresh_price()
        End If
    End Sub

    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim mytransaction As OleDb.OleDbTransaction
        myconnection2.Open()

        mytransaction = myconnection2.BeginTransaction

        Try
            For i As Integer = 0 To grd_productorder.RowCount - 2
                Dim productid As String = grd_productorder(0, i).Value
                Dim productname As String = grd_productorder(1, i).Value
                Dim quantity As String = grd_productorder(2, i).Value
                Dim price As String = grd_productorder(3, i).Value

                Dim mysql As String = "insert into TBL_ORDER_DETAILS_A175835(FLD_ORDER_ID, FLD_PRODUCT_ID, FLD_PRODUCT_NAME, FLD_QUANTITY, FLD_PRICE) values (""" & lbl_orderID.Text & """,""" & productid & """, """ & productname & """, """ & quantity & """, """ & price & """)"
                Dim mywriter As New OleDb.OleDbCommand(mysql, myconnection2, mytransaction)


                mywriter.ExecuteNonQuery()

            Next
            mytransaction.Commit()
            myconnection2.Close()
            Beep()
            MsgBox("Transaction successful!")
            refresh_grid()
            grd_productorder.Rows.Clear()

        Catch ex As Exception
            Beep()
            MsgBox("Problem with transaction:" & vbCrLf & vbCrLf & ex.Message)
            mytransaction.Rollback()
            myconnection2.Close()
            refresh_grid()

        End Try

        btn_addtocart.Enabled = False
        btn_confirm.Enabled = False
        btn_delete.Enabled = False
        btn_neworder.Enabled = True
        nud_quantity.Value = 1
        lbl_total.Text = "0"
        refresh_count()
    End Sub

    Private Sub btn_printinvoice_Click(sender As Object, e As EventArgs) Handles btn_printinvoice.Click
        frm_vieworder_a175835.Show()
        Me.Hide()
    End Sub



    Private Sub refresh_text(product As String)
        Dim mysql As String = "SELECT * FROM TBL_PRODUCT_A175835 WHERE FLD_PRODUCT_ID='" & product & "'"
        Dim mydatatable As New DataTable
        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)
        myreader.Fill(mydatatable)
        txt_productcode.Text = mydatatable.Rows(0).Item("FLD_PRODUCT_ID")
        txt_productname.Text = mydatatable.Rows(0).Item("FLD_PRODUCT_NAME")
        txt_price.Text = mydatatable.Rows(0).Item("FLD_PRICE")
        txt_brand.Text = mydatatable.Rows(0).Item("FLD_BRAND")
        txt_producttype.Text = mydatatable.Rows(0).Item("FLD_TYPE")
        txt_wireinvolvement.Text = mydatatable.Rows(0).Item("FLD_WIRE_INVOLVEMENT")
        txt_description.Text = mydatatable.Rows(0).Item("FLD_DESCRIPTION")
        txt_total.Text = num * txt_price.Text

        Try

            pic_product.BackgroundImage = Image.FromFile("Product pictures/" & product & ".jpg")

        Catch ex As Exception

            pic_product.BackgroundImage = Image.FromFile("Product pictures/nophoto.jpg")

        End Try
    End Sub

    Private Sub nud_quantity_ValueChanged(sender As Object, e As EventArgs) Handles nud_quantity.ValueChanged
        num = nud_quantity.Value
        number = txt_price.Text()
        txt_total.Text = num * number
    End Sub



    Private Sub lbl_makeform_date_Click(sender As Object, e As EventArgs) Handles lbl_makeorder_date.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim current_date As String = Date.Now
        lbl_makeorder_date.Text = current_date
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click

        frm_mainmenu_a175835.Show()
        Me.Close()

    End Sub
End Class
