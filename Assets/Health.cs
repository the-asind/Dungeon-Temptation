using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int health = 100;

        private int MAX_HEALTH = 100;
        
        public void Damage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException("Damage can't be below zero!");
            this.health -= damage;

            if (health <= 0)
                Die();

        }

        public void Heal(int heal)
        {
            if (heal < 0)
                throw new ArgumentOutOfRangeException("Healing can't be below zero!");

            health = (health + heal > MAX_HEALTH) ? MAX_HEALTH : health + heal;
        }

        private void Die()
        {
            Debug.Log("i'm dead");
            Destroy(gameObject);
        }
    }
}