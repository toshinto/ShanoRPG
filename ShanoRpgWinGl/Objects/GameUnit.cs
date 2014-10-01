using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShanoRpgWinGl.Sprites;

namespace ShanoRpgWinGl.Objects
{
    class GameUnit
    {
        public Sprite Sprite { get; private set; }

        public IUnit Unit { get; private set; }

        public GameUnit(IUnit u)
        {
            Sprite = SpriteCache.New(ResourceType.Model, u.Model);
            Unit = u;
        }

        public void Draw(SpriteBatch sb)
        {
            var moving = false;
            Sprite.Period = moving ? 100 : 1000;

            Vector2 sz = new Vector2((float)Unit.Size);
            Sprite.DrawInGame(sb, Unit.Location.ToVector2() - sz / 2, sz);
        }
    }
}
