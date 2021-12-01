using System.Drawing;
using System;

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
            
            return null;
        }
    }
}