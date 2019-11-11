using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using static System.Console;
namespace OOP_Lab_10
{
    public static class Q
    {
        public static void Show(this Queue<int> queue)
        {
            foreach (var item in queue)
            {
                Write(item + " ");
            }
            WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList() { 1, 2, 3, 4, 5};
            arrayList.Add("Hello!");
            arrayList.Add(new User { Name = "Denis" });
            arrayList.Remove(1);
            WriteLine(arrayList.Count);
            foreach (var item in arrayList)
            {
                Write(item + " ");
            }
            WriteLine();
            WriteLine(arrayList[arrayList.BinarySearch(3)]);

            Queue<int> queue = new Queue<int>();
            
            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(i);
            }

            queue.Show();

            for (int i = 0; i < 3; i++)
            {
                queue.Dequeue();
            }

            queue.Show();

            SortedDictionary<int, string> SDictionary = new SortedDictionary<int, string>();

            SDictionary.Add(3, "Denis");
            SDictionary.Add(2, "Mark");
            SDictionary.Add(1, "Igor");

            foreach (var item in SDictionary)
            {
                WriteLine(item.Key + " " + item.Value);
            }

            WriteLine(SDictionary.ContainsValue("Mark"));
            WriteLine();

            ObservableCollection<User> users = new ObservableCollection<User>
            {
                new User { Name = "Bill"},
                new User { Name = "Tom"},
                new User { Name = "Alice"}
            };

            users.CollectionChanged += Users_CollectionChanged;

            users.Add(new User { Name = "Bob" });
            users.RemoveAt(1);
            users[0] = new User { Name = "Anders" };

            foreach (User user in users)
            {
                WriteLine(user.Name);
            }

            Read();
        }

        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    User newUser = e.NewItems[0] as User;
                    Console.WriteLine("Добавлен новый объект: {0}", newUser.Name);
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    User oldUser = e.OldItems[0] as User;
                    Console.WriteLine("Удален объект: {0}", oldUser.Name);
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    User replacedUser = e.OldItems[0] as User;
                    User replacingUser = e.NewItems[0] as User;
                    Console.WriteLine("Объект {0} заменен объектом {1}",
                                        replacedUser.Name, replacingUser.Name);
                    break;
            }
        }
    }

    class User
    {
        public string Name { get; set; }
    }
}

