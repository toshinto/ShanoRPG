using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Objects
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public IEnumerable<Point> IterateToInclusive(Point b)
        {
            for (int ix = X; ix <= b.X; ix++)
                for (int iy = Y; iy <= b.Y; iy++)
                    yield return new Point(ix, iy);
        }

        public static implicit operator Vector(Point p)
        {
            return new Vector(p.X, p.Y);
        }
    }
}
