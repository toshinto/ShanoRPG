using Engine.Systems;
using Input;
using Output;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Engine.Objects
{
    [ProtoContract]
    public class Hero : Entity, IHero
    {
        private const int XpPerLevel = 100;

        private int _experience;

        /// <summary>
        /// The current experience of this hero.
        /// </summary>
        [ProtoMember(1)]
        public int Experience
        {
            get { return _experience; }
            set
            {
                if (value < 0 || value < _experience)
                    throw new Exception("You must supply an experience value higher than the previous one!");
                _experience = value;
                while (_experience > ExperienceNeeded)
                {
                    _experience -= ExperienceNeeded;
                    _level++;
                }
            }
        }

        public int ExperienceNeeded
        {
            get
            {
                return XpPerLevel * _level;
            }
        }

        private int _level;
        public override int Level
        {
            get { return _level; }
        }
        [ProtoMember(2)]
        public double BaseStrength;
        [ProtoMember(3)]
        public double BaseVitality;
        [ProtoMember(4)]
        public double BaseIntellect;
        [ProtoMember(5)]
        public double BaseAgility;

        public double CurrentStrength;
        public double CurrentVitality;
        public double CurrentIntellect;
        public double CurrentAgility;


        public volatile MovementState MovementState;

        public Hero()
            : base()
        {
            
        }

        public Hero(string name)
            : base(name)
        {
            this.BaseMoveSpeed = 3;
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

        public override void UpdateMovement(int msElapsed)
        {
            var dx = MovementState.XDirection;
            var dy = MovementState.YDirection;

            var dist = this.CurrentMoveSpeed * msElapsed / 1000;

            if (dx != 0 || dy != 0)
            {
                if (dx * dy != 0)
                    dist = dist / Math.Sqrt(2);
                this.X += dx * dist;
                this.Y += dy * dist;
            }
        }

        public void Save(string fileName)
        {
            using(var fs = File.Create(fileName))
            {

                Serializer.Serialize(fs, this);
            }
        }

        public static Hero Load(string fileName)
        {
            using (var fs = File.OpenRead(fileName))
            {
                var h = Serializer.Deserialize<Hero>(fs);
                return h;
            }
        }

    }

}
