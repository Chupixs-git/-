using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Mage : Character
    {
        public int Mana { get; set; }

        public Mage(string name, int mana, int health) : base(name, health)
        {
            Mana = mana;

        }
        public override void Attack()
        {
            Console.WriteLine("Персонаж атакует Огненым шаром");
        }
    }
}
