using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            //MultiSet set = new MultiSet();

            //set.Add("a");
            //set.Add("b");
            //set.Add("a");

            //List<MultiSet> powersetList = set.FindPowerSet();
            //// powersetList:
            //// { }
            //// { a }
            //// { a, a }
            //// { a, a, b }
            //// { a, b }
            //// { b }

            //foreach (var i in powersetList)
            //{
            //    foreach (var j in i.sets)
            //    {
            //        Console.Write(j);
            //    }
            //    Console.WriteLine();
            //}

            //List<string> test = new List<string>();

            //test.Add("a");
            //test.Add("c");
            //test.Add("b");

            //List<string> temp1 = new List<string>() { "a", "b" };

            //StringBuilder sb = new StringBuilder();

            //foreach (var i in temp1)
            //{
            //    sb.Append(i);
            //}

            //string magicString = sb.ToString();

            //Console.WriteLine(magicString);

            // ===========================중복 테스트=============================
            //var set1 = new MultiSet(); // aabccc
            //set1.Add("a");
            //set1.Add("a");
            //set1.Add("b");
            //set1.Add("c");
            //set1.Add("c");
            //set1.Add("c");
            //var set2 = new MultiSet();// aaaabc
            //set2.Add("a");
            //set2.Add("a");
            //set2.Add("a");
            //set2.Add("a");
            //set2.Add("b");
            //set2.Add("c");

            //MultiSet union = set1.Union(set2); // //{a, a, a, b, c, c, c}

            //foreach (var i in union.Sets)
            //{
            //    Console.Write(i + "");
            //}

            //Console.WriteLine("------------------------------Union()-------------------------------------------------------");
            //var set1 = new MultiSet();
            //var list = set1.ToList();
            //var expectedList = new List<string> { "a", "a", "b", "c" };


            //set1 = new MultiSet();
            //set1.Add("a");
            //set1.Add("b");
            //set1.Add("b");
            //set1.Add("c");

            //var set2 = new MultiSet();
            //set2.Add("a");
            //set2.Add("b");
            //set2.Add("c");

            //list = set1.Union(set2).ToList();

            //var expectedSet1 = new List<string> { "a", "b", "b", "c" };
            //var expectedSet2 = new List<string> { "a", "b", "c" };
            //expectedList = new List<string> { "a", "b", "b", "c" };

            //Console.WriteLine("\n{ a, b, b, c } | { a, b, c }");
            //EqualList(expectedSet1, set1.ToList());
            //EqualList(expectedSet2, set2.ToList());
            //Console.WriteLine("MultiSet.Union(other) => { a, b, b, c }");
            //EqualList(expectedList, list);

            //set1 = new MultiSet();
            //set1.Add("A");
            //set1.Add("C");
            //set1.Add("B");

            //list = set1.Union(set2).ToList();
            //expectedSet1 = new List<string> { "A", "B", "C" };
            //expectedSet2 = new List<string> { "a", "b", "c" };
            //expectedList = new List<string> { "a", "A", "b", "B", "c", "C" };

            //Console.WriteLine("\n\n{ A, B, C } | { a, b, c }");
            //EqualList(expectedSet1, set1.ToList());
            //EqualList(expectedSet2, set2.ToList());
            //Console.WriteLine("MultiSet.Union(other) => { a, A, b, B, c, C }");
            //EqualList(expectedList, list);

            //set2 = new MultiSet();
            //list = set1.Union(set2).ToList();
            //expectedSet1 = new List<string> { "A", "B", "C" };
            //expectedSet2.Clear();
            //expectedList = new List<string> { "A", "B", "C" };

            //Console.WriteLine("\n{ A, B, C } | {   }");
            //EqualList(expectedSet1, set1.ToList());
            //EqualList(expectedSet2, set2.ToList());
            //Console.WriteLine("MultiSet.Union(other) => { A, B, C }");
            //EqualList(expectedList, list);

            //set1 = new MultiSet();
            //list = set1.Union(set2).ToList();
            //expectedSet1.Clear();
            //expectedList.Clear();

            //Console.WriteLine("\n{   } | {   }");
            //EqualList(expectedSet1, set1.ToList());
            //EqualList(expectedSet2, set2.ToList());
            //Console.WriteLine("MultiSet.Union(other) => {   }\n");
            //EqualList(expectedList, list);

            MultiSet set1 = new MultiSet();
            MultiSet set2 = new MultiSet();
            MultiSet set3 = new MultiSet();

            set1.Add("d");
            set1.Add("d");
            set1.Add("d");
            set1.Add("l"); // set1: { d, d, h, l }

            set2.Add("d");
            set2.Add("c");
            set2.Add("h");
            set2.Add("h"); // set2: { c, d, h, h }

            MultiSet union = set1.Union(set2); // { c, d, d, h, h, l }

            Console.WriteLine("**********");
            foreach (var i in union.Sets)
            {
                Console.WriteLine(i + "");
            }

        }
        public static void EqualList(List<string> expectedList, List<string> list)
        {
            for (int i = 0; i < expectedList.Count; i++)
            {
                Debug.Assert(expectedList[i] == list[i]);
            }
        }

        #region PowerSet Recursive Algorithm
        //static void makePowerSet(string[] inputs, int[] flag, int index)
        //{

        //	if (index == inputs.Length)
        //	{
        //		for (int i = 0; i < flag.Length; i++)
        //		{
        //			if (flag[i] == 1)
        //			{
        //				Console.Write(inputs[i]);
        //			}
        //		}
        //		Console.WriteLine();
        //		return;
        //	}

        //	flag[index] = 1;
        //	makePowerSet(inputs, flag, index + 1); 

        //	flag[index] = 0;
        //	makePowerSet(inputs, flag, index + 1);
        //}
        #endregion
    }
}
