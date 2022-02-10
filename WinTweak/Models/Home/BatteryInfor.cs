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
        public string BatteryLifeRemaining, BatteryLifePercent, BatteryFullLifetime, WearLevel, DesignedCapacity, Health;
        public BatteryInfor()
        {
            BatteryLifeRemaining = get_BatteryLifeRemaining();
            BatteryLifePercent = get_BatteryLifePercent();  
            BatteryFullLifetime = get_BatteryFullLifetime();    
            WearLevel = String.Format("About {0}%", get_WearLevel());
            DesignedCapacity = get_DesignedCapacity();
            Health = get_Health();
        }

        string get_BatteryLifeRemaining()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            if (status.BatteryLifeRemaining != -1)
            {
                return String.Format("About {0} minutes", status.BatteryLifeRemaining);
            }
            return "Cannot estimate";
        }
        string get_BatteryLifePercent()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            return String.Format("About {0}%", status.BatteryLifePercent * 100);
        }
        string get_BatteryFullLifetime()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            if (status.BatteryFullLifetime != -1)
            {
                return String.Format("About {0} minutes", status.BatteryFullLifetime / 60);
            }
            return "0 minute";
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
