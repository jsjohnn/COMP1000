using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public sealed class MultiSet
    {
        public List<string> Sets = new List<string>(1024);

        public MultiSet()
        {
        }
        public MultiSet(List<string> elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }
        public void Add(string element)
        {
            Sets.Add(element);
        }

        public bool Remove(string element)
        {
            foreach (var set in Sets)
            {
                if (set == element)
                {
                    Sets.Remove(set);
                    return true;
                }
            }

            return false;
        }

        public uint GetMultiplicity(string element)
        {
            uint multiplicityCount = 0;

            foreach (var set in Sets)
            {
                if (set == element)
                {
                    ++multiplicityCount;
                }
            }

            return multiplicityCount;
        }

        public List<string> ToList()
        {
            Sets.Sort();
            return Sets;
        }

        public MultiSet Union(MultiSet other)
        {
            MultiSet union = new MultiSet();

            // other = {d,d,h,l}
            // Sets = {}

            foreach (var set in Sets)
            {
                union.Add(set);
            }

            foreach (var set in other.Sets)
            {
                if (!union.Sets.Contains(set))
                {
                    union.Add(set);
                    continue;
                }

                int temp1 = (int)GetMultiplicity(set); // 0
                int temp2 = (int)other.GetMultiplicity(set); // 2

                if (temp1 >= temp2)
                {
                    continue;
                }

                int addSetCount = temp2 - temp1;

                for (int i = 0; i < addSetCount - 1; ++i)
                {
                    union.Add(set);
                }
            }
            union.Sets.Sort();
            return union;
        }

        public MultiSet Intersect(MultiSet other)
        {
            MultiSet intersect = new MultiSet();

            foreach (var set in Sets)
            {
                if (!other.Sets.Contains(set) || intersect.Sets.Contains(set))
                {
                    continue;
                }

                int temp1 = (int)GetMultiplicity(set);
                int temp2 = (int)other.GetMultiplicity(set);

                if (temp1 <= temp2)
                {
                    for (int i = 0; i < temp1; ++i)
                    {
                        intersect.Add(set);
                    }
                }
                else
                {
                    for (int i = 0; i < temp2; ++i)
                    {
                        intersect.Add(set);
                    }
                }
            }

            intersect.Sets.Sort();
            return intersect;
        }

        public MultiSet Subtract(MultiSet other)
        {
            MultiSet subtract = new MultiSet();

            foreach (var set in Sets)
            {
                int temp1 = (int)GetMultiplicity(set);
                int temp2 = (int)other.GetMultiplicity(set);

                if (!other.Sets.Contains(set) && !subtract.Sets.Contains(set))
                {
                    for (int i = 0; i < temp1; ++i)
                    {
                        subtract.Add(set);
                    }
                }
                else if (other.Sets.Contains(set) && !subtract.Sets.Contains(set))
                {
                    if (temp2 >= temp1)
                    {
                        continue;
                    }

                    for (int i = 0; i < temp1 - temp2; ++i)
                    {
                        subtract.Add(set);
                    }
                }
                // else 조건은 없어도 상관없기 때문에 생략
            }
            subtract.Sets.Sort();
            return subtract;
        }

        public List<MultiSet> FindPowerSet()
        {
            List<MultiSet> powerSets = new List<MultiSet>();
            powerSets.Add(new MultiSet());

            int[] flag = new int[Sets.Count];
            int index = 0;

            toMakePowerset(powerSets, Sets, flag, index);


            return powerSets;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            return false;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            return false;
        }

        private void toMakePowerset(List<MultiSet> powerSets, List<string> inputs, int[] flags, int index)
        {
            if (index == inputs.Count)
            {
                List<string> temps = new List<string>();

                for (int i = 0; i < flags.Length; i++)
                {
                    if (flags[i] == 1)
                    {
                        temps.Add(inputs[i]);
                    }
                }
                temps.Sort();

                bool bDuplicateCheck = false;
                foreach (var powerset in powerSets)
                {
                    if (powerset.Sets.SequenceEqual(temps))
                    {
                        bDuplicateCheck = true;
                        break;
                    }
                }
                if (!bDuplicateCheck)
                {
                    powerSets.Add(new MultiSet(temps));
                }

                temps.Clear();

                return;
            }

            flags[index] = 1;
            toMakePowerset(powerSets, inputs, flags, index + 1);

            flags[index] = 0;
            toMakePowerset(powerSets, inputs, flags, index + 1);
        }

    }
}