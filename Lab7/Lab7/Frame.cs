﻿using System;
namespace Lab7
{
    public class Frame
    {
        public EFeatureFlags Features { get; private set; }
        public uint ID { get; }
        public string Name { get; }

        public Frame(uint id, string name)
        {
            ID = id;
            Name = name;
        }

        public void ToggleFeatures(EFeatureFlags features)
        {
            Features ^= features;
        }
        public void TurnOnFeatures(EFeatureFlags features)
        {
            Features |= features;
        }
        public void TurnOffFeatures(EFeatureFlags features)
        {
            Features &= ~features;
        }
    }
}
