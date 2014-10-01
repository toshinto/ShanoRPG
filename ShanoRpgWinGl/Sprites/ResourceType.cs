using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanoRpgWinGl.Sprites
{
    enum ResourceType
    {
        Icon = 0,
        Model = 1,
        Ui = 2,
        Terrain = 3,
    }

    static class ResourceTypeExt
    {
        public static readonly string[] dirs = new[]
        {
            @"Icons",
            @"Units",
            @"Ui",
            @"Terrain",
        };

        public static string GetDirectory(this ResourceType t)
        {
            return dirs[(int)t];
        }
    }
}
