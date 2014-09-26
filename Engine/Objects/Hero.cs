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
        private int _level;

        /// <summary>
        /// The experience needed to reach the next level. 
        /// </summary>
        /// <returns></returns>
        public int ExperienceNeeded
        {
            get
            {
                return XpPerLevel * _level;
            }
        }

        public override int Level
        {
            get { return _level; }
        }

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

        [ProtoMember(2)]
        public double BaseStrength;
        [ProtoMember(3)]
        public double BaseVitality;
        [ProtoMember(4)]
        public double BaseIntellect;
        [ProtoMember(5)]
        public double BaseAgility;

        private Dictionary<string, Ability> abilities = new Dictionary<string, Ability>();

        public double CurrentStrength { get; protected set; }
        public double CurrentVitality { get; protected set; }
        public double CurrentIntellect { get; protected set; }
        public double CurrentAgility { get; protected set; }

        public IEnumerable<IAbility> Abilities
        {
            get { return abilities.Values; }
        }

        public volatile MovementState MovementState;

        public Hero()
            : base()
        {
            
        }

        

        public void AddAbility(Ability a)
        {
            abilities.Add(a.Name, a);
        }

        public Hero(string name)
            : base(name)
        {
            this.BaseMoveSpeed = 5;
            CurrentLife = BaseLife = 100;
        }

        protected override void UpdateBuffs(double secondsElapsed)
        {
            //Vika Entity.UpdateBuffs,koeto update-va life,mana,ala bala.
            base.UpdateBuffs(secondsElapsed);

            CurrentStrength = BaseStrength + Buffs.Sum(b => b.Strength);
            CurrentVitality = BaseVitality + Buffs.Sum(b => b.Vitality);
            CurrentIntellect = BaseIntellect + Buffs.Sum(b => b.Intellect);
            CurrentAgility = BaseAgility + Buffs.Sum(b => b.Agility);
        }

        /// <summary>
        /// Uses this.MovementState to update the position of the hero. 
        /// </summary>
        /// <param name="msElapsed"></param>
        protected override void UpdateMovement(int msElapsed)
        {
            var dx = MovementState.XDirection;
            var dy = MovementState.YDirection;

            var dist = this.CurrentMoveSpeed * msElapsed / 1000;

            if (dx != 0 || dy != 0)
            {
                if (dx * dy != 0)
                    dist = dist / Math.Sqrt(2);
                this.Location += new Vector(dx, dy) * dist;
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

        public virtual void OnSpecialAction(string actionId)
        {
            Ability actionAbility;
            abilities.TryGetValue(actionId, out actionAbility);

            if (actionAbility.CurrentCooldown > 0)
                return;

            actionAbility.CurrentCooldown = actionAbility.Cooldown;
            actionAbility.Cast(null);
        }

        public override void Update(int msElapsed)
        {
            base.Update(msElapsed);

            foreach (var a in abilities.Values)
                a.Update(msElapsed);
        }
    }

}
