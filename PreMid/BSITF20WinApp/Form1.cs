using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSITF20WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            //form2.Show();
            form2.ShowDialog();
            MessageBox.Show("This is a message box to show messages");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
