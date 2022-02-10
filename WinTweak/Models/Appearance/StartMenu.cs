using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTweak
{
    internal class StartMenu
    {
        private string commandReg, pathReg, nameReg;
        public void ApplyAction(bool TurnOffAppSuggestions_Enable, bool TurnOffRecentApps_Enable, bool ApplyAccentColor_Enable)
        {
            TurnOffAppSuggestions(TurnOffAppSuggestions_Enable);
            TurnOffRecentApps(TurnOffRecentApps_Enable);
            ApplyAccentColor(ApplyAccentColor_Enable);
        }
        void TurnOffAppSuggestions(bool enable)
        {
            if (enable)
            {
                commandReg = "Set-ItemProperty";
                pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
                
                nameReg = "SubscribedContent-338388Enabled";
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");

                nameReg = "SubscribedContent-338388Enabled";
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");

                nameReg = "SubscribedContent-88000237Enabled";
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");

                nameReg = "SubscribedContent-88000326Enabled";
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");
            }
        }
        void TurnOffRecentApps(bool enable)
        {
            if (enable)
            {
                commandReg = "Set-ItemProperty";
                pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer";
               
                nameReg = "ShowRecent";
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");

                nameReg = "ShowFrequent";
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");
            }
        }
        void ApplyAccentColor(bool enable)
        {
            commandReg = "Set-ItemProperty";
            nameReg = "ColorPrevalence";
            pathReg = @"HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize";

            if (enable)
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 1");
            }
            else
            {
                Program.runCommand(commandReg, pathReg, nameReg, "-Type DWord -Value 0");
            }
        }
    }
}
