using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinTweak
{
    internal class Taskbar
    {
        private string commandReg, pathReg, nameReg;
        public enum aligin { left, center, right }
        public enum size { medium, small }
        public enum state { normal, transparent };
        public void ApplyAction(bool TaskbarAlign_Enable, bool TaskbarSize_Enable, bool SmallSearchIcon_Enable, bool HideTaskViewIcon_Enable, bool TurnOffMeetNow_Enable, bool RemoveCortanaIcon_Enable, bool RemoveBingWeather_Enable, bool HideMSStoreIcon_Enable)
        {
            TaskbarAlign(TaskbarAlign_Enable); 
            TaskbarSize(TaskbarSize_Enable); 

            SmallSearchIcon(SmallSearchIcon_Enable);
            HideTaskViewIcon(HideTaskViewIcon_Enable);
            TurnOffMeetNow(TurnOffMeetNow_Enable);
            RemoveCortanaIcon(RemoveCortanaIcon_Enable);
            RemoveBingWeather(RemoveBingWeather_Enable);
            HideMSStoreIcon(HideMSStoreIcon_Enable);
        }

        private void TaskbarAlign(bool enable)
        {
            if (enable)
            {
                try { System.Diagnostics.Process.Start("CenterTaskbar.exe"); }
                catch { }
            }
            else
            {
                Program.runCommand_Advanced("Stop-Process -Name \"CenterTaskbar\" -Force");
            }
        }
        private void TaskbarSize(bool enable)
        {
            commandReg = "Set-ItemProperty";
            pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
            nameReg = "TaskbarSmallIcons";

            if (enable)
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 1");
            }
            else
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");
            }
        }

        private void SmallSearchIcon(bool enable)
        {
            if (enable)
            {
                commandReg = "Set-ItemProperty";
                pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Search";
                nameReg = "SearchboxTaskbarMode";

                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 1");
            }
        }
        private void HideTaskViewIcon(bool enable)
        {
            if (enable)
            {
                commandReg = "Set-ItemProperty";
                pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                nameReg = "ShowTaskViewButton";

                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");
            }
        }
        private void TurnOffMeetNow(bool enable)
        {
            if (enable)
            {
                commandReg = "Set-ItemProperty";
                pathReg = @"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer";
                nameReg = "HideSCAMeetNow";

                Program.runCommand(commandReg, pathReg, nameReg, "-Value 1");
            }
        }
        private void RemoveCortanaIcon(bool enable)
        {
            if (enable)
            {
                commandReg = "Set-ItemProperty";
                pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                nameReg = "ShowCortanaButton";

                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");

                Program.runCommand_Advanced("Get-AppxPackage -allusers Microsoft.549981C3F5F10 | Remove-AppxPackage");
            }
        }
        private void RemoveBingWeather(bool enable)
        {
            if (enable)
            {
                Program.runCommand_Advanced("Get-AppxPackage *bingweather* | Remove-AppxPackage.");

                commandReg = "Set-ItemProperty";
                pathReg = @"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Feeds";

                nameReg = "ShellFeedsTaskbarViewMode";
                Program.runCommand(commandReg, pathReg, nameReg, "-Value 2");

                nameReg = "IsFeedsAvailable";
                Program.runCommand(commandReg, pathReg, nameReg, "-Value 0");
            }
        }
        private void HideMSStoreIcon(bool enable)
        {
            if (enable)
            {
                commandReg = "Set-ItemProperty";
                pathReg = @"HKLM:\SOFTWARE\Policies\Microsoft\Windows\Explorer";
                nameReg = "NoPinningStoreToTaskbar";

                Program.runCommand(commandReg, pathReg, nameReg, "-Value 1");
            }
        }
    }
}
