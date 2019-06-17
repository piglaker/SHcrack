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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Width = 1200;
            this.Height = 750;
            pictureBox1.Width = 1200;
            pictureBox1.Height = 750;
            pictureBox1.Location = new Point(0, 0);
            button2.Location = new Point(323,489);
            button2.Size = new Size(140,47);
            button2.BackColor = System.Drawing.Color.Transparent;
            textBox2.BackColor = Color.FromArgb(241, 242,246);
            textBox3.BackColor = Color.FromArgb(241, 242, 246);
            textBox2.Size = new Size(308,48);
            textBox2.Location = new Point(153,330);
            textBox3.Size = new Size(308, 60);
            textBox3.Location = new Point(153, 415);
            textBox3.PasswordChar = '*';
            pictureBox2.Location = new Point(150,493);
            pictureBox2.Size = new Size(22,27);
            pictureBox2.BackColor = Color.FromArgb(208, 215, 223);
            pictureBox3.Location = new Point(550, 38);
            pictureBox3.Size = new Size(96,89);
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a,b;
            a = textBox2.Text.Trim();
            b = textBox3.Text.Trim();
            try
            {
                string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
                SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapter = new SqlDataAdapter("select * from log_in where id='" + a + "'", myconn);
                DataTable mytable = new DataTable();
                myadapter.Fill(mytable);
                if (mytable.Rows.Count == 0)
                {
                    MessageBox.Show("账号不存在！");
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else if (textBox3.Text.ToString() != mytable.Rows[0].ItemArray[1].ToString())
                {
                    MessageBox.Show("密码输入错误！");
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    Class1.id = a;
                    Class1.psww = b;
                    Class1.key = 1;
                    this.DialogResult = DialogResult.OK;
                    //Form1 f1 = new Form1();
                    //f1.Show();
                    timer1.Enabled = true;

                }
            }
            catch (Exception ex)
                {
                    MessageBox.Show("请使用同济大学VPN！");
                }

            }

            private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BackColor == Color.FromArgb(208, 215, 223))
            { pictureBox2.BackColor = System.Drawing.Color.Transparent; }
            else
            {
                pictureBox2.BackColor = Color.FromArgb(208, 215, 223);
            }
        }

        private void Form7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== 13)
            {
                button2.PerformClick();
            }
        }

        private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2.PerformClick();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
    }
}
