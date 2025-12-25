using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Classes
{
    public class Field
    {
        public FieldType Type { get; private set; }

        public int Points { get; private set; }

        public Field(FieldType type, int points)
        {
            Type = type;
            Points = points;
        }
    }
}
