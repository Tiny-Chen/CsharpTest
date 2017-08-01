using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进程
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //获取系统运行的所有进程，保存到数组中
            Process[] pro = Process.GetProcesses();
            foreach (var item in pro)
            {
                //杀死所有进程
                //item.Kill();
                Console.WriteLine(item);
            }
            Console.ReadKey();
            */

            /*
            //通过进程打开应用程序
            Process.Start("calc");//计算器
            Process.Start("mspaint");//画图工具
            Process.Start("notepad");//记事本
            */


            //通过进程打开文件
            //1、创建实例，获取文件路径info信息
            ProcessStartInfo p = new ProcessStartInfo(@"C:\Users\Tiny\Desktop\消防总局局长汇报PPT.pdf");
            //创建进程实例
            Process pro = new Process();
            //把需创建的文件信息给进程实例
            pro.StartInfo=p;
            //打开文件
            pro.Start();

            Console.ReadKey();
        }
    }
}
