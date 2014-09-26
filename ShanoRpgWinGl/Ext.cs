using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShanoRpgWinGl
{
    public static class Ext
    {
        public static Color SetAlpha(this Color c, int a)
        {
            return new Color(c.R, c.G, c.B, a);
        }
    }
}
