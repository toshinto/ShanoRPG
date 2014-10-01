using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShanoRpgWinGl.Sprites;

namespace ShanoRpgWinGl.UI
{
    class HeroUI : UserControl
    {
        public readonly IHero Hero;

        public readonly ValueLabel strength = new ValueLabel()
        {
            Text = "Strength: ",
        };

        public readonly ValueLabel agility = new ValueLabel()
        {
            Text = "Agility: ",
        };

        public readonly ValueLabel intellect = new ValueLabel()
        {
            Text = "Intelligence: ",
        };

        public readonly ValueLabel vitality = new ValueLabel()
        {
            Text = "Vitality: ",
        };

        public readonly ValueLabel moveSpeed = new ValueLabel()
        {
            Text = "Speed: ",
        };

        public readonly ValueLabel armor = new ValueLabel()
        {
            Text = "Armor: ",
        };

        public readonly ValueLabel damage = new ValueLabel()
        {
            Text = "Damage: ",
        };


        public readonly ValueBar hpBar;

        public readonly ValueBar manaBar;

        public HeroUI(IHero h)
        {
            Size = new Vector2(1.2f, 0.45f);
            AbsolutePosition = new Vector2(0 - Size.X / 2, 1 - Size.Y);

            this.Hero = h;
            this.Locked = false;

            hpBar = new ValueBar()
            {
                Size = new Vector2(Size.X - 2 * Anchor, 0.05f),
                RelativePosition = new Vector2(Anchor, Anchor),
                ForeColor = Color.DarkRed,
                ClickThrough = true,
                ShowText = true,
            };
            manaBar = new ValueBar()
            {
                Size = hpBar.Size,
                RelativePosition = new Vector2(Anchor, hpBar.Bottom + Anchor),
                ForeColor = Color.DarkBlue,
                ClickThrough = true,
                ShowText = true,
            };

            strength.RelativePosition = new Vector2(Anchor, manaBar.Bottom + Anchor);
            agility.RelativePosition = new Vector2(Anchor, strength.Bottom);
            intellect.RelativePosition = new Vector2(Anchor, agility.Bottom);
            vitality.RelativePosition = new Vector2(Anchor, intellect.Bottom);

            damage.RelativePosition = new Vector2(strength.Right + Anchor, strength.RelativePosition.Y);
            armor.RelativePosition = new Vector2(damage.RelativePosition.X, damage.Bottom + Anchor * 3);
            moveSpeed.RelativePosition = new Vector2(damage.RelativePosition.X, armor.Bottom);

            this.Add(moveSpeed);
            this.Add(armor);
            this.Add(damage);

            this.Add(strength);
            this.Add(agility);
            this.Add(intellect);
            this.Add(vitality);

            this.Add(hpBar);
            this.Add(manaBar);
        }

        public override void Update(int msElapsed)
        {

            strength.Value = Hero.CurrentStrength.ToString("0");
            agility.Value = Hero.CurrentAgility.ToString("0");
            intellect.Value = Hero.CurrentIntellect.ToString("0");
            vitality.Value = Hero.CurrentVitality.ToString("0");

            moveSpeed.Value = Hero.CurrentMoveSpeed.ToString("0.0");
            armor.Value = Hero.CurrentDefense.ToString("0.0");
            damage.Value = Hero.CurrentMinDamage + "-" + Hero.CurrentMaxDamage;

            hpBar.Value = Hero.CurrentLife;
            hpBar.MaxValue = Hero.CurrentMaxLife;

            manaBar.Value = Hero.CurrentMana;
            manaBar.MaxValue = Hero.CurrentMaxMana;

            base.Update(msElapsed);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var backColor = new Color(50, 50, 50, 200);
            SpriteCache.BlankTexture.Draw(spriteBatch, ScreenPosition, ScreenSize, backColor);

            base.Draw(spriteBatch);
        }

        
    }
}
