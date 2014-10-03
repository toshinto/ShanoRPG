using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Objects
{
    /// <summary>
    /// Represents an item which is on the ground. 
    /// 
    /// 
    /// </summary>
    public class GameItem
    {
        /// <summary>
        /// Gets or sets the Item instance this GameItem actually is. 
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Gets or sets the location of this object. 
        /// </summary>
        public Vector Location { get; set; }

        /// <summary>
        /// Creates a new GameItem object containing the given item, on the point specified. 
        /// </summary>
        public GameItem(Item item, Vector location)
        {
            this.Item = item;
            this.Location = location;
        }
    }
}
