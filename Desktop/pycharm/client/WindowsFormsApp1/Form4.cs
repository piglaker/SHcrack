using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.Width = 1200;
            this.Height = 750;
            pictureBox1.Width = 1200;
            pictureBox1.Height = 750;
            pictureBox1.Location = new Point(0, 0);
            this.StartPosition = FormStartPosition.CenterScreen;
            button2.Location = new Point(100, 385);
            button2.Size = new Size(212, 48);
            button1.Location = new Point(100, 510);
            button1.Size = new Size(212, 51);
            button3.Location = new Point(404, 323);
            button3.Size = new Size(163, 51);
            button4.Location = new Point(405, 489);
            button4.Size = new Size(163, 51);
            button5.Location = new Point(671, 436);
            button5.Size = new Size(163, 51);
            button6.Location = new Point(671, 573);
            button6.Size = new Size(163, 51);
            button7.Location = new Point(978, 434);
            button7.Size = new Size(95, 51);
            button8.Location = new Point(978, 573);
            button8.Size = new Size(95, 51);
            button1.ForeColor = Color.FromArgb(94, 101, 110);
            button1.BackColor = Color.FromArgb(209, 215, 223);
            button2.ForeColor = Color.FromArgb(94, 101, 110);
            button2.BackColor = Color.FromArgb(209, 215, 223);
            button4.ForeColor = Color.FromArgb(94, 101, 110);
            button4.BackColor = Color.FromArgb(209, 215, 223);
            button3.ForeColor = Color.FromArgb(94, 101, 110);
            button3.BackColor = Color.FromArgb(209, 215, 223);
            button5.ForeColor = Color.FromArgb(94, 101, 110);
            button5.BackColor = Color.FromArgb(209, 215, 223);
            button6.ForeColor = Color.FromArgb(94, 101, 110);
            button6.BackColor = Color.FromArgb(209, 215, 223);
            button7.ForeColor = Color.FromArgb(94, 101, 110);
            button7.BackColor = Color.FromArgb(209, 215, 223);
            button8.ForeColor = Color.FromArgb(94, 101, 110);
            button8.BackColor = Color.FromArgb(209, 215, 223);
            trackBar1.Location = new Point(570, 325);
            trackBar1.Size = new Size(425,56);
            trackBar1.BackColor = Color.FromArgb(64,72,84);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            timer1.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(255, 255, 255)|| button5.BackColor == Color.FromArgb(255, 255, 255)|| button6.BackColor == Color.FromArgb(255, 255, 255))
            {
                if (button3.BackColor == Color.FromArgb(255, 255, 255))
                {
                    Class1.focal = 1;
                }
                if (button5.BackColor == Color.FromArgb(255, 255, 255))
                {
                    Class1.focal = 2;
                }
                if (button6.BackColor == Color.FromArgb(255, 255, 255))
                {
                    Class1.focal = 3;
                }
                Class1.amount_accuracy = trackBar1.Value;
                Form6 f6 = new Form6();
                f6.Show();
                timer1.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(209, 215, 223))
            {
                button2.BackColor = Color.FromArgb(255, 255, 255);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(255, 255, 255))
            {
                if (button4.BackColor == Color.FromArgb(209, 215, 223))
                {
                    button3.BackColor = Color.FromArgb(255, 255, 255);
                }
                if (button3.BackColor == Color.FromArgb(209, 215, 223) && button4.BackColor == Color.FromArgb(255, 255, 255))
                {
                    button3.BackColor = Color.FromArgb(255, 255, 255);
                    button4.BackColor = Color.FromArgb(209, 215, 223);
                }

                button5.BackColor = Color.FromArgb(209, 215, 223);
                button6.BackColor = Color.FromArgb(209, 215, 223);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(255, 255, 255))
            {
                if (button3.BackColor == Color.FromArgb(209, 215, 223))
                {
                    button4.BackColor = Color.FromArgb(255, 255, 255);
                }
                if (button4.BackColor == Color.FromArgb(209, 215, 223) && button3.BackColor == Color.FromArgb(255, 255, 255))
                {
                    button4.BackColor = Color.FromArgb(255, 255, 255);
                    button3.BackColor = Color.FromArgb(209, 215, 223);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.FromArgb(255, 255, 255))
            {
                if (button6.BackColor == Color.FromArgb(209, 215, 223))
                {
                    button5.BackColor = Color.FromArgb(255, 255, 255);
                }
                if (button5.BackColor == Color.FromArgb(209, 215, 223) && button6.BackColor == Color.FromArgb(255, 255, 255))
                {
                    button5.BackColor = Color.FromArgb(255, 255, 255);
                    button6.BackColor = Color.FromArgb(209, 215, 223);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.FromArgb(255, 255, 255))
            {
                if (button5.BackColor == Color.FromArgb(209, 215, 223))
                {
                    button6.BackColor = Color.FromArgb(255, 255, 255);
                }
                if (button6.BackColor == Color.FromArgb(209, 215, 223) && button5.BackColor == Color.FromArgb(255, 255, 255))
                {
                    button6.BackColor = Color.FromArgb(255, 255, 255);
                    button5.BackColor = Color.FromArgb(209, 215, 223);
                }
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
