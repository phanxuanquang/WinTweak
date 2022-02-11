using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTweak
{
    internal class BatteryInfor
    {
        public string BatteryLifeRemaining, BatteryLifePercent, PowerStatus, WearLevel, DesignedCapacity, Health;
        public BatteryInfor()
        {
            BatteryLifeRemaining = get_BatteryLifeRemaining();
            BatteryLifePercent = get_BatteryLifePercent();
            PowerStatus = get_PowerStatus();
            WearLevel = String.Format("About {0}%", get_WearLevel());
            DesignedCapacity = get_DesignedCapacity();
            Health = get_Health();
        }

        string get_BatteryLifeRemaining()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            if (status.BatteryLifeRemaining != -1)
            {
                if (status.BatteryLifeRemaining / 3600 > 0)
                {
                    return String.Format("{0} hours and {1} minutes", status.BatteryLifeRemaining / 3600, status.BatteryLifeRemaining / 60 - (status.BatteryLifeRemaining / 3600) * 60);
                }
                else
                {
                    return String.Format("About {0} minutes", status.BatteryLifeRemaining / 60);
                }
            }
            return "Unlimited";
        }
        string get_BatteryLifePercent()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            if (status.BatteryLifePercent < 1)
            {
                return String.Format("About {0}%", status.BatteryLifePercent * 100);
            }
            return "100%";
        }
        string get_PowerStatus()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            if (status.PowerLineStatus == PowerLineStatus.Offline)
            {
                return "Running on battery";
            }
            else if (status.PowerLineStatus == PowerLineStatus.Online)
            {
                return "Plugged in";
            }
            return "Cannot identify";
        }
        string get_WearLevel()
        {
            ManagementObjectSearcher mos;
            string DesignedCapacity = "";
            string FullChargedCapacity = "";

            mos = new ManagementObjectSearcher(@"\\localhost\root\wmi", "Select FullChargedCapacity From BatteryFullChargedCapacity");
            foreach (ManagementObject mo in mos.Get())
            {
                FullChargedCapacity = mo["FullChargedCapacity"].ToString();
            }

            mos = new ManagementObjectSearcher(@"\\localhost\root\wmi", "Select DesignedCapacity From BatteryStaticData");
            foreach (ManagementObject mo in mos.Get())
            {
                DesignedCapacity = mo["DesignedCapacity"].ToString();
            }
            double res = double.Parse(FullChargedCapacity) / double.Parse(DesignedCapacity) * 100;

            return Math.Round(100 - res).ToString();
        }
        string get_DesignedCapacity()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher(@"\\localhost\root\wmi", "Select DesignedCapacity From BatteryStaticData");
            foreach (ManagementObject mo in mos.Get())
            {
                double res = double.Parse(mo["DesignedCapacity"].ToString());
                return String.Format("{0} Wh", Math.Round(res / 1000));
            }
            return "Cannot estimate";
        }
        string get_Health()
        {
            if (double.Parse(get_WearLevel()) <= 15)
            {
                return "Excellent";
            }
            else if (double.Parse(get_WearLevel()) > 15 && double.Parse(get_WearLevel()) < 40)
            {
                return "Good";
            }
            return "Bad";
        }
    }
}
