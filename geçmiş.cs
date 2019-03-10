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
    public partial class geçmiş : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\anamenuveri.mdb");
        public geçmiş()
        {
            InitializeComponent();
        }
        DataTable tablo = new DataTable();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adap = new OleDbDataAdapter("Select * from gecmis where  plaka='" + textBox1.Text + "'", baglanti);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void geçmiş_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adap = new OleDbDataAdapter("Select * from gecmis", baglanti);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
