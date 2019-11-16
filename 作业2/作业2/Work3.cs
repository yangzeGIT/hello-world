using System;
using System.Collections.Generic;
using System.Text;

namespace 作业2
{
    class Work3
    {
        static int[,] graph = new int[9, 9] { { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000 } , { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000 }, { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000 }, { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000 }, { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000 }, { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000 }, { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000 }, { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000 }, { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000 } };
        static int[] S = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };//最短路径的顶点集合
        static string[] mid = new string[9] { "", "", "", "", "", "", "", "", "" };//点的路线
        public void work3()
        {
            int [,] a= new int[16, 3];//线路
            int[] b = new int[16];
            Random rnd = new Random();
            for(int i=0;i<15;i=i)
            {
                a[i, 0] = rnd.Next(0, 9);
                a[i, 1] = rnd.Next(0, 9);
                a[i, 2] = rnd.Next(20, 99);
                if (a[i, 0] < a[i, 1])
                    i++;
                for (int j = 0; j < i-1;j++)
                {
                    if(a[j,0]== a[i-1, 0]&& a[j, 1] == a[i-1, 1])
                    {
                        i--; 
                        break;
                    }
                }
            }
            Console.Write("对应城市及其线路的代价\n");
            for (int j = 0; j < 9; j++)
            {
                for (int k = 0; k < 9; k++)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (a[i, 0] == j&&a[i, 1] == k)
                            Console.Write("{0}-{1} {2}\n", a[i, 0], a[i, 1], a[i, 2]);
                    }
                }
            }
            for (int i = 0; i< 15;i++)
            {
                    if (a[i,2] != 10000)
                    {
                        int x = a[i, 0];
                        int y = a[i, 1];
                        int z = a[i, 2];
                        graph[x,y] = z;
                       }
            }
            for (int i = 0; i < 15; i++)
            {
                if (a[i, 2] != 10000)
                {
                    int x = a[i, 0];
                    int y = a[i, 1];
                    int z = a[i, 2];
                    graph[y, x] = z;
                }
            }
            Console.Write("\n邻接矩阵graph\n");
            Console.Write("       " );
            for (int i = 0; i < 9; i++)
            {
                Console.Write("城市{0}  ", i);
            }
            Console.Write("\n");
            for (int i = 0; i < 9; i++)
            {
                Console.Write("城市{0}  ", i);
                for (int j= 0;j < 9; j++)
                {
                    string id1 = graph[i, j].ToString().PadLeft(5, ' ');
                    Console.Write("{0}  ", id1);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
            ShortestPathByDijkstra();
        }
            public static int IsContain(int m)//判断元素是否在mst中
            {
                int index = -1;
                for (int i = 1; i < 9; i++)
                {
                    if (S[i] == m)
                    {
                        index = i;
                    }
                }
                return index;
            }
            /// Dijkstrah实现最短路算法
            static void ShortestPathByDijkstra()
            {
                int min;
                int next;

            for (int f = 8; f > 0; f--)
            {
                    //置为初始值
                    min = 10000;
                    //第一行最小的元素所在的列 next点
                    next = 0;
                    //找出第一行最小的列值
                    for (int j = 1; j < 9; j++)//循环第0行的列
                    {
                        if ((IsContain(j) == -1) && (graph[0, j] < min))//不在S中,找出第一行最小的元素所在的列
                        {
                            min = graph[0, j];
                            next = j;
                        }
                    }
                    //将下一个点加入S
                    S[next] = next;
                    //输出最短距离和路径
                   
                    if(min!=10000)
                    {
                    string id1 = min.ToString().PadLeft(3, ' ');
                    Console.WriteLine("V0到V{0}的最短路径为：{1},路径为：V0{2}->V{0}", next, id1, mid[next]);
                    }
                    // 重新初始0行所有列值
                    for (int j = 1; j < 9; j++)//循环第0行的列
                    {
                        if (IsContain(j) == -1)//初始化除包含在S中的
                        {
                            if ((graph[next, j] + min) < graph[0, j])//如果小于原来的值就替换
                            {
                                graph[0, j] = graph[next, j] + min;
                                mid[j] = mid[next] + "->V" + next;//记录过程点
                            }
                        }
                    }

                }
            for (int i = 1; i < 9; i++)
            {
                if (IsContain(i) == -1)
                    Console.WriteLine("V0到V{0}的最短路径为：无",i);

            }
            
        }
        
    }
}
