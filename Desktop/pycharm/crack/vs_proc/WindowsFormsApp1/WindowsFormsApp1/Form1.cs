using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Threading;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Cmd nb = new Cmd();
            //nb.RunCmd("E: \n cd zxtdeeplearning \n cd crack \n cd matlab_proc \n s.bat");
            //nb.RunCmd("E: \n cd zxtdeeplearning \n cd crack \n cd model \n python predict.py -i E:\\zxtdeeplearning\\crack\\matlab_proc\\temp\\predictions\\images -o E:\\zxtdeeplearning\\crack\\matlab_proc\\temp\\0\\images\\output.jpg " );
            
            
            timer1.Enabled = true;

        }
        public string filenames;
        public int a;
        public int num;
        public float[] a1 = new float[100];
        public float[] a2 = new float[100];
        public float[] a3 = new float[100];
        public float[] a4 = new float[100];
        public float[] a5 = new float[100];
        public string id;
        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void RunBat(string filename)
        {
            Process pro = new Process();

            FileInfo file = new FileInfo(filename);
            pro.StartInfo.WorkingDirectory = file.Directory.FullName;
            pro.StartInfo.FileName = filename;
            pro.StartInfo.CreateNoWindow = false;
            pro.Start();
            pro.WaitForExit();
        }
        public static void DeleteFolder1(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件  
                }
                else
                    DeleteFolder1(d);////递归删除子文件夹
                //Directory.Delete(d);
            }
        }
        private static void copyFiles(string srcFolder, string destFolder, int i)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(srcFolder);
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files) // Directory.GetFiles(srcFolder)        
            {
                if (file.Name == i.ToString() + ".png")
                {
                    //file.CopyTo(Path.Combine(destFolder, file.Name));
                    file.MoveTo(Path.Combine(destFolder, file.Name));//复制 ，剪切的话file.MoveTo();            
                }            // will move all files without if stmt             
                             //file.MoveTo(Path.Combine(destFolder, file.Name));       
            }
        }
        private static void renameFiles(string srcFolder, string destFolder, int i)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(srcFolder);
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files) // Directory.GetFiles(srcFolder)        
            {
                if (file.Name == i.ToString() + ".png")
                {
                    //file.CopyTo(Path.Combine(destFolder, file.Name));
                    file.MoveTo(Path.Combine(destFolder, "1.png"));//复制 ，剪切的话file.MoveTo();            
                }            // will move all files without if stmt             
                             //file.MoveTo(Path.Combine(destFolder, file.Name));       
            }
        }
        private static void rerenameFiles(string srcFolder, string destFolder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(srcFolder);
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files) // Directory.GetFiles(srcFolder)        
            {
                if (file.Name == "1.png")
                {
                    //file.CopyTo(Path.Combine(destFolder, file.Name));
                    file.MoveTo(Path.Combine(destFolder));//复制 ，剪切的话file.MoveTo();            
                }            // will move all files without if stmt             
                             //file.MoveTo(Path.Combine(destFolder, file.Name));       
            }
        }
        public class Cmd
        {
            private Process proc = null;
            /// <summary>
            /// 构造方法
            /// </summary>
            public Cmd()
            {
                proc = new Process();
            }
            /// <summary>
            /// 执行CMD语句
            /// </summary>
            /// <param name="cmd">要执行的CMD命令</param>
            public string RunCmd(string cmd)
            {
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                
                proc.StandardInput.WriteLine(cmd+"&exit");
                
               // proc.StandardInput.WriteLine("exit");
                string outStr = proc.StandardOutput.ReadToEnd();
                proc.Close();
                return outStr;
            }
            /// <summary>
            /// 打开软件并执行命令
            /// </summary>
            /// <param name="programName">软件路径加名称（.exe文件）</param>
            /// <param name="cmd">要执行的命令</param>
            public void RunProgram(string programName, string cmd)
            {
                Process proc = new Process();
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.FileName = programName;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                if (cmd.Length != 0)
                {
                    proc.StandardInput.WriteLine(cmd);
                }
                proc.Close();
            }
            /// <summary>
            /// 打开软件
            /// </summary>
            /// <param name="programName">软件路径加名称（.exe文件）</param>
            public void RunProgram(string programName)
            {
                this.RunProgram(programName, "");
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
        public void writeBATFile(string fileContent)
        {
            string filePath = "C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\single.bat";
            if (!File.Exists(filePath))
            {
                FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);//创建写入文件
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(fileContent);//开始写入值
                sw.Close();
                fs1.Close();
            }
            else
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(fileContent);//开始写入值
                sr.Close();
                fs.Close();
            }
        }
        public int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {


                string sql = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
                SqlConnection myconn = new SqlConnection(sql);
                SqlDataAdapter myadapter = new SqlDataAdapter("select * from auto_detect ", myconn);
                DataTable mytable = new DataTable();
                myadapter.Fill(mytable);



                if (mytable.Rows.Count != 0)
                {

                    id = mytable.Rows[0].ItemArray[0].ToString();

                    int count = mytable.Rows.Count;
                    int[] pic_num = new int[count];
                    for (int f = 0; f < count; f++)
                    {
                        pic_num[f] = int.Parse(mytable.Rows[f].ItemArray[1].ToString());
                    }
                    for (int g = 0; g < count; g++)
                    {
                        string mystring = "select pic from pic where id='" + id + "' and pic_num=" + pic_num[g];

                        SqlDataAdapter myadapter4 = new SqlDataAdapter(mystring, myconn);
                        DataTable mytable4 = new DataTable();
                        myadapter4.Fill(mytable4);
                        if (mytable4.Rows.Count == 1)
                        {
                            MemoryStream myPic = null;

                            byte[] mydata;


                            mydata = (byte[])(mytable4.Rows[0].ItemArray[0]);
                            myPic = new MemoryStream(mydata);

                            System.Drawing.Image img = System.Drawing.Image.FromStream(myPic);
                            img.Save("C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\batch\\" + (g + 1).ToString() + ".png");
                        }
                        else
                        {

                            MemoryStream myPic = null;

                            byte[] mydata;


                            mydata = (byte[])(mytable4.Rows[g].ItemArray[0]);
                            myPic = new MemoryStream(mydata);

                            System.Drawing.Image img = System.Drawing.Image.FromStream(myPic);
                            img.Save("C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\batch\\" + (g + 1).ToString() + ".png");
                        }
                    }

                    //在此调出操作的模式
                    SqlDataAdapter myadapter2 = new SqlDataAdapter("select * from auto_detect where id='" + id + "'", myconn);
                    DataTable mytable2 = new DataTable();
                    myadapter2.Fill(mytable2);
                    int focal_num = int.Parse(mytable2.Rows[0].ItemArray[2].ToString());
                    int weigh = int.Parse(mytable2.Rows[0].ItemArray[3].ToString());
                    int semantic = int.Parse(mytable2.Rows[0].ItemArray[4].ToString());
                    int matlab = int.Parse(mytable2.Rows[0].ItemArray[5].ToString());
                    SqlDataAdapter myadapter3 = new SqlDataAdapter("select id,pic_num,sum(focal_num) from auto_detect where id='" + id + "' group by id, pic_num", myconn);
                    DataTable mytable3 = new DataTable();
                    myadapter3.Fill(mytable3);
                    int ere = mytable3.Rows.Count;



                   
                        for (int qwe = 0; qwe < count ; qwe++)
                        {
                            //将batch中图片一张张放到single里
                            copyFiles("C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\batch\\", "C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\single\\", (qwe+1));
                        renameFiles("C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\single\\", "C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\single\\", (qwe + 1));
                            if (focal_num == 1 || focal_num == 2 || focal_num == 3)
                            {
                                 string mystr;
                                mystr = "call activate pythontf \n cd.. \n cd model \n python fcnn_predict.py --img_dir=../matlab_proc/single/1.png    \n cd.. \n python build_voc2012_data.py \n python vis.py \n cd model \n python joint.py \n cd.. \n  python skeleton.py --binary_imgdir=./python_proc/deeplab/ --trash_imgdir=./python_proc/trash/  --original_imgdir=./matlab_proc/single/      --concat_imgdir=./python_proc/concat/  --txt_dir=./python_proc/txt/";
                                writeBATFile(mystr);
                            
                            Cmd nb = new Cmd();
                                //nb.RunCmd("E: \n cd zxtdeeplearning \n cd crack \n cd matlab_proc \n s.bat");
                                //nb.RunCmd("E: \n cd zxtdeeplearning \n cd crack \n cd model \n python predict.py -i E:\\zxtdeeplearning\\crack\\matlab_proc\\temp\\predictions\\images -o E:\\zxtdeeplearning\\crack\\matlab_proc\\temp\\0\\images\\output.jpg " );
                                //nb.RunCmd("s.bat");
                                Process proc = new Process();
                                string targetDir = string.Format(@"C:\Users\zhang\Desktop\pycharm\crack\matlab_proc\");

                                proc.StartInfo.WorkingDirectory = targetDir;
                                proc.StartInfo.FileName = "single.bat";
                                proc.StartInfo.Arguments = string.Format("10");
                                proc.Start();
                                proc.WaitForExit();
                                //while (true)
                                //{
                                //    DirectoryInfo di = new DirectoryInfo(@"E:\zxtdeeplearning\crack\python_proc\deeplab\");
                                //    a = GetFileNum(di);
                                //    if (a == ere)
                                //    {
                                //        a = 0;
                                //        break;
                                //    }
                                //    System.Threading.Thread.Sleep(2000);
                                //}


                                

                            }
                            StreamReader rd = File.OpenText(@"C:\Users\zhang\Desktop\pycharm\crack\python_proc\txt\crack_info.txt");
                            string s = rd.ReadToEnd();
                            string[] ss = s.Split(' ');

                            int point = 0;

                            num = (ss.Length - 1) / 5;
                            for (int i = 0; i < num; i++)
                            {
                                a1[i] = float.Parse(ss[point++]);
                                a2[i] = float.Parse(ss[point++]);
                                a3[i] = float.Parse(ss[point++]);
                                a4[i] = float.Parse(ss[point++]);

                                a5[i] = float.Parse(ss[point++]);
                            }
                            rd.Close();
                            System.IO.File.WriteAllText(@"C:\Users\zhang\Desktop\pycharm\crack\python_proc\txt\crack_info.txt", string.Empty);
                                                        
                                filenames = "C:\\Users\\zhang\\Desktop\\pycharm\\crack\\python_proc\\concat\\" + (qwe + 1).ToString() + ".png";
                            

                            
                                if (filenames != null)
                                {
                                    string url = filenames;
                                    rerenameFiles( "C:\\Users\\zhang\\Desktop\\pycharm\\crack\\python_proc\\concat\\",url);
                                    byte[] dd = GetContent(url);
                                    string er = "";
                                    for (int t = 0; t < num; t++)
                                    {

                                        er += "insert into crack_info values('" + id + "'," + (pic_num[0]+qwe).ToString() + "," + a2[t].ToString() + "," + a3[t].ToString() + ",0," + a4[t].ToString() + "," + a5[t].ToString() + ",null,@Image)";

                                    }
                                    try
                                    {
                                        SqlConnection con = new SqlConnection("server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~");
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand(er, con);
                                        cmd.Parameters.Add("@Image", SqlDbType.Image);
                                        cmd.Parameters["@Image"].Value = dd;
                                        cmd.ExecuteNonQuery();

                                        con.Close();


                                    }
                                    catch
                                    {
                                        MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    }
                                
                            }

                        //清空concat single
                         DeleteFolder1("C://Users//zhang//Desktop//pycharm//crack//python_proc//concat//");
                        DeleteFolder1("C://Users//zhang//Desktop//pycharm//crack//matlab_proc//single//");
                        }
                    }


                    //在此将auto_detect清空
                    SqlCommand nbcommand = new SqlCommand("delete from auto_detect where id='" + id + "'", myconn);
                    myconn.Open();
                    {
                        try
                        {
                            nbcommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    myconn.Close();
                }
               
                
            
            if (i == 40)
            {


                string sqlq = "server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~";
                SqlConnection myconnq = new SqlConnection(sqlq);
                SqlDataAdapter myadapterq = new SqlDataAdapter("select * from non_auto ", myconnq);
                DataTable mytableq = new DataTable();
                myadapterq.Fill(mytableq);
                
                if (mytableq.Rows.Count != 0)
                {

                    id = mytableq.Rows[0].ItemArray[0].ToString();
                    SqlDataAdapter myadapterqq = new SqlDataAdapter("select id,pic_num,count(point_start_x) from non_auto where id='" + id + "' group by id,pic_num", myconnq);
                    DataTable mytableqq = new DataTable();
                    myadapterqq.Fill(mytableqq);
                    int count = mytableqq.Rows.Count;
                    int[] pic_num = new int[count];
                    for (int f = 0; f < count; f++)
                    {
                        pic_num[f] = int.Parse(mytableqq.Rows[f].ItemArray[1].ToString());
                    }
                    for (int g = 0; g < count; g++)
                    {
                        string mystring = "select pic from pic where id='" + id + "' and pic_num=" + pic_num[g];

                        SqlDataAdapter myadapter4 = new SqlDataAdapter(mystring, myconnq);
                        DataTable mytable4 = new DataTable();
                        myadapter4.Fill(mytable4);
                        if (mytable4.Rows.Count == 1)
                        {
                            MemoryStream myPic = null;

                            byte[] mydata;


                            mydata = (byte[])(mytable4.Rows[0].ItemArray[0]);
                            myPic = new MemoryStream(mydata);

                            System.Drawing.Image img = System.Drawing.Image.FromStream(myPic);
                            img.Save("C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\manual\\" + (g + 1).ToString() + ".png");
                        }
                        else
                        {

                            MemoryStream myPic = null;

                            byte[] mydata;


                            mydata = (byte[])(mytable4.Rows[g].ItemArray[0]);
                            myPic = new MemoryStream(mydata);

                            System.Drawing.Image img = System.Drawing.Image.FromStream(myPic);
                            img.Save("C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\manual\\" + (g + 1).ToString() + ".png");
                        }
                    }

                    //在此调出操作的模式

                

                    for (int h = pic_num[0]; h < pic_num[0]+ count; h++)
                    {
                        SqlDataAdapter myadapter2 = new SqlDataAdapter("select * from non_auto where id='" + id + "' and pic_num=" + (h ).ToString(), myconnq);
                        DataTable mytable2 = new DataTable();
                        myadapter2.Fill(mytable2);
                        int snum = mytable2.Rows.Count;
                        int[] point_start_x = new int[20];
                        int[] point_start_y = new int[20];
                        int[] point_end_x = new int[20];
                        int[] point_end_y = new int[20];
                        for (int sp = 0; sp < snum; sp++)
                        {
                            point_start_x[sp] = int.Parse(mytable2.Rows[sp].ItemArray[2].ToString());
                            point_start_y[sp] = int.Parse(mytable2.Rows[sp].ItemArray[3].ToString());
                            point_end_x[sp] = int.Parse(mytable2.Rows[sp].ItemArray[4].ToString());
                            point_end_y[sp] = int.Parse(mytable2.Rows[sp].ItemArray[5].ToString());
                        }
                        string filePath = "C:\\Users\\zhang\\Desktop\\pycharm\\crack\\matlab_proc\\non_auto_txt\\" + (h ).ToString() + ".txt";
                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        //获得字节数组
                        StreamWriter sw = new StreamWriter(fs);

                        for (int l = 0; l < snum; l++)
                        {
                            int output1,output2,output3,output4;
                                output1 = Convert.ToInt32(point_start_x[l]);
                            output2 = Convert.ToInt32(point_start_y[l]);
                            output3 = Convert.ToInt32(point_end_x[l]);
                            output4 = Convert.ToInt32(point_end_y[l]);
                            sw.Write(output1 + " ");
                            sw.Write(output2 + " ");
                            sw.Write(output3 + " ");
                            sw.Write(output4 + " ");
                            sw.Write(h + " ");

                            sw.WriteLine();
                        }     
                        sw.Flush();             
                        sw.Close();
                        fs.Close();
                              
                    }



                    if (true)
                    {

                        // string mystr;
                        //mystr = "call activate pythontf \n E: \n cd zxtdeeplearning \n cd crack \n cd model \n python fcnn_predict.py --img_dir='E:\\zxtdeeplearning\\crack\\matlab_proc\\original_pic\\1.png'  --out_dir='E:\\zxtdeeplearning\\crack\\matlab_proc\\temp\\'    ";
                        //writeBATFile(mystr);
                        Cmd nb = new Cmd();
                        //nb.RunCmd("E: \n cd zxtdeeplearning \n cd crack \n cd matlab_proc \n s.bat");
                        //nb.RunCmd("E: \n cd zxtdeeplearning \n cd crack \n cd model \n python predict.py -i E:\\zxtdeeplearning\\crack\\matlab_proc\\temp\\predictions\\images -o E:\\zxtdeeplearning\\crack\\matlab_proc\\temp\\0\\images\\output.jpg " );
                        //nb.RunCmd("s.bat");
                        Process proc = new Process();
                        string targetDir = string.Format(@"C:\Users\zhang\Desktop\pycharm\crack\matlab_proc\");

                        proc.StartInfo.WorkingDirectory = targetDir;
                        proc.StartInfo.FileName = "n.bat";                                 //n.bat还没有写
                        proc.StartInfo.Arguments = string.Format("10");

                        proc.Start();
                        proc.WaitForExit();
                        while (true)
                        {
                            DirectoryInfo di = new DirectoryInfo(@"C:\Users\zhang\Desktop\pycharm\crack\python_proc\concat2\");
                            a = GetFileNum(di);
                            if (a == count)
                            {
                                a = 0;
                                break;
                            }
                            System.Threading.Thread.Sleep(2000);
                        }
                       

                     
                        

                    }
                    StreamReader rd = File.OpenText(@"C:\Users\zhang\Desktop\pycharm\crack\python_proc\txt\crack_info.txt");
                    string s = rd.ReadToEnd();
                    string[] ss = s.Split(' ');

                    int point = 0;

                    num = (ss.Length - 1) / 5;
                    for (int i = 0; i < num; i++)
                    {
                        a1[i] = float.Parse(ss[point++]);
                        a2[i] = float.Parse(ss[point++]);
                        a3[i] = float.Parse(ss[point++]);
                        a4[i] = float.Parse(ss[point++]);

                        a5[i] = float.Parse(ss[point++]);
                    }
                    rd.Close();
                    System.IO.File.WriteAllText(@"C:\Users\zhang\Desktop\pycharm\crack\python_proc\txt\crack_info.txt", string.Empty);

                    
                    //在此将non_auto清空
                    SqlCommand nbcommand = new SqlCommand("delete from non_auto where id='" + id + "'", myconnq);
                    myconnq.Open();
                    {
                        try
                        {
                            nbcommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    myconnq.Close();




                    int u = 0;
                        filenames = "C:\\Users\\zhang\\Desktop\\pycharm\\crack\\python_proc\\concat2\\" + (u + 1).ToString() + ".png";
                    
                    for (int i = 0; i < 100; i++)
                    {
                        if (filenames != null)
                        {
                            string url = filenames;
                            byte[] dd = GetContent(url);
                            string er = "";
                            for (int t = 0; t < num; t++)
                            {

                                er += "insert into crack_info values('" + id + "'," + pic_num[0].ToString() + "," + a2[t].ToString() + "," + a3[t].ToString() + ",0," + a5[t].ToString() + "," + a4[t].ToString() + ",null,@Image)";

                            }
                            try
                            {
                                SqlConnection con = new SqlConnection("server= 202.120.167.146;database=crack;uid=sa;pwd=cps640818~");
                                con.Open();
                                SqlCommand cmd = new SqlCommand(er, con);
                                cmd.Parameters.Add("@Image", SqlDbType.Image);
                                cmd.Parameters["@Image"].Value = dd;
                                cmd.ExecuteNonQuery();

                                con.Close();


                            }
                            catch
                            {
                                MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                    }


                    //清空图片
                }

            }
            i += 1;
            if (i == 80)
            {
                i = 0;
            }
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
        public static int GetFileNum(DirectoryInfo info)
        {
            int a;
            //获取该路径下的所有文件的列表
            FileInfo[] fileInfo = info.GetFiles();
            a = fileInfo.Length;
            return a;
        }
        
    }
}
