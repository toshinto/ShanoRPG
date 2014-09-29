using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Objects
{
    /// <summary>
    /// Represents an in-game special effect. 
    /// </summary>
    public class SpecialEffect : GameObject
    {
        /// <summary>
        /// Gets the texture file name for this effect. 
        /// </summary>
        public string FileName;

        /// <summary>
        /// Gets or sets the speed at which this effect plays. 
        /// </summary>
        public double Speed;

        /// <summary>
        /// Gets or sets whether this effect is attached to a particular GameObject. 
        /// </summary>
        public bool IsAttached { get; set; }

        public GameObject AttachedTo { get; set; }

        /// <summary>
        /// Gets or sets the position of the effect on the map, as long as it is not attached to a GameObject. 
        /// </summary>
        public Vector Position { get; set; }

        public Vector Offset { get; set; }

        public SpecialEffect(GameObject anchor)
        {
            this.AttachedTo = anchor;
            this.IsAttached = true;
        }

        public SpecialEffect(Vector loc)
        {
            this.Position = loc;
        }

        
    }
}
