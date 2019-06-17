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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Width = 1200;
            this.Height = 750;
            pictureBox1.Width = 1200;
            pictureBox1.Height = 750;
            button2.Location = new Point(360, 374);
            button2.Size = new Size(453, 52);
            button1.Location = new Point(360, 457);
            button1.Size = new Size(453, 51);
            button3.Location = new Point(360, 546);
            button3.Size = new Size(453, 51);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.matlab = 1;
            Form9 f9 = new Form9();
            f9.Show();
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.matlab = 2;
            Form9 f9 = new Form9();
            f9.Show();
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.matlab = 3;
            Form9 f9 = new Form9();
            f9.Show();
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
