using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Form11 : Form
    {
        public int se = 1;
        public int crack = 1;
        public Form11()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1200;
            this.Height = 750;
            if (Class1.index != 0)
            {
                se = Class1.index;
            }
            string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
            SqlConnection myconn = new SqlConnection(sql);
            SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num="+se.ToString()+"", myconn);
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
            if (crack_direction == 1) { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); }
            else if (crack_direction == 2) { pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
            else if (crack_direction == 3) { pictureBox12.BackColor = Color.FromArgb(59, 65, 74); }
            else { pictureBox13.BackColor = Color.FromArgb(59, 65, 74); }
            chart1.Location = new Point(608, 165);
            chart1.Size = new Size(538,395);
            pictureBox1.Width = 1200;
            pictureBox1.Height = 750;
            button2.Location = new Point(846, 602);
            button2.Size = new Size(161, 54);
            button1.Location = new Point(1005, 602);
            button1.Size = new Size(157, 54);
            button3.Location = new Point(621, 603);
            button3.Size = new Size(87, 54);
            button4.Location = new Point(717, 603);
            button4.Size = new Size(88, 54);
            pictureBox3.Location = new Point(443,47);
            pictureBox3.Size=new Size(84,32);
            pictureBox2.Location = new Point(662, 47);
            pictureBox2.Size = new Size(84,32);
            pictureBox4.Location = new Point(555, 15);
            pictureBox4.Size = new Size(84,84);
            pictureBox5.Location = new Point(798, 47);
            pictureBox5.Size = new Size(84, 32);


            SqlDataAdapter myadapter2 = new SqlDataAdapter("select id,sum(case when crack_width<1 then 1 else 0 end),sum(case when crack_width>=1 and crack_width<2 then 1 else 0 end),sum(case when crack_width>=2 and crack_width<3 then 1 else 0	end) ,sum(case when crack_width>=3 and crack_width<4 then 1 else 0 end),sum(case when crack_width>=4 and crack_width<5 then 1 else 0 end ),sum(case when crack_width>=5  then 1 else 0 end) from crack_info  where id ='"+Class1.id+"' group by id",myconn);
            DataTable mytable2 = new DataTable();
            myadapter2.Fill(mytable2);
            double[] y = new double[] { double.Parse(mytable2.Rows[0].ItemArray[1].ToString()), double.Parse(mytable2.Rows[0].ItemArray[2].ToString()), double.Parse(mytable2.Rows[0].ItemArray[3].ToString()), double.Parse(mytable2.Rows[0].ItemArray[4].ToString()), double.Parse(mytable2.Rows[0].ItemArray[5].ToString()), double.Parse(mytable2.Rows[0].ItemArray[6].ToString()) };

            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;

            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;

            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = 7;
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 10;
            chart.AxisX.Interval = 1;
            chart.AxisY.Interval = 2;

            chart1.Series.Add("裂缝数量");
            chart1.Titles.Add("裂缝宽度分布图(单位：mm)");
            chart1.Titles[0].Font = new Font("Adobe 黑体 Std R", 12f, FontStyle.Regular);
            chart1.Titles[0].Alignment = ContentAlignment.TopCenter;
            //绘制折线图
            chart1.Series["裂缝数量"].ChartType = SeriesChartType.Line;
            //绘制曲线图
            //chart1.Series["line1"].ChartType = SeriesChartType.Spline;
            string[] x = new string[] {"0-1","1-2","2-3","3-4","4-5","5-" };
            
            chart1.Series["裂缝数量"].Color = Color.Red;
            chart1.Series["裂缝数量"].Font= new Font("Adobe 黑体 Std R", 12f, FontStyle.Regular);
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series["裂缝数量"].Points.DataBindXY(x, y);
            //chart1.Series[0].Points[0].Color = Color.White;
          //  chart1.Series[0].Palette = ChartColorPalette.Bright;

            //chart1.Series["裂缝数量"].Points.AddXY("0-0.1", 5);
            //chart1.Series["裂缝数量"].Points.AddXY("0.1-0.2", 6);
            // chart1.Series["裂缝数量"].Points.AddXY("0.2-0.3", 8);
            // chart1.Series["裂缝数量"].Points.AddXY("0.3-0.4", 3);
            //  chart1.Series["裂缝数量"].Points.AddXY("0.4-0.5", 2);
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            pictureBox6.Location = new Point(212, 264);
            pictureBox6.Size = new Size(51, 47);
            pictureBox7.Location = new Point(366, 264);
            pictureBox7.Size = new Size(51, 47);
            pictureBox8.Location = new Point(212, 432);
            pictureBox8.Size = new Size(51, 47);
            pictureBox9.Location = new Point(366, 432);
            pictureBox9.Size = new Size(51, 47);
            if (int.Parse(label1.Text.Trim()) < 10)
            {
                label1.Location = new Point(213, 260);
                label1.Size = new Size(48, 53);
            }
            else
            {
                label1.Location = new Point(203, 260);
                label1.Size = new Size(48, 53);
            }
            if (int.Parse(label2.Text.Trim()) < 10)
            {
                label2.Location = new Point(369, 263);
                label2.Size = new Size(48, 53);
            }
            else
            {
                label2.Location = new Point(357, 263);
                label2.Size = new Size(48, 53);
            }
            label3.Location=new Point(198, 442);
            label4.Location = new Point(364,442);
            pictureBox10.Location = new Point(79,227);
            pictureBox10.Size = new Size(63,60);
            pictureBox11.Location = new Point(76, 302);
            pictureBox11.Size = new Size(63, 60);
            pictureBox12.Location = new Point(78, 374);
            pictureBox12.Size = new Size(63, 60);
            pictureBox13.Location = new Point(76, 450);
            pictureBox13.Size = new Size(63, 60);
            pictureBox14.Location = new Point(85, 234);
            pictureBox14.Size = new Size(51,47);
            pictureBox15.Location = new Point(82,309);
            pictureBox15.Size = new Size(51,47);
            pictureBox16.Location = new Point(84,380);
            pictureBox16.Size = new Size(51, 47);
            pictureBox15.Location = new Point(82,309);
            pictureBox15.Size = new Size(51, 47);
            pictureBox17.Location = new Point(82, 456);
            pictureBox17.Size = new Size(51, 47);
            
            pictureBox10.BackColor = Color.FromArgb(59,65,74);
            label5.Location = new Point(867, 618);
            label6.Location = new Point(1036, 618);
            label6.BackColor = Color.FromArgb(59,65,74);
            label6.ForeColor = Color.White;
        }
        
        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            //f1.Show();
            //timer1.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Class1.index = 0;
            Form12 f12 = new Form12();
            f12.Show();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            timer1.Enabled = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Class1.index = 0;
            Form10 f10 = new Form10();
            f10.Show();
            timer1.Enabled = true;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (se > 1)
            {
                crack = 1;
                se -= 1;
                pictureBox10.BackColor = Color.Transparent;
                pictureBox11.BackColor = Color.Transparent;
                pictureBox12.BackColor = Color.Transparent;
                pictureBox13.BackColor = Color.Transparent;
                string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
                SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num="+se.ToString()+" ", myconn);
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
                if (crack_direction == 1) { pictureBox13.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 2) { pictureBox12.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 3) { pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 4) { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); }
                else { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int max_qwe;
            
            string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
            SqlConnection myconn = new SqlConnection(sql);
            SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,sum(crack_num) from crack_info where id = '"+Class1.id+"' group by id, pic_num  ", myconn);
            DataTable mytable = new DataTable();
            myadapter.Fill(mytable);
            max_qwe = mytable.Rows.Count;
            if (se <max_qwe)
            {
                crack = 1;
                se += 1;
                pictureBox10.BackColor = Color.Transparent;
                pictureBox11.BackColor = Color.Transparent;
                pictureBox12.BackColor = Color.Transparent;
                pictureBox13.BackColor = Color.Transparent;

                SqlDataAdapter myadapter5 = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num="+se.ToString()+" ", myconn);
                DataTable mytable5 = new DataTable();
                myadapter5.Fill(mytable5);
                int pic_num = int.Parse(mytable5.Rows[0].ItemArray[1].ToString());
                int crack_num = int.Parse(mytable5.Rows[0].ItemArray[2].ToString());
                float crack_length = float.Parse(mytable5.Rows[0].ItemArray[3].ToString());
                float crack_width = float.Parse(mytable5.Rows[0].ItemArray[4].ToString());
                int crack_direction = int.Parse(mytable5.Rows[0].ItemArray[5].ToString());
                label1.Text = pic_num.ToString();
                label2.Text = crack_num.ToString();
                label3.Text = crack_length.ToString();
                label4.Text = crack_width.ToString();
                if (crack_direction == 1) { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 2) { pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 3) { pictureBox12.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 4) { pictureBox13.BackColor = Color.FromArgb(59, 65, 74); }
                else { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (crack > 1)
            {
                crack -= 1;
                pictureBox10.BackColor = Color.Transparent;
                pictureBox11.BackColor = Color.Transparent;
                pictureBox12.BackColor = Color.Transparent;
                pictureBox13.BackColor = Color.Transparent;
                string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
                SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num="+se.ToString()+" and crack_num="+crack.ToString()+"  ", myconn);
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
                if (crack_direction == 1) { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 2) { pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 3) { pictureBox12.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 4) { pictureBox13.BackColor = Color.FromArgb(59, 65, 74); }
                else { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int max_qwe;
            
            string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
            SqlConnection myconn = new SqlConnection(sql);
            SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num=" + se.ToString() + " ", myconn);
            DataTable mytable = new DataTable();
            myadapter.Fill(mytable);
            max_qwe = mytable.Rows.Count;
            if (crack < max_qwe)
            {
                pictureBox10.BackColor = Color.Transparent;
                pictureBox11.BackColor = Color.Transparent;
                pictureBox12.BackColor = Color.Transparent;
                pictureBox13.BackColor = Color.Transparent;
                crack += 1;
                //string sql = "server= 47.95.250.165;database=crack;uid=sa;pwd=283003Qsy";
                //SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapters = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num="+se.ToString()+" and crack_num="+crack.ToString()+" ", myconn);
                DataTable mytables = new DataTable();
                myadapters.Fill(mytables);
                int pic_num = int.Parse(mytables.Rows[0].ItemArray[1].ToString());
                int crack_num = int.Parse(mytables.Rows[0].ItemArray[2].ToString());
                float crack_length = float.Parse(mytables.Rows[0].ItemArray[3].ToString());
                float crack_width = float.Parse(mytables.Rows[0].ItemArray[4].ToString());
                int crack_direction = int.Parse(mytables.Rows[0].ItemArray[5].ToString());
                label1.Text = pic_num.ToString();
                label2.Text = crack_num.ToString();
                label3.Text = crack_length.ToString();
                label4.Text = crack_width.ToString();
                if (crack_direction == 1) { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 2) { pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 3) { pictureBox12.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 4) { pictureBox13.BackColor = Color.FromArgb(59, 65, 74); }
                else { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (crack > 1)
            {
                crack -= 1;
                pictureBox10.BackColor = Color.Transparent;
                pictureBox11.BackColor = Color.Transparent;
                pictureBox12.BackColor = Color.Transparent;
                pictureBox13.BackColor = Color.Transparent;
                string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
                SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num=" + se.ToString() + " and crack_num=" + crack.ToString() + "  ", myconn);
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
                if (crack_direction == 1) { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 2) { pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 3) { pictureBox12.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 4) { pictureBox13.BackColor = Color.FromArgb(59, 65, 74); }
                else { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            int max_qwe;

            string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
            SqlConnection myconn = new SqlConnection(sql);
            SqlDataAdapter myadapter = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num=" + se.ToString() + " ", myconn);
            DataTable mytable = new DataTable();
            myadapter.Fill(mytable);
            max_qwe = mytable.Rows.Count;
            if (crack < max_qwe)
            {
                pictureBox10.BackColor = Color.Transparent;
                pictureBox11.BackColor = Color.Transparent;
                pictureBox12.BackColor = Color.Transparent;
                pictureBox13.BackColor = Color.Transparent;
                crack += 1;
                //string sql = "server= 47.95.250.165;database=crack;uid=sa;pwd=283003Qsy";
                //SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapters = new SqlDataAdapter("select id,pic_num,crack_num,crack_length,crack_width,crack_direction from crack_info where id = '" + Class1.id + "' and pic_num=" + se.ToString() + " and crack_num=" + crack.ToString() + " ", myconn);
                DataTable mytables = new DataTable();
                myadapters.Fill(mytables);
                int pic_num = int.Parse(mytables.Rows[0].ItemArray[1].ToString());
                int crack_num = int.Parse(mytables.Rows[0].ItemArray[2].ToString());
                float crack_length = float.Parse(mytables.Rows[0].ItemArray[3].ToString());
                float crack_width = float.Parse(mytables.Rows[0].ItemArray[4].ToString());
                int crack_direction = int.Parse(mytables.Rows[0].ItemArray[5].ToString());
                label1.Text = pic_num.ToString();
                label2.Text = crack_num.ToString();
                label3.Text = crack_length.ToString();
                label4.Text = crack_width.ToString();
                if (crack_direction == 1) { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 2) { pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 3) { pictureBox12.BackColor = Color.FromArgb(59, 65, 74); }
                else if (crack_direction == 4) { pictureBox13.BackColor = Color.FromArgb(59, 65, 74); }
                else { pictureBox10.BackColor = Color.FromArgb(59, 65, 74); pictureBox11.BackColor = Color.FromArgb(59, 65, 74); }
            }
        }
    }
}
