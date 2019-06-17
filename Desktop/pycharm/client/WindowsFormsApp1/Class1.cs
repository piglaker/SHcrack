using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    class Class1
    {
        static public int state = 0;
        static public string[] filenames=new string[100];
        static public int key = 0;
        static public int point = 0;
        static public int focal = 0;
        static public int semantic = 0;
        static public int matlab = 0;
        static public int focal_passion = 0;
        static public int deep_passion = 0;
        static public int amount_accuracy = 0;
        static public string id;
        static public string psww;
        static public int min = 0;
        static public int max = 0;
        static public Point[] x=new Point[1000];
        static public Point[] y = new Point[1000];
        static public Dictionary<int, int> pos = new Dictionary<int, int>();
        static public int index = 0;
    }
}
