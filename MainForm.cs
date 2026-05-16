using Kości__gra_.Scenes;
using System.Diagnostics;

namespace Kości__gra_
{
    public partial class MainForm : Form
    {
        public static GameScene gameScene = new GameScene();
        public static JoinGame joinGame = new JoinGame();
        public static CreateGame createGame = new CreateGame();
        public static MainMenu mainMenu = new MainMenu();
        public static Settings settings = new Settings();

        public MainForm()
        {
            InitializeComponent();

            this.Width = 1280;
            this.Height = 720;

            NavigateTo(mainMenu);
        }

        public void NavigateTo(UserControl scene)
        {
            if(!this.mainPanel.Controls.Contains(scene))
            {
                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(scene);
            }

            scene.Dock = DockStyle.Fill;
            scene.BringToFront();
            scene.Show();
        }
    }
}
