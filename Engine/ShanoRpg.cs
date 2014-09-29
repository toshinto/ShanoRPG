using Engine.Objects;
using Engine.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using IO;
using IO;
using ScriptLib;
using Engine.Systems;
//using Input;

namespace Engine
{
    public class ShanoRpg
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
        WorldMap WorldMap;


        /// <summary>
        /// A list of all players currently in game. 
        /// </summary>
        List<Player> Players;


        List<Ability> Abilities;


        Scenario scenario;

        /// <summary>
        /// Gets all entities currently in the game. 
        /// </summary>
        public IEnumerable<Unit> Entities
        {
            get { return WorldMap.Entities; }
        }

        public ShanoRpg(int mapSeed, Player localPlayer)
        {
            if (!loadScenario("Abilities"))
            {
                throw new Exception("Unable to compile some of the abilities!");
            }
            this.WorldMap = new WorldMap(mapSeed);

            this.Players = new List<Player>();

            this.AddPlayer(localPlayer);



            //start the update thread
            this.MainThread = new Thread(updateLoop)
            {
                IsBackground = true
            };
            MainThread.Start();

            var c = new ShanoMonster("Goshko", 1)
            {
                Location = new Vector(5, 5),
            };

            AddCreature(c);
        }

        public bool loadScenario(string scName)
        {
            scenario = new Scenario(scName);

            return scenario.TryCompile();
        }

        public void AddAbility(Hero h, string ability)
        {
            var a = scenario.CreateAbility(ability);

            a.Hero = h;
            a.Game = this;

            h.AddAbility(a);
        }

        public void AddPlayer(Player p)
        {
            this.Players.Add(p);
            this.WorldMap.AddEntity(p.Hero);

            AddAbility(p.Hero, "Attack");
        }

        public void AddCreature(ShanoMonster c)
        {
            this.WorldMap.AddEntity(c);
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
                e.Update(msElapsed);

            foreach (var p in Players)
                p.Update();

            //update local hero state
            //foreach()
        }

        public IEnumerable<Unit> GetUnitsInRange(Unit fromUnit, float range)
        {
            var rsq = range * range;
            return Entities
                .Where(e => e.Location.DistanceToSquared(fromUnit.Location) <= rsq);
        }

        public IEnumerable<IUnit> GetUnits(IHero h)
        {
            return Entities;
        }

        public void GetNearbyTiles(IHero h, ref MapTile[,] tileMap, out double heroX, out double heroY)
        {
            heroX = h.Location.X;
            heroY = h.Location.Y;

            const int xRange = 8;
            const int yRange = 5;
            const int xSize = xRange * 2 + 1;
            const int ySize = yRange * 2 + 1;

            var x = (int)Math.Floor(heroX - xRange);
            var y = (int)Math.Floor(heroY - yRange);

            if (tileMap.GetLength(0) < xSize ||tileMap.GetLength(1) < ySize)
                throw new ArgumentOutOfRangeException("Tile array should be larger than the given. ");

            WorldMap.GetMap(x, y, xSize, ySize, ref tileMap);
        }



        public void AddClient(IClient d)
        {
            throw new NotImplementedException();
        }
    }
}
