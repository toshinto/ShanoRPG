using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.GameObjects
{
    public abstract class Entity
    {
        public abstract int Level { get; }
        public abstract double CurrentDefense { get; }
        public abstract double CurrentDodge { get; }
        public readonly  string Name;
        public abstract double MaxLife { get; }
        public abstract double MaxMana { get; }
        public double CurrentMoveSpeed { get { return BaseMoveSpeed; } }
        public abstract double CurrentDamage { get; }
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
    }
     
}
