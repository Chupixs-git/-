using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class Vehicle
    {
        public string Model { get; set; }
        public double MaxSpeed { get; set; }

        public Vehicle(string model, double maxSpeed)
        {
            Model = model;
            MaxSpeed = maxSpeed;
        }


    }
}
