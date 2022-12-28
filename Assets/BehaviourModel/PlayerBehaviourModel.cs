using System;
using UnityEngine;

namespace DungeonCreature.BehaviourModel
{
    public class PlayerBehaviourModel
    {
        public Player Player;

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
        }
        public event Action Die;
        public event Action PositionChanged;
    }
}