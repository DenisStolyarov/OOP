using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Console;
namespace OOP_Lab_16
{
    class Program
    {
        static BlockingCollection<int> bc;

        static async void SayAsync()
        {
            await Task.Run(()=>Console.WriteLine("Async stream"));
        }

        static void producer()
        {
            for (int i = 0; i < 10; i++)
            {
                bc.Add(i * i);
                Console.WriteLine("Производится число " + i * i);
            }
            bc.CompleteAdding();
        }

        static void consumer()
        {
            int i;
            while (!bc.IsCompleted)
            {
                if (bc.TryTake(out i))
                    Console.WriteLine("Потребляется число: " + i);
            }
        }

        public static Task task1;
        public static void EasyNumbersIrato()
        {
            WriteLine("Current task ID: " + Task.CurrentId.ToString());

            WriteLine("Task Completed: " + task1.IsCompleted.ToString());

            WriteLine("Status: " + task1.Status.ToString());

            int i, j, n = 100;

            int[] mas = new int[n];

            for (i = 0; i < n; i++)

                mas[i] = i + 1;

            for (i = 1; i < n - 1; i++)

                if (mas[i] != -1)

                    for (j = i + 1; j < n; j++)

                        if ((mas[j] != -1) && (mas[j] % mas[i] == 0))

                            mas[j] = -1;

            for (i = 0; i < n; i++)

                if (mas[i] != -1)

                    WriteLine(mas[i]);

        }

        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            WriteLine("Current task ID: " + Task.CurrentId.ToString());
            WriteLine("Result: " + result.ToString());
            return result;
        }

        static int Sum(int a,int b,int c)
        {
            return a + b + c;
        }

        static void Main(string[] args)
        {
            WriteLine("Задание 1");

            Action action1 = new Action(EasyNumbersIrato);

            Stopwatch watch = Stopwatch.StartNew();

            task1 = Task.Factory.StartNew(action1);

            task1.Wait();

            task1.Dispose();

            watch.Stop();

            WriteLine("Time for task: " + watch.Elapsed.ToString());
            WriteLine("Task Completed: " + task1.IsCompleted.ToString());
            WriteLine("Status: " + task1.Status.ToString());

            WriteLine("Задание 2");
            CancellationTokenSource cancellation = new CancellationTokenSource();
            task1 = Task.Factory.StartNew(action1,cancellation.Token);
            cancellation.Cancel();
            WriteLine("Task Canceled: " + task1.IsCanceled.ToString());
            WriteLine("Status: " + task1.Status.ToString());

            WriteLine("Задание 3 - 4");
            Task<int> fact1 = new Task<int>(() => Factorial(5));
            Task<int> fact2 = fact1.ContinueWith(a => Factorial(10));
            Task<int> fact3 = fact2.ContinueWith(a => Factorial(15));
            Task<int> res = new Task<int>(() => Sum(fact1.Result, fact2.Result, fact3.Result));
            fact1.Start();
            res.Start();
            var awaiter = res.GetAwaiter();
            awaiter.OnCompleted(() => WriteLine("Last Result:" + awaiter.GetResult()));
            Thread.Sleep(1000);
            WriteLine("Задание 5");
            watch = Stopwatch.StartNew();
            int[] array = new int[100000000];
            ParallelLoopResult result = Parallel.For(0, 10000000, (int z,ParallelLoopState loop) => { array[z] = z + 1; if (z == 1000) loop.Break();});

            if (result.IsCompleted) WriteLine("Выполнен");
            else WriteLine("Выполнение цикла завершено на итерации {0}", result.LowestBreakIteration.ToString());
            watch.Stop();
            WriteLine("Time for task: " + watch.Elapsed.ToString());

            WriteLine("Задание 6");
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Write("1 ");
                }
            },
            () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Write("2 ");
                }
            });

            WriteLine("\nЗадание 7");
            bc = new BlockingCollection<int>(5);

            // Создадим задачи поставщика и потребителя
            Task Pr = new Task(producer);
            Task Cn = new Task(consumer);

            // Запустим задачи
            Pr.Start();
            Cn.Start();

            try
            {
                Task.WaitAll(Cn, Pr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Cn.Dispose();
                Pr.Dispose();
                bc.Dispose();
            }

            WriteLine("\nЗадание 8");
            SayAsync();
            Console.WriteLine("I\'m first!");

            ReadKey();
        }
}
}
