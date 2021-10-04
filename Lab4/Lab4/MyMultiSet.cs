//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Lab4
//{
//    public sealed class MultiSet
//    {
//        public List<string> Sets = new List<string>(1024);

//        public MultiSet()
//        {
//        }

//        private MultiSet(List<string> elements)
//        {
//            foreach (var element in elements)
//            {
//                Add(element);
//            }
//        }

//        public void Add(string element)
//        {
//            Sets.Add(element);
//        }

//        public bool Remove(string element)
//        {
//            return Sets.Remove(element);
//        }

//        public uint GetMultiplicity(string element)
//        {
//            uint multiplicityCount = 0;

//            foreach (var set in Sets)
//            {
//                if (set == element)
//                {
//                    ++multiplicityCount;
//                }
//            }

//            return multiplicityCount;
//        }

//        public List<string> ToList()
//        {
//            Sets.Sort();
//            return Sets;
//        }

//        public MultiSet Union(MultiSet other)
//        {
//            MultiSet union = new MultiSet();

//            foreach (var set in Sets)
//            {
//                if (union.Sets.Contains(set))
//                {
//                    continue;
//                }

//                uint thisSetsMultiplicity = GetMultiplicity(set);
//                uint otherSetsMultiplicity = other.GetMultiplicity(set);

//                uint maxValue = thisSetsMultiplicity >= otherSetsMultiplicity ? thisSetsMultiplicity : otherSetsMultiplicity;

//                for (uint i = 0; i < maxValue; ++i)
//                {
//                    union.Add(set);
//                }
//            }

//            foreach (var set in other.Sets)
//            {
//                if (union.Sets.Contains(set))
//                {
//                    continue;
//                }

//                uint multiplicity = other.GetMultiplicity(set);

//                for (uint i = 0; i < multiplicity; ++i)
//                {
//                    union.Add(set);
//                }
//            }
//            union.Sets.Sort();
//            return union;
//        }

//        public MultiSet Intersect(MultiSet other)
//        {
//            MultiSet intersect = new MultiSet();

//            foreach (var set in Sets)
//            {
//                if (!other.Sets.Contains(set) || intersect.Sets.Contains(set))
//                {
//                    continue;
//                }

//                uint thisSetsMultiplicity = GetMultiplicity(set);
//                uint otherSetsMultiplicity = other.GetMultiplicity(set);

//                if (thisSetsMultiplicity <= otherSetsMultiplicity)
//                {
//                    for (int i = 0; i < thisSetsMultiplicity; ++i)
//                    {
//                        intersect.Add(set);
//                    }
//                }
//                else
//                {
//                    for (int i = 0; i < otherSetsMultiplicity; ++i)
//                    {
//                        intersect.Add(set);
//                    }
//                }
//            }

//            intersect.Sets.Sort();
//            return intersect;
//        }

//        public MultiSet Subtract(MultiSet other)
//        {
//            MultiSet subtract = new MultiSet();

//            foreach (var set in Sets)
//            {
//                int thisSetsMultiplicity = (int)GetMultiplicity(set);
//                int otherSetsMultiplicity = (int)other.GetMultiplicity(set);

//                if (!other.Sets.Contains(set) && !subtract.Sets.Contains(set))
//                {
//                    for (int i = 0; i < thisSetsMultiplicity; ++i)
//                    {
//                        subtract.Add(set);
//                    }
//                }
//                else if (other.Sets.Contains(set) && !subtract.Sets.Contains(set))
//                {
//                    if (otherSetsMultiplicity >= thisSetsMultiplicity)
//                    {
//                        continue;
//                    }

//                    for (int i = 0; i < thisSetsMultiplicity - otherSetsMultiplicity; ++i)
//                    {
//                        subtract.Add(set);
//                    }
//                }
//            }
//            subtract.Sets.Sort();
//            return subtract;
//        }

//        public List<MultiSet> FindPowerSet()
//        {
//            List<MultiSet> powerSets = new List<MultiSet>();
//            powerSets.Add(new MultiSet());

//            int[] flag = new int[Sets.Count];
//            int index = 0;

//            toMakePowerset(powerSets, Sets, flag, index);
//            toSortMultisetList(powerSets);

//            return powerSets;
//        }

//        public bool IsSubsetOf(MultiSet other)
//        {
//            foreach (var set in Sets)
//            {
//                if (!other.Sets.Contains(set))
//                {
//                    return false;
//                }
//                else
//                {
//                    uint thisSetsMultiplicity = this.GetMultiplicity(set);
//                    uint otherSetsMultiplicity = other.GetMultiplicity(set);

//                    if (thisSetsMultiplicity > otherSetsMultiplicity)
//                    {
//                        return false;
//                    }
//                }
//            }
//            return true;
//        }

//        public bool IsSupersetOf(MultiSet other)
//        {
//            return other.IsSubsetOf(this);
//        }

//        private void toMakePowerset(List<MultiSet> powerSets, List<string> inputs, int[] flags, int index)
//        {
//            if (index == inputs.Count)
//            {
//                List<string> powerSetsElements  = new List<string>();

//                for (int i = 0; i < flags.Length; i++)
//                {
//                    if (flags[i] == 1)
//                    {
//                        powerSetsElements.Add(inputs[i]);
//                    }
//                }
//                powerSetsElements.Sort();

//                bool bDuplicateCheck = false;
//                foreach (var powerset in powerSets)
//                {
//                    if (powerset.Sets.SequenceEqual(powerSetsElements))
//                    {
//                        bDuplicateCheck = true;
//                        break;
//                    }
//                }
//                if (!bDuplicateCheck)
//                {
//                    powerSets.Add(new MultiSet(powerSetsElements));
//                }

//                powerSetsElements.Clear();

//                return;
//            }

//            flags[index] = 1;
//            toMakePowerset(powerSets, inputs, flags, index + 1);

//            flags[index] = 0;
//            toMakePowerset(powerSets, inputs, flags, index + 1);
//        }

//        private void toSortMultisetList(List<MultiSet> powerSets)
//        {
//            for (int i = 0; i < powerSets.Count - 1; ++i)
//            {
//                for (int j = 0; j < powerSets.Count - 1; ++j)
//                {
//                    MultiSet temp = new MultiSet();

//                    StringBuilder sb1 = new StringBuilder();
//                    StringBuilder sb2 = new StringBuilder();

//                    foreach (var s in powerSets[j].Sets)
//                    {
//                        sb1.Append(s);
//                    }
//                    foreach (var s in powerSets[j + 1].Sets)
//                    {
//                        sb2.Append(s);
//                    }
//                    string s1 = sb1.ToString();
//                    string s2 = sb2.ToString();

//                    if (s2.CompareTo(s1) == -1)
//                    {
//                        temp.Sets = powerSets[j].Sets;
//                        powerSets[j].Sets = powerSets[j + 1].Sets;
//                        powerSets[j + 1].Sets = temp.Sets;
//                    }
//                    sb1.Clear();
//                    sb2.Clear();
//                }
//            }

//        }
//    }
//}
