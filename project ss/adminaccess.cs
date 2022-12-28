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
    public partial class adminaccess : Form
    {
        public adminaccess()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            studentdatabase studentdatabase = new studentdatabase();
            studentdatabase.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            staffdatabase staffdatabase = new staffdatabase();
            staffdatabase.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            details details = new details();
            details.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            teacherdatabase teacherdatabase = new teacherdatabase();
            teacherdatabase.Show(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
