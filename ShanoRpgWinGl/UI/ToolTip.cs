using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShanoRpgWinGl.UI
{
    class ToolTip : UserControl
    {
        string Text;

        Color BackColor = Color.DarkGray.SetAlpha(100);

        public override void Update(int msElapsed)
        {
            this.AbsolutePosition = ScreenInfo.ScreenToUi(mouseState.Position - new Point(10, 22));
            base.Update(msElapsed);
        }

        public override void Draw(SpriteBatch sb)
        {

            base.Draw(sb);
        }

        public void Show(string text)
        {

        }
    }
}
