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
    public partial class konum : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\anamenuveri.mdb");
        public konum()
        {
            InitializeComponent();
        }

        private void konum_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from parkyeri,musteriadi where parkyeri.parkyeri=musteriadi.p and musteriadi.durum like (0)", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku["p"].ToString()=="A1")
                {
                    pictureBox1.BackColor = Color.Red;
                    label11.Text = oku["plaka"].ToString();
                    label11.BackColor = Color.Red;
                    label1.BackColor = Color.Red;

                }
                if (oku["p"].ToString() == "A2")
                {
                    pictureBox2.BackColor = Color.Red;
                    label12.Text = oku["plaka"].ToString();
                    label12.BackColor = Color.Red;
                    label2.BackColor = Color.Red;

                }
                if (oku["p"].ToString() == "A3")
                {
                    pictureBox3.BackColor = Color.Red;
                    label13.Text = oku["plaka"].ToString();
                    label13.BackColor = Color.Red;
                    label3.BackColor = Color.Red;

                }
                if (oku["p"].ToString() == "A4")
                {
                    pictureBox4.BackColor = Color.Red;
                    label14.Text = oku["plaka"].ToString();
                    label14.BackColor = Color.Red;
                    label4.BackColor = Color.Red;

                }
                if (oku["p"].ToString() == "A5")
                {
                    pictureBox5.BackColor = Color.Red;
                    label15.Text = oku["plaka"].ToString();
                    label15.BackColor = Color.Red;
                    label5.BackColor = Color.Red;

                }
                if (oku["p"].ToString() == "A6")
                {
                    pictureBox6.BackColor = Color.Red;
                    label16.Text = oku["plaka"].ToString();
                    label16.BackColor = Color.Red;
                    label6.BackColor = Color.Red;

                }
                if (oku["p"].ToString() == "A7")
                {
                    pictureBox7.BackColor = Color.Red;
                    label17.Text = oku["plaka"].ToString();
                    label17.BackColor = Color.Red;
                    label7.BackColor = Color.Red;

                }
                if (oku["p"].ToString() == "A8")
                {
                    pictureBox8.BackColor = Color.Red;
                    label18.Text = oku["plaka"].ToString();
                    label18.BackColor = Color.Red;
                    label8.BackColor = Color.Red;

                }
                if (oku["p"].ToString() == "A9")
                {
                    pictureBox9.BackColor = Color.Red;
                    label19.Text = oku["plaka"].ToString();
                    label19.BackColor = Color.Red;
                    label9.BackColor = Color.Red;

                }
                if (oku["p"].ToString() == "A10")
                {
                    pictureBox10.BackColor = Color.Red;
                    label20.Text = oku["plaka"].ToString();
                    label20.BackColor = Color.Red;
                    label10.BackColor = Color.Red;

                }

            }
            baglanti.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
