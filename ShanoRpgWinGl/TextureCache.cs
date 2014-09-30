using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using IO;

namespace ShanoRpgWinGl
{
    static class TextureCache
    {
        /// <summary>
        /// The directory where all the resources are. 
        /// </summary>
        const string ContentDir = @"Content\";

        public static class Terrain
        {
            public static Sprite Grass { get; set; }
            public static Sprite Dirt { get; set; }

            public static Sprite GetSprite(MapTile t)
            {
                switch (t)
                {
                    case MapTile.Dirt:
                        return TextureCache.Terrain.Dirt;
                    case MapTile.Grass:
                        return TextureCache.Terrain.Grass;
                    default:
                        throw new Exception("Unrecognized MapTile. ");
                }
            }
        }

        public static class Icon
        {
            private static Dictionary<string, Sprite> icons = new Dictionary<string, Sprite>();

            public static Sprite Border { get; private set; }
            public static Sprite BorderHover { get; private set; }

            public static IReadOnlyDictionary<string, Sprite> Icons
            {
                get { return icons; }
            }

            const string Directory = @"Icons\";

            public static void Load()
            {
                var iconDir = Path.Combine(ContentDir, Directory);
                foreach (var f in System.IO.Directory.EnumerateFiles(iconDir, "*.png", SearchOption.AllDirectories))
                {
                    var fne = f
                        .Take(f.LastIndexOf("."))
                        .Skip(ContentDir.Length);
                    var fn = new string(fne.ToArray());

                    loadSprite(fn);
                }

                Border = Get("border");
                BorderHover = Get("border_hover");
            }


            public static Sprite Get(string s)
            {
                var iconId = Path.Combine(Directory, s);
                return sprites[iconId];
            }
        }

        public static AnimatedSprite InGameHero { get; set; }

        public static Sprite BlankTexture { get; private set; }

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
            Icon.Load();
            Terrain.Grass = loadSprite(@"terrain\grass");
            Terrain.Dirt = loadSprite(@"terrain\dirt");
            BlankTexture = loadSprite("1");

            InGameHero = loadSprite(@"units\hero", 1, 3, 50);

        }


        internal static object GetResouce(string model)
        {
            return sprites[model];
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
