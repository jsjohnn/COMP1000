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

                //p:아이템의 부피가 10L, 11L 또는 15L가 아니다.
                //  (10 or 11 or 15)' == 10' and 11' and 15'
                //q:이는 그 아이템이 유독 폐기물임을 함의한다.
                //r:이는 다시 그 아이템이 가구나 전기제품임을 함의한다.
                //  (furniture or electronics)
                // (p && !q) && (q && !r)

                // TTT, FTT, FF

                foreach (var i in NonRecycleItems)
                {
                    if (i.Volume != 10 && i.Volume != 11 && i.Volume != 15 && i.IsToxicWaste == false)
                    {
                        dump.Add(i);
                    }
                    else
                    {
                        if (i.Type == EType.Furniture || i.Type == EType.Electronics)
                        {
                            dump.Add(i);
                        }
                    }
                }

                return dump;
            }
        }
    }
}
