using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public int sequence = 1;
        private Point m_ptStart = new Point(0, 0);
        private Point m_ptEnd = new Point(0, 0);
        // true: MouseUp or false: MouseMove 
        Dictionary<Point, Point> dicPoints = new Dictionary<Point, Point>();
        LinkList<Dictionary<Point, Point>, int> link = new LinkList<Dictionary<Point, Point>, int>();
        private bool m_bMouseDown = false;
        public static int max = Class1.filenames.Count();
        public Form5()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1200;
            this.Height = 750;
            pictureBox1.Width = 1200;
            pictureBox1.Height = 750;
            button2.Location =new Point(815, 606);
            button2.Size = new Size(87, 54);
            button1.Location = new Point(1070, 606);
            button1.Size = new Size(91, 54);
            pictureBox2.Location = new Point(97, 266);
            pictureBox2.Size = new Size(657, 383);
            button3.Size = new Size(185,66);
            button3.Location = new Point(623,197);
            button4.Location = new Point(125,197);
            button4.Size = new Size(185,66);
            button5.Location = new Point(902, 606);
            button5.Size = new Size(80, 54);
            button6.Location = new Point(982, 606);
            button6.Size = new Size(88, 54);
            pictureBox3.Location = new Point(97,266);
            pictureBox3.Size = new Size(657,394);
            label1.BackColor = Color.FromArgb(64,72,84);
            label1.Location = new Point(872,292);
            pictureBox3.Image = Image.FromFile(Class1.filenames[0]);
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                if (Class1.filenames[i] == null)
                {
                    break;
                }
                    count += 1;
                
            }
            if (sequence < count)
            {
               
                sequence += 1;
                dicPoints =copy(link,sequence);
                pictureBox3.Refresh();

                pictureBox3.Image = Image.FromFile(Class1.filenames[sequence - 1]);
                pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
                foreach (var item in link.Find(sequence))
                {
                    int state = 0;
                    foreach (var t in dicPoints)
                    {
                        if (t.Key == item.Key && t.Value == item.Value)
                        {
                            state = 1;
                        }

                    }
                    if (state == 0)
                    {
                        dicPoints.Add(item.Key, item.Value);
                    }
                }





            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = 0;
            Node<Dictionary<Point, Point>, int> link2 = new Node<Dictionary<Point, Point>, int>();
            link2 = link.Head;
            
            while (link2 != null)
            { 
                    foreach (var item in link2.Data)
                    {
                        Class1.x[num] = item.Key;
                        Class1.y[num] = item.Value;
                        num++;
                    }
                    Class1.pos.Add(link2.data,link2.Data.Count);
                    link2 = link2.Next;
            }
               
            
            Form6 f6 = new Form6();
            f6.Show();
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
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

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (!m_bMouseDown)
            {
                m_ptStart = new Point(e.X, e.Y);
                m_ptEnd = new Point(e.X, e.Y);
            }
            m_bMouseDown = !m_bMouseDown;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            m_ptEnd = new Point(e.X, e.Y);
            this.pictureBox3.Refresh();
        }
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)

            {

                return;

            }



            if (m_ptStart.X >= 0 && m_ptEnd.X >= 0

                 && m_ptStart.Y >= 0 && m_ptEnd.Y >= 0

                 && m_ptStart.X <= 657 && m_ptEnd.X <= 657

                 && m_ptStart.Y <= 394 && m_ptEnd.Y <= 394)

            {

                m_ptEnd = new Point(e.X, e.Y);

                m_bMouseDown = !m_bMouseDown;
  
                dicPoints.Add(m_ptStart, m_ptEnd);
            }

            else

            {

                m_ptEnd = m_ptStart;

                m_bMouseDown = !m_bMouseDown;

                this.pictureBox3.Refresh();

            }
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(Color.Orange,3);

            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

            //pen.Width = 2;

            if (m_bMouseDown)

            {

                //实时的画矩形

                Graphics g = e.Graphics;

                g.DrawRectangle(pen, m_ptStart.X, m_ptStart.Y, m_ptEnd.X - m_ptStart.X, m_ptEnd.Y - m_ptStart.Y);

            }



            //实时的画之前已经画好的矩形
            if (dicPoints != null)
            {
                foreach (var item in dicPoints)
                {
                    Point p1 = item.Key;
                    Point p2 = item.Value;
                    e.Graphics.DrawRectangle(pen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                }
                pen.Dispose();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dicPoints.Clear();
            pictureBox3.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (link.Find(sequence) == null||link.Head==null)
            {
                link.Append(dicPoints, sequence);
                pictureBox3.Refresh();
            }
            else
            { 
                Dictionary<Point, Point> df = new Dictionary<Point, Point>();
                foreach (var item in link.Find(sequence))
                {
                    df.Add(item.Key,item.Value);
                }
                link.Delete(sequence);
                foreach (var item in dicPoints)
                {
                    int state = 0;
                    foreach (var it in df)
                    {
                        if (item.Key == it.Key && item.Value == it.Value)
                        {
                            state = 1;
                        }
                    }
                    if (state == 0)
                    {
                        df.Add(item.Key,item.Value);
                    }
                }
                link.Append(df,sequence);
                
            }
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                if (Class1.filenames[i] == null)
                {
                    break;
                }
                count += 1;

            }
            if (sequence <count)
            {
                sequence += 1;
                pictureBox3.Refresh();
                pictureBox3.Image = Image.FromFile(Class1.filenames[sequence - 1]);
                pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
                foreach (var item in link.Find(sequence))
                {
                    Point x = new Point();
                    Point y = new Point();
                    x = item.Key;
                    y = item.Value;
                    dicPoints.Add(x,y);
                }
                dicPoints = copy(link, sequence);
            }
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (sequence > 1)
            {
                sequence -= 1;
                dicPoints = copy(link, sequence);
                pictureBox3.Image = Image.FromFile(Class1.filenames[sequence - 1]);
                pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
                foreach (var item in link.Find(sequence))
                {
                    int state = 0;
                    foreach (var t in dicPoints)
                    {
                        if (t.Key == item.Key && t.Value == item.Value)
                        {
                            state = 1;
                        }

                    }
                    if (state == 0)
                    {
                        dicPoints.Add(item.Key, item.Value);
                    }
                }

            }
        }
        public class Node<T1,T2>
        {
            public T1 Data { set; get; }    //数据域,当前结点数据
            public T2 data { set; get; }
            public Node<T1,T2> Next { set; get; }    //位置域,下一个结点地址

            public Node(T1 item,T2 item2)
            {
                this.Data = item;
                this.data = item2;
                this.Next = null;
            }
            public Node()
            {
                this.Data = default(T1);
                this.data = default(T2);
                this.Next = null;
            }
        }
        public class LinkList <T1,T2>
        {
            public Node<Dictionary<Point, Point>, int> Head { set; get; } //单链表头

            //构造
            public LinkList()
            {
                Head = null;
            }
            /// <summary>
            /// 增加新元素到单链表末尾
            /// </summary>
            public void Append(Dictionary<Point, Point> item,int item2)
            {
                Node<Dictionary<Point, Point>, int> foot = new Node<Dictionary<Point, Point>, int>(item,item2);
                Node<Dictionary<Point, Point>, int> A = new Node<Dictionary<Point, Point>, int>();
                if (Head==null)
                {
                    Head = foot;
                    return;
                }
                A = Head;
                while (A.Next != null)
                {
                    A = A.Next;
                }
                A.Next = foot;
            }
            public void Delete(int i)
            {
                Node<Dictionary<Point, Point>, int> A = new Node<Dictionary<Point, Point>, int>();
                if (i == 1)   //删除头
                {
                    A = Head;
                    Head = Head.Next;
                    return;
                }
                Node<Dictionary<Point, Point>, int> B = new Node<Dictionary<Point, Point>,int>();
                B = Head;
                int j = 1;
                while (B.Next != null && i != B.data)
                {
                    A = B;
                    B = B.Next;
                    j++;
                }
                if (B.data == i)
                {
                    A.Next = B.Next;
                }
            }
            public Dictionary<Point,Point> Find(int x)
            {
                Dictionary<Point, Point> a = new Dictionary<Point, Point>();
                Node< Dictionary < Point, Point >,int> A = new Node<Dictionary<Point, Point>, int>();
                Node<Dictionary<Point, Point>, int> B = new Node<Dictionary<Point, Point>, int>();
                B = Head;
                
                if (B == null)
                {
                    Dictionary<Point, Point> v = new Dictionary<Point, Point>();
                    return v;
                }
                while (B.Next != null && B.data != x)
                {
                    A = B;
                    B = B.Next;
                    
                }
                if (B.data == x)
                {
                    a =B.Data;
                }
                return a;
            }
            
        }
        public Dictionary<Point, Point> copy( LinkList<Dictionary<Point, Point>, int> b, int x)
        {
            Dictionary<Point, Point> dfg = new Dictionary<Point, Point>();
            if (b.Find(x) == null)
            {
                return dfg;
            }
            else
            {
                dfg = b.Find(x);
                return dfg;
            }
            
        }
    }
    
}
