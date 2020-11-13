using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV_Kursach.Resources
{
    public partial class Currency_Converter : Form
    {
        public Currency_Converter()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConvertCurrency();

        }
        private void ConvertCurrency()
        {
            decimal number = this.numericUpDown1.Value;
            string currency = this.comboBox1.SelectedItem.ToString();
            decimal convertedAmmount = number;
            if (currency == "EUR")
            {
                convertedAmmount = number / 1.95583m;
            }
            else if (currency == "USD")
                {
                    convertedAmmount = number / 1.80810m;
                }
            
            else if (currency == "GBP")
                { convertedAmmount = number / 2.54990m; }

            this.label2.Text = number + "BGN -> " + convertedAmmount + " " + currency;
            
        }

        private void Currency_Converter_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedItem = "EUR";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Glavni glavni = new Glavni();
            this.Hide();
            glavni.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Translator translator = new Translator();
            this.Hide();
            translator.Show();
        }
    }
}
