using System.Drawing;

namespace Assignment4
{
    public struct Rgb
    {
        public double Red { get; private set; }
        public double Green { get; private set; }
        public double Blue { get; private set; }

        public Rgb(Color color)
        {
            Red = color.R;
            Green = color.G;
            Blue = color.B;
        }

    }
}
