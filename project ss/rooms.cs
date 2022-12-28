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
    public partial class rooms : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\project ss\project ss\ahmedabdallah.mdf;Integrated Security=True;");
        public int ct4 = 0;
       
        public rooms()
        {
            InitializeComponent();
        }

        private void roomtableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.roomtableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ahmedabdallahDataSet);

        }

        private void rooms_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ahmedabdallahDataSet.roomtable' table. You can move, or remove it, as needed.
            this.roomtableTableAdapter.Fill(this.ahmedabdallahDataSet.roomtable);
            timer1.Start();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into roomtable(room_id,student_name) " +
                "values('" + textBox1.Text + "','" + textBox2.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            ct4++;
            MessageBox.Show("data is inserted successfuly");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from roomtable where room_id='" + textBox1.Text + "' ";
            cmd.ExecuteNonQuery();
            connection.Close();
            ct4--;
            MessageBox.Show("data is deleted successfuly");
        }
        public void dispaly_database()
        {
            SqlCommand command = new SqlCommand("select  * from roomtable ", connection);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            roomtableDataGridView.DataSource = dt;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            dispaly_database();
            
        }

        private void roomtableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            staffaccess staffaccess = new staffaccess();
            staffaccess.Show();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count = roomtableBindingSource.Count;
            label4.Text = "there are " + count.ToString() + "rooms";
        }
    }
}
