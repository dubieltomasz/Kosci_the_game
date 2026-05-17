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
    public partial class CreateGame : UserControl
    {
        public CreateGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.gameScene.SetGame(new Game.Game(Convert.ToInt32(niPlayers.Value)));
            Program.mainForm.NavigateTo(MainForm.gameScene);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.mainForm.NavigateTo(MainForm.mainMenu);
        }
    }
}
