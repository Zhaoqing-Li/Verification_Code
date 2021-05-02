using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 绘制验证码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            paint();
        }

        Random number = new Random();
        string s = "", answer = "";        
        string[] font = { "Arial", "Yu Gothic UI", "宋体", "等线", "仿宋", "黑体", "楷体", "微软雅黑", "新宋体", "Bahnschrift", "Calibri", "Cambria", "Candara", "Consolas", "Comic Sans MS", "Segoe Script", "Impact", "Segoe Script" };
        Color[] color = { Color.Black, Color.Blue, Color.Brown, Color.Gold, Color.Gray, Color.Green, Color.Orange, Color.Pink, Color.Purple, Color.Red, Color.Silver, Color.Yellow };
        Pen pen = new Pen(Color.Gray, 1);

        void paint()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < 5; i++)
            { s = s + number.Next(0, 10); }
            Graphics g = Graphics.FromImage(bitmap);
            for (int i = 0; i < 5; i++)                                      
            { g.DrawString(s[i].ToString(), new Font(font[number.Next(0, 17)], 30, FontStyle.Bold), new SolidBrush(color[number.Next(0, 5)]), new Point(20 + 30 * i, number.Next(0, 10))); }            
            for (int i = 1; i < pictureBox1.Width; i++)
            {
                for (int j = 1; j < pictureBox1.Height; j++)
                {
                    if (number.Next(1, 5) == 1)
                    { bitmap.SetPixel(i, j, Color.Gray); }
                    if (number.Next(1, 500) == 2)
                    { g.DrawLine(pen, i, j, number.Next(1, pictureBox1.Width), number.Next(1, pictureBox1.Height)); }
                }
            }
            pictureBox1.Image = bitmap;
            answer = s;
            s = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {            
            paint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("没填啊");
            }
            else
            {  
                if (textBox1.Text == answer) { MessageBox.Show("对了哦"); }
                if (textBox1.Text != answer) { MessageBox.Show("不对呢"); }                 
            }            
        }
    }
}
