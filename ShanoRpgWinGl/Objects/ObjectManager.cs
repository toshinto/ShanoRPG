using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Microsoft.Xna.Framework.Graphics;

namespace ShanoRpgWinGl.Objects
{
    class ObjectManager
    {
        public IHero LocalHero { get; private set; }

        public int LocalGuid
        {
            get { return LocalHero.Guid; }
        }

        public GameUnit LocalGameHero
        {
            get { return Units[LocalGuid]; }
        }

        Dictionary<int, GameUnit> Units = new Dictionary<int, GameUnit>();

        public ObjectManager(IHero localHero)
        {
            this.LocalHero = localHero;
            addUnit(LocalHero);
        }

        public void Update(int msElapsed, IEnumerable<IUnit> newUnits)
        {
            var toRemove = new HashSet<int>(Units.Values.Select(gu => gu.Unit.Guid)); // mark all units for removal initially

            //add new units, or mark them as not-to-remove
            foreach(var u in newUnits)
            {
                if (this.Units.ContainsKey(u.Guid))
                    toRemove.Remove(u.Guid);            // don't remove if its in the new list
                else
                    addUnit(u);                         // an (actually) new guy 
            }

            foreach (var guid in toRemove)  //remove old units
                if (guid != LocalGuid)
                    Units.Remove(guid);

            // update everyone who is still around
            foreach (var u in Units.Values)
            {
                u.Update(msElapsed);
            }
        }

        private void addUnit(IUnit u)
        {
            var gu = new GameUnit(u);
            Units.Add(u.Guid, gu);
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var u in Units.Values)
                u.Draw(sb);
        }
    }
}
