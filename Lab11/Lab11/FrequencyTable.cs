using System;
using System.Collections.Generic;

namespace Lab11
{
    public static class FrequencyTable
    {
        public static List<Tuple<Tuple<int, int>, int>> GetFrequencyTable(int[] data, int maxBinCount)
        {
            var dataList = new List<int>(data);
            dataList.Sort();

            int minValue = dataList[0];
            int maxValue = dataList[dataList.Count - 1];
            int binWidth = (int)Math.Round((maxValue - minValue) / (double)maxBinCount);

            if (binWidth < 1)
            {
                binWidth = 1;
            }

            if (minValue + binWidth * maxBinCount <= maxValue)
            {
                binWidth += 1;
            }

            var ranges = new List<Tuple<int, int>>(maxBinCount);

            for (int i = 0, j = minValue; i < maxBinCount; ++i, j += binWidth)
            {
                if (j <= maxValue)
                {
                    ranges.Add(new Tuple<int, int>(j, j + binWidth));
                }
            }

            var frequencyTable = new List<Tuple<Tuple<int, int>, int>>(ranges.Count);

            int indexOfList = 0;
            for (int i = 0; i < ranges.Count; ++i)
            {
                int count = 0;
                for (int j = indexOfList; j < dataList.Count; ++j)
                {
                    if (dataList[j] >= ranges[i].Item1 && dataList[j] < ranges[i].Item2)
                    {
                        count += 1;
                    }
                    else
                    {
                        frequencyTable.Add(new Tuple<Tuple<int, int>, int>(ranges[i], count));
                        indexOfList = j;
                        break;
                    }

                    if (j == dataList.Count - 1)
                    {
                        frequencyTable.Add(new Tuple<Tuple<int, int>, int>(ranges[i], count));
                        break;
                    }
                }
            }

            return frequencyTable;
        }
    }
}