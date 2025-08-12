using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDrive.Models
{
    internal class Drives
    {
        DriveInfo[] drivesInfo;
        public DriveInfo[] DrivesInfo
        {
            get => drivesInfo;
        }

        public Drives()
        {
            drivesInfo = new DriveInfo[0];
            UpdateDrives();
        }

        public void UpdateDrives()
        {
            drivesInfo = DriveInfo.GetDrives();
            Console.WriteLine(drivesInfo.Length.ToString() + " " + drivesInfo.ToString());
        }
    }
}
