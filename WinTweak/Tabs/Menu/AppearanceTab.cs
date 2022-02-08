using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTweak
{
    public partial class AppearanceTab : UserControl
    {
        Taskbar taskbarActions;
        
        public AppearanceTab()
        {
            InitializeComponent();
            taskbarActions = new Taskbar();

            var themeColor = WindowsColor.GetAccentColor();
            colorSample.FillColor = themeColor;
            ApplyButton.FillColor = ApplyButton.FillColor2 = themeColor;
            ApplyButton.HoverState.FillColor = ApplyButton.HoverState.FillColor2 = ControlPaint.Light(themeColor);
        }

        private void AccentColor_Manual_CheckedChanged(object sender, EventArgs e)
        {
            if (AccentColor_Manual.Checked)
            {
                ColorDialog pickColorDialog = new ColorDialog();
                if (pickColorDialog.ShowDialog() == DialogResult.OK) 
                {
                    colorSample.FillColor = pickColorDialog.Color;
                }
                else
                {
                    AccentColor_Automatic.Checked = true;
                    AccentColor_Manual.Checked = false;
                }
            }

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            #region Taskbar 
            if (TaskbarAligin_Left.Checked)
            {
                taskbarActions.Aligin = WinTweak.Taskbar.aligin.left;
            }
            else if (TaskbarAligin_Center.Checked)
            {
                taskbarActions.Aligin = WinTweak.Taskbar.aligin.center;
            }
            else
            {
                taskbarActions.Aligin = WinTweak.Taskbar.aligin.right;
            }

            if (TaskbarSize_Medium.Checked)
            {
                taskbarActions.Size = WinTweak.Taskbar.size.medium;
            }
            else
            {
                taskbarActions.Size = WinTweak.Taskbar.size.small;
            }

            if (TaskbarState_Normal.Checked)
            {
                taskbarActions.State = WinTweak.Taskbar.state.normal;
            }
            else
            {
                taskbarActions.State = WinTweak.Taskbar.state.transparent;
            }

            taskbarActions.ApplyAction(SmallSearchIcon.Checked, HideTaskViewIcon.Checked, TurnOffMeetNow.Checked, RemoveCortanaIcon.Checked, RemoveBingWeather.Checked);
            #endregion
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            TaskbarAligin_Center.Checked = TaskbarSize_Small.Checked = TaskbarState_Transparent.Checked = true;
            Program.CheckAll_CheckBox(this);
        }
    }
}
