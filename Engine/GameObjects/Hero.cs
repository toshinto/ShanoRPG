using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.GameObjects
{
     public class Hero : Entity
    {
         private int _experience;

         /// <summary>
         /// The current experience of this hero......
         /// </summary>
         public int Experience
         {
             get { return _experience; }
             set
             {
                 if (value < 0 || value < _experience)
                     throw new Exception("Invalid EXP");
                 _experience = value;
                 if (_experience > 100 * Level)
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
         public double CurrentStrength
         {
             get
             {
                 return BaseStrength;
             }
         }

         public double CurrentVitality
         {
             get
             {
                 return BaseVitality;
             }
         }

         public double CurrentIntellect
         {
             get
             {
                 return BaseIntellect;
             }
         }

         public double CurrentAgility
         {
             get
             {
                 return BaseAgility;
             }
         }

         public override double MaxLife 
         {
             get { return BaseLife + CurrentVitality * ObjectConstants.LifePerVitality  ; }
         }

         public override double MaxMana
         {
             get { return BaseMana + CurrentMana * ObjectConstants.ManaPerVitality   ; }
         }
         public override double CurrentDefense
         {
             get { return BaseDefense + CurrentStrength * ObjectConstants.DefensePerStrength   ; }
         }
         public override double CurrentDodge
         {
             get { return BaseDodge + CurrentAgility * ObjectConstants.DodgePerAgility ; }
         }
    }

}
