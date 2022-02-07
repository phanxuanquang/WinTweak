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
        }

        private void AccentColor_Manual_CheckedChanged(object sender, EventArgs e)
        {
            if (AccentColor_Manual.Checked == true)
            {
                colorSample.Enabled = true;
                ColorDialog pickColorDialog = new ColorDialog();
                if (pickColorDialog.ShowDialog() == DialogResult.OK) 
                {
                    colorSample.BackColor = pickColorDialog.Color;
                }
            }

        }

        private void AppearanceTab_Load(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
