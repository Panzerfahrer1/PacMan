using Pacman.GameLogic;
using PacMan.Classes;
using System.Windows.Forms;

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
                //gameManager.Update();
            }

            MessageBox.Show($"Player new position");

            InitializeGameFieldUI(gameManager);
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

        private void InitializeGameFieldUI(GameManager game)
        {
            var gameFieldPanel = new TableLayoutPanel
            {
                Name = "gameFieldPanel",
                RowCount = game.GameField.GetLength(1),
                ColumnCount = game.GameField.GetLength(0),
                Dock = DockStyle.Fill,
                BackColor = Color.DarkGray,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            gameFieldPanel.SuspendLayout();
            gameFieldPanel.RowStyles.Clear();
            gameFieldPanel.ColumnStyles.Clear();

            // Wichtig: Prozent-Styles, sonst können Rows/Cols 0 groß sein
            for (int y = 0; y < gameFieldPanel.RowCount; y++)
                gameFieldPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / gameFieldPanel.RowCount));

            for (int x = 0; x < gameFieldPanel.ColumnCount; x++)
                gameFieldPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / gameFieldPanel.ColumnCount));

            for (int y = 0; y < gameFieldPanel.RowCount; y++)
            {
                for (int x = 0; x < gameFieldPanel.ColumnCount; x++)
                {
                    Image img = null;
                    if(game.GameField[x, y].Type == FieldType.Pellet)
                    {
                        img = Image.FromFile(@"C:/Users/olive/Downloads/ER5hyI3W4AwxGEG.png");
                    }

                    var panel = GameRenderer.CreatePictureBox(
                        x,
                        y,
                        //game.GameField[x, y].Type == FieldType.Wall ? Color.Blue : Color.Black,
                        img
                    );

                    gameFieldPanel.Controls.Add(panel, x, y);
                }
            }

            // ALTES entfernen, falls du es mehrfach aufrufst
            var old = this.Controls["gameFieldPanel"];
            if (old != null) this.Controls.Remove(old);

            this.Controls.Add(gameFieldPanel); // <-- DAS hast du vergessen
            gameFieldPanel.BringToFront();

            gameFieldPanel.ResumeLayout();
        }

    }
}
