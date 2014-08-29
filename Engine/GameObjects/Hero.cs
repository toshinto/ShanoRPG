using Engine.BuffSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.GameObjects
{
     public class Hero : Entity
    {
        private const int XpPerLevel = 100;

        private int _experience;

         /// <summary>
         /// The current experience of this hero.
         /// </summary>
         public int Experience
         {
             get { return _experience; }
             set
             {
                 if (value < 0 || value < _experience)
                     throw new Exception("Invalid EXP");
                 _experience = value;
                 if (_experience > XpPerLevel * Level)
                 {
                     _experience = 0;
                     _level++;
                 }
             }
         }
         private int _level;
         public override int Level
         {
             get { return _level; }
         }
         public double BaseStrength,
                BaseVitality,
                BaseIntellect,
                BaseAgility;
     
         public double CurrentStrength;
         public double CurrentVitality;
         public double CurrentIntellect;
         public double CurrentAgility;



         public Hero(string name)
             : base(name)
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
