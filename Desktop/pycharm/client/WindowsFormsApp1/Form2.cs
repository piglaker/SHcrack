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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
           
            this.Width = 1200;
            this.Height = 750;
            pictureBox1.Width = 1200;
            pictureBox1.Height = 750;
            pictureBox1.Location = new Point(0, 0);
            button1.Location=new Point(409,421);
            button1.Size=new Size(160,55);
            button2.Location = new Point(633, 425);
            button2.Size = new Size(155,50);
            button2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.Size = new Size(68,25);
            pictureBox2.Location = new Point(155,52);
            button2.BackColor = Color.FromArgb(59, 62, 71);
            //pictureBox3.Size = new Size(68, 25);
            //pictureBox3.Location = new Point(294, 52);
            //pictureBox4.Size = new Size(68, 25);
            //pictureBox4.Location = new Point(595, 52);
            //pictureBox5.Size = new Size(68, 25);
            //pictureBox5.Location = new Point(711, 52);
            //string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
            //SqlConnection myconn = new SqlConnection(sql);
            //SqlCommand mycmd = new SqlCommand("select * from log_in",myconn);
            //myconn.Open();
            //{
            //    try
            //    {
            //        mycmd.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                Form7 f7 = new Form7();
                if (f7.ShowDialog(this) == DialogResult.OK)
                {
              
                //timer2.Enabled = true;
                this.Close();
                }
            

            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("很抱歉，该功能暂时未上线，敬请期待下一版本更新");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = System.Drawing.Color.White;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            
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
        public int a = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            a += 1;
            if (a == 1)
            {
                this.Close();
            }
        }
    }
}
