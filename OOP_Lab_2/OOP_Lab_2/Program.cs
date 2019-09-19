using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_2
{
    class Program
    {
        static void example ()
        {
            double a = 10.5;
            Console.WriteLine(a);

            Example b = new Example();
            b.Show(ref a);
         
            Console.WriteLine(a);
            b.Write();

            int x, y, z, i;
            x = 5;

            Out OutPut = new Out();
            i = OutPut.Show(x, out y, out z);

            Console.WriteLine("x = {0}, y = {1}, z = {2}, i = {3}", x, y, z, i);
        }

        static void Main(string[] args)
        {
            Random rand = new Random();

            Point Random_Point()
            {
                Point dot = new Point(rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10));
                return dot;
            }

            Point[] dots = new Point[30];

            dots[0] = new Point();
            dots[1] = new Point(1, 4);

            for (int i = 2; i < dots.Length; i++)
            {
                dots[i] = Random_Point();
            }

            //for (int i = 0; i < dots.Length; i++)
            //{
            //    Console.WriteLine(dots[i].ToString());
            //}

            Triangle[] tris = new Triangle[10];

            Stack<Triangle> ALL = new Stack<Triangle>();
            Stack<Triangle> TWO = new Stack<Triangle>();
            Stack<Triangle> PRIM = new Stack<Triangle>();
            Stack<Triangle> DIFF = new Stack<Triangle>();

            int j = -1;
            for (int i = 0; i < tris.Length; i++)
            {
                tris[i] = new Triangle(dots[++j], dots[++j], dots[++j]);

                switch (tris[i].Get_Type())
                {
                    case Triangle.Type.ALL:
                        ALL.Push(tris[i]);
                        break;
                    case Triangle.Type.TWO:
                        TWO.Push(tris[i]);
                        break;
                    case Triangle.Type.PRIM:
                        PRIM.Push(tris[i]);
                        break;
                    case Triangle.Type.DIFF:
                        DIFF.Push(tris[i]);
                        break;
                    default:
                        Console.WriteLine("Undefined!");
                        break;
                }
                //Console.WriteLine(tris[i].ToString());
            }

            void Max_Min(Stack<Triangle> stack)
            {
                if (stack.Count == 0)
                {
                    return;
                }
                Triangle min, max;
                min = max = stack.Pop();
                for (int i = 1; i < stack.Count; i++)
                {
                    if (min.Compare(stack.Peek()))
                    {
                        min = stack.Pop();
                    }
                    else if (!max.Compare(stack.Peek()))
                    {
                        max = stack.Pop();
                    }
                }
                Console.WriteLine("\nMin of Triangels: ");
                Console.WriteLine(min.ToString());
                Console.WriteLine("\nMax of Triangels: ");
                Console.WriteLine(max.ToString());
            }
            Console.WriteLine("\nALL: {0}; \nTWO: {1} \nPRIM: {2} \nDIFF: {3} \n",ALL.Count, TWO.Count, PRIM.Count, DIFF.Count);


            Max_Min(ALL);
            Max_Min(TWO);
            Max_Min(PRIM);
            Max_Min(DIFF);
        }
    }
}
