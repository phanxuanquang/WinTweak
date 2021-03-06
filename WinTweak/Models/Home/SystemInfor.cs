using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    return mo["Model"].ToString();
                }
                return "Cannot identify";
            }
            catch (Exception ex)
            {
                MessageBox.Show("System model not found.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Cannot identify";
        }
        string get_CPU()
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor");
                foreach (ManagementObject mo in mos.Get())
                {
                    return mo["Name"].ToString();
                }
                return "Cannot identify";
            }
            catch (Exception ex)
            {
                MessageBox.Show("CPU information not found.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Cannot identify";
        }
        string get_OperatingSystem()
        {
            try
            {
                ComputerInfo computerInfo = new ComputerInfo();
                return computerInfo.OSFullName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operating System information not found.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Cannot identify";
        }
        string get_GraphicCard()
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT Name FROM Win32_VideoController");
                foreach (ManagementObject mo in mos.Get())
                {
                    return mo["Name"].ToString();
                }
                return "Not available";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dedicated GPU information not found.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Cannot identify";
        }
        string get_RAM()
        {
            try
            {
                ComputerInfo computerInfo = new ComputerInfo();
                var RAM = (double)(computerInfo.TotalPhysicalMemory as UInt64?);
                var availableRAM = (double)(computerInfo.AvailablePhysicalMemory as UInt64?);
                return String.Format("{0} GB with {1} GB available at present", Math.Round(RAM / 1048576000, 2), Math.Round(availableRAM / 1048576000, 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show("RAM not found.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "RAM not found";
        }
        string get_HardDiskSpace()
        {
            try
            {
                double totalSize = 0;
                double freeSpace = 0;
                foreach (DriveInfo disc in DriveInfo.GetDrives())
                {
                    if (disc.DriveType == DriveType.Fixed)
                    {
                        totalSize += disc.TotalSize;
                        freeSpace += disc.AvailableFreeSpace;
                    }
                }
                return String.Format("{0} GB with {1} GB available", Math.Round(totalSize / 1048576000, 2), Math.Round(freeSpace / 1048576000, 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hard drive not found.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Hard drive not found";
        }
    }
}
