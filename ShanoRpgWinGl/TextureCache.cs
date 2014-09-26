using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ShanoRpgWinGl
{
    static class TextureCache
    {
        public static Sprite GrassTile { get; private set; }
        public static Sprite DirtTile { get; private set; }
        public static AnimatedSprite InGameHero { get; set; }

        public static Sprite BlankTexture { get; private set; }
        public static Sprite IconBorder { get; private set; }

        public static IEnumerable<Sprite> Sprites
        {
            get { return sprites.Values; }
        }

        private static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

        public static TextureFont MainFont { get; private set; }

        private static ContentManager content;
        public static void LoadContent(ContentManager content)
        {
            TextureCache.content = content;
            loadTextures();

            //load fonts
            MainFont = new TextureFont(content, "Fonts\\UI", 0.8f);
        }

        /// <summary>
        /// Load the textures and bind them to locals here. 
        /// </summary>
        static void loadTextures()
        {
            loadIcons();
            GrassTile = loadSprite(@"terrain\grass");
            DirtTile = loadSprite(@"terrain\dirt");
            BlankTexture = loadSprite("1");

            InGameHero = loadSprite(@"units\hero", 1, 3, 50);

        }

        const string contentDir = @"Content\";
        const string iconFolder = @"Icons\";
        private static void loadIcons()
        {
            var iconDir = Path.Combine(contentDir, iconFolder);
            foreach (var f in Directory.EnumerateFiles(iconDir, "*.png", SearchOption.AllDirectories))
            {
                var fne = f
                    .Take(f.LastIndexOf("."))
                    .Skip(contentDir.Length);
                var fn = new string(fne.ToArray());

                loadSprite(fn);
            }

            IconBorder = GetIcon("border");
        }

        public static Sprite GetIcon(string iconName)
        {
            var iconId = Path.Combine(iconFolder, iconName);
            return sprites[iconId];
        }



        /// <summary>
        /// Loads a single texture into the cache and then returns it. 
        /// </summary>
        static SimpleSprite loadSprite(string name)
        {
            var tex = content.Load<Texture2D>(name);
            var sprite = new SimpleSprite(tex);
            sprites.Add(name, sprite);
            return sprite;
        }

        static AnimatedSprite loadSprite(string name, int rows, int cols, int speed = 1)
        {
            var tex = content.Load<Texture2D>(name);
            var sprite = new AnimatedSprite(tex, 1, 3)
            {
                Period = speed,
            };
            sprites.Add(name, sprite);
            return sprite;
        }



    }
}
