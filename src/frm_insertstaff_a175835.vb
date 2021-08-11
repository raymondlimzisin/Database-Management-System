Public Class frm_insertstaff_a175835

    Dim defaultpicture As String = Application.StartupPath & "\Staff pictures\nophoto.jpg"

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_staff.CellContentClick

    End Sub

    Private Sub frm_insertstaff_a175835_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        refresh_grid()

    End Sub

    Private Sub refresh_grid()

        grd_staff.DataSource = run_select("select * from TBL_STAFF_A175835 order by FLD_STAFF_ID")

        txt_staffcode.Text = generate_staffID()

        txt_staffphoto.Text = defaultpicture
        pic_staff.BackgroundImage = Image.FromFile(defaultpicture)


        grd_staff.Columns(0).HeaderText = "Staff Code"
        grd_staff.Columns(1).HeaderText = "Staff Name"
        grd_staff.Columns(2).HeaderText = "Staff Contact"



    End Sub

    Private Function generate_staffID() As String

        Dim laststaffID As String = run_select("select max(FLD_STAFF_ID) as maxstaffID from TBL_STAFF_A175835").Rows(0).Item("maxstaffID")

        'MsgBox(laststaffID)

        Dim newstaffID As String = "S" & Mid(laststaffID, 2) + 1

        Return newstaffID

    End Function

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insertstaff.Click

        Dim mysql As String = "insert into TBL_STAFF_A175835 values ('" & txt_staffcode.Text & "', '" & txt_staffname.Text & "','" & txt_staffcontact.Text & "')"

        MsgBox(mysql)

        Dim mywriter As New OleDb.OleDbCommand(mysql, myconnection2)

        Try

            mywriter.Connection.Open()
            mywriter.ExecuteNonQuery()
            mywriter.Connection.Close()

            My.Computer.FileSystem.CopyFile(txt_staffphoto.Text, "Staff pictures\" & txt_staffcode.Text & ".jpg")

            refresh_grid()
            txt_staffname.Text = ""
            txt_staffcontact.Text = ""

        Catch ex As Exception

            Beep()
            MsgBox("There is a mistake in the data that you entered as shown below: " & vbCrLf & vbCrLf & ex.Message)
            mywriter.Connection.Close()

        End Try

    End Sub

    Private Sub btn_staffpic_Click(sender As Object, e As EventArgs) Handles btn_staffpic.Click

        Dim mydesktop As String = My.Computer.FileSystem.SpecialDirectories.Desktop

        OpenFileDialog1.InitialDirectory = mydesktop
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG files (*.jpg|*.jpg"
        OpenFileDialog1.ShowDialog()

        txt_staffphoto.Text = OpenFileDialog1.FileName
        pic_staff.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)

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