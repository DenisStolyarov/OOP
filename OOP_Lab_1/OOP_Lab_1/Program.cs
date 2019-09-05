using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type//
            Console.WriteLine("Type:");
            //a)
            sbyte   sbt = -14;                  //from -128 to 127
            byte    bt  = 14;                   //from 0 to 255
            bool    bl  = true;                 //true or false
            ushort  ush = 1414;                 //from 0 to 65535
            short   sh  = -1414;                //from -32768 to 32767
            char    ch  = 'C';                  //from U + 0000 to U + FFFF
            uint    unt = 14141414;             //from 0 to 4 294 967 295
            int     nt  = -14141414;            //from -2 147 483 648 to 2 147 483 647
            float   fl  = 14.14F;               //from 1.5 x 10 ^ -45 to 3.4 x 10 ^ 38
            ulong   ulg = 1414141414141414;     //from 0 to 18 446 744 073 709 551 615
            long    lg  = -1414141414141414;    //from -9 223 372 036 854 775 808 to -9 223 372 036 854 775 807
            double  db  = 1414.1414;            // from 5.0 x 10 ^ -324 to 1.7 x 10 ^ 308
            decimal dc  = 14141414141414141414; // +- from 10 ^ -28 to 10 ^ 28
            string  st  = "String";
            //b)
            sh = bt;
            nt = sh;
            lg = nt;
            dc = lg;
            ulg = bt;

            nt = (int)fl;
            fl = (float)db;
            nt = (int)lg;
            lg = (long)dc;
            sh = (short)lg;
            //c)
            object num = 10;
            object str = "Object";
            nt = (int)num;
            st = (string)str;
            //d)
            var vr1 = 14;
            var vr2 = "String";
            Console.WriteLine(vr1.GetType());
            Console.WriteLine(vr2.GetType());
            //e)
            int? a = null;
            Nullable<int> b = 10;
            Console.WriteLine(a.HasValue);
            Console.WriteLine(b.HasValue);
            Console.WriteLine(a??b);
            //Strings//
            Console.WriteLine(Environment.NewLine + "String:");
            //a),b)
            string line1 = "Hello";
            string line2 = "line";
            string line3 = "line";

            Console.WriteLine(line1 == line2);
            Console.WriteLine(line3 == line2);

            string line4 = line1 + " " + line2;
            Console.WriteLine(line4);
            string line5 = String.Copy(line1);
            Console.WriteLine(line5);
            string line6 = line1.Substring(0, 4);
            Console.WriteLine(line6);
            Console.WriteLine("arrar");
            string[] array = line4.Split();
            foreach (var word in array)
            {
                Console.WriteLine(word);
            }
            line1 = line1.Insert(1, line2);
            Console.WriteLine(line1);
            line1 = line1.Remove(1, line2.Length);
            Console.WriteLine(line1);
            //c)
            string empty = "";
            string nul = null;
            Console.WriteLine(empty??nul);
            Console.WriteLine(empty == nul);
            //d)
            StringBuilder lineX = new StringBuilder("StringBuild", 50);
            Console.WriteLine(lineX);

            lineX.Remove(0, 6);
            Console.WriteLine(lineX);

            lineX.Append(" end.");
            Console.WriteLine(lineX);

            lineX.Insert(0, "start ->");
            Console.WriteLine(lineX);
            //Arrays//
            Console.WriteLine(Environment.NewLine + "Arrays:");
            //a)
            int[,] arr1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for (int i = 0; i < arr1.GetLength(0); ++i)
            {
                for (int j = 0; j < arr1.GetLength(1); ++j)
                {
                    Console.Write(arr1[i,j] + " ");
                }
                Console.WriteLine();
            }
            //b)
            string[] arr2 = { "Hello", "world", "!" };
            foreach (var line in arr2)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Size: "+ arr2.Length);
            Console.Write("Write a word: ");
            string user_line = Console.ReadLine();
            Console.Write("Write a index: ");
            int user_index;
            while(true)
            {
                if(int.TryParse(Console.ReadLine(), out user_index) && user_index < arr2.Length)
                {
                    break;
                }
                Console.Write("Write a index: ");
            }
            arr2[user_index] = user_line;
            foreach (var line in arr2)
            {
                Console.WriteLine(line);
            }
            //c)
            double[][] arr3 = new double[3][];
            arr3[0] = new double[2];
            arr3[1] = new double[3];
            arr3[2] = new double[4];
            for (int i = 0; i < arr3.Length; i++)
            {
                for (int j = 0; j < arr3[i].Length; j++)
                {
                    arr3[i][j] = (double)1 / (j + 1);
                    Console.Write(arr3[i][j] + "\t");
                }
                Console.WriteLine();
            }
            //d)
            var arr4 = new int[3] { 0, 2, 4 };
            var arr5 = new char[3] { 'D', 'e', 'n' };
            //Tuples//
            Console.WriteLine(Environment.NewLine + "Tuples:");
            //a),b)
            (int age, string name, char letter, string lastname, ulong ip) human = (19, "Denis", 'A', "Stolyarov", 123456789);
            //c)
            Console.WriteLine(human);
            Console.WriteLine("Name: {0} Age: {1} LastName: {2}", human.name, human.age, human.lastname);
            //d)
            var (it1, it2, it3, it4, it5) = human;
            //e)
            (int, string) tup1 = (1, "1");
            (int, string) tup2 = (2, "2");
            Console.WriteLine(Equals(tup1, tup2));
            //Task 5//
            Console.WriteLine(Environment.NewLine + "Task 5:");
            (int,int,int,char) LocalFunction (int[] arr,string line)
            {
                int idMin = 0, idMax = 0, sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i]>arr[idMax])
                    {
                        idMax = i;
                    }
                    if (arr[i] < arr[idMin])
                    {
                        idMin = i;
                    }
                    sum += arr[i];
                }
                return (arr[idMax], arr[idMin], sum, line[0]);
            }
            Console.WriteLine(LocalFunction(new int [] {10,5,85,-8,0 },"Local"));
        }
    }
}
