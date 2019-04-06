using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje2014
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.BackColor = Color.FromArgb(23,23,23);
            label2.BackColor = Color.FromArgb(23, 23, 23);
            label3.BackColor = Color.FromArgb(23, 23, 23);
        }
        
        int sayac = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {   sayac++;
        if (sayac >= 101)
        {
            timer1.Enabled = false;
            Form form2 = new Form2();
            Form form4 = new Form4();

            
            this.Hide();
            form4.Show();

        }

        else
        {
            pictureBox2.Width += 4;
            pictureBox1.Left += 4;
            label2.Text = ("% " + sayac);
        }
            
           
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
