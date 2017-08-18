using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 复习数组
{
    class Program
    {
        //3.	定义长度50的数组,随机给数组赋值,并可以让用户输入一个数字n,
        //按照n行n个数，输出数组  int[]  array = new int[50];     Random r = new Random();  r.Next();
        static void Main(string[] args)
        {
            Console.WriteLine("请输入小于50的数");
            int n = Convert.ToInt32(Console.ReadLine());
            GetNumber(n);
            Console.ReadKey();

        }

        static void GetNumber(int n)
        {
           
            int [] array = new int[50];
            Random ran = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ran.Next(1,10);
            }
            for (int i = 0; i <array.Length; i++)
            {
                Console.Write(array[i]+"\t");   
                if((i+1)%n==0) Console.WriteLine();
            }
            
        }
    }
}
