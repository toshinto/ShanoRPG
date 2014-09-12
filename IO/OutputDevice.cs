using Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output
{
    public interface OutputDevice
    {
        /// <summary>
        /// Gets all entities in range of the given hero. 
        /// </summary>
        IEnumerable<IEntity> GetEntities(IHero h);


        MapTile[,] GetNearbyTiles(IHero h);

        void AddInputDevice(InputDevice d);

    }
}
