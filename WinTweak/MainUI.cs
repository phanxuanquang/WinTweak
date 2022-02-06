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
            BaseTab x = new BaseTab();
            loadTab(x);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimalizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void loadTab(UserControl tab)
        {
            ContainPanel.Controls.Clear();
            ContainPanel.Controls.Add(tab);
        }
    }
}
