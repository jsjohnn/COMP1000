using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    public sealed class MultiSet
    {
        public List<string> Set = new List<string>();
​
        public MultiSet() { }
        public MultiSet(List<string> list)
        {
            Set.AddRange(list);
        }
​
        public void Add(string element)
        {
            Set.Add(element);
        }
​
        public bool Remove(string element)
        {
            bool bContain = Set.Contains(element);
​
            Set.Remove(element);
​
            return bContain;
        }
​
        public uint GetMultiplicity(string element)
        {
            uint number = (uint)Set.Count(s => s == element);
​
            return number;
        }
​
        public List<string> ToList()
        {
            if (!Set.Any())
            {
                return Set;
            }
​
            var result = Set.OrderBy(s => s).ToList();
​
            return result;
        }
​
        public MultiSet Union(MultiSet other)
        {
            var otherList = other.ToList();
​
            var result = new List<string>();
​
            result.AddRange(Set);
            result.AddRange(otherList);
​
            var intersectList = Intersect(other).ToList();
​
            for (int i = 0; i < intersectList.Count; ++i)
            {
                result.Remove(intersectList[i]);
            }
​
            return new MultiSet(result);
        }
​
        public MultiSet Intersect(MultiSet other)
        {
            var otherList = other.ToList();
            var defaultSet = Set.OrderBy(s => s).ToList();
​
            uint number1;
            uint number2;
​
            var result = new List<string>();
            for (int i = 0; i < defaultSet.Count(); ++i)
            {
                if (i != defaultSet.Count() - 1 && defaultSet[i] == defaultSet[i + 1])
                {
                    continue;
                }
​
                if (otherList.Contains(defaultSet[i]))
                {
                    number1 = GetMultiplicity(defaultSet[i]);
                    number2 = other.GetMultiplicity(defaultSet[i]);
​
                    uint index = (number1 < number2) ? number1 : number2;
                    for (int j = 0; j < (int)index; ++j)
                    {
                        result.Add(defaultSet[i]);
                    }
                }
            }
​
            return new MultiSet(result);
        }
​
        public MultiSet Subtract(MultiSet other)
        {
            var result = new List<string>();
​
            result.AddRange(Set);
​
            var intersectList = Intersect(other).ToList();
​
            for (int i = 0; i < intersectList.Count(); ++i)
            {
                result.Remove(intersectList[i]);
            }
​
            return new MultiSet(result);
        }
​
        public List<MultiSet> FindPowerSet()
        {
            if (!Set.Any())
            {
                return new List<MultiSet> { new MultiSet() };
            }
​
            const char DELIMETER = ',';
​
            var powerSet = new List<string>();
            var filtered = new SortedSet<string>();
​
            int totalCount = 1 << Set.Count();
​
            for (int bitMask = 0; bitMask < totalCount; ++bitMask)
            {
                for (int j = 0; j < Set.Count(); ++j)
                {
                    if ((bitMask & (1 << j)) > 0)
                    {
                        powerSet.Add(Set[j]);
                    }
                }
                powerSet = powerSet.OrderBy(r => r).ToList();
                filtered.Add(string.Join(DELIMETER, powerSet));
                powerSet.Clear();
            }
​
            var sortedList = filtered.ToList();
​
            var resultSet = new List<MultiSet>();
​
            resultSet.Add(new MultiSet());
            for (int i = 1; i < sortedList.Count(); ++i)
            {
                resultSet.Add(new MultiSet());
​
                string[] tokens = sortedList[i].Split(DELIMETER);
​
                for (int j = 0; j < tokens.Length; ++j)
                {
                    resultSet[i].Add(tokens[j]);
                }
            }
            return resultSet;
        }
​
        public bool IsSubsetOf(MultiSet other)
        {
            if (Set.SequenceEqual(Intersect(other).ToList()))
            {
                return true;
            }
​
            return false;
        }
​
        public bool IsSupersetOf(MultiSet other)
        {
            var otherList = other.ToList();
​
            if (otherList.SequenceEqual(Intersect(other).ToList()))
            {
                return true;
            }
​
            return false;
        }
    }
}