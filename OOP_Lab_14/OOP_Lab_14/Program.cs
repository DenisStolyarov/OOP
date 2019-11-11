using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace OOP_Lab_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person_1 = new Person("Denis", 19);
            Person person_2 = new Person("Kerill", 19);
            Person person_3 = new Person("Maksim", 18);
            Person person_4 = new Person("Ivan", 18);

            Person[] room = new Person[] { person_1, person_2, person_3, person_4 };
            //Binary
            BinaryFormatter binary = new BinaryFormatter();

            using (FileStream file = new FileStream("BIN_Person.dat", FileMode.OpenOrCreate))
            {
                binary.Serialize(file, room);
                Console.WriteLine("Serealization Complite!\n");
            }

            using (FileStream file = new FileStream("BIN_Person.dat", FileMode.OpenOrCreate))
            {
                Person[] block = binary.Deserialize(file) as Person[];
                Console.WriteLine("Deserealization Complite!");
                foreach (var item in block)
                {
                    Console.WriteLine("Object Person: Name - " + item.Name + " Age - " + item.Year);
                }
            }
            //SOAP
            SoapFormatter soap = new SoapFormatter();

            using (FileStream file = new FileStream("SOAP_Person.dat", FileMode.OpenOrCreate))
            {
                soap.Serialize(file, room);
                Console.WriteLine("Serealization Complite!\n");
            }

            using (FileStream file = new FileStream("SOAP_Person.dat", FileMode.OpenOrCreate))
            {
                Person[] block = soap.Deserialize(file) as Person[];
                Console.WriteLine("Deserealization Complite!");
                foreach (var item in block)
                {
                    Console.WriteLine("Object Person: Name - " + item.Name + " Age - " + item.Year);
                }
            }
            //JSON
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Person[]));

            using (FileStream file = new FileStream("JSON_Person.dat", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(file, room);
                Console.WriteLine("Serealization Complite!\n");
            }

            using (FileStream file = new FileStream("JSON_Person.dat", FileMode.OpenOrCreate))
            {
                Person[] block = jsonSerializer.ReadObject(file) as Person[];
                Console.WriteLine("Deserealization Complite!");
                foreach (var item in block)
                {
                    Console.WriteLine("Object Person: Name - " + item.Name + " Age - " + item.Year);
                }
            }
            //XML
            XmlSerializer xml = new XmlSerializer(typeof(Person[]));

            using (FileStream file = new FileStream("XML_Person.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(file, room);
                Console.WriteLine("Serealization Complite!\n");
            }

            using (FileStream file = new FileStream("XML_Person.xml", FileMode.OpenOrCreate))
            {
                Person[] block = xml.Deserialize(file) as Person[];
                Console.WriteLine("Deserealization Complite!");
                foreach (var item in block)
                {
                    Console.WriteLine("Object Person: Name - " + item.Name + " Age - " + item.Year);
                }
            }
            Console.WriteLine();
            //XPath
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XML_Person.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList list = xRoot.SelectNodes("Person");
            foreach (XmlNode item in list)
            {
                Console.WriteLine(item.SelectSingleNode("@Name").Value);
            }
            XmlNode denis = xRoot.SelectSingleNode("Person[@Name = 'Denis']");
            if (denis != null)
            {
                Console.WriteLine(denis.OuterXml);
            }
            //LINQ to XML
            XDocument document = new XDocument(new XElement("People",
                new XElement("Person",
                    new XAttribute("Type", "Neighbour"),
                    new XElement("FirstName", "Denis"),
                    new XElement("LastName", "Stoliarou")),
                new XElement("Person",
                    new XAttribute("Type", "Visitor"),
                    new XElement("FirstName", "Mark"),
                    new XElement("LastName", "Popov")),
                new XElement("Person",
                    new XAttribute("Type", "Visitor"),
                    new XElement("FirstName", "Kolia"),
                    new XElement("LastName", "Ivanov"))
                ));
            document.Save("LINQ_XML_People.xml");

            XDocument xDocument = XDocument.Load("LINQ_XML_People.xml");
            foreach (XElement item in xDocument.Element("People").Elements("Person").Where(i => i.Attribute("Type").Value == "Visitor"))
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
