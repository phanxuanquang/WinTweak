using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTweak
{
    internal class Personalize
    {
        private string commandReg, pathReg, nameReg;
        public enum DesktopIconSize { small, medium, large }
        public DesktopIconSize desktopIconSize;
        public void ApplyAction(bool DarkMode_Enable, bool TransparentEffect_Enable, bool PersonalizeDesktopIconArrange_Auto_Enable, int scaleRatio, bool AccentColor_Enable, bool HideFileNameExtensions_Enable)
        {
            Change_DesktopIconSize();

            DarkMode_Activate(DarkMode_Enable);
            AccentColor(AccentColor_Enable);
            TransparentEffect(TransparentEffect_Enable);
            PersonalizeDesktopIconArrange_Auto(PersonalizeDesktopIconArrange_Auto_Enable);
            HideFileNameExtensions(HideFileNameExtensions_Enable);
            Set_DesktopResolution();
            Set_DesktopScale(scaleRatio);
        }
        private void DarkMode_Activate(bool enable)
        {
            commandReg = "Set-ItemProperty";
            pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            nameReg = "AppsUseLightTheme";

            if (enable)
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Value 0");
            }
            else
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Value 1");
            }
        }
        private void AccentColor(bool enable)
        {
            commandReg = "Set-ItemProperty";
            nameReg = "ColorPrevalence";
            pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\DWM";

            if (enable)
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 1");
            }
            else
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");
            }
        }
        private void TransparentEffect(bool enable)
        {
            commandReg = "Set-ItemProperty";
            pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            nameReg = "EnableTransparency";

            if (enable)
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Value 1");
            }
            else
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Value 0");
            }
        }
        private void Change_DesktopIconSize()
        {
            commandReg = "Set-ItemProperty";
            pathReg = @"HKCU:\Software\Microsoft\Windows\Shell\Bags\1\Desktop";
            nameReg = "IconSize";

            switch (desktopIconSize)
            {
                case DesktopIconSize.small:
                    Program.runCommand(commandReg, pathReg, nameReg, "-Value 20");
                    break;
                case DesktopIconSize.medium:
                    Program.runCommand(commandReg, pathReg, nameReg, "-Value 30");
                    break;
                case DesktopIconSize.large:
                    Program.runCommand(commandReg, pathReg, nameReg, "-Value 60");
                    break;
            }
        }
        private void PersonalizeDesktopIconArrange_Auto(bool enable)
        {
            if (enable)
            {
                commandReg = "Set-ItemProperty";
                pathReg = @"HKCU:\Software\Microsoft\Windows\Shell\Bags\1\Desktop";
                nameReg = "FFlags";

                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 1075839525");
            }
        }

        public double width;
        public int height;
        private void Set_DesktopResolution()
        {
            string command = String.Format("Set-DisplayResolution -Width {0} -Height {1} -Force", width, height);
            Program.runCommand_Advanced(command);
        }
        private void Set_DesktopScale(int ratio)
        {
            int DPI = 96; // 100%
            switch (ratio)
            {
                case 125:
                    DPI = 120;
                    break;
                case 150:
                    DPI = 144;
                    break;
                case 200:
                    DPI = 192;
                    break;
            }

            commandReg = "Set-ItemProperty";
            pathReg = @"HKCU:\Control Panel\Desktop\WindowMetrics";

            nameReg = "Win8DpiScaling";
            Program.runCommand(commandReg, pathReg, nameReg, "-Value 1");

            nameReg = "LogPixels";
            Program.runCommand(commandReg, pathReg, nameReg, "-Value " + DPI.ToString());
        }
        private void HideFileNameExtensions(bool enable)
        {
            if (enable)
            {
                commandReg = "Set-ItemProperty";
                pathReg = @"HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                nameReg = "HideFileExt";

                Program.runCommand(commandReg, pathReg, nameReg, "-Value 1");
            }
        }
    }
}
