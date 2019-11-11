using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_12
{
    class Reflector
    {
        public void WriteAllInformation(string Name)
        {
            Type type = Type.GetType(Name, false, true);
            StreamWriter writer = new StreamWriter("File.txt", false);
            writer.WriteLine("Full Name: " + type.FullName);

            writer.WriteLine("Base Type: " + type.BaseType);

            writer.WriteLine("Is sealed: " + type.IsSealed);

            writer.WriteLine("Is class = " + type.IsClass);

            writer.WriteLine("Is Public = " + type.IsPublic);

            writer.Close();
        }

        public void ShowMetods(string Name)
        {
            Type type = Type.GetType(Name, false, true);
            foreach (MethodInfo method in type.GetMethods())
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual ";
                Console.Write(modificator + method.ReturnType.Name + " " + method.Name + " (");
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }

        public void ShowData(string Name)
        {
            Type type = Type.GetType(Name, false, true);
            Console.WriteLine("Поля:");
            foreach (FieldInfo field in type.GetFields())
            {
                Console.WriteLine("{0} {1}", field.FieldType, field.Name);
            }

            Console.WriteLine("Свойства:");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Console.WriteLine("{0} {1}", prop.PropertyType, prop.Name);
            }
        }

        public void ShowInterfaces(string Name)
        {
            Type type = Type.GetType(Name, false, true);
            if (type.GetInterfaces().Count() > 0)
            {
                Console.WriteLine(" Contains interfaces:");
            }
            foreach (Type iType in type.GetInterfaces())
            {
                Console.WriteLine('\t' + iType.Name);
            }
        }

        public void Metod(string Name,string Type_Name)
        {
            Type type = Type.GetType(Name, false, true);
            Type param = Type.GetType(Type_Name);
            if (param != null)
            {
                var request = type.GetMethods().Where(i => i.GetParameters().Any(a => a.ParameterType == param));
                if (request.Count() > 0)
                {
                    Console.WriteLine(" Find Metods:");

                    foreach (var item in request)
                    {
                        string modificator = "";
                        if (item.IsStatic)
                            modificator += "static ";
                        if (item.IsVirtual)
                            modificator += "virtual ";
                        Console.Write(modificator + item.ReturnType.Name + " " + item.Name + " (");
                        //получаем все параметры
                        ParameterInfo[] parameters = item.GetParameters();
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                            if (i + 1 < parameters.Length) Console.Write(", ");
                        }
                        Console.WriteLine(")");
                    }
                }
                else
                {
                    Console.WriteLine("No Metod with this parametr");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        public void CallMetod(string Name)
        {
            StreamReader reader = new StreamReader(Name);
            string [] param = reader.ReadToEnd().Split();
            //Assembly assembly = Assembly.GetAssembly(param.First().GetType());
            //Console.WriteLine(assembly.FullName);
            //Определяем тип
            Type type = Type.GetType(param.First(), false, true);
            //Находим метод
            MethodInfo method = type.GetMethod(param.Last());
            //Создаем экземпляр класса
            object obj = Activator.CreateInstance(type);
            //Получаем результат работы метода
            object result = method.Invoke(obj, new object[] { 14, 5 });
            Console.WriteLine(result);
        }
    }
}
