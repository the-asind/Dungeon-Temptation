using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTest
{
    [UnityTest]
    public IEnumerator TakeDamage()
    {
        Player player = new Player();
        int health1 = player.Health;
        player.TakeDamage(5);
        Assert.Less(player.Health, health1);
        yield return null;
    }
}
