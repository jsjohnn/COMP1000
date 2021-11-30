using System;
using System.Collections.Generic;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            int depth = 0;
            var stepsWithDepth = new List<Tuple<int, int>>();

            stepsWithDepth.Add(new Tuple<int, int>(steps[0], depth));

            for (int index = 0; index < steps.Length - 1; ++index)
            {
                stepsWithDepth.Add(new Tuple<int, int>(steps[index + 1], depth));

                if (Math.Abs(steps[index] - steps[index + 1]) > 10)
                {
                    MakeStepsRecursive(stepsWithDepth, noise, stepsWithDepth.Count - 2, depth);
                }
            }
            var newSteps = new List<int>(stepsWithDepth.Count);
            foreach (var i in stepsWithDepth)
            {
                newSteps.Add(i.Item1);
            }

            return newSteps;
        }

        public static List<Tuple<int, int>> MakeStepsRecursive(List<Tuple<int, int>> stepsWithDepth, INoise noise, int index, int depth)
        {

            if (index >= stepsWithDepth.Count - 1)
            {
                return stepsWithDepth;
            }

            if (Math.Abs(stepsWithDepth[index].Item1 - stepsWithDepth[index + 1].Item1) > 10)
            {
                int leftMost = stepsWithDepth[index].Item1;
                int rightMost = stepsWithDepth[index + 1].Item1;

                stepsWithDepth.Insert(index + 1, new Tuple<int, int>((leftMost * 8 + rightMost * 2) / 10 + noise.GetNext(depth), depth));
                stepsWithDepth.Insert(index + 2, new Tuple<int, int>((leftMost * 6 + rightMost * 4) / 10 + noise.GetNext(depth), depth));
                stepsWithDepth.Insert(index + 3, new Tuple<int, int>((leftMost * 4 + rightMost * 6) / 10 + noise.GetNext(depth), depth));
                stepsWithDepth.Insert(index + 4, new Tuple<int, int>((leftMost * 2 + rightMost * 8) / 10 + noise.GetNext(depth), depth));
            }
            for (int i = index; i < index + 5; ++i)
            {
                if (i >= stepsWithDepth.Count - 1)
                {
                    return stepsWithDepth;
                }

                if (Math.Abs(stepsWithDepth[i].Item1 - stepsWithDepth[i + 1].Item1) > 10)
                {
                    MakeStepsRecursive(stepsWithDepth, noise, i, ++depth);
                }
            }

            if (index + 5 < stepsWithDepth.Count - 1)
            {
                index += 5;
                for (int i = index; i < stepsWithDepth.Count - 1; ++i)
                {
                    if (Math.Abs(stepsWithDepth[i].Item1 - stepsWithDepth[i + 1].Item1) > 10)
                    {
                        MakeStepsRecursive(stepsWithDepth, noise, i, stepsWithDepth[i].Item2 + 1);
                    }
                }
            }
            return stepsWithDepth;
        }
    }
}