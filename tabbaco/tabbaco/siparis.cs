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
    public partial class siparis : Form
    {
        public siparis()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port=5432; Database=tabaccodb; user Id= postgres; password=953687423");
        private void siparis_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from sepet";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into public.sepet (sepet_id,satis_adedi,toplam_tutar,sepet_urun_adi,sepet_musteri_id,sepet_puro_adi,sepet_sigara_adi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sipariş ekleme işlemi başarılı bir şekilde gerçekleştirildi.");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from public.sepet where sepet_id=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sipariş silme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand guncelle = new NpgsqlCommand("update public.sepet set satis_adedi=@p1,toplam_tutar=@p2,sepet_urun_adi=@p3,sepet_musteri_id=@p4,sepet_puro_adi=@p5,sepet_sigara_adi=@p6 where sepet_id=@p7", baglanti);
            guncelle.Parameters.AddWithValue("@p7", int.Parse(textBox1.Text));
            guncelle.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
            guncelle.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));
            guncelle.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
            guncelle.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));
            guncelle.Parameters.AddWithValue("@p5", int.Parse(textBox6.Text));
            guncelle.Parameters.AddWithValue("@p6", int.Parse(textBox7.Text));
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sipariş güncelleme basarili", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from sepet";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }
    }
}
