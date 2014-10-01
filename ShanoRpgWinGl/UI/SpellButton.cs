using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IO;
using ShanoRpgWinGl.Sprites;

namespace ShanoRpgWinGl.UI
{
    class SpellButton : UserControl
    {
        private IAbility ability;

        public event Action AbilityChanged;

        private void OnAbilityChanged()
        {
            if (AbilityChanged != null)
                AbilityChanged();
        }

        public Keys Keybind { get; set; }

        public bool Clickable { get; set; }

        public IAbility Ability
        {
            get { return ability; }
            set
            {
                if (ability != value)
                {
                    ability = value;
                    OnAbilityChanged();
                }
            }
        }

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
            var tex = TextureCache.Get(ResourceType.Icon, Ability.Icon);
            sb.Draw(tex, ScreenPosition, ScreenSize);

            var border = MouseOver ? SpriteCache.Icon.BorderHover : SpriteCache.Icon.Border;

            border.Draw(sb, ScreenPosition, ScreenSize);

            var cdHeight = ScreenSize.Y * Ability.CurrentCooldown / Ability.Cooldown;
            if (cdHeight > 0)
            {
                var cdPos = new Point(ScreenPosition.X, ScreenPosition.Y + ScreenSize.Y - cdHeight);
                SpriteCache.BlankTexture.Draw(sb, cdPos, new Point(ScreenSize.X, cdHeight), Color.Black.SetAlpha(120));
            }
            base.Draw(sb);
        }
    }
}
