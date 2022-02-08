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
        public void ApplyAction(bool DarkMode_Enable, bool TransparentEffect_Enable, bool CleanDesktopIcons_Enable)
        {
            Change_DesktopIconSize();

            DarkMode_Activate(DarkMode_Enable);
            TransparentEffect(TransparentEffect_Enable);
            CleanDesktopIcons(CleanDesktopIcons_Enable);
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
        private void CleanDesktopIcons(bool enable)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] desktopShortCuts = { "A", "B", "C", "D", };

            foreach(string shortcut in desktopShortCuts)
            {
                if(File.Exists(Path.Combine(desktopPath, shortcut)))
                {
                    File.Delete(Path.Combine(desktopPath, shortcut));
                }
            }
        }
    }
}
