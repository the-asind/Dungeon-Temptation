using System;
using UnityEngine;

namespace DungeonCreature
{
    public class Health : MonoBehaviour
    {
        private int health = 100;

        private readonly int MAX_HEALTH = 100;

        public void Damage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException("Damage can't be below zero!");
            health -= damage;

            if (health <= 0)
                Die();
        }

        public void Heal(int heal)
        {
            if (heal < 0)
                throw new ArgumentOutOfRangeException("Healing can't be below zero!");

            health = health + heal > MAX_HEALTH ? MAX_HEALTH : health + heal;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}