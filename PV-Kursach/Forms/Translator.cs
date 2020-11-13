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
    public partial class Translator : Form
    {
        public Translator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Glavni glavni = new Glavni();
            this.Hide();
            glavni.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Currency_Converter valuta = new Currency_Converter();
            this.Hide();
            valuta.Show();
        }
        private void TranslateTerm()
        {
            string SelectedWord = comboBox1.SelectedItem.ToString();
            switch(SelectedWord)
            {
                case "King":
                    this.label5.Text = "Король";
                    this.label6.Text = "Краљ";
                    this.label7.Text = "Re";
                    Refresh();
                    break;
                case "Queen":
                    this.label5.Text = "Ферзь";
                    this.label6.Text = "Краљица";
                    this.label7.Text = "Regina";
                    Refresh();
                    break;
                case "Rook":
                    this.label5.Text = "Ладья";
                    this.label6.Text = "Топ";
                    this.label7.Text = "Torre";
                    Refresh();
                    break;
                case "Knight":
                    this.label5.Text = "Конь";
                    this.label6.Text = "Скакч";
                    this.label7.Text = "Cavaliere";
                    Refresh();
                    break;
                case "Bishop":
                    this.label5.Text = "Слон";
                    this.label6.Text = "Ловац";
                    this.label7.Text = "Vescovo";
                    Refresh();
                    break;
                case "Pawn":
                    this.label5.Text = "Пешка";
                    this.label6.Text = "Пион";
                    this.label7.Text = "Pedone";
                    Refresh();
                    break;
            }
        
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TranslateTerm();
        }
    }
}
