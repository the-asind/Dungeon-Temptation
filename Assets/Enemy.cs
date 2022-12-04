using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public enum Direction { Left, Up, Right, Down }
    public class Enemy : MonoBehaviour
    {
        public Transform player;
        private Vector2 movement;
        private RaycastHit2D hit;
        private BoxCollider2D boxCollider;
        public float movementSpeed = 1f;
        public float Cooldown = 0.3f;
        public float nextWalkTime = 0;
        public Direction Direction = Direction.Left;
        private void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            if (Time.time < nextWalkTime) return;
            Vector3 direction = player.position - transform.position; 

            // Sprite rotation
            if (direction.x > 0)
                transform.localScale = new Vector3(6.25f, 6.25f, 6.25f);
            else if (direction.x < 0)
                transform.localScale = new Vector3(-6.25f, 6.25f, 6.25f);

            // X axis collidetation
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(direction.x, direction.y),
                Mathf.Abs(direction.x * movementSpeed) + Mathf.Abs(direction.y * movementSpeed),
                LayerMask.GetMask("Actor", "Blocking"));

            if (hit.collider == null && Time.time > nextWalkTime)
            {
                if (player.position.x < transform.position.x && Direction == Direction.Left)
                {
                    transform.Translate(transform.position.x - movementSpeed, 0, 0);
                    nextWalkTime = Time.time + Cooldown;
                    Direction = Direction.Right;
                }

                if (player.position.x > transform.position.x && Direction == Direction.Right)
                {
                    transform.Translate(transform.position.x + movementSpeed, 0, 0);
                    nextWalkTime = Time.time + Cooldown;
                    Direction = Direction.Down;
                }

                if (player.position.y < transform.position.y && Direction == Direction.Down)
                {
                    transform.Translate(0, transform.position.y - movementSpeed, 0);
                    nextWalkTime = Time.time + Cooldown;
                    Direction = Direction.Up;
                }

                if (player.position.y > transform.position.y && Direction == Direction.Up)
                {
                    transform.Translate(0, transform.position.y + movementSpeed, 0);
                    nextWalkTime = Time.time + Cooldown;
                    Direction = Direction.Left;
                }
                nextWalkTime += Cooldown;
            }
        }
    }
}