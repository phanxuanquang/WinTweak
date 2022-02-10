using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            try
            {
                Process p = new Process();

                p.StartInfo.FileName = "CMD.exe";
                p.StartInfo.Verb = "runas";
                p.StartInfo.Arguments = String.Format("/C PowerShell if(Test-Path {0}) {{ {1} -Path {2} -Name {3} {4} }}", path, command, path, name, arguments);
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void runCommand_Advanced(string command)
        {
            try
            {
                Process p = new Process();

                p.StartInfo.FileName = "CMD.exe";
                p.StartInfo.Verb = "runas";
                p.StartInfo.Arguments = "/C PowerShell " + command;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                p.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    public class WindowsColor
    {
        [DllImport("uxtheme.dll", EntryPoint = "#95")]
        private static extern uint GetImmersiveColorFromColorSetEx(uint dwImmersiveColorSet, uint dwImmersiveColorType, bool bIgnoreHighContrast, uint dwHighContrastCacheMode);
        [DllImport("uxtheme.dll", EntryPoint = "#96")]
        private static extern uint GetImmersiveColorTypeFromName(IntPtr pName);
        [DllImport("uxtheme.dll", EntryPoint = "#98")]
        private static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

        private static Color ConvertDWordColorToRGB(uint colorSetEx)
        {
            byte redColor = (byte)((0x000000FF & colorSetEx) >> 0);
            byte greenColor = (byte)((0x0000FF00 & colorSetEx) >> 8);
            byte blueColor = (byte)((0x00FF0000 & colorSetEx) >> 16);

            return Color.FromArgb(redColor, greenColor, blueColor);
        }

        public static Color GetAccentColor()
        {
            var userColorSet = GetImmersiveUserColorSetPreference(false, false);
            var colorType = GetImmersiveColorTypeFromName(Marshal.StringToHGlobalUni("ImmersiveStartSelectionBackground"));
            var colorSetEx = GetImmersiveColorFromColorSetEx((uint)userColorSet, colorType, false, 0);

            return ConvertDWordColorToRGB(colorSetEx);
        }
    }
}
