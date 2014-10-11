using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Content;

namespace ShanoRpgWinGl
{
    class TextureFont
    {
        Rectangle[] keys = new Rectangle[256];

        private readonly int _baseHeight;

        public readonly float _baseScale;

        public double Height
        {
            get { return _baseHeight * Scale; }
        }

        public double Scale
        {
            get {  return _baseScale * ScreenInfo.FontScale; }
        }

        public readonly Texture2D Texture;

        public TextureFont(ContentManager content, string name, float scale = 1f)
        {
            this._baseScale = scale;
            this.Texture = content.Load<Texture2D>(name);

            var xmlSchema = new XmlDocument();
            xmlSchema.Load("Content\\" + name + ".xml");

            foreach(XmlNode node in xmlSchema.SelectNodes("font/chars/char"))
            {
                //var sId = node.Attributes.GetNamedItem("key").Value;

                //var id = parseInt(sId);
                var id = parseInt(node.Attributes.GetNamedItem("id").InnerText);
                var x = parseInt(node.Attributes.GetNamedItem("x").InnerText);
                var y = parseInt(node.Attributes.GetNamedItem("y").InnerText);
                var w = parseInt(node.Attributes.GetNamedItem("width").InnerText);
                var h = parseInt(node.Attributes.GetNamedItem("height").InnerText);
                if(x == -1 || y == -1 || w == -1 || h == -1 || id == -1)
                    continue;

                keys[id] = new Rectangle(x, y + 1, w, h - 1);
                _baseHeight = Math.Max(_baseHeight, w);
            }
        }

        public TextureFont(TextureFont f, float relativeScale = 1f)
        {
            this.Texture = f.Texture;
            this._baseScale = f._baseScale * relativeScale;

            this.keys = f.keys.Clone() as Rectangle[];
        }

        public int CharacterSpacing { get; set; }

        public void DrawMultilineString(SpriteBatch sb, string text, Color col, int x, int y, float xAnchor = 0.0f, float yAnchor = 0.5f)
        {
            var lines = text.Split('\n');

        }

        public void DrawString(SpriteBatch sb, string text, Color col, int x, int y, float xAnchor = 0.0f, float yAnchor = 0.5f)
        {
            var txtSize = measureString(text);

            x -= (int)(xAnchor * txtSize.X);
            foreach(var c in text)
            {
                DrawChar(sb, c, col, x, y, yAnchor);
                var sz = getSize(c);
                x += sz.X + this.CharacterSpacing;
            }
        }

        private Point measureString(string text)
        {
            return (text ?? string.Empty).Aggregate(Point.Zero, (acc, c) => getSize(c) + new Point(acc.X, 0));
        }

        public void DrawChar(SpriteBatch sb, char c, Color col, int x, int y, float yAnchor = 0.5f)
        {
            if(keys[c] == Rectangle.Empty)
                throw new ArgumentOutOfRangeException("Character '" + c + "' does not exist in the current font. ");

            var sz = getSize(c);

            y -= (int)(yAnchor * sz.Y);
            sb.Draw(Texture, new Rectangle(x, y, sz.X, sz.Y), keys[c], col);
        }

        private Point getSize(char c)
        {
            return new Point((int)(Scale * keys[c].Width), (int)(Scale * keys[c].Height));
        }

        private int parseInt(string i)
        {
            int id = -1;
            int.TryParse(i, out id);
            return id;
        }
    }
}
