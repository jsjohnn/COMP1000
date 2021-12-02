using System;
using System.Drawing;

namespace Assignment4
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            Bitmap tempMap = new Bitmap(6, 5);

            Console.WriteLine("입력값");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Color tempMapColor = Color.FromArgb(i, j, i + j); // 증가하는 반복문 값으로 rgb값을 설정했습니다. 원하신다면 직접 값을 설정하세요
                    tempMap.SetPixel(j, i, tempMapColor);
                    Console.Write($"{{{tempMapColor.R:D3},{tempMapColor.G:D3},{tempMapColor.B:D3}}} ");
                }
                Console.WriteLine();
            }

            double[,] tempFilter = { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; // 원하는 필터를 사용하세요
                                                                              // {{0,0,0},{0,1,0},{0,0,0} 값을 그대로 나오게 해주는 필터
                                                                              // {{0,0,0},{0,0,0},{0,1,0}} 아래로 한 칸 이동
                                                                              // {{0,1,0},{0,0,0},{0,0,0}} 위로 한 칸 이동

            Console.WriteLine("\n필터");
            for (int i = 0; i < tempFilter.GetLength(0); i++)
            {
                Console.Write("{ ");
                for (int j = 0; j < tempFilter.GetLength(1); j++)
                {
                    Console.Write($"{tempFilter[i, j]}, ");
                }
                Console.WriteLine("}");
            }

            Bitmap result = SignalProcessor.ConvolveImage(tempMap, tempFilter);


            Console.WriteLine("\n출력값");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Color resultColor = result.GetPixel(j, i);
                    Console.Write($"{{{resultColor.R:D3},{resultColor.G:D3},{resultColor.B:D3}}} ");
                }
                Console.WriteLine();
            }
        }
    }
}
