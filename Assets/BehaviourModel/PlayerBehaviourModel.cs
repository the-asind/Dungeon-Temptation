using System;
using UnityEngine;

namespace DungeonCreature.BehaviourModel
{
    public class PlayerBehaviourModel
    {
        public Player Player;

        public int ProvideMaxHealth()
        {
            return Player.MAX_HEALTH;
        }
        public int ProvideHealth()
        {
            return Player.Health;
        }
        public float ProvideAttackCooldown()
        {
            return Player.AttackCooldown;
        }
        public void ChangePlayerPosition(float x, float y)
        {
            Player.Move(x, y);
            PositionChanged?.Invoke();
        }

        public void OnDie()
        {
            Die?.Invoke();
        }
        public void TakeDamage(int damage)
        {
            Player.TakeDamage(damage);
            if (Player.Health <= 0)
                Die?.Invoke();
        }

        public void Attack(Enemy target)
        {
            Player.Attack(target);
        }

        public void TeleportToCoordinates(float x, float y)
        {
            Player.Move(x,y);
        }
        
        public Position ProvidePosition()
        {
            return Player.Position;
        }

        public float ProvideCooldown()
        {
            return Player.MoveCooldown;
        }

        public PlayerBehaviourModel(float x, float y)
        {
            Player = new Player();
            Player.Move(x,y);
            Player.Die += OnDie;
            Player.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            HealthChanged?.Invoke();
        }
        public event Action HealthChanged;
        public event Action Die;
        public event Action PositionChanged;
    }
}