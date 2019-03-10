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
using System.Diagnostics;

namespace Otopark_Projesi
{
    public partial class Kullanıcıgirişi : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source ="+Application.StartupPath+"\\anamenuveri.mdb");
        public Kullanıcıgirişi()
        {
            InitializeComponent();
        }
                

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://dosya.co/dhz3hdhc454r/otoparkverileri.accdb.html");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Giriş Bilgilerinizi Doldurunuz!");

            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Kullanıcı Adınızı Giriniz!");
            }
            else if (textBox2.Text=="")
            {
                MessageBox.Show("Şifrenizi Giriniz!");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from kullanıcıveri where kullanıcıadı='" + textBox1.Text.ToString()+"'",baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                if (oku.Read()==true)
                {
                    if (textBox1.Text.ToString() == oku["kullanıcıadı"].ToString() && textBox2.Text.ToString() == oku["şifre"].ToString()) 
                    {
                        Form Anamenu = new Anamenu();
                        Anamenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Şifre YANLIŞ!!!");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre YANLIŞ!!!");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                baglanti.Close();
            }
            }

        private void Kullanıcıgirişi_Load(object sender, EventArgs e)
        {
            timer1.Start();            
            label4.Text = DateTime.Now.ToString();           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            üyelik git = new üyelik(); ;
            this.Hide();
            git.Show();
        }
    }
    }

