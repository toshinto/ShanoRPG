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


        public double CurrentDefense { get; protected set; }
        public double CurrentDodge { get; protected set; }
        public double MaxLife { get; protected set; }
        public double MaxMana { get; protected set; }
        public double CurrentDamage { get; protected set; }
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
            BaseDamage;

        public Entity(string name)
        {
            this.Name = name;
        }
        public virtual void UpdateBuffs()
        {
            
        }
    }
     
}
