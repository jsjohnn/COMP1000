using System;
using System.Collections.Generic;
namespace Lab6
{
    public class Recyclebot
    {
        public List<Item> RecycleItems { get; private set; } = new List<Item>();
        public List<Item> NonRecycleItems { get; private set; } = new List<Item>();

        public Recyclebot()
        {
        }

        public void Add(Item item)
        {
            switch (item.Type)
            {
                case EType.Paper:
                case EType.Furniture:
                case EType.Electronics:
                    if (item.Weight >= 5.0 || item.Weight < 2.0)
                    {
                        NonRecycleItems.Add(item);
                    }
                    else
                    {
                        RecycleItems.Add(item);
                    }
                    break;
                default:
                    RecycleItems.Add(item);
                    break;
            }
        }
        public List<Item> Dump()
        {
            if (NonRecycleItems.Count == 0)
            {
                return null;
            }
            else
            {
                List<Item> dump = new List<Item>(NonRecycleItems.Count);
                foreach (var i in NonRecycleItems)
                {
                    if (!(i.Volume != 10 && i.Volume != 11 && i.Volume != 15 && i.IsToxicWaste)
                        && !(i.IsToxicWaste && i.Type != EType.Electronics && i.Type != EType.Furniture))
                    {
                        dump.Add(i);
                    }
                }

                return dump;
            }
        }
    }
}
