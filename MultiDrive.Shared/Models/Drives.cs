using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDrive.Shared.Models
{
    public class Drives
    {
        DriveInfo[] drivesInfo;
        public DriveInfo[] DrivesInfo
        {
            get => drivesInfo;
        }

        public Drives()
        {
            drivesInfo = [];
            UpdateDrives();
        }

        public void UpdateDrives()
        {
            drivesInfo = DriveInfo.GetDrives();
            Console.WriteLine(drivesInfo.Length.ToString() + " " + drivesInfo.ToString());
        }
    }
}
