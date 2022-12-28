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
   
    public partial class viewstudentdatabase : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\project ss\project ss\ahmedabdallah.mdf;Integrated Security=True;");
        public viewstudentdatabase()
        {
            InitializeComponent();
        }

        private void studenttableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studenttableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ahmedabdallahDataSet);

        }

        private void viewstudentdatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ahmedabdallahDataSet.studenttable' table. You can move, or remove it, as needed.
            this.studenttableTableAdapter.Fill(this.ahmedabdallahDataSet.studenttable);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dispaly_database();
        }
         public void dispaly_database()
        {
            SqlCommand command = new SqlCommand("select  * from studenttable ", connection);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            studenttableDataGridView.DataSource = dt;




        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            staffaccess staffaccess = new staffaccess();
            staffaccess.Show();
        }
    }
}
