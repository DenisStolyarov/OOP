using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Lab_13
{
    static class SDS_DirInfo
    {
        public static void GetDirectoryInformation(string Name)
        {
            DirectoryInfo file = new DirectoryInfo(Name);
            if (file.Exists)
            {
                SDS_Log.WriteMessage("Подучение информации о папке", file.Name, file.FullName);
                Console.WriteLine("Directory: " + file.Name);
                Console.WriteLine("Count of Files: " + file.GetFiles().Count());
                Console.WriteLine("Count of SubDirectory: " + file.GetDirectories().Count());
                Console.WriteLine("Name of Parent: " + file.Parent);
                Console.WriteLine("Full Way: " + file.FullName);
                Console.WriteLine("Time of Create: " + file.CreationTime + "\n");
            }
            else
            {
                SDS_Log.WriteMessage("Поиск папки - папка отсутствует");
                Console.WriteLine("Directory is not found!" + "\n");
            }
        }
    }
}
