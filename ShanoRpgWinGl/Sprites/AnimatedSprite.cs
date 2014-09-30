using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShanoRpgWinGl
{
    class AnimatedSprite : Sprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public int Period { get; set; }

        private int timeElapsed = 0;

        public AnimatedSprite(Texture2D texture, int rows, int columns, int period = 500)
        {
            if (rows < 1 || columns < 1)
                throw new ArgumentOutOfRangeException("Number of cells must be a positive integer. ");
            this.Texture = texture;
            this.Rows = rows;
            this.Columns = columns;

            for(int ix = 0; ix < rows; ix++)
                for(int iy = 0; iy < rows; iy++)

            currentFrame = 0;
            totalFrames = Rows * Columns;

            this.Period = period;
        }

        public override void Update(int msElapsed)
        {
            if (totalFrames == 1)
                return;
            timeElapsed += msElapsed;
            while(timeElapsed > Period)
            {
                timeElapsed -= Period;
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Point location, Point? size, Color? color)
        {
            var c = color ?? Color.White;
            var s = size ?? new Point(Texture.Width, Texture.Height);

            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;

            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X, location.Y, s.X, s.Y);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, c);
        }

        public override void DrawInGame(SpriteBatch spriteBatch, Vector2 gameLocation, Vector2 gameSize, Color? color)
        {
            var pLoc = ScreenInfo.GameToScreen(gameLocation);
            var farPos = ScreenInfo.GameToScreen(gameLocation + gameSize);
            var pSize = farPos - pLoc;

            Draw(spriteBatch, pLoc, pSize, color);
        }
    }
}
