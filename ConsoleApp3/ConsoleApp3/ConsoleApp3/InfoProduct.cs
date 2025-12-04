using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class DigitalProduct : Shop
    {
        public double FileSize { get; set; } 

        public DigitalProduct(int id, string name, decimal price, double fileSize)
            : base(id, name, price)
        {
            FileSize = fileSize;
        }

        public override void DisplayProductInfo()
        {
            base.DisplayProductInfo();
            Console.WriteLine($"File Size: {FileSize} MB");
        }


    }
}
