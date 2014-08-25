using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.GameObjects
{
    public abstract class Entity
    {
        public readonly  string Name;
        public abstract double MaxLife { get; }
        public abstract double MaxMana { get; }
        public double
            CurrentLife,
            CurrentMana;
        public double BaseLife,
            BaseMana;
    }
     
}
