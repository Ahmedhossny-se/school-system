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
    public partial class studentdatabase : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\project ss\project ss\ahmedabdallah.mdf;Integrated Security=True;");
        public int ct2;
        
        public studentdatabase()
        {
            InitializeComponent();
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into studenttable(Id,first_name,last_name,age,birthdate,fees,stallment,bus_fees,nationality,address) " +
                "values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" +
                textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
            cmd.ExecuteNonQuery();

            connection.Close();


            ct2++;
            MessageBox.Show("data is inserted successfuly");
       

        }
        
        public void dispaly_database()
        {
            SqlCommand command = new SqlCommand("select  * from studenttable ", connection);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
          studenttableDataGridView.DataSource = dt;
           



        }

        private void studenttableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studenttableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ahmedabdallahDataSet);

        }

        private void studentdatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ahmedabdallahDataSet.studenttable' table. You can move, or remove it, as needed.
            this.studenttableTableAdapter.Fill(this.ahmedabdallahDataSet.studenttable);
            timer1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dispaly_database();
            textBox11.Text = ct2.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from studenttable where Id='" +textBox1.Text + "' ";
            cmd.ExecuteNonQuery();

            connection.Close();



            ct2--;
            MessageBox.Show("data is deleted successfuly");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminaccess adminaccess = new adminaccess();
            adminaccess.Show();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count = studenttableBindingSource.Count;
            label13.Text = "there are  " + count.ToString()  +  "  student";
        }
    }
}
