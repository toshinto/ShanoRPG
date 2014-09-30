using Engine.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShanoRpgWin
{
    static class LocalHeroes
    {
        const string HeroDir = "Heroes";

        readonly static List<Hero> heroes = new List<Hero>();

        public static IEnumerable<Hero> Heroes
        {
            get { return heroes; }
        }

        static LocalHeroes()
        {
            if (!Directory.Exists(HeroDir))
                Directory.CreateDirectory(HeroDir);
        }

        public static void LoadHeroes()
        {
            heroes.Clear();
            foreach(var fn in Directory.EnumerateFiles(HeroDir, "*.hero"))
            {
                try
                {
                    var h = Hero.Load(fn);
                    heroes.Add(h);
                }
                catch
                {
                    //Console.WriteLine("Error reading hero {1}", Path.GetFileNameWithoutExtension(fn));
                }
            }
        }

        public static void Save(this Hero h)
        {
            h.Save(Path.Combine(HeroDir, h.Name + ".hero"));
            if(!heroes.Contains(h))
            {
                Console.WriteLine("Warning: Saving a newly created hero!");
                heroes.Add(h);
            }
        }

    }
}
