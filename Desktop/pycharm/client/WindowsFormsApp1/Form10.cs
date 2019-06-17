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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1200;
            this.Height = 750;


            pictureBox1.Width = 1200;
            pictureBox1.Height = 750;
            pictureBox5.Size = new Size(98, 89);
            pictureBox5.Location = new Point(551, 14);
            button2.Location = new Point(847,601);
            button2.Size = new Size(161,54);
            button1.Location = new Point(1005, 601);
            button1.Size = new Size(157, 54);
            pictureBox2.Location = new Point(600,165);
            pictureBox2.Size = new Size(562,421);
            label1.Location = new Point(269, 280);
            //label1.Size = new Size(53,19);
            label2.Location = new Point(269, 328);
            //label2.Size = new Size(53, 19);
            label3.Location = new Point(269, 375);
            //label3.Size = new Size(53, 19);
            label4.Location = new Point(269, 422);
            //label4.Size = new Size(53, 19);
            label5.Location = new Point(269,471);
            //label5.Size = new Size(53, 19);
            pictureBox4.Location = new Point(442, 47);
            pictureBox4.Size = new Size(84,32);
            pictureBox3.Location=new Point(661, 47);
            pictureBox3.Size = new Size(84, 32);
            for (int i = 0; i < 100; i++)
            {
                Class1.filenames[i] = null;
            }
            Class1.semantic = 0;
            Class1.matlab = 0;
            Class1.focal = 0;
            string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
            SqlConnection myconn = new SqlConnection(sql);
            SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction,crack_rcnn from crack_info where id = '" + Class1.id + "' and pic_num>="+Class1.min.ToString()+" and pic_num<="+Class1.max.ToString()+" ", myconn);
            DataTable mytable = new DataTable();
            myadapter.Fill(mytable);
            int pic_num = int.Parse(mytable.Rows[0].ItemArray[1].ToString());
            int crack_num = int.Parse(mytable.Rows[0].ItemArray[2].ToString());
            float crack_length = float.Parse(mytable.Rows[0].ItemArray[3].ToString());
            float crack_width = float.Parse(mytable.Rows[0].ItemArray[4].ToString());
            int crack_direction = int.Parse(mytable.Rows[0].ItemArray[5].ToString());
            label1.Text = pic_num.ToString();
            label2.Text = crack_num.ToString();
            label3.Text = crack_length.ToString();
            label4.Text = crack_width.ToString();
            if (crack_direction == 1) { label5.Text = "横向"; }
            else if (crack_direction == 2) { label5.Text = "竖向"; }
            else if (crack_direction == 3) { label5.Text = "左斜"; }
            else if (crack_direction == 4) { label5.Text = "右斜"; }
            else { label5.Text = "弯曲"; }
            byte[] mydata1;
            MemoryStream myPic1 = null;
            mydata1 = (byte[])(mytable.Rows[0].ItemArray[6]);
            myPic1 = new MemoryStream(mydata1);
            pictureBox2.BackgroundImage= Image.FromStream(myPic1);
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public int pos = 1;
        public int pic_point = 0;
        private void Form10_Load(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            timer1.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int max = 0;
            string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
            SqlConnection myconn = new SqlConnection(sql);
            SqlDataAdapter myadaptert = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num>=" + Class1.min.ToString() + " and pic_num<=" + Class1.max.ToString() + " ", myconn);
            DataTable mytablet = new DataTable();
            myadaptert.Fill(mytablet);
            max = mytablet.Rows.Count;
            if (pos < max)
            {
                pos += 1;
                SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction,crack_rcnn  from crack_info where id = '" + Class1.id + "' and pic_num>=" + Class1.min.ToString() + " and pic_num<=" + Class1.max.ToString() + " ", myconn);
                DataTable mytable = new DataTable();
                myadapter.Fill(mytable);
                int pic_num = int.Parse(mytable.Rows[pos-1].ItemArray[1].ToString());
                int crack_num = int.Parse(mytable.Rows[pos-1].ItemArray[2].ToString());
                float crack_length = float.Parse(mytable.Rows[pos-1].ItemArray[3].ToString());
                float crack_width = float.Parse(mytable.Rows[pos-1].ItemArray[4].ToString());
                int crack_direction = int.Parse(mytable.Rows[pos-1].ItemArray[5].ToString());
                label1.Text = pic_num.ToString();
                label2.Text = crack_num.ToString();
                label3.Text = crack_length.ToString();
                label4.Text = crack_width.ToString();
                if (crack_direction == 1) { label5.Text = "左斜"; }
                else if (crack_direction == 2) { label5.Text = "右斜"; }
                else if (crack_direction == 3) { label5.Text = "竖向"; }
                else { label5.Text = "横向"; }      
                byte[] mydata1;
                MemoryStream myPic1 = null;
                mydata1 = (byte[])(mytable.Rows[0].ItemArray[6]);
                myPic1 = new MemoryStream(mydata1);
                pictureBox2.BackgroundImage = Image.FromStream(myPic1);
                pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pos >1)
            {
                pos -= 1;
                string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
                SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction,crack_rcnn from crack_info where id = '" + Class1.id + "' and pic_num>=" + Class1.min.ToString() + " and pic_num<=" + Class1.max.ToString() + " ", myconn);
                DataTable mytable = new DataTable();
                myadapter.Fill(mytable);
                int pic_num = int.Parse(mytable.Rows[pos-1].ItemArray[1].ToString());
                int crack_num = int.Parse(mytable.Rows[pos-1].ItemArray[2].ToString());
                float crack_length = float.Parse(mytable.Rows[pos-1].ItemArray[3].ToString());
                float crack_width = float.Parse(mytable.Rows[pos-1].ItemArray[4].ToString());
                int crack_direction = int.Parse(mytable.Rows[pos-1].ItemArray[5].ToString());
                label1.Text = pic_num.ToString();
                label2.Text = crack_num.ToString();
                label3.Text = crack_length.ToString();
                label4.Text = crack_width.ToString();
                if (crack_direction == 1) { label5.Text = "左斜"; }
                else if (crack_direction == 2) { label5.Text = "右斜"; }
                else if (crack_direction == 3) { label5.Text = "竖向"; }
                else { label5.Text = "横向"; }
                byte[] mydata1;
                MemoryStream myPic1 = null;
                mydata1 = (byte[])(mytable.Rows[0].ItemArray[6]);
                myPic1 = new MemoryStream(mydata1);
                pictureBox2.BackgroundImage = Image.FromStream(myPic1);
                pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
    }
}
