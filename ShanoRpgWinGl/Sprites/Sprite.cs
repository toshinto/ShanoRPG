using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace ShanoRpgWinGl
{
    abstract class Sprite
    {
        public abstract void Draw(SpriteBatch spriteBatch, Point location, Point? size, Color? color);
        public abstract void DrawInGame(SpriteBatch spriteBatch, Vector2 location, Vector2 size, Color? color);
        public abstract void Update(int msElapsed);

        //smelly
        public void Draw(SpriteBatch spriteBatch, Point location)
        {
            Draw(spriteBatch, location, null, null);
        }
        public void Draw(SpriteBatch spriteBatch, Point location, Point size)
        {
            Draw(spriteBatch, location, size, null);
        }
        public void DrawInGame(SpriteBatch spriteBatch, Vector2 location, Vector2 size)
        {
            DrawInGame(spriteBatch, location, size, null);
        }
    }
}
