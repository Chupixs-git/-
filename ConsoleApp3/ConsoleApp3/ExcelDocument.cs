using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class ExcelDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Excel документ : отображается на экране");
        }
    }
}
