using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Cat : Animal
    {
        public string Breed { get; set; }
        public Cat(string name, string breed) : base(name)
        {
            Breed = breed;

        }

        
        public void JumpJumpJumpNight()
        {
            Console.WriteLine("кот перешел в режим ночной активности");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Животное издало may");
        }

    }
}
