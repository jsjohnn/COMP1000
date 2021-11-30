using System;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr1 = new double[] { 10.0, 50.0, 60.0, 10.0, 20.0, 40.0, 30.0 };
            double[] arr2 = new double[] { 1 / 3.0, 2 / 3.0, 1.0 };

            double hValues = 0;
            double addValues = 0.0;

            for (int i = 0; i < arr2.Length; ++i)
            {
                addValues += arr2[i] * arr1[(int)(hValues - i + (arr2.Length - 1) / 2)];
            }
                Console.WriteLine(addValues);
            
        }
    }
}
