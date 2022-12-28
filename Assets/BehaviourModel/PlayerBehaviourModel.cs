using System;
using UnityEngine;

namespace DungeonCreature.BehaviourModel
{
    public class PlayerBehaviourModel
    {
        public Player Player = new Player();

        public void ChangePlayerPosition(float x, float y)
        {
            Player.Move(x, y);
            PositionChanged?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            Player.TakeDamage(damage);
            if (Player.Health <= 0)
                Die?.Invoke();
        }
        public Position ProvidePosition()
        {
            return Player.Position;
        }
        public float ProvideCooldown()
        {
            return Player.MoveCooldown;
        }

        public event Action Die;
        public event Action PositionChanged;

        public void TeleportToCoordinates(float x, float y)
        {
            Player.Move(x,y);
        }
    }
}