using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IO
{
    public interface IHero : IUnit
    {
        double CurrentStrength { get; }
        double CurrentAgility { get; }
        double CurrentVitality { get; }
        double CurrentIntellect { get; }

        IEnumerable<IAbility> Abilities { get; }
    }
}
