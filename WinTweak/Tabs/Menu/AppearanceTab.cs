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
        }

        private void AccentColor_Manual_CheckedChanged(object sender, EventArgs e)
        {
            if (AccentColor_Manual.Checked)
            {
                colorSample.Enabled = true;
                ColorDialog pickColorDialog = new ColorDialog();
                if (pickColorDialog.ShowDialog() == DialogResult.OK) 
                {
                    colorSample.BackColor = pickColorDialog.Color;
                }
                else
                {
                    AccentColor_Manual.Checked = false;
                    AccentColor_Automatic.Checked = true;
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
            //foreach (Control control in this.Controls)
            //{
            //    if (control is Guna.UI2.WinForms.Guna2CheckBox)
            //    {
            //        Guna.UI2.WinForms.Guna2CheckBox checkBox = (Guna.UI2.WinForms.Guna2CheckBox)control;
            //        if (!checkBox.Checked)
            //        {
            //            checkBox.Checked = true;
            //        }
            //    }
            //}
            foreach(Guna.UI2.WinForms.Guna2CheckBox checkBox in this.Controls)
            {
                if (!checkBox.Checked)
                {
                    checkBox.Checked = true;
                }
            }
            TaskbarAligin_Center.Checked = TaskbarSize_Small.Checked = TaskbarState_Transparent.Checked = true;
        }
    }
}
