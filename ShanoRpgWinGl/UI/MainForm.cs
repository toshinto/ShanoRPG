using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Output;

namespace ShanoRpgWinGl.UI
{
    class MainForm : UserControl
    {
        readonly HeroUI heroUi;

        readonly SpellButton mainAbilityButton;

        readonly IHero hero;

        readonly LocalInput input;

        public MainForm(IHero hero, LocalInput input)
        {
            this.Size = new Vector2(2f, 2f);
            this.AbsolutePosition = new Vector2(-1, -1);
            this.hero = hero;
            this.input = input;
            
            this.heroUi = new HeroUI(hero);

            this.mainAbilityButton = new SpellButton()
            {
                Ability = hero.Abilities.First(),
                AbsolutePosition = new Vector2(0.3f, 0.3f),
            };
            this.Add(heroUi, false);
            this.Add(mainAbilityButton, false);

            this.MouseDown += mouseDown;
        }

        public override void Update(int msElapsed)
        {
            var min = ScreenInfo.ScreenToUi(Point.Zero);
            var max = ScreenInfo.ScreenToUi(new Point(ScreenInfo.ScreenSize.X, ScreenInfo.ScreenSize.Y));

            //use the field so we don't move children..
            this.absolutePosition = min;
            this.Size = max - min;

            base.Update(msElapsed);
        }


        private void mouseDown(Vector2 p)
        {
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                input.RegisterAction(mainAbilityButton.Ability.Name);
        }
    }
}
