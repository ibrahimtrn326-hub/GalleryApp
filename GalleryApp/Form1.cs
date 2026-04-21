using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalleryApp
{
    public partial class Form1 : Form
    {
        List<PictureBox> secilist = new List<PictureBox>();
        PictureBox secili = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Multiselect = true;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach(string dosya in openFileDialog.FileNames)
                {
                   PictureBox pic =new PictureBox();
                    pic.Image=Image.FromFile(dosya);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Width = 100;
                    pic.Height = 100;
                    pic.Margin=new Padding(5);
                    pic.BorderStyle=BorderStyle.FixedSingle;
                    pic.Click += (s, ev) =>
                    {
                     PictureBox tiklanan =(PictureBox)s;
                        pictureBox1.Image = tiklanan.Image;
                        secili=tiklanan;
                        tiklanan.BorderStyle=BorderStyle.Fixed3D;

                    };
                    flowLayoutPanel1.Controls.Add(pic);

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(secili != null)
            {
                flowLayoutPanel1.Controls.Remove(secili);
                secili.Dispose();
                pictureBox1.Image=null;
                secili=null;
            }
            else
            {
                MessageBox.Show("Önce bir resim seçiniz");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
