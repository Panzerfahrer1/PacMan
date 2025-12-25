using Pacman.GameLogic;
using PacMan.Classes;

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

            Field[,] gameField = InitGameField();
            
            Player player = new Player(5, 5, 5);
            GameManager gameManager = new GameManager(gameField, 10, player);

            player.Direction = Direction.Down;

            for (int i = 0; i < 10; i++)
            {
                gameManager.Update();
            }

            MessageBox.Show($"Player new position");
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
