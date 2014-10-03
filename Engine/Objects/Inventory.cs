using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Objects
{
    class Inventory
    {
        const int BackpackWidht=5;
        const int BackpackHeight=4;
        private int numberOfItemsInBackspack;
        public Item[,] Backpack;
        Dictionary<EquipSlot, Item>ItemsEquiped = new Dictionary<EquipSlot, Item>();

        public Inventory()
        {
            numberOfItemsInBackspack = 0;
            Backpack = new Item[BackpackWidht, BackpackHeight];
            ItemsEquiped.Add(EquipSlot.Head, null);
            ItemsEquiped.Add(EquipSlot.Torso, null);
            ItemsEquiped.Add(EquipSlot.Hand, null);
        }
        public bool TryPickUpItem(Item i)
        {
            if(numberOfItemsInBackspack == BackpackWidht * BackpackHeight)
                return false;
            else 
            {
                for (int j = 0; j < BackpackWidht; j++)
                    for (int k = 0; k < BackpackHeight; k++)
                        if (Backpack[j, k] == null)
                        {
                            Backpack[j, k] = i;
                            numberOfItemsInBackspack++;
                            return true;
                        }                   
                return false;
            }
        }
        public bool TryEquipItem(int backpackX, int backpackY, EquipSlot slot)
        {
            Item temp;
            if (Backpack[backpackX, backpackY] != null && Backpack[backpackX, backpackY].ItemType != EquipSlot.None)
            {
                temp = ItemsEquiped[slot];
                ItemsEquiped[slot] = Backpack[backpackX, backpackY];
                Backpack[backpackX, backpackY] = temp; 
                return true;
            }
            else return false;
        }
        public bool TryDropItem(int backpackX, int backpackY)
        {
            if (Backpack[backpackX, backpackY] != null)
                return true;
            else return false;
        }
    }
}
