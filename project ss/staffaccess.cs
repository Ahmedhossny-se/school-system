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
    public partial class staffaccess : Form
    {
        public staffaccess()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewstudentdatabase viewstudentdatabase = new viewstudentdatabase();
            viewstudentdatabase.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewteacherdatabase viewteacherdatabase = new viewteacherdatabase();
            viewteacherdatabase.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            rooms rooms = new rooms();
            rooms.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
