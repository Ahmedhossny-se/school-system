using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_ss
{
    public partial class viewteacherdatabase : Form
    {
        public viewteacherdatabase()
        {
            InitializeComponent();
        }

        private void teachertableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.teachertableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ahmedabdallahDataSet);

        }

        private void viewteacherdatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ahmedabdallahDataSet.teachertable' table. You can move, or remove it, as needed.
            this.teachertableTableAdapter.Fill(this.ahmedabdallahDataSet.teachertable);

        }

        private void button1_Click(object sender, EventArgs e)
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
