Public Class frm_updatecustomer_a175835

    Dim current_code As String
    Private Sub frm_updatecustomer_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        refresh_grid()

    End Sub

    Private Sub refresh_grid()

        grd_customer.DataSource = run_select("select * from TBL_CUSTOMER_A175835 order by FLD_CUST_ID")

        grd_customer.Columns(0).HeaderText = "Customer Code"
        grd_customer.Columns(1).HeaderText = "Customer Name"
        grd_customer.Columns(2).HeaderText = "Customer Contact"

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

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click

        run_command("update TBL_CUSTOMER_A175835 set FLD_CUST_NAME = '" & txt_customername.Text & "', FLD_CUST_CONTACT = '" & txt_customercontact.Text & "' where FLD_CUST_ID = '" & current_code & "'")
        refresh_grid()
        get_current_code()

    End Sub

    Private Sub btn_deletecustomer_Click(sender As Object, e As EventArgs) Handles btn_deletecustomer.Click

        Beep()
        Dim delete_confirmation = MsgBox("Are you SURE you would like to delete the customer " & current_code & "?", MsgBoxStyle.YesNo)

        If delete_confirmation = MsgBoxResult.Yes Then

            run_command("delete from TBL_CUSTOMER_A175835  where FLD_CUST_ID = '" & current_code & "'")
            Beep()
            MsgBox("The customer " & current_code & " has been deleted successfully")

            refresh_grid()
            get_current_code()

        End If

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