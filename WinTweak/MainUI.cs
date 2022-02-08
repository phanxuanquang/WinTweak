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
        public MainUI()
        {
            InitializeComponent();
            ShadowForm.SetShadowForm(this);
        }
        #region Windows State Button
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Menu Button
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

        private void loadTab(UserControl tab)
        {
            ContainPanel.Controls.Clear();
            ContainPanel.Controls.Add(tab);
        }
        
        private void SettingButton_Click(object sender, EventArgs e)
        {
             
        }
    }
}
