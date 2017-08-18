using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 客户端
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //创建通信的Sockete(网络，流，协议)
        Socket socketsend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //IP地址
            IPAddress ip = IPAddress.Parse(IpNumber.Text);
            //端口号：包含IP地址的
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(PointNumber.Text));
            //连接
            socketsend.Connect(point);
            ShowMsg("连接成功");
            //接收消息,开启新线程
            Thread th = new Thread(Receive);
            th.IsBackground = true;
            th.Start();

        }

        /// <summary>
        /// 不停接收服务器的消息，接收到二进制字符后，选对第1位标识进行判断 
        /// </summary>
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    int r = socketsend.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    //如果是文本
                    if (buffer[0] == 0)
                    {
                        //这里要注意，读取要从第1位开始读，因为第0位是标识，实际长度要减去0位
                        string str = Encoding.UTF8.GetString(buffer, 1, r-1);
                        ShowMsg(socketsend.RemoteEndPoint.ToString() + ":" + str);
                    }
                    //如果是文件
                    else if (buffer[0] == 1)
                    {
                        //创建打开窗口
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.InitialDirectory = @"C:\Users\Tiny\Desktop";
                        sfd.Title = "请选择保存的路径";
                        sfd.Filter = "所有文件|*.*";
                        sfd.ShowDialog(this);//-------------------这里要加this，不然弹不出来

                        string path = sfd.FileName;
                        using (FileStream fsWrite = new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write))
                        {
                            fsWrite.Write(buffer,0,r-1);
                        }
                        MessageBox.Show("保存成功");

                    }
                    //如果是震动
                    else if (buffer[0] == 2)
                    {
                     ZD();   
                    }

                   
                }
            }
            catch
            {
               
            }
           
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="str"></param>
        private void ShowMsg(string str)
        {
            //这里用的是追加，而不是text，因为追加不会覆盖掉上一次的记录
            LogText.AppendText(str + "\r\n");
        }


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendMsn_Click(object sender, EventArgs e)
        {
            try
            {
                //获取发送的字符
                string str = texMsg.Text.Trim();
                //转码
                byte[] buttbytes = System.Text.Encoding.UTF8.GetBytes(str);
                //发送
                socketsend.Send(buttbytes);
                //添加记录
                ShowMsg("我"+ ":" + str);
                //发送后清空发送的区域
                texMsg.Text = "";
            }
            catch
            {
            }
        }

        /// <summary>
        /// 震动的方法
        /// </summary>
        void ZD()
        {
            //震动就是让窗口发生位移，让人感觉上是震动
            for (int i = 0; i < 1000; i++)
            {
                this.Location = new Point(300,300);
                this.Location = new Point(320,320);
                this.Location = new Point(300, 300);
                this.Location = new Point(280, 280);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
