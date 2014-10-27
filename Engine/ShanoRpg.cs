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
        /// The current world map containing the terrain info. 
        /// </summary>
        WorldMap WorldMap;

        /// <summary>
        /// The current game map containing unit/doodad/sfx info. 
        /// </summary>
        GameMap GameMap;


        /// <summary>
        /// A list of all players currently in game. 
        /// </summary>
        List<Player> Players;


        Scenario scenario;


        public ShanoRpg(int mapSeed, Player localPlayer)
        {
            if (!loadScenario("Abilities"))
            {
                throw new Exception("Unable to compile some of the abilities!");
            }
            this.WorldMap = new WorldMap(mapSeed);

            this.Players = new List<Player>();

            this.GameMap = new GameMap();

            this.AddPlayer(localPlayer);



            //start the update thread
            this.MainThread = new Thread(updateLoop)
            {
                IsBackground = true
            };
            MainThread.Start();

            //add a random fuckin monster. 
            var c = new ShanoMonster("Goshko", 1)
            {
                Location = new Vector(5, 5),
            };
            c.CurrentLife = c.CurrentMaxLife;

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
            a.Map = GameMap;

            h.AddAbility(a);
        }

        public void AddPlayer(Player p)
        {
            this.Players.Add(p);

            //add his hero to the map. 
            this.GameMap.AddUnit(p.Hero);

            //add a placeholder spell till we figure something better. 
            AddAbility(p.Hero, "Attack");
        }

        public void AddCreature(ShanoMonster c)
        {
            this.GameMap.AddUnit(c);
        }

        /// <summary>
        /// Performs the basic game loop. 
        /// </summary>
        private void updateLoop()
        {
            int frameStartTime, drawTime = 0;
            while(true)
            {
                var toSleep = 1000 / FPS - drawTime;    //time to sleep
                var isThrottled = toSleep < 0;          //or no sleep?

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
            GameMap.Update(msElapsed);


            foreach (var p in Players)
                p.Update();
        }

        public IEnumerable<IUnit> GetNearbyUnits(Hero h)
        {
            var unitRange = (Vector)Constants.ClientParams.WindowSize / 2 + 1;
            return GameMap.GetUnitsInRect(h.Location - unitRange, unitRange * 2);
        }

        public void GetNearbyTiles(IHero h, ref MapTile[,] tileMap, out double heroX, out double heroY)
        {
            heroX = h.Location.X;
            heroY = h.Location.Y;

            const int xRange = Constants.ClientParams.WindowWidth / 2;
            const int yRange = Constants.ClientParams.WindowHeight / 2;

            const int xSendSize = xRange * 2 + 1;
            const int ySendSize = yRange * 2 + 1;

            var x = (int)Math.Floor(heroX - xRange);
            var y = (int)Math.Floor(heroY - yRange);

            if (tileMap.GetLength(0) < xSendSize ||tileMap.GetLength(1) < ySendSize)
                throw new ArgumentOutOfRangeException("Tile array should be larger than the given. ");

            WorldMap.GetMap(x, y, xSendSize, ySendSize, ref tileMap);
        }



        public void AddClient(IClient d)
        {
            throw new NotImplementedException();
        }
    }
}
