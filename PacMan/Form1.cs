using Pacman.GameLogic;
using Pacman.Rendering;
using PacMan.Classes;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private Player player;

        public Form1()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread gameThread = new Thread(Game);
            gameThread.Start();
        }

        private void Game()
        {
            Graphics graphics = this.CreateGraphics();
            List<Point> points = new List<Point>()
            {
                new Point(50, 50),
                new Point(125, 75),
                new Point(50, 100)
            };

            GameObject gameObject = new GameObject(graphics, Color.Yellow, points);

            Field[,] gameField = InitGameField();

            player = new Player(5, 5, 5);
            GameManager gameManager = new GameManager(gameField, 10, player);

            //This loop should be the main update loop of the game
            while (true)
            {
                for (int i = 0; i < 100; i++)
                {
                    (int x, int y) = GameManager.GetMovement(player.Direction);
                    // Move the player accordint to the direction updated in the game logic
                    // 50 is the speed factor here to make the movement visible
                    // And Sleep(500) to slow down the loop for demonstration purposes
                    gameObject.MoveShape(5 * x, 5 * y, true);
                    // Update game logic
                    gameManager.Update();
                    System.Threading.Thread.Sleep(10);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            player.Direction = GetDirection(e.KeyCode);
        }

        private Direction GetDirection(Keys key)
        {
            switch (key)
            {
                case Keys.Up: return Direction.Up;
                case Keys.Down: return Direction.Down;
                case Keys.Left: return Direction.Left;
                case Keys.Right: return Direction.Right;
                default: return Direction.None;
            }
        }


        private Field[,] InitGameField()
        {
            Field[,] gameField = new Field[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (x == 0 || x == 9 || y == 0 || y == 9)
                    {
                        gameField[x, y] = new Field(FieldType.Wall, 0);
                    }
                    else
                    {
                        gameField[x, y] = new Field(FieldType.Pellet, 30);
                    }
                }
            }
            return gameField;
        }
    }
}
