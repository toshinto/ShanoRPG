﻿using Engine.GameObjects;
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


        Tile[,] GetNearbyTiles(Hero h);

    }
}
