//using _Scripts;
//using _Scripts.DungeonGenerator;

using System;
using DungeonCreature;
using UnityEngine;

public class Player : Creature
{
    private int XpPerLevel;

    public int LevelUpPoints
    {
        get
        {
            int Level = (int)Xp / XpPerLevel, CurrentLevel = Agility + Strength + Intelligence;
            return (Level - CurrentLevel < 0) ? 0 : Level - CurrentLevel;
        }
    }

    public void LevelUpAgility() => Agility++;
    public void LevelUpStrength() => Strength++;
    public void LevelUpIntelligence() => Intelligence++;

    public void Loot(Item item)
    {
        Inventory.Add(item);
    }
    public void UseItem(HealingPotion potion)
    {
        Heal(potion.ProvideHeal());
    }

    public void UseItem(Weapon weapon)
    {
        SwapWeapon(weapon);
    }
    
    private void SwapWeapon(Weapon weapon)
    {
        Weapon = weapon;
    }
}