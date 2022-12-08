using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.XP, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Coins, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Shurikens, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Bow, amount = 1 });
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
