using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("请输入第1个整数");
            //string OneNumber = Console.ReadLine();

            //Console.WriteLine("请输入第2个整数");
            //string TwoNumber = Console.ReadLine();

            //Console.WriteLine("请输入第3个整数");
            //string ThreeNumber = Console.ReadLine();

            //Console.WriteLine("请输入第4个整数");
            //string FourNumber = Console.ReadLine();

            //int first = Convert.ToInt32(OneNumber);
            //int two = Convert.ToInt32(TwoNumber);
            //int three = Convert.ToInt32(ThreeNumber);
            //int four = Convert.ToInt32(FourNumber);

            //int CheJi = first * two * three * four;
            //Console.WriteLine("四个数的乘积是：{0}",CheJi);
            //Console.ReadKey();
            //布尔运算
            //bool var1;
            //int var2 = 2;
            //int var3 = 4;
            //int var4 = 2;

            ////var1= var2 == var3;
            //var1 = var2 < var3;
            //Console.WriteLine(var1);
            //Console.ReadKey();
            
            //按位运算
            //int sum, number1 = 4, number2 = 5;
            ////sum = number1 & number2;//与运算，把转换成二进制，有只有同时为1时才是1，否则是0---------（100，101）4
            //sum = number2 | number2;//位运算，转换二进制，只要有一位为1，则为1，同时为0才是为0---------5
            //Console.WriteLine(sum);
            //Console.ReadKey();

            //位移运算
            int var1, var2 = 10, var3 = 5;
            //向左位移2位（var3=2）,即把var2转换成二进制1010，向左移两位101000，值=40；
            //向左位移n位，即等于值*于2n次方，向右移n位，即等于值/2n次方。
            var1 = var2 << var3;
            Console.WriteLine(var1);
            Console.ReadKey();

        }
    }
}
