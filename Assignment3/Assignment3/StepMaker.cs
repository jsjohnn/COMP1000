using System;
using System.Collections.Generic;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            List<int> newSteps = new List<int>(1024);
            //newSteps.AddRange(steps);

            for (int i = 0; i < steps.Length - 1; ++i)
            {
                var tempList = new List<int>(1024);
                if (Math.Abs(steps[i] - steps[i + 1]) > 10)
                {
                    tempList.Add(steps[i]);
                    tempList.Add(steps[i + 1]);
                    tempList = AddStepsRecursive(tempList, 0, 0, noise);
                    
                }
                else if (tempList.Count == 0 || (tempList[tempList.Count -1] != steps[i]))
                {
                    newSteps.Add(steps[i]);
                }
                newSteps.AddRange(tempList);
            }

            if (Math.Abs(steps[steps.Length -2] - steps[steps.Length -1]) < 11)
            {
                newSteps.Add(steps[steps.Length - 1]);
            }
            //newSteps.Add(steps[steps.Length - 1]);

            return newSteps;
        }

        private static List<int> AddStepsRecursive(List<int> newSteps, int index, int depth, INoise noise)
        {
            if (index >= newSteps.Count - 1)
            {
                return newSteps;
            }

            
            if (Math.Abs(newSteps[index] - newSteps[index + 1]) < 11)
            {
                AddStepsRecursive(newSteps, ++index, depth, noise);
                return newSteps;
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

            if (Math.Abs(newSteps[index] - newSteps[index + 1]) > 10)
            {
                AddStepsRecursive(newSteps, index, ++depth, noise);
            }
            else
            {
                AddStepsRecursive(newSteps, ++index, depth, noise);
            }

            //AddStepsRecursive(newSteps, index + 5, depth, noise);

            return newSteps;
        }


        #region cosineFail
        //private static List<int> AddStepsRecursive(List<int> steps, INoise noise, int index, int depth)
        //{
        //    if (index >= steps.Count - 1)
        //    {
        //        return null;
        //    }

        //    if (Math.Abs(steps[index + 1] - steps[index]) < 11)
        //    {
        //        AddStepsRecursive(steps, noise, ++index, depth);
        //        return null;
        //    }

        //    int diff = Math.Abs(steps[index + 1] - steps[index]);

        //    //int[] increments = new int[4] {(int)(diff *  0.2), (int)(diff * 0.4), (int)(diff * 0.6), (int)(diff * 0.8)};
        //    float[] increments = new float[4] { diff * 0.2f, diff * 0.4f, diff * 0.6f, diff * 0.8f };

        //    if (steps[index] > steps[index + 1])
        //    {
        //        steps.Insert(index + 1, (int)(steps[index + 1] + increments[3]) + noise.GetNext(depth));
        //        steps.Insert(index + 2, (int)(steps[index + 2] + increments[2]) + noise.GetNext(depth));
        //        steps.Insert(index + 3, (int)(steps[index + 3] + increments[1]) + noise.GetNext(depth));
        //        steps.Insert(index + 4, (int)(steps[index + 4] + increments[0]) + noise.GetNext(depth));

        //    }
        //    else
        //    {
        //        steps.Insert(index + 1, (int)(steps[index] + increments[0]) + noise.GetNext(depth));
        //        steps.Insert(index + 2, (int)(steps[index] + increments[1]) + noise.GetNext(depth));
        //        steps.Insert(index + 3, (int)(steps[index] + increments[2]) + noise.GetNext(depth));
        //        steps.Insert(index + 4, (int)(steps[index] + increments[3]) + noise.GetNext(depth));
        //    }

        //    AddStepsRecursive(steps, noise, 0, ++depth);
        //    AddStepsRecursive(steps, noise, index + 5, depth);

        //    return steps;
        //}
        #endregion
        #region second
        //private static List<int> AddSteps(List<int> nums, int index, INoise noise, int depth)
        //{
        //    if (index == nums.Count - 1)
        //    {
        //        return null;
        //    }

        //    if (Math.Abs(nums[index + 1] - nums[index]) < 11)
        //    {
        //        AddSteps(nums, ++index, noise, depth);

        //        return null;
        //    }

        //    //int dif = Math.Abs(nums[index + 1] - nums[index]);
        //    int dif = nums[index + 1] - nums[index];
        //    int[] increments = new int[4] { (int)(dif * 0.2f), (int)(dif * 0.4f), (int)(dif * 0.6f), (int)(dif * 0.8f) };

        //    nums.Insert(index + 1, nums[index] + increments[0] + noise.GetNext(depth));
        //    nums.Insert(index + 2, nums[index] + increments[1] + noise.GetNext(depth));
        //    nums.Insert(index + 3, nums[index] + increments[2] + noise.GetNext(depth));
        //    nums.Insert(index + 4, nums[index] + increments[3] + noise.GetNext(depth));

        //    return AddSteps(nums, index, noise, ++depth);

        //}
        #endregion
        #region first
        // 호출 시 (메인 내)
        //for (int i = 0; i < newSteps.Count; ++i)
        //{
        //    AddSteps(newSteps, 0, noise, i);
        //}



        // 재귀 구현부
        //private static List<int> AddSteps(List<int> newSteps, int index, INoise noise, int depth)
        //{
        //    if (index == newSteps.Count - 1)
        //    {
        //        return null;
        //    }

        //    if (newSteps[index + 1] - newSteps[index] < Math.Abs(11))
        //    {
        //        return AddSteps(newSteps, ++index, noise, depth);
        //    }

        //    int diff = newSteps[index + 1] - newSteps[index];
        //    int[] increments = new int[4] { (int)(diff * 0.2f), (int)(diff * 0.4f), (int)(diff * 0.6f), (int)(diff * 0.8f) };

        //    newSteps.Insert(index + 1, newSteps[index] + increments[0] + noise.GetNext(depth));
        //    newSteps.Insert(index + 2, newSteps[index] + increments[1] + noise.GetNext(depth));
        //    newSteps.Insert(index + 3, newSteps[index] + increments[2] + noise.GetNext(depth));
        //    newSteps.Insert(index + 4, newSteps[index] + increments[3] + noise.GetNext(depth));

        //    return newSteps;
        //}

        #endregion

    }
}

// 100, 102, 112, 115, 116, 117, 117, 123, 122, 124, 128, 132, 138, 139, 143, 146, 151, 151, 161, 170 
// 100, 102, 112, 115, 116, 117, 117, 123, 122, 125, 128, 130, 138, 136, 139, 141, 144, 151, 161, 170