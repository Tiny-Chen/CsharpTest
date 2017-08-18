using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 复习299乘法表
{
    class Program
    {
        static void Main(string[] args)
        {
            Multiplication();
            Console.ReadKey();
        }

        static void Multiplication()
        {
            int sum;
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j <=i; j++)
                {
                    sum = i * j;
                    Console.Write("{1}*{2}={0}"+"\t", sum,i,j);
                }
                Console.WriteLine();
            }
        }
    }
}
