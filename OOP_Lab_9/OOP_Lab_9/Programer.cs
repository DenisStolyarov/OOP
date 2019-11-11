using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_9
{
    class Programer
    {
        public event Func<int, string> Rename;
        public event Action<string> New_Property;

        public Programer(string name)
        {
            this.name = name;
            version = 0;
        }

        string name;
        int version;
        public void Add_Property(string word)
        {
            New_Property(word);
            version++;
            name += Rename(version);
        }

        public void Show_Name()
        {
            Console.WriteLine(name);
        }
    }
}
