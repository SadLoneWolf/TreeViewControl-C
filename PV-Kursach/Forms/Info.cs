using PV_Kursach.Resources;
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

namespace PV_Kursach.Forms
{
    public partial class Info : Form
    {
        private void DisplayInfo()
        {
            string path = @"C:\Users\bruker\source\repos\PV Kursach\PV-Kursach\PV-Kursach\Resources\info.txt";
            string Info = File.ReadAllText(path);
            this.label2.Text = Info.ToString();
            
        }
        public Info()
        {
            InitializeComponent();
            DisplayInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Glavni menu = new Glavni();
            this.Hide();
            menu.Show();
        }
    }
}
