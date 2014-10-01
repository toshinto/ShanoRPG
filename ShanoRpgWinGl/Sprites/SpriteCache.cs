using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShanoRpgWinGl.Sprites
{
    /// <summary>
    /// Contains information about the sprites stuff shit stack.
    /// </summary>
    class SpriteCache
    {

        public static Sprite BlankTexture { get; private set; }

        public static class Terrain
        {
            public static Sprite Grass { get; set; }
            public static Sprite Dirt { get; set; }

            public static Sprite GetSprite(MapTile t)
            {
                switch (t)
                {
                    case MapTile.Dirt:
                        return Dirt;
                    case MapTile.Grass:
                        return Grass;
                    default:
                        throw new Exception("Unrecognized MapTile. ");
                }
            }

            internal static void Load()
            {
                Grass = New(ResourceType.Terrain, "grass");
                Dirt = New(ResourceType.Terrain, "dirt");
            }
        }

        public static class Icon
        {
            public static Sprite Border { get; private set; }
            public static Sprite BorderHover { get; private set; }


            public static void Load()
            {
                Border = New(ResourceType.Icon, "border");
                BorderHover = New(ResourceType.Icon, "border_hover");
            }
        }

        private static readonly Point DefaultSize = new Point(1, 1);
        private static Dictionary<Texture2D, Point> defaultSizes = new Dictionary<Texture2D, Point>();

        public static void Load()
        {
            Icon.Load();
            Terrain.Load();

            BlankTexture = new Sprite(TextureCache.Get("1"));

            InitSpecialSprites();
        }

        /// <summary>
        /// Sets the default sizes for the default animated sprites. 
        /// </summary>
        private static void InitSpecialSprites()
        {
            SetDefaultSize(ResourceType.Model, "hero", 1, 3);
        }
        

        /// <summary>
        /// Sets the default size for the specified texture. 
        /// </summary>
        /// <param name="texPath"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public static void SetDefaultSize(ResourceType t, string texName, int r, int c)
        {
            var tex = TextureCache.Get(t, texName);

            defaultSizes[tex] = new Point(r, c);
        }

        public static Sprite New(ResourceType t, string texName)
        {
            var tex = TextureCache.Get(t, texName);

            Point sz = DefaultSize;

            if (defaultSizes.ContainsKey(tex))
                sz = defaultSizes[tex];

            return new Sprite(tex, sz.X, sz.Y);
        }
    }
}
