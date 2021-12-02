using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;

namespace Assignment4
{
    public static class SignalProcessor
    {
        public static double[] GetGaussianFilter1D(double sigma)
        {
            int lengthOfGaussianFilter1D = (int)(sigma * 6);

            if (lengthOfGaussianFilter1D % 2 == 0)
            {
                lengthOfGaussianFilter1D += 1;
            }

            var gaussianFilter1D = new double[lengthOfGaussianFilter1D];
            int midIndex = (int)(lengthOfGaussianFilter1D / 2 + 0.5);

            for (int i = 0; i < gaussianFilter1D.Length; ++i)
            {
                gaussianFilter1D[i] = 1 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Exp(-Math.Pow(Math.Abs(i - midIndex), 2) / (2 * Math.Pow(sigma, 2)));
            }
            return gaussianFilter1D;
        }

        public static double[] Convolve1D(double[] signal, double[] filter)
        {
            var convolved1D = new double[signal.Length];
            for (int i = 0; i < signal.Length; ++i)
            {
                for (int j = 0; j < filter.Length; ++j)
                {
                    if (i - j + (filter.Length - 1) / 2 >= 0 && i - j + (filter.Length - 1) / 2 < signal.Length)
                    {
                        convolved1D[i] += filter[j] * signal[i - j + (filter.Length - 1) / 2];
                    }
                }
            }
            return convolved1D;
        }

        public static double[,] GetGaussianFilter2D(double sigma)
        {
            int lengthOfGaussianFilter2D = (int)(sigma * 6);

            if (lengthOfGaussianFilter2D % 2 == 0)
            {
                lengthOfGaussianFilter2D += 1;
            }

            var gaussianFilter2D = new double[lengthOfGaussianFilter2D, lengthOfGaussianFilter2D];
            int midIndex = (int)(lengthOfGaussianFilter2D / 2 + 0.5);

            for (int i = 0; i < gaussianFilter2D.GetLength(0); ++i)
            {
                for (int j = 0; j < gaussianFilter2D.GetLength(1); ++j)
                {
                    gaussianFilter2D[i, j] = 1 / (2 * Math.PI * Math.Pow(sigma, 2)) * Math.Exp(-(Math.Pow(Math.Abs(i - midIndex), 2) + Math.Pow(Math.Abs(j - midIndex), 2)) / (2 * Math.Pow(sigma, 2)));
                }
            }
            return gaussianFilter2D;
        }

        public static Bitmap ConvolveImage(Bitmap bitmap, double[,] filter)
        {
            RgbColor[,] input = new RgbColor[bitmap.Width, bitmap.Height];

            for (int i = 0; i < input.GetLength(0); ++i)
            {
                for (int j = 0; j < input.GetLength(1); ++j)
                {
                    input[i, j] = new RgbColor(bitmap.GetPixel(i, j));
                }
            }

            int lengthOfFilter = filter.GetLength(0);

            for (int x = 0; x < input.GetLength(0); ++x)
            {
                for (int y = 0; y < input.GetLength(1); ++y)
                {
                    double red = 0;
                    double green = 0;
                    double blue = 0;

                    for (int i = 0; i < filter.GetLength(0); ++i)
                    {
                        for (int j = 0; j < filter.GetLength(1); ++j)
                        {
                            if (x - j + (lengthOfFilter - 1) / 2 >= 0 && x - j + (lengthOfFilter - 1) / 2 < input.GetLength(0)
                                && y - i + (lengthOfFilter - 1) / 2 >= 0 && y - i + (lengthOfFilter - 1) / 2 < input.GetLength(1))
                            {

                                red += filter[i, j] * input[x - j + (lengthOfFilter - 1) / 2, y - i + (lengthOfFilter - 1) / 2].Red;
                                green += filter[i, j] * input[x - j + (lengthOfFilter - 1) / 2, y - i + (lengthOfFilter - 1) / 2].Green;
                                blue += filter[i, j] * input[x - j + (lengthOfFilter - 1) / 2, y - i + (lengthOfFilter - 1) / 2].Blue;

                                //red += filter[j, i] * input[x - j + (lengthOfFilter - 1) / 2, y - i + (lengthOfFilter - 1) / 2].Red;
                                //green += filter[j, i] * input[x - j + (lengthOfFilter - 1) / 2, y - i + (lengthOfFilter - 1) / 2].Green;
                                //blue += filter[j, i] * input[x - j + (lengthOfFilter - 1) / 2, y - i + (lengthOfFilter - 1) / 2].Blue;

                                //red += (int)(filter[j, i] * input[x - j + (lengthOfFilter - 1) / 2, y - i + (lengthOfFilter - 1) / 2].Red);
                                //green += (int)(filter[j, i] * input[x - j + (lengthOfFilter - 1) / 2, y - i + (lengthOfFilter - 1) / 2].Green);
                                //blue += (int)(filter[j, i] * input[x - j + (lengthOfFilter - 1) / 2, y - i + (lengthOfFilter - 1) / 2].Blue);
                            }
                        }
                    }

                    if (red > byte.MaxValue)
                    {
                        red = byte.MaxValue;
                    }
                    else if (red < byte.MinValue)
                    {
                        red = byte.MinValue;
                    }

                    if (green > byte.MaxValue)
                    {
                        green = byte.MaxValue;
                    }
                    else if (green < byte.MinValue)
                    {
                        green = byte.MinValue;
                    }

                    if (blue > byte.MaxValue)
                    {
                        blue = byte.MaxValue;
                    }
                    else if (blue < byte.MinValue)
                    {
                        blue = byte.MinValue;
                    }

                    bitmap.SetPixel(x, y, Color.FromArgb((byte)red, (byte)green, (byte)blue));
                }
            }

            return bitmap;
        }

        //나중에 삭제
        //public static double[,] Convolve2D(double[,] signal, double[,] filter)
        //{
        //    var convolved2D = new double[signal.GetLength(0), signal.GetLength(1)];

        //    for (int x = 0; x < signal.GetLength(0); ++x)
        //    {
        //        for (int y = 0; y < signal.GetLength(1); ++y)
        //        {
        //            for (int i = 0; i < filter.GetLength(0); ++i)
        //            {
        //                for (int j = 0; j < filter.GetLength(0); ++j)
        //                {
        //                    if (x - j + (filter.GetLength(0) - 1) / 2 >= 0 && x - j + (filter.GetLength(0) - 1) / 2 < signal.GetLength(0)
        //                        && y - i + (filter.GetLength(0) - 1) / 2 >= 0 && y - i + (filter.GetLength(0) - 1) / 2 < signal.GetLength(1))
        //                    {
        //                        convolved2D[x, y] += filter[j, i] * signal[x - j + (filter.GetLength(0) - 1) / 2, y - i + (filter.GetLength(0) - 1) / 2];
        //                    }
        //                }
        //            }

        //        }
        //    }

        //    return convolved2D;

        //}
    }
}
