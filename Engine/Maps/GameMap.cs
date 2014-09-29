using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Objects;

namespace Engine.Maps
{
    class GameMap
    {
        static readonly Vector MapCellSize = new Vector(5, 5);

        HashMap<Unit> Units;

        HashMap<Doodad> Doodads;

        public GameMap()
        {
            Units = new HashMap<Unit>((e => e.Location), MapCellSize);
            Doodads = new HashMap<Doodad>((e => e.Location), MapCellSize);
        }
    }
}
