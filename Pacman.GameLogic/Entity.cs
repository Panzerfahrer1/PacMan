using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman.GameLogic
{
    public class Entity
    {
        public int CurrentXPosition { get; set; }
        public int CurrentYPosition{ get; set; }
        public Entity(int x, int y)
        {
            ValidatePosition(x, y);
            CurrentXPosition = x;
            CurrentYPosition = y;
        }

        private void ValidatePosition(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0)
            {
                throw new ArgumentOutOfRangeException("Entity position cannot be negative");
            }
        }
    }
}
