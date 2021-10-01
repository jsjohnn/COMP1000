using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    public sealed class MultiSet
    {
        public List<string> Sets = new List<string>(1024);

        public MultiSet()
        {
        }

        private MultiSet(List<string> elements)
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

            foreach (var set in Sets)
            {
                if (union.Sets.Contains(set))
                {
                    continue;
                }

                uint thisSets = GetMultiplicity(set);
                uint otherSets = other.GetMultiplicity(set);

                uint maxValue = thisSets >= otherSets ? thisSets : otherSets;

                for (uint i = 0; i < maxValue; ++i)
                {
                    union.Add(set);
                }
            }

            foreach (var set in other.Sets)
            {
                if (union.Sets.Contains(set))
                {
                    continue;
                }

                uint multiplicity = other.GetMultiplicity(set);

                for (uint i = 0; i < multiplicity; ++i)
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
            toSortMultisetList(powerSets);

            return powerSets;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            //bool bCheck = true;

            foreach (var set in Sets)
            {
                if (!other.Sets.Contains(set))
                {
                    return false;
                }
                else
                {
                    uint temp1 = this.GetMultiplicity(set);
                    uint temp2 = other.GetMultiplicity(set);

                    if (temp1 > temp2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            return other.IsSubsetOf(this);
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

        private void toSortMultisetList(List<MultiSet> powerSets)
        {
            for (int i = 0; i < powerSets.Count - 1; ++i)
            {
                for (int j = 0; j < powerSets.Count - 1; ++j)
                {
                    MultiSet temp = new MultiSet();

                    StringBuilder sb1 = new StringBuilder();
                    StringBuilder sb2 = new StringBuilder();

                    foreach (var s in powerSets[j].Sets)
                    {
                        sb1.Append(s);
                    }
                    foreach (var s in powerSets[j + 1].Sets)
                    {
                        sb2.Append(s);
                    }
                    string s1 = sb1.ToString();
                    string s2 = sb2.ToString();

                    if (s2.CompareTo(s1) == -1)
                    {
                        temp.Sets = powerSets[j].Sets;
                        powerSets[j].Sets = powerSets[j + 1].Sets;
                        powerSets[j + 1].Sets = temp.Sets;
                    }
                    sb1.Clear();
                    sb2.Clear();
                }
            }

        }
    }
}
