using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonCreature
{
    public class Inventory
    {
        private uint InventorySize { get; }
        private IEnumerable<Item> General { get; set; }

        public void Add(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (General.Count() < InventorySize)
                General = General.Append(item);
        }

        public Inventory()
        {
            General = new Item[InventorySize];
        }
    }
}