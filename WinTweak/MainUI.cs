using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTweak
{
    public partial class MainUI : Form
    {
        UserPreferenceChangedEventHandler UserPreferenceChanged;

        HomeTab homeTab;
        AppearanceTab appearanceTab;
        SystemTab systemTab;
        ApplycationsTab applicationsTab;
        AutomationTab automationTab;

        public MainUI()
        {
            InitializeComponent();

            homeTab = new HomeTab();
            appearanceTab = new AppearanceTab();
            systemTab = new SystemTab();
            applicationsTab = new ApplycationsTab();
            automationTab = new AutomationTab();

            loadTab(homeTab);

            ApplyTheme();

            UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            this.Disposed += new EventHandler(MainUI_Disposed);
        }

        #region Windows State
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MainUI_Disposed(object sender, EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= UserPreferenceChanged;
        }
        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.General || e.Category == UserPreferenceCategory.VisualStyle)
            {
                ApplyTheme();
            }
        }
        private void ApplyTheme()
        {
            ShadowForm.SetShadowForm(this);
            Banner.BackColor = WindowsColor.GetAccentColor();
            SettingButton.HoverState.FillColor = ButtonBadge.FillColor = ControlPaint.Light(WindowsColor.GetAccentColor());
            Program.ApplyThemeColor_CheckButtons(this);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }
        #endregion

        #region Menu Button
        private void loadTab(UserControl tab)
        {
            if (!ContainPanel.Controls.Contains(tab))
            {
                ContainPanel.Controls.Add(tab);
                tab.BringToFront();
            }
            else
            {
                tab.BringToFront();
            }
            ApplyTheme();
        }
        private void Home_MenuButton_Click(object sender, EventArgs e)
        {
            loadTab(homeTab);
            ButtonBadge.Top = Home_MenuButton.Top - 2;
        }
        private void Appearance_MenuButton_Click(object sender, EventArgs e)
        {
            loadTab(appearanceTab);
            ButtonBadge.Top = Appearance_MenuButton.Top - 2;
            appearanceTab.UpdateBrightnessValue();
        }
        private void System_MenuButton_Click(object sender, EventArgs e)
        {
            loadTab(systemTab);
            ButtonBadge.Top = System_MenuButton.Top - 2;
        }
        private void Applycations_MenuButton_Click(object sender, EventArgs e)
        {
            loadTab(applicationsTab);
            ButtonBadge.Top = Applications_MenuButton.Top - 2;
        }
        private void Automation_MenuButton_Click(object sender, EventArgs e)
        {
            loadTab(automationTab);
            ButtonBadge.Top = Automation_MenuButton.Top - 2;
        }
        #endregion
        
        private void SettingButton_Click(object sender, EventArgs e)
        {
             
        }
    }
}
