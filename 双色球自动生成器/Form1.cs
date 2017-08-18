using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 双色球自动生成器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random ran = new Random();
        private bool b = false;
        private bool c = false;

        private void button1_Click(object sender, EventArgs e)
        {
            //创建线程
            Thread One = new Thread(ReadBall);
            if (b == false)
            {
                b = true;
                button1.Text = "停止";
                One.IsBackground = true;
                One.Start();
            }
            else
            {
                b = false;
                button1.Text = "开始";
            }
        }
        //循环随机红球
        private void ReadBall()
        {
            while (b)
            {
                label1.Text = ran.Next(1, 34).ToString();
                label2.Text = ran.Next(1, 34).ToString();
                label3.Text = ran.Next(1, 34).ToString();
                label4.Text = ran.Next(1, 34).ToString();
                label5.Text = ran.Next(1, 34).ToString();
            }
            
        }
        //循环随机蓝球
        private void BludBall()
        {
            while (c)
            {
                
                label6.Text = ran.Next(1, 17).ToString();
            }

        }
        //取消防跨线程访问
        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程访问检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        //按钮2，开始执行蓝球
        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(BludBall);
            if (c==false)
            {
                c = true;
                button2.Text = "停止";
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                c = false;
                button2.Text = "开始";
            }
        }
    }
}
