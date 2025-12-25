using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    public class GameManager
    {
        public Field[,] GameField { get; private set; }
        public Player Player { get; private set; }

        public GameManager(Field[,] gameField, int ghostAmount, Player player)
        {
            ValidatePlayer(player);
            ValidatePlayerPosition();

            GameField = gameField;
            ValidateGameField();
            Player = player;
        }

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

        private void ValidatePlayerPosition()
        {
            int xPos = Player.CurrentXPosition;
            int yPos = Player.CurrentYPosition;

            // The check against negative values is redundant with the one in Entity class. Maybe remove one of them. IDK
            if (xPos < 0 || xPos >= GameField.GetLength(0) || yPos < 0 || yPos >= GameField.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Player position is out of game field bounds");
            }
        }
    }
}
