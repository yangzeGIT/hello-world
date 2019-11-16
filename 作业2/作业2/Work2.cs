using System;
using System.Collections.Generic;
using System.Text;

namespace 作业2
{
    class Work2
    {
        public void work2()
        {
            Random rnd = new Random();
            int[,] a = new int[35, 5];
            double [] b = new double[4];//平均分
            double[] c = new double[35]; //加权积分
            //产生学号
            for (int i = 0; i < 35; i++)
            {
                a[i,4] = i;
            }
            //产生随机成绩
            for (int i=0;i<35;i++)
            {
                for(int j=0;j<4;j++)
                {
                    a[i, j] = rnd.Next(60,100);
                }
            }
            //计算平均分
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    b[i] += a[j,i];
                }
                b[i] = b[i] / 35;
            }
            //计算加权积分
            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    c[i] += a[i,j] / b[j];
                    c[i] = Math.Round(c[i], 2);
                }
            }
            //冒泡排序
            for (int j = 0; j < 35; j++)
            {
                for (int k = j + 1; k < 35; k++)
                {
                    if (c[k] > c[j])
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int m = a[k, i];
                            a[k, i] = a[j, i];
                            a[j, i] = m;
                        }
                        double n = c[k];
                        c[k] =c[j];
                        c[j] = n;
                    }
                }
            }
            double x = 35 * 0.05;
            int x1 = (int)(x);
            double y = 35 * 0.1;
            int y1 = (int)(y);
            double z = 35 * 0.15;
            int z1 = (int)(z);
            Console.WriteLine("一等奖学金:");
            for (int i = 0; i <x1; i++)
            {
                string id = a[i, 4].ToString().PadLeft(2, '0');
                Console.Write("学号：{0}  ", id);
                Console.Write("课1成绩：{0}  ", a[i,0]);
                Console.Write("课2成绩：{0}  ", a[i,1]);
                Console.Write("课3成绩：{0}  ", a[i, 2]);
                Console.Write("课4成绩：{0}  ", a[i, 3]);
                string id1 = c[i].ToString().PadRight(4, '0');
                Console.Write("加权积分：{0}\n", id1);
            }
            Console.WriteLine("\n二等奖学金:");
            for (int i = x1; i < y1+ x1; i++)
            {
                string id = a[i, 4].ToString().PadLeft(2, '0');
                Console.Write("学号：{0}  ", id);
                Console.Write("课1成绩：{0}  ", a[i, 0]);
                Console.Write("课2成绩：{0}  ", a[i, 1]);
                Console.Write("课3成绩：{0}  ", a[i, 2]);
                Console.Write("课4成绩：{0}  ", a[i, 3]);
                string id1 = c[i].ToString().PadRight(4, '0');
                Console.Write("加权积分：{0}\n", id1);
            }
            Console.WriteLine("\n三等奖学金:");
            for (int i = y1+x1; i < z1+y1 + x1; i++)
            {
                string id = a[i, 4].ToString().PadLeft(2, '0');
                Console.Write("学号：{0}  ", id);
                Console.Write("课1成绩：{0}  ", a[i, 0]);
                Console.Write("课2成绩：{0}  ", a[i, 1]);
                Console.Write("课3成绩：{0}  ", a[i, 2]);
                Console.Write("课4成绩：{0}  ", a[i, 3]);
                string id1 = c[i].ToString().PadRight(4, '0');
                Console.Write("加权积分：{0}\n", id1);
            }
        }


        }
}
