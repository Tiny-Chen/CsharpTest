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

namespace 线程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Thread th;
        //按钮事件,创建线程
        private void button1_Click(object sender, EventArgs e)
        {
            //Test();//运行后会发现，窗体假死
            //单线程：
            //每运行1个程序 ，计算机都会分给1个主线程去执行，主线程结束后程序 就结束了
            //主线程操作窗体，绘制窗体，如果增加了其他工作，那么原来的工作就会假死，需等其他工作先完成了才会执行正常

            //多线程
            //创建1个线程去做这个事
            th = new Thread(Test);
            //标记线程准备完毕，注意不是立即开始，这是告诉CPU这个线程准备好了，可以随时执行，具体执行时间由CPU决定
            //前台线程：所有前台线程关闭，程序才完全关闭（默认）
            //后台线程：只要所有前台线程结束，后台线程自动关闭
            //设置为后台线程
            th.IsBackground = true;
            th.Start();

            //线程睡眠，以毫秒为单位
            Thread.Sleep(3000);

            //终止后不能再启动
            //th.Abort();
            //th.Start();这里会报异常
            
           
        }

        //测试方法
        private void Test()
        {
            //for (int i = 0; i < 100000; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //如果要跨线程访问,必须解除跨线程访问限制,因为.net不允许跨线程访问。，在窗体内设计，主线程是操作窗体的
            for (int i = 0; i < 100000; i++)
            {
                textBox1.Text = i.ToString();
            }
        }

        //主线程是操作窗体的，在里面设计取消跨线程访问的检查
        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程的访问
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //判断新线程是否关闭，如果没关闭会抛异常，因为当关闭窗体的时候，主线程结束了，新线程还在访问textBox.而这个BOX已经随主线程关闭被释放资源 了
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //判断新建的线程是否关闭，如果没有手动关闭
            if(th!=null) th.Abort();//注意，Abort终止后是不能重新运行这个线程了的，即是内存里已经没有这个线程了，不能重新start
        }
    }
}
