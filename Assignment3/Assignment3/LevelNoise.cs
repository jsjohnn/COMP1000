using System;
namespace Assignment3
{
    public sealed class LevelNoise : INoise
    {
        public int GetNext(int level)
        {
            return level;
        }
    }
}
