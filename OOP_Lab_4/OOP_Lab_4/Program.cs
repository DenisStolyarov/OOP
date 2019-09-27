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
            Earth[] array = new Earth[3];
            Object obj_1 = new Ocean();
            if (obj_1 is Ocean)
            {
                Console.WriteLine("Is Test!");
                Ocean ocean = (Ocean)obj_1;
                ocean.Show();
                ocean.Sound();
            }
            Object obj_2 = new Kontinent("Africa");
            Kontinent land = obj_2 as Kontinent;
            if (land != null)
            {
                array[0] = land;
                land.Show();
            }
            Island island = new Island("Kuba");
            array[1] = island;
            island.Show();
            island.Sound();
            IWater water = new Island("Kuba");
            water.Show();
            ((Island)water).Show();
            State state = new State("The USA");
            array[2] = state;
            state.Show();
            state.Messege();

            Console.WriteLine();

            foreach (var item in array)
            {
                Printer.IAmPrinting(item);
            }
        }
    }
}
