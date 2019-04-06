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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
            pictureBox1.BackColor = Color.Transparent;
        }
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
                OleDbCommand veri = new OleDbCommand("SELECT * From UserInformation",bag);
            
                oku = veri.ExecuteReader();
                while (oku.Read())
                {
                   
                    sifre = oku[2].ToString();
                    ad = oku[1].ToString();
                }
                oku.Close();
                bag.Close();
                
            }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../../img/logout.png");
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../../img/logout2.png");
}

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            if (degis)
            {
                DialogResult a = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "UYARI", MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                if (a == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }else
                Application.Exit();
        }
        bool degis = false;
        public string sifre,ad;
       

        private void textBox2_Click(object sender, EventArgs e)
        {
          textBox2.BackColor = Color.LightGreen;
        }

        private void Form1_Load(object sender, EventArgs e)
             {
             vericekme();
             
            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ad != textBox1.Text || textBox1.Text == "")
            {
                textBox1.BackColor = Color.Red;
                MessageBox.Show("Girdiğiniz Ad Hatalı.!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                textBox1.Clear();
                textBox1.Focus();
            } 
            else if (sifre != textBox2.Text || textBox2.Text == "")
            {
                textBox2.BackColor = Color.Red;
                MessageBox.Show("Girdiğiniz Şifre Hatalı.!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                textBox2.Clear();
                textBox2.Focus();
            } else {
                this.Hide();
                Form form2 = new Form2();
                form2.Show();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            form3.Show();
        }
    }
}
