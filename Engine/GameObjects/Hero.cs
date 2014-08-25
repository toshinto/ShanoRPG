using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.GameObjects
{
     public class Hero : Entity
    {
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
             get { return BaseLife; }
         }

         public override double MaxMana
         {
             get { return BaseMana; }
         }
    }

}
