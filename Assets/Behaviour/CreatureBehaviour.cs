using System;
using UnityEngine;

namespace DungeonCreature
{
    public class CreatureBehaviour : MonoBehaviour
    {
        private Creature _creature;

        private void Start()
        {
            _creature = gameObject.GetComponent<Creature>();
        }
        private void Update()
        {
            if (_creature.Health <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}