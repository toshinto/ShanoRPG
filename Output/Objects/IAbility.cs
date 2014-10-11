using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IO
{
    public interface IAbility
    {
        string Name { get; }

        string Description { get; }

        string Icon { get; }


        int CurrentCooldown { get; }
        int Cooldown { get; }
        int ManaCost { get; }
    }
}
