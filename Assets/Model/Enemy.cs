using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DungeonCreature
{
    public class Enemy : Creature
    {
        public Player Player;

        public Enemy() : base()
        {
            Player = new Player();
        }
    }
}