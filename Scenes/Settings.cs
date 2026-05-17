using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kości__gra_.Scenes
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Program.mainForm.FormBorderStyle = FormBorderStyle.None;
                Program.mainForm.WindowState = FormWindowState.Maximized;
                Program.mainForm.TopMost = true;
            }
            if (radioButton2.Checked)
            {
                Program.mainForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                Program.mainForm.WindowState = FormWindowState.Normal;
                Program.mainForm.TopMost = false;
            }
            if (radioButton3.Checked)
            {
                Program.mainForm.FormBorderStyle = FormBorderStyle.None;
                Program.mainForm.WindowState = FormWindowState.Normal;
                Program.mainForm.TopMost = false;
            }
            if (radioButton4.Checked)
            {

                Program.mainForm.Width = 1280;
                Program.mainForm.Height = 720;
            }
            if (radioButton5.Checked)
            {

                Program.mainForm.Width = 1920;
                Program.mainForm.Height = 1080;
            }
            if (radioButton6.Checked)
            {

                Program.mainForm.Width = 2560;
                Program.mainForm.Height = 1440;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.mainForm.NavigateTo(MainForm.mainMenu);
        }
    }
}
