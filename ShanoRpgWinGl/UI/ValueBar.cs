using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShanoRpgWinGl.Sprites;

namespace ShanoRpgWinGl.UI
{
    class ValueBar : UserControl
    {
        public bool ShowText = false;

        public double Value;

        public double MaxValue;

        public Color BackColor = new Color(64, 64, 64, 64);
        public Color ForeColor = Color.Azure;

        public ValueBar()
        {

        }

        public override void Draw(SpriteBatch sb)
        {

            SpriteCache.BlankTexture.Draw(sb, ScreenPosition, ScreenSize, BackColor);

            if (MaxValue > 0)
            {
                SpriteCache.BlankTexture.Draw(sb, ScreenPosition, new Point((int)(ScreenSize.X * Value / MaxValue), ScreenSize.Y), ForeColor);
            }

            if (ShowText)
            {
                var text = MaxValue != 0 ? (Value.ToString("0") + "/" + MaxValue.ToString("0")) : "N/A";
                var textPos = new Point(ScreenPosition.X + ScreenSize.X / 2, ScreenPosition.Y + ScreenSize.Y / 2);
                TextureCache.MainFont.DrawString(sb, text, Color.White, textPos.X, textPos.Y, 0.5f, 0.5f);
            }
        }
    }
}
