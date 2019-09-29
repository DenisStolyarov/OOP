using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_7
{
    public class Person
    {
        int age;
        public string name;
        
        public Person(int age, string name)
        {
            if (age < 18)
            {
                throw new Exeption_Person("Доступ для людей старше 18 лет!", age);
            }
            else
            {
                this.age = age;
            }

            if (name.Length > 5)
            {
                throw new Exeption_Name("Превышена длина идентификатора!", name);
            }
            else
            {
                this.name = name;
            }
        }
    }

    public class Exeption_Person : ArgumentException
    {
        public int wrong_age;
        public Exeption_Person(string message, int value) : base(message)
        {
            wrong_age = value;
        }
    }

    public class Exeption_Name : ArgumentOutOfRangeException
    {
        public string wrong_name;
        public Exeption_Name(string message, string value) : base("name",message)
        {
            wrong_name = value;
        }
    }
}
