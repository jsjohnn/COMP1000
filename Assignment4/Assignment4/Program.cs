using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bitmap = new Bitmap(File.OpenRead("earth.png"));



            //using (FileStream fs = File.OpenRead("/Users/donghwa/Desktop/COMP1000/Assignment4/Assignment4/earth.png"))
            //using (Bitmap image = new Bitmap(fs))
            //using (Bitmap newImage = SignalProcessor.ConvolveImage(image, new double[,] {
            //        { 1 / 9.0, 1 / 9.0, 1 / 9.0 },
            //        { 1 / 9.0, 1 / 9.0, 1 / 9.0 },
            //        { 1 / 9.0, 1 / 9.0, 1 / 9.0 }
            //       }))
            //{
            //    newImage.Save("image_box_filtered.png", ImageFormat.Png); // 결과를 image_box_filtered.png 파일에 저장
            //}
        }
    }
}