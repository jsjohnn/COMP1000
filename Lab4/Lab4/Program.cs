﻿using System;
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
            //    foreach (var j in i.Sets)
            //    {
            //        Console.Write(j);
            //    }
            //    Console.WriteLine();


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

            MultiSet set1 = new MultiSet();
            MultiSet set2 = new MultiSet();
            MultiSet set3 = new MultiSet();


            set1.Add("a");
            set1.Add("a");
            set1.Add("a");
            set1.Add("b"); //{a,a,a,b}

            set2.Add("a");
            set2.Add("a");
            set2.Add("b");
            set2.Add("c"); //{a,a,b,c}


            MultiSet union = set3.Union(set1); // {a,a,a,b,c}

            foreach (var i in union.Sets)
            {
                Console.WriteLine(i + "");
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
        //}
    }
}
