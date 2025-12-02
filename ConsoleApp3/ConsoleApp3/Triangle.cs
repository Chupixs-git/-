using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Triangle : Shape
    {
        public int H { get; set; }

        public Triangle (int a, int h) : base(a)
        {
            H = h;
        }
        public override string GetArea()
        {
            return $"Area of triang {0.5 * A * H}";
        }
    }
}
