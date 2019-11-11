using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Lab_13
{
    static class SDS_FileInfo
    {
        public static void GetFileInformation(string Name)
        {
            FileInfo file = new FileInfo(Name);
            if (file.Exists)
            {
                SDS_Log.WriteMessage("Подучение информации о файле", file.Name, file.FullName);
                Console.WriteLine("File: " + file.Name);
                Console.WriteLine("Size: " + file.Length);
                Console.WriteLine("Extension: " + file.Extension);
                Console.WriteLine("Full Way: " + file.FullName);
                Console.WriteLine("Time of Create: " + file.CreationTime + "\n");
            }
            else
            {
                SDS_Log.WriteMessage("Поиск файла - Файл отсутствует");
                Console.WriteLine("File is not found!" + "\n");
            }
        }
    }
}
