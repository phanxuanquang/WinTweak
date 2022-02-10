﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // Source: https://github.com/mdhiggins/CenterTaskbar
            try
            {
                Process[] runingProcess = Process.GetProcesses();
                if (enable)
                {
                    for (int i = 0; i < runingProcess.Length; i++)
                    {
                        if (runingProcess[i].ProcessName == "CenterTaskbar")
                        {
                            runingProcess[i].Kill();
                        }
                    }

                    try 
                    {
                        for (int i = 0; i < runingProcess.Length; i++)
                        {
                            if (runingProcess[i].ProcessName == "CenterTaskbar")
                            {
                                runingProcess[i].Kill();
                            }
                        }

                        System.Diagnostics.Process.Start("CenterTaskbar.exe"); 
                    }
                    catch { }
                }
                else
                {
                    for (int i = 0; i < runingProcess.Length; i++)
                    {
                        if (runingProcess[i].ProcessName == "CenterTaskbar")
                        {
                            runingProcess[i].Kill();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TaskbarSize(bool enable)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SmallSearchIcon(bool enable)
        {
            try
            {
                if (enable)
                {
                    commandReg = "Set-ItemProperty";
                    pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Search";
                    nameReg = "SearchboxTaskbarMode";

                    Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HideTaskViewIcon(bool enable)
        {
            try
            {
                if (enable)
                {
                    commandReg = "Set-ItemProperty";
                    pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                    nameReg = "ShowTaskViewButton";

                    Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TurnOffMeetNow(bool enable)
        {
            try
            {
                if (enable)
                {
                    commandReg = "Set-ItemProperty";
                    pathReg = @"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer";
                    nameReg = "HideSCAMeetNow";

                    Program.runCommand(commandReg, pathReg, nameReg, "-Value 1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RemoveCortanaIcon(bool enable)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RemoveBingWeather(bool enable)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HideMSStoreIcon(bool enable)
        {
            try
            {
                if (enable)
                {
                    commandReg = "Set-ItemProperty";
                    pathReg = @"HKLM:\SOFTWARE\Policies\Microsoft\Windows\Explorer";
                    nameReg = "NoPinningStoreToTaskbar";

                    Program.runCommand(commandReg, pathReg, nameReg, "-Value 1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
