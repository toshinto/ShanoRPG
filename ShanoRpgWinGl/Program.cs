#region Using Statements
using Engine;
using Engine.Objects;
using Input;
using Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
#endregion

namespace ShanoRpgWinGl
{
    public static class ShanoRPGWinGl
    {
        public static void StartLocalGame(int mapSeed, IHero localHero)
        {
            var t = new Thread(() =>
            {
                //create the game client
                var g = new MainGame(localHero);

                //create the game engine
                var theGame = new ShanoRpg(mapSeed, new Player((Hero)localHero, (InputDevice)g.LocalInput));
                
                //link them
                g.GameDevice = theGame;

                //start
                g.Run();
            });
            t.Start();
        }
    }
}
