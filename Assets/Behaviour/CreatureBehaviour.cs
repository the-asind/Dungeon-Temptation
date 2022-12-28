using System;
using UnityEngine;

namespace DungeonCreature
{
    public class CreatureBehaviour : BehaviourModel.BehaviourModel 
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

        public void Dispose()
        {
           base.Dispose(); 
        }
    }
}