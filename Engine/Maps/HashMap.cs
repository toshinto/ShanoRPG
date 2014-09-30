using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Objects;

namespace Engine.Maps
{
    /// <summary>
    /// Maps objects in 2D space by dividing it into equally-sized bins contained in a hash-table. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class HashMap<T>
    {
        const int AvgItemsPerBin = 10;

        List<T>[] hashTable;

        readonly Func<T, Vector> ExtractFunc;

        readonly Vector CellSize;

        readonly Dictionary<T, Vector> currentPos = new Dictionary<T, Vector>();

        public IEnumerable<T> Items
        {
            get { return hashTable.SelectMany(x => x); }
        }

        public int TableSize
        {
            get { return hashTable.Length; }
        }

        public HashMap(Func<T, Vector> extractFunc, Vector cellSize, int tableSize = 10)
        {
            this.ExtractFunc = extractFunc;
            this.CellSize = cellSize;

            resizeTable(tableSize);
        }

        private void resizeTable(int newSize)
        {
            // init the new table
            var newTable = new List<T>[newSize];

            for (int i = 0; i < newSize; i++)
                newTable[i] = new List<T>();

            // move all items from the previous table
            if (hashTable != null)  // (if any)
            {
                foreach (var it in Items)
                {
                    var pos = currentPos[it];
                    var id = getBinIdHash(pos, newSize);
                    newTable[id].Add(it);
                }
            }

            //set the new table. 
            this.hashTable = newTable;
        }

        /// <summary>
        /// Returns the bin Id of the given item, as determined by the bin size. 
        /// </summary>
        private Point getBinId(Vector pos)
        {
            return (pos / CellSize).ToPoint();
        }

        /// <summary>
        /// Gets the bin Id of the given cell in a table with a specified size (bins). 
        /// </summary>
        private int getBinHash(Point p, int tSize)
        {
            return ((p.X.GetHashCode() | p.Y.GetHashCode()) % tSize + tSize) % tSize;
        }

        /// <summary>
        /// Gets the bin hash of the given vector in the current table. 
        /// </summary>
        private int getBinIdHash(Vector pos)
        {
            return getBinIdHash(pos, TableSize);
        }

        /// <summary>
        /// Gets the bin hash of the given vector in a table with a specified size (bins). 
        /// </summary>
        private int getBinIdHash(Vector pos, int tSize)
        {
            var binId = getBinId(pos);
            var binHash = getBinHash(binId, tSize);
            return binHash;
        }

        public void Add(T item)
        {
            if (currentPos.ContainsKey(item))
                throw new ArgumentException("Cannot add an object which is already on the map. ");

            //add to the hashmap. 
            var iPos = ExtractFunc(item);
            var binId = getBinIdHash(iPos);
            hashTable[binId].Add(item);

            //add to the list
            currentPos.Add(item, iPos);


            //resize ?!

            if (currentPos.Count > AvgItemsPerBin * TableSize)
                resizeTable(TableSize * 2);
        }

        public void Remove(T item)
        {
            if (!currentPos.ContainsKey(item))
                throw new ArgumentException("Cannot remove an object which is not on the map. ");

            //remove from the hashmap using the item's current key to locate it. 
            var iPos = currentPos[item];
            var binId = getBinIdHash(iPos);
            hashTable[binId].Remove(item);

            //remove from the list
            currentPos.Remove(item);
        }


        public bool Contains(T item)
        {
            return currentPos.ContainsKey(item);
        }

        public void UpdateItem(T item)
        {
            if (!currentPos.ContainsKey(item))
                throw new ArgumentException("Cannot update an item which is not on the map. ");

            var oldPos = currentPos[item];
            var oldBin = getBinIdHash(oldPos);

            var newPos = ExtractFunc(item);
            var newBin = getBinIdHash(newPos);

            if (oldBin == newBin)
                return;

            hashTable[oldBin].Remove(item);
            hashTable[newBin].Add(item);

            currentPos[item] = newPos;
        }

        public IEnumerable<T> RangeQuery(Vector pos, Vector size)
        {
            var cellStart = getBinId(pos);
            var cellEnd = getBinId(pos + size);

            foreach (var p in cellStart.IterateToInclusive(cellEnd))
            {
                var binHash = getBinHash(p, TableSize);
                var binTable = hashTable[binHash];

                //check if it is a bin on the contour of the area. 
                if (p.X == cellStart.X || p.X == cellEnd.X || p.Y == cellStart.Y || p.Y == cellEnd.Y)
                {
                    // if so, we must check whether each item is inside the rect. 
                    foreach (var it in binTable)
                    {
                        var iPos = currentPos[it];
                        if (iPos.Inside(pos, size))
                            yield return it;
                    }
                }
                else
                    // otherwise yield all items from the bin. 
                    foreach (var it in binTable)
                        yield return it;
            }
        }
    }
}
