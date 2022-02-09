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

            ajustResolutionComboBox();
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

            double scrRatioHW = Screen.PrimaryScreen.Bounds.Height / Screen.PrimaryScreen.Bounds.Width;
            double tempHeight = 0;
            switch (Display_ResolutionComboBox.SelectedItem)
            {
                case 0:
                    personalizeActions.width = 1366;
                    tempHeight = personalizeActions.width * scrRatioHW;
                    personalizeActions.height = (int)tempHeight; 
                    break;
                case 1:
                    personalizeActions.width = 1920;
                    tempHeight = personalizeActions.width * scrRatioHW;
                    personalizeActions.height = (int)tempHeight;
                    break;
                case 2:
                    personalizeActions.width = 2560;
                    tempHeight = personalizeActions.width * scrRatioHW;
                    personalizeActions.height = (int)tempHeight;
                    break;
                case 3:
                    personalizeActions.width = 3840;
                    tempHeight = personalizeActions.width * scrRatioHW;
                    personalizeActions.height = (int)tempHeight;
                    break;
            }

            Task applyChanges_Taskbar = Task.Factory.StartNew(() => taskbarActions.ApplyAction(TaskbarAlign_Center.Checked, TaskbarSize_Small.Checked, SmallSearchIcon.Checked, HideTaskViewIcon.Checked, TurnOffMeetNow.Checked, RemoveCortanaIcon.Checked, RemoveBingWeather.Checked, HideMSStoreIcon.Checked));
            Task applyChanges_StartMenu = Task.Factory.StartNew(() => startMenuActions.ApplyAction(TurnOffAppSuggestions.Checked, TurnOffRecentApps.Checked,ApplyAccentColor.Checked));
            Task applyChanges_Personalize = Task.Factory.StartNew(() => personalizeActions.ApplyAction(PersonalizeColorMode_Dark.Checked, PersonalizeTransparentEffect_Enable.Checked, PersonalizeDesktopIconArrange_Auto.Checked, int.Parse(Display_ZoomComboBox.Text), PersonalizeAccentColor_Enable.Checked, HideFileNameExtensions.Checked));

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

        private void ajustResolutionComboBox()
        {
            if (Screen.PrimaryScreen.Bounds.Width < 1920)
            {
                Display_ResolutionComboBox.Items.RemoveAt(1);
                Display_ResolutionComboBox.Items.RemoveAt(2);
                Display_ResolutionComboBox.Items.RemoveAt(3);
            }
            else if (Screen.PrimaryScreen.Bounds.Width < 2560)
            {
                Display_ResolutionComboBox.Items.RemoveAt(2);
                Display_ResolutionComboBox.Items.RemoveAt(3);
            }
            else if (Screen.PrimaryScreen.Bounds.Width < 3840)
            {
                Display_ResolutionComboBox.Items.RemoveAt(3);
            }

        }
    }
}
