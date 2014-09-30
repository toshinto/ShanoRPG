using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Objects;

namespace Engine.Maps
{
    class GameMap
    {
        static readonly Vector MapCellSize = new Vector(5, 5);

        HashMap<Unit> units;

        HashMap<Doodad> doodads;

        public IEnumerable<Unit> Units
        {
            get { return units.Items; }
        }

        public IEnumerable<Doodad> Doodads
        {
            get { return doodads.Items; }
        }

        public GameMap()
        {
            units = new HashMap<Unit>((e => e.Location), MapCellSize, 100);
            doodads = new HashMap<Doodad>((e => e.Location), MapCellSize, 1000);
        }

        internal void AddUnit(Unit u)
        {
            units.Add(u);
            u.LocationChanged += Unit_LocationChanged;
        }

        private void Unit_LocationChanged(GameObject o)
        {
            units.UpdateItem(o as Unit);
        }

        public IEnumerable<Unit> GetUnitsInRect(Vector pos, Vector size)
        {
            return units.RangeQuery(pos, size);
        }

        public IEnumerable<Unit> GetUnitsInRange(Unit fromUnit, float range)
        {
            return GetUnitsInRange(fromUnit.Location, range);
        }

        public IEnumerable<Unit> GetUnitsInRange(Vector pos, float range)
        {
            //get a rectangle around the query region. 
            var windowPos = pos - range;
            var windowSize = new Vector(range) * 2;

            //pick the units in this rectangle. 
            var us = units.RangeQuery(windowPos, windowSize);

            //get exactly the units within the circle. 
            var rsq = range * range;
            return us
                .Where(e => e.Location.DistanceToSquared(pos) <= rsq);
        }

        /// <summary>
        /// Calls the update function for all objects on the GameMap: units, doodads, special effects. 
        /// </summary>
        /// <param name="msElapsed">The time elapsed since the last update, in milliseconds. </param>
        internal void Update(int msElapsed)
        {
            foreach (var e in Units.ToArray())
                e.Update(msElapsed);

            //foreach (var e in Doodads.ToArray())
            //    e.Update(msElapsed);
        }
    }
}
