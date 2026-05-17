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
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btQuit_Click(object sender, EventArgs e)
        {
            Program.mainForm.Close();
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            Program.mainForm.NavigateTo(MainForm.settings);
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            Program.mainForm.NavigateTo(MainForm.createGame);
        }
    }
}
