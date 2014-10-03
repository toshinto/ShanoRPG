using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Common;

namespace Engine.Objects
{
    class Inventory
    {
        const int BackpackWidth = 5;
        const int BackpackHeight = 4;
        const int BackpackSize = BackpackWidth * BackpackHeight;

        private int backpackItemCount;  //numberOfItemsInBackpack

        Item[,] Backpack;

        Dictionary<EquipSlot, Item> EquippedItems = new Dictionary<EquipSlot, Item>();

        public Inventory()
        {
            Backpack = new Item[BackpackWidth, BackpackHeight];
            //ItemsEquiped.Add(EquipSlot.Head, null);
            //ItemsEquiped.Add(EquipSlot.Torso, null);  //nqma nujda ot teq
            //ItemsEquiped.Add(EquipSlot.Hand, null);
        }

        public bool TryPickupItem(Item i)
        {
            //continue only if there is space in the backpack. 
            if(backpackItemCount == BackpackSize)
                return false;

            // are we always allowed to pick an item as the client requests?
            // what if the item is on the other side of the world?

            for (int j = 0; j < BackpackWidth; j++)
                for (int k = 0; k < BackpackHeight; k++)
                    if (Backpack[j, k] == null)
                    {
                        Backpack[j, k] = i;
                        backpackItemCount++;
                        return true;
                    }
                
            return false;
        }
        public bool TryEquipItem(int backpackX, int backpackY, EquipSlot slot)
        {
            //continue only if there is an item in this slot and it is equippable. 
            if (Backpack[backpackX, backpackY] == null || Backpack[backpackX, backpackY].ItemType == EquipSlot.None)
                return false;

            Item oldItem = null;
            EquippedItems.TryGetValue(slot, out oldItem);   //ako ima item go vzema, inache ne bara oldItem
            EquippedItems[slot] = Backpack[backpackX, backpackY];
            Backpack[backpackX, backpackY] = oldItem; 
            return true;
        }
        public bool TryDropItem(int backpackX, int backpackY)
        {
            if (Backpack[backpackX, backpackY] != null)
                return true;
            else return false;
        }
    }
}
