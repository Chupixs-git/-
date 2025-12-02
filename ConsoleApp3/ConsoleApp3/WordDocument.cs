using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class WordDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Word документ : отображается на экране");
        }
    }
}
