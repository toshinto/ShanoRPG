using Engine.Objects;
using Engine.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Input;

namespace Engine
{
    public class ShanoRpg
    {
        /// <summary>
        /// The frames per second we aim to run at. 
        /// </summary>
        const int FPS = 60;

        public InputDevice LocalInput;

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
        List<Hero> Heroes;

        /// <summary>
        /// Gets all entities currently in the game. 
        /// </summary>
        public IEnumerable<Entity> Entities
        {
            get
            {
                foreach (var m in Monsters)
                    yield return m;
                foreach (var h in Heroes)
                    yield return h;
            }
        }

        /// <summary>
        /// The hero that the local player uses. 
        /// </summary>
        readonly Hero LocalHero;


        public ShanoRpg(Map map, Hero localHero)
        {
            this.WorldMap = map;

            this.Heroes.Add(localHero);

            this.LocalHero = localHero;

            //start the update thread
            this.MainThread = new Thread(updateLoop);
        }

        /// <summary>
        /// Performs the basic game loop. 
        /// </summary>
        private void updateLoop()
        {
            int frameStartTime, drawTime = 0;
            while(true)
            {
                Thread.Sleep(1000 / FPS - drawTime);
                
                frameStartTime = Environment.TickCount;
                this.Update();
                drawTime = Environment.TickCount - frameStartTime;
            }
        }

        private void Update()
        {

            foreach (Hero h in Heroes)
                h.UpdateBuffs(1000 / FPS);
            foreach (Creature c in Monsters)
                c.UpdateBuffs(1000 / FPS);
        }


    }
}
