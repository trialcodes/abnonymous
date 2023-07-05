Public Class student_registration
    Private Sub student_registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbox1()
        cbox3()
        cbox2()
        lv1_design()
        Button3.Enabled = False
        Button4.Enabled = False
        opencon()
        reload_graduated()
        reload_graduated2()
        reload_scholars1()
        reload_scholars2()
        reload_student_information()
    End Sub

    Sub lv1_design()
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = False
        ListView1.Columns.Clear()
        ListView1.Columns.Add("#", 0)
        ListView1.Columns.Add("ID Number", 150)
        ListView1.Columns.Add("Fullname", 200)
        ListView1.Columns.Add("Address", 200)
        ListView1.Columns.Add("Sex", 80)
        ListView1.Columns.Add("Birthdate", 100)
        ListView1.Columns.Add("Age", 60)
        ListView1.Columns.Add("Course", 100)
        ListView1.Columns.Add("Yr & Sec", 100)
        ListView1.Columns.Add("CFE - Fullname", 200)
        ListView1.Columns.Add("CFE - Address", 200)
        ListView1.Columns.Add("CFE - Contact Number", 200)
        ListView1.Columns.Add("Scholar ?", 100)
        ListView1.Columns.Add("Graduated ?", 100)
        ListView1.Columns.Add("Date Registration", 200)
        ListView1.Columns.Add("Added By", 150)
        ListView1.Columns.Add("Updated By", 150)
        ListView1.Columns.Add("", 30)
    End Sub

    Sub cbox1()
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("[ SELECT ]")
        ComboBox1.Items.Add("BSIT")
        ComboBox1.Items.Add("BSBA")
        ComboBox1.Items.Add("BSAT")
        ComboBox1.Items.Add("BSAC")
        ComboBox1.Items.Add("BSCRIM")
        ComboBox1.Items.Add("BSHRM")
        ComboBox1.Items.Add("BSBA")
        ComboBox1.Items.Add("BSED")
        ComboBox1.Items.Add("BEED")
        ComboBox1.Items.Add("BSEE")
        ComboBox1.Items.Add("BSME")
        ComboBox1.Items.Add("BSA")
        ComboBox1.Items.Add("BSENTREP")
        ComboBox1.Text = "[ SELECT ]"
    End Sub

    Sub cbox2()
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("[ SELECT ]")
        ComboBox2.Items.Add("YES")
        ComboBox2.Items.Add("NO")
        ComboBox2.Text = "[ SELECT ]"
    End Sub

    Sub cbox3()
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.Items.Clear()
        ComboBox3.Items.Add("[ SELECT ]")
        ComboBox3.Items.Add("YES")
        ComboBox3.Items.Add("NO")
        ComboBox3.Text = "[ SELECT ]"
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each subform As Form In Form1.MdiChildren
            subform.Close()
        Next
        Form1.GroupBox1.Visible = True
        Form1.GroupBox2.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        students_details.GroupBox1.Text = "NEW STUDENT"
        For Each subform As Form In Form1.MdiChildren
            subform.Close()
        Next
        Form1.GroupBox1.Visible = False
        Form1.GroupBox2.Visible = False
        students_details.MdiParent = Form1
        students_details.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        search_student_information()
    End Sub

    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged
        search_student_information_scholar()
    End Sub

    Private Sub ComboBox3_TextChanged(sender As Object, e As EventArgs) Handles ComboBox3.TextChanged
        search_student_information_graduated()
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        search_student_information_course()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        students_details.GroupBox1.Text = "UPDATE STUDENT"
        For Each subform As Form In Form1.MdiChildren
            subform.Close()
        Next
        Form1.GroupBox1.Visible = False
        Form1.GroupBox2.Visible = False
        students_details.MdiParent = Form1
        students_details.Show()
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        select_to_update_students()
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
        reload_graduated()
        reload_graduated2()
        reload_scholars1()
        reload_scholars2()
        reload_student_information()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim AskToDelete As MsgBoxResult = MsgBox("Are you sure to delete the student in the list?", vbYesNo, "Ask To Delete")
        If AskToDelete = MsgBoxResult.Yes Then
            delete_student_information()
            MsgBox("A student in the list is now deleted.", vbInformation, "Deleted Successfully")
        Else
            MsgBox("Deleting student information in the list is now cancelled.", vbInformation, "Cancelled Successfully")
        End If
        reload_graduated()
        reload_graduated2()
        reload_scholars1()
        reload_scholars2()
        reload_student_information()
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub
End Class