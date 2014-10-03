using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Objects
{
    enum EquipSlot
    {
        None,
        Head,
        Torso,
        Hand
    };
    class Item
    {
        public string ItemName;
        public string ItemIcon;
        public Buff ItemBonuses;
        public EquipSlot ItemType;

        public Item(string itemName, string itemIcon, Buff itemBonuses, EquipSlot itemType)
        {
            this.ItemName = itemName;
            this.ItemIcon = itemIcon;
            this.ItemBonuses = itemBonuses;
            this.ItemType = itemType;
        }

    }
}
