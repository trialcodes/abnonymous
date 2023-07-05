Imports MySql.Data.MySqlClient
Module sis_mod
    Dim con As New MySqlConnection("Server=localhost;username=root;database=mysql;")
    Dim com As New MySqlCommand
    Dim dr As MySqlDataReader

    Sub opencon()
        con.Close()
        con.Open()
        com.Connection = con
    End Sub

    Sub closedr()
        dr = com.ExecuteReader
        dr.Close()
    End Sub

    Sub create_db_system_sis_db()
        com.CommandText = "create database if not exists db_sis;"
        closedr()
    End Sub

    Sub create_tb_sis_student_information()
        com.CommandText = "create table if not exists db_sis.student_information(id int(100) auto_increment primary key, idnumber varchar(100), fullname varchar(150), address varchar(200), sex char(6), birthdate varchar(100), age int(2), course varchar(100), ys varchar(50), fullname2 text, address2 text, contactno varchar(11), scholar char(3), graduate char(3), date varchar(100), addedby varchar(150), updatedby varchar(150));"
        closedr()
    End Sub

    Sub insert_into_student_information()
        com = New MySqlCommand("insert into db_sis.student_information(idnumber,fullname,address,sex,birthdate,age,course,ys,fullname2,address2,contactno,scholar,graduate,date,addedby,updatedby)values(@idnumber,@fullname,@address,@sex,@birthdate,@age,@course,@ys,@fullname2,@address2,@contactno,@scholar,@graduate,@date,@addedby,@updatedby)", con)
        save_params()
        closedr()
    End Sub

    Sub update_student_information()
        com = New MySqlCommand("update db_sis.student_information set id=@id, idnumber=@idnumber, fullname=@fullname, address=@address, sex=@sex, birthdate=@birthdate, age=@age, course=@course, ys=@ys, fullname2=@fullname2, address2=@address2, contactno=@contactno, scholar=@scholar, graduate=@graduate, updatedby=@updatedby where id=@id", con)
        update_params()
        closedr()
    End Sub

    Sub delete_student_information()
        com.CommandText = "delete from db_sis.student_information where id='" & student_registration.ListView1.FocusedItem.Text & "';"
        closedr()
    End Sub

    Sub reload_student_information()
        student_registration.ListView1.Items.Clear()
        student_registration.ListView1.BackColor = Color.DarkGreen
        com.CommandText = "select * from db_sis.student_information order by id desc"
        dr = com.ExecuteReader
        While dr.Read
            Dim sis As New ListViewItem(dr.Item(0).ToString)
            Dim sis_c As Integer
            For sis_c = 1 To 16 Step 1
                sis.SubItems.Add(dr.Item(sis_c).ToString).BackColor = Color.White
            Next
            sis.UseItemStyleForSubItems = False
            student_registration.ListView1.Items.AddRange(New ListViewItem() {sis})
        End While
        dr.Close()
        student_registration.Label5.Text = "TOTAL OF STUDENTS: " & student_registration.ListView1.Items.Count
        Form1.Label2.Text = student_registration.ListView1.Items.Count
    End Sub

    Sub search_student_information()
        student_registration.ListView1.Items.Clear()
        student_registration.ListView1.BackColor = Color.DarkGreen
        com.CommandText = "select * from db_sis.student_information where fullname like '%" & student_registration.TextBox1.Text & "%';"
        dr = com.ExecuteReader
        While dr.Read
            Dim sis As New ListViewItem(dr.Item(0).ToString)
            Dim sis_c As Integer
            For sis_c = 1 To 16 Step 1
                sis.SubItems.Add(dr.Item(sis_c).ToString).BackColor = Color.White
            Next
            sis.UseItemStyleForSubItems = False
            student_registration.ListView1.Items.AddRange(New ListViewItem() {sis})
        End While
        dr.Close()
        student_registration.Label5.Text = "TOTAL OF STUDENTS: " & student_registration.ListView1.Items.Count
    End Sub

    Sub search_student_information_scholar()
        student_registration.ListView1.Items.Clear()
        student_registration.ListView1.BackColor = Color.DarkGreen
        com.CommandText = "select * from db_sis.student_information where scholar ='" & student_registration.ComboBox2.Text & "' order by fullname asc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim sis As New ListViewItem(dr.Item(0).ToString)
            Dim sis_c As Integer
            For sis_c = 1 To 16 Step 1
                sis.SubItems.Add(dr.Item(sis_c).ToString).BackColor = Color.White
            Next
            sis.UseItemStyleForSubItems = False
            student_registration.ListView1.Items.AddRange(New ListViewItem() {sis})
        End While
        dr.Close()
        student_registration.Label5.Text = "TOTAL OF STUDENTS: " & student_registration.ListView1.Items.Count
    End Sub

    Sub search_student_information_graduated()
        student_registration.ListView1.Items.Clear()
        student_registration.ListView1.BackColor = Color.DarkGreen
        com.CommandText = "select * from db_sis.student_information where graduate ='" & student_registration.ComboBox3.Text & "' order by fullname asc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim sis As New ListViewItem(dr.Item(0).ToString)
            Dim sis_c As Integer
            For sis_c = 1 To 16 Step 1
                sis.SubItems.Add(dr.Item(sis_c).ToString).BackColor = Color.White
            Next
            sis.UseItemStyleForSubItems = False
            student_registration.ListView1.Items.AddRange(New ListViewItem() {sis})
        End While
        dr.Close()
        student_registration.Label5.Text = "TOTAL OF STUDENTS: " & student_registration.ListView1.Items.Count
    End Sub

    Sub search_student_information_course()
        student_registration.ListView1.Items.Clear()
        student_registration.ListView1.BackColor = Color.DarkGreen
        com.CommandText = "select * from db_sis.student_information where course ='" & student_registration.ComboBox1.Text & "' order by fullname asc;"
        dr = com.ExecuteReader
        While dr.Read
            Dim sis As New ListViewItem(dr.Item(0).ToString)
            Dim sis_c As Integer
            For sis_c = 1 To 16 Step 1
                sis.SubItems.Add(dr.Item(sis_c).ToString).BackColor = Color.White
            Next
            sis.UseItemStyleForSubItems = False
            student_registration.ListView1.Items.AddRange(New ListViewItem() {sis})
        End While
        dr.Close()
        student_registration.Label5.Text = "TOTAL OF STUDENTS: " & student_registration.ListView1.Items.Count
    End Sub

    Sub reload_scholars1()
        student_registration.ListView1.BackColor = Color.DarkGreen
        student_registration.ListView1.Items.Clear()
        com.CommandText = "select * from db_sis.student_information where scholar='" & "YES" & "';"
        dr = com.ExecuteReader
        While dr.Read
            Dim sis As New ListViewItem(dr.Item(0).ToString)
            Dim sis_c As Integer
            For sis_c = 1 To 16 Step 1
                sis.SubItems.Add(dr.Item(sis_c).ToString).BackColor = Color.White
            Next
            sis.UseItemStyleForSubItems = False
            student_registration.ListView1.Items.AddRange(New ListViewItem() {sis})

        End While
        dr.Close()
        student_registration.Label6.Text = "SCHOLARS: " & student_registration.ListView1.Items.Count
        Form1.Label9.Text = student_registration.ListView1.Items.Count
    End Sub

    Sub reload_scholars2()
        student_registration.ListView1.Items.Clear()
        student_registration.ListView1.BackColor = Color.DarkGreen
        com.CommandText = "select * from db_sis.student_information where scholar='" & "NO" & "';"
        dr = com.ExecuteReader
        While dr.Read
            Dim sis As New ListViewItem(dr.Item(0).ToString)
            Dim sis_c As Integer
            For sis_c = 1 To 16 Step 1
                sis.SubItems.Add(dr.Item(sis_c).ToString).BackColor = Color.White
            Next
            sis.UseItemStyleForSubItems = False
            student_registration.ListView1.Items.AddRange(New ListViewItem() {sis})

        End While
        dr.Close()
        student_registration.Label7.Text = "NOT SCHOLARS: " & student_registration.ListView1.Items.Count
        Form1.Label5.Text = student_registration.ListView1.Items.Count
    End Sub

    Sub reload_graduated()
        student_registration.ListView1.Items.Clear()
        student_registration.ListView1.BackColor = Color.DarkGreen
        com.CommandText = "select * from db_sis.student_information where graduate='" & "NO" & "';"
        dr = com.ExecuteReader
        While dr.Read
            Dim sis As New ListViewItem(dr.Item(0).ToString)
            Dim sis_c As Integer
            For sis_c = 1 To 16 Step 1
                sis.SubItems.Add(dr.Item(sis_c).ToString).BackColor = Color.White
            Next
            sis.UseItemStyleForSubItems = False
            student_registration.ListView1.Items.AddRange(New ListViewItem() {sis})
        End While
        dr.Close()
        student_registration.Label10.Text = "NOT GRADUATED: " & student_registration.ListView1.Items.Count
        Form1.Label3.Text = student_registration.ListView1.Items.Count
    End Sub

    Sub reload_graduated2()
        student_registration.ListView1.Items.Clear()
        student_registration.ListView1.BackColor = Color.DarkGreen
        com.CommandText = "select * from db_sis.student_information where graduate='" & "YES" & "';"
        dr = com.ExecuteReader
        While dr.Read
            Dim sis As New ListViewItem(dr.Item(0).ToString)
            Dim sis_c As Integer
            For sis_c = 1 To 16 Step 1
                sis.SubItems.Add(dr.Item(sis_c).ToString).BackColor = Color.White
            Next
            sis.UseItemStyleForSubItems = False
            student_registration.ListView1.Items.AddRange(New ListViewItem() {sis})

        End While
        dr.Close()
        student_registration.Label9.Text = "GRADUATED: " & student_registration.ListView1.Items.Count
        Form1.Label4.Text = student_registration.ListView1.Items.Count
    End Sub



    Sub save_params()
        com.Parameters.AddWithValue("@idnumber", students_details.TextBox1.Text)
        com.Parameters.AddWithValue("@fullname", students_details.TextBox2.Text)
        com.Parameters.AddWithValue("@address", students_details.TextBox3.Text)
        com.Parameters.AddWithValue("@sex", students_details.ComboBox1.Text)
        com.Parameters.AddWithValue("@birthdate", students_details.DateTimePicker1.Text)
        com.Parameters.AddWithValue("@age", students_details.TextBox4.Text)
        com.Parameters.AddWithValue("@course", students_details.ComboBox2.Text)
        com.Parameters.AddWithValue("@ys", students_details.TextBox5.Text)
        com.Parameters.AddWithValue("@fullname2", students_details.TextBox6.Text)
        com.Parameters.AddWithValue("@address2", students_details.TextBox7.Text)
        com.Parameters.AddWithValue("@contactno", students_details.TextBox8.Text)
        com.Parameters.AddWithValue("@scholar", students_details.ComboBox3.Text)
        com.Parameters.AddWithValue("@graduate", "NO")
        com.Parameters.AddWithValue("@date", Form1.ToolStripStatusLabel11.Text)
        com.Parameters.AddWithValue("@addedby", Form1.ToolStripStatusLabel9.Text)
        com.Parameters.AddWithValue("@updatedby", "--")
    End Sub

    Sub update_params()
        com.Parameters.AddWithValue("@id", students_details.Label15.Text)
        com.Parameters.AddWithValue("@idnumber", students_details.TextBox1.Text)
        com.Parameters.AddWithValue("@fullname", students_details.TextBox2.Text)
        com.Parameters.AddWithValue("@address", students_details.TextBox3.Text)
        com.Parameters.AddWithValue("@sex", students_details.ComboBox1.Text)
        com.Parameters.AddWithValue("@birthdate", students_details.DateTimePicker1.Text)
        com.Parameters.AddWithValue("@age", students_details.TextBox4.Text)
        com.Parameters.AddWithValue("@course", students_details.ComboBox2.Text)
        com.Parameters.AddWithValue("@ys", students_details.TextBox5.Text)
        com.Parameters.AddWithValue("@fullname2", students_details.TextBox6.Text)
        com.Parameters.AddWithValue("@address2", students_details.TextBox7.Text)
        com.Parameters.AddWithValue("@contactno", students_details.TextBox8.Text)
        com.Parameters.AddWithValue("@scholar", students_details.ComboBox3.Text)
        com.Parameters.AddWithValue("@graduate", students_details.ComboBox4.Text)
        com.Parameters.AddWithValue("@updatedby", Form1.ToolStripStatusLabel9.Text)
    End Sub

    Sub select_to_update_students()
        com.CommandText = "select * from db_sis.student_information where id='" & student_registration.ListView1.FocusedItem.Text & "';"
        dr = com.ExecuteReader
        While dr.Read
            students_details.Label15.Text = dr.Item(0).ToString
            students_details.TextBox1.Text = dr.Item(1).ToString
            students_details.TextBox2.Text = dr.Item(2).ToString
            students_details.TextBox3.Text = dr.Item(3).ToString
            students_details.ComboBox1.Text = dr.Item(4).ToString
            students_details.DateTimePicker1.Text = dr.Item(5).ToString
            students_details.TextBox4.Text = dr.Item(6).ToString
            students_details.ComboBox2.Text = dr.Item(7).ToString
            students_details.TextBox5.Text = dr.Item(8).ToString
            students_details.TextBox6.Text = dr.Item(9).ToString
            students_details.TextBox7.Text = dr.Item(10).ToString
            students_details.TextBox8.Text = dr.Item(11).ToString
            students_details.ComboBox3.Text = dr.Item(12).ToString
            students_details.ComboBox4.Text = dr.Item(13).ToString
        End While
        dr.Close()
    End Sub



End Module
