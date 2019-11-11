using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = "OOP_Lab_12.User";
            Reflector reflector = new Reflector();
            reflector.WriteAllInformation(Name);
            reflector.ShowMetods(Name);
            reflector.ShowData(Name);
            reflector.ShowInterfaces(Name);
            reflector.Metod(Name, "System.Int32");
            reflector.CallMetod("In.txt");

    //        Assembly assembly = Assembly.LoadFile(@"D:\Education\Programming\3 sem\OOP\Практика\OOP\OOP_Lab_10\OOP_Lab_10\obj\Debug\OOP_Lab_10.exe");
    //        Console.WriteLine(assembly.DefinedTypes);
    //        foreach (var item in assembly.DefinedTypes)
    //        {
    //            Console.WriteLine(item);
    //            foreach (var i in item.GetMethods())
    //            {
    //                Console.WriteLine(i);
    //            }
    //        }
    //        Type type = assembly.GetType("OOP_Lab_10.Program");
    //        object obj = Activator.CreateInstance(type);
    //        MethodInfo info = type.GetMethod("Main", BindingFlags.DeclaredOnly
    //| BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
    //        info.Invoke(obj, new object[] { new string[] { } });
        }
    }

    public class User
    {
        public string Gender;
        public string Name { get; set; }
        public int Age { get; set; }
        public User()
        {
            Name = "Denis";
            Age = 19;
        }
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
        public void Display()
        {
            Console.WriteLine("Имя: {0}  Возраст: {1}", this.Name, this.Age);
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}
