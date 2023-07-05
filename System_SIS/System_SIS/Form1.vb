Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        IsMdiContainer = True
        opencon()
        create_db_system_sis_db()
        create_tb_sis_student_information()
        reload_scholars1()
        reload_scholars2()
        reload_graduated()
        reload_graduated2()
        reload_student_information()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each subform As Form In Me.MdiChildren
            subform.Close()
        Next
        GroupBox1.Visible = True
        GroupBox2.Visible = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel11.Text = Today & " | " & TimeOfDay
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each subform As Form In Me.MdiChildren
            subform.Close()
        Next
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        student_registration.MdiParent = Me
        student_registration.Show()
    End Sub
End Class
