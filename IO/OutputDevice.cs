using Engine.GameObjects;
using Engine.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public interface OutputDevice
    {
        Entity GetEntities(Hero h);


        MapTile[,] GetNearbyTiles(Hero h);

    }
}
