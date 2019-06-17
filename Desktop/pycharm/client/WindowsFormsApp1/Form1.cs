using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1200;
            this.Height = 750;
            pictureBox5.Width = 1200;
            pictureBox5.Height = 750;
            pictureBox1.Location = new Point(404,71);
            pictureBox1.Size = new Size(84, 32);
            pictureBox2.Location = new Point(570, 267);
            pictureBox2.Size = new Size(520, 270);
            pictureBox3.Location = new Point(570, 554);
            pictureBox3.Size = new Size(120,96);
            pictureBox4.Location = new Point(703, 554);
            pictureBox4.Size = new Size(120, 96);
            pictureBox6.Location = new Point(835, 554);
            pictureBox6.Size = new Size(120, 96);
            pictureBox9.Location = new Point(688,72);
            pictureBox9.Size = new Size(84,32);
            pictureBox7.Location = new Point(968, 554);
            pictureBox7.Size = new Size(120, 96);
            pictureBox8.Location = new Point(545,72);
            pictureBox8.Size = new Size(84,32);
            button2.Location = new Point(136, 338);
            button2.Size = new Size(345,57);
            button1.Location = new Point(136, 456);
            button1.Size = new Size(345, 57);
            pictureBox5.Location = new Point(0, 0);
            button3.Location = new Point(136, 587);
            button3.Size = new Size(151,55);
            button4.Location = new Point(330, 587);
            button4.Size = new Size(151, 55);
            pictureBox10.Location = new Point(830,72);
            pictureBox10.Size = new Size(84,32);
            if (Class1.key == 0)
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }

        }
        public static byte[] imgbytesIn;
        Stream ms;
        byte[] picbyte;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();


            if (f3.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();


            if (f3.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();


            if (f4.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();


            if (f4.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();


            if (f5.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();


            if (f5.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            this.Hide();


            if (f6.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            this.Hide();


            if (f6.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Text = "减少图片";
            button1.ForeColor = Color.FromArgb(120,125,133);

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff|" + "Windows Bitmap(*.bmp)|*.bmp|" + "Windows Icon(*.ico)|*.ico|" + "Graphics Interchange Format (*.gif)|(*.gif)|" + "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|" + "Portable Network Graphics (*.png)|*.png|" + "Tag Image File Format (*.tif)|*.tif;*.tiff";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string[] files;
                files = openFileDialog1.FileNames;
                int a=files.Length;
                int b = 0;
                if (Class1.filenames[0] != null)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        if (string.IsNullOrEmpty(Class1.filenames[i]) == true)
                        {
                            b = i;
                            break;
                        }
                    }
                }
                
                for (int i = 0; i < a; i++)
                {
                    Class1.filenames[b++] = files[i];
                }

                if ((ms = openFileDialog1.OpenFile()) != null)
                {
                    Class1.state = 1;
                    picbyte = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(picbyte, 0, Convert.ToInt32(ms.Length));
                    set_pic(Class1.point);
                }
            }
            else
            {
                MessageBox.Show("您选择的图片不能被读取或文件类型不对！");
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int b;
            for (int i = 0; i < 100; i++)
            {
                if (string.IsNullOrEmpty(Class1.filenames[i]) == true)
                {
                    b = i;
                    if (b != 0)
                    {
                        Class1.filenames[b - 1] = null;
                    }
                    break;
                }
            }
            
            if (string.IsNullOrEmpty(Class1.filenames[4]) == true)
            {
                pictureBox7.Image = null;
            }
            if (string.IsNullOrEmpty(Class1.filenames[3]) == true)
            {
                pictureBox6.Image = null;
            }
            if (string.IsNullOrEmpty(Class1.filenames[2]) == true)
            {
                pictureBox4.Image = null;
            }
            if (string.IsNullOrEmpty(Class1.filenames[1]) == true)
            {
                pictureBox3.Image = null;
            }
            if (string.IsNullOrEmpty(Class1.filenames[0]) == true)
            {
                pictureBox2.Image = null;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (Class1.state == 1)
            {
                Form3 f3 = new Form3();
                f3.Show();
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("请导入图片！");
            }
            
        }
        public int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i += 1;
            if (i == 5)
            {
                this.Hide();
            }
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.ShowDialog();
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.point = Class1.point- 5;
            if (Class1.point < 0)
            {
                Class1.point = 0;
            }
            if (Class1.point >= 0)
            {
                set_pic(Class1.point);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1.point += 5;
            if (Class1.point < 100)
            {
                set_pic(Class1.point);
            }
        }
        private void set_pic(int point)
        {
            if (string.IsNullOrEmpty(Class1.filenames[point]) == false)
            {
                pictureBox2.Image = Image.FromFile(Class1.filenames[point]);
                pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (string.IsNullOrEmpty(Class1.filenames[point+1]) == false)
            {
                pictureBox3.Image = Image.FromFile(Class1.filenames[point+1]);
                pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (string.IsNullOrEmpty(Class1.filenames[point+2]) == false)
            {
                pictureBox4.Image = Image.FromFile(Class1.filenames[point+2]);
                pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (string.IsNullOrEmpty(Class1.filenames[point+3]) == false)
            {
                pictureBox6.Image = Image.FromFile(Class1.filenames[point+3]);
                pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (string.IsNullOrEmpty(Class1.filenames[point+4]) == false)
            {
                pictureBox7.Image = Image.FromFile(Class1.filenames[point+4]);
                pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (Class1.min == Class1.max && Class1.min == 0)
            { MessageBox.Show("no images analyzed!"); }
            else
            {
                Form10 f10 = new Form10();
                f10.Show();
                timer1.Enabled = true;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
