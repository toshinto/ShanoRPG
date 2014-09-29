using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IO
{
    public struct MovementState
    {
        public int XDirection,
            YDirection;

        public MovementState(int dx, int dy)
        {
            XDirection = dx;
            YDirection = dy;
        }
    }
}
