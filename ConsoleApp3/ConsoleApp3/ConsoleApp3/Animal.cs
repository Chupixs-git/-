using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Animal
    {
        public string NamePublic { get; set; } = "Public";
        public string NamePrivate { get; set; } = "privet";
        protected string NameProtected { get; set; } = "protected";

        public Animal(string name) 
        {
            NamePublic = name;

        }
        public void ShowModifiers()
        {
            Console.WriteLine(NamePublic);
            Console.WriteLine(NamePrivate);
            Console.WriteLine(NameProtected);
        }
        public virtual void MakeSound()
        {
            Console.WriteLine("Животное издало непонятный звук");
        }
        public void feed()
        {
            Console.WriteLine("Животное ест");
        }
        
    }
}
