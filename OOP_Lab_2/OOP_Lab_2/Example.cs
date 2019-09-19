using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_2
{
    public partial class Example
    {
        public void Show(ref double a)
        {
            a = Math.Sqrt(a);
        }
    }

    public sealed partial class Example
    {
        public void Write()
        {
            Console.WriteLine("Partial class");
        }
    }

    public class Out
    {
        public int Show(int a,out int b,out int c)
        {
            a++;
            b = a * a;
            c = a * a * a;
            return a;
        }
    }
}
