using System.Collections.Generic;

namespace Lab7
{
    public static class FilterEngine
    {
        private static List<Frame> mFilterFrames;
        private static List<Frame> mFilterOutFrames;

        public static List<Frame> FilterFrames(List<Frame> frames, EFeatureFlags features)
        {
            mFilterFrames = new List<Frame>(frames.Count);
            mFilterOutFrames = new List<Frame>(frames.Count);

            foreach (var i in frames)
            {
                if ((i.Features & features) != default)
                {
                    mFilterFrames.Add(i);
                }
                else
                {
                    mFilterOutFrames.Add(i);
                }
            }

            return mFilterFrames;
        }

        public static List<Frame> FilterOutFrames(List<Frame> frames, EFeatureFlags features)
        {
            FilterFrames(frames, features);
            return mFilterOutFrames;
        }

        public static List<Frame> Intersect(List<Frame> frames1, List<Frame> frames2)
        {
            List<Frame> intersectList = new List<Frame>();

            foreach (var i in frames1)
            {
                foreach (var j in frames2)
                {
                    if (i.Name == j.Name)
                    {
                        intersectList.Add(i);
                    }
                }
            }

            return intersectList;
        }

        public static List<int> GetSortKeys(List<Frame> frames, List<EFeatureFlags> features)
        {
            Dictionary<EFeatureFlags, int> framesWithScore = new Dictionary<EFeatureFlags, int>(features.Count);
            List<int> listForScore = new List<int>(frames.Count);

            int count = 1;
            for (int i = features.Count - 1; i >= 0; --i)
            {
                framesWithScore.TryAdd(features[i], count);
                count *= 2;
            }

            foreach (var i in frames)
            {
                int inclementValue = 0;
                foreach (var j in framesWithScore)
                {
                    if ((i.Features & j.Key) != default)
                    {
                        inclementValue += j.Value;
                    }
                }
                listForScore.Add(inclementValue);
            }

            return listForScore;
        }
    }
}