using Pacman.GameLogic;

namespace PacMan.Classes
{
    public class GameManager
    {
        public Field[,] GameField { get; private set; }
        public Player Player { get; private set; }

        public GameManager(Field[,] gameField, int ghostAmount, Player player)
        {
            ValidatePlayer(player);
            GameField = gameField;
            ValidateGameField();
            Player = player;
            ValidatePlayerPosition();
        }

        public void Update()
        {
            var(dx, dy) = GetMovement(Player.Direction);

            MovePlayer(dx, dy);
            AddPointsToPlayer(Player.CurrentXPosition, Player.CurrentYPosition);
        }

        private void MovePlayer(int dx, int dy)
        {
            ValidatePlayerPosition(dx, dy);

            if (CheckIfWall(Player.CurrentXPosition + dx, Player.CurrentYPosition + dy))
            {
                return;
            }

            Player.CurrentXPosition += dx;
            Player.CurrentYPosition += dy;
        }

        private void AddPointsToPlayer(int xPos, int yPos)
        {
            if(GameField[xPos,yPos].Type == FieldType.Pellet || GameField[xPos,yPos].Type == FieldType.PowerPellet)
            {
                Player.AddScore(GameField[xPos, yPos].Points);
                GameField[xPos, yPos] = new Field(FieldType.Empty, 0);
            }
        }

        private bool CheckIfWall(int newXPos, int newYPos) => GameField[newXPos, newYPos].Type == FieldType.Wall;

        private (int dx, int dy) GetMovement(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up: return (0, -1);
                case Direction.Down: return (0, 1);
                case Direction.Left: return (-1, 0);
                case Direction.Right: return (1, 0);
                default: return (0, 0);
            }
        }

        #region Error Handling
        private void ValidateGameField()
        {
            if (GameField == null || GameField.GetLength(0) == 0 || GameField.GetLength(1) == 0)
            {
                throw new ArgumentException("Game field cannot be null or empty");
            }
        }

        private void ValidatePlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("Player cannot be null");
            }
        }   

        private void ValidatePlayerPosition(int dx = 0, int dy = 0)
        {
            int xPos = Player.CurrentXPosition;
            int yPos = Player.CurrentYPosition;

            // The check against negative values is redundant with the one in Entity class. Maybe remove one of them. IDK
            if (xPos + dx < 0 || xPos + dx >= GameField.GetLength(0) || yPos + dy < 0 || yPos + dy >= GameField.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Player position is out of game field bounds");
            }
        }

        #endregion Error Handling
    }
}
