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
        
        public AppearanceTab()
        {
            InitializeComponent();

            var themeColor = WindowsColor.GetAccentColor();
            colorSample.FillColor = themeColor;
            ApplyButton.FillColor = ApplyButton.FillColor2 = themeColor;
            ApplyButton.HoverState.FillColor = ApplyButton.HoverState.FillColor2 = ControlPaint.Light(themeColor);
        }

        private void AccentColor_Manual_CheckedChanged(object sender, EventArgs e)
        {
            if (PersonalizeAccentColor_Manual.Checked)
            {
                ColorDialog pickColorDialog = new ColorDialog();
                if (pickColorDialog.ShowDialog() == DialogResult.OK) 
                {
                    colorSample.FillColor = pickColorDialog.Color;
                }
                else
                {
                    PersonalizeAccentColor_Automatic.Checked = true;
                    PersonalizeAccentColor_Manual.Checked = false;
                }
            }

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            
            Taskbar taskbarActions = new Taskbar();
            StartMenu startMenuActions = new StartMenu();
            Personalize personalizeActions = new Personalize();

            if (PersonalizeDesktopIconSize_Small.Checked)
            {
                personalizeActions.desktopIconSize = WinTweak.Personalize.DesktopIconSize.small;
            }
            else if (PersonalizeDesktopIconSize_Medium.Checked)
            {
                personalizeActions.desktopIconSize = WinTweak.Personalize.DesktopIconSize.medium;
            }
            else
            {
                personalizeActions.desktopIconSize = WinTweak.Personalize.DesktopIconSize.large;
            }

            Task applyChanges_Taskbar = Task.Factory.StartNew(() => taskbarActions.ApplyAction(TaskbarAlign_Center.Checked, TaskbarSize_Small.Checked, SmallSearchIcon.Checked, HideTaskViewIcon.Checked, TurnOffMeetNow.Checked, RemoveCortanaIcon.Checked, RemoveBingWeather.Checked, HideMSStoreIcon.Checked));
            Task applyChanges_StartMenu = Task.Factory.StartNew(() => startMenuActions.ApplyAction(TurnOffAppSuggestions.Checked, TurnOffRecentApps.Checked,ApplyAccentColor.Checked));
            Task applyChanges_Personalize = Task.Factory.StartNew(() => personalizeActions.ApplyAction(PersonalizeColorMode_Dark.Checked, PersonalizeTransparentEffect_Enable.Checked, PersonalizeDesktopIconArrange_CleanDesktopIcons.Checked));

            Task.WaitAll(applyChanges_Taskbar, applyChanges_StartMenu, applyChanges_Personalize);

            Task restartExplorer = Task.Factory.StartNew(() => Program.runCommand_Advanced("stop-process -name explorer –force"));
            restartExplorer.Wait();

            MessageBox.Show("Completed. Please restart your computer.");
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            TaskbarAlign_Center.Checked = TaskbarSize_Small.Checked = true;
            Program.CheckAll_CheckBox(this);
        }
    }
}
