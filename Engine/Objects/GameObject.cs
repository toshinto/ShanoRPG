using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Objects
{
    /// <summary>
    /// A base class for all entities on the map. 
    /// Currently this includes doodads, units, special effects. 
    /// </summary>
    public abstract class GameObject
    {
        private static int guidCount = 0;
        private static int GetGuid()
        {
            return ++guidCount;
        }

        public readonly string Name = "Pesho";

        public int Guid { get; private set; }

        public Vector Location { get; set; }

        /// <summary>
        /// Gets or sets the size of this entity. 
        /// </summary>
        public double Size { get; set; }

        protected GameObject() { }

        public GameObject(string name)
        {
            this.Name = name;
            this.Size = 0.4;
            Guid = GetGuid();
        }
    }
}
