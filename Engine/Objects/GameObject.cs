using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Engine.Objects
{
    /// <summary>
    /// A base class for all entities on the map. 
    /// Currently this includes doodads, units, special effects. 
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(Unit))]
    [ProtoInclude(2, typeof(Doodad))]
    [ProtoInclude(3, typeof(SpecialEffect))]
    public abstract class GameObject
    {
        private static int guidCount = 0;
        private static int GetGuid()
        {
            return ++guidCount;
        }

        /// <summary>
        /// Gets the name of the unit. 
        /// </summary>
        [ProtoMember(4)]
        public readonly string Name = "Pesho";

        /// <summary>
        /// Gets or sets the size of this entity. 
        /// </summary>
        [ProtoMember(5)]
        public double Size { get; set; }

        /// <summary>
        /// Gets the globally unique identifier of the object. 
        /// </summary>
        public int Guid { get; private set; }

        private Vector location;
        /// <summary>
        /// Gets or sets the location of the game object. 
        /// </summary>
        public Vector Location
        {
            get { return location; }
            set
            {
                if (location != value)
                {
                    if (LocationChanged != null)
                        LocationChanged(this);

                    location = value;
                }
            }
        }

        public event Action<GameObject> LocationChanged;

        protected GameObject() { }

        public GameObject(string name)
        {
            this.Name = name;
            this.Size = 0.4;
            Guid = GetGuid();
        }
    }
}
