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
    public partial class Gider : Form
    {
        public Gider()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port=5432; Database=tabaccodb; user Id= postgres; password=953687423");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into public.gider (gider_id,gider_turu) values ('" + textBox1.Text + "','" + textBox2.Text + "')", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Gider ekleme işlemi başarılı bir şekilde gerçekleştirildi.");
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Gider_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from gider";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from public.gider where gider_id=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Gider silme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand guncelle = new NpgsqlCommand("update public.gider set gider_turu=@p2 where gider_id=@p1", baglanti);
            guncelle.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            guncelle.Parameters.AddWithValue("@p2", textBox2.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Gider güncelleme basarili.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from gider";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
