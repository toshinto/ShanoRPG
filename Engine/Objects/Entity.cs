using Engine.Systems;
using Input;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Output;

namespace Engine.Objects
{
    [ProtoContract]
    [ProtoInclude(1, typeof(Hero))]
    [ProtoInclude(2, typeof(Creature))]
    public abstract class Entity : IEntity
    {
        [ProtoMember(3)]
        public readonly string Name = "Pesho";
        public abstract int Level { get; }

        public double CurrentAttackCooldown
        {
            get { return 1 / CurrentAttacksPerSecond;  }
        }
        

        public double CurrentAttacksPerSecond { get; protected set; }
        public double CurrentMinDamage { get; protected set; }
        public double CurrentDefense { get; protected set; }
        public double CurrentDodge { get; protected set; }
        public double CurrentMaxLife { get; protected set; }
        public double CurrentMaxMana { get; protected set; }
        public double CurrentMaxDamage { get; protected set; }
        public double CurrentMoveSpeed { get; protected set; }

        public Vector Location { get; set; }

        public List<Buff> Buffs = new List<Buff>();


        [ProtoMember(4)]
        public double CurrentLife { get; set; }

        public string Icon { get; set; }

        [ProtoMember(5)]
        public double CurrentMana { get; set; }

        IVector IEntity.Location
        {
            get
            {
                return Location;
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

        //[ProtoMember(14)]
        private List<string> abilityNames = new List<string>();

        protected Entity()
        {

        }
        
        public Entity(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Updates the entity's buffs
        /// </summary>
        /// <param name="secondsElapsed">the time elapsed since the last update, in seconds</param>
        protected virtual void UpdateBuffs(double msElapsed)
        {
            //Update durations, remove stale buffs
            foreach (var b in Buffs)
                b.DurationLeft -= msElapsed;
            Buffs.RemoveAll((b) => b.DurationLeft <= 0);


            CurrentDefense = BaseDefense + Buffs.Sum(b => b.Defense);
            CurrentDodge = BaseDodge;
            CurrentMaxLife = BaseLife + Buffs.Sum(b => b.Life);
            CurrentMaxMana = BaseMana + Buffs.Sum(b => b.Mana);
            CurrentMinDamage = BaseMinDamage + Buffs.Sum(b => b.MinDamage);
            CurrentMaxDamage = BaseMaxDamage + Buffs.Sum(b => b.MaxDamage);
            CurrentMoveSpeed = BaseMoveSpeed * (100 + Buffs.Sum(b => b.MoveSpeedPerc)) / 100;
            CurrentAttacksPerSecond = BaseAttacksPerSecond * (100 + Buffs.Sum(b => b.AttackSpeedPerc)) / 100;

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
        }
    }
     
}
