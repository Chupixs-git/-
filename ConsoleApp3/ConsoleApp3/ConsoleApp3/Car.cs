using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public string FuelType { get; set; }

        public Car(string model, double maxSpeed, int numberOfDoors, string fuelType)
            : base(model, maxSpeed)
        {
            NumberOfDoors = numberOfDoors;
            FuelType = fuelType;
        }
    }
}
