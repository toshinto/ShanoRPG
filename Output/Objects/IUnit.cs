using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IO
{
    public interface IUnit : IGameObject
    {
        bool IsDead { get; }

        double CurrentLife { get; }
        double CurrentMaxLife { get; }

        double CurrentMana { get; }
        double CurrentMaxMana { get; }

        double CurrentMoveSpeed { get; }
        double CurrentDefense { get; }
        double CurrentMinDamage { get; }
        double CurrentMaxDamage { get; }
    }
}
