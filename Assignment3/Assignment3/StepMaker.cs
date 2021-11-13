using System;
using System.Collections.Generic;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            //int depth = 0;
            //var newSteps = new List<int>();
            //newSteps.Add(steps[0]);

            //for (int index = 0; index < steps.Length - 1; ++index)
            //{
            //    if (Math.Abs(steps[index] - steps[index + 1]) > 10)
            //    {
            //        newSteps.Add(steps[index + 1]);
            //        MakeStepsRecursive(newSteps, noise, index, depth);
            //    }
            //    else
            //    {
            //        newSteps.Add(steps[index + 1]);
            //    }
            //}

            int depth = 0;
            var newStepsWithDepth = new List<Tuple<int, int>>();

            newStepsWithDepth.Add(new Tuple<int, int>(steps[0], depth));

            for (int index = 0; index < steps.Length - 1; ++index)
            {
                if (Math.Abs(steps[index] - steps[index + 1]) > 10)
                {
                    newStepsWithDepth.Add(new Tuple<int, int>(steps[index + 1], depth));
                    MakeStepsRecursive(newStepsWithDepth, noise, newStepsWithDepth.Count - 2, depth);
                }
                else
                {
                    newStepsWithDepth.Add(new Tuple<int, int>(steps[index + 1], depth));
                }

            }

            var newSteps = new List<int>(newStepsWithDepth.Count);
            foreach (var i in newStepsWithDepth)
            {
                newSteps.Add(i.Item1);
            }

            return newSteps;
        }

        public static List<Tuple<int, int>> MakeStepsRecursive(List<Tuple<int, int>> newStepsWithDepth, INoise noise, int index, int depth)
        {

            if (index >= newStepsWithDepth.Count - 1)
            {
                return newStepsWithDepth;
            }

            //if (Math.Abs(newStepsWithDepth[index].Item1 - newStepsWithDepth[index + 1].Item1) < 11)
            //{
            //    return MakeStepsRecursive(newStepsWithDepth, noise, index, newStepsWithDepth[index].Item2 + 1);
            //}

            if (Math.Abs(newStepsWithDepth[index].Item1 - newStepsWithDepth[index + 1].Item1) > 10)
            {

                int a = newStepsWithDepth[index].Item1;
                int b = newStepsWithDepth[index + 1].Item1;

                newStepsWithDepth.Insert(index + 1, new Tuple<int, int>((a * 8 + b * 2) / 10 + noise.GetNext(depth), depth));
                newStepsWithDepth.Insert(index + 2, new Tuple<int, int>((a * 6 + b * 4) / 10 + noise.GetNext(depth), depth));
                newStepsWithDepth.Insert(index + 3, new Tuple<int, int>((a * 4 + b * 6) / 10 + noise.GetNext(depth), depth));
                newStepsWithDepth.Insert(index + 4, new Tuple<int, int>((a * 2 + b * 8) / 10 + noise.GetNext(depth), depth));

            }
            for (int i = index; i < index + 5; ++i)
            {
                if (i >= newStepsWithDepth.Count - 1)
                {
                    return newStepsWithDepth;
                }
                if (Math.Abs(newStepsWithDepth[i].Item1 - newStepsWithDepth[i + 1].Item1) > 10)
                {
                    //MakeStepsRecursive(newStepsWithDepth, noise, i, newStepsWithDepth[i].Item2 + 1);
                    MakeStepsRecursive(newStepsWithDepth, noise, i, ++depth);
                }

            }

            //if (index + 5 < newStepsWithDepth.Count - 1)
            //{
            //    index += 5;
            //    MakeStepsRecursive(newStepsWithDepth, noise, index, newStepsWithDepth[index].Item2 + 1);
            //}

            if (index + 5 < newStepsWithDepth.Count - 1)
            {
                index += 5;
                for (int i = index; i < newStepsWithDepth.Count - 1; ++i)
                {
                    if (Math.Abs(newStepsWithDepth[i].Item1 - newStepsWithDepth[i + 1].Item1) > 10)
                        MakeStepsRecursive(newStepsWithDepth, noise, i, newStepsWithDepth[i].Item2 + 1);
                }

            }

            return newStepsWithDepth;

            //for (int i = index; i < index + 5; ++i)
            //{
            //    if ( i >= newStepsWithDepth.Count -1)
            //    {
            //        break;
            //    }
            //    if (Math.Abs(newStepsWithDepth[i].Item1 - newStepsWithDepth[i + 1].Item1) > 10)
            //    {
            //         MakeStepsRecursive(newStepsWithDepth, noise, index, ++depth);
            //    }
            //}

            //if (index + 5 < newStepsWithDepth.Count - 1)
            //{
            //    index += 5;
            //    MakeStepsRecursive(newStepsWithDepth, noise, index, newStepsWithDepth[index].Item2 + 1);
            //}

            //return newStepsWithDepth;


        }
        //            if (index >= newSteps.Count - 1)
        //            {
        //                return newSteps;
        //            }

        //            int a = newSteps[index];
        //            int b = newSteps[index + 1];

        //            newSteps.Insert(index + 1, (a * 8 + b * 2) / 10 + noise.GetNext(depth));
        //            newSteps.Insert(index + 2, (a * 6 + b * 4) / 10 + noise.GetNext(depth));
        //            newSteps.Insert(index + 3, (a * 4 + b * 6) / 10 + noise.GetNext(depth));
        //            newSteps.Insert(index + 4, (a * 2 + b * 8) / 10 + noise.GetNext(depth));

        //            //for (int i = index; i < index + 5; ++i)
        //            //{
        //            //    if (Math.Abs(newSteps[i] - newSteps[i + 1]) > 10)
        //            //    {
        //            //        MakeStepsRecursive(newSteps, noise, index, ++depth);
        //            //    }
        //            //}
        //\
        //            //index += 5;
        //            //MakeStepsRecursive(newSteps, noise, index, --depth);

        //            return newSteps;


        public static List<int> MakeStepsRecursive2(List<int> newSteps, INoise noise, int index, int depth)
        {
            ++depth;

            int a = newSteps[index];
            int b = newSteps[index + 1];

            newSteps.Insert(index + 1, a * 8 / 10 + b * 2 / 10 + noise.GetNext(depth));
            newSteps.Insert(index + 2, a * 6 / 10 + b * 4 / 10 + noise.GetNext(depth));
            newSteps.Insert(index + 3, a * 4 / 10 + b * 6 / 10 + noise.GetNext(depth));
            newSteps.Insert(index + 4, a * 2 / 10 + b * 8 / 10 + noise.GetNext(depth));

            for (int i = index; i < index + 5; ++i)
            {
                if (Math.Abs(newSteps[i] - newSteps[i + 1]) > 10)
                {
                    MakeStepsRecursive2(newSteps, noise, index, depth);
                }
            }

            return newSteps;
        }

    }
}

// 100 365
// 100, {153, 206, 259, 312}, 365 , d = 0
// 100, {111, 122, 132, 143, 153}, 206, 259, 312, 365, d = 1
// 100, {104, 106, 108, 110}, 111, 122, 132, 143, 153, 206, 259, 312, 365, d= 2
// 100, 104, 106, 108, 110, 111, {115, 117, 119, 121}, 122, 132, 143, 153, 206, 259, 312, 365, d= 2


#region: 선형보간 미스 or..
//int diff = Math.Abs(newSteps[index + 1] - newSteps[index]);
//float[] increments = new float[4] { diff * 0.2f, diff * 0.4f, diff * 0.6f, diff * 0.8f };

//if (newSteps[index] > newSteps[index + 1])
//{
//    newSteps.Insert(index + 1, (int)(newSteps[index + 1] + increments[3]) + noise.GetNext(depth));
//    newSteps.Insert(index + 2, (int)(newSteps[index + 2] + increments[2]) + noise.GetNext(depth));
//    newSteps.Insert(index + 3, (int)(newSteps[index + 3] + increments[1]) + noise.GetNext(depth));
//    newSteps.Insert(index + 4, (int)(newSteps[index + 4] + increments[0]) + noise.GetNext(depth));
//}   
//else
//{
//    newSteps.Insert(index + 1, (int) (newSteps[index] + increments[0]) + noise.GetNext(depth));
//    newSteps.Insert(index + 2, (int) (newSteps[index] + increments[1]) + noise.GetNext(depth));
//    newSteps.Insert(index + 3, (int) (newSteps[index] + increments[2]) + noise.GetNext(depth));
//    newSteps.Insert(index + 4, (int) (newSteps[index] + increments[3]) + noise.GetNext(depth));
//}

//newSteps.Insert(index + 1, (int)(a * 0.8 + b * 0.2) + noise.GetNext(depth));
//newSteps.Insert(index + 2, (int)(a * 0.6 + b * 0.4) + noise.GetNext(depth));
//newSteps.Insert(index + 3, (int)(a * 0.4 + b * 0.6) + noise.GetNext(depth));
//newSteps.Insert(index + 4, (int)(a * 0.2 + b * 0.8) + noise.GetNext(depth));

#endregion