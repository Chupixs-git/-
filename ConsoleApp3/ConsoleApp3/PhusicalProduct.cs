using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class PhysicalProduct : Shop
    {
       
            public double Weight { get; set; } 

            public PhysicalProduct(int id, string name, decimal price, double weight)
                : base(id, name, price)
            {
                Weight = weight;
            }

            public override void DisplayProductInfo()
            {
                base.DisplayProductInfo();
                Console.WriteLine($"Weight: {Weight} kg");
            }
    }
    
}
