using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShanoRpgWinGl
{
    class SimpleSprite : Sprite
    {

        public Texture2D Texture { get; set; }

        public SimpleSprite(Texture2D texture)
        {
            this.Texture = texture;
        }
        public override void Update(int msElapsed)
        {
            //nothing to see here. 
        }

        public override void Draw(SpriteBatch spriteBatch, Point location, Point? size, Color? color)
        {
            var s = size ?? new Point(Texture.Width, Texture.Height);
            var c = color ?? Color.White;

            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Rectangle destinationRectangle = new Rectangle(location.X, location.Y, s.X, s.Y);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, c);
        }

        public override void DrawInGame(SpriteBatch spriteBatch, Vector2 gameLocation, Vector2 gameSize, Color? c)
        {
            var pLoc = ScreenInfo.GameToScreen(gameLocation);
            var farPos = ScreenInfo.GameToScreen(gameLocation + gameSize);
            var pSize = farPos - pLoc;

            Draw(spriteBatch, pLoc, pSize, c);
        }
    }
}
