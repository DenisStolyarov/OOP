using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_4
{
    static public class Printer
    {
        public static void IAmPrinting (Earth earth)
        {
            Console.WriteLine(earth.ToString());
        }
    }
}
