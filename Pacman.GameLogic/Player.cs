using Pacman.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    public class Player : Entity
    {
        public int Score { get; private set; } = 0;
        public int Lives { get; private set; } = 5;
        public int CurrentLevel { get; private set; } = 1;
        public bool HasPowerUp { get; set; } = false;
        public Direction Direction { get; set; } = Direction.None;

        public Player(int xStartPos, int yStartPos, int Lives) : base(xStartPos, yStartPos) { 
            ValidateLives(Lives);
            this.Lives = Lives;
        }

        public void AddScore(int points)
        {
            Score += points;
        }
        #region Error Handling
        private void ValidateLives(int lives)
        {
            if (lives < 0)
            {
                throw new ArgumentOutOfRangeException("Lives cannot be negative");
            }
        }
        #endregion Region Error Handling
    }
}
