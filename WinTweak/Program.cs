using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTweak
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainUI());
        }
        public static void runCommand(string command, string path, string name, string arguments)
        {
            Process p = new Process();

            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = String.Format("/C PowerShell if(Test-Path {0}) {{ {1} -Path {2} -Name {3} {4} }}", path, command, path, name, arguments);
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();
        }
        public static void runCommand_Advanced(string command)
        {
            Process p = new Process();

            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = "/C PowerShell " + command;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();
        }
        public static void restartComputer()
        {
            DialogResult dialogResult = MessageBox.Show("To apply these changes, your computer must restart.\n Are you sure to continue?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                runCommand_Advanced("Restart-Computer -Force");
            }
        }
        public static void CheckAll_CheckBox(Control control)
        {
            Guna.UI2.WinForms.Guna2CheckBox checkBox = control as Guna.UI2.WinForms.Guna2CheckBox;
            if (checkBox == null)
            {
                foreach (Control child in control.Controls)
                {
                    CheckAll_CheckBox(child);
                }
            }
            else
            {
                checkBox.Checked = true;
            }
        }
        public static void ApplyThemeColor_CheckButtons(Control control)
        {
            Guna.UI2.WinForms.Guna2CheckBox checkBox = control as Guna.UI2.WinForms.Guna2CheckBox;
            Guna.UI2.WinForms.Guna2RadioButton radioButton = control as Guna.UI2.WinForms.Guna2RadioButton;

            if (checkBox == null)
            {
                foreach (Control child in control.Controls)
                {
                    ApplyThemeColor_CheckButtons(child);
                }
            }
            else
            {
                checkBox.CheckedState.FillColor = ControlPaint.Light(WindowsColor.GetAccentColor());
            }

            if (radioButton == null)
            {
                foreach (Control child in control.Controls)
                {
                    ApplyThemeColor_CheckButtons(child);
                }
            }
            else
            {
                radioButton.CheckedState.FillColor = ControlPaint.Light(WindowsColor.GetAccentColor());
            }
        }
    }
}
