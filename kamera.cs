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
using System.IO;

namespace Otopark_Projesi
{
    public partial class kamera : Form
    {
        private FilterInfoCollection webcam;

        private VideoCaptureDevice cam;
        public kamera()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\anamenuveri.mdb");
        string resimPath;

        private void kamera_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videocapturedevice in webcam)
            {
                comboBox1.Items.Add(videocapturedevice.Name);
            }
            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }
        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning) 
            {
                cam.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            pictureBox2.Image = pictureBox1.Image;
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        { 
            if (cam.IsRunning)
            {
                cam.Stop();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form kapatc = new Anamenu();
            kapatc.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";

            sfd.Title = "Kayıt";

            sfd.FileName = "resim";

            DialogResult sonuç = sfd.ShowDialog();

            if (sonuç == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);


            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form acekle = new ekle();
            acekle.Show();
            this.Hide();
        }
    }
    }

