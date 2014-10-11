using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Maps;
using Engine.Objects;
using IO;

namespace Engine.Systems
{
    public abstract class Ability : IAbility
    {
        public class CastEventArgs
        {
            /// <summary>
            /// Gets or sets whether the spell cast was successful. True by default. 
            /// </summary>
            public bool Success = true;

        }

        public Hero Hero { get; internal set; }

        public ShanoRpg Game { get; internal set; }
        public GameMap Map { get; internal set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
        public int CurrentCooldown { get; set; }


        public readonly SpellType AbilityType;

        public int Cooldown { get; set; }
        public virtual int ManaCost { get { return 5; } }

        /// <summary>
        /// Creates an ability host for the given hero. 
        /// </summary>
        public Ability(SpellType abilityType)
        {
            this.AbilityType = abilityType;
            this.Icon = "default";
        }


        internal CastEventArgs Cast(object target) //wtf
        {
            var e = new CastEventArgs();
            switch (AbilityType)
            {
                case SpellType.NoTarget:
                    OnCast(e);
                    break;
                case SpellType.PointTarget:
                    OnCast(e, Vector.Zero);
                    break;
                case SpellType.UnitTarget:
                    OnCast(e, (Unit)target);
                    break;
                default:
                    throw new Exception("Unrecognized ability type!");
            }
            return e;
        }

        //only one of the following three will get called by the engine. 
        //make sure to override the correct one, 
        //depending on your choice for an abilityType

        /// <summary>
        /// The function which gets called when a no-target ability is cast. 
        /// </summary>
        public virtual void OnCast(CastEventArgs e)
        {

        }

        public virtual void OnCast(CastEventArgs e, Vector target)
        {

        }

        public virtual void OnCast(CastEventArgs e, Unit target)
        {

        }

        internal void Update(int msElapsed)
        {
            CurrentCooldown = Math.Max(0, CurrentCooldown - msElapsed);

            OnUpdate(msElapsed);
        }

        public virtual void OnUpdate(int msElapsed)
        {

        }
    }
}
