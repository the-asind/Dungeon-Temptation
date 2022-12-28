using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealingPotionTest
{
    [UnityTest]
    public IEnumerator GetHeal()
    {
        HealingPotion healingPotion = new HealingPotion(100);
        Assert.Equals(100, healingPotion.ProvideHeal());
        yield return null;
    }
}
