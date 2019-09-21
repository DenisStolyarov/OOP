using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_2
{
    class Triangle
    {
        public enum Type { ALL, TWO, PRIM, DIFF };
        double A;
        double B;
        double C;
        double P;
        Type type;

        public Triangle(Point a, Point b, Point c)
        {
            A = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));
            B = Math.Sqrt(Math.Pow(b.X - c.X, 2) + Math.Pow(b.Y - c.Y, 2) + Math.Pow(b.Z - c.Z, 2));
            C = Math.Sqrt(Math.Pow(c.X - a.X, 2) + Math.Pow(c.Y - a.Y, 2) + Math.Pow(c.Z - a.Z, 2));

            A = Math.Round(A);
            B = Math.Round(B);
            C = Math.Round(C);

            P = A + B + C;

            if (A == B || A == C || B == C)
            {
                type = Type.TWO;
            }
            else if (A == B && B == C)
            {
                type = Type.ALL;
            }
            else if ( (Math.Pow(A,2) == Math.Pow(B, 2)+ Math.Pow(C, 2)) || (Math.Pow(B, 2) == Math.Pow(A, 2) + Math.Pow(C, 2)) || (Math.Pow(C, 2) == Math.Pow(B, 2) + Math.Pow(A, 2)))
            {
                type = Type.PRIM;
            }
            else
            {
                type = Type.DIFF;
            }
        }

        public double Perimetr()
        {
            return P;
        }

        public override string ToString()
        {
            return "This is a Triangle with 3 sides: A = " + A + " B = " + B + " C = " + C + ";\n P = " + P + ";" + "\nType: " + type + ";";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 2;
        }

        public bool Compare(Triangle obj)
        {
            if (P > obj.Perimetr())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            Console.WriteLine("Equals Metod");
            return base.Equals(obj);
        }

        public Type Get_Type()
        {
            return type;
        }
    }
}
