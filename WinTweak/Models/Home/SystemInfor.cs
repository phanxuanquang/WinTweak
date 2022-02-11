using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WinTweak
{
    internal class SystemInfor
    {
        public string SystemModel, OperatingSystem, CPU, GraphicCard, RAM, HardDiscSpace;
        public SystemInfor()
        {
            SystemModel = get_SystemModel();
            CPU = get_CPU();
            OperatingSystem = get_OperatingSystem();
            GraphicCard = get_GraphicCard();
            RAM = get_RAM();
            HardDiscSpace = get_HardDiskSpace();
        }
        string get_SystemModel()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject mo in mos.Get())
            {
                return mo["Model"].ToString();
            }
            return "Cannot identify";
        }
        string get_CPU()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject mo in mos.Get())
            {
                return mo["Name"].ToString();
            }
            return "Cannot identify";
        }
        string get_OperatingSystem()
        {
            ComputerInfo computerInfo = new ComputerInfo();
            return computerInfo.OSFullName;
        }
        string get_GraphicCard()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            foreach (ManagementObject mo in mos.Get())
            {
                return mo["Name"].ToString();
            }
            return "Not available";
        }
        string get_RAM()
        {
            ComputerInfo computerInfo = new ComputerInfo();
            var RAM = (double)(computerInfo.TotalPhysicalMemory as UInt64?);
            return String.Format("{0} GB", Math.Round(RAM / 1048576000, 2));
        }
        string get_HardDiskSpace()
        {
            double totalSize = 0;
            foreach (DriveInfo disc in DriveInfo.GetDrives())
            {
                if (disc.DriveType == DriveType.Fixed)
                {
                    totalSize += disc.TotalSize;
                }
            }
            return String.Format("{0} GB", Math.Round(totalSize / 1048576000, 2));
        }
    }
}
