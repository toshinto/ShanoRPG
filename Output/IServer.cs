using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    /// <summary>
    /// An interface to a (local or remote) game server. 
    /// Supports updating movement state, as well as registering special actions. (abilities)
    /// </summary>
    public interface IServer
    {
        /// <summary>
        /// Gets our hero. 
        /// </summary>
        IHero LocalHero { get; }

        /// <summary>
        /// Sets the direction our hero is heading in. 
        /// </summary>
        MovementState MovementState { get; set; }

        /// <summary>
        /// Registers a special action: a command followed by a variable number of parameters. 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="param"></param>
        void RegisterAction(Command action, byte[] p);


        void GetNearbyTiles(ref MapTile[,] tiles, out double x, out double y);

        /// <summary>
        /// Gets all entities in range of our hero. 
        /// </summary>
        IEnumerable<IUnit> GetUnits();
    }
}
 