using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> MyStack_1 = new Stack<int>();
            Stack<int> MyStack_2 = new Stack<int>();

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                MyStack_1.push(rand.Next(1, 100));
                MyStack_2.push(rand.Next(1, 100));
            }

            Stack<int>.Show(MyStack_1);
            Stack<int>.Show(MyStack_2);

            Console.WriteLine();

            MyStack_1 = MyStack_1 < MyStack_2;

            Stack<int>.Show(MyStack_1);
            Stack<int>.Show(MyStack_2);

            Console.WriteLine();

            for (int i = 0; i < MyStack_2.size; i++)
            {
                MyStack_1--;
            }

            Stack<int>.Show(MyStack_1);
            Stack<int>.Show(MyStack_2);

            Console.WriteLine();

            MyStack_1 = MyStack_1 + MyStack_2;

            Stack<int>.Show(MyStack_1);
            Stack<int>.Show(MyStack_2);

            Console.WriteLine();

            MyStack_1.Information();
            MyStack_2.Information();

            Console.WriteLine(); 

            Console.WriteLine(MathOperation.GetMax(MyStack_1));
            Console.WriteLine(MathOperation.GetMin(MyStack_1));
            Console.WriteLine(MathOperation.Length(MyStack_1));
            Console.WriteLine();
            Console.WriteLine(MathOperation.GetMax(MyStack_2));
            Console.WriteLine(MathOperation.GetMin(MyStack_2));
            Console.WriteLine(MathOperation.Length(MyStack_2));
        }
    }
}
