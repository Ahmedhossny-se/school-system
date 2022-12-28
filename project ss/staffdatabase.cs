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
    public partial class staffdatabase : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\project ss\project ss\ahmedabdallah.mdf;Integrated Security=True;");
       public int ct1 = 0;

        public staffdatabase( )
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into stafftable(Id,password) " +
                "values('" + textBox1.Text + "','" + textBox2.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            ct1++;
            MessageBox.Show("data is inserted successfuly");
        }


        private void stafftableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.stafftableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ahmedabdallahDataSet);

        }

        private void staffdatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ahmedabdallahDataSet.stafftable' table. You can move, or remove it, as needed.
            this.stafftableTableAdapter.Fill(this.ahmedabdallahDataSet.stafftable);
            timer1.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dispaly_database();
            

        }
        public void dispaly_database()
        {
            SqlCommand command = new SqlCommand("select  * from stafftable ", connection);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            stafftableDataGridView.DataSource = dt;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from stafftable where Id='" + textBox1.Text + "' ";
            cmd.ExecuteNonQuery();
            connection.Close();
            ct1--;
            MessageBox.Show("data is deleted successfuly");
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
            count = stafftableBindingSource.Count;
            label4.Text = "there are  " + count.ToString() +  "  staff";
        }
    }

    

}
