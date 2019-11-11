using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace OOP_Lab_15
{
    class Program
    {
        static void Main(string[] args)
        {
            var allProcess = Process.GetProcesses(".");
            foreach (var item in allProcess)
            {
                try
                {
                    Console.WriteLine($"{item.Id} - {item.ProcessName} - {item.BasePriority} - { item.StartTime} - {item.TotalProcessorTime}");
                }
                catch (Exception)
                {
                    continue;
                }
            }
            Console.WriteLine("///////////////////////////");
            AppDomain app = AppDomain.CurrentDomain;
            Console.WriteLine($"{app.FriendlyName} - {app.SetupInformation} \nAssembly:");
            foreach (var item in app.GetAssemblies())
            {
                Console.WriteLine(item.GetName());
            }

            AppDomain domain = AppDomain.CreateDomain("New");
            domain.Load("mscorlib.dll");
            AppDomain.Unload(domain);

            Thread thread = new Thread(new Enumerator().Get);
            thread.Name = "Denis";
            thread.Priority = ThreadPriority.AboveNormal;
            thread.Start();
            Thread.Sleep(100);
            Console.WriteLine("Статус потока: " + thread.ThreadState.ToString());
            thread.Resume();
            Thread.Sleep(100);
            
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Hello);
            // создаем таймер
            Timer timer = new Timer(tm, null, 0, 5000);

            Thread thread_even = new Thread(new ParameterizedThreadStart(Even));
            Thread thread_odd = new Thread(new ParameterizedThreadStart(Odd));

            thread_even.Name = "Even";
            thread_odd.Name = "Odd";
            thread_odd.Priority = ThreadPriority.Highest;

            thread_even.Start(true);
            thread_odd.Start(true);

            Thread.Sleep(100);
            Console.WriteLine("\nСледующий поток:");

            Thread thread_even_1 = new Thread(new ParameterizedThreadStart(Even));
            Thread thread_odd_1 = new Thread(new ParameterizedThreadStart(Odd));
             
            thread_even_1.Start(false);
            thread_odd_1.Start(false);

            Console.ReadLine();
        }

        public class Enumerator
        {
            public void Get()
            {
                Console.WriteLine("Имя потока: " + Thread.CurrentThread.Name);

                Console.WriteLine("Приоритет потока: " + Thread.CurrentThread.Priority.ToString());

                Console.WriteLine("Id потока: " + Thread.CurrentThread.ManagedThreadId.ToString());

                Console.WriteLine("Статус потока: " + Thread.CurrentThread.ThreadState.ToString());

                Number(10);
            }

            static bool flag = true;

            void Number(int n)
            {
                StreamWriter fout = new StreamWriter("numbers.txt", true);
                for (int i = 1; i < n; i++)
                {
                    fout.Write(i.ToString() + " ");
                    
                    Console.WriteLine(i.ToString() + " ");
                    if (flag)
                    {
                        Thread.CurrentThread.Suspend();
                        flag = false;
                    }
                }
                fout.Close();
            }
        }

        public static void Hello(object obj)
        {
            Console.WriteLine("Hi!I\'m Timer ...");
        }

        static object locker = new object();
        static int n = 10;

        public static void Even(object obj)
        {
            bool flag1 = (bool)obj;
            int a = 1;
            if (flag1)
            {
                lock (locker)
                {
                    while (a < n)
                    {
                        Console.Write(a.ToString() + " ");
                        a += 2;
                        //Thread.Sleep(50);
                    }
                }
            }
            else
            {
                while (a < n)
                {
                    Console.Write(a.ToString() + " ");
                    a += 2;
                    Thread.Sleep(50);
                }
            }
        }

        public static void Odd(object obj)
        {
            bool flag1 = (bool)obj;
            int a = 2;
            if (flag1)
            {
                lock (locker)
                {
                    while (a < n)
                    {
                        Console.Write(a.ToString() + " ");
                        a += 2;
                        //Thread.Sleep(50);
                    }
                }
            }
            else
            {
                while (a < n)
                {
                    Console.Write(a.ToString() + " ");
                    a += 2;
                    Thread.Sleep(50);
                }
            }
        }

        class Reader
        {
            // создаем семафор
            static Semaphore sem = new Semaphore(3, 3);
            Thread myThread;
            int count = 3;// счетчик чтения

            public Reader(int i)
            {
                myThread = new Thread(Read);
                myThread.Name = $"Читатель {i.ToString()}";
                myThread.Start();
            }

            public void Read()
            {
                while (count > 0)
                {
                    sem.WaitOne();

                    Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                    Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                    Thread.Sleep(1000);

                    Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                    sem.Release();

                    count--;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
