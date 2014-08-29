using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.GameObjects
{
    public class Creature : Entity
    {
        public Creature(string name,int level)
            : base(name)
        {
            this._level = level;
            BaseLife = 90 + 10 * level;
            BaseMinDamage = 10 + 2 * level;
            BaseMaxDamage = BaseMinDamage + 5;
            BaseDefense = 2 + 0.2 * level;
            BaseMoveSpeed = 5;
            BaseDodge = 10;
        }
        private readonly  int _level;
        public override int Level
        {
            get { return _level; }
        }
        public override double MaxLife
        {
            get { return BaseLife; }
        }

        public override double MaxMana
        {
            get { return BaseMana; }
        }

        public override double CurrentDefense
        {
            get { return BaseDefense; }
        }
        public override double CurrentDodge
        {
            get { return BaseDodge; }
        }
     }    
} 
