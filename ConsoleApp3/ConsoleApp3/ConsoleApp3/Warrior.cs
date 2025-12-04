using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Warrior : Character
    {
        public int Strength { get; set; }

        public Warrior (string name ,int strength,  int health) : base (name, health)
        {
            Strength = strength;


        }
        public override void Attack()
        {
            Console.WriteLine("Персонаж атакует Мечём");
        }
    }
}
