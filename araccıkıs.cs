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



namespace Otopark_Projesi
{
    public partial class araccıkıs : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\anamenuveri.mdb");
        
        public araccıkıs()
        {
            InitializeComponent();
        }

        private void araccıkıs_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from musteriadi where durum like (0)", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["plaka"].ToString());

            }
            baglanti.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        DateTime tarih;
        string parkyeri = "";
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            double aracyikama = 0;
            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("select * from musteriadi where durum like (0) and plaka LIKE'" + comboBox2.Text + "'", baglanti);
            OleDbDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                label9.Text = oku2["marka"].ToString();
                label10.Text = oku2["model"].ToString();
                label11.Text = oku2["adi"].ToString();
                label12.Text = oku2["soyadi"].ToString();
                tarih = Convert.ToDateTime(oku2["gsaat"].ToString());
                parkyeri = oku2["p"].ToString();
                label13.Text = oku2["aracyikama"].ToString();


            }
            if (label13.Text=="Var")
            {
                aracyikama = 15;

            }
            else if(label13.Text=="Yok")
            {
                aracyikama = 0;
            }
            baglanti.Close();
            System.TimeSpan zaman;
            DateTime sondeger = DateTime.Now;
            zaman = sondeger.Subtract(tarih);
            double saat = Convert.ToDouble(zaman.TotalHours);
            double para = 2 * double.Parse(saat.ToString("0.##"));
            label14.Text = (aracyikama + para).ToString() + "TL ";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut4 = new OleDbCommand("update parkyeri set durum=0 where parkyeri='" + parkyeri + "'", baglanti);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            OleDbCommand komut5 = new OleDbCommand("update musteriadi set durum=1 where plaka ='" + comboBox2.Text + "'", baglanti);
            komut5.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            OleDbCommand komut6 = new OleDbCommand("update gecmis set csaat='" + DateTime.Now + "',fiyat='" + label14.Text + "' where plaka='" + comboBox2.Text + "'", baglanti);
            komut6.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Araç Çıkışı Yapıldı.");
            parkyeri = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            comboBox2.Text = "";
            label14.Text = "";
            comboBox2.Items.Clear();
            araccıkıs_Load(sender, e);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) 
             || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }
    }
}
