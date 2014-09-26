using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Output
{
    public interface IAbility
    {
        string Name { get; }

        string Description { get; }

        string Icon { get; }


        int CurrentCooldown { get; }
        int Cooldown { get; }
        int ManaCost { get; }
        int LifeCost { get; }
    }
}
