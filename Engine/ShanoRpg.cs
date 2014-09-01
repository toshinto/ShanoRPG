﻿using Engine.GameObjects;
using Engine.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Engine
{
    public class ShanoRpg
    {
        const int FPS = 60;


        public readonly Thread MainThread;

        Map WorldMap;

        List<Creature> Monsters;

        List<Hero> Heroes;

        /// <summary>
        /// Points to the hero that the local player plays with. 
        /// </summary>
        readonly Hero LocalHero;


        public ShanoRpg(Map map, Hero localHero)
        {
            this.WorldMap = map;

            this.Heroes.Add(localHero);

            this.LocalHero = localHero;


            this.MainThread = new Thread(updateLoop);
        }

        private void updateLoop()
        {
            while(true)
            {
                Thread.Sleep(1000 / FPS);

                this.Update();
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