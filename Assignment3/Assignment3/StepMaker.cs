using System;
using System.Collections.Generic;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            var newSteps = new List<int>(1024);

            for (int i = 0; i < steps.Length - 1; ++i)
            {
                var tempList = new List<int>(1024);
                if (Math.Abs(steps[i] - steps[i + 1]) > 11)
                {
                    tempList.Add(steps[i]);
                    tempList.Add(steps[i + 1]);
                    tempList = MakeStepsRecursive(tempList, noise, 0, 0);
                    newSteps.AddRange(tempList);

                }
                else if (newSteps.Count == 0 || (newSteps.Count != 0 && newSteps[newSteps.Count - 1] != steps[i]))
                {
                    newSteps.Add(steps[i]);
                }
                else if (i == steps.Length - 2)
                {
                    newSteps.Add(steps[steps.Length - 1]);
                }
            }

            return newSteps;
        }

        public static List<int> MakeStepsRecursive(List<int> newSteps, INoise noise, int index, int depth)
        {
            if (index > newSteps.Count - 2)
            {
                return newSteps;
            }

            if (Math.Abs(newSteps[index] - newSteps[index + 1]) < 11)
            {
                return MakeStepsRecursive(newSteps, noise, ++index, depth);
            }

            int diff = Math.Abs(newSteps[index + 1] - newSteps[index]);

            float[] increments = new float[4] { diff * 0.2f, diff * 0.4f, diff * 0.6f, diff * 0.8f };

            if (newSteps[index] > newSteps[index + 1])
            {
                newSteps.Insert(index + 1, (int)(newSteps[index + 1] + increments[3]) + noise.GetNext(depth));
                newSteps.Insert(index + 2, (int)(newSteps[index + 2] + increments[2]) + noise.GetNext(depth));
                newSteps.Insert(index + 3, (int)(newSteps[index + 3] + increments[1]) + noise.GetNext(depth));
                newSteps.Insert(index + 4, (int)(newSteps[index + 4] + increments[0]) + noise.GetNext(depth));

            }
            else
            {
                newSteps.Insert(index + 1, (int)(newSteps[index] + increments[0]) + noise.GetNext(depth));
                newSteps.Insert(index + 2, (int)(newSteps[index] + increments[1]) + noise.GetNext(depth));
                newSteps.Insert(index + 3, (int)(newSteps[index] + increments[2]) + noise.GetNext(depth));
                newSteps.Insert(index + 4, (int)(newSteps[index] + increments[3]) + noise.GetNext(depth));
            }

            if (Math.Abs(newSteps[index] - newSteps[index + 1]) < 11)
            {
                MakeStepsRecursive(newSteps, noise, ++index, depth);
            }
            else
            {
                MakeStepsRecursive(newSteps, noise, index, ++depth);
            }

            return newSteps;
        }
    }
}