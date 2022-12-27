using System;
using Npgsql;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port=5432; Database=tabaccodb; user Id= postgres; password=953687423");
        private void Form3_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from il";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into public.il (il_id,il_adi) values ('" + textBox1.Text + "','" + textBox2.Text + "')", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İlçe ekleme işlemi başarılı bir şekilde gerçekleştirildi.");
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand guncelle = new NpgsqlCommand("update public.il set il_adi=@p2 where il_id=@p1", baglanti);
            guncelle.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            guncelle.Parameters.AddWithValue("@p2", textBox2.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İl güncelleme basarili", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from public.il where il_id=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("il silme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }
    }
}
