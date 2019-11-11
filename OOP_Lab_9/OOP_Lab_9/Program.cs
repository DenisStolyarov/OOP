using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_9
{
    class Program
    {
        public delegate string String_Operations(ref string line);

        static string Up(ref string a)
        {
            a = a.ToUpper();
            return a;
        }

        static string Add(ref string a)
        {
            a = a + "Denis!";
            return a;
        }

        static string Del(ref string a)
        {
            a = a.Trim();
            return a;
        }

        static string Inf(ref string a)
        {
            a = a.Remove(10,10);
            return a;
        }

        static string Siz(ref string a)
        {
            a = a + ";Size: " + a.Length;
            return a;
        }

        static void Main(string[] args)
        {
            Programer a = new Programer("C++");
            a.New_Property += (word) => Console.WriteLine($"Было добавленно новое свойство: {word}");
            a.Rename += (version) => version.ToString();
            a.Add_Property("New Function");
            a.Show_Name();

            Programer b = new Programer("C++");
            b.New_Property += (word) => Console.WriteLine($"Cвойство: {word}");
            b.Rename += (version) => " " + version.ToString() + "0.0.1";
            b.Add_Property("Delete");
            b.Show_Name();

            string Long_Line = "                         It\'s may be the biggest line in this code!";
            String_Operations Show_Line = Up;
            Show_Line += Add;
            Show_Line += Del;
            Show_Line += Inf;
            Show_Line += Siz;
            Console.WriteLine(Show_Line(ref Long_Line));
        }
    }
}
