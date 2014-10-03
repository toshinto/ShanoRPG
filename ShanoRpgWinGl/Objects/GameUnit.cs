using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShanoRpgWinGl.Sprites;
using ShanoRpgWinGl.UI;

namespace ShanoRpgWinGl.Objects
{
    class GameUnit : UserControl
    {
        public Sprite Sprite { get; private set; }

        public IUnit Unit { get; private set; }

        public Point CenterPoint
        {
            get { return ScreenPosition + ScreenSize.DivideBy(2); }
        }

        public GameUnit(IUnit u)
        {
            Sprite = SpriteCache.New(ResourceType.Model, u.Model);
            Unit = u;
        }

        public override void Update(int msElapsed)
        {
            Sprite.Update(msElapsed);

            var loc = Unit.Location.ToVector2();
            Vector2 sz = new Vector2((float)Unit.Size / 2);

            var posLo = ScreenInfo.GameToUi(loc - sz);
            var posHi = ScreenInfo.GameToUi(loc + sz);

            this.AbsolutePosition = posLo;
            this.Size = posHi - posLo;

            base.Update(msElapsed);
        }

        public void Draw(SpriteBatch sb)
        {
            var moving = false;
            Sprite.Period = moving ? 100 : 1000;

            Vector2 sz = new Vector2((float)Unit.Size);
            Sprite.Draw(sb, ScreenPosition, ScreenSize);

            if (MouseOver)
            {

                TextureCache.MainFont.DrawString(sb, Unit.CurrentLife.ToString(), Color.Red, ScreenPosition.X, ScreenPosition.Y, 0.5f, 1f);
            }
        }
    }
}
