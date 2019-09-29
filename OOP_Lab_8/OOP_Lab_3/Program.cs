using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
            Item universal;
            Stack<Item> stack = new Stack<Item>();
            stack.pop();
            for (int i = 0; i < 10; i++)
            {
                universal.value = i;
                stack.push(universal);
                Console.WriteLine(stack.top().value);
            }

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("stack.dat", FileMode.OpenOrCreate))
            {
                // сериализуем весь массив people
                formatter.Serialize(fs, stack);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("stack.dat", FileMode.OpenOrCreate))
            {
                Stack<Item> deserilizeStack = (Stack<Item>)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                while (!deserilizeStack.isEmpty())
                {
                    Console.WriteLine(deserilizeStack.top().value);
                    deserilizeStack.pop();
                }
            }
        }
    }
}
