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

        public readonly Texture2D Texture;

        public readonly float Scale;

        public TextureFont(ContentManager content, string name, float scale = 1f)
        {
            this.Scale = scale;
            this.Texture = content.Load<Texture2D>(name);

            var xmlSchema = new XmlDocument();
            xmlSchema.Load("Content\\" + name + ".xml");

            foreach(XmlNode node in xmlSchema.SelectNodes("fontMetrics/character"))
            {
                var sId = node.Attributes.GetNamedItem("key").Value;

                var id = shanoParse(sId);
                var x = shanoParse(node.SelectSingleNode("x").InnerText);
                var y = shanoParse(node.SelectSingleNode("y").InnerText);
                var w = shanoParse(node.SelectSingleNode("width").InnerText);
                var h = shanoParse(node.SelectSingleNode("height").InnerText);
                if(x == -1 || y == -1 || w == -1 || h == -1 || id == -1)
                    continue;

                keys[id] = new Rectangle(x, y + 1, w, h - 1);
            }
        }

        public TextureFont(TextureFont f, float relativeScale = 1f)
        {
            this.Texture = f.Texture;
            this.Scale = f.Scale * relativeScale;

            this.keys = f.keys.Clone() as Rectangle[];
        }

        public int CharacterSpacing { get; set; }

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
                throw new ArgumentOutOfRangeException("c");
            var sz = getSize(c);

            y -= (int)(yAnchor * sz.Y);
            sb.Draw(Texture, new Rectangle(x, y, sz.X, sz.Y), keys[c], col);
        }

        private Point getSize(char c)
        {
            return new Point((int)(Scale * keys[c].Width), (int)(Scale * keys[c].Height));
        }

        private int shanoParse(string i)
        {
            int id;
            if (int.TryParse(i, out id))
                return id;
            else
                return -1;
        }
    }
}
