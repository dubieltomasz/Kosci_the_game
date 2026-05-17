using Microsoft.VisualBasic;
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
    public partial class GameScene : UserControl
    {
        private Game.Game game;
        string lastText = "";
        private int player = 0;

        public GameScene()
        {
            InitializeComponent();
            game = new Game.Game(1);

            UpdateScore();
        }

        public void SetGame(Game.Game game)
        {
            this.game = game;
        }

        private void btRoll_Click(object sender, EventArgs e)
        {
            string[] response = game.MadeMove(
                player,
                Game.Action.Roll,
                [cbD1.Checked, cbD2.Checked, cbD3.Checked, cbD4.Checked, cbD5.Checked],
                null
            );

            if (response.Length == 1 && response[0] != lastText)
            {
                chatBox.Items.Add("Player " + player + " rolled: " + response[0]);
                lastText = response[0];
            }

            if (response[0].Length == 5)
            {
                lDice1.Text = Convert.ToString(response[0][0]);
                lDice2.Text = Convert.ToString(response[0][1]);
                lDice3.Text = Convert.ToString(response[0][2]);
                lDice4.Text = Convert.ToString(response[0][3]);
                lDice5.Text = Convert.ToString(response[0][4]);
            }
        }

        private void UpdateScore()
        {
            string[] response2 = game.ShowScore();
            scoreBox.Items.Clear();
            scoreBox.Items.AddRange(response2);
        }

        private void btContinue_Click(object sender, EventArgs e)
        {
            RadioButton? checkedButton = tableLayoutPanel6.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);

            if (checkedButton == null || checkedButton.Tag == null)
            {
                return;
            }

            string[] response = game.MadeMove(
                player,
                Game.Action.ChooseCategory,
                null,
                (Game.Category) Convert.ToInt32(checkedButton.Tag)
            );

            if(response.Length == 1)
            {
                chatBox.Items.Add(response[0]);
            }
            else
            {
                chatBox.Items.Add(response[2]);
            }

                player = game.CurrentPlayer();
            UpdateScore();

            if(response.Length == 4)
            {
                WriteToColumn(response[0], response[1], response[3]);
            }

            if (!game.GameEnded())
            {
                chatBox.Items.Add("Turn of Player " + game.CurrentPlayer());
            }
            else
            {
                int[] score = game.GetScore();
                int winningPlayer = 0;
                int winningScore = 0;
                
                for(int i = 0; i < game.players; ++i)
                {
                    if (score[i] > winningScore)
                    {
                        winningPlayer = i;
                        winningScore = score[i];
                    }
                }

                MessageBox.Show("Player " + winningPlayer + " won!!!");
                Program.mainForm.NavigateTo(MainForm.mainMenu);
            }
        }

        private void WriteToColumn(string score, string category, string combination)
        {
            int converted = (int) Enum.Parse(typeof(Game.Category), category);

            switch (converted)
            {
                case 0:
                    lc00.Text += combination + "\n";
                    ls00.Text += score + "\n";
                    break;
                case 1:
                    lc01.Text += combination + "\n";
                    ls01.Text += score + "\n";
                    break;
                case 2:
                    lc02.Text += combination + "\n";
                    ls02.Text += score + "\n";
                    break;
                case 3:
                    lc03.Text += combination + "\n";
                    ls03.Text += score + "\n";
                    break;
                case 4:
                    lc04.Text += combination + "\n";
                    ls04.Text += score + "\n";
                    break;
                case 5:
                    lc05.Text += combination + "\n";
                    ls05.Text += score + "\n";
                    break;
                case 6:
                    lc10.Text += combination + "\n";
                    ls10.Text += score + "\n";
                    break;
                case 7:
                    lc11.Text += combination + "\n";
                    ls11.Text += score + "\n";
                    break;
                case 8:
                    lc12.Text += combination + "\n";
                    ls12.Text += score + "\n";
                    break;
                case 9:
                    lc13.Text += combination + "\n";
                    ls13.Text += score + "\n";
                    break;
                case 10:
                    lc14.Text += combination + "\n";
                    ls14.Text += score + "\n";
                    break;
                case 11:
                    lc15.Text += combination + "\n";
                    ls15.Text += score + "\n";
                    break;
                case 12:
                    lc16.Text += combination + "\n";
                    ls16.Text += score + "\n";
                    break;
            }
        }
    }
}
