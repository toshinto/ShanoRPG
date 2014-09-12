using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShanoRpgWinGl
{
    class TextureCache
    {
        readonly ContentManager content;

        public Dictionary<string, Texture2D> texCache;

        public Texture2D GrassTile { get; private set; }
        public Texture2D DirtTile { get; private set; }

        /// <summary>
        /// Returns the texture with the specified name. 
        /// </summary>
        public Texture2D this[string s]
        {
            get { return texCache[s]; }
        }

        public TextureCache(ContentManager content)
        {
            texCache = new Dictionary<string, Texture2D>();
            this.content = content;

            loadTextures();
        }

        /// <summary>
        /// Load the textures and bind them to locals here. 
        /// </summary>
        protected void loadTextures()
        {
            GrassTile = loadTexture("grass");
            DirtTile = loadTexture("dirt");
        }




        /// <summary>
        /// Loads a single texture into the cache and then returns it. 
        /// </summary>
        protected Texture2D loadTexture(string name)
        {
            var tex = content.Load<Texture2D>(name);
            texCache.Add(name, tex);
            return tex;
        }
    }
}
