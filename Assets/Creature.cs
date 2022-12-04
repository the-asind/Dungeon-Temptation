using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Creature : MonoBehaviour
    {
        public double Health { get; private set; }
        public double Defence { get; private set; }
        public float MoveCooldown { get; private set; }
        public float AttackCooldown { get; private set; }
        public byte Agility { get; private set; }
        public byte Strength { get; private set; }
        public byte Intelligence { get; private set; }
        public byte Level { get; private set; }
        public Inventory Inventory { get; private set; }
        
        public void LevelUp()
        {
            if (Level == 255) return;
            Level++;
        }

        public abstract void Move();

        public abstract void Attack();

        public Creature(double _health = 100, double _defence = 0, float _cooldown = 0.7f,
            byte _agility = 1, byte _strength = 1,
            byte _intelligence = 1, byte _level = 1)

        {
            Health = (_health > 0) ? _health : throw new Exception("Wrong health value!");
            Defence = (_defence >= 0) ? _defence : throw new Exception("Wrong defence value!");
            Cooldown = (_cooldown > 0) ? _cooldown : throw new Exception("Wrong cooldown value!");
            Agility = (_agility > 0) ? _agility : throw new Exception("Wrong agility value!");
            Strength = (_strength > 0) ? _strength : throw new Exception("Wrong strength value!");
            Intelligence = (_intelligence > 0) ? _intelligence : throw new Exception("Wrong intelligence value!");
            Level = (_level > 0) ? _level : throw new Exception("Wrong intelligence value!");
        }
    }
}