using System;
using System.Drawing;

namespace Assignment4
{
    public struct RgbColor
    {
        public double Red { get; private set; }
        public double Green { get; private set; }
        public double Blue { get; private set; }

        public RgbColor(Color color)
        {
            Red = color.R;
            Green = color.G;
            Blue = color.B;
        }

    }
}
