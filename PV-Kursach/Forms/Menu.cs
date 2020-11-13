using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PV_Kursach.Forms;

namespace PV_Kursach.Resources
{
    public partial class Glavni : Form
    {
        public Glavni()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Tree = new Form1();
            this.Hide();
            Tree.Parent = this;
            Tree.BringToFront();
            Tree.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Currency_Converter currency = new Currency_Converter();
            this.Hide();
            currency.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            this.Hide();
            info.Show();
        }

       
    }
}
