using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Engine.Objects;
using IO;
using ShanoRpgWinGl;

namespace Local
{
    /// <summary>
    /// Represents a locally played game. 
    /// Automatically starts both the engine and the client. 
    /// </summary>
    public class LocalShano : IClient, IServer
    {
        public Hero LocalHero { get; private set; }

        public MovementState MovementState { get; set; }

        IHero IServer.LocalHero
        {
            get { return LocalHero; }
        }

        public event Action<Command, byte[]> OnSpecialAction;

        /// <summary>
        /// Gets the game engine. 
        /// </summary>
        public readonly ShanoRpg ShanoGame;

        /// <summary>
        /// Gets the game client. 
        /// </summary>
        public readonly MainGame ShanoClient;

        /// <summary>
        /// Creates a new local game instance, putting the provided hero in the map with the specified seed. 
        /// </summary>
        /// <param name="mapSeed">The map seed. </param>
        /// <param name="h">The hero to play with. </param>
        public LocalShano(int mapSeed, Hero h)
        {
            MovementState = new MovementState();
            LocalHero = h;

            //create the local game client
            ShanoClient = new MainGame(h);

            //create the game engine
            //hack: should accept IHero?
            ShanoGame = new ShanoRpg(mapSeed, new Player(h, this));

            //link them
            ShanoClient.Server = this;

            //start the client
            ShanoClient.Running = true;
        }


        public void GetNearbyTiles(ref MapTile[,] tiles, out double x, out double y)
        {
            ShanoGame.GetNearbyTiles(LocalHero, ref tiles, out x, out y);
        }

        public IEnumerable<IUnit> GetUnits()
        {
            return ShanoGame.GetNearbyUnits(LocalHero);
        }

        public void RegisterAction(Command action, byte[] p)
        {
            if (OnSpecialAction != null)
                OnSpecialAction(action, p);
        }
    }
}
