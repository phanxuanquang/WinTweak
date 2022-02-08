using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTweak
{
    internal class Taskbar
    {
        public enum aligin { left, center, right }
        public enum size { medium, small }
        public enum state { normal, transparent };

        private string commandReg, pathReg, nameReg;
        public aligin Aligin;
        public size Size;
        public state State;

        public void ApplyAction(bool SmallSearchIcon_Enable, bool HideTaskViewIcon_Enable, bool TurnOffMeetNow_Enable, bool RemoveCortanaIcon_Enable, bool RemoveBingWeather_Enable)
        {
            Change_TaskbarAligin(Aligin);
            Change_TaskbarSize(Size);
            Change_TaskbarState(State);

            SmallSearchIcon(SmallSearchIcon_Enable);
            HideTaskViewIcon(HideTaskViewIcon_Enable);
            TurnOffMeetNow(TurnOffMeetNow_Enable);
            RemoveCortanaIcon(RemoveCortanaIcon_Enable);
            RemoveBingWeather(RemoveBingWeather_Enable);
        }

        private void Change_TaskbarAligin(aligin newAligin)
        {
            //nothing here
        }
        private void Change_TaskbarSize(size newSize)
        {
            commandReg = "Set-ItemProperty";
            pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
            nameReg = "TaskbarSmallIcons";

            if (newSize == size.small)
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 1");

            }
            else
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");
            }
        }
        private void Change_TaskbarState(state newState)
        {
            //nothing here
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
                Program.runCommand_Advanced("Get-AppxPackage -allusers Microsoft.549981C3F5F10 | Remove-AppxPackage");
            }
        }
        private void RemoveBingWeather(bool enable)
        {
            if (enable)
            {
                Program.runCommand_Advanced("Get-AppxPackage *bingweather* | Remove-AppxPackage.");
            }
        }
    }
}
