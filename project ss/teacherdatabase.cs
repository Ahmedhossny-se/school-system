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
    public partial class teacherdatabase : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\project ss\project ss\ahmedabdallah.mdf;Integrated Security=True;");
        int ct3 = 0;


        public teacherdatabase()
        {
            InitializeComponent();
        }

        private void teachertableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.teachertableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ahmedabdallahDataSet);

        }

        private void teacherdatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ahmedabdallahDataSet.teachertable' table. You can move, or remove it, as needed.
            this.teachertableTableAdapter.Fill(this.ahmedabdallahDataSet.teachertable);
            timer1.Start();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into teachertable(Id,first_name,last_name,address,mopile_number) " +
                "values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();

            connection.Close();


            ct3++;
            MessageBox.Show("data is inserted successfuly");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from teachertable where Id='" + textBox1.Text + "' ";
            cmd.ExecuteNonQuery();

            connection.Close();



            ct3--;
            MessageBox.Show("data is deleted successfuly");
        }
        public void dispaly_database()
        {
            SqlCommand command = new SqlCommand("select  * from teachertable ", connection);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            teachertableDataGridView.DataSource = dt;




        }

        private void button3_Click(object sender, EventArgs e)
        {
            dispaly_database();
            //number_of();




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
            count = teachertableBindingSource.Count;
            label6.Text = "there are " + count.ToString() + "teacher";
        }
    }
        
       
}
