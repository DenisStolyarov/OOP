using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.ForegroundColor = ConsoleColor.White;

            Point Random_Point()
            {
                Point dot = new Point(rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10));
                return dot;
            }

            string[] MonthArray = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            var request_1 = MonthArray.Where(n => n.Length == 5);
            var request_2 = MonthArray.Where(i => i.StartsWith("J") || i.StartsWith("F") || i.StartsWith("Au") || i.StartsWith("D"));
            var request_3 = MonthArray.OrderBy(n => n);
            var request_4 = MonthArray.Where(i => i.Length > 4 && i.Contains("u"));

            //foreach (var item in request_4)
            //{
            //    Console.WriteLine(item);
            //}

            Point[] dots = new Point[30];

            dots[0] = new Point();
            dots[1] = new Point(1, 4);

            for (int i = 2; i < dots.Length; i++)
            {
                dots[i] = Random_Point();
            }

            int j = -1;

            List<Triangle> tris = new List<Triangle>();

            for (int i = 0; i < 10; i++)
            {
                tris.Add(new Triangle(dots[++j], dots[++j], dots[++j]));
            }

            var request_5 = tris.GroupBy(i => i.Get_Type()).Select(g => new { Name = g.Key, count = g.Count() });
            foreach (var item in request_5)
            {
                Console.WriteLine(item.Name + "   " + item.count);
            }

            var request_6 = tris.Where(u => u.P == tris.Max(i => i.P));
            var request_7 = tris.Where(u => u.P == tris.Min(i => i.P));
            var request_8 = tris.Where(u => u.S == tris.Min(i => i.S));
            var request_9 = tris.OrderBy(i => i.P).Where(u => u.P > 15 && u.S < 450);

            var request_10 = tris.OrderBy(i => i.S).GroupBy(i => i.P).Skip(4).Select(i => i);

            Console.WriteLine(request_6.First());
            Console.WriteLine(request_7.First());
            Console.WriteLine(request_8.First());
            Console.WriteLine();
            //foreach (var item in request_9)
            //{
            //    Console.WriteLine(item);
            //}
            foreach (var item in request_10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i.ToString());
                }
                Console.WriteLine();
            }

            List<Team> teams = new List<Team>()
{
    new Team { Name = "Бавария", Country ="Германия" },
    new Team { Name = "Барселона", Country ="Испания" }
};
            List<Player> players = new List<Player>()
{
    new Player {Name="Месси", Team="Барселона"},
    new Player {Name="Неймар", Team="Барселона"},
    new Player {Name="Роббен", Team="Бавария"}
};
            var request_11 = players.Join(teams,a=>a.Team,b=>b.Name,(a,b)=>new {Name = a.Name, team = a.Team, Country = b.Country });
            foreach (var item in request_11)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} - {1} ({2})", item.Name, item.team, item.Country);
            }
        }
        }
}
