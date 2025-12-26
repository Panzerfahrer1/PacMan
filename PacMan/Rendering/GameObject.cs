using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman.Rendering
{
    public class GameObject
    {
        public List<Point> Points { get; private set; }
        private SolidBrush brush;
        private Graphics graphics;

        public GameObject(Graphics graphics, Color color, IEnumerable<Point> points)
        {
            Points = points.ToList();
            brush = new SolidBrush(color);
            this.graphics = graphics;
        }

        public void Draw()
        {
            graphics.FillPolygon(brush, Points.ToArray());
        }

        public void Clear()
        {
            graphics.Clear(Color.Gray);
        }

        public void MoveShape(int dx, int dy, bool drawAndDelete = false)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new Point(Points[i].X + dx, Points[i].Y + dy);
            }

            if (drawAndDelete)
            {
                Clear();
                Draw();
            }
        }
    }
}
