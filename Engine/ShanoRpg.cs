using Engine.Objects;
using Engine.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Output;
using Input;
//using Input;

namespace Engine
{
    public class ShanoRpg : OutputDevice
    {
        /// <summary>
        /// The frames per second we aim to run at. 
        /// </summary>
        const int FPS = 60;

        //public InputDevice LocalInput;

        public readonly Thread MainThread;

        /// <summary>
        /// The current world map. 
        /// </summary>
        Map WorldMap;

        /// <summary>
        /// A list of all the (spawned) monsters in the game. 
        /// </summary>
        List<Creature> Monsters;

        /// <summary>
        /// A list of all heroes in the game. 
        /// </summary>
        List<Player> Players;

        /// <summary>
        /// Gets all entities currently in the game. 
        /// </summary>
        public IEnumerable<Entity> Entities
        {
            get
            {
                foreach (var m in Monsters)
                    yield return m;
                foreach (var p in Players)
                    yield return p.Hero;
            }
        }

        public ShanoRpg(int mapSeed, Player localPlayer)
        {
            this.WorldMap = new Map(mapSeed);

            this.Monsters = new List<Creature>();

            this.Players = new List<Player>();

            this.AddPlayer(localPlayer);

            //start the update thread
            this.MainThread = new Thread(updateLoop)
            {
                IsBackground = true
            };
            MainThread.Start();
        }

        public void AddPlayer(Player p)
        {
            this.Players.Add(p);
        }

        void LocalInput_OnAbilityCast(int obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs the basic game loop. 
        /// </summary>
        private void updateLoop()
        {
            int frameStartTime, drawTime = 0;
            while(true)
            {
                var toSleep = 1000 / FPS - drawTime;
                var isThrottled = toSleep < 0;

                if (!isThrottled)
                    Thread.Sleep(toSleep);
                else
                    Console.WriteLine("Warning: Drawing too slow!");
                frameStartTime = Environment.TickCount;
                this.Update(1000 / FPS);
                drawTime = Environment.TickCount - frameStartTime;
            }
        }

        private void Update(int msElapsed)
        {

            foreach (var e in Entities)
                e.UpdateBuffs(msElapsed);

            foreach (var p in Players)
            {
                p.Hero.UpdateMovement(msElapsed);
            }

            //update local hero state
            //foreach()
        }

        public IEnumerable<IEntity> GetEntities(IHero h)
        {
            return Entities;
        }

        public MapTile[,] GetNearbyTiles(IHero h)
        {
            const int xRange = 7;
            const int yRange = 5;
            const int xSize = xRange * 2 + 1;
            const int ySize = yRange * 2 + 1;
            var x = (int)(h.X - xRange);
            var y = (int)(h.Y - yRange);


            var tileMap = new MapTile[xSize, ySize];
            WorldMap.GetMap(x, y, xSize, ySize, ref tileMap);

            return tileMap;
        }



        public void AddInputDevice(InputDevice d)
        {
            throw new NotImplementedException();
        }
    }
}
