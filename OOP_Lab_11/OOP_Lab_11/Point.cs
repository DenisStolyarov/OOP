using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_11
{
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class Point
    {
        const string ClassName = "Point";

        private int x;

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Input value must be rise zero!");
                }
                else
                {
                    x = value;
                }
            }
        }
        private int y;

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Input value must be rise zero!");
                }
                else
                {
                    y = value;
                }
            }
        }
        private int z;

        public int Z
        {
            get
            {
                return z;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Input value must be rise zero!");
                }
                else
                {
                    z = value;
                }
            }
        }

        private readonly int _id;
        private static int _count;
        
        Random random = new Random(); 

        static Point()
        {
            _count = 0;
        }

        public Point() : this(0)
        {
            _id = random.Next();
            x = 0;
            y = 0;
            _count++;
        }
        private Point (int z)
        {
            this.z = random.Next(z,10);
        }

        public Point(int x, int y, int z = 0)
        {
            _id = random.Next();
            this.x = x;
            this.y = y;
            this.z = z;
            _count++;
        }

        public int Count()
        {
            return _count;
        }

        public int Id()
        {
            return _id;
        }

        public override string ToString()
        {
            return "This is a Point: X = " + X + " Y = " + Y + " Z = " + Z + ";";
        }
    }
}
