using System;
using System.Net;
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
        public Position Position { get; set; }
        
        public Creature(int _health = 100, int _maxHealth = 100,
            int _defence = 0, float _moveCooldown = 0.25f,
            float _attackCooldown = 0.4f, byte _agility = 1,
            byte _strength = 1, byte _intelligence = 1, byte _level = 1)

        {
            Weapon = new MeleeWeapon(100, 1, WeaponType.Melee);
            if (_defence < 0)
                throw new ArgumentException("Wrong defence value!");
            Defence = _defence;

            if (_moveCooldown <= 0)
                throw new ArgumentException("Wrong moveCooldown value!");
            MoveCooldown = _moveCooldown;

            if (_attackCooldown <= 0)
                throw new ArgumentException("Wrong attackCooldown value!");
            AttackCooldown = _attackCooldown;

            if (_agility <= 0)
                throw new ArgumentException("Wrong agility value!");
            Agility = _agility;

            if (_strength <= 0)
                throw new ArgumentException("Wrong strength value!");
            Strength = _strength;

            if (_intelligence <= 0)
                throw new ArgumentException("Wrong intelligence value!");
            Intelligence = _intelligence;

            if (_level <= 0)
                throw new ArgumentException("Wrong level value!");
            Level = _level;

            Health = _health;
            MAX_HEALTH = _maxHealth;

        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Defence;
            if (Health <= 0)
                Die?.Invoke();
        }

        public void Move(float x, float y)
        {
            Position = new Position(x, y);
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

        public event Action Die;
    }
}