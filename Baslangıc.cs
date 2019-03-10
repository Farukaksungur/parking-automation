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
    public partial class Baslangıc : Form
    {
        public Baslangıc()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value<100)
            {
                progressBar1.Value = progressBar1.Value + 5;
            }
            else
            {
                timer1.Enabled = false;
                Form kullanici = new Kullanıcıgirişi();
                kullanici.Show();
                this.Hide();
            }
        }
    }
}
