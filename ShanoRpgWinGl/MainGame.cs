#region Using Statements
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Output;
using Input;
using System.Xml;
using ShanoRpgWinGl.UI;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

namespace ShanoRpgWinGl
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Game
    {
        public OutputDevice GameDevice;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MapTile[,] mapTiles = new MapTile[Constants.Game.ScreenWidth + 5, Constants.Game.ScreenHeight + 5];

        MainForm mainInterface;

        /// <summary>
        /// Gets our local hero. 
        /// </summary>
        readonly IHero localHero;

        IEnumerable<IEntity> entities;

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

            mainInterface = new MainForm(localHero, LocalInput);

            ScreenInfo.CenterPoint = new Vector2((float)localHero.Location.X, (float)localHero.Location.Y);
            ScreenInfo.ScreenSize = new Point(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            this.IsMouseVisible = true;
            this.Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += Window_ClientSizeChanged;
            Window_ClientSizeChanged(null, null);
        }


        int sizeChangeCounter = 0;

        Rectangle lastWindowBounds;
        private async void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            var s = this.Window.ClientBounds;
            if (s != lastWindowBounds)
            {
                lastWindowBounds = s;
                graphics.PreferredBackBufferWidth = s.Width;
                graphics.PreferredBackBufferHeight = s.Height;
                graphics.ApplyChanges();
            }
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

            TextureCache.LoadContent(Content);

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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here

            var msElapsed = (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            //check local hero keys
            LocalInput.UpdateKeys();

            //update sprites
            foreach (var sprite in TextureCache.Sprites)
                sprite.Update(msElapsed);

            //update UI
            mainInterface.Update(msElapsed);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //get terrain, hero info. 
            double x, y;
            GameDevice.GetNearbyTiles(localHero, ref mapTiles, out x, out y);

            entities = GameDevice.GetEntities(localHero)
                .Where(h => h != localHero);

            //update cameraInfo
            ScreenInfo.CenterPoint = new Vector2((float)x, (float)y);
            ScreenInfo.ScreenSize = new Point(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            //cameraInfo.ScreenSize = new Point(800, 480);

            if (GameDevice != null)
            {
                //start drawing
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullNone);

                drawTerrain();
                drawHero();

                //interface
                mainInterface.Draw(spriteBatch);

                //position
                var mp = ScreenInfo.ScreenToUi(Mouse.GetState().Position);
                var debugStr = string.Format(
                    "UI: {0} {1}", mp.X.ToString("0.00"), mp.Y.ToString("0.00"));

                TextureCache.MainFont.DrawString(spriteBatch, debugStr, Color.Black, 24, 24, 0.0f);

                //fps
                var fps = (1000 / gameTime.ElapsedGameTime.TotalMilliseconds).ToString("00");
                TextureCache.MainFont.DrawString(spriteBatch, fps, Color.Goldenrod, 10, 10, 0.0f);

                //end drawing
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private void drawHero()
        {
            var moving = (LocalInput.State.XDirection | LocalInput.State.YDirection) != 0;
            TextureCache.InGameHero.Period = moving ? 100 : 1000;
            Vector2 heroSize = new Vector2(0.8f, 0.8f);
            TextureCache.InGameHero.DrawInGame(spriteBatch, ScreenInfo.CenterPoint - heroSize / 2, heroSize);
        }

        private void drawEntity(IEntity u)
        {

        }

        private void drawTerrain()
        {
            int xRange = Constants.Game.ScreenWidth / 2,
                yRange = Constants.Game.ScreenHeight / 2;

            int xHero = (int)Math.Floor(ScreenInfo.CenterPoint.X),
                yHero = (int)Math.Floor(ScreenInfo.CenterPoint.Y);

            //draw the terrain
            for (int ix = -xRange; ix <= xRange; ix++)
                for (int iy = -yRange; iy <= yRange; iy++)
                {
                    var tileX = xHero + ix;
                    var tileY = yHero + iy;

                    var mapTile = mapTiles[ix + xRange, iy + yRange];

                    Sprite tileTexture = null;
                    switch (mapTile)
                    {
                        case MapTile.Dirt:
                            tileTexture = TextureCache.DirtTile;
                            break;
                        case MapTile.Grass:
                            tileTexture = TextureCache.GrassTile;
                            break;
                        default:
                            throw new Exception("nmz e");
                    }

                    tileTexture.DrawInGame(spriteBatch, new Vector2(tileX, tileY), new Vector2(1, 1));
                }
        }
    }
}
