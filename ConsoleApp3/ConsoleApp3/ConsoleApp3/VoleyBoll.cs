using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class VoleyBoll
    {
        public List<Sport> Members { get; }
        public bool IsComplete { get; }

        public VoleyBoll(bool isComplete)
        {
            Members = new List<Sport>();
            IsComplete = isComplete;
        }

        public void AddMember(Sport p)
        {
            Members.Add(p);
        }

        public void Register()
        {
            if (IsComplete)
            {
                Console.WriteLine("Волейбол: команда в сборе, регистрация прошла успешно.");
                Console.WriteLine("Члены команды:");
                foreach (var member in Members)
                    Console.WriteLine($"- {member.Name}");
            }
            else
            {
                Console.WriteLine("Волейбол: команда не полностью собрана, регистрация невозможна.");
            }
        }
    }
}
