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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1200;
            this.Height = 750;
            pictureBox1.Width = 1200;
            pictureBox1.Height = 750;
            label1.Location = new Point(892, 340);
            label1.Size = new Size(20,21);
            label2.Location = new Point(892, 500);
            label2.Size = new Size(20, 21);
            pictureBox3.Location = new Point(552, 35);
            pictureBox3.Size = new Size(90, 89);
            trackBar1.Location = new Point(488, 322);
            trackBar1.Size = new Size(358,56);
            trackBar1.BackColor = Color.FromArgb(59, 62, 71);
            trackBar2.Location = new Point(488, 481);
            trackBar2.Size = new Size(358, 56);
            trackBar2.BackColor = Color.FromArgb(59, 62, 71);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Class1.deep_passion = int.Parse(label2.Text);
            Class1.focal_passion = int.Parse(label1.Text);
            this.Close();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = (trackBar1.Value).ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = (trackBar2.Value).ToString();
        }
    }
}
