using System;
using System.Drawing;

namespace Assignment4
{
    public static class SignalProcessor
    {
        public static double[] GetGaussianFilter1D(double sigma)
        {
            int filterLength = (int)Math.Ceiling(sigma * 6);

            if (filterLength % 2 == 0)
            {
                filterLength += 1;
            }

            var gaussianFilter1D = new double[filterLength];
            int midIndex = (int)(filterLength / 2 + 0.5);

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
            int filterLength = (int)Math.Ceiling(sigma * 6);

            if (filterLength % 2 == 0)
            {
                filterLength += 1;
            }

            var gaussianFilter2D = new double[filterLength, filterLength];
            int midIndex = (int)(filterLength / 2 + 0.5);

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
            Bitmap output = new Bitmap(bitmap.Width, bitmap.Height);

            Rgb[,] input = new Rgb[bitmap.Width, bitmap.Height];

            for (int i = 0; i < input.GetLength(0); ++i)
            {
                for (int j = 0; j < input.GetLength(1); ++j)
                {
                    input[i, j] = new Rgb(bitmap.GetPixel(i, j));
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
                            }
                        }
                    }

                    if (red > byte.MaxValue)
                    {
                        red = byte.MaxValue;
                    }
                    //else if (red < byte.MinValue)
                    //{
                    //    red = byte.MinValue;
                    //}

                    if (green > byte.MaxValue)
                    {
                        green = byte.MaxValue;
                    }
                    //else if (green < byte.MinValue)
                    //{
                    //    green = byte.MinValue;
                    //}

                    if (blue > byte.MaxValue)
                    {
                        blue = byte.MaxValue;
                    }
                    //else if (blue < byte.MinValue)
                    //{
                    //    blue = byte.MinValue;
                    //}

                    output.SetPixel(x, y, Color.FromArgb((byte)red, (byte)green, (byte)blue));
                }
            }
            
            return output;
        }
    }
}

