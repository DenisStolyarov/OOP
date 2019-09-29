using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_4
{
    public partial class World
    {
        private ArrayList arrayList;
        static int ocean;

        public World()
        {
            arrayList = new ArrayList();
        }
    }

    public partial class World
    {
        public void Add(object obj)
        {
            arrayList.Add(obj);
            if (obj is Ocean)
            {
                ocean++;
            }
        }

        public void Del(object obj)
        {
            arrayList.Remove(obj);
        }

        public void Show_List()
        {
            foreach (var item in arrayList)
            {
                IWater obj = (IWater)item;
                obj.Show();
            }
        }

        public int Get_Ocean()
        {
            return ocean;
        }

        public void Get_Island()
        {
            foreach (var item in arrayList)
            {
                if (item is Island)
                {
                    Island obj = (Island)item;
                    Console.WriteLine(obj.name);
                }
            }
        }
    }

    public abstract class Earth : IWater
    {
        public string name;
        public double Square;
        public Earth(string str, double num)
        {
            name = str;
            Square = Math.Pow(num, 2);
        }
        public override string ToString()
        {
            return "Name: " + name + "\nSquare: " + Square + "\n" + base.ToString() + "\n";
        }
        public abstract void Show();
        public void Sound() { }
    }

    public interface IWater
    {
        void Sound();
        void Show();
    }

    public class Ocean : IWater
    {
        public void Sound()
        {
            Console.WriteLine("Wshhh-Wshhh");
        }

        public void Show()
        {
            Console.WriteLine("It is a Ocean");
        }
    }

    public class Kontinent : Earth
    {
        public Kontinent(string name) : base(name, name.Length) { }
        public override void Show()
        {
            Console.WriteLine("It is a Kontinent " + name + "\nSqrt: " + Square);
        }
    }

    public class Island : Earth,IWater
    {
        public Island(string name) : base(name, name.Length) { }
        public override void Show()
        {
            Console.WriteLine("It is a Island " + name);
        }

        void IWater.Show()
        {
            Console.WriteLine("It is a Island\'s Square: " + Square);
        }

        public new void Sound()
        {
            Console.WriteLine("Yooo-Yooo");
        }
    }

    sealed class State : Kontinent
    {
        public State(string name) : base(name) { }
        public void Messege()
        {
            Console.WriteLine("It is my State " + name);
        }
    }

    struct Example
    {
        int example_int;
        string example_string;
        Example(string a)
        {
            example_string = a;
            example_int = a.Length;
        }
        enum example_enum { First = 2, Second = 5, Therd }
        void exaple_metod()
        {
            Console.WriteLine("Struct");
        }
    }
}
