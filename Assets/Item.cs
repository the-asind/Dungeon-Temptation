using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Sword,
        Coins,
        Shurikens,
        XP,
        Bow,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.XP: return ItemAssets.Instance.XPPointsSprite;
        }
    }
}
