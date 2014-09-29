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
    public class LocalShano : IClient, IServer
    {
        public IHero LocalHero { get; private set; }

        public MovementState MovementState { get; set; }

        public event Action<Command, byte[]> OnSpecialAction;

        public readonly ShanoRpg ShanoGame;

        public readonly MainGame ShanoClient;

        public LocalShano(int mapSeed, IHero h)
        {
            MovementState = new MovementState();
            LocalHero = h;

            //create the local game client
            ShanoClient = new MainGame(h);

            //create the game engine
            //hack: should accept IHero?
            ShanoGame = new ShanoRpg(mapSeed, new Player((Hero)h, this));

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
            return ShanoGame.GetUnits(LocalHero);
        }

        public void RegisterAction(Command action, byte[] p)
        {
            if (OnSpecialAction != null)
                OnSpecialAction(action, p);
        }
    }
}
