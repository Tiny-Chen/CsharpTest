using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 复习大小写转换
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 4.	编写一个函数,接收一个字符串,把用户输入的字符串中的第一个字母转换成小写然后返回(命名规范  骆驼命名)   
             * name       s.SubString(0,1)      s.SubString(1);
                5.	编写一个函数,接收一个字符串,把用户输入的字符串中的第一个字母转换成大小然后返回（命名规范  帕斯卡）

             * 
             */
            Console.WriteLine("请输入一个字符串");
            string presson =GetString(Console.ReadLine());
            Console.WriteLine(presson);
            Console.ReadKey();
        }

        static string GetString(string n)
        {
            //改小写
            string name = n.Substring(0, 1).ToLower();
            return name+n.Substring(1);
        }
    }
}
