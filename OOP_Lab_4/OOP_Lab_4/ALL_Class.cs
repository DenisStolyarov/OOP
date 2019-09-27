using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_4
{
    public abstract class Earth
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
    }

    interface IWater
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

        public void Sound()
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
}
