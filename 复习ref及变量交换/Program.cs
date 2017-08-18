using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 复习ref及变量交换
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 6.	声明两个变量：int n1 = 10, n2 = 20;要求将两个变量交换，最后输出n1为20,n2为10。扩展（*）：不使用第三个变量如何交换？
            7.	用方法来实现：将上题封装一个方法来做。提示：方法有两个参数n1,n2,在方法中将n1与n2进行交换，使用ref。（*）
            */
            //int n1 = 10;
            //int n2 = 20;
            //sExchage(ref n1,ref n2);
            ////Console.WriteLine(n1);
            ////Console.WriteLine(n2);
            //Console.ReadKey();

            //8.	请用户输入一个字符串，计算字符串中的字符个数，并输出
            //Console.WriteLine("请输入字符串");
            //string str = Console.ReadLine();
            //int nunber = str.Length;
            //Console.WriteLine(nunber);
            //Console.ReadKey();

            //9.	用方法来实现：计算两个数的最大值。思考：方法的参数？返回值？扩展（*）：计算任意多个数间的最大值（提示：params）
            //int a = 10;
            //int b = 20;
            //int[] number = new[] {1, 2, 3, 4, 5, 6, 7, 13, 15, 16};
            //int max = MaxNumber(8,9,3,5,12,9,45);
            //Console.WriteLine(max);

            ////1-100之间的整数和
            //int sum =GetSum(100);
            //Console.WriteLine(sum);

            //String[] str = new[] {"马龙", "迈克尔乔丹", "雷吉米勒", "蒂姆邓肯", "科比布莱恩特"};
            //string n = LongString(str);
            //Console.WriteLine(n);


            //计算数组的平均值
            //double[] num = {1, 3, 5, 7, 93, 33, 4, 4, 6, 8, 10};
            //double avg = GetNum(num);
            //avg = Convert.ToDouble(avg.ToString("0.00"));//保留两位
            //Console.WriteLine(avg);


            //冒泡升序
            //int[] num = {1, 3, 5, 7, 93, 33, 4, 4, 6, 8, 10};
            //Numbers(num);
            //foreach (var itm in num)
            //{
            //    Console.WriteLine(itm);
            //}

            //18.	为教师编写一个程序，该程序使用一个数组存储30个学生的考试成绩，并给各个数组元素指定一个1-100的随机值，然后计算平均成绩
            //int[] leve = new int[30];
            //Random r = new Random();
            //int sum=0;
            //for (int i = 0; i < leve.Length; i++)
            //{
            //    leve[i] = r.Next(1,100);
            //    sum += leve[i];
            //}
            //double avg = sum / leve.Length;
            //Console.WriteLine(avg);


            /*19.	有如下字符串：【"患者：“大夫，我咳嗽得很重。”     大夫：“你多大年记？”     患者：“七十五岁。”     大夫：“二十岁咳嗽吗”患者：“不咳嗽。”     大夫：“四十岁时咳嗽吗？”     患者：“也不咳嗽。”     大夫：“那现在不咳嗽，还要等到什么时咳嗽？”"】。
            // * 需求：请统计出该字符中“咳嗽”二字的出现次数，以及每次“咳嗽”出现的索引位置
            
            string str = " 患者：“大夫，我咳嗽得很重。”     大夫：“你多大年记？”     患者：“七十五岁。”     大夫：“二十岁咳嗽吗”患者：“不咳嗽。”     大夫：“四十岁时咳嗽吗？”     患者：“也不咳嗽。”     大夫：“那现在不咳嗽，还要等到什么时咳嗽？”";
            //第1次出现的位置
            int index = str.IndexOf("咳嗽");
            Console.WriteLine("第1次出现的位置是{0}",index);
            int i = 1;
            while (index!=-1)
            {
                i++;
                index = str.IndexOf("咳嗽", index + 1);//从上一次找到的位置起从新找，全部都找不到后会返回-1，退出循环
                if(index==-1) break;
                Console.WriteLine("第{1}次出现的位置是{0}", index,i);
            }
            */


            //将字符串"  hello      world,你  好 世界   !    "两端空格去掉，并且将其中的所有其他空格都替换成一个空格，
            //输出结果为："hello world,你 好 世界 !"
            string str = "  hello      world,你  好 世界   !    ";
            str = str.Trim();//去两端的空格
            //分割字符串
            string[ ] NewStr = str.Split(new char[ ]{' '}, StringSplitOptions.RemoveEmptyEntries);
            //再连接字符串
            str = string.Join(" ", NewStr);
            Console.WriteLine(str);



            Console.ReadKey();
        }

        public static  void sExchage(ref int n1,ref int n2)
        {
            int n = n1;
            n1 = n2;
            n2 = n;
        }

        public static int MaxNumber(params int[] number)
        {
           
            int n = number[0];
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] > n) number[0] = number[i];
            }
            return number[0];
        }

        /// <summary>
        /// 1-100整数和
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetSum(int number)
        {
            return ((number + 1) * number) / 2;
        }

        /*15.	用方法来实现：有一个字符串数组：{ "马龙", "迈克尔乔丹", "雷吉米勒", "蒂姆邓肯", "科比布莱恩特" },请输出最长的字符串*/

            public static string LongString(string[] name)
        {
            string str = "";
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i].Length > str.Length) str = name[i];
            }
            return str;
        }
        //请计算出一个整型数组的平均值。{ 1, 3, 5, 7, 93, 33, 4, 4, 6, 8, 10 }。要求：计算结果如果有小数，则显示小数点后两位（四舍五入）

        public static double GetNum(double[] n)
        {
            double sum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                sum += n[i];
            }
            return sum / n.Length;
        }

        /// <summary>
        /// 冒泡升序
        /// </summary>
        /// <param name="num"></param>
        public static void Numbers(int[] num)
        {
            for (int i = 0; i < num.Length-1; i++)
            {
                for (int j = 0; j < num.Length-1-i; j++)
                {
                    if (num[j] > num[j + 1])
                    {
                        int temp = num[j];
                        num[j] = num[j + 1];
                        num[j + 1] = temp;
                    }
                }
            }
        }
    }
}
