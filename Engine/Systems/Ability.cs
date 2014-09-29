using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Objects;
using IO;

namespace Engine.Systems
{
    public abstract class Ability : IAbility
    {
        public Hero Hero { get; internal set; }

        public ShanoRpg Game { get; internal set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
        public int CurrentCooldown { get; set; }


        public readonly SpellType AbilityType;

        public virtual int Cooldown { get { return 1000; } }
        public virtual int ManaCost { get { return 5; } }
        public virtual int LifeCost { get { return 0; } }

        /// <summary>
        /// Creates an ability host for the given hero. 
        /// </summary>
        public Ability(SpellType abilityType)
        {
            this.AbilityType = abilityType;
            this.Icon = "default";
        }


        internal void Cast(object target) //wtf
        {
            switch (AbilityType)
            {
                case SpellType.NoTarget:
                    OnCast();
                    break;
                case SpellType.PointTarget:
                    OnCast(Vector.Zero);
                    break;
                case SpellType.UnitTarget:
                    OnCast((Unit)target);
                    break;
            }
        }

        //only one of the following three will get called by the engine. 
        //make sure to override the correct one, 
        //depending on your choice for an abilityType

        /// <summary>
        /// The function which gets called when a no-target ability is cast. 
        /// </summary>
        public virtual void OnCast()
        {

        }

        public virtual void OnCast(Vector target)
        {

        }

        public virtual void OnCast(Unit target)
        {

        }

        internal void Update(int msElapsed)
        {
            CurrentCooldown = Math.Max(0, CurrentCooldown - msElapsed);
        }
    }
}
