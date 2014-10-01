using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShanoRpgWinGl.Sprites
{
    static class TextureExt
    {
        public static void Draw(this SpriteBatch sb, Texture2D tex, Point screenPosition, Point screenSize)
        {
            Draw(sb, tex, screenPosition, screenSize, Color.White);
        }

        public static void Draw(this SpriteBatch sb, Texture2D tex, Point screenPosition, Point screenSize, Color color)
        {
            var destinationRectangle = new Rectangle(screenPosition.X, screenPosition.Y, screenSize.X, screenSize.Y);
            sb.Draw(tex, destinationRectangle, color);
        }
    }
}
