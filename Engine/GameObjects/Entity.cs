using Engine.BuffSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.GameObjects
{
    public abstract class Entity
    {
        public readonly string Name;
        public abstract int Level { get; }

        public double CurrentAttackCooldown
        {
            get { return 1 / CurrentAttacksPerSecond;  }
        }
        

        public double CurrentAttacksPerSecond { get; protected set; }
        public double CurrentMinDamage { get; protected set; }
        public double CurrentDefense { get; protected set; }
        public double CurrentDodge { get; protected set; }
        public double MaxLife { get; protected set; }
        public double MaxMana { get; protected set; }
        public double CurrentMaxDamage { get; protected set; }
        public double CurrentMoveSpeed { get; protected set; }



        public List<Buff> Buffs = new List<Buff>();

        
        public double
            CurrentLife,
            CurrentMana;
        public double BaseLife,
            BaseMana,
            BaseDefense,
            BaseDodge,
            BaseMoveSpeed,
            BaseMinDamage,
            BaseMaxDamage,
            BaseAttacksPerSecond;

        public Entity(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Updates the entity's buffs
        /// </summary>
        /// <param name="secondsElapsed">the time Elapsed since the last update,in seconds</param>
        public virtual void UpdateBuffs(double secondsElapsed)
        {
            //Here we reset the stats
            CurrentDefense = BaseDefense;
            CurrentDodge = BaseDodge;
            MaxLife = BaseLife;
            MaxMana = BaseMana;
            CurrentMinDamage = BaseMinDamage;
            CurrentMaxDamage = BaseMaxDamage; 
            CurrentMoveSpeed = BaseMoveSpeed;
            CurrentAttacksPerSecond = BaseAttacksPerSecond;
            // Here we update the active buffs
           for(int i = 0;i<Buffs.Count;i++)
           {
               Buff b = Buffs[i];
               CurrentDefense += b.Defense;
               MaxLife += b.Life;
               MaxMana += b.Mana;
               CurrentMinDamage += b.MinDamage;
               CurrentMaxDamage += b.MaxDamage;
               CurrentMoveSpeed += BaseMoveSpeed * b.MoveSpeedPerc / 100;
               CurrentAttacksPerSecond += BaseAttacksPerSecond * b.AttackSpeedPerc / 100;
           }

        }
    }
     
}
