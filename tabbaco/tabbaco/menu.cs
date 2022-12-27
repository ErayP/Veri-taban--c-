using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tabbaco
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            satis satis = new satis();
            satis.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fatura fatura = new fatura();
            fatura.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            odemeturu odemeturu = new odemeturu();
            odemeturu.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            stok stok = new stok();
            stok.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Gider gider = new Gider();
            gider.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            nikotin nikotin = new nikotin();
            nikotin.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            puro puro = new puro();
            puro.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sigara sigara = new sigara();
            sigara.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tedarikçi tedarikçi = new tedarikçi();
            tedarikçi.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            siparis siparis = new siparis();
            siparis.Show();
            this.Hide();
        }
    }
}
