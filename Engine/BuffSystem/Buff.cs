using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.BuffSystem
{
    public class Buff
    {
        public readonly int MoveSpeedPerc,
            AttackSpeedPerc;


        public readonly double Life,
            Mana,
            Defense,
            MinDamage,
            MaxDamage,
            Strength,
            Vitality,
            Agility,
            Intellect;

        /// <summary>
        /// The total duration of the buff, in seconds. 
        /// </summary>
        public double Duration;

        public double DurationLeft;

        public Buff(double duration, int moveSpeed = 0, int atkSpeed = 0, double life = 0, double mana = 0, 
            double defense = 0, double minDmg = 0, double maxDmg = 0)
        {
            this.Duration = duration;
            this.DurationLeft = duration;

            this.MoveSpeedPerc = moveSpeed;
            this.AttackSpeedPerc = atkSpeed;
            this.Life = life;
            this.Mana = mana;
            this.Defense = defense;
            this.MinDamage = minDmg;
            this.MaxDamage = maxDmg;
        }

    }
}
