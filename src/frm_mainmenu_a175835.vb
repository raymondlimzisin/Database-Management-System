Public Class frm_mainmenu_a175835

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click

        End

    End Sub

    Private Sub frm_mainmenu_a175835_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        End

    End Sub

    Private Sub frm_mainmenu_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True


        lbl_welcome.Text = "Welcome " & username & " to the Lim's Antique Electronic Store System!"


    End Sub

    Private Sub lbl_welcome_Click(sender As Object, e As EventArgs) Handles lbl_welcome.Click

    End Sub

    Private Sub btn_productlist_Click(sender As Object, e As EventArgs) Handles btn_productlist.Click

        frm_productlist_a175835.Show()

    End Sub

    Private Sub btn_productdetails_Click(sender As Object, e As EventArgs) Handles btn_productdetails.Click

        frm_productdetails_a175835.Show()

    End Sub

    Private Sub btn_customer_Click(sender As Object, e As EventArgs) Handles btn_customer.Click

        frm_customerdetails_a175835.Show()

    End Sub

    Private Sub btn_staff_Click(sender As Object, e As EventArgs) Handles btn_staff.Click

        frm_staffdetails_a175835.Show()

    End Sub

    Private Sub btn_order_Click(sender As Object, e As EventArgs) Handles btn_order.Click

        frm_orderlist_a175835.Show()

    End Sub

    Private Sub btn_orderdetails_Click(sender As Object, e As EventArgs) Handles btn_orderdetails.Click

        frm_orderdetails_a175835.Show()

    End Sub

    Private Sub lbl_date_Click(sender As Object, e As EventArgs) Handles lbl_date.Click

    End Sub

    Private Sub btn_insertproduct_Click(sender As Object, e As EventArgs) Handles btn_insertproduct.Click

        frm_insertproduct_a175835.Show()

    End Sub

    Private Sub btn_updateproduct_Click(sender As Object, e As EventArgs) Handles btn_updateproduct.Click

        frm_updateproduct_a175835.Show()

    End Sub

    Private Sub btn_insertcustomer_Click(sender As Object, e As EventArgs) Handles btn_insertcustomer.Click

        frm_insertcustomer_a175835.Show()

    End Sub

    Private Sub btn_updatecustomer_Click(sender As Object, e As EventArgs) Handles btn_updatecustomer.Click

        frm_updatecustomer_a175835.Show()

    End Sub

    Private Sub btn_insertstaff_Click(sender As Object, e As EventArgs) Handles btn_insertstaff.Click

        frm_insertstaff_a175835.Show()

    End Sub

    Private Sub btn_updatestaff_Click(sender As Object, e As EventArgs) Handles btn_updatestaff.Click

        frm_updatestaff_a175835.Show()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim current_date As String = Date.Now
        lbl_date.Text = current_date

    End Sub

    Private Sub btn_makeorder_Click(sender As Object, e As EventArgs) Handles btn_makeorder.Click

        frm_makeorder_a175835.Show()

    End Sub

    Private Sub btn_vieworder_Click(sender As Object, e As EventArgs)

        frm_vieworder_a175835.Show()

    End Sub

    Private Sub btn_vieworder_Click_1(sender As Object, e As EventArgs) Handles btn_vieworder.Click

        frm_vieworder_a175835.Show()

    End Sub
End Class