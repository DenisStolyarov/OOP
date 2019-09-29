using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person_1 = new Person(10,"Den");
            }
            catch (Exeption_Person ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.wrong_age}");
                Console.WriteLine($"Ошибка: {ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine();
            }

            try
            {
                Person person_2 = new Person(18,"GodSpeed");
            }
            catch (Exeption_Name ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.wrong_name}");
                Console.WriteLine($"Ошибка: {ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine();
            }

            try
            {
                List<int> exeption_array = new List<int>();
                Console.WriteLine(exeption_array[0]);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Cработало Исключение!");
            }
            finally
            {
                Console.WriteLine();
            }

            int a = 0;
            int b = 0;

            try
            {
                Console.WriteLine("Введите числа: ");
                a = Convert.ToByte(Console.ReadLine());
                b = Convert.ToByte(Console.ReadLine());
                int c = a / b;
            }
            catch (DivideByZeroException) when (a == 0 && b == 0)
            {
                Console.WriteLine("Неопределенность!"); 
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Попытка деления на ноль!");
            }
            finally
            {
                Console.WriteLine();
            }

            object o = null;
            Debug.Assert(o != null, "Type parameter is null");
        }
    }
}
