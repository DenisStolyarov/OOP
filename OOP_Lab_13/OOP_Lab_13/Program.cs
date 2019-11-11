using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            SDS_DiskInfo.Show_Disks();
            SDS_FileInfo.GetFileInformation("D:\\File.txt");
            SDS_DirInfo.GetDirectoryInformation("D:\\Steam");
            SDS_FileManager.Manager("D:\\");
            SDS_Log.CloseStream();
        }
    }
}
