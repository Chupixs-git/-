using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class GoWater : Sport
    {
        public bool HasCertificate { get; }
        public GoWater(string name, int age,bool hasCertificate) : base(name, age)
        {
            HasCertificate = hasCertificate;

        }
        public bool CanRegister()
        {
            return Age >= 16;
        }

        public void Register()
        {
            if (HasCertificate)
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
