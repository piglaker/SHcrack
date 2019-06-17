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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1200;
            this.Height = 750;
            pictureBox1.Width = 1200;
            pictureBox1.Height = 750;
            pictureBox1.Location=new Point(0,0);
            button2.Location = new Point(792, 398);
            button2.Size = new Size(49,45);
            textBox2.Location = new Point(360, 405);
            textBox2.Size = new Size(432,36);
            pictureBox2.Location = new Point(460, 47);
            pictureBox2.Size=new Size(84, 32);
            pictureBox3.Location = new Point(548,239);
            pictureBox3.Size = new Size(104,101);
            pictureBox4.Location = new Point(780, 47);
            pictureBox4.Size = new Size(84, 32);
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tmp;
            
            if (textBox2.Text.Trim() != "" && int.TryParse(textBox2.Text, out tmp))
            {
                string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
                SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,sum(crack_num) from crack_info where id = '" + Class1.id + "' group by id,pic_num", myconn);
                DataTable mytable = new DataTable();
                myadapter.Fill(mytable);
                int num = mytable.Rows.Count;
                Class1.index = int.Parse(textBox2.Text.Trim());
                if (Class1.index <= num&&Class1.index!=0)
                {
                    Form11 f11 = new Form11();
                    f11.Show();
                    timer1.Enabled = true;

                }
                else { MessageBox.Show("图片不存在！"); }
            }
            else { MessageBox.Show("请输入图片编号！"); }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
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

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2.PerformClick();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            timer1.Enabled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2.PerformClick();
            }
        }
    }
}
