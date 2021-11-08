//using System.Collections.Generic;

//namespace Lab7
//{
//    public static class FilterEngine
//    {
//        private static List<Frame> mFilterFrames;
//        private static List<Frame> mFilterOutFrames;

//        public static List<Frame> FilterFrames(List<Frame> frames, EFeatureFlags features)
//        {
//            mFilterFrames = new List<Frame>(frames.Count);
//            mFilterOutFrames = new List<Frame>(frames.Count);

//            foreach (var frame in frames)
//            {
//                if ((frame.Features & features) != default)
//                {
//                    mFilterFrames.Add(frame);
//                }
//                else
//                {
//                    mFilterOutFrames.Add(frame);
//                }
//            }

//            return mFilterFrames;
//        }

//        public static List<Frame> FilterOutFrames(List<Frame> frames, EFeatureFlags features)
//        {
//            FilterFrames(frames, features);
//            return mFilterOutFrames;
//        }

//        public static List<Frame> Intersect(List<Frame> frames1, List<Frame> frames2)
//        {
//            var intersectList = new List<Frame>();

//            foreach (var frame1 in frames1)
//            {
//                foreach (var frame2 in frames2)
//                {
//                    if (frame1.Name == frame2.Name)
//                    {
//                        intersectList.Add(frame1);
//                    }
//                }
//            }

//            return intersectList;
//        }

//        public static List<int> GetSortKeys(List<Frame> frames, List<EFeatureFlags> features)
//        {
//            var featuresWithScore = new Dictionary<EFeatureFlags, int>(features.Count);
//            var scoreOfFrames = new List<int>(frames.Count);

//            int count = 1;
//            for (int i = features.Count - 1; i >= 0; --i)
//            {
//                featuresWithScore.TryAdd(features[i], count);
//                count <<= 2;
//            }

//            foreach (var frame in frames)
//            {
//                int inclementValue = 0;
//                foreach (var featureWithScore in featuresWithScore)
//                {
//                    if ((frame.Features & featureWithScore.Key) != default)
//                    {
//                        inclementValue += featureWithScore.Value;
//                    }
//                }
//                scoreOfFrames.Add(inclementValue);
//            }

//            return scoreOfFrames;
//        }
//    }
//}

using System.Collections.Generic;
using System;

namespace Lab7
{
    public static class FilterEngine
    {
        public static List<Frame> FilterFrames(List<Frame> frames, EFeatureFlags features)
        {
            List<Frame> outputFrames = new List<Frame>(frames.Count);

            foreach (var frame in frames)
            {
                if ((frame.Features & features) != 0)
                {
                    outputFrames.Add(frame);
                }
            }

            return outputFrames;
        }

        public static List<Frame> FilterOutFrames(List<Frame> frames, EFeatureFlags features)
        {
            List<Frame> outputFrames = new List<Frame>(frames.Count);

            foreach (var frame in frames)
            {
                if ((frame.Features & features) == 0)
                {
                    outputFrames.Add(frame);
                }
            }

            return outputFrames;
        }

        public static List<Frame> Intersect(List<Frame> frames1, List<Frame> frames2)
        {
            int capacity = frames1.Count < frames2.Count ? frames1.Count : frames2.Count;

            List<Frame> outputFrames = new List<Frame>(capacity);

            foreach (var frame in frames1)
            {
                uint frameID = frame.ID;
                foreach (var comparingFrame in frames2)
                {
                    if ((frameID ^ comparingFrame.ID) == 0)
                    {
                        outputFrames.Add(frame);
                        break;
                    }
                }
            }

            return outputFrames;
        }

        public static List<int> GetSortKeys(List<Frame> frames, List<EFeatureFlags> features)
        {
            List<int> keys = new List<int>(frames.Count);

            foreach (var frame in frames)
            {
                EFeatureFlags frameFeatures = frame.Features;

                int priority = 0;
                int key = 0;
                foreach (var feature in features)
                {
                    if ((frameFeatures & feature) != 0)
                    {
                        key |= 1 << (30 - priority);
                    }

                    ++priority;
                }

                keys.Add(key);
            }

            for (int i = 0; i < keys.Count; ++i)
            {
                Console.WriteLine(keys[i]);
            }
            return keys;
        }
    }
}