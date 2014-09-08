using Engine.Systems;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Objects
{
    [ProtoContract]
     public class Hero : Entity
    {
        private const int XpPerLevel = 100;

        private int _experience;

         /// <summary>
         /// The current experience of this hero.
         /// </summary>
        [ProtoMember(100)]
        public int Experience
         {
             get { return _experience; }
             set
             {
                 if (value < 0 || value < _experience)
                     throw new Exception("Invalid EXP");
                 _experience = value;
                 if (_experience > XpPerLevel * _level)
                 {
                     _experience -= XpPerLevel * _level;
                     _level++;
                 }
             }
         }
         private int _level;
         public override int Level
         {
             get { return _level; }
         }
         [ProtoMember(101)]
         public double BaseStrength;
         [ProtoMember(102)]
         public double BaseVitality;
         [ProtoMember(103)]
         public double BaseIntellect;
         [ProtoMember(104)]
         public double BaseAgility;
     
         public double CurrentStrength;
         public double CurrentVitality;
         public double CurrentIntellect;
         public double CurrentAgility;


         protected Hero() : base()
         {

         }

         public Hero(string name) : base(name)
         {

         }
         
         public override void UpdateBuffs(double secondsElapsed)
         {
             //Vika Entity.UpdateBuffs,koeto update-va life,mana,ala bala.
             base.UpdateBuffs(secondsElapsed);
             CurrentStrength = BaseStrength;
             CurrentAgility = BaseAgility;
             CurrentIntellect = BaseIntellect;
             CurrentVitality = BaseVitality;
             for (int i = 0; i < Buffs.Count; i++)
             {
              Buff b = Buffs[i];
              CurrentStrength += b.Strength;
              CurrentVitality += b.Vitality;
              CurrentIntellect += b.Intellect;
              CurrentAgility += b.Agility;

             }
         }
         
    }

}
