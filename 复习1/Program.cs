using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 复习1
{
    class Program
    {
        /*
         * 1.	编写一段程序，运行时向用户提问“你考了多少分？（0~100）”
         * 接受输入后判断其等级并显示出来。
         * 判断依据如下：等级={优 （90~100分）；良 （80~89分）；中 （60~69分）；差 （0~59分）；}
         *
         */
        static void Main(string[] args)
        {
           
            Console.WriteLine("请输入你的成绩");
            int NewNumber = Convert.ToInt32(Console.ReadLine());
            string levie =ShowAchievement(NewNumber);
            Console.WriteLine(levie);
            Console.ReadKey();
        }

       static string ShowAchievement(int number)
       {
           string levie;
            if (number<=100&number>=90)
            {
                levie = "你的成绩为：优";
            }
            else if (number <= 89 & number >= 80)
            {
                levie = "你的成绩为：良";
            }
            else if (number <= 79 & number >= 70)
            {
                levie = "你的成绩为：中";
            }
            else if (number<=69&number>=60)
            {
                levie = "你的成绩为：合格";
            }
            else if(number<60&number>0)
            {
                levie = "你的成绩不合格";
            }
            else
            {
                Console.WriteLine("你的输入有误，请重新输入");
                int NewNumber = Convert.ToInt32(Console.ReadLine());
                levie =ShowAchievement(NewNumber);
            }
           return levie;
       }
    }
}
