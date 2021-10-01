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
            set1.Add("a");
            set1.Add("b");
            set1.Add("a");

            List<MultiSet> powersets = set1.FindPowerSet();

            foreach (var powerset in powersets)
            {
                Console.WriteLine(string.Join(',', powerset.Sets));
            }

            //List<int> number = new List<int>();
            //number.Add(4);
            //number.Add(2);
            //number.Add(3);
            //number.Add(5);
            //number.Add(1);


            //Console.WriteLine(string.Join(',', number));



            #region Union Test
            //MultiSet set1 = new MultiSet();
            //MultiSet set2 = new MultiSet();
            //MultiSet set3 = new MultiSet();


            //set1.Add("a");
            //set1.Add("a");
            //set1.Add("a");
            //set1.Add("b"); //{a,a,a,b}

            //set2.Add("a");
            //set2.Add("a");
            //set2.Add("b");
            //set2.Add("c"); //{a,a,b,c}


            //MultiSet union = set3.Union(set1); // {a,a,a,b,c}

            //foreach (var i in union.Sets)
            //{
            //    Console.WriteLine(i + "");
            //}

            #endregion

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
}
