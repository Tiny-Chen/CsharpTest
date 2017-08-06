using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 播放器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //保存文件全路径的列表
        List<string> ListBoxSound = new List<string>();
        //创建播放器
        SoundPlayer sp = new SoundPlayer();

        private void button1_Click(object sender, EventArgs e)
        {
            //创建打开窗口对象
            OpenFileDialog ofd = new OpenFileDialog();
            //窗口标题
            ofd.Title = "请选择打开的文件";
            //打开的路径
            ofd.InitialDirectory = @"D:\music\2003.林海 -《琵琶相》.[FLAC]\2003.林海 -《琵琶相》.[FLAC]";
            //设置多选
            ofd.Multiselect = true;
            //文件类型
            ofd.Filter = "音乐文件|*.flac|所有文件|*.*";
            //显示窗口
            ofd.ShowDialog();
            //a获得路径字符串
            string[] path = ofd.FileNames;
            //获取文件名,添加到列表
            for (int i = 0; i < path.Length; i++)
            {
                //添加文件名BOX列表中
                listBox1.Items.Add(Path.GetFileName(path[i]));
                //添加路径到列表
                ListBoxSound.Add(path[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 双击播放文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
           
            //双击播放的音乐，其序号等于列表中的序号,全路径
            sp.SoundLocation = ListBoxSound[listBox1.SelectedIndex];
            //注意，播放的类型是WAV的
            sp.Play();

        }
        //上一曲
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count==0)
            {
                return;
            }
            //获得当前选择的序号
            int index = listBox1.SelectedIndex;
            //上一曲--
            index--;
            if (index == 0) index = listBox1.Items.Count;
            //把切换后的序号给当前选中
            listBox1.SelectedIndex = index;

            sp.SoundLocation = ListBoxSound[index];
            sp.Play();
        }
        //下一曲
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) return;

            int index = listBox1.SelectedIndex;
            index++;
            if (index == listBox1.Items.Count) index = 0;

            listBox1.SelectedIndex = index;

            sp.SoundLocation = ListBoxSound[index];
            sp.Play();
        }
    }
}
