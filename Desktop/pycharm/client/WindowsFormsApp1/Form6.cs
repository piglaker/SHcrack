using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Width = 1200;
            this.Height = 750;
            pictureBox2.Width = 1200;
            pictureBox2.Height = 750;
            button2.Location = new Point(354, 374);
            button2.Size = new Size(453, 54);
            button1.Location = new Point(354, 457);
            button1.Size = new Size(453, 54);
            button3.Location = new Point(354, 541);
            button3.Size = new Size(453, 54);
        }
        public static byte[] imgbytesIn;
        Stream ms;
        byte[] picbyte;
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter= "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff|"+"Windows Bitmap(*.bmp)|*.bmp|"+"Windows Icon(*.ico)|*.ico|"+"Graphics Interchange Format (*.gif)|(*.gif)|"+"JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|"+"Portable Network Graphics (*.png)|*.png|"+"Tag Image File Format (*.tif)|*.tif;*.tiff";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                if ((ms = openFileDialog1.OpenFile()) != null)
                {
                    picbyte = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(picbyte,0,Convert.ToInt32(ms.Length));
                    pictureBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            else
            {
                MessageBox.Show("您选择的图片不能被读取或文件类型不对！");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.semantic = 1;
            Form8 f8 = new Form8();
            f8.Show();
            timer1.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Class1.semantic = 2;
            Form8 f8 = new Form8();
            f8.Show();
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.semantic = 3;
            Form8 f8 = new Form8();
            f8.Show();
            timer1.Enabled = true;
        }
        public int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i += 1;
            if (i == 5)
            {
                this.Close();
            }
        }
    }
}
