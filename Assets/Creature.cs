using System;
using UnityEngine;

namespace DungeonCreature
{
    public abstract class Creature
    {
        public uint Health { get; set; }
        public uint MAX_HEALTH { get; }
        public double Defence { get; private set; }
        public float MoveCooldown { get; set; }
        public float AttackCooldown { get; set; }
        public uint Agility { get; private set; }
        public uint Strength { get; private set; }
        public uint Intelligence { get; private set; }
        public uint Level { get; private set; }
        //public Inventory Inventory { get; private set; }
        public void LevelUp()
        {
            if (Level == 255) return;
            Level++;
        }

        public Creature(uint _health = 100, uint _maxHealth = 100, 
            double _defence = 0, float _moveCooldown = 0.7f,
            float _attackCooldown = 0.4f, byte _agility = 1, 
            byte _strength = 1, byte _intelligence = 1, byte _level = 1)

        {
            Health = _health;
            MAX_HEALTH = _maxHealth;
            Defence = (_defence >= 0) ? _defence : throw new ArgumentException("Wrong defence value!");
            MoveCooldown = (_moveCooldown > 0) ? _moveCooldown : throw new ArgumentException("Wrong moveCooldown value!");
            AttackCooldown = (_attackCooldown > 0) ? _attackCooldown : throw new ArgumentException("Wrong attackCooldown value!");
            Agility = (_agility > 0) ? _agility : throw new ArgumentException("Wrong agility value!");
            Strength = (_strength > 0) ? _strength : throw new ArgumentException("Wrong strength value!");
            Intelligence = (_intelligence > 0) ? _intelligence : throw new ArgumentException("Wrong intelligence value!");
            Level = (_level > 0) ? _level : throw new ArgumentException("Wrong intelligence value!");
        }

        public void TakeDamage(uint damage)
        {
            Health -= damage;
        }

        public void Heal(uint heal)
        {
            Health = Health + heal > MAX_HEALTH ? MAX_HEALTH : Health + heal;
        }
    }
}