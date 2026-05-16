using Kości__gra_.Scenes;

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
