using System;
using System.Collections.Generic;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            List<int> newSteps = new List<int>(steps.Length);
            newSteps.AddRange(steps);

            //AddStepsRecursive(newSteps, noise, 0, 0);
            return newSteps;
        }

        
        


        #region cosineFail
        //private static List<int> AddStepsRecursive(List<int> steps, INoise noise, int index, int depth)
        //{
        //    if (index >= steps.Count -1)
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

        //    if (steps[index] > steps[index+1])
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

        //    AddStepsRecursive(steps, noise, index + 5, depth);
        //    AddStepsRecursive(steps, noise, 0, ++depth);

        //    return steps;
        }
        #endregion

        // 100, {157, 207, 256, 305}, 360 -> d:0
        // 100, {107, 117, 130, 142}, 157, 207, 256, 305, 360 -> d:1
        // 100, 107, 117, 130, 142, 157, {166, 177, 188, 200} 207, 256, 305, 360 -> d:1


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