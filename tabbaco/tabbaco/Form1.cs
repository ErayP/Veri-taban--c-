using System;
using System.Collections.Generic;
using Npgsql;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tabbaco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port=5432; Database=tabaccodb; user Id= postgres; password=953687423");
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Müşteri tablosu";
            string sorgu = "select * from musteri";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into public.musteri (kisi_id,kisi_ad,kisi_soyad,kisi_adres,kisi_il,kisi_ilce,kisi_bolge) values ('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori ekleme işlemi başarılı bir şekilde gerçekleştirildi.");
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
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from public.musteri where kisi_id=@p1",baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün silme işlemi başarılı","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from musteri";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
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
            NpgsqlCommand guncelle = new NpgsqlCommand("update public.musteri set kisi_ad=@p1,kisi_soyad=@p2,kisi_adres=@p3,kisi_il=@p4,kisi_ilce=@p5,kisi_bolge=@p6 where kisi_id=@p7",baglanti);
            guncelle.Parameters.AddWithValue("@p1",textBox2.Text);
            guncelle.Parameters.AddWithValue("@p2",textBox3.Text);
            guncelle.Parameters.AddWithValue("@p3",textBox4.Text);
            guncelle.Parameters.AddWithValue("@p4",int.Parse(textBox5.Text));
            guncelle.Parameters.AddWithValue("@p5",int.Parse(textBox6.Text));
            guncelle.Parameters.AddWithValue("@p6",int.Parse(textBox7.Text));
            guncelle.Parameters.AddWithValue("@p7",int.Parse(textBox1.Text));
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Urun güncelleme basarili", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            int sayi = int.Parse(textBox1.Text);
            NpgsqlCommand fonk = new NpgsqlCommand("select * from musteriara(sayi)");
            baglanti.Close();
            fonk.ExecuteNonQuery();
            
        }
    }
}
