using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dota2heroes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection ("server=localhost;username=root;database=mysql;");
        MySqlDataReader dr;
        MySqlCommand com;


        public void dbheroes() {
            com = new MySqlCommand("create database if not exists dbheroes", con);
            dr = com.ExecuteReader();
            dr.Close();
        }

        public void herodetails()
        {
            com = new MySqlCommand("create table if not exists dbheroes.details2(id int(100) auto_increment primary key, heroname text, herotype text, herostory text, heroimage text)", con);
            dr = com.ExecuteReader();
            dr.Close();
        }

        public void heroparams() {
            com.Parameters.AddWithValue("@id", label6.Text);
            com.Parameters.AddWithValue("@heroname", textBox1.Text);
            com.Parameters.AddWithValue("@herotype", comboBox1.Text);
            com.Parameters.AddWithValue("@herostory", textBox3.Text);
            com.Parameters.AddWithValue("@heroimage", textBox2.Text);
            
        }

        public void savedetails()
        {
            com = new MySqlCommand("insert into dbheroes.details2 (heroname, herotype, herostory, heroimage)values (@heroname, @herotype, @herostory, @heroimage)", con);
            heroparams(); // sorry nakalimutan natin haha
            dr = com.ExecuteReader();
            
            dr.Close();


        }

        public void updatedetails()
        {
            com = new MySqlCommand("update dbheroes.details2 set id=@id, heroname=@heroname, herotype=@herotype, herostory=@herostory, heroimage=@heroimage where id=@id;", con);
            heroparams();
            dr = com.ExecuteReader();
            dr.Close();

        }

        public void reloadheroes() {
            dataGridView1.Rows.Clear();
            com = new MySqlCommand("select * from dbheroes.details2 order by heroname asc;", con);
            dr = com.ExecuteReader();
            detailsheroes();
            textBox1.Clear();
            textBox3.Clear();
            textBox2.Clear();
            comboBox1.Text ="";
            label6.Text = "0";
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            dbheroes();
            herodetails();
            textBox2.ReadOnly = true;
            comboBox1.Items.Clear();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("Support");
            comboBox1.Items.Add("Hard Support");
            comboBox1.Items.Add("Mid Laner");
            comboBox1.Items.Add("Safelaner");
            comboBox1.Items.Add("Offlaner");
            reloadheroes();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox1 .Text=="" || textBox3 .Text =="" || comboBox1 .Text == ""){
                MessageBox.Show("Please enter all required hero details","Required All Details",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            }else if (label6.Text =="0"){
                savedetails();
                MessageBox.Show("Details of " + textBox1 .Text + " now saved.","Saved Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information );
            }else{
            updatedetails();
            MessageBox.Show("Details of " + textBox1.Text + " now updated.", "Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
            reloadheroes(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reloadheroes(); 
        }

   
        public void deletedetails() {
            com = new MySqlCommand("delete from dbheroes.details2 where id=@id",con);
            heroparams();
            dr = com.ExecuteReader();
            dr.Close();
        }

    
        private void button2_Click(object sender, EventArgs e)
        {
            if (label6.Text == "0")
            {
                MessageBox.Show("Please select hero Details First", "Select One Hero First", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                deletedetails();
                MessageBox.Show("Details of "+ textBox1 .Text + " now deleted.","Deleted Successfully", MessageBoxButtons .OK,MessageBoxIcon.Information );
            }
            reloadheroes();

        }
		
		    public void detailsheroes() {
            while (dr.Read()) {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
                textBox2.Text = dr.GetString(4).ToString();
            }
            dr.Close();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog myfilepath = new OpenFileDialog();
            {
                if (DialogResult.OK == myfilepath.ShowDialog())
                {
                    string filename = myfilepath.FileName;
                    textBox2.Text = myfilepath.FileName;
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                pictureBox1.Image = null;

            }
            else
            {
                pictureBox1.ImageLocation = textBox2.Text;
            }
        }
    }
}
