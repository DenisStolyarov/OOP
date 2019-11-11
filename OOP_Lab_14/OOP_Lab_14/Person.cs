using System;
using System.Xml.Serialization;

namespace OOP_Lab_14
{
    [Serializable]
    public class Person
    {
        [XmlAttribute]
        public string Name { get; set; }
        public int Year { get; set; }
        [NonSerialized]
        const string owner = "Denis";

        public Person()
        { }

        public Person(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}
