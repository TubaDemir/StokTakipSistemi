using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Proje2014
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public string sifre, ad;
        OleDbConnection bag;
        public void baglanti()
        {
            bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=STOKTAKIP.mdb");
            bag.Open();
        }
        public void vericekme()
        {

            baglanti();
            OleDbDataReader oku;
            OleDbCommand veri = new OleDbCommand("SELECT * From SIRKETGIRIS", bag);

            oku = veri.ExecuteReader();
            while (oku.Read())
            {

                sifre = oku[2].ToString();
                ad = oku[1].ToString();
            }
            oku.Close();
            bag.Close();

        }
        public void button1_Click(object sender, EventArgs e)
        {

            
            if (textBox1.Text != sifre)
                MessageBox.Show("Şifre Hatalı!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
                timer1.Enabled = true;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 5;
            if (progressBar1.Value >= 100)
            {
                timer1.Enabled = false;
                this.Hide();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.IndianRed;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            vericekme();
            textBox1.BackColor = Color.LightGreen;
        }

    }
}
