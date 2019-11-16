using System;
using System.Collections.Generic;
using System.Text;

namespace 作业2
{
    class Work1
    {
        public void work1()
        {
     
            for(int k1=1000;k1<=9999;k1++)
            {
                int f = k1;
            int[] a = new int[10]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int b = 0, c = 0, m=0;
            Console.Write("{0}-", f);
            if (f >= 1000 && f <= 9999)
            {
                for (int i = 1; i <= 10; i++)
                {
                    m = f; b = 0; c = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        a[j] = m % 10;
                        m = m / 10;
                    }
                    //冒泡排序
                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = j; k < 4; k++)
                        {
                            if (a[k] > a[j])
                            {
                                int n = a[k];
                                a[k] = a[j];
                                a[j] = n;
                            }
                        }
                    }

                    for (int j = 0; j < 4; j++)
                    {
                        double d = Math.Pow(10, j);
                        int e = (int)d;
                        b += a[j] * e;
                    }
                    for (int j = 3; j >= 0; j--)
                    {
                        double d = Math.Pow(10, 3 - j);
                        int e = (int)d;
                        c += a[j] * e;
                    }
                    f = c - b;
                    if (f == 6174)
                    {
                        Console.WriteLine("6174\n经过了{0}次变换", i);
                        break;
                    }
                    else
                        Console.Write("{0}-", f);
                }

            }
            else
            {
                Console.WriteLine("输入错误!");
            }
            }
            
        }
    }
}
