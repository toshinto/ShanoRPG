using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Objects;

namespace Engine.Maps
{

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
                    var id = getBinId(pos, newSize);
                    newTable[id].Add(it);
                }
            }

            //set the new table. 
            this.hashTable = newTable;
        }

        /// <summary>
        /// Returns the Cell id of the given item, as determined by the bin size. 
        /// </summary>
        private void getCellId(Vector pos, out int x, out int y)
        {
            var binId = pos / CellSize;

            x = (int)binId.X;
            y = (int)binId.Y;
        }

        /// <summary>
        /// Gets the bin Id of the cell with given co-ordinates in a table with a specified size (bins). 
        /// </summary>
        private int getBinId(int x, int y, int tSize)
        {
            return (x.GetHashCode() | y.GetHashCode()) % tSize;
        }

        /// <summary>
        /// Gets the bin id of the given vector in the current table. 
        /// </summary>
        private int getBinId(Vector pos)
        {
            return getBinId(pos, TableSize);
        }

        /// <summary>
        /// Gets the bin id of the given vector in a table with a specified size (bins). 
        /// </summary>
        private int getBinId(Vector pos, int tSize)
        {
            int binX, binY;
            getCellId(pos, out binX, out binY);

            return getBinId(binX, binY, tSize);
        }

        public void Add(T item)
        {
            if (currentPos.ContainsKey(item))
                throw new ArgumentException("Cannot add an object which is already on the map. ");

            //add to the hashmap
            var iPos = ExtractFunc(item);
            var binId = getBinId(iPos);
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

            //remove from the hashmap
            var iPos = currentPos[item];
            var binId = getBinId(iPos);
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
            var oldBin = getBinId(oldPos);

            var newPos = ExtractFunc(item);
            var newBin = getBinId(newPos);

            if (oldBin == newBin)
                return;

            hashTable[oldBin].Remove(item);
            hashTable[newBin].Add(item);

            currentPos[item] = newPos;
        }

        public IEnumerable<T> RangeQuery(Vector pos, Vector size)
        {
            int cellStartX, cellStartY,
                cellEndX, cellEndY;
            getCellId(pos, out cellStartX, out cellStartY);
            getCellId(pos + size, out cellEndX, out cellEndY);

            for (int ix = cellStartX; ix <= cellEndX; ix++)
                for (int iy = cellStartY; iy <= cellEndY; iy++)
                {
                    var binId = getBinId(ix, iy, TableSize);
                    var t = hashTable[binId];

                    //check if it is a bin on the contour of the area. 
                    if (ix == cellStartX || ix == cellEndX || iy == cellStartY || iy == cellEndY)
                    {
                        // if so, we must check whether each item is inside the rect. 
                        foreach (var it in t)
                        {
                            var iPos = currentPos[it];
                            if (iPos.Inside(pos, size))
                                yield return it;
                        }
                    }
                    else
                        // otherwise yield all items. 
                        foreach (var it in t)
                            yield return it;
                }
        }
    }
}
