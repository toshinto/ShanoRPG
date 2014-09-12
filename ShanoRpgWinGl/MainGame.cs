#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Engine.Maps;
using Output;
using Input;
#endregion

namespace ShanoRpgWinGl
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TextureCache texCache;

        public OutputDevice GameDevice;

        /// <summary>
        /// Gets our local hero. 
        /// </summary>
        readonly IHero localHero;

        public readonly LocalInput LocalInput = new LocalInput();

        public MainGame(IHero h)
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.localHero = h;
        }

        /// <summary>
        /// Run at the beginning. 
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            //var heroTexture = Content.Load<Texture2D>("hero.bmp");

            texCache = new TextureCache(Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            //check local hero keys
            LocalInput.UpdateKeys();

            mapTiles = GameDevice.GetNearbyTiles(localHero);

            base.Update(gameTime);
        }

        MapTile[,] mapTiles;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Func<double, double, double> mod = (a, b) => ((a % b) + b) % b;

            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (GameDevice != null)
            {
                // TODO: Add your drawing code here
                spriteBatch.Begin();

                const int tileSize = 30;

                //get hero offset
                var off = new Point((int)(mod(localHero.X, 1) * tileSize), (int)(mod(localHero.Y, 1) * tileSize));


                //TODO: change with const
                int xRange = mapTiles.GetLength(0) / 2,
                    yRange = mapTiles.GetLength(1) / 2;

                int xHero = (int)localHero.X,
                    yHero = (int)localHero.Y;

                Console.WriteLine("{0} {1}", xHero, yHero);
                //draw the terrain
                for (int ix = -xRange; ix < xRange; ix++)
                    for (int iy = -yRange; iy < yRange; iy++)
                    {
                        double tileX = xHero + ix,
                            tileY = yHero + iy;

                        var t = mapTiles[ix + xRange, iy + yRange] == MapTile.Dirt ? texCache.DirtTile : texCache.GrassTile;
                        drawInGameTex(t, tileX, tileY, 1, 1);

                        //ix += xRange;
                        //iy += yRange;

                        //spriteBatch.Draw(t, new Rectangle(tileSize * ix - off.X, tileSize * iy - off.Y, tileSize, tileSize), Color.White);
                    }
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// Draws the given texture at the specified in-game coordinates. 
        /// </summary>
        /// <param name="tex"></param>
        /// <param name="gameX"></param>
        /// <param name="gameY"></param>
        /// <param name="gameWidth"></param>
        /// <param name="gameHeight"></param>
        private void drawInGameTex(Texture2D tex, double gameX, double gameY, double gameWidth, double gameHeight)
        {
            //screen pixel width/height
            var spw = 840;
            var sph = 480;

            var sgw = 14;
            var sgh = 10;

            var x = (int)((gameX - localHero.X) * spw / sgw);
            var y = (int)((gameY - localHero.Y) * sph / sgh);

            var w = (int)(gameWidth * spw / sgw);
            var h = (int)(gameWidth * spw / sgw);

            spriteBatch.Draw(tex, new Rectangle(x, y, w, h), Color.Red);
        }
    }
}
