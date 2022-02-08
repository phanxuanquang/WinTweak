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
            p.StartInfo.Arguments = String.Format("PowerShell if(Test-Path {0}) { {1} -Path {2} -Name {3} {4} }", path, command, path, name, arguments);
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();
        }
        public static void runCommand_Advanced(string command)
        {
            Process p = new Process();

            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = "PowerShell " + command;
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
    }
}
