using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Go : Sport
    {
       public Go(string name, int age) : base(name, age) 
        { 
        
        }
        public bool CanRegister()
        {
            return Age >= 16;
        }

        public void Register()
        {
            if (CanRegister())
            {
                Console.WriteLine($"{Name} зарегистрирован на бег (возраст {Age}).");
            }
            else
            {
                Console.WriteLine($"{Name} не подходит для бега — возраст менее 16 лет.");
            }
        }
    }
}
