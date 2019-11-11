using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_13
{
    static class SDS_DiskInfo
    {
        public static void Show_Disks()
        {
            SDS_Log.WriteMessage("Получение общих сведений о дисках");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                Console.WriteLine("Disk " + drive.Name);
                Console.WriteLine("Disk Type: " + drive.DriveType);
                if (drive.IsReady)
                {
                    Console.WriteLine("Space: " + drive.TotalSize);
                    Console.WriteLine("Free Space: " + drive.TotalFreeSpace);
                    Console.WriteLine("Disk Marker: " + drive.VolumeLabel);
                    Console.WriteLine("Disk Format: " + drive.DriveFormat);
                }
                Console.WriteLine();
            }
        }
    }
}
