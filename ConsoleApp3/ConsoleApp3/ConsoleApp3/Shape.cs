using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Shape
    {
        public int A {get;set;}
        //public int B { get;set;}

        public Shape(int a)
        {
            A = a;
            //B = b;
        }
        public virtual string GetArea()
        {
            return "Area of shape";
        }
    }
}
