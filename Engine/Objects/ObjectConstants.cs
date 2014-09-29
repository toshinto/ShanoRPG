using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Objects
{
     static class ObjectConstants
    {
      // are those used anywhere?
      public  const double DamagePerStrength = 1;
      public const double DefensePerStrength = 2;
      public const double LifePerVitality = 10;
      public const double ManaPerVitality = 8;
      public const double ManaRegPerInt = 0.1;
      public const double MagicDamagePerInt = 0.5;
      public const double AtkSpeedPerAgility = 1;        // percentage;
      public const double DodgePerAgility = 0.1;         // percentage;
    }
}
