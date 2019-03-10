using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark_Projesi
{
    public partial class Anamenu : Form
    {
        public Anamenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form ekleform = new ekle();
            ekleform.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form aracc = new araccıkıs();
            aracc.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form konum = new konum();
            konum.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form gecmis = new geçmiş();
            gecmis.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form kapat = new Kullanıcıgirişi();
            kapat.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form kamera = new kamera();
            kamera.Show();
        }
    }
}
