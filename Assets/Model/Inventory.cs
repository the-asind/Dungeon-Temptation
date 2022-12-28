using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity.VisualScripting.ReorderableList;

namespace DungeonCreature
{
    public class Inventory
    {
        private uint InventorySize { get; }
        public IEnumerable<Item> General { get; set; }

        public void Add(Item item)
        {
            
            if (item == null)
                throw new ArgumentNullException("Item can't be null!");
            if (General.Count() < InventorySize)
                General = General.Append(item);
        }
         
        public Inventory()
        {
            General = new Item[InventorySize];
        }
    }
}
