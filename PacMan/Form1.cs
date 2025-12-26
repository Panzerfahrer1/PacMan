using Pacman.GameLogic;
using Pacman.Rendering;
using PacMan.Classes;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Pacman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            List<Point> points = new List<Point>()
            {
                new Point(50, 50),
                new Point(150, 50),
                new Point(150, 150),
                new Point(50, 150)
            };

            GameObject gameObject = new GameObject(graphics, Color.Yellow, points);

            Field[,] gameField = InitGameField();

            Player player = new Player(5, 5, 5);
            GameManager gameManager = new GameManager(gameField, 10, player);

            //This loop should be the main update loop of the game
            while (true)
            {
                player.Direction = Direction.Down;

                for (int i = 0; i < 100; i++)
                {
                    (int x, int y) = GameManager.GetMovement(player.Direction);
                    // Move the player accordint to the direction updated in the game logic
                    // 50 is the speed factor here to make the movement visible
                    // And Sleep(500) to slow down the loop for demonstration purposes
                    gameObject.MoveShape(50 * 1, 50 * y, true);
                    // Update game logic
                    gameManager.Update();
                    System.Threading.Thread.Sleep(500);
                }
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
