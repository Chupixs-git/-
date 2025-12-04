using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя {Name}  \t Здоровье {Health}") ;
        }

        public Character(string name, int health)
        {
            Name = name ;
            Health = health ;
        }

        public virtual void Attack()
        {
            Console.WriteLine("Персонаж атакует ");
        }




    }
}
