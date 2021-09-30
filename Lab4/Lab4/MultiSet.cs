using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public sealed class MultiSet
    {
        public List<string> sets = new List<string>(1024);

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
            sets.Add(element);
        }

        public bool Remove(string element)
        {
            foreach (var set in sets)
            {
                if (set == element)
                {
                    sets.Remove(set);
                    return true;
                }
            }

            return false;
        }

        public uint GetMultiplicity(string element)
        {
            uint multiplicityCount = 0;

            foreach (var set in sets)
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
            // sort기능 직접 구현해보기
            sets.Sort();
            return sets;
        }

        public MultiSet Union(MultiSet other)
        {
            MultiSet union = new MultiSet();

            foreach (var set in sets)
            {
                union.Add(set);
            }

            foreach (var set in other.sets)
            {
                if (!union.sets.Contains(set))
                {
                    union.Add(set);
                    continue;
                }

                int temp1 = (int)GetMultiplicity(set);
                int temp2 = (int)other.GetMultiplicity(set);

                if (temp1 >= temp2)
                {
                    continue;
                }

                int addSetCount = temp2 - temp1;

                for (int i = 0; i < addSetCount; ++i)
                {
                    union.Add(set);
                }
            }
            union.sets.Sort();
            return union;
        }

        public MultiSet Intersect(MultiSet other)
        {
            MultiSet intersect = new MultiSet();

            foreach (var set in sets)
            {
                if (!other.sets.Contains(set) || intersect.sets.Contains(set))
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

            intersect.sets.Sort();
            return intersect;
        }

        public MultiSet Subtract(MultiSet other)
        {
            MultiSet subtract = new MultiSet();

            foreach (var set in sets)
            {
                int temp1 = (int)GetMultiplicity(set);
                int temp2 = (int)other.GetMultiplicity(set);

                if (!other.sets.Contains(set) && !subtract.sets.Contains(set))
                {
                    for (int i = 0; i < temp1; ++i)
                    {
                        subtract.Add(set);
                    }
                }
                else if (other.sets.Contains(set) && !subtract.sets.Contains(set))
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
            subtract.sets.Sort();
            return subtract;
        }

        public List<MultiSet> FindPowerSet()
        {
            List<MultiSet> powerSets = new List<MultiSet>();
            powerSets.Add(new MultiSet());

            int[] flag = new int[sets.Count];
            int index = 0;

            ToMakePowerset(powerSets, sets, flag, index);

            
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

        private void ToMakePowerset(List<MultiSet> powerSets, List<string> inputs, int[] flags, int index)
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
                    if (powerset.sets.SequenceEqual(temps))
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
            ToMakePowerset(powerSets, inputs, flags, index + 1);

            flags[index] = 0;
            ToMakePowerset(powerSets, inputs, flags, index + 1);
        }
        
    }
}