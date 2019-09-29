using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean ocean = new Ocean();
            Kontinent land = new Kontinent("Africa");
            Island island = new Island("Kuba");
            State state_1 = new State("The USA");
            State state_2 = new State("The Belarus");
            World world = new World();

            world.Add(ocean);
            world.Add(land);
            world.Add(island);
            world.Add(state_1);
            world.Add(state_2);

            world.Show_List();
            Console.WriteLine();

            world.Del(state_1);

            world.Show_List();
            Console.WriteLine();

            Console.WriteLine(world.Get_Ocean());
            world.Get_Island();
        }
    }
}
