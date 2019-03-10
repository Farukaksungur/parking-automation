using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Data.OleDb;

namespace Otopark_Projesi
{
    public partial class ekle : Form

    {

        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\anamenuveri.mdb");

        public ekle()
        {
            InitializeComponent();
        }



        private void ekle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from parkyeri where durum like (0)", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["parkyeri"].ToString());
            }
            baglanti.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form accam = new kamera();
            accam.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string tarih = DateTime.Now.ToShortDateString();
            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("insert into musteriadi(p,marka,model,plaka,adi,soyadi,gsaat,durum,aracyikama) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + tarih.ToString() + "','0','" + comboBox2.Text + "')", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand(" update parkyeri set durum='1' where parkyeri like'" + comboBox1.Text + "'", baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            OleDbCommand komut4 = new OleDbCommand("insert into gecmis (plaka,adi,soyadi,marka,model,p,aracyıkama,gsaat) values('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + tarih.ToString() + "')", baglanti);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaydedildi!");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) 
            || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) 
            || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }
    }
}
