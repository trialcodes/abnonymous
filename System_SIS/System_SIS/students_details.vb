Public Class students_details

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each subform As Form In Form1.MdiChildren
            subform.Close()
        Next
        Form1.GroupBox1.Visible = True
        Form1.GroupBox2.Visible = True
    End Sub

    Private Sub students_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox4.Enabled = False
        TextBox1.Text = DateTime.Now.ToString("yyy-MMddhhmmss")
        If GroupBox1.Text = "NEW STUDENT" Then
            cbox0()
            cbox1()
            cbox2()
            cbox3()
        Else
            cbox3()
        End If
    End Sub

    Sub cbox0()
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("[ SELECT ]")
        ComboBox1.Items.Add("MALE")
        ComboBox1.Items.Add("FEMALE")
        ComboBox1.Text = "[ SELECT ]"
    End Sub

    Sub cbox1()
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("[ SELECT ]")
        ComboBox2.Items.Add("BSIT")
        ComboBox2.Items.Add("BSBA")
        ComboBox2.Items.Add("BSAT")
        ComboBox2.Items.Add("BSAC")
        ComboBox2.Items.Add("BSCRIM")
        ComboBox2.Items.Add("BSHRM")
        ComboBox2.Items.Add("BSBA")
        ComboBox2.Items.Add("BSED")
        ComboBox2.Items.Add("BEED")
        ComboBox2.Items.Add("BSEE")
        ComboBox2.Items.Add("BSME")
        ComboBox2.Items.Add("BSA")
        ComboBox2.Items.Add("BSENTREP")
        ComboBox2.Text = "[ SELECT ]"
    End Sub


    Sub cbox2()
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.Items.Clear()
        ComboBox3.Items.Add("[ SELECT ]")
        ComboBox3.Items.Add("YES")
        ComboBox3.Items.Add("NO")
        ComboBox3.Text = "[ SELECT ]"
    End Sub

    Sub cbox3()
        ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox4.Items.Clear()
        ComboBox4.Items.Add("[ SELECT ]")
        ComboBox4.Items.Add("YES")
        ComboBox4.Items.Add("NO")
        ComboBox4.Text = "[ SELECT ]"
    End Sub


    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox8.MaxLength = 11
        If Not IsNumeric(TextBox8.Text) Then
            TextBox8.Clear()
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
      allowed_keys(e)
    End Sub

    Sub allowed_keys2(e)
        If Char.IsLetterOrDigit(e.KeyChar) Or e.KeyChar = " " Or e.KeyChar = "-" Or e.KeyChar = vbBack Or e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub allowed_keys(e)
        If Char.IsLetter(e.KeyChar) Or e.KeyChar = " " Or e.KeyChar = "-" Or e.KeyChar = vbBack Or e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        allowed_keys(e)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub


    Sub age_calculate()
        Dim calc As Integer
        Dim age As TimeSpan = DateTime.Now.Date - DateTimePicker1.Value
        calc = age.TotalDays / 365
        TextBox4.Text = calc
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        age_calculate()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        allowed_keys2(e)
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        allowed_keys2(e)
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        allowed_keys2(e)
    End Sub

    Sub txtclear()
        reload_scholars1()
        reload_scholars2()
        reload_graduated()
        reload_graduated2()
        reload_student_information()
        cbox0()
        cbox2()
        cbox1()
        cbox3()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If GroupBox1.Text = "NEW STUDENT" Then
            If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "[ SELECT ]" Or ComboBox2.Text = "[ SELECT ]" Or ComboBox3.Text = "[ SELECT ]" Then
                MsgBox("Please input missing information. Thank you!", vbExclamation, "Missing Details")
            Else
                insert_into_student_information()
                MsgBox("The information of Mr./Ms." & TextBox2.Text & " is now saved in the student list.", vbInformation, "Saved Successfully")
            End If
        ElseIf GroupBox1.Text = "UPDATE STUDENT" Then
            If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "[ SELECT ]" Or ComboBox2.Text = "[ SELECT ]" Or ComboBox3.Text = "[ SELECT ]" Then
                MsgBox("Please input missing information. Thank you!", vbExclamation, "Missing Details")
            Else
                update_student_information()
                MsgBox("The information of Mr./Ms." & TextBox2.Text & " is now updated in the student list.", vbInformation, "Updated Successfully")
            End If
        End If
        txtclear()
        TextBox1.Text = DateTime.Now.ToString("yyy-mmddhhmmss")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For Each subform As Form In Form1.MdiChildren
            subform.Close()
        Next
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        student_registration.MdiParent = Form1
        student_registration.Show()
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        cbox0()
    End Sub

    Private Sub ComboBox2_Click(sender As Object, e As EventArgs) Handles ComboBox2.Click
        cbox1()
    End Sub

    Private Sub ComboBox3_Click(sender As Object, e As EventArgs) Handles ComboBox3.Click
        cbox2()
    End Sub

    Private Sub ComboBox4_Click(sender As Object, e As EventArgs) Handles ComboBox4.Click
        cbox3()
    End Sub


End Class