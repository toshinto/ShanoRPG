using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.GameObjects
{
    public class Creature : Entity
    {
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
