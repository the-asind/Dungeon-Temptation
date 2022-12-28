using System;

namespace DungeonCreature.BehaviourModel
{
    public class EnemyBehaviourModel : BehaviourModelBase
    {
        public Enemy Enemy = new Enemy();

        public Player CheckTarget()
        {
            return Enemy.Target;
        }

        public void TakeDamage(int damage)
        {
            Enemy.TakeDamage(damage);
            if (Enemy.Health <= 0)
                Die?.Invoke();
            HealthChanged?.Invoke(); 
        }
        public void ChangePosition(float x, float y)
        {
            Enemy.Move(x,y);
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

        public event Action Die;
        public event Action HealthChanged;
        public event Action PositionChanged;
    }
}