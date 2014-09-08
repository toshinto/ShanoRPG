using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Objects
{
    [ProtoContract]
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

        [ProtoMember(200)]
        private int _level { get; set; }
        public override int Level
        {
            get { return _level; }
        }
     }    
} 
