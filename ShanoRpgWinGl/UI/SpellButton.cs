using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IO;

namespace ShanoRpgWinGl.UI
{
    class SpellButton : UserControl
    {
        public IAbility Ability { get;set; }

        public Keys Keybind { get; set; }

        public bool Clickable { get; set; }

        public SpellButton(Keys k = Keys.None)
        {
            this.Size = new Vector2(0.12f, 0.12f);
            this.Keybind = k;

            this.MouseDown += onMouseDown;
        }

        private void onMouseDown(Vector2 p)
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            TextureCache.Icon.Get(Ability.Icon).Draw(sb, ScreenPosition, ScreenSize);

            var border = MouseOver ? TextureCache.Icon.BorderHover : TextureCache.Icon.Border;

            border.Draw(sb, ScreenPosition, ScreenSize);

            var cdHeight = ScreenSize.Y * Ability.CurrentCooldown / Ability.Cooldown;
            if (cdHeight > 0)
            {
                var cdPos = new Point(ScreenPosition.X, ScreenPosition.Y + ScreenSize.Y - cdHeight);
                TextureCache.BlankTexture.Draw(sb, cdPos, new Point(ScreenSize.X, cdHeight), Color.Black.SetAlpha(120));
            }
            base.Draw(sb);
        }
    }
}
