using System;
using UnityEngine;

namespace DungeonCreature
{
    public abstract class Creature : MonoBehaviour
    {
        public Health Health { get; set; }
        public double Defence { get; private set; }
        public float MoveCooldown { get; private set; }
        public float AttackCooldown { get; private set; }
        public byte Agility { get; private set; }
        public byte Strength { get; private set; }
        public byte Intelligence { get; private set; }
        public byte Level { get; private set; }
        //public Inventory Inventory { get; private set; }
        public void LevelUp()
        {
            if (Level == 255) return;
            Level++;
        }

        public abstract void Move();

        public Creature(double _defence = 0, float _moveCooldown = 0.7f,
            float _attackCooldown = 0.4f,
            byte _agility = 1, byte _strength = 1,
            byte _intelligence = 1, byte _level = 1)

        {
            Defence = (_defence >= 0) ? _defence : throw new Exception("Wrong defence value!");
            MoveCooldown = (_moveCooldown > 0) ? _moveCooldown : throw new Exception("Wrong moveCooldown value!");
            AttackCooldown = (_attackCooldown > 0) ? _attackCooldown : throw new Exception("Wrong attackCooldown value!");
            Agility = (_agility > 0) ? _agility : throw new Exception("Wrong agility value!");
            Strength = (_strength > 0) ? _strength : throw new Exception("Wrong strength value!");
            Intelligence = (_intelligence > 0) ? _intelligence : throw new Exception("Wrong intelligence value!");
            Level = (_level > 0) ? _level : throw new Exception("Wrong intelligence value!");
        }

        private void Start()
        {
            Health = gameObject.AddComponent<Health>();
        }
    }
}