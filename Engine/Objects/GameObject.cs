using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
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
    public abstract class GameObject : IGameObject
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

        [ProtoMember(6)]
        public string Model { get; set; }

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

        IVector IGameObject.Location
        {
            get
            {
                return this.Location;
            }

            set
            {
                this.Location = new Vector(value);
            }
        }

        public event Action<GameObject> LocationChanged;

        protected GameObject()
        {
            this.Size = 0.4;
            this.Model = "default";
            Guid = GetGuid();
        }

        public GameObject(string name)
            : this()
        {
            this.Name = name;
        }
    }
}
