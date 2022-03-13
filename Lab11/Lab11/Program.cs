using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] data = new int[] { 4 };
            //List<Tuple<Tuple<int, int>, int>> frequencyTable = FrequencyTable.GetFrequencyTable(data, 1);

            //Debug.Assert(getTotalCount(frequencyTable) == data.Length);

            //Debug.Assert(frequencyTable.Count == 1);
            //Debug.Assert(frequencyTable[0].Item1.Item1 == 4);
            //Debug.Assert(frequencyTable[0].Item1.Item2 == 5);
            //Debug.Assert(frequencyTable[0].Item2 == 1);

            //frequencyTable = FrequencyTable.GetFrequencyTable(data, 5);

            //Debug.Assert(getTotalCount(frequencyTable) == data.Length);

            //Debug.Assert(frequencyTable.Count == 1);
            //Debug.Assert(frequencyTable[0].Item1.Item1 == 4);
            //Debug.Assert(frequencyTable[0].Item1.Item2 == 5);
            //Debug.Assert(frequencyTable[0].Item2 == 1);

            //data = new int[] { 4, 4, 4, 4 };
            //frequencyTable = FrequencyTable.GetFrequencyTable(data, 3);

            //Debug.Assert(getTotalCount(frequencyTable) == data.Length);

            //Debug.Assert(frequencyTable.Count == 1);
            //Debug.Assert(frequencyTable[0].Item1.Item1 == 4);
            //Debug.Assert(frequencyTable[0].Item1.Item2 == 5);
            //Debug.Assert(frequencyTable[0].Item2 == 4);

            //data = new int[] { 4, 5, 6, 7, 8, 9 };
            //frequencyTable = FrequencyTable.GetFrequencyTable(data, 5);

            //Debug.Assert(getTotalCount(frequencyTable) == data.Length);
            //Debug.Assert(frequencyTable.Count == 3);

            //Debug.Assert(frequencyTable[0].Item1.Item1 == 4);
            //Debug.Assert(frequencyTable[0].Item1.Item2 == 6);
            //Debug.Assert(frequencyTable[0].Item2 == 2);

            //Debug.Assert(frequencyTable[1].Item1.Item1 == 6);
            //Debug.Assert(frequencyTable[1].Item1.Item2 == 8);
            //Debug.Assert(frequencyTable[1].Item2 == 2);

            //Debug.Assert(frequencyTable[2].Item1.Item1 == 8);
            //Debug.Assert(frequencyTable[2].Item1.Item2 == 10);
            //Debug.Assert(frequencyTable[2].Item2 == 2);

            //data = new int[] { 1, 12, 14, 15, 21, 22, 22, 30, 33, 41, 41, 61, 69, 70, 81, 90, 92, 101 };
            //frequencyTable = FrequencyTable.GetFrequencyTable(data, 5);

            //Debug.Assert(getTotalCount(frequencyTable) == data.Length);
            //Debug.Assert(frequencyTable.Count == 5);

            //Debug.Assert(frequencyTable[0].Item1.Item1 == 1);
            //Debug.Assert(frequencyTable[0].Item1.Item2 == 22);
            //Debug.Assert(frequencyTable[0].Item2 == 5);

            //Debug.Assert(frequencyTable[1].Item1.Item1 == 22);
            //Debug.Assert(frequencyTable[1].Item1.Item2 == 43);
            //Debug.Assert(frequencyTable[1].Item2 == 6);

            //Debug.Assert(frequencyTable[2].Item1.Item1 == 43);
            //Debug.Assert(frequencyTable[2].Item1.Item2 == 64);
            //Debug.Assert(frequencyTable[2].Item2 == 1);

            //Debug.Assert(frequencyTable[3].Item1.Item1 == 64);
            //Debug.Assert(frequencyTable[3].Item1.Item2 == 85);
            //Debug.Assert(frequencyTable[3].Item2 == 3);

            //Debug.Assert(frequencyTable[4].Item1.Item1 == 85);
            //Debug.Assert(frequencyTable[4].Item1.Item2 == 106);
            //Debug.Assert(frequencyTable[4].Item2 == 3);

            //data = new int[] { 10, 11, 20, 1, 30, 20, 22, 25, 48, 43, 23, 44, 49, 21, 31, 35, 33, 36, 2, 4, 3 };
            //frequencyTable = FrequencyTable.GetFrequencyTable(data, 5);

            //Debug.Assert(getTotalCount(frequencyTable) == data.Length);
            //Debug.Assert(frequencyTable.Count == 5);

            //Debug.Assert(frequencyTable[0].Item1.Item1 == 1);
            //Debug.Assert(frequencyTable[0].Item1.Item2 == 11);
            //Debug.Assert(frequencyTable[0].Item2 == 5);

            //Debug.Assert(frequencyTable[1].Item1.Item1 == 11);
            //Debug.Assert(frequencyTable[1].Item1.Item2 == 21);
            //Debug.Assert(frequencyTable[1].Item2 == 3);

            //Debug.Assert(frequencyTable[2].Item1.Item1 == 21);
            //Debug.Assert(frequencyTable[2].Item1.Item2 == 31);
            //Debug.Assert(frequencyTable[2].Item2 == 5);

            //Debug.Assert(frequencyTable[3].Item1.Item1 == 31);
            //Debug.Assert(frequencyTable[3].Item1.Item2 == 41);
            //Debug.Assert(frequencyTable[3].Item2 == 4);

            //Debug.Assert(frequencyTable[4].Item1.Item1 == 41);
            //Debug.Assert(frequencyTable[4].Item1.Item2 == 51);
            //Debug.Assert(frequencyTable[4].Item2 == 4);

            //int[,] table = new int[9, 9];

            //for (int i = 0; i < 9; ++i)
            //{
            //    for (int j = 0; j < 9; ++j)
            //    {
            //        table[i, j] = (i + 1) * (j + 1);
            //        Console.Write($"{(i + 1),2} * {j + 1,-2} = {table[i, j],-3}");
            //    }
            //    Console.WriteLine();
            //}




            //int[] a = { 5, 7, 9 };
            //int N = a.Length;

            //int result = go(a, 0, N - 1);

            Fibonacci(3);

        }


        //private static int go(int[] a, int l, int r)
        //{
        //    if (l == r)
        //    {
        //        return a[l];
        //    }

        //    int mid = (l + r) / 2;
        //    int sum = go(a, l, mid) + go(a, mid + 1, r);

        //    for (int i = l; i <= r; i++)
        //    {
        //        sum += a[i];
        //    }

        //    return sum;
        //}

        //private static int getTotalCount(List<Tuple<Tuple<int, int>, int>> frequencyTable)
        //{
        //    int count = 0;

        //    foreach (var tup in frequencyTable)
        //    {
        //        count += tup.Item2;
        //    }

        //    return count;
        //}

        public static void Magic(int n)
        {
            if (n == 1)
            {
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.WriteLine();
                }
            }
        }
        public static void NotMagic(int n)
        {
            int p = 0;
            for (int i = 0; i < n; i++)
            {
                while (i - p > 5)
                {
                    p++;
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static int Fibonacci(int n)
        {
            Console.WriteLine(n);

            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return Fibonacci(n - 2) + Fibonacci(n - 1);
        }
    }
}
   