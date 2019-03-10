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
    public partial class üyelik : Form
    {
        public üyelik()
        {
            InitializeComponent();
        }
        OleDbConnection bağlanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\anamenuveri.mdb");
        private void button2_Click(object sender, EventArgs e)
        {
            Kullanıcıgirişi git = new Kullanıcıgirişi();
            this.Hide();
            git.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Girdiğiniz şifreler aynı değil. Lütfen yeniden şifre giriniz.");
                textBox3.Clear();
                textBox4.Clear();
                textBox3.Focus();
            }
            bağlanti.Open();
            OleDbCommand ekle = new OleDbCommand("Insert into kullanıcıveri (adsoyad,kullanıcıadı,şifre,telefon) Values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + maskedTextBox1.Text.ToString() + "')", bağlanti);
            ekle.ExecuteNonQuery();
            bağlanti.Close();
            MessageBox.Show("Başarılı");
        }
    }
}
