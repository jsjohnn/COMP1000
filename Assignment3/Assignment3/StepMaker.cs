using System.Collections.Generic;
using System;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, ref INoise noise)
        {
            //List<int> newSteps = new List<int>();
            //newSteps.AddRange(steps);
            //AddSteps(newSteps, 0, noise, 0);
            //return newSteps;

            return null;
        }

        private static List<int> AddSteps(List<int> nums, int index, INoise noise, int depth)
        {
            // { 100, 102, 112, 170 }

            if (index == nums.Count - 1)
            {
                return null;
            }

            if (nums[index + 1] - nums[index] < 11)
            {
                // return AddSteps(//) 인 경우 돌아가는지 확인
                AddSteps(nums, ++index, noise, ++depth);
                return null;
            }

            
            int dif = nums[index + 1] - nums[index];
            int[] increments = new int[4] { (int)(dif * 0.2f), (int)(dif * 0.4f), (int)(dif * 0.6f), (int)(dif * 0.8f) };
            
            nums.Insert(index + 1, nums[index] + increments[0] + noise.GetNext(depth));
            nums.Insert(index + 2, nums[index] + increments[1] + noise.GetNext(depth));
            nums.Insert(index + 3, nums[index] + increments[2] + noise.GetNext(depth));
            nums.Insert(index + 4, nums[index] + increments[3] + noise.GetNext(depth));
            
            return AddSteps(nums, index, noise, ++depth);
        }
    }
}