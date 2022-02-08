using Microsoft.Win32;
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
    public partial class MainUI : Form
    {
        private UserPreferenceChangedEventHandler UserPreferenceChanged;

        public MainUI()
        {
            InitializeComponent();
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
            SettingButton.HoverState.FillColor = ControlPaint.Light(WindowsColor.GetAccentColor());
            Program.ApplyThemeColor_CheckButtons(this);
        }
        #endregion

        #region Menu Button
        private void loadTab(UserControl tab)
        {
            ContainPanel.Controls.Clear();
            ContainPanel.Controls.Add(tab);
            ApplyTheme();
        }
        private void Home_MenuButton_Click(object sender, EventArgs e)
        {
            HomeTab homeTab = new HomeTab();
            loadTab(homeTab);
        }
        private void Appearance_MenuButton_Click(object sender, EventArgs e)
        {
            AppearanceTab appearanceTab = new AppearanceTab();
            loadTab(appearanceTab);
        }
        private void System_MenuButton_Click(object sender, EventArgs e)
        {
            SystemTab systemTab = new SystemTab();
            loadTab(systemTab);
        }
        private void Applycations_MenuButton_Click(object sender, EventArgs e)
        {
            ApplycationsTab applycationsTab = new ApplycationsTab();
            loadTab(applycationsTab);
        }
        private void Automation_MenuButton_Click(object sender, EventArgs e)
        {
            AutomationTab automationTab = new AutomationTab();
            loadTab(automationTab);
        }
        #endregion
        
        private void SettingButton_Click(object sender, EventArgs e)
        {
             
        }
    }
}
