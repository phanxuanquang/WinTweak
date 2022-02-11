﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTweak
{
    public partial class HomeTab : UserControl
    {
        public HomeTab()
        {
            InitializeComponent();
        }

        private void HomeTab_Load(object sender, EventArgs e)
        {
            LoadDataFrom(new SystemInfor(), new BatteryInfor(), new DisplayInfor()); 
            var themeColor = WindowsColor.GetAccentColor();
        }
        private void LoadDataFrom(SystemInfor systemInfor, BatteryInfor batteryInfor, DisplayInfor displayInfor)
        {
            this.SystemModel.Text = systemInfor.SystemModel;
            this.OperatingSystem.Text = systemInfor.OperatingSystem;
            this.CPU.Text = systemInfor.CPU;
            this.GraphicCard.Text = systemInfor.GraphicCard;
            this.RAM.Text = systemInfor.RAM;
            this.HardDiscSpace.Text = systemInfor.HardDiscSpace;

            this.DesignedCapacity.Text = batteryInfor.DesignedCapacity;
            this.WearLevel.Text = batteryInfor.WearLevel;
            this.BatteryLifeRemaining.Text = batteryInfor.BatteryLifeRemaining;
            this.PowerStatus.Text = batteryInfor.PowerStatus;
            this.CurrentPercent.Text = batteryInfor.BatteryLifePercent;
            this.Health.Text = batteryInfor.Health;

            this.Resolution.Text = displayInfor.Resolution;
            this.RefreshRate.Text = displayInfor.RefreshRate;
            this.Brightness.Text = displayInfor.Brightness;
            this.ScreenScale.Text = displayInfor.scale;
            this.NightLight.Text = displayInfor.NightLight;
            this.HDR.Text = displayInfor.HDRforPlayback;
        }

        private void OpenWindowsUpdate_Button_Click(object sender, EventArgs e)
        {
            Program.runCommand_Advanced("explorer ms-settings:windowsupdate");
        }

        private void RefreshInformation_Button_Click(object sender, EventArgs e)
        {
            LoadDataFrom(new SystemInfor(), new BatteryInfor(), new DisplayInfor());
        }

        private void DisplayInformation_Group_Enter(object sender, EventArgs e)
        {

        }

        private void BatteryInformation_Group_Enter(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
