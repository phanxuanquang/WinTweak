﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTweak
{
    internal class DisplayInfor
    {
        public string Resolution, RefreshRate, Brightness, scale, NightLight;
        public DisplayInfor()
        {
            Resolution = get_Resolution();
            RefreshRate = get_RefreshRate();
            Brightness = get_Brightness().ToString() + "%";
            scale = get_Scale();
            NightLight = get_NightLightStatus();
        }
        string get_Resolution()
        {
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            return String.Format("{0}  x {1}", screenWidth, screenHeight);
        }
        string get_RefreshRate()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            foreach (ManagementObject mo in mos.Get())
            {
                return mo["CurrentRefreshRate"].ToString() + "Hz";
            }
            return "Cannot identify";
        }
        int get_Brightness()
        {
            var mclass = new ManagementClass("WmiMonitorBrightness")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };

            foreach (ManagementObject instance in mclass.GetInstances())
            {
                return (byte)instance["CurrentBrightness"];
            }
            return 0;
        }
        string get_Scale()
        {
            var currentDPI = (int)Registry.GetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "LogPixels", 96);
            var scale = (float)currentDPI / 96 * 100;
            return scale.ToString() + "%";
        }
        string get_NightLightStatus()
        {
            const string BlueLightReductionStateKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CloudStore\Store\DefaultAccount\Current\default$windows.data.bluelightreduction.bluelightreductionstate\windows.data.bluelightreduction.bluelightreductionstate";
            using (var key = Registry.CurrentUser.OpenSubKey(BlueLightReductionStateKey))
            {
                var data = key?.GetValue("Data");
                if (data is null)
                    return "Disable";
                var byteData = (byte[])data;
                if (byteData.Length > 24 && byteData[23] == 0x10 && byteData[24] == 0x00)
                    return "Enable";
                return "Disable";
            }
        }
    }
}
