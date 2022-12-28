using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project_ss
{
    public partial class stafflogin : Form
    {
        public stafflogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\project ss\project ss\ahmedabdallah.mdf;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from stafftable where Id='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ;
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                staffaccess staffaccess = new staffaccess();
                staffaccess.Show();


            }
            else
            {
                MessageBox.Show("yoyr passord or id is incorrect");
            }
        }

       

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
