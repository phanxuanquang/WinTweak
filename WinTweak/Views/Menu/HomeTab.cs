using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTweak
{
    public partial class HomeTab : UserControl
    {
        Stopwatch watch = new Stopwatch();

        BatteryInfor battery = new BatteryInfor();
        public HomeTab()
        {
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            InitializeComponent();
            
        }

        void checkUpdate()
        {
            try
            {
                if (File.Exists("appVersion.xml"))
                {
                    string appVersion;
                    using (var reader = new StreamReader("appVersion.xml"))
                    {
                        appVersion = reader.ReadLine().Trim();
                    }
                    WebClient client = new WebClient();
                    string latestVersion = client.DownloadString("https://raw.githubusercontent.com/phanxuanquang/WinInfor/master/WinInfor/forUpdate.xml").Trim();

                    if (latestVersion != appVersion)
                    {
                        DialogResult dialogResult = MessageBox.Show("A new version has been released. Do you want to download it now?\nThis update package includes: \n" + latestVersion, "Update Notification", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start("https://github.com/phanxuanquang/WinInfor/releases/latest");
                            Application.Exit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshInformation_Button_Click(object sender, EventArgs e)
        {
            ReLoadDataFrom(new BatteryInfor(), new DisplayInfor(this.DesignedCapacity.Text), new WindowsInfor());
        }

        #region Data loading
        private void HomeTab_Load(object sender, EventArgs e)
        {
            watch.Start();
            checkUpdate();
            this.DesignedCapacity.Text = battery.DesignedCapacity;
            LoadDataFrom(new SystemInfor(), battery, new DisplayInfor(this.DesignedCapacity.Text), new WindowsInfor());
            var themeColor = WindowsColor.GetAccentColor();
            watch.Stop();
            MessageBox.Show($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        private void LoadDataFrom(SystemInfor systemInfor, BatteryInfor batteryInfor, DisplayInfor displayInfor, WindowsInfor windowsInfor)
        {
            this.SystemModel.Text = systemInfor.SystemModel;
            this.OperatingSystem.Text = systemInfor.OperatingSystem;
            this.CPU.Text = systemInfor.CPU;
            this.GraphicCard.Text = systemInfor.GraphicCard;
            this.RAM.Text = systemInfor.RAM;
            this.HardDiscSpace.Text = systemInfor.HardDiscSpace;

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

            this.ComputerName.Text = windowsInfor.ComputerName;
            this.WindowsVersion.Text = windowsInfor.Version;
            this.Architechture.Text = windowsInfor.WindowsArchitechture;
            this.Activation.Text = windowsInfor.Activation;
            this.InstallTime.Text = windowsInfor.InstallTime;
            this.DefenderStatus.Text = windowsInfor.Defender;

        }
        private void ReLoadDataFrom(BatteryInfor batteryInfor, DisplayInfor displayInfor, WindowsInfor windowsInfor)
        {
            this.BatteryLifeRemaining.Text = batteryInfor.BatteryLifeRemaining;
            this.PowerStatus.Text = batteryInfor.PowerStatus;
            this.CurrentPercent.Text = batteryInfor.BatteryLifePercent;

            this.Resolution.Text = displayInfor.Resolution;
            this.RefreshRate.Text = displayInfor.RefreshRate;
            this.Brightness.Text = displayInfor.Brightness;
            this.NightLight.Text = displayInfor.NightLight;
            this.HDR.Text = displayInfor.HDRforPlayback;

            this.ComputerName.Text = windowsInfor.ComputerName;
            this.DefenderStatus.Text = windowsInfor.Defender;
        }
        #endregion

        #region Click for Google searching
        void openGoogleSearch(string keyWord, string filter)
        {
            if (keyWord != "Cannot identify")
            {
                Process.Start(String.Format("http://www.google.com/search?q=\"{0}\" {1}", keyWord, filter));
            }
        }

        private void SystemModel_Click(object sender, EventArgs e)
        {
            openGoogleSearch(SystemModel.Text, "filetype:pdf");
        }

        private void OperatingSystem_Click(object sender, EventArgs e)
        {
            openGoogleSearch(OperatingSystem.Text.Replace("Microsoft ", String.Empty), String.Empty);
        }

        private void GraphicCard_Click(object sender, EventArgs e)
        {
            openGoogleSearch(GraphicCard.Text, String.Empty);
        }

        private void CPU_Click(object sender, EventArgs e)
        {
            openGoogleSearch(CPU.Text, String.Empty);
        }
        #endregion
    }
}
