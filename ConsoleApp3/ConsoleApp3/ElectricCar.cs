using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class ElectricCar : Car
    {
        public double BatteryCapacity { get; set; } 

        public ElectricCar(string model, double maxSpeed, int numberOfDoors, double batteryCapacity)
            : base(model, maxSpeed, numberOfDoors, "Электроэнергия")
        {
            BatteryCapacity = batteryCapacity;
        }

        public void Charge()
        {
            Console.WriteLine($"Электрокар {Model} заряжается.");
        }

    }
}
