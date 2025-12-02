using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Rectangle : Shape
    {
        public int B {get;set;}

        public Rectangle(int a, int b) : base(a)
        {
            B = b;
        }
        public override string GetArea()
        {
            return $"Area of rect {A * B}";
        }
    }
}
