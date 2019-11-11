using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_13
{
    static class SDS_Log
    {
        static StreamWriter writer;
        static SDS_Log()
        {
            string Path = "SDS_Log_File.txt";
            writer = new StreamWriter(Path,true);
        }

        public static void WriteMessage(string Event, string FileName, string Way)
        {
            writer.WriteLine(Event);
            writer.WriteLine("Work in File: " + FileName);
            writer.WriteLine("Location: " + Way);
            writer.WriteLine("Time: " + DateTime.Now + "\n");
        }

        public static void WriteMessage(string Event)
        {
            writer.WriteLine(Event);
            writer.WriteLine("Time: " + DateTime.Now + "\n");
        }

        public static void CloseStream()
        {
            writer.Close();
        }
    }
}
