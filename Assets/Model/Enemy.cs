using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DungeonCreature
{
    public class Enemy : Creature
    {
        public Player Target;

        public Enemy() : base()
        {
            Target = null;
        }
    }
}