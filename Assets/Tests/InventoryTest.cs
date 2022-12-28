using System;
using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTest
{
    [UnityTest]
    public IEnumerator AddNull()
    {
        Inventory inventory = new Inventory();
        Assert.Throws<ArgumentNullException>(() => inventory.Add(null));
        yield return null;
    }

    [UnityTest]
    public IEnumerator AddNotNullItem()
    {
        Inventory inventory = new Inventory();
        Assert.DoesNotThrow(() => inventory.Add(new Weapon()));
        yield return null;
    }
}
