using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socked学习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //出现异常处理
            try
            {
                //点击监听的时候，在服务端创建一个监听的socket
                Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //IP地址，监听所有的地址
                IPAddress ip = IPAddress.Any;
                //创建端口号（设置面板上的端口号），包含IP地址
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(PointNumber.Text));
                //监听端口
                socketWatch.Bind(point);
                ShowMsg("监听成功");
                //设置队列数量，就是最多是10台，多出的需要等待
                socketWatch.Listen(10);
                //创建监听线程
                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(socketWatch);
            }
            catch 
            {
               
            }
        }

        /// <summary>
        /// 显示信息的窗口
        /// </summary>
        /// <param name="str"></param>
        private void ShowMsg(string str)
        {
            //这里用的是追加，而不是text，因为追加不会覆盖掉上一次的记录
            LogText.AppendText(str+"\r\n");
        }

        /// <summary>
        /// 建立健值对字典，用来存储连接进来的客户端的IP地址端口号和与其通信的socket
        /// </summary>
        Dictionary<string,Socket> dicsocket = new Dictionary<string, Socket>();


        /// <summary>
        /// 等待客户端连接，并创建与其建立通信的socket
        /// </summary>
        private Socket socketSend;
        void Listen(object o)//因为线程启动带参方法，必须是object类型的
        {
            Socket socketSwitch = o as Socket;//转换
            //等待客户连接，并创建客户端通信的socket,不停的监听（Accept）
            while (true)
            {
                try
                {
                    socketSend = socketSwitch.Accept();
                    //用字典存储连接进来的客户端的IP地址端口号和与其通信的socket
                    dicsocket.Add(socketSend.RemoteEndPoint.ToString(),socketSend);
                    //将IP地址和端口号存入下拉列表中
                    cboUser.Items.Add(socketSend.RemoteEndPoint.ToString());

                    //RemoteEndPoint： 拿到远程计算机的IP和端口，输出连接成功
                    ShowMsg(socketSend.RemoteEndPoint.ToString() + ":" + "连接成功");       
                    //开启一个新线程，接收来自客户端的消息
                    Thread th = new Thread(Receive);
                    th.IsBackground = true;
                    th.Start();
                }
                catch
                {
                  //不用提示用户出现异常
                }
            }
        }

        /// <summary>
        ///  //服务器端不停接收来自客户端的消息（Receive）
        /// </summary>
        private void Receive()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 2];                                          //建立2M的字节数组，用来接收消息
                    int r = socketSend.Receive(buffer);                                                    //实际接收到的字节数
                    if (r == 0)
                    {
                        ShowMsg(socketSend.RemoteEndPoint.ToString() + ":" + "客户端断开连接");
                        break;                                                                                          //判断是否下线，如果实际接收到的是0个字符，那么下线了，没有这一步会造成死循环
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, r);                             //转换成输出的文本类型
                    ShowMsg(socketSend.RemoteEndPoint.ToString() + ":" + str);            //显示出来
                }
                catch 
                {
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程检查访问
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /*
         * 通过协议来标识发送的是文本还是文件或其他，就是在转换后发送的二进制字符前增加一个标识
         * 如0是文本，1是文件，2是震动等
         * 客户端接收时，先判断是什么类型，再进行处理
         * */
        /// <summary>
        ///给客户端发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendMsn_Click(object sender, EventArgs e)
        {
            try
            {
                //获取发送的文本
                string str = texMsg.Text.Trim();
                //转码二进制
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);

                //增加标识位--------------------------------------------------------------
                List<byte>list = new List<byte>();
                //标记为文本
                list.Add(0);
                //添加转换后的二进制进来
                list.AddRange(buffer);
                //再转换成数组
                byte[] newBuffer = list.ToArray();

                //从下拉列表中选择对应的IP进行发送消息
                //socketSend.Send(buffer);
                string ip = cboUser.SelectedItem.ToString();
                //字典中对应健的通信socket进行发送消息
                dicsocket[ip].Send(newBuffer);
                //清空文本域
                texMsg.Text = "";
                //添加显示记录
                ShowMsg("我"+ ":" + str);
            }
            catch 
            {
            }
           

        }

        /// <summary>
        /// 选择发送的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeletFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\Tiny\Desktop";
            ofd.Title = "请选择发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();

            //把路径给这个文本框
            opfBox.Text = ofd.FileName;

        }

        /// <summary>
        /// 发送文件，这里文件都是小文件，如果是大文件涉及到断点续传，把大文件切割成很多的小文件再发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendFile_Click(object sender, EventArgs e)
        {
            try
            {
                //获得路径
                string path = opfBox.Text;
                //创建文件流
                using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    //创建字节数组
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    //实际长度
                    int r = fsRead.Read(buffer, 0, buffer.Length);

                    //添加标识位
                    List<byte> list = new List<byte>();
                    list.Add(1);
                    list.AddRange(buffer);
                    byte[] newBuffer = list.ToArray();

                    //根据选择的IP进行发送,并限定发送字节的长度
                    dicsocket[cboUser.SelectedItem.ToString()].Send(newBuffer, 0, r + 1, SocketFlags.None);
                }
            }
            catch 
            {
               
            }
          
        }

        /// <summary>
        /// 发送震动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZhenDong_Click(object sender, EventArgs e)
        {
            try
            {
                //就是发送个标识符过去，让客户端根据标识符执行功能就可以
                byte[] buffer = new byte[1];
                buffer[0] = 2;
                dicsocket[socketSend.RemoteEndPoint.ToString()].Send(buffer);
            }
            catch 
            {
              
            }
          
        }
    }
}
