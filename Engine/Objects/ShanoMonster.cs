using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Objects
{
    /// <summary>
    /// A simple type of unit. 
    /// </summary>
    [ProtoContract]
    public class ShanoMonster : Unit
    {
        public ShanoMonster(string name, int level)
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

        [ProtoMember(1)]
        private int _level { get; set; }
        public override int Level
        {
            get { return _level; }
        }

        protected override void UpdateMovement(int msElapsed)
        {
            //throw new NotImplementedException();
        }
     }    
} 
