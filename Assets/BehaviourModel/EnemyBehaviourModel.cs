using System;

namespace DungeonCreature.BehaviourModel
{
    public class EnemyBehaviourModel
    {
        public Enemy Enemy;

        public bool CheckTarget()
        {
            return (Enemy.Target == null);
        }

        public float ProvideAttackCooldown()
        {
            return Enemy.AttackCooldown;
        }

        public void Attack(Player target)
        {
            Enemy.Attack(target);
        }

        public void OnDie()
        {
            Die?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            Enemy.TakeDamage(damage);
            HealthChanged?.Invoke();
        }

        public void ChangePosition(float x, float y)
        {
            Enemy.Move(x, y);
            PositionChanged?.Invoke();
        }

        public float ProvideCooldown()
        {
            return Enemy.MoveCooldown;
        }

        public Position ProvidePosition()
        {
            return Enemy.Position;
        }

        public EnemyBehaviourModel(float x, float y)
        {
            Enemy = new Enemy();
            Enemy.Die += OnDie;
            ChangePosition(x, y);
        }

        public event Action Die;
        public event Action HealthChanged;
        public event Action PositionChanged;
    }
}