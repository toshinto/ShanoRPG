using Engine.Systems;
using IO;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Engine.Common;

namespace Engine.Objects
{
    /// <summary>
    /// Represents an in-game unit. This includes NPCs, heroes and buildings. 
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(Hero))]
    [ProtoInclude(2, typeof(ShanoMonster))]
    public abstract class Unit : GameObject, IUnit
    {
        //[ProtoMember(3)]
        public abstract int Level { get; }

        /// <summary>
        /// Gets the time it takes for an unit to attack, as determined by <see cref="CurrentAttacksPerSecond"/> 
        /// </summary>
        /// <returns>The time for an attack, in milliseconds. </returns>
        public int CurrentAttackCooldown
        {
            get { return (int)(1000 / CurrentAttacksPerSecond);  }
        }

        // The following stats have different base values for each unit
        // and are thus preceded by Current_

        private double currentMaxLife,
            currentMaxMana;
        public double CurrentMaxLife
        {
            get
            {
                return currentMaxLife;
            }

            protected set
            {
                if (value != currentMaxLife)
                {
                    if(currentMaxLife != 0 && !IsDead)
                        CurrentLife = CurrentLife * value / currentMaxLife;
                    currentMaxLife = value;
                }
            }
        }
        public double CurrentMaxMana
        {
            get
            {
                return currentMaxMana;
            }

            protected set
            {
                if (value != currentMaxMana)
                {
                    if (currentMaxMana != 0 && !IsDead)
                        CurrentLife = CurrentLife * value / currentMaxMana;
                    currentMaxMana = value;
                }
            }
        }
        public double CurrentAttacksPerSecond { get; protected set; }
        public double CurrentMinDamage { get; protected set; }
        public double CurrentDefense { get; protected set; }
        public double CurrentDodge { get; protected set; }
        public double CurrentMaxDamage { get; protected set; }
        public double CurrentMoveSpeed { get; protected set; }

        //NYI
        public event Action Dying;
        public event Action<DamageType, double> Damaged;
        public event Action<DamageType, double> Damaging;


        //the following stats have no base values (or constant ones)

        public double LifeRegen { get; protected set; }

        public double ManaRegen { get; protected set; }

        public double MagicDamage { get; protected set; }



        protected List<Buff> Buffs = new List<Buff>();


        [ProtoMember(4)]
        public double CurrentLife { get; set; }

        [ProtoMember(5)]
        public double CurrentMana { get; set; }

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

        [ProtoMember(6)]
        public double BaseLife;

        [ProtoMember(7)]
        public double BaseMana;

        [ProtoMember(8)]
        public double BaseDodge;

        [ProtoMember(9)]
        public double BaseDefense; 

        [ProtoMember(10)]
        public double BaseMoveSpeed;

        [ProtoMember(11)]
        public double BaseMinDamage;

        [ProtoMember(12)]
        public double BaseMaxDamage;

        [ProtoMember(13)]
        public double BaseAttacksPerSecond;

        public bool IsDead { get; private set; }

        public bool Invulnerable { get; set; }

        //[ProtoMember(14)]
        private List<string> abilityNames = new List<string>();

        protected Unit() { }

        public Unit(string name) : base(name)
        {
            this.Size = 0.4;
            this.BaseAttacksPerSecond = 0.6;
            this.BaseMinDamage = 0;
            this.BaseMaxDamage = 2;
            this.BaseMoveSpeed = 5;
            this.BaseDefense = 0;
            this.BaseDodge = 5;

            this.BaseLife = 5;
            this.CurrentMaxLife = 5;

        }

        /// <summary>
        /// Handles unit statistics changes. 
        /// </summary>
        /// <param name="secondsElapsed">the time elapsed since the last update, in seconds</param>
        protected virtual void UpdateBuffs(double msElapsed)
        {
            //Update durations, remove stale buffs
            foreach (var b in Buffs)
                b.DurationLeft -= msElapsed;
            Buffs.RemoveAll((b) => b.DurationLeft <= 0);

            //current stat is simply the base value plus the sum of all effects on it from buffs. 
            CurrentDefense = BaseDefense + Buffs.Sum(b => b.Defense);
            CurrentDodge = BaseDodge;
            CurrentMaxLife = BaseLife + Buffs.Sum(b => b.Life);
            CurrentMaxMana = BaseMana + Buffs.Sum(b => b.Mana);
            CurrentMinDamage = BaseMinDamage + Buffs.Sum(b => b.MinDamage);
            CurrentMaxDamage = BaseMaxDamage + Buffs.Sum(b => b.MaxDamage);
            CurrentMoveSpeed = BaseMoveSpeed * (100 + Buffs.Sum(b => b.MoveSpeedPerc)) / 100;
            CurrentAttacksPerSecond = BaseAttacksPerSecond * (100 + Buffs.Sum(b => b.AttackSpeedPerc)) / 100;

            //reset the (currently) constant stats:
            //these can be tied at any moment
            //and are also modified by heroes' stats.  
            LifeRegen = ObjectConstants.BaseLifeRegen;
            ManaRegen = ObjectConstants.BaseManaRegen;
            MagicDamage = ObjectConstants.BaseMagicDamage;
        }

        protected abstract void UpdateMovement(int msElapsed);

        /// <summary>
        /// Updates movement and buffs. 
        /// </summary>
        /// <param name="msElapsed"></param>
        public virtual void Update(int msElapsed)
        {
            this.UpdateBuffs(msElapsed);
            this.UpdateMovement(msElapsed);

            this.CurrentMana += msElapsed * this.ManaRegen / 1000;
            this.CurrentLife += msElapsed * this.LifeRegen / 1000;

            this.CurrentLife = Math.Min(this.CurrentMaxLife, this.CurrentLife);
            this.CurrentMana = Math.Min(this.CurrentMaxMana, this.CurrentMana);
        }

        public bool DamageUnit(Unit u, DamageType damageType, double amount)
        {
            if (this.IsDead)
                throw new Exception("Dead guy casting!");

            if (u.IsDead || u.Invulnerable)
                return false;

            //if its physical damage we can dodge it. 
            if (damageType == DamageType.Physical)
            {
                var dodgeRoll = Rnd.Next(0, 100);

                if (dodgeRoll < u.CurrentDodge)     //dodge!
                    return false;
            }

            //todo: if it is magical damage, increase it. 
            //base on cooldown and manacost?

            var dmgModifier = u.getResistance(damageType);     //currently allows healing if resistance > 1
            var dmgDealt = amount * dmgModifier;

            u.CurrentLife -= dmgDealt;

            //check if other guy dies
            if (u.CurrentLife <= 0)
            {
                u.CurrentLife = 0;
                u.IsDead = true;

                //award experience? drop items? fire event?
            }

            return true;
        }

        private double getResistance(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    return 1 / (ObjectConstants.DamageReductionPerDefense * CurrentDefense + 1);
                case DamageType.Fire:
                    return 0;
                case DamageType.Ice:
                    return 0;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
