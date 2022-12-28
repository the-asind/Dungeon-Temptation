using System;
using System.Numerics;
using DungeonCreature.Interfaces;
using Vector2 = UnityEngine.Vector2;
using Vector3 = System.Numerics.Vector3;

namespace DungeonCreature
{
    public abstract class Creature : ICreatureTakeDamage, ICreatureAttack
    {
        public int Health { get; set; }
        public int MAX_HEALTH { get; }
        public int Defence { get; set; }
        public float MoveCooldown { get; set; }
        public float AttackCooldown { get; set; }
        public int Agility { get; protected set; }
        public int Strength { get; protected set; }
        public int Intelligence { get; protected set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }
        public Inventory Inventory { get; private set; }
        public int Xp { get; set; }
        public Position Position { get; }
        
        public Creature(int _health = 100, int _maxHealth = 100,
            int _defence = 0, float _moveCooldown = 0.7f,
            float _attackCooldown = 0.4f, byte _agility = 1,
            byte _strength = 1, byte _intelligence = 1, byte _level = 1)

        {
            Health = _health;
            MAX_HEALTH = _maxHealth;
            Defence = (_defence >= 0) ? _defence : throw new ArgumentException("Wrong defence value!");
            MoveCooldown = (_moveCooldown > 0)
                ? _moveCooldown
                : throw new ArgumentException("Wrong moveCooldown value!");
            AttackCooldown = (_attackCooldown > 0)
                ? _attackCooldown
                : throw new ArgumentException("Wrong attackCooldown value!");
            Agility = (_agility > 0) ? _agility : throw new ArgumentException("Wrong agility value!");
            Strength = (_strength > 0) ? _strength : throw new ArgumentException("Wrong strength value!");
            Intelligence = (_intelligence > 0)
                ? _intelligence
                : throw new ArgumentException("Wrong intelligence value!");
            Level = (_level > 0) ? _level : throw new ArgumentException("Wrong intelligence value!");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Defence;
        }

        public void Move(float x, float y)
        {
            Position.ChangePosition(x,y);
        }

        public void Attack(ICreatureTakeDamage _creature)
        {
            switch (Weapon.Type)
            {
                case WeaponType.Melee:
                    _creature.TakeDamage(Weapon.Damage + Strength);
                    return;
                case WeaponType.Ranged:
                    _creature.TakeDamage(Weapon.Damage + Agility);
                    return;
                case  WeaponType.Magic:
                    _creature.TakeDamage(Weapon.Damage + Intelligence);
                    return;
            }
        }

        ~Creature() { } 
        public void Heal(int heal)
        {
            Health = Health + heal > MAX_HEALTH ? MAX_HEALTH : Health + heal;
        }
    }
}