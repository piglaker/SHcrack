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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1200;
            this.Height = 750;
            string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
            SqlConnection myconn = new SqlConnection(sql);
            SqlDataAdapter myadapter = new SqlDataAdapter("select id from pic where id = '"+Class1.id+"' ", myconn);
            DataTable mytable = new DataTable();
            myadapter.Fill(mytable);
            int a = mytable.Rows.Count;
            Class1.min = a + 1;
            for (int i = 0; i < 100; i++)
            {
                if (Class1.filenames[i] != null)
                {
                    string url = Class1.filenames[i];
                    byte[] dd = GetContent(url);
                    pass(dd, i+1+a);
                    Class1.max = a + 1 + i;
                }
            }
            if (Class1.focal == 0)
            {
                int num = 0;
                foreach (var item in Class1.pos)
                {
                    //SqlDataAdapter myadapter2 = new SqlDataAdapter("insert into non_auto values()", myconn);
                    //DataTable mytable2 = new DataTable();
                    // myadapter.Fill(mytable);
                    int i = item.Key;


                    for (int p = 0; p < item.Value; p++)
                    {
                        string non_string = "insert into non_auto values('" + Class1.id + "'," + (i + a).ToString() + ",";
                        non_string = non_string + Class1.x[num + p].X.ToString() + "," + Class1.x[num + p].Y.ToString() + "," + Class1.y[num + p].X.ToString() + "," + Class1.y[num + p].Y.ToString() + "," + Class1.semantic.ToString() + "," + Class1.matlab.ToString() + ")";
                        SqlCommand mycmd = new SqlCommand(non_string, myconn);
                        myconn.Open();
                        {
                            try
                            {
                                mycmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        myconn.Close();
                    }
                    num += item.Value;
                }
            }
            else
            {
                int r=0;
                for (int k = 0; k < 100; k++)
                {
                    if (Class1.filenames[k] != null)
                    {
                        r++;
                    }
                }
                for (int p = 0; p < r; p++)
                {
                    string mystr = "insert into auto_detect values('" + Class1.id + "',"+(a+p+1).ToString()+","+Class1.focal.ToString()+","+Class1.focal_passion.ToString()+","+Class1.deep_passion.ToString()+","+Class1.amount_accuracy.ToString()+","+Class1.semantic.ToString()+","+Class1.matlab.ToString()+")";
                    SqlCommand mycmd = new SqlCommand(mystr,myconn);
                    myconn.Open();
                    {
                        try
                        {
                            mycmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    myconn.Close();
                }
            }
            pictureBox1.Width = 1205;
            pictureBox1.Height = 755;
             this.DoubleBuffered = true;
            string a34=System.IO.Directory.GetCurrentDirectory();
            string path = new DirectoryInfo("../../../").FullName;
            // pictureBox1.BackgroundImage = Image.FromFile("D:\\university\\sophomore\\计算机大赛裂缝组\\WindowsFormsApp1\\素材\\img1.gif");
            pictureBox2.Image = Image.FromFile(path+"素材\\小圈圈.gif");
            pictureBox1.Location = new Point(0,0);
            pictureBox2.Location = new Point(511, 338);
            pictureBox2.Size = new Size(136, 136);
            timer1.Enabled = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        public float i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i += 1;
            if (i % 10 == 0)
            {
                string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
                SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapter = new SqlDataAdapter("select  id,pic_num,count(crack_num) from crack_info where id = '"+Class1.id+"' group by id,pic_num ", myconn);
                DataTable mytable = new DataTable();
                myadapter.Fill(mytable);
                int a = mytable.Rows.Count;


                SqlDataAdapter myadapter2 = new SqlDataAdapter("select pic_num from pic where id='"+Class1.id+"'  ", myconn);
                DataTable mytable2 = new DataTable();
                myadapter2.Fill(mytable2);

                int count = mytable2.Rows.Count;
                
                if (a == count)
                {
                    Form10 f10 = new Form10();
                    f10.Show();
                    timer2.Enabled = true;
                }
            }
            
            
        }
        public static Byte[] GetContent(string filepath)//将指定路径下的文件转换成二进制代码，用于传输到数据库
        {
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            Byte[] byData = new Byte[fs.Length];//新建用于保存文件流的字节数组
            fs.Read(byData, 0, byData.Length);//读取文件流
            fs.Close();
            return byData;
        }
        public byte[] GetPictureData(string imagepath)
        {
            ////根据图片文件的路径使用文件流打开，并保存为byte[] 
            FileStream fs = new FileStream(imagepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);

            StringBuilder sb = new StringBuilder();
            while (!sr.EndOfStream)
            {
                sb.AppendLine(sr.ReadLine() + "<br>");
            }
            
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            fs.Close();
            return byData;
        }

        private void pass(byte[] imgBytesIn,int p)
        {
            try
            {
                SqlConnection con = new SqlConnection("server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert  into pic values( '"+Class1.id+"','"+p.ToString()+"',@Image ) ;", con);
                cmd.Parameters.Add("@Image", SqlDbType.Image);
                cmd.Parameters["@Image"].Value = imgBytesIn;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        int r = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            r++;
            if (r == 5)
            {
                Array.Clear(Class1.x, 0, Class1.y.Length);
                Array.Clear(Class1.y, 0, Class1.y.Length);
                
                Array.Clear(Class1.filenames,0,Class1.filenames.Length);
                this.Close();
            }

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
